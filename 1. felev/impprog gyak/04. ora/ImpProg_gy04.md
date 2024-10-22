# 4. gyakorlat
# Aritmetikai és bit műveletek, operátorok

***Emlékeztető:***  
- Fordítás közben használd a **-W**, **-Wall**, **-Wextra**, **-pedantic** kapcsolókat!
- Az egyes feladatokat szervezzük ki saját alprogramba!
- Használjuk segítségnek a hivatalos dokumentációt is: [C reference](https://en.cppreference.com/w/c)

## Kötelező feladatok
1. Vizsgáld meg, mi a különbség a prefix ++ (`++i`) és a posztfix ++ (`i++`) operátorok között!
2. Egy ciklus segítségével olvass be pár betűt, és ha kisbetű, konvertáld nagybetűvé, ha nagybetű, akkor kisbetűvé! (Az eddig megismert `scanf()` mellé megnézhetjük a `getchar()` függvény működését is. )
   - Igyekezzünk hibabiztosra írni a kódot, nem karakter esetén, jelezzük a hibát a felhasználónak és kérjünk be új betűt!
   - A beolvasott karakterek mennyiségét többféle képpen szabályozhatjuk:
     - előre meghatározott számú karaktert olvasunk (n db)
     - külön megválasztott lezáró karakterig olvasunk (pl. bemeneten 0-t kapunk)
     - **haladó szint:** `EOF` használatával (linuxban: **Ctrl+D**; windowsban: **Ctrl+Z** (**Enter**) )
3. Olvass be két számot, és végezd el rajtuk az összes lehetséges aritmetikai műveletet!
4. Olvasd be egy kör sugarát, és számold ki a kör átmérőjét, kerületét és területét!
5. Olvass be egy dátumot pozitív egész számként (egybeirva!), majd írd ki valamilyen dátum formátumban (év. hónap. nap. / DD-MM-YYYY / ...)!
6. Állapítsd meg 2-2 koordináta-rendszerbeli pontról, hogy az általuk alkotott egyenesek merőlegesek-e egymásra!
7. Olvass be két számot egy-egy változóba, és csak aritmetikai műveletek segítségével cseréld meg őket!
8. Fordítsd meg egy szám bitjeit! Mi lesz az eredmény?

## Opcionális feladatok
1. Olvasd be egy egyenlő szárú háromszög oldalait, és számold ki a háromszög területét és kerületét!
2. Olvasd be egy téglalap oldalait, és számold ki a területét és a kerületét!
3. Olvass be két számot, és emeld az egyik számot a másik hatványra! Mindkét irányba végezd el a feladatot!

## Gyakorló feladatok
1. Döntsd el egy számról csak bitműveletek használatával, hogy páros vagy páratlan!
2. Olvass be két számot, és írasd ki a két szám között lévő összes prímszámot!
3. Fordítsd meg egy szám n-edik bitjét! Mi az eredmény?
4. Számítsd ki egy szám prímtényezős felbontását!
5. **Dátum v2** Olvassunk be egy tetszőleges természetes számot. Induljunk ki egy alap dátumból `n=0` esetén (pl.: 1800.01.01.). A kapott egész szám az ezóta eltelt napok számát jelentse. Írjuk ki a meghatározott dátumot formázva. Egyszerűsítés: tekinthejük az összes hónapot azonos méretűnek
   - **profi szint**: A hónapokat megfelelő hosszal tekintjük
   - **mester szint**: Figyelembe vesszük a szökőéveket is

## Python
- Mit tudunk Pythonban a listákról?
 > - 1-lists.py
```py
# empty list
list1 = []

# list of integers
list2 = [1, 2, 3]

# list with mixed datatypes
list3 = [1, "Hello", 3.4]

# nested list
list4 = ["mouse", [8, 4, 6], ['a']]

#Indexing

# Output: 1
print(list3[0])

# Output: Hello
print(list3[1])

# Output: 3.4
print(list3[2])

# Negativ indexes

# Output: 3.4
print(list3[-1])

# Output: Hello
print(list3[-2])

# Nested indexing

# Output: o
print(list4[0][1])    

# Output: 6
print(list4[1][2])

# Slicing

arr5 = ['a','l','m','a','f','a']
# elements 3rd to 5th : ['m', 'a', 'f']
print(arr5[2:5])

# elements 3rd to end : ['a', 'f', 'a']
print(arr5[3:])

# elements except the last two : ['a', 'l', 'm', 'a']
print(arr5[:-2])

# elements beginning to end
print(arr5[:])

# length of a list
print(len(arr5))
```
 > - 2-edit lists.py
```py
# mistake values
odd = [2, 4, 6, 8]

# change the 1st item    
odd[0] = 1            

# Output: [1, 4, 6, 8]
print(odd)

# change 2nd to 4th items
odd[1:4] = [3, 5, 7]  

# Output: [1, 3, 5, 7]
print(odd)

# Output: [1, 3, 5, 7, 9, 11, 13]
print(odd + [9, 11, 13])

# Output: ["re", "re", "re"]
print(["re"] * 3)

# Extending by assigning a list to an empty slice
odd[2:2] = [-1,-1,-1]
print(odd)

# Deleting by assigning an empty list to a slice
odd[2:5] = []
print(odd)

# Deleting with 'del' (works on slices, lists too)
del odd[2]
print(odd)
```
 > - 3-methods-lists.py
```py
import copy

arr = [5, 7, 2, 8, 3.4,]
#append() - Add an element to the end of the list
arr.append(23)
print(arr)

#extend() - Add all elements of a list to the another list
arr.extend([-1, -2, -2])
print(arr)

#insert() - Insert an item at the defined index
arr.insert(3,100)
print(arr)

#remove() - Removes an item from the list
arr.remove(3.4)
print(arr)

#pop() - Removes and returns an element at the given index
print(arr.pop(6))
print(arr)

#index() - Returns the index of the first matched item
print(arr.index(-2))
#Error: print(arr.index(6))

#count() - Returns the count of number of items passed as an argument
print(arr.count(-2))

#sort() - Sort items in a list in ascending order
arr.sort()
print(arr)

#reverse() - Reverse the order of items in the list
arr.reverse()
print("arr:", arr)

arrr = [[1,2,3], [4,5,6]]

print("Real deep copy")
#deepcopy() - Returns a recusively deep copy of the list
arr1 = copy.deepcopy(arrr)
arr1[0][0] = "really deep!"
print("arr:", arrr)
print("arr1:", arr1)

print("Deep copy")
#copy() - Returns a copy of the list
arr2 = arrr.copy()
arr2[1] = "deep"
arr2[0][0] = "really deep?"
print("arr:", arrr)
print("arr2:", arr2)

print("Shallow copy")
# shallow copy - really just a new name
arr3 = arrr
arr3[0] = "shallow"
print("arr:", arrr)
print("arr3:", arr3)

arr4 = arrr[:]
arr4[0] = "test"

#clear() - Removes all items from the list
arr2.clear()
arr3.clear()
```
 > - 4-list-comprehension.py
```py
pow2 = [2 ** x for x in range(10)]

# Equivalent with this:
pow2_ = []
for x in range(10):
   pow2_.append(2 ** x)

# Output: [1, 2, 4, 8, 16, 32, 64, 128, 256, 512]
print(pow2)
print(pow2_)

odd = [x for x in range(20) if x % 2 == 1]

print(odd)

str = [x+y for x in ['Python ','C '] 
              for y in ['Language','Programming']]

print(str)
```
- Csináljunk egy tömböt (Pythonban lista), amiben több típus is van, pl. `lista = [1, "2", ["lista", "a", "listában"]]`. Miért tudunk ilyet megcsinálni Pythonban? (És miért nem érdemes ilyet csinálni?)
- Mi a különbség a Pythonban a `list` és a `tuple` között? /gyors `tuple` áttekintés: https://www.w3schools.com/python/python_tuples.asp /
- A 3-7. C-s kötelező feladatokat írjuk meg Pythonban is. Ne használd a `min`, `max`, `sum` beépített függvényeket.
- Csináljunk egy halmazt (set), pl. `halmazom = {"Robin", "Galahad", "Lancelot"}`. Iteráljunk végig ezen a halmazon, és írjuk ki az elemeit. Figyeld meg milyen sorrendben íródnak ki az elemek. /halmazon végezhető műveletek egy gyors összefoglalója: https://www.w3schools.com/python/python_sets.asp/
- Duplikáljunk egy elemet a halmazban, pl. `halmazom = {"Robin", "Galahad", "Lancelot", "Lancelot"}`, és írjuk ki ezt a halmazt. Figyeld meg hány eleme van!
- Csináljunk két listát:<br> `questions = ['neved', 'küldetésed', 'kedvenc színed']`<br> `answers = ['Sir Lancelot', 'A szent kehely', 'Kék']`<br> Írjuk ki a kérdéseket és válaszokat a következő formában (példa):<br> Q: Mi a neved?<br> A: Sir Lancelot.<br> Mi lenne a kényelmesebb adatszerkezet a lista helyett az ilyen típusú adatok tárolására, és miért?
