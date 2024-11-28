# Programozás 2. beadandó
## Új őrség küldése a Kínai Nagy Falra
### Feladat
![Feladat](feladat.png)

### [Specifikáció](https://progalap.elte.hu/specifikacio/?data=H4sIAAAAAAAAE21S206DQBD9lZEnm6yVxWp0IyY1GmO8Jd4epDyAoG5btkbgQRsTfeuv%2BB3%2BiV%2Fimd1i0UgWZvYwZ8%2BZgalXPua3%2Bk7fJpWeGE95u7ki8zWbnQoqXBjrsko4jWS3W8QDc5EomjyV%2BX0%2BamATCweVL0kxGS2qBY3qcXv7oBPz3ABZCiRLeTswR1pRPXT5%2Fp2iZbkdGvr8KMlsh9L3OzZntLBZgdedgblC6dfsTYPoNMCcu4us9UjHMYUkLX9gCFfLKt4cHV5%2Fvh%2BfHfQvl3XIzYimPVBpKSRfkO50gwUfPUWSD20dxMAKyUVRYyqYm2KS%2FkvSTPoFrLhzWm6zFKS9%2Fnl%2F1%2Fkr7FBB3WlX2cH%2B002rusl%2B9VIPQbq4uTo56TtCls6%2FEipXg44nvCovq9JT0dTLkirBT0JGkVwHv1C0hWDnrCjaELQmSAa4IdYTtC5oExsE2cOf08xVsTBFmCuWbC2%2FebpkAZH8obtBQc0ewoJOCOK4NoWD2QAbQdZjB0xH907ZqrsQNHK%2BJco5nfEW5DM9SxUFiHY40A9EwHA9dDAGZZIix3iQPeVlPa48JV%2Fj129fCtiUZQMAAA%3D%3D)

```groovy
Be: n∈N, m∈N, lista∈N[1..m]
Sa: orsegek∈N[1..n], orsegszamok∈N[1..m], kul∈N[1..m], hiany∈N[1..db], db∈N
Ki: uj∈N
Ef: (1<=n és n<=100) és (1<=m és m<=n)
Uf: ∀i∈[1..m]: (orsegek[lista[i]] = 1) és
    orsegszamok = KIVÁLOGAT(i=1..n, orsegek[i] != 0, i).2 és
    kul[1] = orsegszamok[1] - 1 és
    ∀i∈[2..m]: (kul[i] = orsegszamok[i] - orsegszamok[i-1] - 1) és
    db = DARAB(i=1..m, kul[i]>1) és
    hiany = KIVÁLOGAT(i=1..m, kul[i]>1, kul[i]).2 és
    uj = SZUMMA(i=1..db, hiany[i]/2)
```

### Sablon
![SZUMMA sablon](szumma.png)
![KIVÁLOGATÁS sablon](kivalogat.png)
![DARAB sablon](darab.png)
![MÁSOL sablon](masol.png)

### Visszavezetés
```groovy
MÁSOL: ∀i∈[e..u]:(y[i-e+1]=f(i))
e..u     ~ 1..m
y[i-e+1] ~ falak[lista[i]]
f(i)     ~ 1

KIVÁLOGAT:
y    ~ orsegszamok
e..u ~ 1..n
T(i) ~ orsegek[i] != 0
f(i) ~ i

MÁSOL: ∀i∈[e..u]:(y[i-e+1]=f(i))
e..u     ~ 2..m
y[i-e+1] ~ kul[i]
f(i)     ~ ujlista[i] - ujlista[i-1] - 1

DARAB:
db   ~ db
e..u ~ 1..m
T(i) ~ kul[i] > 1

KIVÁLOGAT:
y    ~ hiany
e..u ~ 1..m
T(i) ~ kul[i]>1
f(i) ~ kul[i]

SZUMMA:
s    ~ uj
e..u ~ 1..db
f(i) ~ hiany[i]/2
```

### [Algoritmus]()


### Kód (C#)
```cs

```

### Bíró pontszám


### Saját tesztfájlok