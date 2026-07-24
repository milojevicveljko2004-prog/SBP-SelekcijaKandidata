-- Oglasi
INSERT INTO OGLAS (
    NAZIV_POZICIJE, VRSTA_OGLASA, OPIS, ZAHTEVI,
    MIN_PLATA, MAX_PLATA, DATUM_OBJAVE, DATUM_ZATVARANJA, STATUS
) VALUES (
    'Backend developer', 'STALNI',
    'Razvoj i odrzavanje serverskih aplikacija.',
    'Poznavanje C#, SQL-a i objektno-orijentisanog programiranja.',
    120000, 180000, DATE '2026-06-01', NULL, 'AKTIVAN'
);

INSERT INTO OGLAS (
    NAZIV_POZICIJE, VRSTA_OGLASA, OPIS, ZAHTEVI,
    MIN_PLATA, MAX_PLATA, DATUM_OBJAVE, DATUM_ZATVARANJA, STATUS
) VALUES (
    'QA inzenjer na projektu', 'PRIVREMENI',
    'Testiranje poslovne veb aplikacije.',
    'Poznavanje manuelnog i automatizovanog testiranja.',
    100000, 140000, DATE '2026-05-10', DATE '2026-06-10', 'U_PROCESU_SELEKCIJE'
);

INSERT INTO OGLAS (
    NAZIV_POZICIJE, VRSTA_OGLASA, OPIS, ZAHTEVI,
    MIN_PLATA, MAX_PLATA, DATUM_OBJAVE, DATUM_ZATVARANJA, STATUS
) VALUES (
    'Praksa za softverskog inzenjera', 'PRAKSA',
    'Tromesecna praksa u razvojnom timu.',
    'Osnove C#-a, baza podataka i Git-a.',
    45000, 55000, DATE '2026-06-15', NULL, 'AKTIVAN'
);

INSERT INTO OGLAS (
    NAZIV_POZICIJE, VRSTA_OGLASA, OPIS, ZAHTEVI,
    MIN_PLATA, MAX_PLATA, DATUM_OBJAVE, DATUM_ZATVARANJA, STATUS
) VALUES (
    'Sezonski operater podrske', 'SEZONSKI',
    'Podrska korisnicima tokom letnje sezone.',
    'Komunikativnost i poznavanje engleskog jezika.',
    75000, 90000, DATE '2026-04-01', DATE '2026-05-15', 'ZATVOREN'
);

-- Podaci karakteristicni za pojedine vrste oglasa
INSERT INTO OGLAS_PRIVREMENI (OGLAS_ID, PROJEKAT, PERIOD_ANGAZOVANJA)
SELECT OGLAS_ID, 'Digitalizacija prodaje', '6 meseci'
FROM OGLAS
WHERE NAZIV_POZICIJE = 'QA inzenjer na projektu';

INSERT INTO OGLAS_PRAKSA (
    OGLAS_ID, MENTOR_IME, MENTOR_PREZIME, DUZINA_TRAJANJA
)
SELECT OGLAS_ID, 'Jelena', 'Jovanovic', 3
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Praksa za softverskog inzenjera';

INSERT INTO OGLAS_SEZONSKI (OGLAS_ID, SEZONA, LOKACIJA)
SELECT OGLAS_ID, 'Leto 2026', 'Nis'
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Sezonski operater podrske';

-- Primljeni CV-jevi
INSERT INTO CV (
    DATUM_PODNOSENJA, STATUS, IME, PREZIME, EMAIL, TELEFON, OGLAS_ID
)
SELECT
    DATE '2026-06-05', 'POZVAN_NA_INTERVJU', 'Ana', 'Petrovic',
    'ana.petrovic@example.com', '061111222', OGLAS_ID
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Backend developer';

INSERT INTO CV (
    DATUM_PODNOSENJA, STATUS, IME, PREZIME, EMAIL, TELEFON, OGLAS_ID
)
SELECT
    DATE '2026-06-07', 'U_PROCESU', 'Marko', 'Nikolic',
    'marko.nikolic@example.com', '062333444', OGLAS_ID
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Backend developer';

INSERT INTO CV (
    DATUM_PODNOSENJA, STATUS, IME, PREZIME, EMAIL, TELEFON, OGLAS_ID
)
SELECT
    DATE '2026-05-18', 'ODBIJEN', 'Milica', 'Ilic',
    'milica.ilic@example.com', '063555666', OGLAS_ID
FROM OGLAS
WHERE NAZIV_POZICIJE = 'QA inzenjer na projektu';

INSERT INTO CV (
    DATUM_PODNOSENJA, STATUS, IME, PREZIME, EMAIL, TELEFON, OGLAS_ID
)
SELECT
    DATE '2026-06-20', 'PRIMLJEN', 'Nikola', 'Stojanovic',
    'nikola.stojanovic@example.com', '064777888', OGLAS_ID
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Praksa za softverskog inzenjera';

-- Intervjui
INSERT INTO INTERVJU (
    DATUM, VREME, TIP_INTERVJUA, LOKACIJA,
    ZAPOSLENI_IME, ZAPOSLENI_PREZIME, OCENA, NAPOMENE, CV_ID
)
SELECT
    DATE '2026-06-12', '10:30', 'VIDEO', 'Microsoft Teams',
    'Ivan', 'Markovic', 9, 'Kandidat je pokazao veoma dobro tehnicko znanje.',
    CV_ID
FROM CV
WHERE EMAIL = 'ana.petrovic@example.com';

INSERT INTO INTERVJU (
    DATUM, VREME, TIP_INTERVJUA, LOKACIJA,
    ZAPOSLENI_IME, ZAPOSLENI_PREZIME, OCENA, NAPOMENE, CV_ID
)
SELECT
    DATE '2026-05-25', '13:00', 'LICNI', 'Kancelarija 4',
    'Sara', 'Pavlovic', 6, 'Potrebno je vise iskustva sa automatizovanim testovima.',
    CV_ID
FROM CV
WHERE EMAIL = 'milica.ilic@example.com';

-- Testovi
INSERT INTO TEST (
    REZULTAT, DATUM_TESTIRANJA, VRSTA_TESTIRANJA, KOMENTAR, CV_ID
)
SELECT
    88.50, DATE '2026-06-10', 'C# i SQL test',
    'Odlican rezultat iz SQL dela testa.', CV_ID
FROM CV
WHERE EMAIL = 'ana.petrovic@example.com';

INSERT INTO TEST (
    REZULTAT, DATUM_TESTIRANJA, VRSTA_TESTIRANJA, KOMENTAR, CV_ID
)
SELECT
    72.00, DATE '2026-06-11', 'Test logickih sposobnosti',
    'Kandidat je uspesno zavrsio vecinu zadataka.', CV_ID
FROM CV
WHERE EMAIL = 'marko.nikolic@example.com';

INSERT INTO TEST (
    REZULTAT, DATUM_TESTIRANJA, VRSTA_TESTIRANJA, KOMENTAR, CV_ID
)
SELECT
    58.00, DATE '2026-05-22', 'Testiranje softvera',
    'Nedovoljno poznavanje automatizovanog testiranja.', CV_ID
FROM CV
WHERE EMAIL = 'milica.ilic@example.com';

-- Odluke; UNIQUE(CV_ID) garantuje najvise jednu odluku za jedan CV
INSERT INTO ODLUKA (
    STATUS, DATUM_DONOSENJA_ODLUKE, PONUDJENA_PLATA,
    PRIHVATIO_PONUDU, DATUM_POCETKA_RADA, RAZLOG_ODBIJANJA, CV_ID
)
SELECT
    'IZABRAN', DATE '2026-06-18', 155000,
    1, DATE '2026-07-01', NULL, CV_ID
FROM CV
WHERE EMAIL = 'ana.petrovic@example.com';

INSERT INTO ODLUKA (
    STATUS, DATUM_DONOSENJA_ODLUKE, PONUDJENA_PLATA,
    PRIHVATIO_PONUDU, DATUM_POCETKA_RADA, RAZLOG_ODBIJANJA, CV_ID
)
SELECT
    'NA_CEKANJU', DATE '2026-06-18', NULL,
    0, NULL, NULL, CV_ID
FROM CV
WHERE EMAIL = 'marko.nikolic@example.com';

INSERT INTO ODLUKA (
    STATUS, DATUM_DONOSENJA_ODLUKE, PONUDJENA_PLATA,
    PRIHVATIO_PONUDU, DATUM_POCETKA_RADA, RAZLOG_ODBIJANJA, CV_ID
)
SELECT
    'ODBIJEN', DATE '2026-05-30', NULL,
    0, NULL, 'Kandidat nije ostvario potreban rezultat na testu.', CV_ID
FROM CV
WHERE EMAIL = 'milica.ilic@example.com';

COMMIT;

