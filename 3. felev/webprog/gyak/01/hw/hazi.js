//Az alábbi tömb hőmérsékleti méréseket tartalmaz.
const temperatures = [0, -1.5, 20, 30, -12.5, 1];

// Tömbfüggvények segítségével oldjuk meg az alábbi feladatokat:
// Írjuk ki a tömb összes elemét egymás alá!
temperatures.forEach((e) => console.log(e));

// Nézzük meg, hány napról van adatunk!
console.log(temperatures.length);

// Szűrjük ki azokat a napokat, amikor nem fagyott. Hány ilyen nap volt?
console.log(temperatures.filter((e) => e > 0).length)

// Hozzunk létre egy új tömböt, amiben minden elem után hozzárendeljük a "C" betűt!
const mapped = temperatures.map((e) => e + " C");

// Döntsük el, hogy volt-e olyan nap, amikor 40 foknál melegebb volt!
console.log(temperatures.some((e) => e > 40));

// Döntsük el, hogy igaz-e, hogy egyik nap sem fagyott!
console.log(temperatures.every((e) => e > 0));

// Keressük meg az első olyan napot, amikor 10 foknál melegebb volt!
console.log(temperatures.find((e) => e > 10));

// Mennyi volt a hőmérsékletek összege?
console.log(temperatures.reduce((acc, value) => acc + value));

// Rendezzük a tömböt!
console.log(temperatures.sort((a, b) => a > b));

// Induljunk ki az alábbi, objektumokat tartalmazó tömbből:
const friendDetails = [
  { name: "Barna", age: 23, favSport: "football", hasStrava: true },
  { name: "Matyi", age: 24, favSport: null, hasStrava: false },
  { name: "Eszter", age: 20, favSport: "running", hasStrava: true },
  { name: "Ádám", age: 23, favSport: "football", hasStrava: true },
];

// Tömbfüggvények segítségével oldjuk meg az alábbi feladatokat:
// Írjuk ki mindenki nevét és életkorát!
friendDetails.forEach(friend => { console.log(`${friend.name}, ${friend.age} éves`) });

// Gyűjtsük ki egy tömbbe az összes kedvenc sportot!
const favSports = [...new Set(friendDetails.map(friend => friend.favSport).filter(sport => sport !== null))];

// Gyűjtsük ki a Stravat használókat!
const stravaUsers = friendDetails.filter(friend => friend.hasStrava);

// Döntsük el, hogy van-e bárki, akinek nincs kedvenc sportja!
console.log(friendDetails.some(friend => friend.favSport === null));

// Igaz, hogy mindenkinek van Stravaja?
console.log(friendDetails.every(friend => friend.hasStrava));

// Keressük meg az első személyt, akinek a kedvenc sportja a "handball", jelezzük, ha nincs ilyen!
const handballFan = friendDetails.find(friend => friend.favSport === "handball");
if (handballFan) {
    console.log(`Az első kézilabda kedvelő: ${handballFan.name}, ${handballFan.age} éves.`);
} else {
    console.log("Nincs olyan barát, akinek a kedvenc sportja a kézilabda!")
}

// Bővítsétek ki a tömböt néhány új, hasonló struktúrával rendelkező objecttel. Tegyétek ezt meg a push és a spread operator használatával is!
console.log(friendDetails);
friendDetails.push(
  { name: "Lilla", age: 22, favSport: "tennis", hasStrava: false },
  { name: "Gábor", age: 25, favSport: "swimming", hasStrava: true }
);
console.log(friendDetails);

const newFriends = [
  { name: "Anna", age: 21, favSport: "handball", hasStrava: true },
  { name: "Dávid", age: 26, favSport: null, hasStrava: false }
];
const updatedFriends = [...friendDetails, ...newFriends];
console.log(updatedFriends);