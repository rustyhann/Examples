Function Must-UsePowerShellApprovedVerbs() {
    [CmdletBinding()]
    Param(
        [Parameter(Mandatory = $true)]
        [ValidateSet('Prod','QA','Dev',IgnoreCase = $false)]
        [string]
        $Parameter,
    )
    Begin {
        $ErrorActionPreference = 'Stop'
    }
    Process {

    }
    End { }
}
