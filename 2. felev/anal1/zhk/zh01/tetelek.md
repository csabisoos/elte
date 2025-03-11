## 1. A teljes indukció elve.

**1. Tétel (A teljes indukció elve).** Tegyük fel, hogx minden $n$ természetes számra adott egy $A(n)$ állítás, és azt tudjuk, hogy

i) $A(0)$ igaz,

ii) ha $A(n)$ igaz, akkor $A(n+1)$ is igaz.

Ekkor az $A(n)$ állítás minden $n$ természetes számra igaz.

**Bizonyítás.** Legyen

$$
S := \left\{ n \in \mathbb{N} \mid A(n) \ \ \text{igaz}\right\}.
$$

Ekkor $\underline{S \subset \mathbb{N}}$ és $S$ induktív halmaz, hiszen $0 \in S$, és ha $n \in S$, azaz $A(n)$ igaz, akkor $A(n+1)$ is igaz, ezért $n + 1 \in S$ teljesül következésképpen $S$ induktív halmaz. Mivel $\mathbb{N}$ a legszűkebb induktív halmaz, ezért az $\underline{\mathbb{N} \subset S}$ tartalmazás is fennáll, tehát $S=\mathbb{N}$. Ez pedig azt jelenti, hogy az állítás minden $n$ terészetes számra igaz.

## 2. A szuprémum elv.

**2. Tétel (A szuprérum elv).** Legyen $H \subset \mathbb{R}$ és tegyük fel, hogy 

i) $H \neq \emptyset$ és

ii) $H$ felülről korlátos.

Ekkor

$$
\exists \min \left\{K \in \mathbb{R}\mid K \ \ \text{felső korlátja} \ \ H \text{-nak}\right\}
$$

Legkisebb felső korlát.

**Bizonyítás.** Legyen

$$
A:=H \quad \text{és} \quad B:=\left\{K \in \mathbb{R}\mid K \ \ \text{felső korlátja} \ \ H \text{-nak}\right\}
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



## 4. A Cantor-tulajdonság.



## 5. Konvergens sorozatok határértékének egyértelműsége.



## 6. A konvergencia és a korlátosság kapcsolata.



## 7. Monoton részsorozatok létezésére vonatkozó tétel.



## 8. A sorozatokra vonatkozó közrefogási elv.



## 9. A határérték és a rendezés kapcsolata.



## 10. Műveletek nullsorozatokkal.



## 11. Konvergens sorozatok szorzatára vonatkozó tétel.



## 12. Konvergens sorozatok hányadosára vonatkozó tétel.



## 13. Monoton növekv® sorozatok határértékére vonatkozó tétel (véges és végtelen eset).



## 14. Az $a_n := \left(1 + \frac{1}{n}\right)^n \ \ (b \in \mathbb{N}^+)$ sorozat konvergenciája



## 15. Newton-féle iterációs eljárás $m$-edik gyökök keresésére.



## 16. A Cauchy-féle konvergenciakritérium sorozatokra.