### 1. Hogyan értelmezi a függvényt?



### 2. Mit jelent az $f \in A \to B$ szimbólum?

Ez azt jelenti, hogy $f$ egy függvény, amely az $A$ halmaz elemeit képezi le a $B$ halmaz elemeire. Itt az "$\in$" jel arra utal, hogya $f$ egy függvény az $A \to B$ típusú függvények halmazában.

### 3. Mit jelent az $f:A \to B$ szimbólum?

Ez egy másik módja annak, hogy egy függvényt definiáljunk. Azt jelenti, hogya $f$ egy olyan függvény, amely az $A$ halmaz elemeit $B$-be képezi le. Ebben az esetben a "$:$" szimbólum a függvényt jelöli, és a nyíl mutatja, hogy az $A$ halmazból a $B$ halmazba történik a leképezés.

### 4. Definiálja a halmaznak függvény által létesített képét!

Legyen $f:A \to B$ egy adott függvény és $C \subset A$. Ekkor **a $C$ halmaz $f$ által létesített képén** az

$$
f[C]:= \left\lbrace f(x) \mid x \in C \right\rbrace = \left\lbrace y \in B \mid \exists x \in C:y=f(x) \right\rbrace \subset B
$$

halmazt értjük. Megállapodunk abban, hogy $f[\emptyset] = \emptyset$

### 5. Definiálja a halmaznak függvény által létesített ősképét!

Legyen $f:A \to B$ egy adott függvény és $D \subset B$. Ekkor **a D halmaz $f$ által létesített ősképén** az

$$
f^{-1}[D]:= \left\lbrace x \in D_f \mid f(x) \in D \right\rbrace \subset A
$$

halmazt értjük. Megállapodunk abban, hogy $f^{-1}[\emptyset]= \emptyset$

### 6. Mikor nevez egy függvényt invertálhatónak (vagy injektívnek)?

Akkor mondtuk, hogy egy $f:A \to B$ függvényt invertálható, ha az $A=D_f$ halmaz bármely két különböző pontjának a képe különböző. Ez pedig három különböző módon is le lehet írni:
- $f$ invertálható $\iff \forall x,t \in D_f$ esetén $x \neq t \implies f(x) \neq f(t)$
- $f$ invertálható $\iff$ $\forall x,t \in D_f$ esetén $f(x)=f(t) \implies x = t$,
- $f$ invertálható $\iff$ $\forall y \in R_f$-hez $\exists !x \in D_f:f(x)=y$.

### 7. Definiálja az inverz függvényt!

Ekkor az $f$ inverz függvényt (vagy röviden inverzét) így értelmezzük:

$$f^{-1}:R_f \ni y \to x, \quad \text{amelyre} \quad f(x) = y$$

### 8. Mi a definíciója az összetett függvénynek?

Tegyük fel, hogy $f:A \to B$ és $g:C \to D$ olyan függvények, amelyekre

$$
\left\lbrace x \in D_g \mid g(x) \in D_f \right\rbrace \neq \emptyset
$$

Ebben az esetben az $f$ (**külső**) és a $g$ (**belső**) függvénny **összetett függvényét** (vagy más szóval $f$ és $g$ **kompozícióját**) az $f \circ g$ szimbólummal jelöljük, és így értelmezzük:

$$
f \circ g : \left\lbrace x \in D_g \mid g(x) \in D_f\right\rbrace \to B, \quad \Big(f \circ g\Big)(x):=f\Big(g(x)\Big)
$$