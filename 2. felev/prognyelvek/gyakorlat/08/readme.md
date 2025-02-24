# 08. `List`, `Set`, `Map`

## Demo

### 1. demó

Készítsük el a `WorkerScheduleStructureTest` szerint a megadott osztályt. Ennek adattagja leírja, hogy melyik héten kik dolgoznak. A heteket a hívó fél `1` kezdéssel számozza, de belül `0` kezdéssel tároljuk el.

Dolgozókat két `add()` művelettel adunk a munkarendhez.

- Az egyik egy specifikus héthez adja hozzá a második paraméterben megadott dolgozókat.
    - Hozzáadhatók egyenként is, de a `HashSet` osztály `addAll()` metódusával is.
    - Ha a hét még nem szerepel a `weekToWorkers` adattagban, be kell tenni dolgozók nélkül (üres halmazt hozzárendelve).
- A másik több hetet add meg, a dolgozókat mindegyikhez hozzá kell adni.
    - Ez a metódus hívjon át az előzőre.

A másik két metódus megadja, hogy egy adott dolgozó szerepel-e a munkarend egy megadott napján, illetve megadja az összes olyan napot, amelyeken egy adott dolgozó dolgozik.

- Az utóbbihoz használjuk a `HashMap` osztály `entrySet()` metódusát a kulcs-érték párok bejárásához.
    - Ez `Entry<kulcs típusa, érték típusa>` értékeket jár be (`java.util.Map.Entry`).

A következő módon tesztelendő.

- `emptySchedule`: üres munkarendben senki nem dolgozik semelyik napon
    - Itt `assertFalse(<feltétel>)` is használható, ami rövidebb, mint a szintén érvényes `assertEquals(false, <feltétel>)`.
- `schedule`: vegyünk fel néhány dolgozót mindkét `add()` használatával, és aztán próbáljuk ki a két másik metódust.
    - A második változathoz néhány `ArrayList`re van szüksége. Ezek összeállíthatók úgy, hogy minden névre meghívjuk az `add` metódust.
    - Összeállítható így is: `new ArrayList<>(List.of(name1, name2, ...))`. Ebben `List` csomagja szintén `java.util`.
    - A teszt működtethető a szokásos módon `@ParameterizedTest` segítségével is, amivel rövidebb és átfogóbb megoldás adható.

## Feladatok

### 1. feladat