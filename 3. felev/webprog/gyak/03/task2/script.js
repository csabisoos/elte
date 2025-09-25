const title = document.querySelector("#title");
const titleInput = document.querySelector("#titleInput");
const checkBox = document.querySelector("#highlight");
const lockButton = document.querySelector("#lockBtn");

titleInput.addEventListener("input", () => { // keydown, keyup
    const inputValue = titleInput.value;
    title.textContent = inputValue.trim().length == 0 ? "Jegyzeteim" : inputValue.trim();
});

checkBox.addEventListener("change", () => {
    /* if (e.target.checked) {
        title.classList.add("highlight");
    } else {
        title.classList.remove("highlight");    
    } */

    title.classList.toggle("highlight", checkBox.checked);
});

lockButton.addEventListener("click", () => {
    titleInput.hasAttribute("readonly") ? titleInput.removeAttribute("readonly") : titleInput.setAttribute("readonly", "");
});