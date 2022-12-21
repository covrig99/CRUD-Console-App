using Domain.Models;

namespace DataAccessLayer.DataStores
{
    public interface IDataStoreCarte
    {
        void AddCarte(Carte carte);
        int DeleteCarte(int CarteIdToBeDeleted);
        List<Carte> GetAllCarti();
        Carte GetCarteByID(int IdCarte);
        List<Carte> GetCarteByName(string carteName);
        int UpdateCarte(int CarteIdToBeUpdated, int AnPublicare, string Titlu = null, string Autor = null, string Categorie = null);
    }
}