// 1. Mi lesz a végeredmény az alábbi esetekben?
console.log("7" + 2 * 3);
console.log(10 - "4" + "5" + 5);
console.log("100" / "10" + 5);
console.log("5" + (3 - 1));

// 2. Oldjuk meg az alábbi feladatokat tömbsüggvények segítségével!
const items = [
  { id: "A", qty: 10, price: 2.5, active: true },
  { id: "B", qty: 5, price: 3.0, active: false },
  { id: "C", qty: 8, price: 4.0, active: true },
  { id: "D", qty: 3, price: 10.0, active: true },
  { id: "E", qty: 12, price: 1.25, active: false },
];

// adjuk meg az `active` elemek árának összegét!
const sum = items
  .filter((e) => e.active)
  .reduce((acc, curr) => (acc += curr.price), 0);
console.log(sum);

// adjuk meg a a minőségek legnagyobb értékét!
const maxQuality = items.reduce(
  (acc, curr) => (curr.qty > acc ? curr.qty : acc),
  items[0].qty
);
console.log(maxQuality);

// hozzunk létre egy új tömböt, ami {id, active, revenue} formátumú objecteket tartalmaz, ahol revenue = qty * price

// hozzunk létre egy tömböt az árakból, majd rendezzük őket növekvő sorrendben!
