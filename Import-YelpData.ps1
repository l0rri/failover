# CS 451-02 Spring 2018
# Team "The IT Crowd" (Geilenfeldt, Rink, Williams)
# Milestone 2, Part 3: Yelp Data Importer

[CmdletBinding()]
param (
    # The path (absolute or relative) to the pre-provided Yelp data folder.
    # This will default to looking inside a folder named "Yelp-CptS451-2018" stored alongside the script itself.
    [ValidateScript({
        If (-not (Test-Path $_ -ErrorAction SilentlyContinue)) {
            throw [ArgumentException]::new("Specified path does not exist.", "YelpDataPath")
        } 
        
        $Param = $_

        @(
            "yelp_business.json"
            "yelp_checkin.json"
            "yelp_review.json"
            "yelp_user.json"
        ) | Foreach-Object {
            If (-not (Test-Path (Join-Path $Param $_) -ErrorAction SilentlyContinue)) {
                throw [ArgumentException]::new("Specified folder does not contain the required document `"$_`".", "YelpDataPath")            
            }
        }
        Remove-Variable Param
        Return $true       
    })]
    [Parameter(
        ValueFromPipeline = $true,
        ValueFromPipelineByPropertyName = $true,
        Position = 0,
        HelpMessage = "Provide the path to the pre-generated yelp_checkin.json file. Relative and absolute paths are supported."
    )]
    [String]$YelpDataPath = (Join-Path $(If ($PSScriptRoot -eq "") {$PWD} Else {$PSScriptRoot}) "Yelp-CptS451-2018")
)
# First, import the assemblies we need.

# System.Threading.Tasks.Extensions
try {
    Write-Verbose "Importing assembly System.Threading.Tasks.Extensions..."
    $STTEPath = (Get-Package System.Threading.Tasks.Extensions -RequiredVersion 4.3.0 -ErrorAction Stop).Source | Split-Path -Parent
    Add-Type -LiteralPath (Join-Path $STTEPath "lib\portable-net45+win8+wp8+wpa81\System.Threading.Tasks.Extensions.dll")
    Write-Verbose "Import complete."
}
catch {
    throw
}

# Npgsql
try {
    Write-Verbose "Importing assembly Npgsql..."
    $NpgsqlPath = (Get-Package Npgsql -RequiredVersion 3.2.6 -ErrorAction Stop).Source | Split-Path -Parent
    Add-Type -LiteralPath (Join-Path $NpgsqlPath "lib\net451\Npgsql.dll")
    Write-Verbose "Import complete."
}
catch {
    throw
}

# Define our table column-maps, for converting .NET-typed attributes to columns
# Key-names in map value dictionary arrays are as follows:
# NN: .NET Name
# NT: .NET Type (what the object should be casted to before passing to Npgsql)
# SN: PostgreSQL (table) name
# ST: Npgsql Type (must be an [NpgsqlDbType] enum value name)
$Maps = @{
    yelp_business = @(
        @{NN = "business_id";    NT = [String];  ST = "Varchar";    SN = "business_id"; }
        @{NN = "name";           NT = [String];  ST = "Varchar";    SN = "name";        }
        @{NN = "address";        NT = [String];  ST = "Varchar";    SN = "address";     }
        @{NN = "city";           NT = [String];  ST = "Varchar";    SN = "city";        }
        @{NN = "state";          NT = [String];  ST = "Varchar";    SN = "state";       }
        @{NN = "postal_code";    NT = [String];  ST = "Varchar";    SN = "postal_code"; }
        @{NN = "is_Open";        NT = [int];     ST = "Boolean";    SN = "is_Open";     }
        @{NN = "stars";          NT = [decimal]; ST = "Numeric";    SN = "stars";       }
        @{NN = "review_count";   NT = [int];     ST = "Integer";    SN = "review_count";}
        @{NN = "latitude";       NT = [Double];  ST = "Double";     SN = "latitude";    }
        @{NN = "longitude";      NT = [Double];  ST = "Double";     SN = "longitude";   }
    )

    yelp_business_attributes = @(
        @{NN = "AcceptsInsurance";			    NT = [bool];	ST = "Boolean"; SN = "accepts_insurance"}
        @{NN = "AgesAllowed";				    NT = [String];	ST = "Varchar"; SN = "ages_allowed"}
        @{NN = "Alcohol";					    NT = [String];	ST = "Varchar"; SN = "alcohol"}
        @{NN = "BikeParking";				    NT = [bool];	ST = "Boolean"; SN = "bike_parking"}
        @{NN = "BusinessAcceptsBitcoin";		NT = [bool];	ST = "Boolean"; SN = "business_accepts_bitcoin"}
        @{NN = "BusinessAcceptsCreditCards";	NT = [bool];	ST = "Boolean"; SN = "business_accepts_credit_cards"}
        @{NN = "ByAppointmentOnly";			    NT = [bool];	ST = "Boolean"; SN = "by_appointment_only"}
        @{NN = "BYOB";						    NT = [bool];	ST = "Boolean"; SN = "byob"}
        @{NN = "BYOBCorkage";				    NT = [String];	ST = "Varchar"; SN = "byobcorkage"}
        @{NN = "Caters";						NT = [bool];	ST = "Boolean"; SN = "caters"}
        @{NN = "CoatCheck";					    NT = [bool];	ST = "Boolean"; SN = "coat_check"}
        @{NN = "Corkage";					    NT = [bool];	ST = "Boolean"; SN = "corkage"}
        @{NN = "DogsAllowed";				    NT = [bool];	ST = "Boolean"; SN = "dogs_allowed"}
        @{NN = "DriveThru";					    NT = [bool];	ST = "Boolean"; SN = "drive_thru"}
        @{NN = "GoodForDancing";				NT = [bool];	ST = "Boolean"; SN = "good_for_dancing"}
        @{NN = "GoodForKids";				    NT = [bool];	ST = "Boolean"; SN = "good_for_kids"}
        @{NN = "HappyHour";					    NT = [bool];	ST = "Boolean"; SN = "happy_hour"}
        @{NN = "HasTV";						    NT = [bool];	ST = "Boolean"; SN = "has_tv"}
        @{NN = "NoiseLevel";					NT = [String];	ST = "Varchar"; SN = "noise_level"}
        @{NN = "Open24Hours";				    NT = [bool];	ST = "Boolean"; SN = "open24hours"}
        @{NN = "OutdoorSeating";				NT = [bool];	ST = "Boolean"; SN = "outdoor_seating"}
        @{NN = "RestaurantsAttire";			    NT = [String];	ST = "Varchar"; SN = "restaurants_attire"}
        @{NN = "RestaurantsCounterService";	    NT = [bool];	ST = "Boolean"; SN = "restaurants_counter_service"}
        @{NN = "RestaurantsDelivery";		    NT = [bool];	ST = "Boolean"; SN = "restaurants_delivery"}
        @{NN = "RestaurantsGoodForGroups";	    NT = [bool];	ST = "Boolean"; SN = "restaurants_good_for_groups"}
        @{NN = "RestaurantsPriceRange2";		NT = [int]; 	ST = "Integer"; SN = "restaurants_price_range2"}
        @{NN = "RestaurantsReservations";	    NT = [bool];	ST = "Boolean"; SN = "restaurants_reservations"}
        @{NN = "RestaurantsTableService";	    NT = [bool];	ST = "Boolean"; SN = "restaurants_table_service"}
        @{NN = "RestaurantsTakeOut";			NT = [bool];	ST = "Boolean"; SN = "restaurants_take_out"}
        @{NN = "Smoking";					    NT = [String];	ST = "Varchar"; SN = "smoking"}
        @{NN = "WheelchairAccessible";		    NT = [bool];	ST = "Boolean"; SN = "wheelchair_accessible"}
        @{NN = "WiFi";						    NT = [String];	ST = "Varchar"; SN = "wi_fi"}
    )

    yelp_ambience_attribset = (@(
        "casual"  
        "classy"  
        "divey"   
        "hipster" 
        "intimate"
        "romantic"
        "touristy"
        "trendy"  
        "upscale" 
    ) | ForEach-Object {@{
        NN = $_
        NT = [bool]
        ST = "Boolean"
        SN = ($_ -replace '-','_')
    }})

    yelp_bestnight_attribset = (@(
        "sunday"
        "monday"
        "tuesday"
        "wednesday"
        "thursday"
        "friday"
        "saturday"
    ) | ForEach-Object {@{
        NN = $_
        NT = [bool]
        ST = "Boolean"
        SN = ($_ -replace '-','_')
    }})

    yelp_music_attribset = (@(
        "background"
        "dj"
        "jukebox"
        "karaoke"
        "live"
        "no_music"
        "video"
    ) | ForEach-Object {@{
        NN = $_
        NT = [bool]
        ST = "Boolean"
        SN = ($_ -replace '-','_')
    }})

    yelp_dietary_restrictions_attribset = (@(
        "dairy-free"
        "gluten-free"
        "halal"
        "kosher"
        "soy-free"
        "vegan"
        "vegetarian"
    ) | ForEach-Object {@{
        NN = $_
        NT = [bool]
        ST = "Boolean"
        SN = ($_ -replace '-','_')
    }})

    yelp_good_meals_attribset = (@(
        "breakfast"
        "brunch"
        "lunch"
        "dessert"
        "dinner"
        "latenight"
    ) | ForEach-Object {@{
        NN = $_
        NT = [bool]
        ST = "Boolean"
        SN = ($_ -replace '-','_')
    }})

    yelp_hair_specialization_attribset = (@(
        "african_american"
        "asian"
        "coloring"
        "curly"
        "extensions"
        "kids"
        "perms"
        "straight_perms"
    ) | ForEach-Object {@{
        NN = $_
        NT = [bool]
        ST = "Boolean"
        SN = ($_ -replace '-','_')
    }})

    yelp_parking_attribset = (@(
        "garage"
        "lot"
        "street"
        "valet"
        "validated"
    ) | ForEach-Object {@{
        NN = $_
        NT = [bool]
        ST = "Boolean"
        SN = ($_ -replace '-','_')
    }})

    yelp_user = @(
        @{NN = "user_id";       NT = [String];  ST = "Varchar"; SN = "user_id"}
        @{NN = "name";          NT = [String];  ST = "Varchar"; SN = "name"}
        @{NN = "review_count";  NT = [int];     ST = "Integer"; SN = "review_count"}
        @{NN = "yelping_since"; NT = [DateTime];ST = "Date";    SN = "yelping_since"}
        @{NN = "fans";          NT = [int];     ST = "Integer"; SN = "fans"}
    )

    yelp_review = @(
        @{NN = "business_id";   NT = [String];      ST = "Varchar"; SN = "business_id"}
        @{NN = "review_id";     NT = [String];      ST = "Varchar"; SN = "review_id"}
        @{NN = "user_id";       NT = [String];      ST = "Varchar"; SN = "user_id"}
        @{NN = "stars";         NT = [int];         ST = "Integer"; SN = "stars"}
        @{NN = "date";          NT = [DateTime];    ST = "Date";    SN = "date"}
        @{NN = "text";          NT = [String];      ST = "Text";    SN = "text"}
        @{NN = "useful";        NT = [int];         ST = "Integer"; SN = "useful"}
        @{NN = "funny";         NT = [int];         ST = "Integer"; SN = "funny"}
        @{NN = "cool";          NT = [int];         ST = "Integer"; SN = "cool"}
    )

    yelp_checkin = @(
        @{NN = "ID";        NT = [String];  ST = "Varchar"; SN = "business_id"}
        @{NN = "DayOfWeek"; NT = [String];  ST = "Varchar"; SN = "day_of_week"}
        @{NN = "Morning";   NT = [int];     ST = "Integer"; SN = "morning"}
        @{NN = "Afternoon"; NT = [int];     ST = "Integer"; SN = "afternoon"}
        @{NN = "Evening";   NT = [int];     ST = "Integer"; SN = "evening"}
        @{NN = "Night";     NT = [int];     ST = "Integer"; SN = "night"}
    )
}

$AttribSetMaps = @{
    Ambience = "yelp_ambience_attribset"
    BestNights = "yelp_bestnight_attribset"
    BusinessParking = "yelp_parking_attribset"
    DietaryRestrictions = "yelp_dietary_restrictions_attribset"
    GoodForMeal = "yelp_good_meals_attribset"
    HairSpecializesIn = "yelp_hair_specialization_attribset"
    Music = "yelp_music_attribset"
}


If ((Test-Path ".\ConnectionString.clixml") -and ((Import-Clixml ".\ConnectionString.clixml") -as [Npgsql.NpgsqlConnectionStringBuilder] -ne $null)) {
    Write-Verbose "Using stored ConnectionString.clixml"
    $ConnectionString = (Import-Clixml ".\ConnectionString.clixml") -as [Npgsql.NpgsqlConnectionStringBuilder]
} Else {
    $ConnectionString = [Npgsql.NpgsqlConnectionStringBuilder]::new()
    
    Write-Verbose "Building connection string."
    $ConnectionString.Host = ""
    $ConnectionString.Username = "postgres"
    $ConnectionString.Password = ""
    $ConnectionString.Database = "451Project"

}

$Connection = [Npgsql.NpgsqlConnection]::new($ConnectionString)

Write-Verbose "Opening connection to PostgreSQL."
try {
    $Connection.Open()
    Write-Verbose "Connection opened successfully."
}
catch {
    throw "Failed to connect to PostgreSQL: $_"
}

# First, work on the businesses.
Write-Verbose "Importing business data."
$YBusiness = Get-Content (Join-Path $YelpDataPath "yelp_business.json") | ConvertFrom-Json
Write-Verbose "Data import complete."

Write-Verbose "Processing basic business data."
$YBusiness | ForEach-Object -ErrorAction Stop -Begin {
    Write-Verbose "Starting binary-copy operation to yelp_business table."    
    try {
        $YBusinessCopier = $Connection.BeginBinaryImport("COPY yelp_business (
            $(($Maps["yelp_business"] | ForEach-Object SN) -join ", ")
        ) FROM STDIN (FORMAT BINARY)")
    }
    catch {
        throw "Failed to open binary-copy importer on table yelp_business: $_"
    }
    
    $RowCount = 0
} -Process {
    $Item = $_
    $YBusinessCopier.StartRow()
    $Maps["yelp_business"] | ForEach-Object {
        If ($Item.($_.NN) -ne $null) {
            $YBusinessCopier.Write(($Item.($_.NN) -as $($_.NT)), [NpgsqlTypes.NpgsqlDbType]::($_.ST))
        } Else {
            $YBusinessCopier.WriteNull()
        }
    }
    $RowCount++
} -End {
    Write-Verbose "Committing copy... [$RowCount rows]"
    $YBusinessCopier.Close()
    Remove-Variable YBusinessCopier,Item,RowCount
    Write-Verbose "Copy complete."
}

Write-Verbose "Processing business simple attribute data."
# Now, work on simple attributes for those businesses.
$YBusiness | Where-Object attributes | ForEach-Object -ErrorAction Stop -Begin {
    Write-Verbose "Starting binary-copy operation to yelp_business_attributes table."
    try {
        $YBusAttribCopier = $Connection.BeginBinaryImport("COPY yelp_business_attributes (
            $((@("business_id") + ($Maps["yelp_business_attributes"] | ForEach-Object SN)) -join ', ')
        ) FROM STDIN (FORMAT BINARY)")
    }
    catch {
        throw "Failed to open binary-copy importer on table yelp_business_attributes: $_"         
    }            
    $RowCount = 0
} -Process {
    $Attrib = $_.attributes
    $YBusAttribCopier.StartRow()
    $YBusAttribCopier.Write($_.business_id, [NpgsqlTypes.NpgsqlDbType]::Varchar)

    $Maps["yelp_business_attributes"] | ForEach-Object {
        If ($Attrib.($_.NN) -ne $null) {
            $YBusAttribCopier.Write(($Attrib.($_.NN) -as $($_.NT)), [NpgsqlTypes.NpgsqlDbType]::($_.ST))
        } Else {
            $YBusAttribCopier.WriteNull()
        }
    }
    $RowCount++
} -End {
    Write-Verbose "Committing copy... [$RowCount rows]"
    $YBusAttribCopier.Close()
    Remove-Variable YBusAttribCopier,Attrib,RowCount
    Write-Verbose "Copy complete."
}

Write-Verbose "Processing business flag attribute-set data."
# Now, handle boolean flag-attribute sets.
$AttribSetMaps.GetEnumerator() | ForEach-Object {
    $AttribName = $_.Key
    $MapName = $_.Value

    Write-Verbose "Processing attribute-set $AttribName [$MapName]."
    $YBusiness | Where-Object {
        $_.attributes -and $_.attributes.$AttribName
    } | ForEach-Object -Begin {
        Write-Verbose "Starting binary-copy operation to $MapName table."
        try {
            $YBusAttribSetCopier = $Connection.BeginBinaryImport("COPY $MapName (
                $((@("business_id") + ($Maps[$MapName] | ForEach-Object SN)) -join ', ')
            ) FROM STDIN (FORMAT BINARY)")
        }
        catch {
            throw "Failed to open binary-copy importer on table $MapName`: $_"         
        }            
        $RowCount = 0
    } -Process {
        $FlagSet = $_.attributes.$AttribName
        $YBusAttribSetCopier.StartRow()
        $YBusAttribSetCopier.Write($_.business_id, [NpgsqlTypes.NpgsqlDbType]::Varchar)

        $Maps[$MapName] | ForEach-Object {
            If ($FlagSet.($_.NN) -ne $null) {
                $YBusAttribSetCopier.Write(($FlagSet.($_.NN) -as $($_.NT)), [NpgsqlTypes.NpgsqlDbType]::($_.ST))
            } Else {
                $YBusAttribSetCopier.WriteNull()
            }
        }
        $RowCount++
    } -End {
        Write-Verbose "Committing copy... [$RowCount rows]"
        $YBusAttribSetCopier.Close()
        Remove-Variable YBusAttribSetCopier,FlagSet,RowCount
        Write-Verbose "Copy complete."
    }   
    
}
Write-Verbose "Attribute-set data complete."

Write-Verbose "Processing business categorical data."
# Now, copy over categories.
$YBusiness | Where-Object categories | ForEach-Object -ErrorAction Stop -Begin {
    Write-Verbose "Starting binary-copy operation to yelp_business_categories table."
    try {
        $YBusCategoryCopier = $Connection.BeginBinaryImport("COPY yelp_business_categories (
            business_id, category_name
        ) FROM STDIN (FORMAT BINARY)")
    }
    catch {
        throw "Failed to open binary-copy importer on table yelp_business_categories: $_"                     
    }    
    $RowCount = 0
} -Process {
    $ID = $_.business_id
    $_.categories | ForEach-Object {
        $YBusCategoryCopier.StartRow()
        $YBusCategoryCopier.Write($ID, [NpgsqlTypes.NpgsqlDbType]::Varchar)
        $YBusCategoryCopier.Write($_, [NpgsqlTypes.NpgsqlDbType]::Varchar)
    }
    $RowCount++
} -End {
    Write-Verbose "Committing copy... [$RowCount rows]"
    $YBusCategoryCopier.Close()
    Remove-Variable YBusCategoryCopier,ID,RowCount
    Write-Verbose "Copy complete."
}

Write-Verbose "Processing business hours-of-operation data."
# Finally, copy over the business' hours of operation.
$YBusiness | ForEach-Object -Begin {
    Write-Verbose "Starting binary-copy operation to yelp_business_hours table."
    try {
        $YBusHoursCopier = $Connection.BeginBinaryImport("COPY yelp_business_hours (
            business_id, day_of_week, open, close
        ) FROM STDIN (FORMAT BINARY)")
    }
    catch {
        throw "Failed to open binary-copy importer on table yelp_business_hours: $_"                     
    }    
    $RowCount = 0
} -Process {
    $ID = $_.business_id
    $Hours = $_.Hours
    $Hours | Get-Member -MemberType NoteProperty | ForEach-Object {
        $YBusHoursCopier.StartRow()
        $YBusHoursCopier.Write($ID, [NpgsqlTypes.NpgsqlDbType]::Varchar)
        # The day of the week (name of the subkey)
        $YBusHoursCopier.Write($_.Name, [NpgsqlTypes.NpgsqlDbType]::Varchar)
        # Write the open time, then the close time.
        $Hours.($_.Name) -split "-" | ForEach-Object {
            $YBusHoursCopier.Write([TimeSpan]$_, [NpgsqlTypes.NpgsqlDbType]::Time)
        }
    }
    $RowCount++
} -End {
    Write-Verbose "Committing copy... [$RowCount rows]"
    $YBusHoursCopier.Close()
    Remove-Variable YBusHoursCopier,ID,Hours,RowCount
    Write-Verbose "Copy complete."
}

# We're done with the Business data, so let's get rid of it to save on memory.
Remove-Variable YBusiness

Write-Verbose "Processing user data."
# In this case, as the User data is ~10x the size of the Business data, we're going to stream it in.
# This should minimize memory consumption.
Get-Content (Join-Path $YelpDataPath "yelp_user.json") | ConvertFrom-Json | ForEach-Object -ErrorAction Stop -Begin {
    Write-Verbose "Starting binary-copy operation to yelp_user table."
    try {
        $YUserCopier = $Connection.BeginBinaryImport("COPY yelp_user (
            $(($Maps["yelp_user"] | ForEach-Object SN) -join ", ") 
        ) FROM STDIN (FORMAT BINARY)")
    }
    catch {
        throw "Failed to open binary-copy importer on table yelp_user: $_"                     
    }
    $RowCount = 0
} -Process {
    $Item = $_
    $YUserCopier.StartRow()
    $Maps["yelp_user"] | ForEach-Object {
        If ($Item.($_.NN) -ne $null) {
            $YUserCopier.Write(($Item.($_.NN) -as $($_.NT)), [NpgsqlTypes.NpgsqlDbType]::($_.ST))
        } Else {
            $YUserCopier.WriteNull()
        }
    }
    $RowCount++
} -End {
    Write-Verbose "Committing copy... [$RowCount rows]"
    $YUserCopier.Close()
    Remove-Variable YUserCopier,RowCount
    Write-Verbose "Copy complete."
}

Write-Verbose "Processing user-to-user friendship data..."
# Unfortunately, it does mean we have to read it another time for friend-related data.
Get-Content (Join-Path $YelpDataPath "yelp_user.json") | ConvertFrom-Json | Where-Object {
    $_.friends.Count -gt 0
} | ForEach-Object -ErrorAction Stop -Begin {
    Write-Verbose "Starting binary-copy operation to yelp_friends table."    
    try {
        $YFriendCopier = $Connection.BeginBinaryImport("COPY yelp_friends (
            user_id, friend_id
        ) FROM STDIN (FORMAT BINARY)")
    }
    catch {
        throw "Failed to open binary-copy importer on table yelp_friends: $_"        
    }
    $RowCount = 0    
} -Process {
    $ID = $_.user_id
    $_.friends | Foreach-Object {
        $YFriendCopier.StartRow()
        $YFriendCopier.Write($ID, [NpgsqlTypes.NpgsqlDbType]::Varchar)
        $YFriendCopier.Write($_, [NpgsqlTypes.NpgsqlDbType]::Varchar)
    }
    $RowCount++    
} -End {
    Write-Verbose "Committing copy... [$RowCount rows]"
    $YFriendCopier.Close()
    Remove-Variable YFriendCopier,ID,RowCount
    Write-Verbose "Copy complete."
}

Write-Verbose "Processing review data."
# Stream in the review data, like we did with the users.
Get-Content (Join-Path $YelpDataPath "yelp_review.json") | ConvertFrom-Json | ForEach-Object -ErrorAction Stop -Begin {
    Write-Verbose "Starting binary-copy operation to yelp_review table."
    try {
        $YReviewCopier = $Connection.BeginBinaryImport("COPY yelp_review (
            $(($Maps["yelp_review"] | ForEach-Object SN) -join ", ") 
        ) FROM STDIN (FORMAT BINARY)")
    }
    catch {
        throw "Failed to open binary-copy importer on table yelp_review: $_"        
    }
    $RowCount = 0
} -Process {
    $Item = $_
    $YReviewCopier.StartRow()
    $Maps["yelp_review"] | ForEach-Object {
        If ($Item.($_.NN) -ne $null) {
            $YReviewCopier.Write(($Item.($_.NN) -as $($_.NT)), [NpgsqlTypes.NpgsqlDbType]::($_.ST))
        } Else {
            $YReviewCopier.WriteNull()
        }
    }
    $RowCount++
} -End {
    Write-Verbose "Committing copy... [$RowCount rows]"
    $YReviewCopier.Close()
    Remove-Variable YReviewCopier,RowCount
    Write-Verbose "Copy complete."
}

# Finally, process checkin data.
Write-Verbose "Processing external check-in data."
# We can use the Write-CheckinReport script to generate the statistics we need.
& $PSScriptRoot\Write-YelpCheckinReport.ps1 -CheckinJSONPath (Join-Path $YelpDataPath "yelp_checkin.json") -Verbose:$false | ForEach-Object -ErrorAction Stop -Begin {
    Write-Verbose "Starting binary-copy operation to yelp_checkin table."
    try {
        $YCheckinCopier = $Connection.BeginBinaryImport("COPY yelp_checkin (
            $(($Maps["yelp_checkin"] | ForEach-Object SN) -join ", ") 
        ) FROM STDIN (FORMAT BINARY)")
    }
    catch {
        throw "Failed to open binary-copy importer on table yelp_checkin: $_"        
    }
    $RowCount = 0
} -Process {
    $Item = $_
    $YCheckinCopier.StartRow()
    $Maps["yelp_checkin"] | ForEach-Object {
        If ($Item.($_.NN) -ne $null) {
            $YCheckinCopier.Write(($Item.($_.NN) -as $($_.NT)), [NpgsqlTypes.NpgsqlDbType]::($_.ST))
        } Else {
            $YCheckinCopier.WriteNull()
        }
    }
    $RowCount++
} -End {
    Write-Verbose "Committing copy... [$RowCount rows]"
    $YCheckinCopier.Close()
    Remove-Variable YCheckinCopier,RowCount
    Write-Verbose "Copy complete."
}

Write-Verbose "Finished."

$Connection.Close()

