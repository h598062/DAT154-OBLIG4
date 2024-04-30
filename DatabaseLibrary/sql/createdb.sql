DROP TABLE IF EXISTS bookingdata;
DROP TABLE IF EXISTS romdata;
DROP TABLE IF EXISTS prisdata;
DROP TABLE IF EXISTS brukere;

-- Tabell for å lagre prisdata for de forskjellige kvalitetene på rommene
CREATE TABLE prisdata
(
    kvalitet VARCHAR(255) NOT NULL PRIMARY KEY,
    pris     INT          NOT NULL
);

-- Tabell for å lagre de forskjellige rommene
CREATE TABLE romdata
(
    id            int IDENTITY (1,1) NOT NULL PRIMARY KEY,
    kvalitet      VARCHAR(255)       NOT NULL,
    antall_senger INT                NOT NULL
    FOREIGN KEY (kvalitet) REFERENCES prisdata (kvalitet) ON DELETE NO ACTION ON UPDATE CASCADE
);

-- Bruker tabell
-- Denne skal linkes mot en User fra ASPNET Identity, bruk migrations for å legge til den funksjonalitet
CREATE TABLE brukere
(
    id    int IDENTITY (1,1) NOT NULL PRIMARY KEY,
    epost TEXT               NOT NULL,
    name  TEXT               NOT NULL,
    tlf   TEXT,
    AspNetUser_Id nvarchar(450) NULL DEFAULT NULL,
    FOREIGN KEY (AspNetUser_Id) REFERENCES AspNetUsers (Id) ON DELETE NO ACTION ON UPDATE CASCADE
);

-- Tabell for å lagre bookingdata
CREATE TABLE bookingdata
(
    id              INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    rom_id          INT                NOT NULL,
    startdato       DATETIME           NOT NULL,
    sluttdato       DATETIME           NOT NULL,
    antall_personer INT                NOT NULL,
    bruker          INT                NOT NULL,
    FOREIGN KEY (rom_id) REFERENCES romdata (id) ON DELETE NO ACTION ON UPDATE CASCADE,
    FOREIGN KEY (bruker) REFERENCES brukere (id) ON DELETE NO ACTION ON UPDATE CASCADE
);

