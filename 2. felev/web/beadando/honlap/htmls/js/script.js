function valtStilus() {
    document.body.classList.toggle('high-contrast');
}

document.addEventListener("DOMContentLoaded", () => {
    const style = document.createElement('style');
    style.innerHTML = `
    .high-contrast {
        background-color: black !important;
        color: white !important;
    }
    .high-contrast a {
        color: yellow !important;
    }
    `;
    document.head.appendChild(style);
});