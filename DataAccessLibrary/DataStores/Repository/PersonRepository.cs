using Dapper;
using Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataStores.Repository
{
    public class PersonRepository : IDataStoreMembru
    {
        private readonly DapperContext dapperContext;

        public PersonRepository(string connectionString)
        {
            dapperContext = new DapperContext(connectionString);
        }

        public void AddPerson(Membru membru1)
        {
            using var connection = dapperContext.CreateConnection();

            var sql = "add_membru";

            var paramms = new

            {
                membru1.Id,
                membru1.Prenume,
                membru1.Nume,
                membru1.Adresa,
                membru1.NumarTelefon

            };
            var rowsAffect = connection.Execute(sql, paramms, commandType: CommandType.StoredProcedure);

        }

        public int DeleteMembru(int membruIdToBeDeleted)
        {
            using var connection = dapperContext.CreateConnection();

            var sql = "del_membru";
            var paramms = new

            { 
              Id = membruIdToBeDeleted,
            };
                var rowsAffect = connection.Execute(sql,paramms,commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }

        public List<Membru> GetAllMembri()
        {
            using var connection = dapperContext.CreateConnection();

            var query = "get_membri";

            var membru = connection.Query<Membru>(query, commandType: CommandType.StoredProcedure);
            return membru.ToList();

        }

        public Membru GetMembruByID(int Id)
        {
            using var connection = dapperContext.CreateConnection();
            var sql = "get_membru";
            var paramms = new
            {
                Id = Id
            };
            var membru = connection.QueryFirstOrDefault<Membru>(sql,paramms, commandType: CommandType.StoredProcedure);
            return membru;
                
        }

        public List<Membru> GetMembruByName(string membruName)
        {
            using var connection = dapperContext.CreateConnection();
            var sql = "search_membru_by_name";
            var paramms = new
            {
                @Prenume = membruName
            };
            var membru = connection.Query<Membru>(sql, paramms, commandType: CommandType.StoredProcedure);
            return membru.ToList();

        }

        public int UpdateMembru(int membruIdToBeUpdated, string Prenume = null, string Nume = null, string Adresa = null, string NumarTelefon = null)
        {
            using var connection = dapperContext.CreateConnection();

            var sql = "upd_membru";
            

            var paramms = new
            {
            ID = membruIdToBeUpdated,
            prenume = Prenume,
            nume = Nume,
            adresa = Adresa,
            Numartelefon = NumarTelefon
            };


            var rowsAffect = connection.Execute(sql, paramms, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }
    }
}
