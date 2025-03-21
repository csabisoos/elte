## **1. feladat**

Állítsa aszimptotikusan **növekvőleg** a következő függvényeket, az egyenlőséget is jelölje.

$5n^2+3n+10, \quad \log _2 (n), \quad n^{0,5}-45, \quad (n+1)*\log _{10} (n), \quad \ln (n^2), \quad 2^n+3, \quad n!$

**Megoldás:** 

1. $\log _2 (n)$ : Logaritmikus növekedés.

2. $\ln (n^2) = 2 \ln (n)$ : Ez is logaritmikus, de konstans szorzóval, így $\ln (n)$ és $\log _2 (n)$ azonos rendű.
3. $(n+1)* \log _{10} (n)$ : Majdnem lineáris növekedés, de logaritmussal szorozva.
4. $n^{0,5}-45$ : Gyökös növekedés, lassabban nő, mint a lineáris.
5. $5n^2 + 3n + 10$ : Másodfokú növekedés, a fő tag $5n^2$ dominál. 
6. $2^n + 3$ : Exponenciális növekedés, gyorsabban nő, mint bármely polinomiális.
7. $n!$ : Faktoriális növekedés, még az exponenciálisnál is gyorsabban nő.

Az aszimptotikusan növekvő sorrend:

$$
\log _2 (n) = \ln (n^2) < n^{0,5}-45 < (n+1) \log _{10}(n) < 5n^2+3n+10 < 2^n + 3 < n!
$$

## **2. feladat**

N gyerek **kiszámolós játékot** játszik. A gyerekek körbe állnak és az egyik gyerektől elkezdve az óramutató járásával azonos irányban lévő M-edik gyerek kiesik a játékból, majd a kiesett gyerek utáni gyerektől számított M-edik gyerek szintén kiesik a játékból, és így tovább. Az a nyertes, aki utolsóként marad bent a körben. **Ki lesz a nyertes?** A megoldáshoz használjunk sor adattípust (a műveletek szintjén).

Ez a feladat az ún. **Josephus-probléma**, amelyben egy körben alló gyerekek közül minden $M$-edik kiesik, míg végül egy marad. A megoldáshoz egy **sor (queue) adatszerkezetet** használunk, amely lehetővé teszi az elemek FIFO (First-In-First-Out) kezelését.

1. **Inicializáljuk a sort:**
    - A sorba behelyezzük az $1, 2, , N$ gyereket (a pozíciójuk szerint).
2. **Kiesési folyamat:**
    - Addig ismételjük, amíg csak egy gyerek marad:  

        1. $M-1$ **gyereket** előrevesszük és visszahelyezzük a sor végére.
        2. Az $M$**-edik gyereket kivesszük** (ő kiesik a játékból).
    
3. **A nyertes kiválasztása:**
    - A folyamat végén a sorban maradt egyetlen elem a győztes.

**Példa:**

Ha $N=5$ **és** $M=3$, akkor a kiesések így alakulnak:

- **Sor kezdésekor:** [1, 2, 3, 4, 5]

- **1. lépés:** Az első két gyereket áthelyezzük (1 $\to$ végére, 2 $\to$ végére), a 3-as kiesik.

    - Sor: [4, 5, 1, 2]

- **2. lépés:** Az első két gyereket áthelyezzük (4 $\to$ végére, 5 $\to$ végére), az 1-es kiesik.

    - Sor: [2, 4, 5]

- **3. lépés:** Az első két gyereket áthelyezzük (2 $\to$ végére, 4 $\to$ végére), az 5-ös kiesik.

    - Sor: [2, 4]

- **4. lépés:** Az első két gyereket áthelyezzük, de **csak egy van hátra: (2)** (2 $\to$ végére), a 4-es kiesik.

    - **Nyertes: 2**

**Python kód:**

```py
def josephus(n, m):
    children = list(range(1, n + 1))  # 1-től N-ig feltöltjük a listát
    index = 0  # Kezdő index
    
    while len(children) > 1:
        index = (index + m - 1) % len(children)  # M-edik gyerek kiválasztása
        children.pop(index)  # Gyerek kiesik
    
    return children[0]  # Az utolsó megmaradt gyerek

# Példa futtatás
N = 5
M = 3
print(josephus(N, M))  # Kimenet: 2
```

## **3. feladat**

Egy **szigorúan monoton növekvően rendezett H1L** (egyirányú, fejelemes) listával **zsák** adatszerkezetet ábrázoltunk. A zsák abban tér el a halmaztól, hogy egy adott értékből több példány is lehet a zsákban. A lista egy eleme a következő hármasból áll: **(key, mult, next)**. A lista **fejelemére az L** pointer mutat. Készítsen algoritmust, mely a zsák **minden eleméből egyet kivesz** (multiplicitásukat eggyel csökkenti). Ha a multiplicitás 0-ra csökken, az elemet kifűzi a láncból. A kifűzött elemeket egy T pointerű, egyszerű listába (S1L) fűzi. T lista is növekvően rendezett legyen! L lista egyszer járható be, T-be való befűzés $\Theta$(1) lehet.

**1. Inicializáció:**  
  - `T = None`, mert a `T` lista kezdetben üres.

  - `prev = L`, hogy az `L` listában törölni tudjunk.

**2. Bejárás az `L` listán:**
  - Minden csomópont multiplicitását csökkentjük.

  - Ha **multiplicitás > 0**, akkor tövábbhaladunk.

  - Ha **multiplicitás = 0**, akkor:
    - Az **elemet eltávolítjuk az `L` listából**.

    - Az **elemet beszúrjuk a `T` lista elejére**.

**3. Az elgoritmus befejeződik, amikor az L lista végére érünk.**

**Implementáció C-szerű pszeudokódban**

```c
function remove_from_L_and_add_to_T(L: pointer to node) -> pointer to node:
    T = None  // T lista kezdetben üres
    prev = L  // Fejre mutató pointer
    curr = L.next  // Az első valódi elem

    while curr is not None:
        curr.mult -= 1  // Csökkentjük a multiplicitást
        
        if curr.mult == 0:  // Ha 0-ra csökkent, akkor kifűzzük az L-ből és áthelyezzük T-be
            prev.next = curr.next  // Kifűzés L-ből

            // Beszúrás a T lista elejére
            curr.next = T
            T = curr
        else:
            prev = curr  // Csak akkor lépünk tovább, ha nem fűztünk ki elemet

        curr = prev.next  // Haladás az L listában

    return T  // Visszaadjuk az új T listát
```

**Magyarázat**

- `prev.next = curr.next` : kifűzi az aktuális csomópontot az `L` listából.

- `curr.next = T; T = curr` : beszúrja a kifűzött elemet a `T` lista **elejére**, ami garantálja a **$\Theta(1)$** beszúrási időt.

- `prev` csak akkor frissül, ha nem történt kifűzés, hogy ne hagyjuk ki a következő elemet.

- `curr = prev.next` : mindig a következő csomópontra lépünk.

**Időbonyolultság**

- $O(N)$, mert az `L` listát egyszer járjuk be.

- $\Theta(1)$ a `T` listába való beszúrás, mivel mindig a fejhez adjuk hozzá az elemeket.

**Összegzés**

Ez az algoritmus hatékonyan csökkenti az `L` lista elemeinek multiplicitását, és azokat az elemeket, amelyek multiplicitása 0 lett, kifűzi és átfűzi egy új, egyszerű listába (`T`). Az új lista **rendezett marad** (mivel az eredeti `L` is rendezett volt), és a **`T` lista építése konstans időben történik**.

## **4. feladat**

Adott két **kétirányú fejelemes ciklikus (C2L)** lista: **L1** és **L2**. A listák szigorúan monoton növekedően rendezettek, halmazt ábrázolnak. Készítsen unionIntersection(L1,L2) néven algoritmust, mely L2 lista megfelelő elemeinek átfűzésével előállítja **L1-ben** a két halmaz **unióját**, míg **L2-ben** keletkezzen a két halmaz **metszete**. Mindkét lista maradjon szigorúan monoton növekedő, műveletigény O(m+n).  
FONTOS megjegyzések:
  - *A struktogramok fejlécének az elkészítése is a feladat része! Adjunk nevet az algoritmusoknak, paramétereiket tüntessük fel, ügyeljünk a helyes paraméter átadási mód (cím-, vagy értékszerinti) kiválasztására! Függvények esetén a visszatérési érték típusát is meg kell adni!*
  - *C2L listák esetén használható az alapműveletekhez az előadáson bevezetett follow, precede, és unlink.*
  - *A 3. és 4. feladathoz nem használható az elemek számával arányos méretű tároló (tömb, sor, verem)! A feladatokat az eredeti listaelemek átláncolásával kell megoldani!*

A feladat két **kétirányú fejelemes ciklikus listán (C2L)** kell végrehajtani az **uniót és a metszetet**, miközben:

  - **L1 lesz az unió** (L1 $\cup$ L2)

  - **L2 lesz a metszet** (L1 $\cap$ L2)

  - Az **átfűzések O(m + n) időben** történnek

  - Az **eredeti listaelemeket használjuk, új csomópontok létrehozása nélkül**

**Megoldás**

1. **Inicializálás:**

  - Két mutató: `p1` az **`L1` lista első elemére, `p2` az **`L2` lista első elemére

  - `head1, head2` : az `L1` és `L2` fejeleme

2. **Léptetés és átfűzés:**

  - Ha `p1.key == p2.key` : **az elem közös**, léptetjük `p1`-et és `p2`-t is.

  - Ha `p1.key < p2.key` : **`p1` előtt nincs `p2` megfelelője**, tehát `p1`-et léptetjük.

  - Ha `p1.key > p2.key` : **`p2` eleme nincs benne `L1`-ben**, ezért **átfűzzük `L1`-be**, és léptetjük `p2`-t.

  - Ha `p2` lista végére ért, az összes hátralévő `L1` elem marad az unióban.

3. **`L2` átrendezése:**

  - Azok az elemek, amelyeket **nem fűztünk át `L1`-be**, maradnak az `L2`-ben $\to$ **ez lesz a metszet**.

**Pszeudokód C-szerű szintaxissal**

```c
procedure unionIntersection(ref L1: C2L, ref L2: C2L)
    p1 = L1.head.next  // Első elem L1-ben
    p2 = L2.head.next  // Első elem L2-ben

    while (p1 != L1.head && p2 != L2.head)
        if p1.key == p2.key then
            // Közös elem → marad L1-ben, L2-ben is
            p1 = p1.next
            p2 = p2.next
        else if p1.key < p2.key then
            // p1 kisebb → léptetjük p1-et
            p1 = p1.next
        else
            // p2 kisebb → átfűzzük p2-t L1-be
            temp = p2
            p2 = p2.next
            unlink(L2, temp)  // Eltávolítás L2-ből
            insertSorted(L1, temp)  // Beszúrás L1-be

    // L2-ben csak azok maradnak, amiket nem fűztünk át → ez lesz a metszet
end procedure
```

**Alapműveletek magyarázata**

  - **`unlink(L2, temp)`** $\to$ kifűzi a `temp` elemet `L2`-ből.

  - **`insertSorted(L1, temp)`** $\to$ beilleszti `temp`-et `L1`-be megfelelő helyre.

**Időbonyolultság**

  - Mindekét listán egyszer végighaladunk $\to$ $O(m+n)$.

  - Az elemek láncolásával nem használunk extra memóriát.

**Összegzés**

Ezzel az algoritmussal:

  - **`L1` az uniót fogja tartalmazni (L1 $\cup$ L2)**

  - **`L2`-ben csak a közös elemek maradnak (L1 $\cap$ L2)**

  - **Nincs extra memóriahasználat** (csak mutatókat mozgatunk)

  - **Futási idő optimális, $O(m+n)$**

## **5. feladat**

A tanult algoritmust alkalmazva határozzuk meg az alábbi kifejezés **lengyel formáját!** A lengyel formában minden <u>operandus</u> fölé rajzolja le a verem pillanatnyi tartalmát!
**Adja meg a kifejezésben szereplő operátorok precedenciáját!**

```
x=-x^2+5*k/(y-z*3+s)^x^2-b*d-w
```
