using Dapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataStores.Repository
{
    public class ImprumutRepository : IDataStoreImprumut
    {
        private readonly DapperContext dapperContext;

        public ImprumutRepository(string connectionString)
        {
            dapperContext = new DapperContext(connectionString);
        }
        public void AddImprumut(Imprumut imprumut)
        {
            using var connection = dapperContext.CreateConnection();

            var sql = "add_imprumut";

            var paramms = new

            {
                imprumut.ImprumutId,
                imprumut.MembruId,
                imprumut.CarteId,
                imprumut.DataImprumut
            };
            var rowsAffect = connection.Execute(sql, paramms, commandType: CommandType.StoredProcedure);
        }
        public int DeleteImprumut(int ImprumutIdToBeDeleted)
        {
            using var connection = dapperContext.CreateConnection();

            var sql = "del_imprumut";
            var paramms = new

            {
                Id = ImprumutIdToBeDeleted,
            };
            var rowsAffect = connection.Execute(sql, paramms, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }

        public List<Imprumut> GetAllImprumuturi()
        {
            using var connection = dapperContext.CreateConnection();

            var query = "get_imprumuturi";

            var imprumut = connection.Query<Imprumut>(query, commandType: CommandType.StoredProcedure);
            return imprumut.ToList();
        }

        public List<Imprumut> GetImprumutByDate(DateTime ImprumutDate)
        {
            using var connection = dapperContext.CreateConnection();
            var sql = "search_imprumut_by_date";
            var paramms = new
            {
                @DataImprumut = ImprumutDate,
            };
            var imprumut = connection.Query<Imprumut>(sql, paramms, commandType: CommandType.StoredProcedure);
            return imprumut.ToList();

           
        }

        public Imprumut GetImprumutByID(int imprumutId)
        {
            using var connection = dapperContext.CreateConnection();
            var sql = "get_imprumut";
            var paramms = new
            {
                ImprumutId = imprumutId,
            };
            var imprumut = connection.QueryFirstOrDefault<Imprumut>(sql, paramms, commandType: CommandType.StoredProcedure);
            return imprumut;
        }

        public int UpdateImprumut(string ImprumutIdToBeUpdated, string MembruId = null, string CarteId = null, string DataImprumut = null)
        {
            using var connection = dapperContext.CreateConnection();

            var sql = "upd_imprumut";


            var paramms = new
            {
                //ID = ImprumutIdToBeUpdated,
                //prenume = MembruId,
                //nume = CarteId,
                //adresa = DataImprumut,
                
            };


            var rowsAffect = connection.Execute(sql, paramms, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }
    }
}
