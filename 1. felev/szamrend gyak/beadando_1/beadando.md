# Első beadandó feladat 2024 ősz

## Shell szkript beadandó feladatok

Válasszon egy feladatot a felsoroltak közül. A megoldó szkript fájlt a futáshoz szükséges állományokkal csomagolja be egy zip fájlba, és ezt a tömörített fájlt töltse fel ezen az oldalon!

Egy autó századmásodpercenként méri mozgás közben, hogy milyen távolságba van előtte vagy utána "valami" és ez alapján dönt arról, gyorsítania kell vagy lassítani vagy esetleg megállni. Ezeket az adatokat most egy adatfájlban tároljuk: időpont (év.hó.nap óra:perc:mperc:szmp), sebesség, távolságelejétől, távolsághátuljától)

1. Készítsen auto.sh néven egy szkriptet, ami megadja, hogy hányszor állt meg az autó. (Hány olyan hely van, ahol a következő adat több, mint 1 perc múlva érkezett. Ha áll az autó, nem mér.)!
2. Készítsen fekez.sh néven szkriptet, ami megadja, hogy mikor kellett fékezni. Fékezni akkor kell, ha az előtte levő autó távolsága K-méternél kisebb.  pl: ./fekez.sh 100)
3. Készítsen legkozelebb.sh néven szkriptet, ami megadja, hogy mikor volt a legközelebb hozzá valami (bármelyik irányból).