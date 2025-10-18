const task1 = document.querySelector('#task1');
const task2 = document.querySelector('#task2');
const task3 = document.querySelector('#task3');
const task4 = document.querySelector('#task4');

const game = [
  "XXOO",
  "O OX",
  "OOO ",
];

const sameLength = game.every(row => row.length === game[0].length);
task1.textContent = String(sameLength);

const onlyXOInFirst = /^[XO]+$/.test(game[0]);
task2.textContent = String(onlyXOInFirst);

const flat = game.join('');
const countX = (flat.match(/X/g) || []).length;
const countO = (flat.match(/O/g) || []).length;
task3.textContent = `X / O = ${countX} / ${countO}`;

const rowWithThree = game.findIndex(r => r.includes('XXX') || r.includes('OOO'));
task4.textContent = String(rowWithThree);