$ErrorActionPreference = 'Stop'

Get-ChildItem "$PSScriptRoot" -Recurse | `
    Where-Object `
    {
        ($_.Name -like '*.ps1') -and `
        ($_.Name -notlike '*.tests.ps1') -and `
        ($_.Name -ne 'ApprovedVerbs.ps1') -and `        
        ($_.FullName -notmatch 'Private')
        ($_.FullName -notmatch 'ThingsYouDontWant') -and `        
    } | `
    ForEach-Object `
    {
        . $_.FullName
    }

. $PSScriptRoot\ApprovedVerbs.ps1

ForEach ($verb in $approvedVerbs){
    Export-ModuleMember -Function "$verb-*"
}
