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
                { header: "ID", render: (o) => String(o.OglasId) },
                { header: "Naziv pozicije", render: (o) => o.NazivPozicije || "" },
                { header: "Vrsta oglasa", render: (o) => prettyEnum(o.VrstaOglasa) },
                { header: "Opis", render: (o) => o.Opis || "" },
                { header: "Zahtevi", render: (o) => o.Zahtevi || "" },
                { header: "Min. plata", render: (o) => formatMoney(o.MinPlata) },
                { header: "Max. plata", render: (o) => formatMoney(o.MaxPlata) },
                { header: "Datum objave", render: (o) => formatDate(o.DatumObjave) },
                { header: "Datum zatvaranja", render: (o) => o.DatumZatvaranja ? formatDate(o.DatumZatvaranja) : "-" },
                { header: "Status", render: (o) => prettyEnum(o.Status) }
            ];

            const lv = buildListView({ columns, rows: [], rowId: (o) => o.OglasId, emptyText: "Trenutno nema oglasa." });
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
                const ob = await api.oglas.get(sel.OglasId);
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
                    await api.oglas.delete(sel.OglasId);
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
                const ob = await api.oglas.get(sel.OglasId);
                await Screens.openCVPrijaveZaOglas(ob);
                await refresh();
            });

            body.querySelector("#btnPosebniPodaci").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) {
                    await alertBox("Izaberite oglas.");
                    return;
                }
                const ob = await api.oglas.get(sel.OglasId);
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

    f.naziv = makeInput("text", "f_naziv", oglas?.NazivPozicije || "");
    f.vrsta = makeSelect("f_vrsta", Enums.VrstaOglasa, oglas?.VrstaOglasa || "STALNI");
    f.status = makeSelect("f_status", Enums.StatusOglasa, oglas?.Status || "AKTIVAN");
    f.opis = makeTextarea("f_opis", oglas?.Opis || "");
    f.zahtevi = makeTextarea("f_zahtevi", oglas?.Zahtevi || "");
    f.minPlata = makeInput("number", "f_minplata", oglas?.MinPlata ?? "");
    f.maxPlata = makeInput("number", "f_maxplata", oglas?.MaxPlata ?? "");
    f.datumZatvaranjaChk = makeCheckbox("f_dzchk", !!oglas?.DatumZatvaranja);
    f.datumZatvaranja = makeInput("date", "f_dz", toDateInputValue(oglas?.DatumZatvaranja));
    f.datumZatvaranja.disabled = !f.datumZatvaranjaChk.checked;
    f.datumZatvaranjaChk.addEventListener("change", () => {
        f.datumZatvaranja.disabled = !f.datumZatvaranjaChk.checked;
    });

    const grid = el("div", { class: "form-grid" }, [
        el("label", { class: "field-label" }, "Naziv pozicije *"), f.naziv,
        el("label", { class: "field-label" }, "Vrsta oglasa *"), f.vrsta,
        el("label", { class: "field-label" }, "Status *"), f.status,
        el("label", { class: "field-label" }, "Min. plata"), f.minPlata,
        el("label", { class: "field-label" }, "Max. plata"), f.maxPlata,
        el("label", { class: "field-label" }, "Datum zatvaranja"),
        el("div", { class: "inline-fields" }, [f.datumZatvaranjaChk, f.datumZatvaranja]),
        el("label", { class: "field-label" }, "Opis"), f.opis,
        el("label", { class: "field-label" }, "Zahtevi"), f.zahtevi
    ]);
    container.appendChild(grid);

    // Praksa
    f.mentorIme = makeInput("text", "f_mentorIme", oglas?.MentorIme || "");
    f.mentorPrezime = makeInput("text", "f_mentorPrezime", oglas?.MentorPrezime || "");
    f.duzinaTrajanja = makeInput("number", "f_duzina", oglas?.DuzinaTrajanja ?? 1);
    const gbPraksa = el("fieldset", { class: "groupbox hidden", id: "gbPraksa" }, [
        el("legend", {}, "Podaci o praksi"),
        el("div", { class: "form-grid" }, [
            el("label", { class: "field-label" }, "Ime mentora *"), f.mentorIme,
            el("label", { class: "field-label" }, "Prezime mentora *"), f.mentorPrezime,
            el("label", { class: "field-label" }, "Duzina trajanja (meseci) *"), f.duzinaTrajanja
        ])
    ]);

    // Privremeni
    f.projekat = makeInput("text", "f_projekat", oglas?.Projekat || "");
    f.datumPocetka = makeInput("date", "f_datumPocetka", toDateInputValue(oglas?.DatumPocetka) || new Date().toISOString().substring(0, 10));
    f.datumZavrsetka = makeInput("date", "f_datumZavrsetka", toDateInputValue(oglas?.DatumZavrsetka) || new Date().toISOString().substring(0, 10));
    const gbPrivremeni = el("fieldset", { class: "groupbox hidden", id: "gbPrivremeni" }, [
        el("legend", {}, "Podaci o privremenom oglasu"),
        el("div", { class: "form-grid" }, [
            el("label", { class: "field-label" }, "Projekat *"), f.projekat,
            el("label", { class: "field-label" }, "Datum pocetka *"), f.datumPocetka,
            el("label", { class: "field-label" }, "Datum zavrsetka *"), f.datumZavrsetka
        ])
    ]);

    // Sezonski
    f.sezona = makeInput("text", "f_sezona", oglas?.Sezona || "");
    f.lokacija = makeInput("text", "f_lokacija", oglas?.Lokacija || "");
    const gbSezonski = el("fieldset", { class: "groupbox hidden", id: "gbSezonski" }, [
        el("legend", {}, "Podaci o sezonskom oglasu"),
        el("div", { class: "form-grid" }, [
            el("label", { class: "field-label" }, "Sezona *"), f.sezona,
            el("label", { class: "field-label" }, "Lokacija *"), f.lokacija
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
            alertBox("Ime i prezime mentora su obavezni.", "Nedostaju podaci", MsgIcon.WARN);
            return null;
        }
        if (Number(f.duzinaTrajanja.value) <= 0) {
            alertBox("Duzina prakse mora biti veca od nule.", "Neispravan unos", MsgIcon.WARN);
            return null;
        }
        extra = {
            MentorIme: f.mentorIme.value.trim(),
            MentorPrezime: f.mentorPrezime.value.trim(),
            DuzinaTrajanja: Number(f.duzinaTrajanja.value)
        };
    } else if (vrsta === "PRIVREMENI") {
        if (!f.projekat.value.trim()) {
            alertBox("Naziv projekta je obavezan.", "Nedostaju podaci", MsgIcon.WARN);
            return null;
        }
        if (f.datumPocetka.value > f.datumZavrsetka.value) {
            alertBox("Datum pocetka ne moze biti posle datuma zavrsetka.", "Neispravan period", MsgIcon.WARN);
            return null;
        }
        extra = {
            Projekat: f.projekat.value.trim(),
            DatumPocetka: dateInputToIso(f.datumPocetka.value),
            DatumZavrsetka: dateInputToIso(f.datumZavrsetka.value)
        };
    } else if (vrsta === "SEZONSKI") {
        if (!f.sezona.value.trim() || !f.lokacija.value.trim()) {
            alertBox("Sezona i lokacija su obavezne.", "Nedostaju podaci", MsgIcon.WARN);
            return null;
        }
        extra = {
            Sezona: f.sezona.value.trim(),
            Lokacija: f.lokacija.value.trim()
        };
    }

    const datumObjave = existing ? existing.DatumObjave : new Date().toISOString();
    const datumZatvaranja = f.datumZatvaranjaChk.checked ? dateInputToIso(f.datumZatvaranja.value) : null;

    if (datumZatvaranja && new Date(datumZatvaranja) < new Date(datumObjave.substring(0, 10) + "T00:00:00")) {
        alertBox("Datum zatvaranja ne moze biti pre datuma objave.", "Greska", MsgIcon.WARN);
        return null;
    }

    const dto = {
        OglasId: existing ? existing.OglasId : 0,
        NazivPozicije: f.naziv.value.trim(),
        VrstaOglasa: vrsta,
        Opis: f.opis.value.trim() || null,
        Zahtevi: f.zahtevi.value.trim() || null,
        MinPlata: minPlata,
        MaxPlata: maxPlata,
        DatumObjave: datumObjave,
        DatumZatvaranja: datumZatvaranja,
        Status: f.status.value,
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
                    if (dto.VrstaOglasa === "PRAKSA") await api.oglas.addPraksa(dto);
                    else if (dto.VrstaOglasa === "PRIVREMENI") await api.oglas.addPrivremeni(dto);
                    else if (dto.VrstaOglasa === "SEZONSKI") await api.oglas.addSezonski(dto);
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
        title: `Azuriranje oglasa ${oglasOsnovni.NazivPozicije?.toUpperCase() || ""}`,
        width: 560,
        height: 640,
        resizable: true,
        build: async (body, win) => {
            body.innerHTML = `<div class="listview-empty">Ucitavanje...</div>`;

            let oglas;
            try {
                oglas = await api.oglas.get(oglasOsnovni.OglasId);
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

            const staraVrsta = oglas.VrstaOglasa;

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
                    if (dto.VrstaOglasa === "PRAKSA") await api.oglas.editPraksa(dto, staraVrsta);
                    else if (dto.VrstaOglasa === "PRIVREMENI") await api.oglas.editPrivremeni(dto, staraVrsta);
                    else if (dto.VrstaOglasa === "SEZONSKI") await api.oglas.editSezonski(dto, staraVrsta);
                    else await api.oglas.editStalni(dto, staraVrsta);

                    await alertBox(`Uspesno ste izmenili oglas sa ID=${dto.OglasId}!`, "Uspesno");
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
    if (oglas.VrstaOglasa === "STALNI") {
        await alertBox("Oglas za stalni rad nema posebne podatke.");
        return;
    }
    if (oglas.VrstaOglasa === "PRAKSA") return Screens.openPosebniPraksa(oglas);
    if (oglas.VrstaOglasa === "PRIVREMENI") return Screens.openPosebniPrivremeni(oglas);
    if (oglas.VrstaOglasa === "SEZONSKI") return Screens.openPosebniSezonski(oglas);
};

Screens.openPosebniPraksa = async function (oglas) {
    await openModal({
        title: "Podaci o praksi",
        width: 440,
        build: async (body, win) => {
            let podaci = null;
            try {
                podaci = await api.oglasPraksa.get(oglas.OglasId);
            } catch { /* nema podataka */ }

            win.setTitle(podaci ? "Izmena podataka o praksi" : "Podaci o praksi nisu pronadjeni");

            if (!podaci) {
                body.innerHTML = `<div class="listview-empty">Podaci o praksi za ovaj oglas ne postoje.</div>`;
                body.appendChild(el("div", { class: "btn-row right" }, [
                    el("button", { class: "winbtn", onclick: () => win.close() }, "Zatvori")
                ]));
                return;
            }

            const mentorIme = makeInput("text", "pp_mi", podaci.MentorIme);
            const mentorPrezime = makeInput("text", "pp_mp", podaci.MentorPrezime);
            const duzina = makeInput("number", "pp_dt", podaci.DuzinaTrajanja);

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "Ime mentora *"), mentorIme,
                el("label", { class: "field-label" }, "Prezime mentora *"), mentorPrezime,
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
                    await alertBox("Ime i prezime mentora su obavezni.", "Greska", MsgIcon.WARN);
                    return;
                }
                const ok = await confirmBox("Da li zelite da sacuvate oglas prakse?");
                if (!ok) return;
                try {
                    podaci.MentorIme = mentorIme.value.trim();
                    podaci.MentorPrezime = mentorPrezime.value.trim();
                    podaci.DuzinaTrajanja = Number(duzina.value);
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
                podaci = await api.oglasPrivremeni.get(oglas.OglasId);
            } catch { /* nema podataka */ }

            if (!podaci) {
                body.innerHTML = `<div class="listview-empty">Podaci o privremenom oglasu ne postoje.</div>`;
                body.appendChild(el("div", { class: "btn-row right" }, [
                    el("button", { class: "winbtn", onclick: () => win.close() }, "Zatvori")
                ]));
                return;
            }

            const projekat = makeInput("text", "pp_proj", podaci.Projekat);
            const datumPocetka = makeInput("date", "pp_dp", toDateInputValue(podaci.DatumPocetka));
            const datumZavrsetka = makeInput("date", "pp_dzv", toDateInputValue(podaci.DatumZavrsetka));

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "Projekat *"), projekat,
                el("label", { class: "field-label" }, "Datum pocetka *"), datumPocetka,
                el("label", { class: "field-label" }, "Datum zavrsetka *"), datumZavrsetka
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
                    await alertBox("Ime projekta je obavezno.", "Greska", MsgIcon.WARN);
                    return;
                }
                if (datumPocetka.value > datumZavrsetka.value) {
                    await alertBox("Datum pocetka mora biti pre datuma zavrsetka!", "Greska", MsgIcon.WARN);
                    return;
                }
                const ok = await confirmBox("Da li zelite da sacuvate privremeni oglas?");
                if (!ok) return;
                try {
                    podaci.Projekat = projekat.value.trim();
                    podaci.DatumPocetka = dateInputToIso(datumPocetka.value);
                    podaci.DatumZavrsetka = dateInputToIso(datumZavrsetka.value);
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
                podaci = await api.oglasSezonski.get(oglas.OglasId);
            } catch { /* nema podataka */ }

            if (!podaci) {
                body.innerHTML = `<div class="listview-empty">Podaci o sezonskom oglasu ne postoje.</div>`;
                body.appendChild(el("div", { class: "btn-row right" }, [
                    el("button", { class: "winbtn", onclick: () => win.close() }, "Zatvori")
                ]));
                return;
            }

            const sezona = makeInput("text", "pp_sez", podaci.Sezona);
            const lokacija = makeInput("text", "pp_lok", podaci.Lokacija);

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "Sezona *"), sezona,
                el("label", { class: "field-label" }, "Lokacija *"), lokacija
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
                    await alertBox("Sezona i lokacija su obavezni.", "Greska", MsgIcon.WARN);
                    return;
                }
                const ok = await confirmBox("Da li zelite da sacuvate sezonski oglas?");
                if (!ok) return;
                try {
                    podaci.Sezona = sezona.value.trim();
                    podaci.Lokacija = lokacija.value.trim();
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
        title: `Oglas ${oglas.NazivPozicije?.toUpperCase() || ""}`,
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
                { header: "ID", render: (c) => String(c.CvId) },
                { header: "Ime", render: (c) => c.Ime || "" },
                { header: "Prezime", render: (c) => c.Prezime || "" },
                { header: "Email", render: (c) => c.Email || "" },
                { header: "Telefon", render: (c) => c.Telefon || "" },
                { header: "Datum podnosenja", render: (c) => formatDate(c.DatumPodnosenja) },
                { header: "Status", render: (c) => prettyEnum(c.Status) },
                { header: "Oglas ID", render: (c) => String(c.OglasID) }
            ];

            const lv = buildListView({ columns, rows: [], rowId: (c) => c.CvId, emptyText: "Nema CV prijava za ovaj oglas." });
            listHolder.appendChild(lv.el);

            async function refresh() {
                try {
                    const podaci = await api.cv.getForOglas(oglas.OglasId);
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
                const cvb = await api.cv.get(sel.CvId);
                await Screens.openIzmeniCV(cvb, oglas);
                await refresh();
            });

            body.querySelector("#btnObrisiCV").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) return alertBox("Izaberite CV prijavu koju zelite da obrisete iz oglasa!");
                const ok = await confirmBox("Da li zelite da obrisete izabranu CV prijavu?");
                if (!ok) return;
                try {
                    await api.cv.delete(sel.CvId);
                    await alertBox("Brisanje CV prijave iz oglasa je uspesno obavljeno!");
                    await refresh();
                } catch (err) {
                    await errorBox(err.message);
                }
            });

            body.querySelector("#btnIntervjui").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) return alertBox("Izaberite CV za koji zelite da vidite intervjue!");
                const cvb = await api.cv.get(sel.CvId);
                await Screens.openIntervjui(cvb);
            });

            body.querySelector("#btnTestovi").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) return alertBox("Izaberite CV za koji zelite da vidite testove!");
                const cvb = await api.cv.get(sel.CvId);
                await Screens.openTestovi(cvb);
            });

            body.querySelector("#btnOdluka").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) return alertBox("Izaberite CV za koji zelite da vidite Odluku!");
                const cvb = await api.cv.get(sel.CvId);
                await Screens.openOdluka(cvb);
            });

            await refresh();
        }
    });
};

Screens.openDodajCV = async function (oglas) {
    await openModal({
        title: `Novi CV za oglas ${oglas.NazivPozicije || ""}`,
        width: 440,
        build: (body, win) => {
            const ime = makeInput("text", "cv_ime", "");
            const prezime = makeInput("text", "cv_prezime", "");
            const email = makeInput("email", "cv_email", "");
            const telefon = makeInput("text", "cv_telefon", "");

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "Ime *"), ime,
                el("label", { class: "field-label" }, "Prezime *"), prezime,
                el("label", { class: "field-label" }, "Email *"), email,
                el("label", { class: "field-label" }, "Telefon *"), telefon
            ]));
            body.appendChild(el("div", { class: "small-note" }, "Datum podnosenja i status (PRIMLJEN) se postavljaju automatski."));

            const btnRow = el("div", { class: "btn-row" });
            const btnDodaj = el("button", { class: "winbtn primary" }, "Dodaj CV");
            const btnOtkazi = el("button", { class: "winbtn" }, "Otkazi");
            btnRow.appendChild(btnDodaj);
            btnRow.appendChild(btnOtkazi);
            body.appendChild(btnRow);

            btnOtkazi.addEventListener("click", () => win.close());

            btnDodaj.addEventListener("click", async () => {
                const ok = await confirmBox(`Da li zelite da dodate novi CV u oglas ${oglas.NazivPozicije}?`);
                if (!ok) return;

                if (!ime.value.trim() || !prezime.value.trim() || !email.value.trim() || !telefon.value.trim()) {
                    await alertBox("Sva polja su obavezna!", "Nedostaju podaci", MsgIcon.WARN);
                    return;
                }

                const dto = {
                    CvId: 0,
                    Ime: ime.value.trim(),
                    Prezime: prezime.value.trim(),
                    Email: email.value.trim(),
                    Telefon: telefon.value.trim(),
                    DatumPodnosenja: new Date().toISOString(),
                    Status: "PRIMLJEN"
                };

                try {
                    await api.cv.add(oglas.OglasId, dto);
                    await alertBox(`Uspesno ste dodali novi CV u oglas ${oglas.NazivPozicije}!`, "Uspesno");
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
        title: `Izmena CV-a za oglas ${oglas.NazivPozicije || ""}`,
        width: 440,
        build: (body, win) => {
            const ime = makeInput("text", "cv_ime", cv.Ime);
            const prezime = makeInput("text", "cv_prezime", cv.Prezime);
            const email = makeInput("email", "cv_email", cv.Email);
            const telefon = makeInput("text", "cv_telefon", cv.Telefon);
            const datumPodnosenja = makeInput("date", "cv_dp", toDateInputValue(cv.DatumPodnosenja));
            datumPodnosenja.disabled = true;
            const status = makeSelect("cv_status", Enums.CVStatus, cv.Status);

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "Ime *"), ime,
                el("label", { class: "field-label" }, "Prezime *"), prezime,
                el("label", { class: "field-label" }, "Email *"), email,
                el("label", { class: "field-label" }, "Telefon *"), telefon,
                el("label", { class: "field-label" }, "Datum podnosenja"), datumPodnosenja,
                el("label", { class: "field-label" }, "Status *"), status
            ]));

            const btnRow = el("div", { class: "btn-row" });
            const btnIzmeni = el("button", { class: "winbtn primary" }, "Sacuvaj izmene");
            const btnOtkazi = el("button", { class: "winbtn" }, "Otkazi");
            btnRow.appendChild(btnIzmeni);
            btnRow.appendChild(btnOtkazi);
            body.appendChild(btnRow);

            btnOtkazi.addEventListener("click", () => win.close());

            btnIzmeni.addEventListener("click", async () => {
                const ok = await confirmBox(`Da li zelite da izmenite CV sa ID=${cv.CvId}?`);
                if (!ok) return;

                if (!ime.value.trim() || !prezime.value.trim() || !email.value.trim() || !telefon.value.trim() || !status.value) {
                    await alertBox("Sva polja su obavezna!", "Nedostaju podaci", MsgIcon.WARN);
                    return;
                }

                cv.Ime = ime.value.trim();
                cv.Prezime = prezime.value.trim();
                cv.Email = email.value.trim();
                cv.Telefon = telefon.value.trim();
                cv.Status = status.value;

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
        title: `Odluka za CV: ${cv.Ime} ${cv.Prezime}`,
        width: 480,
        height: 520,
        resizable: true,
        build: async (body, win) => {
            let odluka = null;
            try {
                odluka = await api.odluka.getForCV(cv.CvId);
            } catch { odluka = null; }

            const odlukaPostoji = !!odluka;
            if (!odluka) {
                odluka = { OdlukaId: 0, Status: "NA_CEKANJU", DatumDonosenjaOdluke: new Date().toISOString(), PonudjenaPlata: null, PrihvatioPonudu: null, DatumPocetkaRada: null, RazlogOdbijanja: null };
            }

            const status = makeSelect("od_status", Enums.StatusOdluke, odluka.Status);
            const ponudjenaPlata = makeInput("number", "od_plata", odluka.PonudjenaPlata ?? 0);
            const checkDa = makeCheckbox("od_da", odluka.PrihvatioPonudu === true);
            const checkNe = makeCheckbox("od_ne", odluka.PrihvatioPonudu === false);
            const datumPocetkaChk = makeCheckbox("od_dprchk", !!odluka.DatumPocetkaRada);
            const datumPocetka = makeInput("date", "od_dpr", toDateInputValue(odluka.DatumPocetkaRada));
            const razlog = makeTextarea("od_razlog", odluka.RazlogOdbijanja || "");

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "Status odluke *"), status,
                el("label", { class: "field-label" }, "Ponudjena plata"), ponudjenaPlata,
                el("label", { class: "field-label" }, "Prihvatio ponudu"),
                el("div", { class: "inline-fields" }, [
                    el("span", { class: "checkline" }, [checkDa, "Da"]),
                    el("span", { class: "checkline" }, [checkNe, "Ne"])
                ]),
                el("label", { class: "field-label" }, "Datum pocetka rada"),
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

                odluka.Status = st;

                if (st === "IZABRAN") {
                    if (Number(ponudjenaPlata.value) <= 0) {
                        await alertBox("Ponudjena plata mora biti veca od nule.", "Neispravan unos", MsgIcon.WARN);
                        return;
                    }
                    if (!checkDa.checked && !checkNe.checked) {
                        await alertBox("Oznacite da li je ponuda prihvacena.", "Nedostaju podaci", MsgIcon.WARN);
                        return;
                    }
                    odluka.PonudjenaPlata = Number(ponudjenaPlata.value);

                    if (checkDa.checked) {
                        if (!datumPocetkaChk.checked) {
                            await alertBox("Unesite datum pocetka rada.", "Nedostaju podaci", MsgIcon.WARN);
                            return;
                        }
                        const dpr = dateInputToIso(datumPocetka.value);
                        if (new Date(dpr) < new Date(odluka.DatumDonosenjaOdluke.substring(0, 10) + "T00:00:00")) {
                            await alertBox("Datum pocetka rada ne moze biti pre datuma donosenja odluke.", "Neispravan datum", MsgIcon.WARN);
                            return;
                        }
                        odluka.PrihvatioPonudu = true;
                        odluka.DatumPocetkaRada = dpr;
                        odluka.RazlogOdbijanja = null;
                    } else {
                        if (!razlog.value.trim()) {
                            await alertBox("Unesite razlog odbijanja ponude.", "Nedostaju podaci", MsgIcon.WARN);
                            return;
                        }
                        odluka.PrihvatioPonudu = false;
                        odluka.DatumPocetkaRada = null;
                        odluka.RazlogOdbijanja = razlog.value.trim();
                    }
                } else {
                    odluka.PonudjenaPlata = null;
                    odluka.PrihvatioPonudu = null;
                    odluka.DatumPocetkaRada = null;

                    if (st === "ODBIJEN") {
                        if (!razlog.value.trim()) {
                            await alertBox("Unesite razlog odbijanja kandidata.", "Nedostaju podaci", MsgIcon.WARN);
                            return;
                        }
                        odluka.RazlogOdbijanja = razlog.value.trim();
                    } else {
                        odluka.RazlogOdbijanja = null;
                    }
                }

                const poruka = odlukaPostoji ? "Da li zelite da sacuvate izmene odluke?" : "Da li zelite da dodate odluku za izabrani CV?";
                const ok = await confirmBox(poruka, "Potvrda");
                if (!ok) return;

                try {
                    if (odlukaPostoji) {
                        await api.odluka.edit(odluka);
                    } else {
                        await api.odluka.add(cv.CvId, odluka);
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
        title: `Intervjui za CV: ${cv.Ime} ${cv.Prezime}`,
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
                { header: "ID", render: (i) => String(i.IntervjuId) },
                { header: "Datum", render: (i) => formatDate(i.Datum) },
                { header: "Vreme", render: (i) => formatTime(i.Vreme) },
                { header: "Tip", render: (i) => prettyEnum(i.Tip) },
                { header: "Lokacija", render: (i) => i.Lokacija || "" },
                { header: "Ime zaposlenog", render: (i) => i.ZaposleniIme || "" },
                { header: "Prezime zaposlenog", render: (i) => i.ZaposleniPrezime || "" },
                { header: "Ocena", render: (i) => String(i.Ocena) },
                { header: "Napomene", render: (i) => i.Napomene || "" }
            ];

            const lv = buildListView({ columns, rows: [], rowId: (i) => i.IntervjuId, emptyText: "Nema intervjua za ovaj CV." });
            listHolder.appendChild(lv.el);

            async function refresh() {
                try {
                    const podaci = await api.intervju.getForCV(cv.CvId);
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
                const ib = await api.intervju.get(sel.IntervjuId);
                await Screens.openIzmeniIntervju(ib, cv);
                await refresh();
            });

            body.querySelector("#btnObrisi").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) return alertBox("Izaberite intervju koji zelite da obrisete iz CV-ja!");
                const ok = await confirmBox("Da li zelite da obrisete izabrani intervju?");
                if (!ok) return;
                try {
                    await api.intervju.delete(sel.IntervjuId);
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
                el("label", { class: "field-label" }, "Datum *"), datum,
                el("label", { class: "field-label" }, "Vreme *"), vreme,
                el("label", { class: "field-label" }, "Tip intervjua *"), tip,
                el("label", { class: "field-label" }, "Lokacija *"), lokacija,
                el("label", { class: "field-label" }, "Ime zaposlenog *"), imeZap,
                el("label", { class: "field-label" }, "Prezime zaposlenog *"), prezimeZap,
                el("label", { class: "field-label" }, "Ocena (1-10) *"), ocena,
                el("label", { class: "field-label" }, "Napomene"), napomene
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
                    await alertBox("Lokacija, ime zaposlenog i prezime zaposlenog su obavezni!", "Nedostaju podaci", MsgIcon.WARN);
                    return;
                }
                if (Number(ocena.value) < 1 || Number(ocena.value) > 10) {
                    await alertBox("Ocena mora biti u opsegu od 1 do 10.", "Greska", MsgIcon.WARN);
                    return;
                }

                const dto = {
                    IntervjuId: 0,
                    Datum: dateInputToIso(datum.value),
                    Vreme: timeInputToIso(vreme.value, datum.value),
                    Tip: tip.value,
                    Lokacija: lokacija.value.trim(),
                    ZaposleniIme: imeZap.value.trim(),
                    ZaposleniPrezime: prezimeZap.value.trim(),
                    Ocena: Number(ocena.value),
                    Napomene: napomene.value.trim()
                };

                try {
                    await api.intervju.add(cv.CvId, dto);
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
        title: `Izmena intervjua za CV sa ID = ${cv.CvId}`,
        width: 460,
        height: 520,
        resizable: true,
        build: (body, win) => {
            const datum = makeInput("date", "iv_datum", toDateInputValue(intervju.Datum));
            const vreme = makeInput("time", "iv_vreme", toTimeInputValue(intervju.Vreme));
            const tip = makeSelect("iv_tip", Enums.TipIntervjua, intervju.Tip);
            const lokacija = makeInput("text", "iv_lok", intervju.Lokacija);
            const imeZap = makeInput("text", "iv_ime", intervju.ZaposleniIme);
            const prezimeZap = makeInput("text", "iv_prezime", intervju.ZaposleniPrezime);
            const ocena = makeInput("number", "iv_ocena", intervju.Ocena);
            ocena.min = 1; ocena.max = 10;
            const napomene = makeTextarea("iv_nap", intervju.Napomene);

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "Datum *"), datum,
                el("label", { class: "field-label" }, "Vreme *"), vreme,
                el("label", { class: "field-label" }, "Tip intervjua *"), tip,
                el("label", { class: "field-label" }, "Lokacija *"), lokacija,
                el("label", { class: "field-label" }, "Ime zaposlenog *"), imeZap,
                el("label", { class: "field-label" }, "Prezime zaposlenog *"), prezimeZap,
                el("label", { class: "field-label" }, "Ocena (1-10) *"), ocena,
                el("label", { class: "field-label" }, "Napomene"), napomene
            ]));

            const btnRow = el("div", { class: "btn-row" });
            const btnIzmeni = el("button", { class: "winbtn primary" }, "Sacuvaj izmene");
            const btnOtkazi = el("button", { class: "winbtn" }, "Otkazi");
            btnRow.appendChild(btnIzmeni);
            btnRow.appendChild(btnOtkazi);
            body.appendChild(btnRow);

            btnOtkazi.addEventListener("click", () => win.close());

            btnIzmeni.addEventListener("click", async () => {
                const ok = await confirmBox(`Da li zelite da izmenite intervju sa ID=${intervju.IntervjuId}?`);
                if (!ok) return;

                if (!lokacija.value.trim() || !imeZap.value.trim() || !prezimeZap.value.trim()) {
                    await alertBox("Lokacija, ime zaposlenog i prezime zaposlenog su obavezni!", "Nedostaju podaci", MsgIcon.WARN);
                    return;
                }
                if (Number(ocena.value) < 1 || Number(ocena.value) > 10) {
                    await alertBox("Ocena mora biti u opsegu od 1 do 10.", "Greska", MsgIcon.WARN);
                    return;
                }

                intervju.Datum = dateInputToIso(datum.value);
                intervju.Vreme = timeInputToIso(vreme.value, datum.value);
                intervju.Tip = tip.value;
                intervju.Lokacija = lokacija.value.trim();
                intervju.ZaposleniIme = imeZap.value.trim();
                intervju.ZaposleniPrezime = prezimeZap.value.trim();
                intervju.Ocena = Number(ocena.value);
                intervju.Napomene = napomene.value.trim();

                try {
                    await api.intervju.edit(intervju);
                    await alertBox(`Uspesno ste izmenili intervju sa ID=${intervju.IntervjuId}!`, "Uspesno");
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
        title: `Testovi za CV: ${cv.Ime} ${cv.Prezime}`,
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
                { header: "ID", render: (t) => String(t.TestId) },
                { header: "Rezultat", render: (t) => formatMoney(t.Rezultat) },
                { header: "Datum testiranja", render: (t) => formatDate(t.DatumTestiranja) },
                { header: "Vrsta testiranja", render: (t) => t.VrstaTestiranja || "" },
                { header: "Komentar", render: (t) => t.Komentar || "" }
            ];

            const lv = buildListView({ columns, rows: [], rowId: (t) => t.TestId, emptyText: "Nema testova za ovaj CV." });
            listHolder.appendChild(lv.el);

            async function refresh() {
                try {
                    const podaci = await api.test.getForCV(cv.CvId);
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
                const tb = await api.test.get(sel.TestId);
                await Screens.openIzmeniTest(tb, cv);
                await refresh();
            });

            body.querySelector("#btnObrisi").addEventListener("click", async () => {
                const sel = lv.getSelected();
                if (!sel) return alertBox("Izaberite test koji zelite da obrisete!");
                const ok = await confirmBox("Da li zelite da obrisete izabrani test?");
                if (!ok) return;
                try {
                    await api.test.delete(sel.TestId);
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
                el("label", { class: "field-label" }, "Rezultat (0-100) *"), rezultat,
                el("label", { class: "field-label" }, "Datum testiranja *"), datum,
                el("label", { class: "field-label" }, "Vrsta testiranja *"), vrsta,
                el("label", { class: "field-label" }, "Komentar"), komentar
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
                    await alertBox("Rezultat mora biti izmedju 1 i 100.", "Greska", MsgIcon.WARN);
                    return;
                }

                const dto = {
                    TestId: 0,
                    Rezultat: Number(rezultat.value),
                    DatumTestiranja: dateInputToIso(datum.value),
                    VrstaTestiranja: vrsta.value.trim(),
                    Komentar: komentar.value.trim()
                };

                try {
                    await api.test.add(cv.CvId, dto);
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
        title: `Izmena testa za CV sa ID = ${cv.CvId}`,
        width: 440,
        build: (body, win) => {
            const rezultat = makeInput("number", "t_rez", test.Rezultat);
            rezultat.min = 0; rezultat.max = 100;
            const datum = makeInput("date", "t_datum", toDateInputValue(test.DatumTestiranja));
            const vrsta = makeInput("text", "t_vrsta", test.VrstaTestiranja);
            const komentar = makeTextarea("t_kom", test.Komentar);

            body.appendChild(el("div", { class: "form-grid" }, [
                el("label", { class: "field-label" }, "Rezultat (0-100) *"), rezultat,
                el("label", { class: "field-label" }, "Datum testiranja *"), datum,
                el("label", { class: "field-label" }, "Vrsta testiranja *"), vrsta,
                el("label", { class: "field-label" }, "Komentar"), komentar
            ]));

            const btnRow = el("div", { class: "btn-row" });
            const btnIzmeni = el("button", { class: "winbtn primary" }, "Sacuvaj izmene");
            const btnOtkazi = el("button", { class: "winbtn" }, "Otkazi");
            btnRow.appendChild(btnIzmeni);
            btnRow.appendChild(btnOtkazi);
            body.appendChild(btnRow);

            btnOtkazi.addEventListener("click", () => win.close());

            btnIzmeni.addEventListener("click", async () => {
                const ok = await confirmBox(`Da li zelite da izmenite test ${test.VrstaTestiranja}?`);
                if (!ok) return;

                if (!vrsta.value.trim()) {
                    await alertBox("Vrsta testiranja je obavezno polje!", "Nedostaju podaci", MsgIcon.WARN);
                    return;
                }
                if (Number(rezultat.value) < 0 || Number(rezultat.value) > 100) {
                    await alertBox("Rezultat mora biti izmedju 1 i 100.", "Greska", MsgIcon.WARN);
                    return;
                }

                test.Rezultat = Number(rezultat.value);
                test.DatumTestiranja = dateInputToIso(datum.value);
                test.VrstaTestiranja = vrsta.value.trim();
                test.Komentar = komentar.value.trim();

                try {
                    await api.test.edit(test);
                    await alertBox(`Uspesno ste izmenili test sa ID=${test.TestId}!`, "Uspesno");
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
                { header: "ID", render: (c) => String(c.CvId) },
                { header: "Ime", render: (c) => c.Ime || "" },
                { header: "Prezime", render: (c) => c.Prezime || "" },
                { header: "Email", render: (c) => c.Email || "" },
                { header: "Telefon", render: (c) => c.Telefon || "" },
                { header: "Datum podnosenja", render: (c) => formatDate(c.DatumPodnosenja) },
                { header: "Status", render: (c) => prettyEnum(c.Status) },
                { header: "Oglas ID", render: (c) => String(c.OglasID) }
            ];

            const lv = buildListView({ columns, rows: [], rowId: (c) => c.CvId, emptyText: "Trenutno nema CV prijava." });
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
                    await api.cv.deletePrijava(sel.CvId);
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
