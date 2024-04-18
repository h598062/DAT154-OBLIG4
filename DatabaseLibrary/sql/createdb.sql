DROP TABLE IF EXISTS oblig4.bookingdata;
DROP TABLE IF EXISTS oblig4.romdata;
DROP TABLE IF EXISTS oblig4.prisdata;

-- Tabell for å lagre prisdata for de forskjellige kvalitetene på rommene
CREATE TABLE oblig4.prisdata
(
    kvalitet VARCHAR(255) NOT NULL PRIMARY KEY,
    pris     INT          NOT NULL
);

-- Tabell for å lagre de forskjellige rommene
CREATE TABLE oblig4.romdata
(
    id            int IDENTITY (1,1) NOT NULL PRIMARY KEY,
    kvalitet      VARCHAR(255)       NOT NULL REFERENCES oblig4.prisdata (kvalitet),
    antall_senger INT                NOT NULL
);

-- Bruker tabell
CREATE TABLE oblig4.brukere
(
    id    int IDENTITY (1,1) NOT NULL PRIMARY KEY,
    epost TEXT               NOT NULL,
    name  TEXT               NOT NULL,
    tlf   TEXT,
    passwordHash TEXT       NOT NULL,
    salt TEXT               NOT NULL
);

-- Ansatt tabell
CREATE TABLE oblig4.ansatte
(
    id    int IDENTITY (1,1) NOT NULL PRIMARY KEY,
    epost TEXT               NOT NULL,
    navn  TEXT               NOT NULL,
    tlf   TEXT,
    passwordHash TEXT       NOT NULL,
    salt TEXT               NOT NULL
);

-- Tabell for å lagre bookingdata
CREATE TABLE oblig4.bookingdata
(
    id              INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    rom_id          INT                NOT NULL REFERENCES oblig4.romdata (id),
    startdato       DATETIME           NOT NULL,
    sluttdato       DATETIME           NOT NULL,
    antall_personer INT                NOT NULL,
    bruker          INT                NOT NULL,
    FOREIGN KEY (bruker) REFERENCES oblig4.brukere (id)
);

