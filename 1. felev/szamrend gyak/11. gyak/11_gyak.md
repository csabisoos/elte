# 11. Gyakorlat
## Powershell script

- `1,2,3 | Measure-Object`
    - `(Get-Content .\fajl.txt | Measure-Object).Count`
- `$args`
    - `$args.Lenght`
    - `$args[0] + $args[1]`
        - `"a" * 5` -> `aaaaa`
```pwsh
Get-Content .\FAJL.txt | % {
    $_.Split(" ")[1]
}
```
- `(Get-Conten .\FAJL.txt).Split(" ")[1]`
- Faktorális számítás:
```pwsh
Param(
    [Parameter(Mandatory=$true)] [int]$n
)
$n
```
```pwsh
function Szamol-Faktorialis ([bigint] $n){
    if ($n -gt 0) { return $n * (Szamol-Faktorialis($n-1)) }
    elseif ($n -eq 0) { return 1 }
}
Szamol-Faktorialis 5
```
- Összes paraméter összege
```pwsh
$args | % {$a += $_}
$a
```
```pwsh
($input | Measure-Object -Sum).Sum
```
- 5.
```pwsh
Param(
    [Parameter(Mandatory=$true)][string]$file
)

if (Test-Path "Paros.txt"){ rm Paros.txt }
if (Test-Path "Paratlan.txt"){ rm Paratlan.txt }

if (Test-Path $file){
    $parity = $false
    Get-Content $file | % {
        if ($parity){
            $_ >> Paros.txt
            $parity = $false
        } else {
            $_ >> Paratlan.txt
            $parity = $true
        }
    }
}
```
- 9. **nem mukodik**
```pwsh
$parok = @{
    "pont" = "."
    "dot" = "."
    "kukac" = "@"
    "at" = "@"
}
$data = Get-Content .\FAJL.txt
foreach ($valami in $parok){
    $data -replace $valami.Keys, $valami.Values
}
```