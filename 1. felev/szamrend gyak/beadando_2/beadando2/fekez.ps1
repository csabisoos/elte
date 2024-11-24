param( [int]$P )
$test = Get-Content .\test.txt
foreach ($sor in $test) {
    $sortomb =  $sor -split ","
   
        if([int]$sortomb[2] -lt $P){        
            Write-Host $sortomb[0]
        }
}