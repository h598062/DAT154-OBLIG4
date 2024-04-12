# DAT154-OBLIG4

## Applikasjoner

### DesktopApp for Front Desk

Lages med WPF. Bruker DatabaseLibrary for å hente data fra databasen.

### WebApp for Booking

Lages med Blazor. Bruker DatabaseLibrary for å hente data fra databasen.

### App for Cleaning Personell

Lages med MAUI. Bruker DatabaseLibrary for å hente data fra databasen.

### DatabaseLibrary

Klasser for å hente data fra databasen.
Bruker Entity Framework Core og scaffolding for å generere klassene.

## Database

Tabell med romdata:

`id | kvalitet | antall_senger`
id er PK

Tabell med bookingdata:

`id | rom_id | startdato | sluttdato | antall_personer`
id er PK, rom_id er FK fra romdata

Tabell med prisdata:

`kvalitet | pris`
kvalitet blir PK og FK i romdata

Tabell med kunde-brukere:

`id | navn | telefon | epost | passord_hash | passord_salt`