#!/bin/bash
#
file="test.txt"
mintav=999999999

while IFS=',' read idop seb tave tavh || [ -n "$idop" ]; do
    if (( tave < mintav )); then
        mintav=$tave
    elif (( tavh < mintav )); then
        mintav=$tave
    fi
done < "$file"
echo $mintav
