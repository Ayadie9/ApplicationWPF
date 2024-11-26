/*==============================================================*/
/* Nom de SGBD :  PostgreSQL 8                                  */
/* Date de création :  13/05/2024 11:05:43                      */
/*==============================================================

drop table if exists ASSURANCE;
drop table if exists CARACTERISTIQUE;
drop table if exists CATEGORIE_VEHICULE;
drop table if exists CLIENT;
drop table if exists DETAIL_CARACTERISTIQUE;
drop table if exists DETAIL_RESERVATION;
drop table if exists EMPLOYE;
drop table if exists MAGASIN;
drop table if exists RESERVATION;
drop table if exists VEHICULE;
*/



/*==============================================================*/
/* Table : ASSURANCE                                            */
/*==============================================================*/
create table ASSURANCE (
   NUM_ASSURANCE        INT4                 not null,
   DESCRIPTION_ASSURANCE VARCHAR(30)          null,
   PRIX_ASSURANCE       INT2                 null,
   constraint PK_ASSURANCE primary key (NUM_ASSURANCE)
);

/*==============================================================*/
/* Table : CARACTERISTIQUE                                      */
/*==============================================================*/
create table CARACTERISTIQUE (
   NUM_CARACTERISTIQUE  INT4                 not null,
   NOM_CARACTERISTIQUE  VARCHAR(30)          null,
   constraint PK_CARACTERISTIQUE primary key (NUM_CARACTERISTIQUE)
);

/*==============================================================*/
/* Table : CATEGORIE_VEHICULE                                   */
/*==============================================================*/
create table CATEGORIE_VEHICULE (
   NOM_CATEGORIE        VARCHAR(30)          not null,
   constraint PK_CATEGORIE_VEHICULE primary key (NOM_CATEGORIE)
);

/*==============================================================*/
/* Table : CLIENT                                               */
/*==============================================================*/
create table CLIENT (
   NUM_CLIENT           SERIAL               not null,
   NOM_CLIENT           VARCHAR(50)          null,
   PRENOM_CLIENT	VARCHAR(50)	     null,
   ADRESSE_RUE_CLIENT    VARCHAR(200)        null,
   ADRESSE_CP_CLIENT    CHAR(5)              null,
   ADRESSE_VILLE_CLIENT VARCHAR(50)          null,
   TELEPHONE_CLIENT     CHAR(10)             null,
   MAIL_CLIENT          VARCHAR(150)         null,
   ESTPARTICULIER	BOOL		     not null,
   constraint PK_CLIENT primary key (NUM_CLIENT)
);

/*==============================================================*/
/* Table : DETAIL_CARACTERISTIQUE                               */
/*==============================================================*/
create table DETAIL_CARACTERISTIQUE (
   IMMATRICULATION      CHAR(7)              not null,
   NUM_CARACTERISTIQUE  INT4                 not null,
   VALEUR_CARACTERISTIQUE VARCHAR(20)          null,
   constraint PK_DETAIL_CARACTERISTIQUE primary key (IMMATRICULATION, NUM_CARACTERISTIQUE)
);

/*==============================================================*/
/* Table : DETAIL_RESERVATION                                   */
/*==============================================================*/
create table DETAIL_RESERVATION (
   IMMATRICULATION      CHAR(7)              not null,
   NUM_RESERVATION      INT4                 not null,
   constraint PK_DETAIL_RESERVATION primary key (IMMATRICULATION, NUM_RESERVATION)
);

/*==============================================================*/
/* Table : EMPLOYE                                              */
/*==============================================================*/
create table EMPLOYE (
   NUM_EMPLOYE          SERIAL               not null,
   NUM_MAGASIN          INT4                 not null,
   LOGIN                CHAR(6)              null,
   MDP                  VARCHAR(10)          null,
   constraint PK_EMPLOYE primary key (NUM_EMPLOYE)
);

/*==============================================================*/
/* Table : MAGASIN                                              */
/*==============================================================*/
create table MAGASIN (
   NUM_MAGASIN          SERIAL               not null,
   NOM_MAGASIN          VARCHAR(50)          not null,
   ADRESSE_RUE_MAGASIN  VARCHAR(200)         null,
   ADRESSE_CP_MAGASIN   CHAR(5)              null,
   ADRESSE_VILLE_MAGASIN VARCHAR(50)          null,
   HORAIRE_MAGASIN      VARCHAR(20)          null,
   constraint PK_MAGASIN primary key (NUM_MAGASIN)
);

/*==============================================================*/
/* Table : RESERVATION                                          */
/*==============================================================*/
create table RESERVATION (
   NUM_RESERVATION      SERIAL               not null,
   NUM_ASSURANCE        INT4                 not null,
   NUM_CLIENT           INT4                 not null,
   DATE_RESERVATION     DATE                 null,
   DATE_DEBUT_RESERVATION DATE                 null,
   DATE_FIN_RESERVATION DATE                 null,
   MONTANT_RESERVATION  DECIMAL(8,2)         null,
   FORFAIT_KM           CHAR(10)             null,
   constraint PK_RESERVATION primary key (NUM_RESERVATION)
);

/*==============================================================*/
/* Table : VEHICULE                                             */
/*==============================================================*/
create table VEHICULE (
   IMMATRICULATION      CHAR(7)              not null,
   TYPE_BOITE           VARCHAR(30)          not null,
   NUM_MAGASIN          INT4                 not null,
   NOM_CATEGORIE        VARCHAR(30)          not null,
   NOM_VEHICULE         VARCHAR(50)          not null,
   DESCRIPTION_VEHICULE VARCHAR(300)         null,
   NOMBRE_PLACES        INT4                 not null,
   PRIX_LOCATION        DECIMAL(5,2)         not null,
   CLIMATISATION        BOOL                 not null,
   LIEN_PHOTO_URL       VARCHAR(100)         null,
   constraint PK_VEHICULE primary key (IMMATRICULATION)
);

alter table DETAIL_CARACTERISTIQUE
   add constraint FK_DETAIL_C_DETAIL_CA_VEHICULE foreign key (IMMATRICULATION)
      references VEHICULE (IMMATRICULATION)
      on delete restrict on update restrict;

alter table DETAIL_CARACTERISTIQUE
   add constraint FK_DETAIL_C_DETAIL_CA_CARACTER foreign key (NUM_CARACTERISTIQUE)
      references CARACTERISTIQUE (NUM_CARACTERISTIQUE)
      on delete restrict on update restrict;

alter table DETAIL_RESERVATION
   add constraint FK_DETAIL_R_DETAIL_RE_VEHICULE foreign key (IMMATRICULATION)
      references VEHICULE (IMMATRICULATION)
      on delete restrict on update restrict;

alter table DETAIL_RESERVATION
   add constraint FK_DETAIL_R_DETAIL_RE_RESERVAT foreign key (NUM_RESERVATION)
      references RESERVATION (NUM_RESERVATION)
      on delete restrict on update restrict;

alter table EMPLOYE
   add constraint FK_EMPLOYE_EST_LIE_MAGASIN foreign key (NUM_MAGASIN)
      references MAGASIN (NUM_MAGASIN)
      on delete restrict on update restrict;

alter table RESERVATION
   add constraint FK_RESERVAT_APPARTIEN_CLIENT foreign key (NUM_CLIENT)
      references CLIENT (NUM_CLIENT)
      on delete restrict on update restrict;

alter table RESERVATION
   add constraint FK_RESERVAT_PORTE_ASSURANC foreign key (NUM_ASSURANCE)
      references ASSURANCE (NUM_ASSURANCE)
      on delete restrict on update restrict;

alter table VEHICULE
   add constraint FK_VEHICULE_LIE_CATEGORI foreign key (NOM_CATEGORIE)
      references CATEGORIE_VEHICULE (NOM_CATEGORIE)
      on delete restrict on update restrict;

alter table VEHICULE
   add constraint FK_VEHICULE_RATTACHE_MAGASIN foreign key (NUM_MAGASIN)
      references MAGASIN (NUM_MAGASIN)
      on delete restrict on update restrict;

