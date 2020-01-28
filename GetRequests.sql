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
*/
select produktID,ordreID,antal,pris from Ordrelinjer where ordreID = 1