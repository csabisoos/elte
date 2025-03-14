## 1. Adja meg az e számot definiáló sorozatot!

**Tétel (Az $e$ szám értelmezése).** Az

$$
a_n := \left(1+\frac{1}{n}\right)^n \quad \quad \left(n \in \mathbb{N}^+\right)
$$

sorozat szigorúan monoton növekvő és felülről korlátos, tehát konvergens. Legyen

$$
e := \lim\limits_{n \to + \infty} \left(1+ \frac{1}{n} \right)^n.
$$

## 2. Fogalmazza meg a sorozatokra vonatkozó közrefogási elvet!

**Tétel (A közrefogási elv).** Tegyük fel, hogy az $(a_n), (b_n)$ és $(c_n)$ sorozatokra teljesülnek a következők:

- $\exists N \in \mathbb{N}, \forall n > N : a_n \leq b_n \leq c_n$,
- az $(a_n)$ és a $(c_n)$ sorozatnak van határértéke, továbbá

$$
\lim (a_n) = \lim(c_n) = A \in \overline{\mathbb{R}}.
$$

Ekkor a $(b_n)$ sorozatnak is van határértéke és $\lim (b_n) = A$.

## 3. Milyen tételt ismer monoton sorozatok határértékével kapcsolatban?

**Tétel.** Minden $(a_n)$ monoton aorozatnak van határértéke.

1. 

- Ha $(a_n) \nearrow$ és felülről korlátos, akkor $(a_n)$ konvergens és

$$
\lim(a_n) = \sup\left\lbrace a_n \mid n \in \mathbb{N}\right\rbrace.
$$

- Ha $(a_n) \searrow$ és alulról korlátos, akkor $(a_n)$ konvergens és

$$
\lim(a_n) = \inf\left\lbrace a_n \mid n \in \mathbb{N} \right\rbrace .
$$

2. 

- Ha $(a_n) \nearrow$ és felülről nem korlátos, akkor $\lim(a_n) = + \infty$.
- Ha $(a_n) \searrow$ és alulról nem korlátos, akkor $\lim(a_n) = - \infty$.

## 4. Igaz-e az, hogy ha az $(a_n)$ és a $(b_n)$ sorozatoknak van határértéke és $a_n > b_n$ minden $n$-re, akkor $\lim(a_n) > \lim (b_n)$?



## 5. Fogalmazza meg egy valós szám m-edik gyökének a létezésére vonatkozó tételt, és adjon olyan eljárást, amivel ezek a számok nagy pontossággal előállíthatók.

**Tétel (Newton-féle iterációs eljárás m-edik gyökök keresésére).** Legyen $A>0$ valós szám és $m \geq 2$ természetes szám. Ekkor az

- $a_0>0$ tetszőleges valós szám,
- $a_{n+1} := \frac{1}{m} \left(\frac{A}{a_n^{m-1}} + (m-1) a_n\right) \quad \quad n \in \mathbb{N}$

rekurzióval értelmezett $(a_n)$ sorozat konvergens, és az $\alpha := \lim(a_n)$ határértékére igaz, hogy $\alpha > 0$ és

$$
\alpha^m=A.
$$

## 6. Hogyan szól a Bolzano-Weierstrass-féle kiválasztási tétel?

**Tétel (a Bolzano-Weierstrass-féle kiválasztás tétel).** Minden korlátos valós sorozatnak van konvergens részsorozata.

## 7. Mikor nevez egy sorozatot Cauchy-sorozatnak?

**Definíció.** Az $(a_n)$ valós sorozatot **Cauchy-sorozatnak** nevezzük, ha

$$
\forall \epsilon > 0 \text{-hoz} \ \ \exists n_0 \in \mathbb{N}, \ \ \forall m,n>n_0 : \left| a_n - a_m \right| < \epsilon .
$$

## 8. Mi a kapcsolat a konvergens sorozatok és a Cauchy-sorozatok között?

**Tétel (a cauchy-féle kovergenciakritérium).** Legyen $(a_n)$ egy valós sorozat. Ekkor

$$
(a_n) \ \ \text{konvergens} \ \ \iff \ \ (a_n) \ \ \text{Cauchy-sorozat}.
$$