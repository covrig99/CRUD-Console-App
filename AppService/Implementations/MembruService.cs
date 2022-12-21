using DataAccessLayer.DataStores;
using Domain.Models;

namespace AppService.Implementations
{
    public class MembruService
    {
        private readonly IDataStoreMembru dataStore;

        
        public MembruService(IDataStoreMembru dataStore)
        {
            this.dataStore = dataStore;
        }
        public List<Membru> GetAllMembri()
        {
            return dataStore.GetAllMembri();
        }
        public Membru GetMembruByID(int ID)
        {
            return dataStore.GetMembruByID(ID);
        }

        public List<Membru> GetMembruByName(string membruName)
        {
            return dataStore.GetMembruByName(membruName);
        }
        public void AddPerson(Membru membru)
        {
            if (membru is null)
            {
                throw new ArgumentNullException(nameof(membru));
            }
            if (string.IsNullOrWhiteSpace(membru.Prenume))
            {
                throw new ArgumentException(nameof(membru.Prenume) + " is null or empty or whithesoace");
            }
            if (string.IsNullOrWhiteSpace(membru.Nume))
            {
                throw new ArgumentException(nameof(membru.Nume) + " is null or empty or whithesoace");
            }
            if (string.IsNullOrWhiteSpace(membru.Adresa))
            {
                throw new ArgumentException(nameof(membru.Adresa) + " is null or empty or whithesoace");
            }
            if (membru.Prenume.Length > 50)
            {
                throw new ArgumentException(nameof(membru.Prenume) + " must not be greater then 50 characters.");
            }
            if (membru.Nume.Length > 50)
            {
                throw new ArgumentException(nameof(membru.Nume) + " must not be greater then 50 characters.");
            }
          

            dataStore.AddPerson(membru);

        }

        public int UpdateMembru(
            int membruIdToBeUpdated,
            string Prenume = null,
            string Nume = null,
            string Adresa = null,
            string NumarTelefon = null)
        {
           return dataStore.UpdateMembru(membruIdToBeUpdated, Prenume, Nume, Adresa, NumarTelefon);
        }

        public int DeleteMembru(
                   int membruIdToBeDeleted)
        {
           return dataStore.DeleteMembru(membruIdToBeDeleted);
        }
        
    }
}