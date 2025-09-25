const table = document.querySelector("#grades");

const handleTableClick = (e) => {
    if (e.target.matches("button")) {
        const row = e.target.closest("tr");
        row.remove();
    }
    if (e.target.matches("td.grade")) {
        e.target.classList.toggle("highlight", !e.target.classList.contains("highlight"))
    }
};

table.addEventListener("click", handleTableClick);