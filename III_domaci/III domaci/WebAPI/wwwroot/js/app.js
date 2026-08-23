// ============================================================================
// app.js - inicijalizacija "Pocetne forme": dva dugmeta koja otvaraju
// Oglasi i Sve CV prijave, identicno PocetnaForma.cs iz Windows Forms app-a.
// ============================================================================

document.getElementById("iconOglasi").addEventListener("click", () => {
    Screens.openOglasi();
});

document.getElementById("iconCV").addEventListener("click", () => {
    Screens.openSveCVPrijave();
});

// sat na taskbar-u
function tickClock() {
    const now = new Date();
    const hh = String(now.getHours()).padStart(2, "0");
    const mm = String(now.getMinutes()).padStart(2, "0");
    document.getElementById("clock").textContent = `${hh}:${mm}`;
}
tickClock();
setInterval(tickClock, 15000);
