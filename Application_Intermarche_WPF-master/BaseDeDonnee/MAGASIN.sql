﻿CREATE TABLE MAGASIN
(
	[NUM_MAGASIN] INT NOT NULL PRIMARY KEY, 
    [NOM_MAGASIN] VARCHAR(50) NOT NULL, 
    [ADRESSE_RUE_MAGASIN] VARCHAR(200) NULL, 
    [ADRESSE_CP_MAGASIN] CHAR(5) NULL, 
    [ADRESSE_VILLE_MAGASIN] VARCHAR(50) NULL, 
    [HORAIRE_MAGASIN] VARCHAR(20) NULL
)