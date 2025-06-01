# Régebbi vizsgakérdések

# 1. Függvények asszimptotikus viselkedése

## 1. Tegyük fel, hogy $g \colon \mathbb{N} \to \mathbb{R}$, asszimptotikusannemnegatív függvény!

### 1.a Adjuk meg az $O(g)$ és az $\Omega (g)$ függvényhalmazok definícióját!

**8.4 Definíció.** Az $O(g)$ függvényhalmaz olyan $f$ függvényekből áll, amiket elég nagy $n$ helyettesítési értékekre, megfelelő pozitív konstans szorzóval felülről becsül a $g$ függvény:

$$
O (g) = \left\{f \colon \exists d \in \mathbb{P}, \ \ \text{hogy elég nagy n-ekre} \ \ d * g(n) \geq f(n).\right\}
$$

$f \in O(g)$ esetén azt mondjuk, hogy $g$ aszimptotikus felső korlátja $f$-nek; szemléletesen: $f$ legfeljebb $g$-vel arányos.

**8.5 Definíció.** Az $\Omega (g)$ függvényhalmaz olyan $f$ függvényekből áll, amiket elég nagy $n$ helyettesítési értékre, megfelelő pozitív konstans szorzóval alulról becsül a $g$ függvény:

$$
\Omega (g) = \left\{f \colon \exists c \in \mathbb{P}, \ \ \text{hogy elég nagy n-ekre} \ \ c * g(n) \leq f(n).\right\}
$$

$f \in \Omega(g)$ esetén azt mondjuk, hogy $g$ aszimptotikus alsó korlátja $f$-nek; szemléletesen: $f$ legalább $g$-vel arányos.