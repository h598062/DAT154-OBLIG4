DROP TABLE IF EXISTS oblig4.bookingdata;
DROP TABLE IF EXISTS oblig4.romdata;
DROP TABLE IF EXISTS oblig4.prisdata;


CREATE TABLE oblig4.prisdata
(
    kvalitet VARCHAR(255) NOT NULL PRIMARY KEY,
    pris     INT          NOT NULL
);


CREATE TABLE oblig4.romdata
(
    id            int IDENTITY (1,1) NOT NULL PRIMARY KEY,
    kvalitet      VARCHAR(255)       NOT NULL REFERENCES oblig4.prisdata (kvalitet),
    antall_senger INT                NOT NULL
);

CREATE TABLE oblig4.bookingdata
(
    id              INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    rom_id          INT                NOT NULL REFERENCES oblig4.romdata (id),
    startdato       DATETIME           NOT NULL,
    sluttdato       DATETIME           NOT NULL,
    antall_personer INT                NOT NULL,
    bruker          VARCHAR(255)       NOT NULL
);
-- Oppdater bruker til å være foreign key mot en brukertabell, bruker epost som primærnøkkel