using DataAccessLayer.DataStores;
using DataAccessLayer.DataStores.Repository;
using Domain.Models;

namespace AppService.Implementations
{
    public class ImprumutService
    {

        private readonly IDataStoreImprumut dataStore;
       
       

        public ImprumutService(IDataStoreImprumut dataStore)
        {
            this.dataStore = dataStore;
        }

        public List<Imprumut> GetAllImprumuturi()
        {
            return dataStore.GetAllImprumuturi();
        }
        public Imprumut GetImprumutByID(int IdImprumut)
        {
            return dataStore.GetImprumutByID(IdImprumut);
        }
        public void AddImprumut(Imprumut imprumut)
        {


            dataStore.AddImprumut(imprumut);

        }

        public List<Imprumut> GetImprumutByDate(DateTime searchName)
        {
           return dataStore.GetImprumutByDate(searchName);
        }

        public int UpdateImprumut(string imprumutId, string membruId, string carteId, string data)
        {
            return dataStore.UpdateImprumut(imprumutId,membruId,carteId,data);
        }

        public int DeleteImprumut(int idsters)
        {
            return dataStore.DeleteImprumut(idsters);
        }
    }
}
