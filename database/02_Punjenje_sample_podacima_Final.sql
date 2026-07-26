-- Oracle 12c+
-- Sample podaci za bazu SELEKCIJA KANDIDATA
-- Pokrenuti nakon skripte 01_Kreiranje_baze_Final.sql.

-- ============================================================
-- OGLASI
-- ============================================================

INSERT INTO OGLAS (
    NAZIV_POZICIJE, VRSTA_OGLASA, OPIS, ZAHTEVI,
    MIN_PLATA, MAX_PLATA, DATUM_OBJAVE, DATUM_ZATVARANJA, STATUS
) VALUES (
    'Senior Java Developer', 'STALNI',
    'Razvoj i odrzavanje poslovnih aplikacija.',
    'Najmanje tri godine iskustva, Java i SQL.',
    180000, 260000, DATE '2026-06-01', NULL, 'AKTIVAN'
);

INSERT INTO OGLAS (
    NAZIV_POZICIJE, VRSTA_OGLASA, OPIS, ZAHTEVI,
    MIN_PLATA, MAX_PLATA, DATUM_OBJAVE, DATUM_ZATVARANJA, STATUS
) VALUES (
    'Poslovni analiticar', 'STALNI',
    'Analiza poslovnih procesa i izrada specifikacija.',
    'Poznavanje UML-a, SQL-a i rada sa klijentima.',
    140000, 200000, DATE '2026-05-10', DATE '2026-06-10',
    'U_PROCESU_SELEKCIJE'
);

INSERT INTO OGLAS (
    NAZIV_POZICIJE, VRSTA_OGLASA, OPIS, ZAHTEVI,
    MIN_PLATA, MAX_PLATA, DATUM_OBJAVE, DATUM_ZATVARANJA, STATUS
) VALUES (
    'Frontend Developer na projektu e-Uprava', 'PRIVREMENI',
    'Razvoj korisnickog interfejsa za novi informacioni sistem.',
    'React, JavaScript, HTML i CSS.',
    160000, 220000, DATE '2026-07-01', NULL, 'AKTIVAN'
);

INSERT INTO OGLAS (
    NAZIV_POZICIJE, VRSTA_OGLASA, OPIS, ZAHTEVI,
    MIN_PLATA, MAX_PLATA, DATUM_OBJAVE, DATUM_ZATVARANJA, STATUS
) VALUES (
    'Administrator baze na migraciji podataka', 'PRIVREMENI',
    'Podrska migraciji podataka na novu platformu.',
    'Oracle SQL, PL/SQL i iskustvo sa migracijama.',
    170000, 230000, DATE '2026-04-01', DATE '2026-04-30', 'ZATVOREN'
);

INSERT INTO OGLAS (
    NAZIV_POZICIJE, VRSTA_OGLASA, OPIS, ZAHTEVI,
    MIN_PLATA, MAX_PLATA, DATUM_OBJAVE, DATUM_ZATVARANJA, STATUS
) VALUES (
    'Praksa za softverskog inzenjera', 'PRAKSA',
    'Praktican rad u timu za razvoj web aplikacija.',
    'Osnove programiranja i relacionih baza podataka.',
    NULL, NULL, DATE '2026-06-15', NULL, 'AKTIVAN'
);

INSERT INTO OGLAS (
    NAZIV_POZICIJE, VRSTA_OGLASA, OPIS, ZAHTEVI,
    MIN_PLATA, MAX_PLATA, DATUM_OBJAVE, DATUM_ZATVARANJA, STATUS
) VALUES (
    'Praksa za QA testera', 'PRAKSA',
    'Upoznavanje sa manuelnim i automatskim testiranjem.',
    'Osnove testiranja softvera i engleski jezik.',
    NULL, NULL, DATE '2026-05-20', DATE '2026-06-20',
    'U_PROCESU_SELEKCIJE'
);

INSERT INTO OGLAS (
    NAZIV_POZICIJE, VRSTA_OGLASA, OPIS, ZAHTEVI,
    MIN_PLATA, MAX_PLATA, DATUM_OBJAVE, DATUM_ZATVARANJA, STATUS
) VALUES (
    'Recepcioner u hotelu', 'SEZONSKI',
    'Rad na recepciji tokom zimske turisticke sezone.',
    'Engleski jezik i rad na racunaru.',
    90000, 120000, DATE '2026-07-01', NULL, 'AKTIVAN'
);

INSERT INTO OGLAS (
    NAZIV_POZICIJE, VRSTA_OGLASA, OPIS, ZAHTEVI,
    MIN_PLATA, MAX_PLATA, DATUM_OBJAVE, DATUM_ZATVARANJA, STATUS
) VALUES (
    'Spasilac na bazenu', 'SEZONSKI',
    'Nadzor i briga o bezbednosti posetilaca bazena.',
    'Vazeca licenca za spasioca.',
    85000, 110000, DATE '2026-03-15', DATE '2026-04-15', 'ZATVOREN'
);

-- ============================================================
-- POSEBNI PODACI ZA OGLASE
-- ============================================================

INSERT INTO OGLAS_PRIVREMENI (
    OGLAS_ID, PROJEKAT, DATUM_POCETKA, DATUM_ZAVRSETKA
)
SELECT
    OGLAS_ID, 'Modernizacija sistema e-Uprave',
    DATE '2026-08-01', DATE '2027-01-31'
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Frontend Developer na projektu e-Uprava';

INSERT INTO OGLAS_PRIVREMENI (
    OGLAS_ID, PROJEKAT, DATUM_POCETKA, DATUM_ZAVRSETKA
)
SELECT
    OGLAS_ID, 'Migracija podataka u centralnu bazu',
    DATE '2026-05-15', DATE '2026-11-15'
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Administrator baze na migraciji podataka';

INSERT INTO OGLAS_PRAKSA (
    OGLAS_ID, MENTOR_IME, MENTOR_PREZIME, DUZINA_TRAJANJA
)
SELECT OGLAS_ID, 'Marko', 'Jovanovic', 6
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Praksa za softverskog inzenjera';

INSERT INTO OGLAS_PRAKSA (
    OGLAS_ID, MENTOR_IME, MENTOR_PREZIME, DUZINA_TRAJANJA
)
SELECT OGLAS_ID, 'Jelena', 'Petrovic', 3
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Praksa za QA testera';

INSERT INTO OGLAS_SEZONSKI (OGLAS_ID, SEZONA, LOKACIJA)
SELECT OGLAS_ID, 'ZIMA 2026/2027', 'Kopaonik'
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Recepcioner u hotelu';

INSERT INTO OGLAS_SEZONSKI (OGLAS_ID, SEZONA, LOKACIJA)
SELECT OGLAS_ID, 'LETO 2026', 'Nis'
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Spasilac na bazenu';

-- ============================================================
-- BIOGRAFIJE KANDIDATA
-- ============================================================

INSERT INTO CV (
    DATUM_PODNOSENJA, STATUS, IME, PREZIME,
    EMAIL, TELEFON, OGLAS_ID
)
SELECT
    DATE '2026-06-05', 'POZVAN_NA_INTERVJU', 'Nikola', 'Nikolic',
    'nikola.nikolic@example.com', '+38164111222', OGLAS_ID
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Senior Java Developer';

INSERT INTO CV (
    DATUM_PODNOSENJA, STATUS, IME, PREZIME,
    EMAIL, TELEFON, OGLAS_ID
)
SELECT
    DATE '2026-06-07', 'U_PROCESU', 'Ana', 'Ilic',
    'ana.ilic@example.com', '+38164222333', OGLAS_ID
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Senior Java Developer';

INSERT INTO CV (
    DATUM_PODNOSENJA, STATUS, IME, PREZIME,
    EMAIL, TELEFON, OGLAS_ID
)
SELECT
    DATE '2026-05-15', 'POZVAN_NA_INTERVJU', 'Milica', 'Markovic',
    'milica.markovic@example.com', '+38164333444', OGLAS_ID
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Poslovni analiticar';

INSERT INTO CV (
    DATUM_PODNOSENJA, STATUS, IME, PREZIME,
    EMAIL, TELEFON, OGLAS_ID
)
SELECT
    DATE '2026-07-05', 'PRIMLJEN', 'Stefan', 'Pavlovic',
    'stefan.pavlovic@example.com', '+38164444555', OGLAS_ID
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Frontend Developer na projektu e-Uprava';

INSERT INTO CV (
    DATUM_PODNOSENJA, STATUS, IME, PREZIME,
    EMAIL, TELEFON, OGLAS_ID
)
SELECT
    DATE '2026-06-18', 'U_PROCESU', 'Luka', 'Stojanovic',
    'luka.stojanovic@example.com', '+38164555666', OGLAS_ID
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Praksa za softverskog inzenjera';

INSERT INTO CV (
    DATUM_PODNOSENJA, STATUS, IME, PREZIME,
    EMAIL, TELEFON, OGLAS_ID
)
SELECT
    DATE '2026-05-25', 'ODBIJEN', 'Sara', 'Djordjevic',
    'sara.djordjevic@example.com', '+38164666777', OGLAS_ID
FROM OGLAS
WHERE NAZIV_POZICIJE = 'Praksa za QA testera';

-- ============================================================
-- INTERVJUI
-- ============================================================

INSERT INTO INTERVJU (
    DATUM, VREME, TIP_INTERVJUA, LOKACIJA,
    ZAPOSLENI_IME, ZAPOSLENI_PREZIME, OCENA, NAPOMENE, CV_ID
)
SELECT
    DATE '2026-06-20', TIMESTAMP '2026-07-22 22:00:00', 'VIDEO', 'Microsoft Teams',
    'Petar', 'Petrovic', 9, 'Kandidat je pokazao veoma dobro tehnicko znanje.',
    CV_ID
FROM CV
WHERE EMAIL = 'nikola.nikolic@example.com';

INSERT INTO INTERVJU (
    DATUM, VREME, TIP_INTERVJUA, LOKACIJA,
    ZAPOSLENI_IME, ZAPOSLENI_PREZIME, OCENA, NAPOMENE, CV_ID
)
SELECT
    DATE '2026-05-28', TIMESTAMP '2026-07-22 22:00:00', 'LICNI', 'Beograd, Bulevar oslobodjenja 10',
    'Ivana', 'Simic', 8, 'Dobre analiticke i komunikacione sposobnosti.',
    CV_ID
FROM CV
WHERE EMAIL = 'milica.markovic@example.com';

INSERT INTO INTERVJU (
    DATUM, VREME, TIP_INTERVJUA, LOKACIJA,
    ZAPOSLENI_IME, ZAPOSLENI_PREZIME, OCENA, NAPOMENE, CV_ID
)
SELECT
    DATE '2026-06-28', TIMESTAMP '2026-07-22 22:00:00', 'TELEFONSKI', 'Telefonski razgovor',
    'Marko', 'Jovanovic', 7, 'Kandidat ispunjava uslove za nastavak selekcije.',
    CV_ID
FROM CV
WHERE EMAIL = 'luka.stojanovic@example.com';

-- ============================================================
-- TESTOVI
-- ============================================================

INSERT INTO TEST (
    REZULTAT, DATUM_TESTIRANJA, VRSTA_TESTIRANJA, KOMENTAR, CV_ID
)
SELECT
    92.50, DATE '2026-06-22', 'TEHNICKI TEST',
    'Odlicno poznavanje Jave i SQL-a.', CV_ID
FROM CV
WHERE EMAIL = 'nikola.nikolic@example.com';

INSERT INTO TEST (
    REZULTAT, DATUM_TESTIRANJA, VRSTA_TESTIRANJA, KOMENTAR, CV_ID
)
SELECT
    84.00, DATE '2026-05-30', 'TEST POSLOVNE ANALIZE',
    'Uspesno reseni prakticni zadaci.', CV_ID
FROM CV
WHERE EMAIL = 'milica.markovic@example.com';

INSERT INTO TEST (
    REZULTAT, DATUM_TESTIRANJA, VRSTA_TESTIRANJA, KOMENTAR, CV_ID
)
SELECT
    76.25, DATE '2026-06-30', 'TEST PROGRAMIRANJA',
    'Dobro razumevanje osnovnih koncepata.', CV_ID
FROM CV
WHERE EMAIL = 'luka.stojanovic@example.com';

-- ============================================================
-- ODLUKE
-- ============================================================

INSERT INTO ODLUKA (
    STATUS, DATUM_DONOSENJA_ODLUKE, PONUDJENA_PLATA,
    PRIHVATIO_PONUDU, DATUM_POCETKA_RADA, RAZLOG_ODBIJANJA, CV_ID
)
SELECT
    'IZABRAN', DATE '2026-06-25', 230000,
    1, DATE '2026-07-15', NULL, CV_ID
FROM CV
WHERE EMAIL = 'nikola.nikolic@example.com';

INSERT INTO ODLUKA (
    STATUS, DATUM_DONOSENJA_ODLUKE, PONUDJENA_PLATA,
    PRIHVATIO_PONUDU, DATUM_POCETKA_RADA, RAZLOG_ODBIJANJA, CV_ID
)
SELECT
    'REZERVA', DATE '2026-06-02', NULL,
    0, NULL, NULL, CV_ID
FROM CV
WHERE EMAIL = 'milica.markovic@example.com';

INSERT INTO ODLUKA (
    STATUS, DATUM_DONOSENJA_ODLUKE, PONUDJENA_PLATA,
    PRIHVATIO_PONUDU, DATUM_POCETKA_RADA, RAZLOG_ODBIJANJA, CV_ID
)
SELECT
    'ODBIJEN', DATE '2026-06-10', NULL,
    0, NULL, 'Nedovoljan rezultat na testu za ovu poziciju.', CV_ID
FROM CV
WHERE EMAIL = 'sara.djordjevic@example.com';

COMMIT;
