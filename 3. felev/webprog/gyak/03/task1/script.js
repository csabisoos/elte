const paragraph = document.querySelector("p");

/*
paragraph.addEventListener("contextmenu", (e) => { // click, dblclick, contextmenu
    e.preventDefault(); // nem ugrik fel a context menu
    console.log(e);
    console.log("Típus: ", e.type);
    console.log("Egérgomb: ", e.button == 0 ? "bal" : "másik");
    console.log("Kattintás: ", e.clientX);
    console.log("Forrás: ", e.target);

    if (e.target.matches("a")) {
        e.preventDefault();
        console.log("log");
    }

    if (e.target.matches("span")) {
        console.log(e.target.innerText); // amit a user lát
        console.log(e.target.textContent); // az is amit a user nem lát (hidden is)
    }
});
*/

// event handlers
const handleParagraphClick = (e, name) => {
    e.preventDefault(); // nem ugrik fel a context menu
    console.log(e);
    console.log("Típus: ", e.type);
    console.log("Egérgomb: ", e.button == 0 ? "bal" : "másik");
    console.log("Kattintás: ", e.clientX);
    console.log("Forrás: ", e.target);

    if (e.target.matches("a")) {
        e.preventDefault();
        console.log("log");
    }

    if (e.target.matches("span")) {
        console.log(e.target.innerText); // amit a user lát
        console.log(e.target.textContent); // az is amit a user nem lát (hidden is)
    }
};

const handleSimpleClick = () => {
    console.log("Simple");
};

paragraph.addEventListener("click", (e) => handleParagraphClick(e, "sanyi"));