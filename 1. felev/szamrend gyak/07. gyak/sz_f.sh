#!/bin/bash
#

FILE=$1

while read line || [[ -n $line ]]
do
    IFS=" _"
    for szo in $line
    do
        if [[ $szo = "kukac" || $szo = "at" || $szo = "nospam" ]]
        then
            echo -n "@"
        elif [[ $szo = "pont" || $szo = "dot" ]]
        then
            echo -n "."
        else
            echo -n $szo
        fi
    done
    echo
done < $FILE