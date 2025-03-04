## 1. Mit tud mondani nullsorozatok összegéről?

Tegyük fel, hogy $\lim (a_n) = 0$ és $\lim (b_n) = 0$.

Ekkor
-  $(a_n + b_n)$ is nullsorozat

## 2. Mit tud mondani korlátos sorozat és nullsorozat szorzatáról?

Tegyük fel, hogy $\lim (a_n) = 0$

Ekkor
- ha $(c_n)$ korlátos sorozat, akkor $(c_n \cdot a_n)$ is nullsorozat

## 3. Mondjon példát olyan $(a_n), (b_n) : \mathbb{N} \to \mathbb{R}$ sorozatokra, amelyekre $\lim (a_n) = 0$, $\lim(b_n) = 0$ és a $\lim (a_n/b_n)$ határérték nem létezik.

## 4. Milyen állítást ismer konvergens sorozatok összegéről?

**(Műveletek konvergens sorozatokkal).** Tegyük fel, hogy az $(a_n)$ és a $(b_n)$ sorozat konvergens. Legyen

$$
\lim (a_n) = A \in \mathbb{R} \quad \text{és} \quad \lim (b_n) = B \in \mathbb{R}.
$$

Ekkor

- $(a_n + b_n)$ is konvergens és $\lim (a_n + b_n) = \lim (a_n) + \lim (b_n) = A + B$

## 5. Milyen állítást ismer konvergens sorozatok szorzatáról?

**(Műveletek konvergens sorozatokkal).** Tegyük fel, hogy az $(a_n)$ és a $(b_n)$ sorozat konvergens. Legyen

$$
\lim (a_n) = A \in \mathbb{R} \quad \text{és} \quad \lim (b_n) = B \in \mathbb{R}.
$$

Ekkor

- $(a_n \cdot b_n)$ is kovergens és $\lim (a_n \cdot b_n) = \lim (a_n) \cdot \lim (b_n) = A \cdot B$

## 6. Milyen állítást ismer konvergens sorozatok hányadosáról?

**(Műveletek konvergens sorozatokkal).** Tegyük fel, hogy az $(a_n)$ és a $(b_n)$ sorozat konvergens. Legyen

$$
\lim (a_n) = A \in \mathbb{R} \quad \text{és} \quad \lim (b_n) = B \in \mathbb{R}.
$$

Ekkor

ha $b_n \neq 0 (n \in \mathbb{N})$ és $\lim(b_n) \neq 0$, akkor

$$
\Big(\frac{a_n}{b_n}\Big) \quad \text{is konvergens, és} \quad \lim \Big(\frac{a_n}{b_n}\Big) = \frac{\lim (a_n)}{\lim (b_n)} = \frac{A}{B}.
$$

## 7. Milyen állítást tud mondani (tágabb értelemben) határértékkel bíró sorozatok összegéről?

**(A müveletek és a határérték kapcsolata).** Tegyük fel, hogy az $(a_n)$ és a $(b_n)$ sorozatnak van határértéke, és legyen

$$
\lim (a_n) =: A \in \overline{\mathbb{R}}, \quad \lim (b_n) =: B \in \overline{\mathbb{R}}.
$$

Ekkor

az $(a_n + b_n)$ összeg-sorozatnak is van határértéke, és 

$$
\lim (a_n + b_n) = \lim (a_n) + \lim (b_n) = A + B,
$$

feltéve, hogy az $A + B \in \overline{\mathbb{R}}$ összeg értelmezve van.

## 8. Milyen állítást tud mondani (tágabb értelemben) határértékkel bíró sorozatok szorzatáról?

**(A müveletek és a határérték kapcsolata).** Tegyük fel, hogy az $(a_n)$ és a $(b_n)$ sorozatnak van határértéke, és legyen

$$
\lim (a_n) =: A \in \overline{\mathbb{R}}, \quad \lim (b_n) =: B \in \overline{\mathbb{R}}.
$$

Ekkor

az $(a_n \cdot b_n)$ szorzat.sorozatnak is van határértéke, és

$$
\lim (a_n \cdot b_n) = \lim (a_n) \cdot \lim (b_n) = A \cdot B
$$

feltéve, hogy az $A \cdot B \in \overline{\mathbb{R}}$ szorzat értelmezve van

## 9. Milyen állítást tud mondani (tágabb értelemben) határértékkel bíró sorozatok hányadosáról?

**(A müveletek és a határérték kapcsolata).** Tegyük fel, hogy az $(a_n)$ és a $(b_n)$ sorozatnak van határértéke, és legyen

$$
\lim (a_n) =: A \in \overline{\mathbb{R}}, \quad \lim (b_n) =: B \in \overline{\mathbb{R}}.
$$

Ekkor

ha $b_n \neq 0 (n \in \mathbb{N})$, akkor az $\Big(\frac{a_n}{b_n}\Big)$ hányados-sorozatnak is van határértéke, és 

$$
\lim \Big(\frac{a_n}{b_n}\Big) = \frac{\lim (a_n)}{\lim (b_n)} = \frac{A}{B}
$$

feltéve, hogy az $\frac{A}{B} \in \overline{\mathbb{R}}$ hányados értelmezve van

## 10. Legyen $q \in \mathbb{R}$. Mit tud mondani a $(q^n)$ sorozatról határérték szempontjából?

Minden rögzített $q \in \mathbb{R}$ esetén a $(q^n)$ mértani sorozat határértékére a következők teljesülnek:

$\lim\limits_{n \to + \infty} q^n$:

- $= 0, \quad \text{ha} \ \ |q| < 1$,
- $= 1, \quad \text{ha} \ \ q = 1$,
- $= + \infty, \quad \text{ha} \ \ q > 1$,
- $\text{nem létezik,} \quad \text{ha} q \leq -1$.