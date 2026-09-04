const ApiError = class extends Error {};

async function apiRequest(method, url, body) {
    const options = {
        method,
        headers: {}
    };

    if (body !== undefined) {
        options.headers["Content-Type"] = "application/json";
        options.body = JSON.stringify(body);
    }

    let response;
    try {
        response = await fetch(url, options);
    } catch (networkErr) {
        throw new ApiError("Server nije dostupan. Proverite da li je WebAPI pokrenut.");
    }

    const contentType = response.headers.get("content-type") || "";
    let payload = null;
    const rawText = await response.text();

    if (rawText) {
        if (contentType.includes("application/json")) {
            try {
                payload = JSON.parse(rawText);
            } catch {
                payload = rawText;
            }
        } else {
            payload = rawText;
        }
    }

    if (!response.ok) {
        const message = typeof payload === "string" ? payload : (payload?.message || `Greska ${response.status}`);
        throw new ApiError(message || `Greska ${response.status}`);
    }

    return payload;
}

const api = {
    oglas: {
        getAll: () => apiRequest("GET", "/Oglas/PreuzmiSveOglase"),
        get: (id) => apiRequest("GET", `/Oglas/PreuzmiOglas/${id}`),
        addStalni: (dto) => apiRequest("POST", "/Oglas/DodajOglasStalni", dto),
        addPraksa: (dto) => apiRequest("POST", "/Oglas/DodajOglasPraksa", dto),
        addPrivremeni: (dto) => apiRequest("POST", "/Oglas/DodajOglasPrivremeni", dto),
        addSezonski: (dto) => apiRequest("POST", "/Oglas/DodajOglasSezonski", dto),
        editStalni: (dto, staraVrsta) => apiRequest("PUT", `/Oglas/IzmeniOglasStalni/${staraVrsta}`, dto),
        editPraksa: (dto, staraVrsta) => apiRequest("PUT", `/Oglas/IzmeniOglasPraksa/${staraVrsta}`, dto),
        editPrivremeni: (dto, staraVrsta) => apiRequest("PUT", `/Oglas/IzmeniOglasPrivremeni/${staraVrsta}`, dto),
        editSezonski: (dto, staraVrsta) => apiRequest("PUT", `/Oglas/IzmeniOglasSezonski/${staraVrsta}`, dto),
        delete: (id) => apiRequest("DELETE", `/Oglas/ObrisiOglas/${id}`)
    },
    oglasPraksa: {
        get: (id) => apiRequest("GET", `/OglasPraksa/PreuzmiOglasPrakse/${id}`),
        edit: (dto) => apiRequest("PUT", "/OglasPraksa/IzmeniOglasPraksu", dto)
    },
    oglasPrivremeni: {
        get: (id) => apiRequest("GET", `/OglasPrivremeni/PreuzmiOglasPrivremeni/${id}`),
        edit: (dto) => apiRequest("PUT", "/OglasPrivremeni/IzmeniOglasPrivremeni", dto)
    },
    oglasSezonski: {
        get: (id) => apiRequest("GET", `/OglasSezonski/PreuzmiOglasSezonski/${id}`),
        edit: (dto) => apiRequest("PUT", "/OglasSezonski/IzmeniOglasSezonski", dto)
    },
    cv: {
        getAll: () => apiRequest("GET", "/CV/PreuzmiSveCVPrijave"),
        getForOglas: (oglasId) => apiRequest("GET", `/CV/PreuzmiCVPrijaveOglasa/${oglasId}`),
        get: (id) => apiRequest("GET", `/CV/PreuzmiCV/${id}`),
        add: (oglasId, dto) => apiRequest("POST", `/CV/DodajCV/${oglasId}`, dto),
        edit: (dto) => apiRequest("PUT", "/CV/IzmeniCV", dto),
        delete: (id) => apiRequest("DELETE", `/CV/ObrisiCV/${id}`),
        deletePrijava: (id) => apiRequest("DELETE", `/CV/ObrisiCVPrijavu/${id}`)
    },
    intervju: {
        getForCV: (cvId) => apiRequest("GET", `/Intervju/PreuzmiIntervjueCVPrijave/${cvId}`),
        get: (id) => apiRequest("GET", `/Intervju/PreuzmiIntervju/${id}`),
        add: (cvId, dto) => apiRequest("POST", `/Intervju/DodajIntervju/${cvId}`, dto),
        edit: (dto) => apiRequest("PUT", "/Intervju/IzmeniIntervju", dto),
        delete: (id) => apiRequest("DELETE", `/Intervju/ObrisiIntervju/${id}`)
    },
    test: {
        getForCV: (cvId) => apiRequest("GET", `/Test/PreuzmiTestoveCVPrijave/${cvId}`),
        get: (id) => apiRequest("GET", `/Test/PreuzmiTest/${id}`),
        add: (cvId, dto) => apiRequest("POST", `/Test/DodajTest/${cvId}`, dto),
        edit: (dto) => apiRequest("PUT", "/Test/IzmeniTest", dto),
        delete: (id) => apiRequest("DELETE", `/Test/ObrisiTest/${id}`)
    },
    odluka: {
        getForCV: (cvId) => apiRequest("GET", `/Odluka/PreuzmiOdlukuZaCV/${cvId}`),
        add: (cvId, dto) => apiRequest("POST", `/Odluka/DodajOdluku/${cvId}`, dto),
        edit: (dto) => apiRequest("PUT", "/Odluka/IzmeniOdluku", dto)
    }
};

// Enumi - vrednosti se sada serijalizuju kao stringovi (JsonStringEnumConverter na backendu),
// pa ih ovde drzimo kao spisak opcija za select box-ove (identicno enumima u DatabaseAccess.Entiteti.Enums).
const Enums = {
    VrstaOglasa: ["STALNI", "PRIVREMENI", "PRAKSA", "SEZONSKI"],
    StatusOglasa: ["AKTIVAN", "ZATVOREN", "U_PROCESU_SELEKCIJE"],
    CVStatus: ["PRIMLJEN", "U_PROCESU", "ODBIJEN", "POZVAN_NA_INTERVJU"],
    TipIntervjua: ["LICNI", "VIDEO", "TELEFONSKI"],
    StatusOdluke: ["IZABRAN", "ODBIJEN", "REZERVA", "NA_CEKANJU"]
};
