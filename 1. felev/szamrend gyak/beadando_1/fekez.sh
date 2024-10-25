#!/bin/bash

# K check
if [[ $# -ne 1 ]]; then
    echo "Használat: ./fekez.sh <távolság_méterben>"
    exit 1
fi

K=$1

# fajl neve
file="test.txt"