function navigateToPage(file, params = {}) {
    const query = new URLSearchParams();
    Object.entries(params).forEach(([key, value]) => {
        if (value !== undefined && value !== null && value !== "") {
            query.set(key, value);
        }
    });
    window.location.href = query.toString() ? `${file}?${query.toString()}` : file;
}

function getPageParams() {
    return new URLSearchParams(window.location.search);
}

async function bootPage() {
    const file = window.location.pathname.split("/").pop().toLowerCase() || "index.html";
    const q = getPageParams();

    try {
        switch (file) {
            case "index.html":
                break;

            case "oglasi.html":
                await Screens.openOglasi();
                break;

            case "dodaj-oglas.html":
                await Screens.openDodajOglas();
                break;

            case "izmeni-oglas.html": {
                const oglas = await api.oglas.get(Number(q.get("id")));
                await Screens.openIzmeniOglas(oglas);
                break;
            }

            case "posebni-podaci.html": {
                const oglas = await api.oglas.get(Number(q.get("oglasId")));
                await Screens.openPosebniPodaci(oglas);
                break;
            }

            case "posebni-praksa.html": {
                const oglas = await api.oglas.get(Number(q.get("oglasId")));
                await Screens.openPosebniPraksa(oglas);
                break;
            }

            case "posebni-privremeni.html": {
                const oglas = await api.oglas.get(Number(q.get("oglasId")));
                await Screens.openPosebniPrivremeni(oglas);
                break;
            }

            case "posebni-sezonski.html": {
                const oglas = await api.oglas.get(Number(q.get("oglasId")));
                await Screens.openPosebniSezonski(oglas);
                break;
            }

            case "cv-prijave.html": {
                const oglas = await api.oglas.get(Number(q.get("oglasId")));
                await Screens.openCVPrijaveZaOglas(oglas);
                break;
            }

            case "dodaj-cv.html": {
                const oglas = await api.oglas.get(Number(q.get("oglasId")));
                await Screens.openDodajCV(oglas);
                break;
            }

            case "izmeni-cv.html": {
                const [cv, oglas] = await Promise.all([
                    api.cv.get(Number(q.get("id"))),
                    api.oglas.get(Number(q.get("oglasId")))
                ]);
                await Screens.openIzmeniCV(cv, oglas);
                break;
            }

            case "odluka.html": {
                const cv = await api.cv.get(Number(q.get("cvId")));
                await Screens.openOdluka(cv);
                break;
            }

            case "intervjui.html": {
                const cv = await api.cv.get(Number(q.get("cvId")));
                await Screens.openIntervjui(cv);
                break;
            }

            case "dodaj-intervju.html": {
                const cv = await api.cv.get(Number(q.get("cvId")));
                await Screens.openDodajIntervju(cv);
                break;
            }

            case "izmeni-intervju.html": {
                const [intervju, cv] = await Promise.all([
                    api.intervju.get(Number(q.get("id"))),
                    api.cv.get(Number(q.get("cvId")))
                ]);
                await Screens.openIzmeniIntervju(intervju, cv);
                break;
            }

            case "testovi.html": {
                const cv = await api.cv.get(Number(q.get("cvId")));
                await Screens.openTestovi(cv);
                break;
            }

            case "dodaj-test.html": {
                const cv = await api.cv.get(Number(q.get("cvId")));
                await Screens.openDodajTest(cv);
                break;
            }

            case "izmeni-test.html": {
                const [test, cv] = await Promise.all([
                    api.test.get(Number(q.get("id"))),
                    api.cv.get(Number(q.get("cvId")))
                ]);
                await Screens.openIzmeniTest(test, cv);
                break;
            }

            case "svi-cv.html":
                await Screens.openSveCVPrijave();
                break;

            default:
                window.location.replace("index.html");
        }
    } catch (err) {
        console.error(err);
        await errorBox(err.message || "Doslo je do greske.");
    }
}

document.addEventListener("DOMContentLoaded", bootPage);

window.addEventListener("pageshow", (event) => {
    if (event.persisted) window.location.reload();
});
