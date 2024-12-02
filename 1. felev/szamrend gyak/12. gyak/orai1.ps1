#nonsensestring

function TrapTest {
    "1"
    trap { 'Error found.' }
}

TrapTest

trap {'Other terminating error trapped' }
trap [System.Management.Automation.CommandNotFoundException] {
    'Command error trapped'
}
nonsenseString

$A=0
$B=0
try {
    $a / $b
} catch {
    0
}