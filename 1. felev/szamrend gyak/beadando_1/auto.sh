#!/bin/bash
#
file="test.txt"
elozo=""
stop=0

while IFS=',' read idop seb tave tavh || [ -n "$idop" ]; do
    IFS=' ' read datum ido <<< "$idop"
    IFS='.' read ev honap nap <<< "$datum"
    IFS=':' read ora perc mp szmp <<< "$ido"

    ev=${ev#0}
    honap=${honap#0}
    nap=${nap#0}
    ora=${ora#0}
    perc=${perc#0}
    mp=${mp#0}
    szmp=${szmp#0}

    akt_mp=$(( ev * 365 * 24 * 360000 + honap * 30 * 24 * 360000 + nap * 24 * 360000 + ora *  360000 + perc * 6000 + mp * 100 + szmp ))
    if [ -n "$elozo" ]; then
        kulonbseg=$(( akt_mp - elozo ))
        if (( kulonbseg > 6000 )); then
            (( stop++ ))
        fi
    fi

    elozo=$akt_mp
done < "$file"
echo $stop