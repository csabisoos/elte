#!/bin/bash
#
FILENEV=$1
paritas="false"

if [[ ! -f $FILENEV ]]
then
    echo "Nincs meg a file" >&2
    exit 1
fi

echo -n > paros
echo -n > paratlan

while read line || [[ -n $line ]]
do
    if [[ $paritas = "true" ]]
    then
        echo $line >> paros
        paritas="false"
    else
        echo $line >> paratlan
        paritas="true"
    fi
done < $FILENEV