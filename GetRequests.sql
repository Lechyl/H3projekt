use LongigantenDB;
/*
select Adresser.id,adresse,etage,pn.id,pn.byNavn from Adresser 
inner join PostNr as pn on pn.id = postnrID
where Adresser.id = 1

select id,type from Adresse_Type where id = 1
*/
--select a1.id,a1.afdeling,a2.id,a2.afdeling from Afdelinger as a1 left join Afdelinger a2 on a2.id = a1.parent_Afdeling where a1.id = 1
/*
select b.id,adr.id,adr.adresse,adr.etage,pn.id,pn.byNavn from Butikker as b inner join Adresser as adr on adr.id = b.adresseID  inner join PostNr as pn on pn.id = adr.postnrID where b.id = 1

select produktID,p.,butikID,statusID,antal from Butikker_har_Vare as bhv
inner join Produkter p on p.id = bhv.produktID
inner join Butikker b on b.id = bhv.butikID
inner join Lager_Status ls on ls.id = bhv.statusID
where butikID = 1
*/
/*
select k1.id,k1.navn,k2.id,k2.navn from Kategorier as k1 left join Kategorier k2 on k1.parent_KategoriID = k2.id where k1.id = 1

select id,producentNavn from Producent where id = 1

select id,leverandorNavn,kontaktPerson,email,telefon from Leverandor where id = 1

select id,produktNavn,beskrivelse,pris,kategoriID,producentID,leverandorID from Produkter where id = 1

select id,status from Lager_Status where id = 1
select produktID,butikID,statusID,antal from Butikker_har_Vare where butikID = 1
select id,fornavn,efternavn,kontonr,reg,email,telefon,adresseID,afdelingID,butikID from Medarbejder where id = 1
select id,fornavn,efternavn,email,telefon from kunder where id = 1
	select adresseID,kundeID,adresseType from Kunder_har_Adresser where kundeID = 1
select id,status from Ordre_Status where id = 1
select id,metodeNavn,pris from Ordre_Leverings_Metode where id = 1
select id,opretsDato,kundeID,leveringsMetodeID,leveringsAdresseID,statusID from Ordre where id = 1
select id,byNavn from PostNr where id = @id
select produktID,ordreID,antal,pris from Ordrelinjer where ordreID = 1
select a1.id,a1.afdeling,a2.id,a2.afdeling from Afdelinger as a1 left join Afdelinger a2 on a2.id = a1.parent_Afdeling
select b.id,adr.id,adr.adresse,adr.etage,pn.id,pn.byNavn from Butikker as b inner join Adresser as adr on adr.id = b.adresseID  inner join PostNr as pn on pn.id = adr.postnrID
*/
/*
select p.id,p.produktNavn,p.beskrivelse,p.pris,k.id,k.navn,k2.id,k2.navn,pc.id,pc.producentNavn,lv.id,lv.leverandorNavn,lv.kontaktPerson,lv.email,lv.telefon,b.id as butikid,adr.id,psn.id,psn.byNavn,adr.adresse,adr.etage,lg.id,lg.status, bhv.antal from Butikker_har_Vare as bhv
inner join Produkter p on p.id = bhv.produktID
inner join Kategorier k on k.id = p.kategoriID 
left join Kategorier k2 on k2.id = k.parent_KategoriID
inner join Producent pc on pc.id = p.producentID
inner join Leverandor lv on lv.id = p.leverandorID
inner join Butikker b on b.id = bhv.butikID
inner join Adresser adr on adr.id = b.adresseID
inner join PostNr psn on psn.id = adr.postnrID
inner join Lager_Status lg on lg.id = bhv.statusID

select id,fornavn,efternavn,email,telefon from Kunder

select a.id,a.navn,a.parent_KategoriID,b.navn,b.parent_KategoriID from Kategorier as a
left join Kategorier as b on b.id = a.parent_KategoriID
select id,status from Lager_Status
select id,leverandorNavn,kontaktPerson,email,telefon from Leverandor
select adresseID,kundeID,adresseType from Kunder_har_Adresser
select id,fornavn,efternavn,kontonr,reg,email,telefon,adresseID,afdelingID,butikID from Medarbejder
select id,opretsDato,kundeID,leveringsMetodeID,leveringsAdresseID,statusID from Ordre
select id,metodeNavn,pris from Ordre_Leverings_Metode
select id,status from Ordre_Status
select produktID,ordreID,antal,pris from Ordrelinjer
select id,byNavn from PostNr
select id,produktNavn,beskrivelse,pris,kategoriID,producentID,leverandorID from Produkter
select id,producentNavn from Producent
Delete from Adresse_Type where id =
select id,produktNavn,beskrivelse,pris,kategoriID,producentID,leverandorID from Produkter where producentID = 5
select id,fornavn,efternavn,email,telefon from Kunder where email like '%9%@%'
select id,fornavn,efternavn,email,telefon from Kunder
select adresseID,kundeID,adresseType from Kunder_har_Adresser where kundeID = 19*
alter table Medarbejder
add dateOfBirth date
select * from Ordre
select * from Ordre where id = 13
*/
/*

alter table Kunder
add tokens nvarchar(250)

alter table Kunder
add username nvarchar(100)

alter table Kunder
add password nvarchar(50)
select id,fornavn,efternavn,email,telefon,username,password,token from Kunder
select id,fornavn,efternavn,email,telefon,dateOfBirth,username, password from kunder where username = 'peter' and password = 'password'
Update Kunder set fornavn = @fornavn, efternavn = @efternavn, email = @email, telefon = @telefon, dateOfBirth = @dateOfBirth, password = @password where id = @id
*/
/*
update  Ordre set leveringsAdresseID = @leveringsAdresseID, leveringsMetodeID = @leveringsMetodeID, opretsDato = @opretsDato, statusID = @statusID, id

update Produkter set produktNavn = @produktNavn, beskrivelse = @beskrivelse, pris = @pris, kategoriID = @kategoriID, producentID = @producentID, leverandorID = @leverandorID

DELETE FROM Kunder WHERE id = @id

delete from Produkter where id = @id

update Adresse_Type set type = @type where id = @id

update Adresser set adresse = @address, postnrID = @postnriD, etage = @etage where id = @id

update Afdelinger set afdeling = @afdeling, parent_Afdeling = @parentAfdeling where id = @id
update Butikker set adresseID = @addressID where id = @id;
--select Kunder.id,fornavn,efternavn,email,telefon,dateOfBirth, password,Roller.rolle from kunder inner join Roller on Roller.id = rolleID where Kunder.id = 3
select id,produktNavn,beskrivelse,pris,kategoriID,producentID,leverandorID from Produkter where kategoriID = @kategoriID
*/
select p.id,p.produktNavn,p.beskrivelse,p.pris,k.id,k.navn,k2.id,k2.navn,pc.id,pc.producentNavn,lv.id,lv.leverandorNavn,lv.kontaktPerson,lv.email,lv.telefon,b.id as butikid,
adr.id,psn.id,psn.byNavn,adr.adresse,adr.etage,lg.id,lg.status,bhv.antal 
from Butikker_har_Vare as bhv
inner join Produkter p on p.id = bhv.produktID
inner join Kategorier k on k.id = p.kategoriID 
left join Kategorier k2 on k2.id = k.parent_KategoriID
inner join Producent pc on pc.id = p.producentID
inner join Leverandor lv on lv.id = p.leverandorID
inner join Butikker b on b.id = bhv.butikID
inner join Adresser adr on adr.id = b.adresseID
inner join PostNr psn on psn.id = adr.postnrID
inner join Lager_Status lg on lg.id = bhv.statusID