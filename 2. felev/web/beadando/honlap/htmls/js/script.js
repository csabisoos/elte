document.querySelectorAll('.skip-link').forEach(link => {
    link.addEventListener('click', e => {
      document.getElementById(link.hash.substring(1)).focus();
    });
});
function toggleContrast() {
  document.documentElement.classList.toggle('high-contrast');
}

function resetForm() {
  document.getElementById("urlap").reset();
}

document.addEventListener('DOMContentLoaded', () => {
  const navbarContainer = document.querySelector('.navbar .container');
  const hamburger       = document.querySelector('.hamburger');

  hamburger.addEventListener('click', () => {
    navbarContainer.classList.toggle('open');
  });
});