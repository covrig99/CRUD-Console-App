using Domain.Models;

namespace DataAccessLayer.DataStores
{
    public interface IDataStoreMembru
    {
        void AddPerson(Membru membru1);
        int DeleteMembru(int membruIdToBeDeleted);
        List<Membru> GetAllMembri();
        List<Membru> GetMembruByName(string membruName);
        Membru GetMembruByID(int Id);
        int UpdateMembru(int membruIdToBeUpdated, string Prenume = null, string Nume = null, string Adresa = null, string NumarTelefon = null);
    }
}