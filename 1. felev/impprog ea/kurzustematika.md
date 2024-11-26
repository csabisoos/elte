# Kurzustematika

## Imeratív programozás
A tárgy célja, hogy programozási nyelvekkel kapcsolatos fogalmakkal ismertesse meg a hallgatókat, melyek alapján a hallgatók a programozás során képesek lesznek tudatosan választani a nyelvi eszközök közül. A tárgyalt ismeretkör az imperatív, a procedurális és (kisebb részben) a moduláris programozási paradigmát fedi le, alapot teremtve későbbi, az objektum-orientált és konkurens programozási paradigmákat tárgyaló kurzusoknak. A tárgy utal a vele egy időben tartott *Funkcionális programozás* kurzusra is (és viszont). A tárgy szoros kapcsolatban áll a vele egy időben tartott *Programozás*, illetve (kisebb mértékben) a *Számítógépes rendszerek* kurzusokkal. Jelen tárgynak nem célja, hogy a hallgatókat programozni tanítsa -- ez a *Programozás* kurzus feladata --, de természetesen hozzájárul a hallgatók programozási készségeinek fejlődéséhez.  
Az előadásokon kötelező részt venni. A géptermi gyakorlatok a gyakorlatvezetővel segített önálló munkát tűzik ki célul. A félév során sem a gyakorlatokon, sem a géptermi zárthelyiken nem használunk integrált fejlesztői környezetet, csak programozói szövegszerkesztőket (pl. geany, notepad++, gedit, (g)vim, emacs) és parancssoros fordítást/futtatást. Ennek az a célja, hogy így a hallgatók megértik az eszközök működési elvét, tudatos eszközhasználókká válnak, és a későbbiekben az IDE-eszközök konfigurálására is képesek lesznek. A gyakorlatokon ösztönözzük a hallgatókat, hogy többféle operációs rendszeren (Windows, Linux) elsajátítsák a programkód megírásának, lefordításának és futtatásának technikáját.  

## Témakörök
Az alábbi témaköröket C és Python nyelveken tekintjük át.
- Programozási paradigmák és nyelvek, történelem (opcionális).
- Programozási nyelv célja (ember-gép és ember-ember kommunikáció) és hatása a programok minőségére, a szoftverfejlesztési folyamat minőségére.
- Programozási nyelv szabályrendszere: lexika, szintaxis, szemantika. Pragmatika.
- Programok felépítése: kifejezések, utasítások, alprogramok, modulok.
- Forráskód, tárgykód. Előfeldolgozás, fordítás, szerkesztés, futtatás. Interpretálás, REPL.
- C-preprocesszor, makrók.
- Fordítási egységek, függőségek, külön fordítás. Moduláris programozás.
- Kifejezések és kiértékelésük
    - lexikális elemek: literálok, azonosítók, operátorok, zárójelek stb.
    - szintaktika: arítás, fixitás;
    - szemantika: precedencia, bal- és jobbasszociativitás, lustaság/mohóság, mellékhatás, operandusok kiértékelési sorrendje, szekvenciapont.
- Utasítások és vezérlési szerkezetek
    - változódeklarációk
    - kifejezés-utasítás
    - értékadás
    - elágazások
    - ciklusok (átírás egyikből a másikba)
    - nem strukturált: break, continue, return, goto (mikor használjuk?)
- Deklarációk: hatókör, láthatóság. Változók élettartama.
- Alprogramok
    - programok strukturálása
    - végrehajtási verem, lokális változók automatikus tárolása
    - paraméterátadás
        - érték és cím szerinti paraméterátadás
        - érték-eredmény-szerinti paraméterátadás (opcionális)
    - paraméterek alapértelmezett értéke
    - globális változók, static local változók
    - blokkszerkezetes nyelv.
- Típusok
    - alaptípusok és ábrázolásuk
    - automatikus és explicit típuskonverziók
    - tömbök
    - listák, rendezett n-esek (opcionális)
    - rekordok / struktúrák
    - unionok (opcionális)
    - mutatók.
- Dinamikus memória kezelése. Élettartam.
- Szemétgyűjtés (opcionális).
- Láncolt adatszerkezetek, sekély és mély másolás/összehasonlítás.
- Pointer aritmetika. Tömbök és pointerek kapcsolata C-ben.
- Input-output, printf/scanf.

## Követelmények
Mind a rendszerezett elméleti tudást, mind a gyakorlati készségeket mérjük a tárgyból. Az előbbi szokott több problémát okozni, ezért is kötelező az előadásokon részt venni.  
Az átlagos hallgatótól 150 munkaórányi (azaz 150 x 45 perc) befektetést várunk el (ez felel meg az 5 ECTS kreditnek, ami a tárgy elvégzéséért jár). Ezt a 150 munkaórát a következő bontásban javasolt a tanulási folyamatra fordítani:  
- 65 munkaóra a heti 5 tanórán, 13 héten át;
- 52 munkaóra önálló tanulás (13 héten át heti 4);
- 14 munkaóra a készülés a zárthelyire (ismétlés);
- 3 munkaóra a zárthelyi megírása
- 16 munkaóra a beadandó elkészítése

### A tárgy teljesítésének előfeltételei
- Az előadás és a gyakorlat rendszeres látogatása legfeljebb 4-4 hiányzással. (A gyakorlatról való negyedik hiányzás esetén a gyakorlatvezető extra feladatot szabhat ki.)

### Számonkérés
A tárgy kombinált számonkérésű, azaz egyetlen (gyakorlati) jegy zárja. Ha valaki több, mint négyszer hiányzik akár az előadásról, akár a gyakorlatról, a jegyet megtagadjuk.  
A kurzus során különböző formákban pontokat (összesen legfeljebb 100-at) kell gyűjteni. A pontok eloszlása a következő:  
- Kis ZH-k a gyakorlatok elején: 20 pont (összesen 10x2)
- Zárthelyi: 50 pont
- Félév végi beadandó: 30 pont
**Mindhárom számonkérésen legalább 10-10-10 pontot el kell érni a kurzus teljesítéséhez!**  
A zh írása során semmilyen (pl. hozott) segédanyag vagy szoftvereszköz nem használható azon kívül, amit az oktatók biztosítanak. Nevezetesen, a programozási feladat megírása során használható lesz egy C referencia: https://en.cppreference.com/w/c (Linkek egy külső oldalra) (valamint a kiemelt csoportoknak egy Python referencia: https://docs.python.org/3.5/library/index.html (Linkek egy külső oldalra)). A kommunikáció minden formája tilos. A szabályok megszegése a jegy megtagadását vonja maga után.  
Az érdemjegy a következőképpen kerül meghatározásra:
- 0-50 pont: elégtelen
- 51-60 pont: elégséges
- 61-70 pont: közepes
- 71-85 pont: jó
- 86-100 pont: jeles

## Irodalom  
- Kozsik Tamás (és mások): Imperatív programozás. Jegyzetek az előadáshoz, 2018. Elérhető itt a Canvasben.
- Porkoláb Zoltán: Imperatív programozás. Jegyzetek az előadáshoz, 2018. http://gsd.web.elte.hu/imper/Linkek egy külső oldalra
- Kernighan – Ritchie: A C programozási nyelv, Műszaki Könyvkiadó. ISBN 9631605523
- Bjarne Stroustrup: A C++ programozási nyelv, Kiskapu Kiadó, 2001. ISBN: 9789639301191
- Mark Summerfield: Python 3 programozás. Kiskapu Kiadó, 2009. ISBN: 978 963 963 7641
- [C reference](https://en.cppreference.com/w/c) (zárthelyin is használható).
- [Python 3 Documentation](https://docs.python.org/3/)