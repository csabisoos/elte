$adatok = Import-Csv -Path .\adatok.csv -Delimiter ";"
$adatok | % {
    $_.taveleje.GetType()
}
