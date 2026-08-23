// ============================================================================
// screens.js - svaka funkcija ovde odgovara jednoj formi iz Windows Forms
// aplikacije (Forme/*.cs). Nazivi i redosled provera su namerno zadrzani
// isti kao u originalnoj desktop aplikaciji.
// ============================================================================

const Screens = {};

// ---------------------------------------------------------------------------
// OGLASI (OglasiForm)
// ---------------------------------------------------------------------------

Screens.openOglasi = async function () {
    await openModal({
        title: "Oglasi",
        width: 920,
        height: 560,
        resizable: true,
        build: async (body, win) => {
            body.innerHTML = `
                <div class="toolbar">
                    <button class="winbtn primary" id="btnDodajOglas">Dodaj oglas</button>
                    <button class="winbtn" id="btnIzmeniOglas">Izmeni oglas</button>
                    <button class="winbtn danger" id="btnObrisiOglas">Obrisi oglas</button>
                    <button class="winbtn" id="btnCVPrijaveZaOglas">CV prijave za oglas</button>
                    <button class="winbtn" id="btnPosebniPodaci">Posebni podaci</button>
                    <button class="winbtn" id="btnOsvezi">Osvezi</button>
                </div>
                <div id="listHolder"></div>
            `;
            const listHolder = body.querySelector("#listHolder");

            const columns = [
                { header: "ID", render: (o) => String(o.oglasId) },
                { header: "Naziv pozicije", render: (o) => o.nazivPozicije || "" },
                { header: "Vrsta oglasa", render: (o) => prettyEnum(o.vrstaOglasa) },
                { header: "opis", render: (o) => o.opis || "" },
                { header: "zahtevi", render: (o) => o.zahtevi || "" },
                { header: "Min. plata", render: (o) => formatMoney(o.minPlata) },
                { header: "Max. plata", render: (o) => formatMoney(o.maxPlata) },
                { header: "datum objave", render: (o) => formatDate(o.datumObjave) },
                { header: "datum zatvaranja", render: (o) => o.datumZatvaranja ? formatDate(o.datumZatvaranja) : "-" },
                { header: "status", render: (o) => prettyEnum(o.status) }
            ];

            const lv = buildListView({ columns, rows: [], rowId: (o) => o.oglasId, emptyText: "Trenutno nema oglasa." });
            listHolder.appendChild(lv.el);

            async function refresh() {
                win.setStatus("Ucitavanje...");
                try {
                    const oglasi = await api.oglas.getAll();
                    lv.setRows(oglasi || []);
                    win.setStatus(`Ukupno oglasa: ${(oglasi || []).length}`);
                } catch (err) {
                    win.setStatus("Greska pri ucitavanju.");
                    await errorBox(err.message);
                }
            }

            body.querySelector("#btnDodajOglas").addEventListener("click", async () => {
                await Screens.openDodajOglas();
                await refresh();
            });

            body.querySelector("#btnIzmeniOglas").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) {
                    await alertBox("Izaberite oglas cije podatke zelite da izmenite!");
                    return;
                }
                const ob = await api.oglas.get(sel.oglasId);
                await Screens.openIzmeniOglas(ob);
                await refresh();
            });

            body.querySelector("#btnObrisiOglas").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) {
                    await alertBox("Izaberite oglas koji zelite da obrisete!");
                    return;
                }
                const ok = await confirmBox("Da li zelite da obrisete izabrani oglas?", "Pitanje");
                if (!ok) return;
                try {
                    await api.oglas.delete(sel.oglasId);
                    await alertBox("Brisanje oglasa je uspesno obavljeno!");
                    await refresh();
                } catch (err) {
                    await errorBox(err.message);
                }
            });

            body.querySelector("#btnCVPrijaveZaOglas").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) {
                    await alertBox("Izaberite oglas za koji zelite da vidite prijave!");
                    return;
                }
                const ob = await api.oglas.get(sel.oglasId);
                await Screens.openCVPrijaveZaOglas(ob);
                await refresh();
            });

            body.querySelector("#btnPosebniPodaci").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) {
                    await alertBox("Izaberite oglas.");
                    return;
                }
                const ob = await api.oglas.get(sel.oglasId);
                await Screens.openPosebniPodaci(ob);
                await refresh();
            });

            body.querySelector("#btnOsvezi").addEventListener("click", refresh);

            await refresh();
        }
    });
};

// --- zajednicko gradjenje forme za dodavanje/izmenu oglasa ----------------

function renderOglasFormFields(container, oglas) {
    const f = {};

    f.naziv = makeInput("text", "f_naziv", oglas?.nazivPozicije || "");
    f.vrsta = makeSelect("f_vrsta", Enums.vrstaOglasa, oglas?.vrstaOglasa || "STALNI");
    f.status = makeSelect("f_status", Enums.StatusOglasa, oglas?.status || "AKTIVAN");
    f.opis = makeTextarea("f_opis", oglas?.opis || "");
    f.zahtevi = makeTextarea("f_zahtevi", oglas?.zahtevi || "");
    f.minPlata = makeInput("number", "f_minplata", oglas?.minPlata ?? "");
    f.maxPlata = makeInput("number", "f_maxplata", oglas?.maxPlata ?? "");
    f.datumZatvaranjaChk = makeCheckbox("f_dzchk", !!oglas?.datumZatvaranja);
    f.datumZatvaranja = makeInput("date", "f_dz", toDateInputValue(oglas?.datumZatvaranja));
    f.datumZatvaranja.disabled = !f.datumZatvaranjaChk.checked;
    f.datumZatvaranjaChk.addEventListener("change", () => {
        f.datumZatvaranja.disabled = !f.datumZatvaranjaChk.checked;
    });

    const grid = el("div", { class: "form-grid" }, [
        el("label", { class: "field-label" }, "Naziv pozicije *"), f.naziv,
        el("label", { class: "field-label" }, "Vrsta oglasa *"), f.vrsta,
        el("label", { class: "field-label" }, "status *"), f.status,
        el("label", { class: "field-label" }, "Min. plata"), f.minPlata,
        el("label", { class: "field-label" }, "Max. plata"), f.maxPlata,
        el("label", { class: "field-label" }, "datum zatvaranja"),
        el("div", { class: "inline-fields" }, [f.datumZatvaranjaChk, f.datumZatvaranja]),
        el("label", { class: "field-label" }, "opis"), f.opis,
        el("label", { class: "field-label" }, "zahtevi"), f.zahtevi
    ]);
    container.appendChild(grid);

    // Praksa
    f.mentorIme = makeInput("text", "f_mentorIme", oglas?.mentorIme || "");
    f.mentorPrezime = makeInput("text", "f_mentorPrezime", oglas?.mentorPrezime || "");
    f.duzinaTrajanja = makeInput("number", "f_duzina", oglas?.duzinaTrajanja ?? 1);
    const gbPraksa = el("fieldset", { class: "groupbox hidden", id: "gbPraksa" }, [
        el("legend", {}, "Podaci o praksi"),
        el("div", { class: "form-grid" }, [
            el("label", { class: "field-label" }, "ime mentora *"), f.mentorIme,
            el("label", { class: "field-label" }, "prezime mentora *"), f.mentorPrezime,
            el("label", { class: "field-label" }, "Duzina trajanja (meseci) *"), f.duzinaTrajanja
        ])
    ]);

    // Privremeni
    f.projekat = makeInput("text", "f_projekat", oglas?.projekat || "");
    f.datumPocetka = makeInput("date", "f_datumPocetka", toDateInputValue(oglas?.datumPocetka) || new Date().toISOString().substring(0, 10));
    f.datumZavrsetka = makeInput("date", "f_datumZavrsetka", toDateInputValue(oglas?.datumZavrsetka) || new Date().toISOString().substring(0, 10));
    const gbPrivremeni = el("fieldset", { class: "groupbox hidden", id: "gbPrivremeni" }, [
        el("legend", {}, "Podaci o privremenom oglasu"),
        el("div", { class: "form-grid" }, [
            el("label", { class: "field-label" }, "projekat *"), f.projekat,
            el("label", { class: "field-label" }, "datum pocetka *"), f.datumPocetka,
            el("label", { class: "field-label" }, "datum zavrsetka *"), f.datumZavrsetka
        ])
    ]);

    // Sezonski
    f.sezona = makeInput("text", "f_sezona", oglas?.sezona || "");
    f.lokacija = makeInput("text", "f_lokacija", oglas?.lokacija || "");
    const gbSezonski = el("fieldset", { class: "groupbox hidden", id: "gbSezonski" }, [
        el("legend", {}, "Podaci o sezonskom oglasu"),
        el("div", { class: "form-grid" }, [
            el("label", { class: "field-label" }, "sezona *"), f.sezona,
            el("label", { class: "field-label" }, "lokacija *"), f.lokacija
        ])
    ]);

    container.appendChild(gbPraksa);
    container.appendChild(gbPrivremeni);
    container.appendChild(gbSezonski);

    function prikaziOdgovarajucaPolja(vrsta) {
        gbPraksa.classList.add("hidden");
        gbPrivremeni.classList.add("hidden");
        gbSezonski.classList.add("hidden");
        if (vrsta === "PRAKSA") gbPraksa.classList.remove("hidden");
        else if (vrsta === "PRIVREMENI") gbPrivremeni.classList.remove("hidden");
        else if (vrsta === "SEZONSKI") gbSezonski.classList.remove("hidden");
    }

    f.vrsta.addEventListener("change", () => prikaziOdgovarajucaPolja(f.vrsta.value));
    prikaziOdgovarajucaPolja(f.vrsta.value);

    return f;
}

function validateAndBuildOglas(f, existing) {
    if (!f.naziv.value.trim() || !f.vrsta.value || !f.status.value) {
        alertBox("Naziv pozicije, vrsta oglasa i status su obavezni.", "Nedostaju podaci", MsgIcon.WARN);
        return null;
    }

    const minPlata = f.minPlata.value === "" ? null : Number(f.minPlata.value);
    const maxPlata = f.maxPlata.value === "" ? null : Number(f.maxPlata.value);

    if (minPlata !== null && maxPlata !== null && minPlata > maxPlata) {
        alertBox(`Minimalna plata (${minPlata}) ne moze biti veca od maksimalne plate (${maxPlata}).`, "Neispravan unos", MsgIcon.WARN);
        return null;
    }

    const vrsta = f.vrsta.value;
    let extra = {};

    if (vrsta === "PRAKSA") {
        if (!f.mentorIme.value.trim() || !f.mentorPrezime.value.trim()) {
            alertBox("ime i prezime mentora su obavezni.", "Nedostaju podaci", MsgIcon.WARN);
            return null;
        }
        if (Number(f.duzinaTrajanja.value) <= 0) {
            alertBox("Duzina prakse mora biti veca od nule.", "Neispravan unos", MsgIcon.WARN);
            return null;
        }
        extra = {
            mentorIme: f.mentorIme.value.trim(),
            mentorPrezime: f.mentorPrezime.value.trim(),
            duzinaTrajanja: Number(f.duzinaTrajanja.value)
        };
    } else if (vrsta === "PRIVREMENI") {
        if (!f.projekat.value.trim()) {
            alertBox("Naziv projekta je obavezan.", "Nedostaju podaci", MsgIcon.WARN);
            return null;
        }
        if (f.datumPocetka.value > f.datumZavrsetka.value) {
            alertBox("datum pocetka ne moze biti posle datuma zavrsetka.", "Neispravan period", MsgIcon.WARN);
            return null;
        }
        extra = {
            projekat: f.projekat.value.trim(),
            datumPocetka: dateInputToIso(f.datumPocetka.value),
            datumZavrsetka: dateInputToIso(f.datumZavrsetka.value)
        };
    } else if (vrsta === "SEZONSKI") {
        if (!f.sezona.value.trim() || !f.lokacija.value.trim()) {
            alertBox("sezona i lokacija su obavezne.", "Nedostaju podaci", MsgIcon.WARN);
            return null;
        }
        extra = {
            sezona: f.sezona.value.trim(),
            lokacija: f.lokacija.value.trim()
        };
    }

    const datumObjave = existing ? existing.datumObjave : new Date().toISOString();
    const datumZatvaranja = f.datumZatvaranjaChk.checked ? dateInputToIso(f.datumZatvaranja.value) : null;

    if (datumZatvaranja && new Date(datumZatvaranja) < new Date(datumObjave.substring(0, 10) + "T00:00:00")) {
        alertBox("datum zatvaranja ne moze biti pre datuma objave.", "Greska", MsgIcon.WARN);
        return null;
    }

    const dto = {
        oglasId: existing ? existing.oglasId : 0,
        nazivPozicije: f.naziv.value.trim(),
        vrstaOglasa: vrsta,
        opis: f.opis.value.trim() || null,
        zahtevi: f.zahtevi.value.trim() || null,
        minPlata: minPlata,
        maxPlata: maxPlata,
        datumObjave: datumObjave,
        datumZatvaranja: datumZatvaranja,
        status: f.status.value,
        ...extra
    };

    return dto;
}

Screens.openDodajOglas = async function () {
    await openModal({
        title: "Dodavanje novog oglasa",
        width: 560,
        height: 620,
        resizable: true,
        build: (body, win) => {
            const form = el("div");
            const f = renderOglasFormFields(form, null);
            body.appendChild(form);

            const btnRow = el("div", { class: "btn-row" });
            const btnDodaj = el("button", { class: "winbtn primary" }, "Dodaj oglas");
            const btnOtkazi = el("button", { class: "winbtn" }, "Otkazi");
            btnRow.appendChild(btnDodaj);
            btnRow.appendChild(btnOtkazi);
            body.appendChild(btnRow);

            btnOtkazi.addEventListener("click", () => win.close());

            btnDodaj.addEventListener("click", async () => {
                const dto = validateAndBuildOglas(f, null);
                if (!dto) return;

                const ok = await confirmBox("Da li zelite da dodate novi oglas?");
                if (!ok) return;

                try {
                    if (dto.vrstaOglasa === "PRAKSA") await api.oglas.addPraksa(dto);
                    else if (dto.vrstaOglasa === "PRIVREMENI") await api.oglas.addPrivremeni(dto);
                    else if (dto.vrstaOglasa === "SEZONSKI") await api.oglas.addSezonski(dto);
                    else await api.oglas.addStalni(dto);

                    await alertBox("Uspesno ste dodali novi oglas!", "Uspesno");
                    win.close();
                } catch (err) {
                    await errorBox(err.message);
                }
            });
        }
    });
};

Screens.openIzmeniOglas = async function (oglasOsnovni) {
    await openModal({
        title: `Azuriranje oglasa ${oglasOsnovni.nazivPozicije?.toUpperCase() || ""}`,
        width: 560,
        height: 640,
        resizable: true,
        build: async (body, win) => {
            body.innerHTML = `<div class="listview-empty">Ucitavanje...</div>`;

            let oglas;
            try {
                oglas = await api.oglas.get(oglasOsnovni.oglasId);
            } catch (err) {
                body.innerHTML = "";
                await errorBox(err.message);
                win.close();
                return;
            }

            if (!oglas) {
                await alertBox("Oglas nije pronadjen.");
                win.close();
                return;
            }

            const staraVrsta = oglas.vrstaOglasa;

            body.innerHTML = "";
            const form = el("div");
            const f = renderOglasFormFields(form, oglas);
            body.appendChild(form);

            const btnRow = el("div", { class: "btn-row" });
            const btnIzmeni = el("button", { class: "winbtn primary" }, "Sacuvaj izmene");
            const btnOtkazi = el("button", { class: "winbtn" }, "Otkazi");
            btnRow.appendChild(btnIzmeni);
            btnRow.appendChild(btnOtkazi);
            body.appendChild(btnRow);

            btnOtkazi.addEventListener("click", () => win.close());

            btnIzmeni.addEventListener("click", async () => {
                const dto = validateAndBuildOglas(f, oglas);
                if (!dto) return;

                const ok = await confirmBox("Da li zelite da izvrsite izmenu oglasa?");
                if (!ok) return;

                try {
                    if (dto.vrstaOglasa === "PRAKSA") await api.oglas.editPraksa(dto, staraVrsta);
                    else if (dto.vrstaOglasa === "PRIVREMENI") await api.oglas.editPrivremeni(dto, staraVrsta);
                    else if (dto.vrstaOglasa === "SEZONSKI") await api.oglas.editSezonski(dto, staraVrsta);
                    else await api.oglas.editStalni(dto, staraVrsta);

                    await alertBox(`Uspesno ste izmenili oglas sa ID=${dto.oglasId}!`, "Uspesno");
                    win.close();
                } catch (err) {
                    await errorBox(err.message);
                }
            });
        }
    });
};

// ---------------------------------------------------------------------------
// POSEBNI PODACI (OglasPraksaForm / OglasPrivremeniForm / OglasSezonskiForm)
// ---------------------------------------------------------------------------

Screens.openPosebniPodaci = async function (oglas) {
    if (oglas.vrstaOglasa === "STALNI") {
        await alertBox("Oglas za stalni rad nema posebne podatke.");
        return;
    }
    if (oglas.vrstaOglasa === "PRAKSA") return Screens.openPosebniPraksa(oglas);
    if (oglas.vrstaOglasa === "PRIVREMENI") return Screens.openPosebniPrivremeni(oglas);
    if (oglas.vrstaOglasa === "SEZONSKI") return Screens.openPosebniSezonski(oglas);
};

Screens.openPosebniPraksa = async function (oglas) {
    await openModal({
        title: "Podaci o praksi",
        width: 440,
        build: async (body, win) => {
            let podaci = null;
            try {
                podaci = await api.oglasPraksa.get(oglas.oglasId);
            } catch { /* nema podataka */ }

            win.setTitle(podaci ? "Izmena podataka o praksi" : "Podaci o praksi nisu pronadjeni");

            if (!podaci) {
                body.innerHTML = `<div class="listview-empty">Podaci o praksi za ovaj oglas ne postoje.</div>`;
                body.appendChild(el("div", { class: "btn-row right" }, [
                    el("button", { class: "winbtn", onclick: () => win.close() }, "Zatvori")
                ]));
                return;
            }

            const mentorIme = makeInput("text", "pp_mi", podaci.mentorIme);
            const mentorPrezime = makeInput("text", "pp_mp", podaci.mentorPrezime);
            const duzina = makeInput("number", "pp_dt", podaci.duzinaTrajanja);

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "ime mentora *"), mentorIme,
                el("label", { class: "field-label" }, "prezime mentora *"), mentorPrezime,
                el("label", { class: "field-label" }, "Duzina trajanja (meseci) *"), duzina
            ]));

            const btnRow = el("div", { class: "btn-row" });
            const btnSacuvaj = el("button", { class: "winbtn primary" }, "Sacuvaj");
            const btnOtkazi = el("button", { class: "winbtn" }, "Otkazi");
            btnRow.appendChild(btnSacuvaj);
            btnRow.appendChild(btnOtkazi);
            body.appendChild(btnRow);

            btnOtkazi.addEventListener("click", () => win.close());

            btnSacuvaj.addEventListener("click", async () => {
                if (!mentorIme.value.trim() || !mentorPrezime.value.trim()) {
                    await alertBox("ime i prezime mentora su obavezni.", "Greska", MsgIcon.WARN);
                    return;
                }
                const ok = await confirmBox("Da li zelite da sacuvate oglas prakse?");
                if (!ok) return;
                try {
                    podaci.mentorIme = mentorIme.value.trim();
                    podaci.mentorPrezime = mentorPrezime.value.trim();
                    podaci.duzinaTrajanja = Number(duzina.value);
                    await api.oglasPraksa.edit(podaci);
                    await alertBox("Podaci su uspesno sacuvani.", "Uspeh");
                    win.close();
                } catch (err) {
                    await errorBox(err.message);
                }
            });
        }
    });
};

Screens.openPosebniPrivremeni = async function (oglas) {
    await openModal({
        title: "Podaci o privremenom oglasu",
        width: 460,
        build: async (body, win) => {
            let podaci = null;
            try {
                podaci = await api.oglasPrivremeni.get(oglas.oglasId);
            } catch { /* nema podataka */ }

            if (!podaci) {
                body.innerHTML = `<div class="listview-empty">Podaci o privremenom oglasu ne postoje.</div>`;
                body.appendChild(el("div", { class: "btn-row right" }, [
                    el("button", { class: "winbtn", onclick: () => win.close() }, "Zatvori")
                ]));
                return;
            }

            const projekat = makeInput("text", "pp_proj", podaci.projekat);
            const datumPocetka = makeInput("date", "pp_dp", toDateInputValue(podaci.datumPocetka));
            const datumZavrsetka = makeInput("date", "pp_dzv", toDateInputValue(podaci.datumZavrsetka));

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "projekat *"), projekat,
                el("label", { class: "field-label" }, "datum pocetka *"), datumPocetka,
                el("label", { class: "field-label" }, "datum zavrsetka *"), datumZavrsetka
            ]));

            const btnRow = el("div", { class: "btn-row" });
            const btnSacuvaj = el("button", { class: "winbtn primary" }, "Sacuvaj");
            const btnOtkazi = el("button", { class: "winbtn" }, "Otkazi");
            btnRow.appendChild(btnSacuvaj);
            btnRow.appendChild(btnOtkazi);
            body.appendChild(btnRow);

            btnOtkazi.addEventListener("click", () => win.close());

            btnSacuvaj.addEventListener("click", async () => {
                if (!projekat.value.trim()) {
                    await alertBox("ime projekta je obavezno.", "Greska", MsgIcon.WARN);
                    return;
                }
                if (datumPocetka.value > datumZavrsetka.value) {
                    await alertBox("datum pocetka mora biti pre datuma zavrsetka!", "Greska", MsgIcon.WARN);
                    return;
                }
                const ok = await confirmBox("Da li zelite da sacuvate privremeni oglas?");
                if (!ok) return;
                try {
                    podaci.projekat = projekat.value.trim();
                    podaci.datumPocetka = dateInputToIso(datumPocetka.value);
                    podaci.datumZavrsetka = dateInputToIso(datumZavrsetka.value);
                    await api.oglasPrivremeni.edit(podaci);
                    await alertBox("Podaci su uspesno sacuvani.", "Uspeh");
                    win.close();
                } catch (err) {
                    await errorBox(err.message);
                }
            });
        }
    });
};

Screens.openPosebniSezonski = async function (oglas) {
    await openModal({
        title: "Podaci o sezonskom oglasu",
        width: 440,
        build: async (body, win) => {
            let podaci = null;
            try {
                podaci = await api.oglasSezonski.get(oglas.oglasId);
            } catch { /* nema podataka */ }

            if (!podaci) {
                body.innerHTML = `<div class="listview-empty">Podaci o sezonskom oglasu ne postoje.</div>`;
                body.appendChild(el("div", { class: "btn-row right" }, [
                    el("button", { class: "winbtn", onclick: () => win.close() }, "Zatvori")
                ]));
                return;
            }

            const sezona = makeInput("text", "pp_sez", podaci.sezona);
            const lokacija = makeInput("text", "pp_lok", podaci.lokacija);

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "sezona *"), sezona,
                el("label", { class: "field-label" }, "lokacija *"), lokacija
            ]));

            const btnRow = el("div", { class: "btn-row" });
            const btnSacuvaj = el("button", { class: "winbtn primary" }, "Sacuvaj");
            const btnOtkazi = el("button", { class: "winbtn" }, "Otkazi");
            btnRow.appendChild(btnSacuvaj);
            btnRow.appendChild(btnOtkazi);
            body.appendChild(btnRow);

            btnOtkazi.addEventListener("click", () => win.close());

            btnSacuvaj.addEventListener("click", async () => {
                if (!sezona.value.trim() || !lokacija.value.trim()) {
                    await alertBox("sezona i lokacija su obavezni.", "Greska", MsgIcon.WARN);
                    return;
                }
                const ok = await confirmBox("Da li zelite da sacuvate sezonski oglas?");
                if (!ok) return;
                try {
                    podaci.sezona = sezona.value.trim();
                    podaci.lokacija = lokacija.value.trim();
                    await api.oglasSezonski.edit(podaci);
                    await alertBox("Podaci su uspesno sacuvani.", "Uspeh");
                    win.close();
                } catch (err) {
                    await errorBox(err.message);
                }
            });
        }
    });
};

// ---------------------------------------------------------------------------
// CV PRIJAVE ZA OGLAS (CVPrijaveZaOglasForm)
// ---------------------------------------------------------------------------

Screens.openCVPrijaveZaOglas = async function (oglas) {
    await openModal({
        title: `Oglas ${oglas.nazivPozicije?.toUpperCase() || ""}`,
        width: 860,
        height: 520,
        resizable: true,
        build: async (body, win) => {
            body.innerHTML = `
                <div class="toolbar">
                    <button class="winbtn primary" id="btnDodajCV">Dodaj CV</button>
                    <button class="winbtn" id="btnIzmeniCV">Izmeni CV</button>
                    <button class="winbtn danger" id="btnObrisiCV">Obrisi CV</button>
                    <button class="winbtn" id="btnIntervjui">Intervjui</button>
                    <button class="winbtn" id="btnTestovi">Testovi</button>
                    <button class="winbtn" id="btnOdluka">Odluka</button>
                </div>
                <div id="listHolder"></div>
            `;
            const listHolder = body.querySelector("#listHolder");

            const columns = [
                { header: "ID", render: (c) => String(c.cvId) },
                { header: "ime", render: (c) => c.ime || "" },
                { header: "prezime", render: (c) => c.prezime || "" },
                { header: "email", render: (c) => c.email || "" },
                { header: "telefon", render: (c) => c.telefon || "" },
                { header: "datum podnosenja", render: (c) => formatDate(c.datumPodnosenja) },
                { header: "status", render: (c) => prettyEnum(c.status) },
                { header: "Oglas ID", render: (c) => String(c.oglasID) }
            ];

            const lv = buildListView({ columns, rows: [], rowId: (c) => c.cvId, emptyText: "Nema CV prijava za ovaj oglas." });
            listHolder.appendChild(lv.el);

            async function refresh() {
                try {
                    const podaci = await api.cv.getForOglas(oglas.oglasId);
                    lv.setRows(podaci || []);
                    win.setStatus(`Broj prijava: ${(podaci || []).length}`);
                } catch (err) {
                    await errorBox(err.message);
                }
            }

            body.querySelector("#btnDodajCV").addEventListener("click", async () => {
                await Screens.openDodajCV(oglas);
                await refresh();
            });

            body.querySelector("#btnIzmeniCV").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) return alertBox("Izaberite CV prijavu cije podatke zelite da izmenite!");
                const cvb = await api.cv.get(sel.cvId);
                await Screens.openIzmeniCV(cvb, oglas);
                await refresh();
            });

            body.querySelector("#btnObrisiCV").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) return alertBox("Izaberite CV prijavu koju zelite da obrisete iz oglasa!");
                const ok = await confirmBox("Da li zelite da obrisete izabranu CV prijavu?");
                if (!ok) return;
                try {
                    await api.cv.delete(sel.cvId);
                    await alertBox("Brisanje CV prijave iz oglasa je uspesno obavljeno!");
                    await refresh();
                } catch (err) {
                    await errorBox(err.message);
                }
            });

            body.querySelector("#btnIntervjui").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) return alertBox("Izaberite CV za koji zelite da vidite intervjue!");
                const cvb = await api.cv.get(sel.cvId);
                await Screens.openIntervjui(cvb);
            });

            body.querySelector("#btnTestovi").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) return alertBox("Izaberite CV za koji zelite da vidite testove!");
                const cvb = await api.cv.get(sel.cvId);
                await Screens.openTestovi(cvb);
            });

            body.querySelector("#btnOdluka").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) return alertBox("Izaberite CV za koji zelite da vidite Odluku!");
                const cvb = await api.cv.get(sel.cvId);
                await Screens.openOdluka(cvb);
            });

            await refresh();
        }
    });
};

Screens.openDodajCV = async function (oglas) {
    await openModal({
        title: `Novi CV za oglas ${oglas.nazivPozicije || ""}`,
        width: 440,
        build: (body, win) => {
            const ime = makeInput("text", "cv_ime", "");
            const prezime = makeInput("text", "cv_prezime", "");
            const email = makeInput("email", "cv_email", "");
            const telefon = makeInput("text", "cv_telefon", "");

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "ime *"), ime,
                el("label", { class: "field-label" }, "prezime *"), prezime,
                el("label", { class: "field-label" }, "email *"), email,
                el("label", { class: "field-label" }, "telefon *"), telefon
            ]));
            body.appendChild(el("div", { class: "small-note" }, "datum podnosenja i status (PRIMLJEN) se postavljaju automatski."));

            const btnRow = el("div", { class: "btn-row" });
            const btnDodaj = el("button", { class: "winbtn primary" }, "Dodaj CV");
            const btnOtkazi = el("button", { class: "winbtn" }, "Otkazi");
            btnRow.appendChild(btnDodaj);
            btnRow.appendChild(btnOtkazi);
            body.appendChild(btnRow);

            btnOtkazi.addEventListener("click", () => win.close());

            btnDodaj.addEventListener("click", async () => {
                const ok = await confirmBox(`Da li zelite da dodate novi CV u oglas ${oglas.nazivPozicije}?`);
                if (!ok) return;

                if (!ime.value.trim() || !prezime.value.trim() || !email.value.trim() || !telefon.value.trim()) {
                    await alertBox("Sva polja su obavezna!", "Nedostaju podaci", MsgIcon.WARN);
                    return;
                }

                const dto = {
                    cvId: 0,
                    ime: ime.value.trim(),
                    prezime: prezime.value.trim(),
                    email: email.value.trim(),
                    telefon: telefon.value.trim(),
                    datumPodnosenja: new Date().toISOString(),
                    status: "PRIMLJEN"
                };

                try {
                    await api.cv.add(oglas.oglasId, dto);
                    await alertBox(`Uspesno ste dodali novi CV u oglas ${oglas.nazivPozicije}!`, "Uspesno");
                    win.close();
                } catch (err) {
                    await errorBox(err.message);
                }
            });
        }
    });
};

Screens.openIzmeniCV = async function (cv, oglas) {
    await openModal({
        title: `Izmena CV-a za oglas ${oglas.nazivPozicije || ""}`,
        width: 440,
        build: (body, win) => {
            const ime = makeInput("text", "cv_ime", cv.ime);
            const prezime = makeInput("text", "cv_prezime", cv.prezime);
            const email = makeInput("email", "cv_email", cv.email);
            const telefon = makeInput("text", "cv_telefon", cv.telefon);
            const datumPodnosenja = makeInput("date", "cv_dp", toDateInputValue(cv.datumPodnosenja));
            datumPodnosenja.disabled = true;
            const status = makeSelect("cv_status", Enums.CVStatus, cv.status);

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "ime *"), ime,
                el("label", { class: "field-label" }, "prezime *"), prezime,
                el("label", { class: "field-label" }, "email *"), email,
                el("label", { class: "field-label" }, "telefon *"), telefon,
                el("label", { class: "field-label" }, "datum podnosenja"), datumPodnosenja,
                el("label", { class: "field-label" }, "status *"), status
            ]));

            const btnRow = el("div", { class: "btn-row" });
            const btnIzmeni = el("button", { class: "winbtn primary" }, "Sacuvaj izmene");
            const btnOtkazi = el("button", { class: "winbtn" }, "Otkazi");
            btnRow.appendChild(btnIzmeni);
            btnRow.appendChild(btnOtkazi);
            body.appendChild(btnRow);

            btnOtkazi.addEventListener("click", () => win.close());

            btnIzmeni.addEventListener("click", async () => {
                const ok = await confirmBox(`Da li zelite da izmenite CV sa ID=${cv.cvId}?`);
                if (!ok) return;

                if (!ime.value.trim() || !prezime.value.trim() || !email.value.trim() || !telefon.value.trim() || !status.value) {
                    await alertBox("Sva polja su obavezna!", "Nedostaju podaci", MsgIcon.WARN);
                    return;
                }

                cv.ime = ime.value.trim();
                cv.prezime = prezime.value.trim();
                cv.email = email.value.trim();
                cv.telefon = telefon.value.trim();
                cv.status = status.value;

                try {
                    await api.cv.edit(cv);
                    await alertBox("Uspesno ste izmenili CV!", "Uspesno");
                    win.close();
                } catch (err) {
                    await errorBox(err.message);
                }
            });
        }
    });
};

// ---------------------------------------------------------------------------
// ODLUKA (Odluka_CV_Za_Oglas_Form)
// ---------------------------------------------------------------------------

Screens.openOdluka = async function (cv) {
    await openModal({
        title: `Odluka za CV: ${cv.ime} ${cv.prezime}`,
        width: 480,
        height: 520,
        resizable: true,
        build: async (body, win) => {
            let odluka = null;
            try {
                odluka = await api.odluka.getForCV(cv.cvId);
            } catch { odluka = null; }

            const odlukaPostoji = !!odluka;
            if (!odluka) {
                odluka = { odlukaId: 0, status: "NA_CEKANJU", datumDonosenjaOdluke: new Date().toISOString(), ponudjenaPlata: null, prihvatioPonudu: null, datumPocetkaRada: null, razlogOdbijanja: null };
            }

            const status = makeSelect("od_status", Enums.StatusOdluke, odluka.status);
            const ponudjenaPlata = makeInput("number", "od_plata", odluka.ponudjenaPlata ?? 0);
            const checkDa = makeCheckbox("od_da", odluka.prihvatioPonudu === true);
            const checkNe = makeCheckbox("od_ne", odluka.prihvatioPonudu === false);
            const datumPocetkaChk = makeCheckbox("od_dprchk", !!odluka.datumPocetkaRada);
            const datumPocetka = makeInput("date", "od_dpr", toDateInputValue(odluka.datumPocetkaRada));
            const razlog = makeTextarea("od_razlog", odluka.razlogOdbijanja || "");

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "status odluke *"), status,
                el("label", { class: "field-label" }, "Ponudjena plata"), ponudjenaPlata,
                el("label", { class: "field-label" }, "Prihvatio ponudu"),
                el("div", { class: "inline-fields" }, [
                    el("span", { class: "checkline" }, [checkDa, "Da"]),
                    el("span", { class: "checkline" }, [checkNe, "Ne"])
                ]),
                el("label", { class: "field-label" }, "datum pocetka rada"),
                el("div", { class: "inline-fields" }, [datumPocetkaChk, datumPocetka]),
                el("label", { class: "field-label" }, "Razlog odbijanja"), razlog
            ]));

            const btnRow = el("div", { class: "btn-row" });
            const btnSacuvaj = el("button", { class: "winbtn primary" }, odlukaPostoji ? "Sacuvaj izmene" : "Sacuvaj odluku");
            const btnOtkazi = el("button", { class: "winbtn" }, "Otkazi");
            btnRow.appendChild(btnSacuvaj);
            btnRow.appendChild(btnOtkazi);
            body.appendChild(btnRow);

            function azurirajPrikazPolja() {
                const st = status.value;
                const izabran = st === "IZABRAN";
                const odbijen = st === "ODBIJEN";
                ponudjenaPlata.disabled = !izabran;
                checkDa.disabled = !izabran;
                checkNe.disabled = !izabran;
                datumPocetkaChk.disabled = !(izabran && checkDa.checked);
                datumPocetka.disabled = !(izabran && checkDa.checked) || !datumPocetkaChk.checked;
                razlog.disabled = !(odbijen || (izabran && checkNe.checked));
            }

            checkDa.addEventListener("change", () => {
                if (checkDa.checked) checkNe.checked = false;
                azurirajPrikazPolja();
            });
            checkNe.addEventListener("change", () => {
                if (checkNe.checked) checkDa.checked = false;
                azurirajPrikazPolja();
            });
            datumPocetkaChk.addEventListener("change", () => {
                datumPocetka.disabled = !datumPocetkaChk.checked;
            });
            status.addEventListener("change", azurirajPrikazPolja);
            azurirajPrikazPolja();

            btnOtkazi.addEventListener("click", () => win.close());

            btnSacuvaj.addEventListener("click", async () => {
                const st = status.value;
                if (!st) {
                    await alertBox("Izaberite status odluke.", "Nedostaju podaci", MsgIcon.WARN);
                    return;
                }

                odluka.status = st;

                if (st === "IZABRAN") {
                    if (Number(ponudjenaPlata.value) <= 0) {
                        await alertBox("Ponudjena plata mora biti veca od nule.", "Neispravan unos", MsgIcon.WARN);
                        return;
                    }
                    if (!checkDa.checked && !checkNe.checked) {
                        await alertBox("Oznacite da li je ponuda prihvacena.", "Nedostaju podaci", MsgIcon.WARN);
                        return;
                    }
                    odluka.ponudjenaPlata = Number(ponudjenaPlata.value);

                    if (checkDa.checked) {
                        if (!datumPocetkaChk.checked) {
                            await alertBox("Unesite datum pocetka rada.", "Nedostaju podaci", MsgIcon.WARN);
                            return;
                        }
                        const dpr = dateInputToIso(datumPocetka.value);
                        if (new Date(dpr) < new Date(odluka.datumDonosenjaOdluke.substring(0, 10) + "T00:00:00")) {
                            await alertBox("datum pocetka rada ne moze biti pre datuma donosenja odluke.", "Neispravan datum", MsgIcon.WARN);
                            return;
                        }
                        odluka.prihvatioPonudu = true;
                        odluka.datumPocetkaRada = dpr;
                        odluka.razlogOdbijanja = null;
                    } else {
                        if (!razlog.value.trim()) {
                            await alertBox("Unesite razlog odbijanja ponude.", "Nedostaju podaci", MsgIcon.WARN);
                            return;
                        }
                        odluka.prihvatioPonudu = false;
                        odluka.datumPocetkaRada = null;
                        odluka.razlogOdbijanja = razlog.value.trim();
                    }
                } else {
                    odluka.ponudjenaPlata = null;
                    odluka.prihvatioPonudu = null;
                    odluka.datumPocetkaRada = null;

                    if (st === "ODBIJEN") {
                        if (!razlog.value.trim()) {
                            await alertBox("Unesite razlog odbijanja kandidata.", "Nedostaju podaci", MsgIcon.WARN);
                            return;
                        }
                        odluka.razlogOdbijanja = razlog.value.trim();
                    } else {
                        odluka.razlogOdbijanja = null;
                    }
                }

                const poruka = odlukaPostoji ? "Da li zelite da sacuvate izmene odluke?" : "Da li zelite da dodate odluku za izabrani CV?";
                const ok = await confirmBox(poruka, "Potvrda");
                if (!ok) return;

                try {
                    if (odlukaPostoji) {
                        await api.odluka.edit(odluka);
                    } else {
                        await api.odluka.add(cv.cvId, odluka);
                    }
                    await alertBox("Odluka je uspesno sacuvana.", "Uspesno");
                    win.close();
                } catch (err) {
                    await errorBox(err.message);
                }
            });
        }
    });
};

// ---------------------------------------------------------------------------
// INTERVJUI (IntervjuiForm)
// ---------------------------------------------------------------------------

Screens.openIntervjui = async function (cv) {
    await openModal({
        title: `Intervjui za CV: ${cv.ime} ${cv.prezime}`,
        width: 860,
        height: 500,
        resizable: true,
        build: async (body, win) => {
            body.innerHTML = `
                <div class="toolbar">
                    <button class="winbtn primary" id="btnDodaj">Dodaj intervju</button>
                    <button class="winbtn" id="btnIzmeni">Izmeni intervju</button>
                    <button class="winbtn danger" id="btnObrisi">Obrisi intervju</button>
                </div>
                <div id="listHolder"></div>
            `;
            const listHolder = body.querySelector("#listHolder");

            const columns = [
                { header: "ID", render: (i) => String(i.intervjuId) },
                { header: "datum", render: (i) => formatDate(i.datum) },
                { header: "vreme", render: (i) => formatTime(i.vreme) },
                { header: "tip", render: (i) => prettyEnum(i.tip) },
                { header: "lokacija", render: (i) => i.lokacija || "" },
                { header: "ime zaposlenog", render: (i) => i.zaposleniIme || "" },
                { header: "prezime zaposlenog", render: (i) => i.zaposleniPrezime || "" },
                { header: "ocena", render: (i) => String(i.ocena) },
                { header: "napomene", render: (i) => i.napomene || "" }
            ];

            const lv = buildListView({ columns, rows: [], rowId: (i) => i.intervjuId, emptyText: "Nema intervjua za ovaj CV." });
            listHolder.appendChild(lv.el);

            async function refresh() {
                try {
                    const podaci = await api.intervju.getForCV(cv.cvId);
                    lv.setRows(podaci || []);
                } catch (err) {
                    await errorBox(err.message);
                }
            }

            body.querySelector("#btnDodaj").addEventListener("click", async () => {
                await Screens.openDodajIntervju(cv);
                await refresh();
            });

            body.querySelector("#btnIzmeni").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) return alertBox("Izaberite intervju koji zelite da menjate!");
                const ib = await api.intervju.get(sel.intervjuId);
                await Screens.openIzmeniIntervju(ib, cv);
                await refresh();
            });

            body.querySelector("#btnObrisi").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) return alertBox("Izaberite intervju koji zelite da obrisete iz CV-ja!");
                const ok = await confirmBox("Da li zelite da obrisete izabrani intervju?");
                if (!ok) return;
                try {
                    await api.intervju.delete(sel.intervjuId);
                    await alertBox("Brisanje intervjua iz CV-ja je uspesno obavljeno!");
                    await refresh();
                } catch (err) {
                    await errorBox(err.message);
                }
            });

            await refresh();
        }
    });
};

Screens.openDodajIntervju = async function (cv) {
    await openModal({
        title: "Novi intervju",
        width: 460,
        height: 520,
        resizable: true,
        build: (body, win) => {
            const today = new Date().toISOString().substring(0, 10);
            const datum = makeInput("date", "iv_datum", today);
            const vreme = makeInput("time", "iv_vreme", "09:00");
            const tip = makeSelect("iv_tip", Enums.TipIntervjua, "LICNI");
            const lokacija = makeInput("text", "iv_lok", "");
            const imeZap = makeInput("text", "iv_ime", "");
            const prezimeZap = makeInput("text", "iv_prezime", "");
            const ocena = makeInput("number", "iv_ocena", 5);
            ocena.min = 1; ocena.max = 10;
            const napomene = makeTextarea("iv_nap", "");

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "datum *"), datum,
                el("label", { class: "field-label" }, "vreme *"), vreme,
                el("label", { class: "field-label" }, "tip intervjua *"), tip,
                el("label", { class: "field-label" }, "lokacija *"), lokacija,
                el("label", { class: "field-label" }, "ime zaposlenog *"), imeZap,
                el("label", { class: "field-label" }, "prezime zaposlenog *"), prezimeZap,
                el("label", { class: "field-label" }, "ocena (1-10) *"), ocena,
                el("label", { class: "field-label" }, "napomene"), napomene
            ]));

            const btnRow = el("div", { class: "btn-row" });
            const btnDodaj = el("button", { class: "winbtn primary" }, "Dodaj intervju");
            const btnOtkazi = el("button", { class: "winbtn" }, "Otkazi");
            btnRow.appendChild(btnDodaj);
            btnRow.appendChild(btnOtkazi);
            body.appendChild(btnRow);

            btnOtkazi.addEventListener("click", () => win.close());

            btnDodaj.addEventListener("click", async () => {
                const ok = await confirmBox("Da li zelite da dodate novi Intervju u CV?");
                if (!ok) return;

                if (!lokacija.value.trim() || !imeZap.value.trim() || !prezimeZap.value.trim()) {
                    await alertBox("lokacija, ime zaposlenog i prezime zaposlenog su obavezni!", "Nedostaju podaci", MsgIcon.WARN);
                    return;
                }
                if (Number(ocena.value) < 1 || Number(ocena.value) > 10) {
                    await alertBox("ocena mora biti u opsegu od 1 do 10.", "Greska", MsgIcon.WARN);
                    return;
                }

                const dto = {
                    intervjuId: 0,
                    datum: dateInputToIso(datum.value),
                    vreme: timeInputToIso(vreme.value, datum.value),
                    tip: tip.value,
                    lokacija: lokacija.value.trim(),
                    zaposleniIme: imeZap.value.trim(),
                    zaposleniPrezime: prezimeZap.value.trim(),
                    ocena: Number(ocena.value),
                    napomene: napomene.value.trim()
                };

                try {
                    await api.intervju.add(cv.cvId, dto);
                    await alertBox("Uspesno ste dodali novi intervju u CV!", "Uspesno");
                    win.close();
                } catch (err) {
                    await errorBox(err.message);
                }
            });
        }
    });
};

Screens.openIzmeniIntervju = async function (intervju, cv) {
    await openModal({
        title: `Izmena intervjua za CV sa ID = ${cv.cvId}`,
        width: 460,
        height: 520,
        resizable: true,
        build: (body, win) => {
            const datum = makeInput("date", "iv_datum", toDateInputValue(intervju.datum));
            const vreme = makeInput("time", "iv_vreme", toTimeInputValue(intervju.vreme));
            const tip = makeSelect("iv_tip", Enums.TipIntervjua, intervju.tip);
            const lokacija = makeInput("text", "iv_lok", intervju.lokacija);
            const imeZap = makeInput("text", "iv_ime", intervju.zaposleniIme);
            const prezimeZap = makeInput("text", "iv_prezime", intervju.zaposleniPrezime);
            const ocena = makeInput("number", "iv_ocena", intervju.ocena);
            ocena.min = 1; ocena.max = 10;
            const napomene = makeTextarea("iv_nap", intervju.napomene);

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "datum *"), datum,
                el("label", { class: "field-label" }, "vreme *"), vreme,
                el("label", { class: "field-label" }, "tip intervjua *"), tip,
                el("label", { class: "field-label" }, "lokacija *"), lokacija,
                el("label", { class: "field-label" }, "ime zaposlenog *"), imeZap,
                el("label", { class: "field-label" }, "prezime zaposlenog *"), prezimeZap,
                el("label", { class: "field-label" }, "ocena (1-10) *"), ocena,
                el("label", { class: "field-label" }, "napomene"), napomene
            ]));

            const btnRow = el("div", { class: "btn-row" });
            const btnIzmeni = el("button", { class: "winbtn primary" }, "Sacuvaj izmene");
            const btnOtkazi = el("button", { class: "winbtn" }, "Otkazi");
            btnRow.appendChild(btnIzmeni);
            btnRow.appendChild(btnOtkazi);
            body.appendChild(btnRow);

            btnOtkazi.addEventListener("click", () => win.close());

            btnIzmeni.addEventListener("click", async () => {
                const ok = await confirmBox(`Da li zelite da izmenite intervju sa ID=${intervju.intervjuId}?`);
                if (!ok) return;

                if (!lokacija.value.trim() || !imeZap.value.trim() || !prezimeZap.value.trim()) {
                    await alertBox("lokacija, ime zaposlenog i prezime zaposlenog su obavezni!", "Nedostaju podaci", MsgIcon.WARN);
                    return;
                }
                if (Number(ocena.value) < 1 || Number(ocena.value) > 10) {
                    await alertBox("ocena mora biti u opsegu od 1 do 10.", "Greska", MsgIcon.WARN);
                    return;
                }

                intervju.datum = dateInputToIso(datum.value);
                intervju.vreme = timeInputToIso(vreme.value, datum.value);
                intervju.tip = tip.value;
                intervju.lokacija = lokacija.value.trim();
                intervju.zaposleniIme = imeZap.value.trim();
                intervju.zaposleniPrezime = prezimeZap.value.trim();
                intervju.ocena = Number(ocena.value);
                intervju.napomene = napomene.value.trim();

                try {
                    await api.intervju.edit(intervju);
                    await alertBox(`Uspesno ste izmenili intervju sa ID=${intervju.intervjuId}!`, "Uspesno");
                    win.close();
                } catch (err) {
                    await errorBox(err.message);
                }
            });
        }
    });
};

// ---------------------------------------------------------------------------
// TESTOVI (TestoviForm)
// ---------------------------------------------------------------------------

Screens.openTestovi = async function (cv) {
    await openModal({
        title: `Testovi za CV: ${cv.ime} ${cv.prezime}`,
        width: 760,
        height: 480,
        resizable: true,
        build: async (body, win) => {
            body.innerHTML = `
                <div class="toolbar">
                    <button class="winbtn primary" id="btnDodaj">Dodaj test</button>
                    <button class="winbtn" id="btnIzmeni">Izmeni test</button>
                    <button class="winbtn danger" id="btnObrisi">Obrisi test</button>
                </div>
                <div id="listHolder"></div>
            `;
            const listHolder = body.querySelector("#listHolder");

            const columns = [
                { header: "ID", render: (t) => String(t.testId) },
                { header: "rezultat", render: (t) => formatMoney(t.rezultat) },
                { header: "datum testiranja", render: (t) => formatDate(t.datumTestiranja) },
                { header: "Vrsta testiranja", render: (t) => t.vrstaTestiranja || "" },
                { header: "komentar", render: (t) => t.komentar || "" }
            ];

            const lv = buildListView({ columns, rows: [], rowId: (t) => t.testId, emptyText: "Nema testova za ovaj CV." });
            listHolder.appendChild(lv.el);

            async function refresh() {
                try {
                    const podaci = await api.test.getForCV(cv.cvId);
                    lv.setRows(podaci || []);
                } catch (err) {
                    await errorBox(err.message);
                }
            }

            body.querySelector("#btnDodaj").addEventListener("click", async () => {
                await Screens.openDodajTest(cv);
                await refresh();
            });

            body.querySelector("#btnIzmeni").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) return alertBox("Izaberite test koji zelite da menjate!");
                const tb = await api.test.get(sel.testId);
                await Screens.openIzmeniTest(tb, cv);
                await refresh();
            });

            body.querySelector("#btnObrisi").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) return alertBox("Izaberite test koji zelite da obrisete!");
                const ok = await confirmBox("Da li zelite da obrisete izabrani test?");
                if (!ok) return;
                try {
                    await api.test.delete(sel.testId);
                    await alertBox("Brisanje testa je uspesno obavljeno!");
                    await refresh();
                } catch (err) {
                    await errorBox(err.message);
                }
            });

            await refresh();
        }
    });
};

Screens.openDodajTest = async function (cv) {
    await openModal({
        title: "Novi test",
        width: 440,
        build: (body, win) => {
            const rezultat = makeInput("number", "t_rez", 0);
            rezultat.min = 0; rezultat.max = 100;
            const datum = makeInput("date", "t_datum", new Date().toISOString().substring(0, 10));
            const vrsta = makeInput("text", "t_vrsta", "");
            const komentar = makeTextarea("t_kom", "");

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "rezultat (0-100) *"), rezultat,
                el("label", { class: "field-label" }, "datum testiranja *"), datum,
                el("label", { class: "field-label" }, "Vrsta testiranja *"), vrsta,
                el("label", { class: "field-label" }, "komentar"), komentar
            ]));

            const btnRow = el("div", { class: "btn-row" });
            const btnDodaj = el("button", { class: "winbtn primary" }, "Dodaj test");
            const btnOtkazi = el("button", { class: "winbtn" }, "Otkazi");
            btnRow.appendChild(btnDodaj);
            btnRow.appendChild(btnOtkazi);
            body.appendChild(btnRow);

            btnOtkazi.addEventListener("click", () => win.close());

            btnDodaj.addEventListener("click", async () => {
                const ok = await confirmBox("Da li zelite da dodate novi Test u CV?");
                if (!ok) return;

                if (!vrsta.value.trim()) {
                    await alertBox("Vrsta testiranja je obavezno polje!", "Nedostaju podaci", MsgIcon.WARN);
                    return;
                }
                if (Number(rezultat.value) < 0 || Number(rezultat.value) > 100) {
                    await alertBox("rezultat mora biti izmedju 1 i 100.", "Greska", MsgIcon.WARN);
                    return;
                }

                const dto = {
                    testId: 0,
                    rezultat: Number(rezultat.value),
                    datumTestiranja: dateInputToIso(datum.value),
                    vrstaTestiranja: vrsta.value.trim(),
                    komentar: komentar.value.trim()
                };

                try {
                    await api.test.add(cv.cvId, dto);
                    await alertBox("Uspesno ste dodali novi test u CV!", "Uspesno");
                    win.close();
                } catch (err) {
                    await errorBox(err.message);
                }
            });
        }
    });
};

Screens.openIzmeniTest = async function (test, cv) {
    await openModal({
        title: `Izmena testa za CV sa ID = ${cv.cvId}`,
        width: 440,
        build: (body, win) => {
            const rezultat = makeInput("number", "t_rez", test.rezultat);
            rezultat.min = 0; rezultat.max = 100;
            const datum = makeInput("date", "t_datum", toDateInputValue(test.datumTestiranja));
            const vrsta = makeInput("text", "t_vrsta", test.vrstaTestiranja);
            const komentar = makeTextarea("t_kom", test.komentar);

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "rezultat (0-100) *"), rezultat,
                el("label", { class: "field-label" }, "datum testiranja *"), datum,
                el("label", { class: "field-label" }, "Vrsta testiranja *"), vrsta,
                el("label", { class: "field-label" }, "komentar"), komentar
            ]));

            const btnRow = el("div", { class: "btn-row" });
            const btnIzmeni = el("button", { class: "winbtn primary" }, "Sacuvaj izmene");
            const btnOtkazi = el("button", { class: "winbtn" }, "Otkazi");
            btnRow.appendChild(btnIzmeni);
            btnRow.appendChild(btnOtkazi);
            body.appendChild(btnRow);

            btnOtkazi.addEventListener("click", () => win.close());

            btnIzmeni.addEventListener("click", async () => {
                const ok = await confirmBox(`Da li zelite da izmenite test ${test.vrstaTestiranja}?`);
                if (!ok) return;

                if (!vrsta.value.trim()) {
                    await alertBox("Vrsta testiranja je obavezno polje!", "Nedostaju podaci", MsgIcon.WARN);
                    return;
                }
                if (Number(rezultat.value) < 0 || Number(rezultat.value) > 100) {
                    await alertBox("rezultat mora biti izmedju 1 i 100.", "Greska", MsgIcon.WARN);
                    return;
                }

                test.rezultat = Number(rezultat.value);
                test.datumTestiranja = dateInputToIso(datum.value);
                test.vrstaTestiranja = vrsta.value.trim();
                test.komentar = komentar.value.trim();

                try {
                    await api.test.edit(test);
                    await alertBox(`Uspesno ste izmenili test sa ID=${test.testId}!`, "Uspesno");
                    win.close();
                } catch (err) {
                    await errorBox(err.message);
                }
            });
        }
    });
};

// ---------------------------------------------------------------------------
// SVE CV PRIJAVE (SveCVPrijaveForm)
// ---------------------------------------------------------------------------

Screens.openSveCVPrijave = async function () {
    await openModal({
        title: "Sve CV prijave",
        width: 860,
        height: 540,
        resizable: true,
        build: async (body, win) => {
            body.innerHTML = `
                <div class="toolbar">
                    <button class="winbtn danger" id="btnObrisiCV">Obrisi CV prijavu</button>
                    <button class="winbtn" id="btnOsvezi">Osvezi</button>
                    <span style="margin-left:auto; display:flex; align-items:center; gap:6px;">
                        Ukupan broj prijava: <span class="count-badge" id="ukupno">0</span>
                    </span>
                </div>
                <div id="listHolder"></div>
            `;
            const listHolder = body.querySelector("#listHolder");

            const columns = [
                { header: "ID", render: (c) => String(c.cvId) },
                { header: "ime", render: (c) => c.ime || "" },
                { header: "prezime", render: (c) => c.prezime || "" },
                { header: "email", render: (c) => c.email || "" },
                { header: "telefon", render: (c) => c.telefon || "" },
                { header: "datum podnosenja", render: (c) => formatDate(c.datumPodnosenja) },
                { header: "status", render: (c) => prettyEnum(c.status) },
                { header: "Oglas ID", render: (c) => String(c.oglasID) }
            ];

            const lv = buildListView({ columns, rows: [], rowId: (c) => c.cvId, emptyText: "Trenutno nema CV prijava." });
            listHolder.appendChild(lv.el);

            async function refresh() {
                try {
                    const podaci = await api.cv.getAll();
                    lv.setRows(podaci || []);
                    body.querySelector("#ukupno").textContent = String((podaci || []).length);
                } catch (err) {
                    await errorBox(err.message);
                }
            }

            body.querySelector("#btnObrisiCV").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) {
                    await alertBox("Izaberite CV prijavu koju zelite da obrisete.", "Obavestenje");
                    return;
                }
                const ok = await confirmYesNo("Da li ste sigurni da zelite da obrisete izabranu CV prijavu?", "Potvrda brisanja");
                if (!ok) return;
                try {
                    await api.cv.deletePrijava(sel.cvId);
                    await alertBox("CV prijava je uspesno obrisana.", "Obavestenje");
                    await refresh();
                } catch (err) {
                    await errorBox(err.message);
                }
            });

            body.querySelector("#btnOsvezi").addEventListener("click", refresh);

            await refresh();
        }
    });
};
