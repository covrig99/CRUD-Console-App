using Domain.Models;

namespace DataAccessLayer.DataStores
{
    public interface IDataStoreImprumut
    {
        void AddImprumut(Imprumut imprumut);
        int DeleteImprumut(int ImprumutIdToBeDeleted);
        List<Imprumut> GetAllImprumuturi();
        List<Imprumut> GetImprumutByDate(DateTime ImprumutDate);
        Imprumut GetImprumutByID(int membruId);
        int UpdateImprumut(string ImprumutIdToBeUpdated, string MembruId = null, string CarteId = null, string DataImprumut = null);
    }
}