## 1. A teljes indukció elve.

**01/01 Tétel (A teljes indukció elve).** Tegyük fel, hogx minden $n$ természetes számra adott egy $A(n)$ állítás, és azt tudjuk, hogy

i) $A(0)$ igaz,

ii) ha $A(n)$ igaz, akkor $A(n+1)$ is igaz.

Ekkor az $A(n)$ állítás minden $n$ természetes számra igaz.

**Bizonyítás.** Legyen

$$
S := \left\lbrace n \in \mathbb{N} \mid A(n) \ \ \text{igaz}\right\rbrace.
$$

Ekkor $\underline{S \subset \mathbb{N}}$ és $S$ induktív halmaz, hiszen $0 \in S$, és ha $n \in S$, azaz $A(n)$ igaz, akkor $A(n+1)$ is igaz, ezért $n + 1 \in S$ teljesül következésképpen $S$ induktív halmaz. Mivel $\mathbb{N}$ a legszűkebb induktív halmaz, ezért az $\underline{\mathbb{N} \subset S}$ tartalmazás is fennáll, tehát $S=\mathbb{N}$. Ez pedig azt jelenti, hogy az állítás minden $n$ terészetes számra igaz.

## 2. A szuprémum elv.

**01/02 Tétel (A szuprérum elv).** Legyen $H \subset \mathbb{R}$ és tegyük fel, hogy 

i) $H \neq \emptyset$ és

ii) $H$ felülről korlátos.

Ekkor

$$
\exists \min \left\lbrace K \in \mathbb{R}\mid K \ \ \text{felső korlátja} \ \ H \text{-nak}\right\rbrace
$$

Legkisebb felső korlát.

**Bizonyítás.** Legyen

$$
A:=H \quad \text{és} \quad B:=\left\lbrace K \in \mathbb{R}\mid K \ \ \text{felső korlátja} \ \ H \text{-nak}\right\rbrace
$$

A feltételek miatt $A \neq \emptyset$ és $B \neq \emptyset$, továbbá

$$
\forall a \in A \quad \text{és} \quad \forall K \in B \quad \text{esetén} \quad a \leq K.
$$

Erre a $\xi$-re teljesül, hogy 

- $\xi$ felső korlátja $H$-nak, hiszen $a\leq \xi$ minden $a \in A$ esetén,
- $\xi$ a legkisebb felső korlát, ui. ha $K$ egy felső korlát (azaz $K \in B$), akkor $K \geq \xi$.

Ez pedig pontosan azt jelenti, hogy $\xi$ a $H$ halmaz legkisebb felső korlátja.

## 3. Az arkhimédészi tulajdonság.

**01/07 Tétel (Az arkhimédészi tulajdonság)**

Ha $n \in \mathbb{N}$, akkor egy szám $n$-szerese úgy tekinthető, mint a szám önmagával vett $n$-szeres összege. Ha $a >0$, akkor a számegyenesen ábrázolva látható, hogy az 

$$
n \cdot a = \underbrace{a + a + \dots + a}_{\text{n-szer}}
$$

alakú számok nagyon értékek vehetnek fel, amelyek bármely $b$ valós számnál is nagyobbak.

![Arkhimédész ábra](arkhimedesz.png)

Ezt állítja az arkhimédészi tulajdonság.

**7. Tétel (Az arkhimédészi tulajdonság).** Minden $a>0$ és minden $b$ valós számhoz létezik olyan $n$ természetes szám, hogy $b<n \cdot a$, azaz

$$
\forall a > 0 \quad \text{és} \quad \forall b \in \mathbb{R} \quad \text{esetén} \quad \exists n \in \mathbb{N}, \quad \text{hogy} \quad b<n \cdot a.
$$

**Bizonyítás.** Indirekt módon. Tegyük fel, hogy

$$
\exists a > 0 \quad \text{és} \quad \exists b \in \mathbb{R}, \quad \text{hogy} \quad \forall n \in \mathbb{N} : b \geq n \cdot a.
$$

Legyen

$$
H := \left\lbrace n \cdot a \in \mathbb{R} \mid n \in \mathbb{N}\right\rbrace.
$$

Ekkor $H \neq \emptyset$ és $H$ felülről korlátos, hiszen $n \cdot a \leq b$ minden $n \in \mathbb{N}$-re. A szuprémum elv szerint

$$
\exists \sup H =: \xi.
$$

Ekkor $\xi$ a legkisebbb felső korlátja $H$-nak, tehát $\xi - a$ nem felső korlát. Ez azt jelenti, hogy 

$$
\exists n_0 \in \mathbb{N} : n_0 \cdot a > \xi - a \quad \iff \quad (n_0 + 1) \cdot a > \xi.
$$

Azonban $(n_0 + 1) \cdot a \in H$, tehát $(n_0 + 1) \cdot a \leq \xi$, hiszen $\xi$ felső korlátja a $H$ halmaznak.

Így ellentmondáshoz jutottunk.

**Következmények.**

1. $\forall \epsilon > 0-hoz \exists n \in \mathbb{N}:\frac{1}{n}<\epsilon. \quad (\forall \epsilon > 0$-hoz $\exists n \in \mathbb{N} : 1 < n \cdot \epsilon)$

2. Az $\mathbb{N}$ halmaz felülről nem korlátos, $\quad (\forall b \in \mathbb{R}$-hez $\exists n \in \mathbb{N} : b < n \cdot 1 = n).$

Az intervallumokat a eddigi tanulmányainkban megszokott módon fogjuk értelmezni és jelölni.

Pl. ha $a,b \in \mathbb{R}$ és $a<b$, akkor az $a$ és $b$ számok által határolt zárt intervallum:

$$
\left[a,b\right] := \left\lbrace x \in \mathbb{R} \mid a \leq x \leq b \right\rbrace.
$$


## 4. A Cantor-tulajdonság.

A következő, ún. Cantor-tulajdonságot úgy szoktuk szavakba foglalni, hogy **egymásba skatulyázott korlátos és zárt intervallumok közös része nem üres.** Ezt szemlélteti az alábbi ábra:

![Cantor ábra](cantor.png)

**01/08 Tétel (A Cantor-tulajdonság).** Tegyük fel, hogy minden $n$ természetes számra adott az $[a_n, b_n] \subset \mathbb{R}$ korlátos és zárt intervallum úgy, hogy

$$
[a_{n+1}, b_{n+1}] \subset [a_n, b_n] \quad (n \in \mathbb{N}).
$$

Ekkor

$$
\bigcap_{n \in \mathbb{N}} [a_n, b_n] \neq \emptyset.
$$

**Bizonyítás.** A teljességi axiómát fogjuk alkalmazni. Legyen

$$
A := \left\lbrace a_n \mid n \in \mathbb{N} \right\rbrace \quad \text{és} \quad B := \left\lbrace b_n \mid n \in \mathbb{N} \right\rbrace .
$$

Először belátjuk, hogy

$(*) \quad \quad \quad a_n \leq b_m$ tetszőleges $n,m \in \mathbb{N}$ esetén.

Valóban,

i) ha $n \leq m$, akkor $a_n \leq a_m \leq b_m$,

ii) ha $m < n$, akkor $a_n \leq b_n \leq b_m$.

Mivel $A \neq \emptyset$ és $B \neq \emptyset$, ezért $(*)$ miatt a teljességi axióma feltételei teljesülnek, így 

$$
\exists \xi \in \mathbb{R} : a_n \leq \xi \leq b_m \quad \forall n,m \in \mathbb{N} \ \ \text{indexre}.
$$

Ha $n = m$, akkor azt kapjuk, hogy

$$
a_n \leq \xi \leq b_n \quad \iff \quad \xi \in [a_n,b_n] \ \ \forall n \in \mathbb{N} \ \ \text{esetén},
$$

és ez azt jelenti, hogy

$$
\xi \in \bigcap_{n \in \mathbb{N}} [a_n,b_n] \neq \emptyset.
$$

## 5. Konvergens sorozatok határértékének egyértelműsége.

**03/01 Tétel (A határérték egyértelműsége).** Ha az $(a_n) : \mathbb{N} \to \mathbb{R}$ sorozat konvergens, akkor a konvergencia definíciójában szereplő $A$ szám egyértelműen létezik.

$(*) \quad \exists A \in \mathbb{R}$, hogy $\forall \epsilon > 0$ számhoz $\exists n_0 \in \mathbb{N}$, hogy $\forall n > n_0$ indexre $| a_n - A | < \epsilon$.

**Bizonyítás.** Tegyük fel, hogy az $(a_n)$ sorozatra $(*)$ az $A_1$ és az $A_2$ számokkal is teljesül.

Indirekt módon tegyük fel azt is, hogy $A_1 \neq A_2$. Ekkor $\forall \epsilon > 0$ számhoz

$$
\exists n_1 \in \mathbb{N}, \forall n > n_1 : | a_n - A_1| < \epsilon, \ \ \text{és}
$$

$$
\exists n_2 \in \mathbb{N}, \forall n > n_2 : | a_n - A_2| < \epsilon.
$$

Válasszuk itt speciálisan az 

$$
\epsilon := \frac{|A_1 - A_2|}{2}
$$

(pozitív) számot. Az ennek megfelelő $n_1, n_2$ indexeket figyelembe véve legyen

$$
n_0 := \max \lbrace n_1, n_2 \rbrace.
$$

Ha $n \in \mathbb{N}$ és $n>n_0$, akkor nyilván $n> n_1$ és $n > n_2$ is fennáll, következésképpen

$$
|A_1 - A_2| = |(A_1-a_n) + (a_n - A_2)| \leq |a_n - A_1| + |a_n - A_2| < \epsilon + \epsilon = 2 \epsilon = |A_1 - A_2|,
$$

amiből (a nyilván nem igaz) $|A_1 - A_2| < |A_1 - A_2|$ következne. Ezért csak $A_1 = A_2$ lehet.

Az $|a_n - A|< \epsilon$ egyenlőtlemség azzal ekvivalens, hogy $A - \epsilon < a_n < A + \epsilon$, vagyus $a_n \in K_\epsilon (A)$, azaz $a_n$ eleme az $A$ középpontú $\epsilon$ sugarú környezetnek. Ezért

$$
\lim (a_n) = A \quad \quad \iff \quad \quad \forall \epsilon > 0 \text{-hoz} \ \ \exists n_0 \in \mathbb{N}, \forall n > n_0 : a_n \in K_\epsilon (A).
$$

Szavakkal megfogalmazva azt is mondhatjuk, hogy "az $(a_n)$ sorozat konvergens, ha van olyan valós szám, hogy annak tetszőleges környezete tartalmazza a sorozat minden, alkalmas küszöbindex utáni tagját". Mivel a küszöbindex előtt csak véges sok index van, ezért

$$
\lim (a_n) = A \quad \quad \iff \quad \quad \forall \epsilon > 0 \ \ \text{esetén} \ \ \left\lbrace n \in \mathbb{N} \mid a_n \notin K_\epsilon (A) \right\rbrace \ \ \text{véges halmaz.}
$$

Más szavakkal: "az $(a_n)$ sorozat konvergens, ha van olyan valós szám, hogy annak tetszőleges környezetéből legfeljebb véges sok sorozatbeli tag marad ki".

A hatáérték fogalmát szemléltetik az alábbi ábrák:

![hatarertek](hatarertek.png)

## 6. A konvergencia és a korlátosság kapcsolata.

**03/03 Tétel.** Ha az $(a_n)$ sorozat konvergens, akkor korlátos is.

**Bizonyítás.** Tegyük fel, hogy $(a_n)$ konvergens és $\lim (a_n) = a \in \mathbb{R}$. Válasszuk a konvergencia definíciója szerinti jelöléssel $\epsilon$-t 1-nek. Ehhez a hibakorláthoz

$$
\exists n_0 \in \mathbb{N}, \forall n > n_0 : |a_n - A| < 1.
$$

Így

$$
|a_n| = |(a_n - A) + A| \leq |a_n - A| + |A| < 1 + |A| \quad (n>n_0).
$$

Ha $n \leq n_0$, akkor

$$
|a_n| \leq \max \left\lbrace |a_0|, |a_1, \dots , |a_n0| \right\rbrace.
$$

Legyen

$$
K := \max \left\lbrace |a_0|, |a_1|, \dots , |a_n0|, 1+|A|\right\rbrace.
$$

Ekkor $|a_n| \leq K$ minden $n \in \mathbb{N}$ indexre, és ez azt jelenti, hogy az $(a_n)$ sorozat korlátos.

**Megjegyzés.** Az állítás megfordítása nem igaz. Például a $\big( (-1)^n \big)$ sorozat korlátos, de nem konvergens. A konvergenciának tehát a korlátosság szükséges, de nem elégséges feltétele.

## 7. Monoton részsorozatok létezésére vonatkozó tétel.

**03/06 Tétel.** Minden $a = (a_n)$ valós sorozatnak létezik monoton részsorozata, azaz létezik olyan $v = v_n$ indexsorozat, amellyel $a \circ v$ monoton növekedő vagy monoton csökkenő.

**Bizonyítás.**

Az állítás igazolásához bevezetjük egy sorozat csúcsának a fogalmát: Azt mondjuk, hogy $a_{n_0}$ az $(a_n)$ sorozat csúcsa (vagy csúcseleme), ha 

$$
\forall n \geq n_0 \quad \text{indexre} \quad a_n \leq a_{n_0}.
$$

![Monoton részsorozat](monotonreszsorozat.png)

Két eset lehetséges.

I. eset. A sorozatnak **végtelen** sok csúcsa van. Ez azt jelenti, hogy

$$
\exists v_0 \in \mathbb{N} : a_{v_0} \ \ \text{csúcselem, azaz} \ \ \forall n \geq v_0 : a_n \leq a_{v_0},
$$

$$
\exists v_1 > v_0 : a_{v_1} \ \ \text{csúcselem, azaz} \ \ \forall n \geq v_1 : a_n \leq a_{v_1} \ (\leq a_{v_0}),
$$

Ezek a lépések folytathatók, mert végtelen sok csúcselem van. Így olyan $v_0 < v_1 < v_2 < \dots$ indexsorozatot kapunk, amelyre

$$
a_{v_0} \geq a_{v_1} \geq a_{v_2} \geq \dots,
$$

ezért a csúcsok $(a_{v_n})$ sorozata $(a_n)$-nek egy monoton csökkenő részsorozata.

II. eset. A sorozatnak legfeljebb **véges** sok csúcsa van. Ez azt jelenti, hogy 

$$
\exists N \in \mathbb{N}, \forall n \geq N \quad \text{esetén} \quad a_n \quad \text{már nem csúcs}. 
$$

Mivel $a_N$ nem csúcselem, ezért

$$
\exists v_0 > N : a_{v_0} > a_N.
$$

Azonban $a_{v_0}$ sem csúcselem, ezért

$$
\exists v_1 > v_0 : a_{v_1} > a_{v_0} \ (> a_N).
$$

Az eljárást folytatva most olyan $v_0<v_1<v_2<\dots$ indexsorozatot kapunk, amelyre

$$
a_{v_0} < a_{v_1} < a_{v_2} < \dots .
$$

Ebben az esetben tehát $(a_{v_n})$ sorozat $(a_n)$-nek egy (szigorúan) monoton növekvő részsorozata.

## 8. A sorozatokra vonatkozó közrefogási elv.

**03/07 Tétel (A közrefogási elv).** Tegyük fel, hogy az $(a_n)$, $(b_n)$ és $(c_n)$ sorozatokra teljesülnek a következők:

- $\exists N \in \mathbb{N}, \forall n > N : a_n \leq b_n \leq c_n$,
- az $(a_n)$ és a $(c_n)$ sorozatnak van határértéke, továbbá

$$
\lim (a_n) = \lim (c_n) = A \in \overline{\mathbb{R}}.
$$

Ekkor a $(b_n)$ sorozatnak is van határértéke és $\lim (b_n) = A$.

**Bizonyítás.** Három eset lehetséges.

I. eset: $\boxed{A \in \mathbb{R}}$ Legyen $\epsilon > 0$ tetszőleges valós szám. $\lim (a_n) = \lim(c_n) = A$ azt jelenti, hogy $(a_n)$ és $(c_n)$ azonos $A$ határértékkel rendelkező konvergens sorozatok. A konvergencia definíciója szerint tehát

$$
\exists n_1 \in \mathbb{N}, \forall n > n_1 : A -\epsilon < a_n < A + \epsilon,
$$

$$
\exists n_2 \in \mathbb{N}, \forall n > n_2 : A -\epsilon < c_n < A + \epsilon,
$$

Legyen $n_0 := \max \left\lbrace N, n_1, n_2 \right\rbrace$. Ekkor $\forall n > n_0$ indexre

$$
A - \epsilon < a_n \leq b_n \leq c_n < A+\epsilon.
$$

Ez azt jelenti, hogy

$$
|b_n -A | < \epsilon , \quad \text{ha} \quad n > n_0,
$$

azaz a $(b_n)$ sorozat konvergens, tehát van határértéke, és $\lim (b_n) = A$.

II. eset: $\boxed{A = + \infty}$ Tegyük fel, hogy $P > 0$ tetszőleges valós szám. A $\lim (a_n) = + \infty$ értelmezése szerint

$$
\exists n_1 \in \mathbb{N}, \forall n > n_1 : a_n > P.
$$

Legyen $n_0 := \max \left\lbrace N,n_1 \right\rbrace$. Ekkor $\forall n > n_0$ indexre

$$
P < a_n \leq b_n,
$$

és ez azt jelenti, hogy $\lim(b_n) = + \infty$.

III. eset: $\boxed{A = - \infty}$ Tegyük fel, hogy P<0 tetszőleges valós szám. A $\lim (c_n) = - \infty$ értelmezése szerint

$$
\exists n_1 \in \mathbb{N}, \forall n > n_1 : c_n < P.
$$

Legyen $n_0 := \max \left\lbrace N, n_1 \right\rbrace$, akkor $\forall n > n_0$ indexre

$$
P > c_n \geq b_n.
$$

Ez pedig azt jelenti, hogy $\lim (b_n) = - \infty$.

**Megjegyzés.** Vegyük észre, hogy a bizonyítás 2. esetében a $(c_n)$ sorozat nem játszik szerepet.

Ezért ebben az esetben közrefogás helyett egy *minoráns* jellegű tulajdonságot kapunk:

$$
\exists N \in \mathbb{N}, \forall n > N : a_n \leq b_n \quad \text{és} \quad \lim(a_n) = + \infty \quad \implies \quad \lim (b_n) = + \infty.
$$

Hasonlóan, a bizonyítás 3. esetében az (a_n) sorozat nem játszik szerepet. Ezért ebben az esetben közrefogás helyett egy *majoráns* jellegű tulajdonságot kapunk:

$$
\exists N \in \mathbb{N}, \forall n > N : b_n \leq c_n \quad \text{és} \quad \lim (c_n) = - \infty \quad \implies \quad \lim (b_n) = - \infty.
$$

## 9. A határérték és a rendezés kapcsolata.

A következő tétel azt állítja, hogy a határértékek közötti nagyságrendi kapcsolatok öröklődnek a soroatok elég nagy indexű tagjaira. Sőt, bizonyos értelemben "fordítva": a tagok nagyságrendi kapcsolataiból következtethetünk a határértékek közötti nagyságrendi viszonyokra.

**03/08 Tétel.** Tegyük fel, hogy az $(a_n)$ és a $(b_n)$ sorozatnak van határértéke és

$$
\lim (a_n) = A \in \overline{\mathbb{R}}, \quad \quad \lim (b_n) = B \in \overline{\mathbb{R}}.
$$

Ekkor:

1. $A < B \quad \implies \quad \exists N \in \mathbb{N}, \forall n > N : a_n < b_n$.
2. $\exists N \in \mathbb{N}, \forall n > N : a_n \leq b_n \quad \implies \quad A \leq B.$

**Bizonyítás.**

I. Azt már tudjuk, hogy bármely két különböző $\overline{\mathbb{R}}$-beli elem szétválasztható diszjunkt környezetekkel:

$$
\forall A,B \in \overline{\mathbb{R}}, A \neq B \text{-hez} \ \ \exists r_1,r_2 > 0, K_{r_1}(A) \cap K_{r_2}(B) = \emptyset.
$$

Világos, hogy ha $A < B$, akor $\forall x \in K_{r_1}(A), \forall y \in K_{r_2}(B):x<y$.

Mivel $\lim (a_n) = A$ és $\lim (b_n) = B$, így a definíció értelmében

$$
\exists n_1 \in \mathbb{N}, \forall n > n_1 : a_n \in K_{r_1}(A),
$$

$$
\exists n_2 \in \mathbb{N}, \forall n > n_2 : b_n \in K_{r_1}(B).
$$

Legyen $N := \max \left\lbrace n_1, n_2 \right\rbrace$. Ekkor $\forall n > N$ esetén

$$
a_n \in K_{r_1}(A) \quad \text{és} \quad b_n \in K_{r_2}(B) \quad \implies \quad a_n<b_n.
$$

II. Indirekt módon bizonyítjuk. Tegyük fel, hogy $A>B$. Ekkor a már igazolt 1. állítás szerint $\exists N \in \mathbb{N}$, hogy minden $n > N$ indexre $b_n < a_n$, ami ellentmond a feltételnek.

**Megjegyzés.** Figyeljük meg, hogy tétel állításai "majdnem" egymás megfordításai, de egyik sem fordítható meg.

- Az 1. állítás megfordítása nem igaz, azaz az $a_n < b_n$ feltételből nem következtethetünk az $A<B$ egyenlőtlenségre. Tekintsük oéldául az 

$$
a_n := - \frac{1}{n} \quad \text{és} \quad b_n := \frac{1}{n} \quad (n \in \mathbb{N}^+)
$$

sorozatokat.

- A 2. állítás megfordítása sem igaz. Legyen például

$$
a_n := \frac{1}{n} \quad \text{és} \quad b_n := - \frac{1}{n} \quad (n \in \mathbb{N}^+).
$$

## 10. Műveletek nullsorozatokkal.

**04/02 Tétel (Műveletek nullsorozatokkal).** Tegyük fel, hogy $\lim (a_n) = 0$ és $\lim (b_n) = 0$.

Ekkor

1. $(a_n + b_n)$ is nullsorozat,
2. ha $(c_n)$ korlátos sorozat, akkor $(c_n \cdot a_n)$ is nullsorozat,
3. $(a_n \cdot b_n)$ is nullsorozat.

**Bizonyítás.**

1. Mivel $\lim (a_n) = \lim (b_n) = 0$, ezért $\forall \epsilon > 0$-hoz

$$
\exists n_1 \in \mathbb{N}, \forall n > n_1 : | a_n | < \frac{\epsilon}{2},
$$

$$
\exists n_2 \in \mathbb{N}, \forall n > n_2 : | b_n | < \frac{\epsilon}{2}.
$$

Legyen $n_0 := \max \left\lbrace n_1, n_2 \right\rbrace$. Ekkor $\forall n > n_0$ indexre

$$
|a_n + b_n| \leq |a_n| + |b_n| < \frac{\epsilon}{2} + \frac{\epsilon}{2} = \epsilon,
$$

és ez azt jelenti, hogy $\lim (a_n + b_n) = 0$, azaz $(a_n + b_n)$ valóban nullsorozat.

2. A $(c_n)$ sorozat korlátos, ezért

$$
\exists K > 0 : |c_n| < K \quad (n \in \mathbb{N}).
$$

Mivel $(a_n)$ nullsorozat, ezért

$$
\forall \epsilon > 0 \text{-hoz} \ \ \exists n_0 \in \mathbb{N}, \forall n > n_0 : |a_n| < \frac{\epsilon}{K},
$$

következésképpen minden $n > n_0$ indexre

$$
|c_n \cdot a_n| = |c_n| \cdot |a_n| < K \cdot \frac{\epsilon}{K} = \epsilon ,
$$

azaz $\lim (c_n \cdot a_n) = 0$.

3. Mivel minden konvergens sorozat korlátos, ezért a $\lim (b_n) = 0$ feltételből következik, hogy $(b_n)$ korlátos sorozat. Az állítás tehát a 2. állítás közvetlen következménye.

## 11. Konvergens sorozatok szorzatára vonatkozó tétel.



## 12. Konvergens sorozatok hányadosára vonatkozó tétel.

A következő tétel már általános kovergens sorozatokra vonatkozik. Azt állítja, hogy a konvergens sorozatok a müveletek során a legtöbb esetben jól viselkednek abban az értelemben, hgy az alapműveletek és a határértékképzés sorrendje felcserélhető.

**04/03 Tétel (Műveletek konvergens sorozatokkal).** Tegyük fel, hogy az $(a_n)$ és a $(b_n)$ sorozat konvergens. Legyen

$$
\lim (a_n) = A \in \mathbb{R} \quad \text{és} \quad \lim (b_n) = B \in \mathbb{R}. 
$$

Ekkor

1. $(a_n + b_n)$ is konvergens és $\lim (a_n + b_n) = \lim (a_n) + \lim (b_n) = A + B$,
2. $(a_n \cdot b_n)$ is konvergens és $\lim (a_n \cdot b_n) = \lim (a_n) \cdot \lim (b_n) = A \cdot B$,
3. ha $b_n \neq 0 \ \ (n \in \mathbb{N})$ és $\lim (b_n) \neq 0$, akkor

$$
\left(\frac{a_n}{b_n}\right) \quad \text{is konvergens, és} \ \ \lim \left(\frac{a_n}{b_n}\right) = \frac{\lim (a_n)}{\lim (b_n)} = \frac{A}{B}.
$$

**Bizonyítás.** Gyakran fogjuk alkalmazni a nullsorozatok 2. alaptulajdonsága, ami azt mondja ki, hogy

$(*) \quad (x_n)$ konvergens, és $\alpha \in \mathbb{R}$ a  határértéke $\quad \iff \quad (x_n - \alpha)$ nullsorozat.

1. $(*)$ miatt elég megmutatni, hogy $\big((a_n + b_n) - (A + B)\big)$ nullsorozat. Ez nyilván igaz, mert

$$
\big((a_n + b_n) - (A + B)\big) = (a_n - A) + (b_n - B),
$$

és két nullsorozat összege is nullsorozat.

2. $(*)$ miatt elég megmutatni, hogy (a_n b_n - AB) nullsorozat. Ez a következő átalakítással igazolható:

$$
a_n b_n - AB = a_n b_n - A b_n + A b_n -AB = \underbrace{\underbrace{\underbrace{b_n}_{\text{korlátos}} \cdot \underbrace{(a_n - A)}_{\text{nullsorozat}}}_{\text{nullsorozat}} +\underbrace{\underbrace{A}_{\text{korlátos}} \cdot \underbrace{(b_n - B)}_{\text{nullsorozat}}}_{\text{nullsorozat}}}_{\text{nullsorozat}}.
$$

A fenti gondolatmenetben a $(b_n)$ sorozat azért korlátos, mert konvergens.

3. A bizonyításhoz először egy önmagában is érdekes állítást igazolunk.

**$\underline{\text{Segédtétel.}}$** Ha $b_n \neq 0 \ \ (n\in \mathbb{N})$ és $(b_n)$ konvergens, továbbá $B := \lim (b_n) \neq 0$, akkor az

$$
\left(\frac{1}{b_n} \right)
$$

reciprok-sorozat korlátos.

Ennek bizonyításához legyen $\epsilon := |B|/2$. Ekkor egy alkalmas $n_0 \in \mathbb{N}$ küszöbindex mellett

$$
|b_n - B| < \epsilon = \frac{|B|}{2} \quad \forall n > n_0 \ \ \text{indexre}.
$$

Így minden $n > n_0$ esetén

$$
|b_n| \geq |B| - |b_n -B| > |B| - \frac{|B|}{2} = \frac{|B|}{2},
$$

hiszen $|B| = |B - b_n + b_n| \leq |B - b_n| + |b_n|$. Tehát

$$
\left| \frac{1}{b_n} \right| < \frac{2}{|B|}, \ \ \text{ha} \ \ n>n_0,
$$

következésképpen az 

$$
\left| \frac{1}{b_n} \right| \leq \max \left\lbrace \frac{1}{|b_0|}, \frac{1}{|b_1|}, \dots , \frac{1}{|b_{n_0}|}, \frac{2}{|B|} \right\rbrace
$$

egyenlőtlenség már minden $n \in \mathbb{N}$ számra teljesül, ezért az $(1/b_n)$ sorozat valóban korlátos. A segédtételt tehát bebizonyíítottuk.

Most azt látjuk be, hogy az 

$$
\left(\frac{1}{b_n} \right) \ \ \text{sorozat konvergens} \quad \text{és} \quad \lim \left(\frac{1}{b_n}\right) = \frac{1}{B}.
$$

Ez $(*)$-ből következik az alábbi átalakítással:

$$
\frac{1}{b_n} - \frac{1}{B} = \frac{B - b_n}{B \cdot b_n} = \underbrace{\underbrace{\frac{1}{B \cdot b_n}}_{\text{korlátos}} \cdot \underbrace{(B - b_n)}_{\text{nullsorozat}}}_{\text{nullsorozat}}.
$$

A 3. állítás bizonyításának a befejezéséhez már csal azt kell figyelembe venni, hogy

$$
\frac{a_n}{b_n} = a_n \cdot \frac{1}{b_n} \quad (n \in \mathbb{N}),
$$

más szóval az $(a_n/b_n)$ "hányados-sorozat" két konvergens sorozat szorzata. Így a 2. állítás és a reciprok sorozatról az előbb mondottak miatt

$$
\left(\frac{a_n}{b_n} \right) \ \ \text{is konvergens} \ \ \text{és} \ \ \lim \left(\frac{a_n}{b_n} \right) = A \cdot \frac{1}{B} = \frac{A}{B} = \frac{\lim (a_n)}{\lim (b_n)}.
$$

## 13. Monoton növekvő sorozatok határértékére vonatkozó tétel (véges és végtelen eset).

### Monoton sorozatok határértéke

A sorozatok egy légyeges osztályát képezik a monoton sorozatok. Látni fogjuk azt, hogy **minden monoton sorozatnak van határértéke**. Ha még azt is feltesszük, hogy a sorozat korlátos, akkor a sorozat konvergens is. Nem korlátos sorozatok határértéke pedig vagy $+ \infty$ vagy $- \infty$. Mivel a monotonitást, illetve a korlátosságot egyszerűbb eldönteni, mint a konvergenciát vagy a határértéket, ezért a következő tétel sok esetben jól használható módszert ad a határérték-vizsgálatokhoz.

**04/05 Tétel.** Minden $(a_n)$ monoton sorozatnak van határértéke.

1. 

a) Ha $(a_n) \nearrow$ és felülről korlátos, akkor $(a_n)$ konvergens és

$$
\lim (a_n) = \sup \left\lbrace a_n \mid n \in \mathbb{N} \right\rbrace .
$$

b) Ha $(a_n) \searrow$ és alulról korlátos, akkor $(a_n)$ konvergens és

$$
\lim (a_n) = \inf \left\lbrace a_n \mid n \in \mathbb{N} \right\rbrace .
$$

2. 

a) Ha $(a_n) \nearrow$ és felülről nem korlátos, akkor $\lim (a_n) = + \infty$.

b) Ha $(a_n) \searrow$ és alulról nem korlátos, akkor $\lim(a_n) = - \infty$.

**Bizonyítás.** Az állítás csak monoton növekvő sorozatokra fogjuk igazolni. Értelemszerű módosításokkal bizonyíthatjuk be az állítást a monoton csökkenő sorozatokra.

1. Tegyük fel, hogy az $(a_n)$ sorozat monoton növekvő és felülről korlátos. Legyen

$$
A := \sup \left\lbrace a_n \mid n \in \mathbb{N} \right\rbrace \in \mathbb{R} .
$$

Ez azt jelenti, hogy $A$ a szóban forgó halmaznak a legkisebb felső korlátja, azaz 

- $\forall n \in \mathbb{N} : a_n \leq A \quad$ és
- $\forall \epsilon > 0$-hoz $\exists n_0 \in \mathbb{N} : A - \epsilon < a_{n_0} \leq A$.

Mivel a feltételezésünk szerint az $(a_n)$ sorozat monoton növekvő, ezért az

$$
A - \epsilon < a_{n_0} \leq a_n \leq A .
$$

becslés is igaz minden $n > n_0$ indexre. Azt kapjuk tehát, hogy

$$
\forall \epsilon > 0 \text{-hoz} \ \ \exists n_0 \in \mathbb{N}, \forall n > n_0 : |a_n - A| < \epsilon .
$$

Ez pontosan azt jelenti, hogy az $(a_n)$ sorozat konvergens, és $\lim (a_n) = A$ .

2. Tegyük fel, hogy az $(a_n)$ sorozat monoton növekő és felülről nem korlátos. Ekkor

$$
\forall P > 0 \text{-hoz} \ \ \exists n_0 \in \mathbb{N} : a_{n_0} > P .
$$

A monotonitás miatt ezért egyúttal az is igaz, hogy

$$
\forall n > n_0 : a_n \geq a_{n_0} > P ,
$$

és ez pontosan azt jelenti, hogy $\lim (a_n) = + \infty$ .

**Megjegyzés.** A tételben elég feltenni azt, hogy a sorozat egy küszöbindextől kezdve monoton, hiszen véges sok tag nem befolyásolja a határértéket.

## 14. Az $a_n := \left(1 + \frac{1}{n}\right)^n \ \ (b \in \mathbb{N}^+)$ sorozat konvergenciája

**6.** Az $e$ szám bevezetése.

**05/02 Tétel (Az $e$ szám értelmezése).** Az 

$$
a_n := \left(1 + \frac{1}{n}\right)^n \quad (n \in \mathbb{N}^+)
$$

sorozat szigorúan monoton növekvő és felülről korlátos, tehát konvergens. Legyen

$$
e := \lim_{n \to + \infty} \left(1 + \frac{1}{n}\right)^n .
$$

**Bizonyítás.** Az állítás a számtani és a mértani közép közötti egyenlőtlenség "ötletes" felhasználásával bizonyítjuk.

- **A monotonitás** igazolásához az egyenlőtlenséget az $(n + 1)$ darab

$$
1, \ \ 1 + \frac{1}{n}, \ \ 1 + \frac{1}{n}, \ \ \dots , \ \ 1 + \frac{1}{n}
$$

számra alkalmazzuk. Mivel ezek nem mind egyenlők, ezért

$$
\sqrt[n+1]{1 \cdot \left(1 + \frac{1}{n}\right)^n} < \frac{1 + n \cdot \left(1 + \frac{1}{n}\right)}{n + 1} = \frac{n + 2}{n + 1} = 1 + \frac{1}{n + 1} .
$$

Mindekét oldalt $(n + 1)$-edik hatványra emelve azt kapjuk, hogy

$$
a_n = \left(1 + \frac{1}{n}\right)^n < \left(1 + \frac{1}{n+1}\right)^{n+1} = a_{n+1} \quad (n \in \mathbb{N}^+) ,
$$

amivel beláttuk, hogy a sorozat szigorúan monoton növekvő.

- **A korlátosság** bizonyításához most az $(n + 2)$ darab

$$
\frac{1}{2}, \ \ \frac{1}{2}, \ \ 1 + \frac{1}{n}, \ \ 1 + \frac{1}{n}, \ \ \dots , \ \ 1 + \frac{1}{n}
$$

számra alkalmazzuk ismét a számtani és mértani közép közötti egyenlőtlenséget:

$$
\sqrt[n+2]{\frac{1}{2} \cdot \frac{1}{2} \cdot \left(1 + \frac{1}{n}\right)^n} < \frac{2 \cdot \frac{1}{2} + n \cdot \left(1 + \frac{1}{n}\right)}{n + 2} = \frac{n + 2}{n + 2} = 1 .
$$

Ebből következik, hogy

$$
a_n = \left(1 + \frac{1}{n}\right)^n < 4 \quad (n \in \mathbb{N}^+) ,
$$

ezért a sorozat felülről korlátos.

A monoton sorozatok határértékére vonatkozó tételből következik, hogy a sorozat konvergens.

## 15. Newton-féle iterációs eljárás $m$-edik gyökök keresésére.

### Rekurzív sorozatok határértéke

A monoton sorozatok konvergenciájára vonatkozó tételt egyszerű feltételei miatt már több esetbenisalkalmaztuk. Atételtszámos, rekurzióval megadott sorozatok konvergencia-vizsgálatánál is jól használhatjuk. A módszer alkalmazása során bebizonyítjuk, hogy a sorozat konvergens; a határértékét pedig a rekurzív képletből nyerhető egyenlet gyökeiből választjuk ki. A módszer hatékonyságát mutatja, hogy a sorozatok nagyságrendjéről szóló részben a határértékek kiszámításához két esetben is felírtuk a sorozatot rekurzív alakban.

Most ennek a módszernek a felhasználásával igazoljuk pozitív valós számok $m$-edik gyökének a létezését, és egy egyszerű konstruktív eljárást adunk ezek közelítő kiszámítására.

Emlékeztetünk arra, hogy ha $A > 0$ tetszőleges valós szám és $m \geq 2$ természetes szám, akkor az $\sqrt[m]{A}$ szimbólummal jelöljük (és az **$A$ szám $m$-edik gyökének** nevezzük) azt a pozitív valós számot, amelynek az $m$-edik hatványa $A$, azaz $\alpha^m = A$. A következő tételből következik, hogy olya $\alpha$ szám mindig létezik.

**05/04 Tétel (Newton-féle iterációs eljárás $m$-edik gyökök keresésére).** Legyen $A > 0$ valós szám és $m \geq 2$ természetes szám. Ekkor az

$$
\begin{cases}
    a_0 > 0 \quad \text{tetszőleges valós szám,} \\
    a_{n+1} := \frac{1}{m} \left( \frac{A}{a_n^{m-1}} + (m-1)a_n \right) \quad (n \in \mathbb{N})
\end{cases}
$$

rekurzióval értelmezett $(a_n)$ sorozat konvergens, és az $\alpha := \lim (a_n)$ határértékre igaz, hogy $\alpha > 0$ és

$$
\alpha^m = A .
$$

**Bizonyítás.** Az állítást több lépésben igazoljuk.

**1. lépés.** Teljes indukcióval könnyen igazolható, hogy az $(a_n)$ sorozat "jól definiált" és $a_n > 0 \ \ (n \in \mathbb{N}) .$

**2. lépés.** $\underline{ \text{Igazoljuk, hogy az} \ \ (a_n) \ \ \text{sorozat konvergens.} }$ A monoton sorozatok konvergenciájára vonatkozó tételt fogjuk alkalmazni.

A sorozat alulról korlátos és $0$ egy triviális alsó korlát (az 1. lépés alapján).

Most megmutatjuk azt, hogy az $(a_n)$ sorozat a második tagtól kezdve monoton csökkenő, azaz

$$
a_{n+1} \leq a_n \quad \iff \quad \frac{a_{n+1}}{a_n} \leq 1, \quad \text{ha} \ \ n = 1, 2, \dots .
$$

A rekurzív képlet szerint minden $n \in \mathbb{N}^+$ esetén

$$
\frac{a_{n+1}}{a_n} = \frac{1}{m} \left(\frac{A}{a_{n}^m} + m - 1 \right) \leq 1 \quad \iff \quad a_{n}^m \geq A .
$$

A jobb oldali egyenlőtlenség igazolására a számtani és a mértani közép közötti egyenlőtlenslg következő alakját fogjuk alkalmazni: ha $x_1, x_2, \dots , x_m$ tetszés szerinti nemnegatív valós számok, akkor

$(\triangle) \quad \quad x_1 \cdot x_2 \cdot _\dots \cdot x_m \leq \left(\frac{x_1+x_2+ \dots + x_m}{m} \right)^m$,

és az egyenlőség akkor és csak akkor áll fenn, ha $x_1 = x_2 = \dots = x_m .$ Fontos hangsúlyozni, hogy lényegében ezt az alakot igazoltuk gyakorlaton, és csak az $m$-edik gyök egyértelmű létezése után írhatjuk fel az egyenlőséget a megszokott alakban.

Vegyük észre, hogy a rekurzív képlet jobb oldalán álló összeg az $m$ darab

$$
x_1 := \frac{A}{a_{n}^{m-1}}, \ \ x_2 := a_n, \ \ x_3 := a_n, \ \ \dots \ \ , \ \ x_m := a_n \quad (n \in \mathbb{N})
$$

pozitív szám számtani közepe. Ezért $(\triangle)$ miatt

$$
a_{n+1}^m = \left( \frac{1}{m} \left( \frac{A}{a_{n}^{m-1}} + \underbrace{a_n + \dots + a_n}_{m-1 \ \ \text{darab}} \right) \right)^m = \left(\frac{x_1 + x_2 + \dots + x_m}{m} \right)^m \geq 
$$

$$
\geq x_1 \cdot x_2 \cdot \dots \cdot x_m = \frac{A}{a_{n}^{m-1}} \cdot \underbrace{a_n \cdot a_n \cdot \dots \cdot a_n}_{m-1 \ \ \text{darab}} = A \quad (n \in \mathbb{N}).
$$

Sikerült igazolnunk tehát, hogy $a_{n}^{m} \geq A \ \ (n \in \mathbb{N}^+)$, ezzel azt, hogy az $(a_n)$ sorozat a második tagtól kezdve monoton csökkenő.

Az $(a_n)$ sorozat tehát monoton csökkenő a második tagtól kezdve és alulról korlátos, ezért a monoton sorozatok határértékére vonatkozó tétel alapján $(a_n)$ komvergens.

**3. lépés.** $\underline{\text{Kiszámítjuk a sorozat határértékét.}}$ Legyen

$$
\alpha := \lim (a_n).
$$

Az eddigiekből az következik, hogy $\alpha \geq 0$. Fontos észrevétel azonban az, hogy az $\alpha > 0$ egyenlőtlenség is igaz. Ez az állítás a konvergens sorozatok és a műveletek kapcsolatára vonatkozó tételből, valamint a határérték és a rendezés kapcsolatára vonatkozó tételből következik, hiszen

$$
a_{n}^{m} \geq A, \ \ a_n \to \alpha \quad \implies \quad a_{n}^{m} \to \alpha^m \geq A > 0 \quad \implies \quad \alpha > 0 .
$$

Az $(a_n)$ sorozatot megadó rekurzív összefüggésben az $n \to \infty$ határátmenetet véve az $\alpha$ határértékre egy egyenletet kapunk. Valóban, ha alkalmazzuk a konvergens sorozatok és a műveletek kapcsolatára vonatkozó tételeket (itt használjuk az $\alpha > 0$ egyenlőtlenséget), akkor az adódik, hogy

$$
\alpha \gets a_{n+1} = \frac{1}{m} \left(\frac{A}{a_{n}^{m-1}} + (m-1) \cdot \underbrace{a_n}_{\to \alpha} \right) \to \frac{1}{m} \left(\frac{A}{\alpha^{m-1}} + (m-1) \alpha \right) .
$$

A határérték egyértelműsége miatt

$$
\alpha = \frac{1}{m} \left(\frac{A}{\alpha^{m-1}} + (m-1) \alpha \right) .
$$

Innen már egyszerű átrendezéssel azt kapjuk, hogy

$$
m \alpha^m = A + (m-1) \alpha^m \quad \implies \quad \alpha^m = A .
$$

## 16. A Cauchy-féle konvergenciakritérium sorozatokra.

**05/01 Definíció.** Az $(a_n)$ valós sorozatot **Cauchy-sorozatnak** nevezzük, ha

$$
\forall \epsilon > 0 \text{-hoz} \ \ \exists n_0 \in \mathbb{N}, \forall m, n > n_0 : |a_n-a_m|<\epsilon .
$$

**Megjegyzés.** Pongyolán, de szemléletesen fogalmazva: "egy sorozat akkor Cauchy-sorozat, ha az elég nagy indexű tagjainak távolsága kisebb, mint bármely előre meghatározott kicsi szám".

Látható tehát, hogy az ún. **Cauchy-tulajdonságban** kizárólag a sorozat tagjai játszanak szerepet.

A kövekező tétel azt állítja, hogy a Cauchy-tulajdonság szükséges és elégséges feltétele a sorozat konvergenciájának.

**05/06 Tétel (A Cauchy-féle konvergenciakritérium).** Legyen $(a_n)$ egy valós sorozat.

Ekkor

$$
(a_n) \ \ \text{konvergens} \quad \iff \quad (a_n) \ \ \text{Cauchy-sorozat} .
$$

**Bizonyítás.**

$\boxed{\Rightarrow}$ Tegyük fel, hogy $(a_n)$ konvergens, és $A := \lim (a_n)$ a határértéke. Legyen $\epsilon > 0$ tetszőleges valós szám. A konvergencia definíciója szerint

$$
\exists n_0 \in \mathbb{N}, \forall n > n_0 : |a_n - A| < \frac{\epsilon}{2} .
$$

Így $\forall m,n>n_0$ index esetén

$$
|a_n - a_m| = \left|(a_n - A) + (A - a_m) \right| \leq |a_n - A| + |a_m - A| < \frac{\epsilon}{2} + \frac{\epsilon}{2} = \epsilon ,
$$

és ez azt jelenti, hogy $(a_n)$ Cauchy-sorozat.

$\boxed{\Leftarrow}$ Tegyük fel, hogy $(a_n)$ Cauchy-sorozat. Több lépésen keresztül látjuk be, hogy $(a_n)$ konvergens.

**1. lépés.** $\underline{\text{Igazoljuk, hogy } (a_n) \text{ korlátos sorozat.}}$

A Cauchy-sorozat definíciójában $\epsilon = 1$-hez van olyan $n_1 \in \mathbb{N}$ index, hogy

$$
\forall m,n > n_1 : |a_n - a_m| < 1 .
$$

Legyen $m = n_1 + 1$. Ekkor minden $n > n_1$ esetén

$$
|a_n| = \left|(a_n - a_{n_1+1}) + a_{n_1+1} \right| \leq |a_n - a_{n_1+1}| + |a_{n_1+1}| < 1 + |a_{n_1+1}| .
$$

Következésképpen az

$$
|a_n| \leq \max \left\lbrace |a_0|, |a_1|, \dots , |a_{n_1}|, 1+|a_{n_1+1}| \right\rbrace
$$

egyenlőtlenség már minden $n \in \mathbb{N}$ számra igaz, azaz a sorozat valóban korlátos.

**2. lépés.** A Bolzano-Weierstrass-féle kiválasztási tételből következik, hogy $(a_n)$-nek létezik egy $(a_{v_n})$ konvergens részsorozata. Jelölje

$$
A:= \lim (a_{v_n}) \in \mathbb{R} .
$$

**3. lépés.** $\underline{\text{Belátjuk, hogy } \lim (a_n) = A \text{ is igaz.}}$

Legyen $\epsilon > 0$ tetszőleges. Ekkor $A$ definíciójából következi, hogy 

$$
\exists n_2 \in \mathbb{N}, \forall > n_2 : |a_{v_n} - A| < \frac{\epsilon}{2} .
$$

Az $(a_n)$ Cauchy-sorozat ezért $\epsilon / 2$-höz

$$
\exists n_3 \in \mathbb{N}, \forall n,m > n_3 : |a_n - a_m| < \frac{\epsilon}{2} .
$$

Mivel $(v_n) : \mathbb{N} \to \mathbb{N}$ indexsorozat (vagyis $(v_n)$ szigorúan monoton növekvő), ezért $v_n \geq n \ \ (n \in \mathbb{N})$, amit teljes indukcióval lehet igazolni.

Ha $n > n_0 := \max \left\lbrace n_2, n_3 \right\rbrace$, akkor $v_n > n_0$, ezért $n$ és $m:=v_n$ is nagyobb, mint $n_2$ és $n_3$, tehát alkalmazhatók a fenti egyenlőtlenségek. Ekkor

$$
|a_n -A| = \left|(a_n - a_{v_n}) + (a_{v_n} - A)\right| \leq |a_n - a_m| + |a_{v_n} - A| < \frac{\epsilon}{2} + \frac{\epsilon}{2} = \epsilon ,
$$

és ez azt jelenti, hogy az $(a_n)$ sorozat valóban konvergens, és $\lim (a_n) = A$.

**Megjegyzés.** Fontos megjegyezni, hogy az iménti tétel konvergens (tehát véges határértékű) sorozatokról szól. Végtelen határértékekre az analóg állítás nem igaz: például az $(n)$ sorozatnak a határértéke $+ \infty$, de ez nem Cauchy-sorozat. A sok hasonlóság mellett ez az egyik leglényegesebb különbség a konvergens, ill. a $\pm \infty$-hez tartó sorozatok között.