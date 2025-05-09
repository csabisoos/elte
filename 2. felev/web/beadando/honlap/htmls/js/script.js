// Skip to content link helper
document.querySelectorAll('.skip-link').forEach(link => {
    link.addEventListener('click', e => {
      document.getElementById(link.hash.substring(1)).focus();
    });
});
// High-contrast toggle
function toggleContrast() {
  document.documentElement.classList.toggle('high-contrast');
}

function clearForm() {
    document.getElementById('urlap').reset();
}