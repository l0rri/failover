# Yelp_user.json parser (Milestone 1, task 1c)
# CS 451-02 Spring 2018
# Team "The IT Crowd" (Geilenfeldt, Rink, Williams)
[CmdletBinding()]
param (
    # The path (absolute or relative) to the pre-provided Yelp_user.JSON file.
    # This will default to looking inside a folder named "Yelp-CptS451-2018" stored alongside the script itself.
    [ValidateScript({
        If (-not (Test-Path $_)) {
            throw [ArgumentException]::new("Specified path does not exist.", "UserJSONPath")
        } elseif ((Get-Item $_).Extension -ne ".json") {
            throw [ArgumentException]::new("Specified file does not appear to be a JSON document.", "UserJSONPath")
        }
        
    })]
    [Parameter(
        ValueFromPipeline = $true,
        ValueFromPipelineByPropertyName = $true,
        Position = 0,
        HelpMessage = "Provide the path to the pre-generated Yelp_user.json file. Relative and absolute paths are supported."
    )]
    [String]$UserJSONPath = (Join-Path $PSScriptRoot ".\Yelp-CptS451-2018\Yelp_user.JSON"),

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

    Write-Verbose "Loading JSON from `"$($UserJSONPath | Split-Path -Leaf)`"..."

    # Retrieve JSON, rehydrate to objects, then iterate.
    # The user JSON appears to be a bunch of smaller JSON documents concatenated together with linebreaks as delimiters.
    # Because of this, we can run ConvertFrom-Json on each individual line (Get-Content returns an array of strings per line by-default)
    # and get a little bit better performance.
    Get-Content $UserJSONPath | ForEach-Object {$_ |  ConvertFrom-Json} | ForEach-Object -Process {

        # Keep track of our current user structure (automatic variables don't work in nested loops)
        $User = $_

        Write-Verbose "Processing data for user with ID `"$($User.User_ID)`"."

        $_ | Select-Object -ExcludeProperty "Compliment_*","Elite","Friends" -Property @(
            "*" # Pull in all properties from the original object
            # Make our own (flat) versions of the complex properties we're excluding above
            @{ 
                N = "Friends"
                E = {$_.Friends -join ", "}
            }
        )
    
    } -End {Write-Verbose "User data processing complete."} |
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