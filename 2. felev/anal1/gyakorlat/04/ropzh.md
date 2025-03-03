## 1. Mit ért azon, hogy egy számsorozat konvergens?

Azt mondjuk, hogy az $(a_n): \mathbb{N} \to \mathbb{R}$ sorozat **konvergens**, ha  
$(*) \ \ \ \ \ \ \exists A \in \mathbb{R}$, hogy $\forall \epsilon > 0$ számhoz $\exists n_0 \in \mathbb{N}$, hogy $\forall n > n_0$ indexre $| a_n - A | < \epsilon$.

Ekkor az $A$ számot a sorozat **határértékének** nevezzük, és az alábbi szimbólumok valamelyikével jelöljük:

- $\lim (a_n) := A$,
- $\lim\limits_{n \to +\infty} a_n := A$,
- $a_n \to A \ \ (n \to +\infty)$.

**Megjegyzések**

1. Az $\epsilon > 0$ számot **hibakorlátnak**, $n_0$-at pedig **küszöbindexnek** nevezzük. Világos, hogy $n_0$ függ az $\epsilon$-tól, ezért szokás ezt az $\epsilon$-hoz tartozó küszöbindexnek is nevezni és $n_0(\epsilon)$-nal jelölni. Egy adott $\epsilon$ hibakorláthoz tartozó küszöbindex nem egyértlmű, ui. bármely $n_0$-nál nagyobb természetes szám is egy "jó" küszöbindex.

2. Megállapodunk abban, hogy $(*)$-ot így rövidítjuk:

$$
\exists A \in \mathbb{R}, \ \ \forall \epsilon > 0 \text{-hoz} \ \ \exists n_0 \in \mathbb{N}, \ \ \forall n > n_0 : | a_n - A | < \epsilon .
$$

## 2. Mit ért azon, hogy egy számsorozat divergens?

Az $(a_n)$ sorozatot **divergensnek** nevezzük, ha nem konvergens

## 3. Pozitív állítás formájában fogalmazza meg azt, hogy egy számsorozat divergens!

Ha egy sorozat divergens, akkor $(*)$ nem teljesül, amit pozitív állítás formájában azt jelenti, hogy

$$
\forall A \in \mathbb{R} \text{-hez} \ \ \exists \epsilon > 0, \ \ \forall n_0 \in \mathbb{N}\text{-hez} \ \ \exists n > n_0 : | a_n - A | \geq \epsilon .
$$

## 4. Milyen állítást ismer sorozatok esetén a konvergencia és a korlátosság kapcsolatáról?

Ha az $(a_n)$ sorozat konvergens, akkor korlátos is.

A korlátosság szükséges feltétele a konvergenciának.

## 5. Mit jelent az, hogy egy valós számsorozatnak $+ \infty$ a határértéke?

Azt mondjuk, hogy az $(a_n)$ sorozat **határértéke $+ \infty$** (vagy a sorozat **$+\infty$-hez tart**), ha  

$$\forall P > 0\text{-hoz} \ \ \exists n_0 \in \mathbb{N}, \forall n > n_0 : a_n > P.$$

Ezt az alábbi szimbólumok valamelyikével jelöljük:

- $\lim (a_n) = + \infty$,
- $\lim\limits_{n \to +\infty} a_n = + \infty$,
- $a_n \to + \infty$, ha $n \to + \infty$.

## 6. Mit jelent az, hogy egy valós számsorozatnak $- \infty$ a határértéke?

Azt mondjuk, hogy az $(a_n)$ sorozat **határértéke $- \infty$** (vagy a sorozat **$- \infty$-hez tart**), ha  

$$\forall P < 0\text{-hoz} \ \ \exists n_0 \in \mathbb{N}, \forall n > n_0 : a_n < P.
$$

Ezt az alábbi szimbólumok valamelyikével jelöljük:

- $\lim (a_n) = - \infty$,
- $\lim\limits_{n \to + \infty} a_n = - \infty$,
- $a_n \to - \infty$, ha $n \to + \infty$.

## 7. Környezetekkel fogalmazza meg azt, hogy az $(a_n)$ valós számsorozatnak (tágabb értelemben) van határértéke.

Azt mondjuk, hogy az $(a_n)$ sorozatnak **van határértéke**, ha

$$
\exists A \in \overline{\mathbb{R}}, \ \ \forall \epsilon > 0 \text{-hoz} \ \ \exists n_0 \in \mathbb{N}, \ \ \forall n > n_0 : a_n \in K_\epsilon(A).
$$

**(A tágabb értelemben vett határérték egyértelműsége).** Ha az $(a_n)$ sorozatnk van határértéke, akkor a fenti definícióban szereplő $A \in \overline{\mathbb{R}}$ elem egyértelműen létezik, ezt a sorozat **határértékének** nevezzük, és így jelöljük:

- $\lim (a_n) := A \in \overline{\mathbb{R}}$,
- $\lim\limits_{n \to + \infty} a_n := A \in \overline{\mathbb{R}}$,
- $a_n \to A \in \overline{\mathbb{R}}$, ha $n \to + \infty$

## 8. Hogyan deniálja egy sorozat részsorozatát?

Legyen $a = (a_n) : \mathbb{N} \to \mathbb{R}$ egy valós sorozat és $v = (v_n) : \mathbb{N} \to \mathbb{N}$ egy szigorúan monoton növekvő sorozat (röviden: $v$ egy **indexsorozata**). Ekkor az $a \circ v$ függvény is sorozat, amelyet az $(a_n)$ sorozat $v$ indexsorozat által meghatározott **részsorozatának** nevezzük. Az $a \circ v$ sorozat n-edik tagja:

$$
\Big(a \circ v \Big)(n) = a (v_n) = a_{v_n} \quad (n \in \mathbb{N}),
$$

így

$$
a \circ v = (a_{v_n}).
$$