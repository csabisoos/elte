const inputCircleNumber = document.querySelector("#circle-number");
const buttonStart = document.querySelector("#start");
const divContainer = document.querySelector("#container");
const divOutput = document.querySelector("#output");

// Application state

let canGuess = false;
let solution = [];
let series = [];

// ========= Utility functions =========

function random(a, b) {
  return Math.floor(Math.random() * (b - a + 1)) + a;
}

function toggleHighlight(node) {
  node.classList.toggle("highlight");
  node.addEventListener(
    "animationend",
    function () {
      node.classList.remove("highlight");
    },
    { once: true }
  );
}

function renderCircles(n) {
  divContainer.innerHTML = "";
  for (let i = 1; i <= n; i++) {
    const a = document.createElement("a");
    a.className = "circle";
    a.textContent = i;
    a.dataset.num = i;
    divContainer.appendChild(a);
  }
}

function generateSeries(nCircles) {
  series = Array.from({ length: 7 }, () => random(1, nCircles));
  console.log("series:", series);
}

function flashSeries(i = 0) {
  if (i >= series.length) {
    canGuess = true;
    divOutput.textContent = "Now, your turn...";
    return;
  }
  const num = series[i];
  const node = divContainer.querySelector(`[data-num="${num}"]`);
  if (node) toggleHighlight(node);

  setTimeout(() => flashSeries(i + 1), 1000);
}

function handleGuessClick(e) {
  const circle = e.target.closest(".circle");
  if (!circle || !canGuess) return;

  const num = Number(circle.dataset.num);
  toggleHighlight(circle);

  solution.push(num);

  const idx = solution.length - 1;
  const correctSoFar = solution[idx] === series[idx];

  if (!correctSoFar) {
    canGuess = false;
    divOutput.textContent = "Failed!";
    console.log("Result: failed", { series, solution });
    return;
  }

  if (solution.length === series.length) {
    canGuess = false;
    divOutput.textContent = "Nice job!";
    console.log("Result: success", { series, solution });
  } else {
    console.log(`Good so far: ${solution.join(", ")}`);
  }
}

function startGame() {
  canGuess = false;
  solution = [];

  const n = Number(inputCircleNumber.value);
  divOutput.textContent = "Flashing circles...";

  generateSeries(n);
  flashSeries(0);
}

inputCircleNumber.addEventListener("input", () => {
  renderCircles(Number(inputCircleNumber.value));
});

divContainer.addEventListener("click", handleGuessClick);
buttonStart.addEventListener("click", startGame);

renderCircles(Number(inputCircleNumber.value));