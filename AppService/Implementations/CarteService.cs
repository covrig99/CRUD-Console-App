using DataAccessLayer.DataStores;
using Domain.Models;

namespace AppService.Implementations
{
    public class CarteService
    {

        private readonly IDataStoreCarte dataStore;

        public CarteService(IDataStoreCarte dataStore)
        {
            this.dataStore = dataStore;
        }
        public List<Carte> GetAllCarti()
        {
            return dataStore.GetAllCarti();
        }
        public Carte GetCarteByID(int IdCarte)
        {
            return dataStore.GetCarteByID(IdCarte);
        }
        public List<Carte> GetCarteByName(string carteName)
        {
            return dataStore.GetCarteByName(carteName);
        }
        public void AddCarte(Carte carte)
        {
  
            if (carte is null)
            {
                throw new ArgumentNullException(nameof(carte));
            }
            if (string.IsNullOrWhiteSpace(carte.Titlu))
            {
                throw new ArgumentException(nameof(carte.Titlu) + " is null or empty or whithesoace");
            }
            if (string.IsNullOrWhiteSpace(carte.Autor))
            {
                throw new ArgumentException(nameof(carte.Autor) + " is null or empty or whithesoace");
            }
            //if (carte.Autor = 0  )
            //{
            //    throw new ArgumentException(nameof(carte.Autor) + " is null or empty or whithesoace");
            //}
            if (carte.Titlu.Length > 50)
            {
                throw new ArgumentException(nameof(carte.Titlu) + " must not be greater then 50 characters.");
            }
            if (carte.Autor.Length > 50)
            {
                throw new ArgumentException(nameof(carte.Autor) + " must not be greater then 50 characters.");
            }


            dataStore.AddCarte(carte);

        }

        public int UpdateCarte(
               int IdCarte,
               int AnPublicare,
               string Titlu = null,
               string Autor = null,
               string Categorie = null)
        {
            return dataStore.UpdateCarte(IdCarte, AnPublicare, Titlu, Autor, Categorie);
        }

        public int DeleteCarte(
                   int carteIdToBeDeleted)
        {
            return dataStore.DeleteCarte(carteIdToBeDeleted);
        }


    }
}
