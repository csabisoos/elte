## Két számsorozat metszete
### [Speci:](https://progalap.elte.hu/specifikacio/?data=H4sIAAAAAAAAE2VRS07DMBC9ysgru3Ibhd%2FCUpBAFIRalU1h0SSLtHHBgbgIh8qhqgS7cgHWbDlHbtKTMG5UGsALezzz3ps39oKYRzlRUzVJCjXTRJBTKcCuV6tR6Hc6MYfyJ450Twm4V3kjcz4XMJZay3miBYzAwiiMcR9A%2Bxj6PNKAawugueKQK7ziIdNU3bKg2z%2BrPgZDWiPdUgFK12WHDjaEUMU1gkW6OxVA16tXhT6cjbuZMS%2FUslhQLfNdN4skDpaDavuMMai%2BTK3hyNkvcvmPXIaZG55DtiHXRM9rtNVIaQjhFahav39mbnTXG2OLKo587SxzfDoW9C5vqrf%2B1cXJkG4m3brnf41j7605LLocCkXaa0WapmOsMwigoYbVlkc4KaQpDBHhgqRJkeCPWgGhz2GPwz6HIw6H%2BJQl5uoEVg4wgd52sBhldJJLJGP0JM3zQ0GEv4yX311iSNYwAgAA)

```
Be: x∈Z[1..], y∈Z[1..]
Ki: kim∈Z[1..]
Fv: bennevan: Z x Z[] x N -> L,
    bennevan(mi, miben, meddig)=ELDÖNT(
        i=1..meddig, mi=miben[i]
    )
Ef: (∀i∈[1..hossz(x)]:(nem bennevan(x[i], x, i-1))) és
    (∀j∈[1..hossz(y)]:(nem bennevan(y[j], y, j-1)))
    //∀i∈[1..n]:(∀j∈[1..n]: (i≠j -> x[i]≠x[j]))
Uf: (,kim)=KIVÁLOGAT(i=1..hossz(x), bennevan(x[i], y, hossz(y)), x[i])

/*
(db, y) = KIVÁLOGAT()
*/
```

### [Stuki:](https://progalap.elte.hu/stuki/?data=H4sIAAAAAAAAE61W7U7bMBR9lclIE9UilJaUtpn6gwKioLaUD7GJqj%2Bc2Gk9EhuSlFJQH2Bvsb97gb0Ab7InmZ3WNy6UoQjyp%2B7x9Tnn3ms7eUSMIBfZW9Va1Snble2qUylX6lUHWWgs7mh8JKf5JAwtlNCQ%2BiklOcIFoQlyH9HDXre9V67HapzxAWChGxxTnuaLxowQypEb4DChFkpnN1QuSOjthHKfygX%2BmIVErjkiknuAeKMnrjo1W8448dXZKf9eQcO5leNa0wjMNU0nryinOKWRDJcRKb1PJUQ8t2kjqXFy5KWc9QPQAGBFA3wVz%2B503P4RN5xOlhLwaDmDuEhKU6mRaQlOWMqEDECsWd7aGoskedi8L8k5T5DZ%2BdLW0Upq0gg%2B6Ce7h3YHjACwYgTMF8%2BbTPvn3Z3LbTnTi3mjFbS7WQm2D%2FZn1dR3QBmAFeXjuPptt34xfVWZC3GjMoFAzWes%2FJhMwKCyDzxaziA25IxttF6OBc%2Fa51HO6R3mm%2FcDNrRm1qKTs5JqZRpPaCvG3B%2BvNNToWUa%2BJgSKIa1DR7R1o0WGdYO10Hki3peykoFuaxkA3i0zGxBv6DZVhZQS343GPXZ2kV8QGlhR2p82um18VX5zK0Gg5jNWvveS26f3JPB6WM6cjmZ7zk5LDSfxKLi1d%2FrZ1oIQkM%2FXFElnTeGY28x6Iy7odf9Y%2BtMSAKxI9MRhFOJ98WbFIBB6na80D1%2BecdG63e62%2FJPQe1gcPs0Dhy8nLlKhtdfn5zD92owoIWz06el38ili6d%2BfvyImD6bab2suVEhWWgOf2hoAxSq7vnlscbRgu2gRAIrlv0ZEXz9uc9OsRAnNpW4iLyA%2FFaMYR6opj4jjSPF0MeOS4g7HDHuh%2BlJA8m8sxIvXWDIW08s8bGlHoW2KCZXfFeqOm1tADdehbIN7MJINebCyXrgXT38ibwDvugwsLUOG1sL28m%2FJ7YgRu8bsPyaNYj23s972fKg2Tiji7MNoUb4B2ggCWz6SZUP9Bup6l5gPmGdXYRRko5q9beNs5FMc1GtouOhGC%2FvXo1hMOFkSexVPfSBsqF9NTH2N0ZqP9SjIRsTxbVpRdOr77QPpjH3wglU9y5zlk2UlH40FFY3RgPgLrNFYzNp23W9U1YhS6pAdsyLz%2BT%2BlEjWzwAoAAA%3D%3D)

![Stuktogram](<Screenshot 2024-11-07 at 10.25.05.png>)

### Kód:
```cs

```