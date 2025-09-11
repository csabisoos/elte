// if (true) {
//     let a = 5; // local scope
//     const b = 6; // local scope
//     // var bad = 7; // global scope
//     // var bad;
//     // var: nem ajánlott
// }

// 1. feladat
const firstNum = 10;
const secondNum = 6;
const result = firstNum + secondNum;
console.log(firstNum === secondNum);

// 2. feladat
if (firstNum > secondNum) {
    console.log("Nagyobb!");
} else if (firstNum === 20) {
    console.log("Pontosan 20");
} else {
    console.log("Nem jött be")
}

for (let i = 0; i < 5; i++) {
    console.log("Szám: ", i);
}

let i = 0;
while (i < 4) {
    // valami
    i++
}

// 3. feladat
const numArray = [1, 2, 3, 4, 5];
console.log(numArray);

const mixedArray = [1, 2, true, "kisutya", false, 3.14];
const matrix = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9]
];
console.log(matrix);
console.log(matrix.length);
console.log(mixedArray);

console.log(Array.isArray(mixedArray));

numArray.push(10); // mutable
// spread operator
const newArray = [-4, ...numArray, 12];
console.log(newArray);
console.log(numArray);

// for in - for of
for (let elem of newArray) {
    console.log("elem: ", elem)
}

for (let i in newArray) {
    console.log("index: ", i);
}

// 4. feladat
function addTwoNums(firstNum, secondNum) {
    return firstNum + secondNum;
}

const addTwoNumsNew = (firstNum, secondNum) => {
    return firstNum + secondNum
};

const addTwoNumsNewNew = (firstNum, secondNum) => firstNum + secondNum;

// lambda: (a, b) => a + b;

console.log(addTwoNums(5, 7));
console.log(addTwoNumsNew(5, 7));
console.log(addTwoNumsNewNew(5, 7));

const person = {
    name: "Barna",
    age: 23,
    greetTarditional: function() {
        console.log("Hello, ", this.name);
    },
    greetArray: () => {
        console.log("Hello, ", this.name); // globalis scope-on keresi a this.name-t
    },
};

person.greetTarditional();
person.greetArray();

//
a = 5;
function inc(num) {
    num++;
    console.log(num);
}

console.log(a);
inc(a);

// tömbfüggvények
const temperature = [0, -1.5, 20, 30, -12.5, 1];

/* const cb = (elem) => {
    console.log(elem);
}
temperature.forEach(cb); */
temperature.forEach((e) => console.log(e));

// b
console.log("Length: ", temperature.length);

// c
const filtered = temperature.filter((e) => e > 0);
console.log(filtered);

// some - every
const has = temperature.some((e) => e > 40);
const all = temperature.every((e) => e > 40);

// map
const mapped = temperature.map((e) => e + " C");
console.log(mapped);