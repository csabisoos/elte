#!/bin/bash
#
file="test.txt"
K=$1

while IFS=',' read idop seb tave tavh || [ -n "$idop" ]; do
    if (( tave < K )); then
        echo $idop
    fi
done < "$file"