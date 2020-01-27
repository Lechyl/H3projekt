using System;
using System.Collections.Generic;
using System.Text;
using ORM.Models;

namespace ORM.Interface
{
    public interface IORM
    {

        //-----------------------------------------Adresse_Type-----------------------------------------//
        //Get requests
        public List<Adresse_Type> GetAllAdresseType();
        public Adresse_Type GetAdresseTypeById(int id);
        //Delete requests
        public void DeleteAdresseType(Adresse_Type adresse_Type);
        //Create requests
        public void CreateAdresseType(Adresse_Type adresse_Type);
        //Update requests
        public void UpdateAdresseType(Adresse_Type adresse_Type);

        //-----------------------------------------Adresse-----------------------------------------//
        public List<Adresser> GetAllAdresse();
        public Adresser GetAdresseById(int id);
        public void DeleteAdresse(Adresser adresse);
        public void CreateAdresse(Adresser adresse);
        public void UpdateAdresse(Adresser adresse);


        //-----------------------------------------Afdelinger-----------------------------------------//
        //Get requests
        public List<Afdelinger> GetAllAfdelinger();
        public Afdelinger GetAfdelingerById(int id);
        //Delete requests
        public void DeleteAfdelinger(Afdelinger afdeling);
        //Create requests
        public void CreateAfdelinger(Afdelinger afdeling);
        //Update requests
        public void UpdateAfdelinger(Afdelinger afdeling);


        //-----------------------------------------Butikker-----------------------------------------//
        //Get requests
        public List<Butikker> GetAllButikker();
        public Butikker GetButikkerById(int id);
        //Delete requests
        public void DeleteButikker(Butikker butikker);
        //Create requests
        public void CreateButikker(Butikker butikker);
        //Update requests
        public void UpdateButikker(Butikker butikker);


        //-----------------------------------------Butikker_har_Vare-----------------------------------------//
        //Get requests
        public List<Butikker_har_Vare> GetAllButikker_har_Vare();
        public List<Butikker_har_Vare> GetButikkerharVareByButik(Butikker butik);
        //Delete requests
        public void DeleteButikkerharVare(Butikker_har_Vare butikker_Har_Vare);
        //Create requests
        public void CreateButikkerharVare(Butikker_har_Vare butikker_har_Vare);
        //Update requests
        public void UpdateButikkerharVare(Butikker_har_Vare butikker_har_Vare);

        //-----------------------------------------Kategorier-----------------------------------------//
        //Get requests
        public List<Kategorier> GetAllKategorier();
        public Kategorier GetKategorierById(int id);
        //Delete requests
        public void DeleteKategorier(Kategorier kategorier);
        //Create requests
        public void CreateKategorier(Kategorier kategorier);
        //Update requests
        public void UpdateKategorier(Kategorier kategorier);

        //-----------------------------------------Kunder-----------------------------------------//
        //Get requests
        public List<Kunder> GetAllKunder();
        public Kunder GetKunderById(int id);
        //Delete requests
        public void DeleteKunder(Kunder kunder);
        //Create requests
        public void CreateKunder(Kunder kunder);
        //Update requests
        public void UpdateKunder(Kunder kunder);


        //-----------------------------------------Kunder_har_Adresser-----------------------------------------//
        //Get requests
        public List<Kunder_har_Adresser> GetAllKunderharAdresser();
        public List<Kunder_har_Adresser> GetKunderharAdresserByKunde(Kunder kunde);
        //Delete requests
        public void DeleteKunderharAdresser(Kunder_har_Adresser kunder_Har_Adresser);
        //Create requests
        public void CreateKunderharAdresser(Kunder_har_Adresser kunder_har_Adresser);
        //Update requests
        public void UpdateKunderharAdresser(Kunder_har_Adresser kunder_har_Adresser);


        //-----------------------------------------Lager_Status-----------------------------------------//
        //Get requests
        public List<Lager_Status> GetAllLagerStatus();
        public Lager_Status GetLagerStatusById(int id);
        //Delete requests
        public void DeleteLagerStatus(Lager_Status lager_Status);
        //Create requests
        public void CreateLagerStatus(Lager_Status lager_Status);
        //Update requests
        public void UpdateLagerStatus(Lager_Status lager_Status);

        //-----------------------------------------Leverandor-----------------------------------------//
        //Get requests
        public List<Leverandor> GetAllLeverandor();
        public Leverandor GetLeverandorById(int id);
        //Delete requests
        public void DeleteLeverandor(Leverandor leverandor);
        //Create requests
        public void CreateLeverandor(Leverandor leverandor);
        //Update requests
        public void UpdateLeverandor(Leverandor leverandor);


        //-----------------------------------------Medarbejder-----------------------------------------//
        //Get requests
        public List<Medarbejder> GetAllMedarbejder();
        public Medarbejder GetMedarbejderById(int id);
        //Delete requests
        public void DeleteMedarbejder(Medarbejder medarbejder);
        //Create requests
        public void CreateMedarbejder(Medarbejder medarbejder);
        //Update requests
        public void UpdateMedarbejder(Medarbejder medarbejder);

        //-----------------------------------------Ordre-----------------------------------------//
        //Get requests
        public List<Ordre> GetAllOrdre();
        public Ordre GetOrdreById(int id);
        //Delete requests
        public void DeleteOrdre(Ordre ordre);
        //Create requests
        public void CreateOrdre(Ordre ordre);
        //Update requests
        public void UpdateOrdre(Ordre ordre);

        //-----------------------------------------Ordre_Leverings_Metode-----------------------------------------//
        //Get requests
        public List<Ordre_Leverings_Metode> GetAllOrdreLeveringsMetode();
        public Ordre_Leverings_Metode GetOrdreLeveringsMetodeById(int id);
        //Delete requests
        public void DeleteOrdreLeveringsMetode(Ordre_Leverings_Metode ordre_Leverings_Metode);
        //Create requests
        public void CreateOrdreLeveringsMetode(Ordre_Leverings_Metode ordre_Leverings_Metode);
        //Update requests
        public void UpdateOrdreLeveringsMetode(Ordre_Leverings_Metode ordre_Leverings_Metode);


        //-----------------------------------------Ordre_Status-----------------------------------------//
        //Get requests
        public List<Ordre_Status> GetAllOrdre_Status();
        public Ordre_Status GetOrdre_StatusById(int id);
        //Delete requests
        public void DeleteOrdre_Status(Ordre_Status ordre_Status);
        //Create requests
        public void CreateOrdre_Status(Ordre_Status ordre_Status);
        //Update requests
        public void UpdateOrdre_Status(Ordre_Status ordre_Status);

        //-----------------------------------------Ordrelinjer-----------------------------------------//
        //Get requests
        public List<Ordrelinjer> GetAllOrdrelinjer();
        public List<Ordrelinjer> GetOrdrelinjerByOrdre(Ordre ordre);
        //Delete requests
        public void DeleteOrdrelinjer(Ordrelinjer ordrelinjer);
        //Create requests
        public void CreateOrdrelinjer(Ordrelinjer ordrelinjer);
        //Update requests
        public void UpdateOrdrelinjer(Ordrelinjer ordrelinjer);

        //-----------------------------------------PostNr-----------------------------------------//
        //Get requests
        public List<PostNr> GetAllPostNr();
        public PostNr GetPostNrById(int id);
        //Delete requests
        public void DeletePostNr(PostNr postNr);
        //Create requests
        public void CreatePostNr(PostNr postNr);
        //Update requests
        public void UpdatePostNr(PostNr postNr);

        //-----------------------------------------Producent-----------------------------------------//
        //Get requests
        public List<Producent> GetAllProducent();
        public Producent GetProducentById(int id);
        //Delete requests
        public void DeleteProducent(Producent producent);
        //Create requests
        public void CreateProducent(Producent producent);
        //Update requests
        public void UpdateProducent(Producent producent);

        //-----------------------------------------Produkter-----------------------------------------//
        //Get requests
        public List<Produkter> GetAllProdukter();
        public Produkter GetProdukterById(int id);
        //Delete requests
        public void DeleteProdukter(Produkter produkter);
        //Create requests
        public void CreateProdukter(Produkter produkter);
        //Update requests
        public void UpdateProdukter(Produkter produkter);
    }
}
