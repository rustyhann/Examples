Function Validate-IPAddress
{
    <#
    .Synopsis
        Validates an IP Address
    .Description
        Validate-IPAddress uses a regular expression to ensure an IP address
        is valid.
    .Parameter IPAdress
        The IP address to be tested as a string
    .Example
        Validate-IPAddress -IPAddress 192.168.0.1
    .Example
        Validate-IPAddres -IPAddress 275.289.348.593
    #>

    [CmdletBinding()]
    [OutputType([Bool])]
    param
    (
        [parameter(Mandatory=$true)]
        [String]
        $IPAddress
    )

    Begin 
    {
        Write-Verbose "Validate-IPAddress: IPAddress: $IPAddress"
    }

    Process
    {
        # http://www.regular-expressions.info/examples.html
        $regex = '^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$'
        
        If ($IPAddress -notmatch $regex ) 
        {
            Write-Verbose "Validate-IPAddress: Validation Failed"
            $false
        }
        Else
        {
            Write-Verbose "Validate-IPAddress: Validation Succeded"
            $true
        }
    }

    End
    {
        # Nothing
    }

}