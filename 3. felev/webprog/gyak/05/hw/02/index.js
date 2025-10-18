const form = document.querySelector("form");
const divContainer = document.querySelector(".container");

function getRangeInputs() {
  return Array.from(form.querySelectorAll('input[type="range"][data-consumption]'));
}

function calculateTotalLastYearConsumption(inputs) {
  return inputs.reduce((sum, inp) => sum + Number(inp.dataset.consumption || 0), 0);
}

function calculateCurrentConsumptions(inputs) {
  return inputs.map(inp => {
    const id = inp.id;
    const value = Number(inp.value);
    const max = Number(inp.max);
    const consumption = Number(inp.dataset.consumption || 0);
    const ci = (value / max) * consumption;
    return { id, ci };
  });
}

function renderDiagram(ciList, M) {
  ciList.forEach(({ id, ci }) => {
    const percent = M > 0 ? (ci / M) * 100 : 0;
    const label = divContainer.querySelector(`label[for="${id}"]`);
    if (label) {
      label.style.width = `${percent}%`;
    }
  });
}

function computeAndRender() {
  const inputs = getRangeInputs();

  const M = calculateTotalLastYearConsumption(inputs);
  console.log("M (last year's total consumption):", M);

  const ciList = calculateCurrentConsumptions(inputs);
  ciList.forEach(({ id, ci }) => {
    console.log(`ci (${id}):`, ci);
  });

  renderDiagram(ciList, M);
}

form.addEventListener("input", computeAndRender);

computeAndRender();