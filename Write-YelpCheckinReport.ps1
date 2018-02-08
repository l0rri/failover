
[CmdletBinding()]
param (
    # The path (absolute or relative) to the pre-provided yelp_checkin.JSON file.
    # This will default to looking inside a folder named "Yelp-CptS451-2018" stored alongside the script itself.
    [ValidateScript({
        If (-not (Test-Path $_)) {
            throw [ArgumentException]::new("Specified path does not exist.", "CheckinJSONPath")
        } elseif ((Get-Item $_).Extension -ne ".json") {
            throw [ArgumentException]::new("Specified file does not appear to be a JSON document.", "CheckinJSONPath")
        }
        
    })]
    [Parameter(
        ValueFromPipeline = $true,
        ValueFromPipelineByPropertyName = $true,
        Position = 0
    )]
    [String]$CheckinJSONPath = (Join-Path $PSScriptRoot ".\Yelp-CptS451-2018\yelp_checkin.JSON"),

    # The path to write a CSV report to, if desired.
    [Parameter(
        Position = 1
    )]
    [String]
    $CSVReportPath,

    # Suppress "writing" output to the console (i.e. whether or not objects should be returned at all)
    [Switch]$Quiet
)


process {

    Write-Verbose "Loading JSON..."

    # Retrieve JSON, rehydrate to objects
    $Checkins = Get-Content $CheckinJSONPath | ConvertFrom-Json

    Write-Verbose "$($CheckinJSONPath | Split-Path -Leaf) loaded."

    # Iterate over all checkin objects
    $Checkins | ForEach-Object {

        # Keep track of our current business/weekly-checkin value (automatic variables don't work in nested loops)
        $Checkin = $_
    
        # Get all properties in the "Time" structure for this checkin (i.e. all days of the week),
        # extract names, then iterate using the names.
        $Checkin.Time | Get-Member -Type NoteProperty | ForEach-Object Name | ForEach-Object {
        
            # Keep track of the current DoW we're looking at.
            $DayOfWeek = $_
    
            # Retrieve the set of hourly checkin measurements
            $CheckinHours = $Checkin.Time.$DayOfWeek
    
            # In one operation, create and return a custom object with the data we need.
            Return [pscustomobject][ordered]@{
            
                ID = $Checkin.Business_ID
                DayOfWeek = $DayOfWeek
                # The basic process used in the subexpressions below is as follows:
                #   * Get a range of hours for our chosen time-of-day (X..Y => range operator, a la Python)
                #   * For each number in the set of numbers, project the property corresponding to the matching hour
                #     (e.g. "1" would retrieve $CheckinHours."1:00")
                #   * Sum all of the projected checkin counts for the hours we specified earlier
                #   * Specifically project the sum (Measure-Object returns a structure with other data we don't want)
                Morning = $(6..11 | ForEach-Object {$CheckinHours."$_`:00"} | Measure-Object -Sum | ForEach-Object Sum)
                Afternoon = $(12..16 | ForEach-Object {$CheckinHours."$_`:00"} | Measure-Object -Sum | ForEach-Object Sum)
                Evening = $(17..22 | ForEach-Object {$CheckinHours."$_`:00"} | Measure-Object -Sum | ForEach-Object Sum)
                Night = $(@(23) + 0..5 | ForEach-Object {$CheckinHours."$_`:00"} | Measure-Object -Sum | ForEach-Object Sum)
            
            }
    
        }
    
    } -End {Write-Verbose "Checkin data processing complete."} | & {
        Process {
            If ($CSVReportPath) {
                $_ | Tee-Object -Variable $Output
            } Else {
                $_
            }
        }
    }
}

end {
    If ($CSVReportPath) {
        Write-Verbose "Writing output to `"$CSVReportPath`"..."
        $Output | Export-CSV -LiteralPath $CSVReportPath -Force
    } Else {
        Write-Verbose "CSVReportPath not specified, skipping CSV output."
    }
    Write-Verbose "Complete."
}