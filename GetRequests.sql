use LongigantenDB;
/*
select Adresser.id,adresse,etage,pn.id,pn.byNavn from Adresser 
inner join PostNr as pn on pn.id = postnrID
where Adresser.id = 1

select id,type from Adresse_Type where id = 1
*/
--select a1.id,a1.afdeling,a2.id,a2.afdeling from Afdelinger as a1 left join Afdelinger a2 on a2.id = a1.parent_Afdeling where a1.id = 1

select b.id,adr.id,adr.adresse,adr.etage,pn.id,pn.byNavn from Butikker as b inner join Adresser as adr on adr.id = b.adresseID  inner join PostNr as pn on pn.id = adr.postnrID where b.id = 1

select produktID,butikID,statusID,antal from Butikker_har_Vare as bhv
inner join Produkter p on p.id = bhv.produktID
inner join Butikker b on b.id = bhv.butikID
inner join Lager_Status ls on ls.id = bhv.statusID
where butikID = 1