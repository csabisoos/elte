# 04-05. Egységtesztelés: JUnit

## Demo

### 1. demó

Írjunk `fib()` metódust a `famous.sequence.Fibonacci` osztályba, amely egy `n` számot kap meg, és kiadja [az `n`-edik Fibonacci-számot](https://hu.wikipedia.org/wiki/Fibonacci-sz%C3%A1mok). Feltesszük, hogy az `n` bemenet kis, pozitív szám.

Teszteljük a következőképpen.

- A metódus kapjon `static` minősítőt. Erről a kulcsszóról részletesebben később lesz szó.  
- A mellékelt `famous.sequence.FibonacciStructureTest` használata.  
    - Ezt a csomagjának megfelelő könyvtárba kell elhelyezni.
    - Ez a `CheckThat` eszközt használja, aminek szintén elérhetőnek kell lennie.
    - Fordítás és futtatás. A parancsokat lásd a demó `zip` fájlban.
        - Először a `FibonacciStructureTest` osztályt fordítsuk.
        - Most a `Fibonacci.java` osztályt külön paranccsal kell lefordítani, mert a tesztelő nem hivatkozik rá közvetlenül, és így az előző fordításban a `javac` nem keresi meg.
        - Futtassuk a teszteket.
- Készítsünk `famous.sequence.FibonacciTest` tesztelőt.
    - Ebben legyen teszt néhány konkrét `n` értékre.
    - Próbáljuk ki a paraméterezett tesztelést is.
    - Fordítás és futtatás.
        - A folyamat jobb megértése érdekében töröljük le a korábban elkészült összes `.class` fájlt. (A `.java` fájlok maradjanak meg!)
        - Fordítsuk le a `FibonacciTest` kódját. Ez a `Fibonacci.java` fájlt is megtalálja és lefordítja.
        - Futtassuk a teszteket.
- A mellékelt `famous.sequence.FibonacciTestSuite` használata.
    - Ezt is a csomagjának megfelelő könyvtárba kell elhelyezni.
    - Ismét töröljük le a korábban elkészült összes `.class` fájlt.
    - Fordítsuk le a `FibonacciTestSuite` kódját. Ezúttal `Fibonacci.java` és a két korábbi tesztelő is lefordul.
    - Futtassuk a teszteket.

## Feladatok

### 1. feladat

Készítsünk [háromszögszámokat](https://hu.wikipedia.org/wiki/H%C3%A1romsz%C3%B6gsz%C3%A1mok) kiszámító `static famous.sequence.TriangularNumbers.getTriangularNumber()` metódust.

- A tesztelő kód a `famous.sequence.TriangularNumbersTest` osztályba kerüljön.
- Ehhez is jár mellékelt strukturális tesztelő és suite is, ezeknek is rendben le kell futniuk.
    - A fájlokat a megfelelő könyvtárba kell elhelyezni, különben nem működnek.

Kipróbálandók a következő bemenetek.

- nulla
- egy
- [a szám, ami a fiatal Gauss anekdotájában szerepel](https://hu.wikipedia.org/wiki/Carl_Friedrich_Gauss#Fiatalkora)
- mínusz egy
- más negaív szám

A tesztelőbe írjunk szándékosan egy rossz tesztesetet is, direkt elrontott elvárt eredménnyel. Vizsgáljuk meg a futtatás eredményét, benne az összefoglalóval és a *stack trace* részleteivel.

Az osztályba kerüljön `getTriangularNumberAlternative()` is. Ez a képlettel dolgozzon, és adja ugyanazt a kimenetet, mint `getTriangularNumber()`.

- A tesztelő próbálja ezt is ki.

### 2. feladat

Készítsük el a `static math.operation.safe.Increment.increment()` metódust.

- Legyen `static` minősítőjű.
- Bemenete egy `int`.
- Ha a bemenete a legnagyobb ábrázolható egész, azzal tér vissza, különben a bemeneténél eggyel nagyobb egésszel.
    - Erre így lehet hivatkozni: `Integer.A_MEGFELELŐ_ADATTAG_NEVE`.
    - A keresett név [a Java API dokumentációból](https://docs.oracle.com/en/java/javase/19/docs/api/java.base/java/lang/Integer.html#field-summary) olvasható ki.

Ugyanebbe a csomagba készítsük el az `IncrementTest` osztályt az `increment()` működésének kipróbálására.

- Bemenete legyen nulla.
- Bemenete legyen a legkisebb ábrázolható egész.
- Bemenete legyen a legnagyobb ábrázolható egész.
- Bemenete legyen egy közepesen nagy, pozitív egész.
- Bemenete legyen egy közepesen nagy, negatív egész.
- Bemenete legyen `-1`.

Készítsünk egy hasonló tesztelő fájlt egy másik csomagba is, és próbáljuk ki ott is.

### 3. feladat

Készítsük el a mellékelt strukturális tesztelőben (`RecordLabelStructureTest`, `ArtistStructureTest`, `FanStructureTest`) leírt osztályokat a megadott szerkezettel.

Ebben a feladatban előre meg van adva néhány funkcionális teszt is. Ezeket a fájlokat bővítsük az alábbi tesztekkel.

- Tesztelendő, hogy létrehozás után mindegyik objektumra helyes értéket adnak a getterek.
    - A rajongónak, a rajongó művészének, és a rajongó művésze kiadójának a neve megfelelő kell, hogy legyen.
    - A rajongó létrehozás után közvetlenül még nem költött el pénzt.

A funkcionális tesztelőben az alábbi tesztek érhetők el a `Fan` osztályhoz. Itt a feladat a megvalósítás elkészítése.

- `buyMerchandise()` kiszámítja a rajongó által vásárolt termék árát.
    - A rajongó természetesen csak a kedvenc művészétől vesz termékeket.
    - Az alapár paraméterként van megadva, de ha a rajongó másokkal együtt veszi meg a terméket, az a darabárat fejenként 10%-kal, de legfeljebb 20%-kal csökkenti.
        - A további rajongókat deklaráljuk egy *vararg* paraméterben, így: `Fan... friends`.
        - Így hívható meg a metódus: `fan1.buyMerchandise(100, friend1, friend2, friend3)`, ahol mindegyik `friendN` egy `Fan` példány.
        - A költségcsökkentés mértéke akkor sem haladja meg a 20%-ot, ha kettőnél több extra rajongó csatlakozik.
    - A metódus visszatérési értéke a számított darabár.
        - Ezt az összeget elkölti a rajongó és mindegyik barátja.
        - Az összes költés felét megkapja a kiadó a gotIncome() segítségével.


