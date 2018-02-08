# Yelp_checkin.json parser (Milestone 1, task 1d)
# CS 451-02 Spring 2018
# Team "The IT Crowd" (Geilenfeldt, Rink, Williams)
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
        Position = 0,
        HelpMessage = "Provide the path to the pre-generated yelp_checkin.json file. Relative and absolute paths are supported."
    )]
    [String]$CheckinJSONPath = (Join-Path $PSScriptRoot ".\Yelp-CptS451-2018\yelp_checkin.JSON"),

    # The path to write a CSV report to, if desired.
    [Parameter(
        Position = 1,
        HelpMessage = "Provide the path to a CSV file for writing the output of this report to. Relative and absolute paths are supported. To skip creating a report, leave this parameter undefined."
    )]
    [String]
    $CSVReportPath,

    # Suppress "writing" output to the console (i.e. whether or not objects should be returned from the script vs. being written to disk with -CSVReportPath)
    [Switch]$Quiet
)


process {

    Write-Verbose "Loading JSON from `"$($CheckinJSONPath | Split-Path -Leaf)`"..."

    # Retrieve JSON, rehydrate to objects, then iterate.
    # The checkin JSON appears to be a bunch of smaller JSON documents concatenated together with linebreaks as delimiters.
    # Because of this, we can run ConvertFom-Json on each individual line (Get-Content returns an array of strings per line by-default)
    # and get a little bit better performance.
    Get-Content $CheckinJSONPath | ForEach-Object {$_ |  ConvertFrom-Json} | ForEach-Object -Process {

        # Keep track of our current business/weekly-checkin value (automatic variables don't work in nested loops)
        $Checkin = $_

        Write-Verbose "Processing checkin data for business with ID `"$($Checkin.Business_ID)`"."
    
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
                #     (The range operator returns an array, which can be concatenated with another array using the + operator)
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
    
    } -End {Write-Verbose "Checkin data processing complete."} |
    # Export to CSV - if specified. (Note the hanging pipeline on the line above, 
    # which means we'll be getting the custom objects we created above piped into this loop.)
    ForEach-Object -Begin {
        If ($CSVReportPath) {
            # Clear the contents of the CSV we'll be writing to.
            Write-Verbose "Clearing output CSV file..."
            try {
                Set-Content -LiteralPath $CSVReportPath -Value $null -Force -ErrorAction Stop    
            }
            catch [System.IO.IOException] {
                Write-Error "Failed to clear output CSV: $_"
            }
            
        } Else {
            Write-Verbose "-CSVReportPath not specified, skipping CSV export."
        }
    } -Process {
        If ($CSVReportPath) {
            # Append each checkin item to the output CSV
            $_ | Export-CSV -Append -NoTypeInformation -LiteralPath $CSVReportPath
        }
        If (-not $Quiet) {
            Return $_
        }
    } -End {
        If ($CSVReportPath) {
            Write-Verbose "CSV Export complete."
        }
    }
}

end {

    Write-Verbose "Complete."

}