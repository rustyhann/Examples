$VerbosePreference = 'SilentlyContinue'

If ($null -eq (Get-Module -Name 'CoolGuyModule')) {
    Import-Module -Name 'CoolGuyModule' -Force
}

$privateFunctionPaths = Get-ChildItem "$PSScriptRoot\Private" -Recurse | `
    Where-Object { ($_.Name -notlike '*.tests.ps1') -and ($_.Name -like '*.ps1') } | `
    Select-Object -Property FullName -ExpandProperty FullName

ForEach ($privateFunctionPath in $privateFunctionPaths) {
    . $privateFunctionPath
}

Function Invoke-Mocks() {
    [CmdletBinding()]
    Param(
        [Switch] $MockSwitchesEasyButton
    )
    Begin { }
    Process {
        If ($MockSwitchesEasyButton) {
            Mock `
                -ModuleName  'CoolGuyModule' `
                -CommandName 'New-StuffAndThings' `
                -RemoveParameterType 'ThatThingYouDontWant' `
                -MockWith { 'Return something or nothing' }
        }
        
        Mock `
            -ModuleName  'CoolGuyModule' `
            -CommandName 'New-AlwaysMockThis' `
            -RemoveParameterType 'ThatThingYouDontWant' `
            -MockWith { 'Return something or nothing' }
    }
    End { }
}

Function Confirm-Mocks() {
    [CmdletBinding()]
    Param(
        [Switch] $MockSwitchesEasyButton
    )
    Begin { }
    Process {
        If ($MockSwitchesEasyButton) {
            Assert-MockCalled `
                -ModuleName "CoolGuyModule" `
                -CommandName 'New-StuffAndThings' `
                -Exactly 1
        }
        
        Assert-MockCalled `
            -ModuleName "CoolGuyModule" `
            -CommandName 'New-AlwaysMockTHis' `
            -Exactly 1        
    }
    End { }
}

Describe 'New-FunctionToTest Parameter FxParameter' {
    Context 'FxParameter Parameter is Valid with Value ''Valid''' {
        It 'Should Not Throw' {
            Invoke-Mocks -MockSwitchesEasyButton

            { New-FunctionToTest -FxParameter 'Valid' } | Should -Not -Throw

            Confirm-Mocks -MockSwitchesEasyButton
        }
    }  
    
    Context 'FxParameter Parameter is Invalid with Value 'Invalid'' {
        It 'Should ''Throw 'does not belong to set''' {
            Invoke-Mocks -MockSwitchesEasyButton

            { New-FunctionToTest -FxParameter 'Valid' } | Should -Throw `
                -ExpectedMessage "does not belong to the set"

            Confirm-Mocks -MockSwitchesEasyButton
        }
    }

    Context 'Should Return ''Awesome''' {
        It 'Should Be ''Awesome''' {
            Invoke-Mocks -MockSwitchesEasyButton

            $result = New-FunctionToTest -FxParameter 'Awesome'
            
            $result | Should -Be 'Awesome'

            Confirm-Mocks -MockSwitchesEasyButton
        }
    }
}
