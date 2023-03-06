CREATE DATABASE REGISTRACIJA;

CREATE TABLE dbo.registracija (
    ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Vards varchar(50) NOT NULL,
    Uzvards varchar(50) NOT NULL,
    epasts varchar(350) NOT NULL,
    parole varchar(30) NOT NULL,
    paroledivi varchar(30) NOT NUll
);

INSERT INTO dbo.registracija (Vards, Uzvards, epasts, parole, paroledivi)
VALUES ('Alise', 'Liepa', 'aliseliepa@gmail.com', 'alise123', 'alise123');

SELECT * FROM dbo.registracija