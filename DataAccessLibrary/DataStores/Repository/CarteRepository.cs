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
    public class CarteRepository : IDataStoreCarte
    {
        private readonly DapperContext dapperContext;
        public CarteRepository(string connectionString)
        {
            dapperContext = new DapperContext(connectionString);
        }

        public void AddCarte(Carte carte)
        {
            using var connection = dapperContext.CreateConnection();

            var sql = "add_carte";

            var paramms = new

            {
                carte.IdCarte,
                carte.Titlu,
                carte.Autor,
                carte.AnPublicare,
                carte.Categorie

            };
            var rowsAffect = connection.Execute(sql, paramms, commandType: CommandType.StoredProcedure);
            
        }

        public int DeleteCarte(int CarteIdToBeDeleted)
        {
            using var connection = dapperContext.CreateConnection();

            var sql = "del_carte";
            var paramms = new

            {
                Id = CarteIdToBeDeleted,
            };
            var rowsAffect = connection.Execute(sql, paramms, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }

        public List<Carte> GetAllCarti()
        {
            using var connection = dapperContext.CreateConnection();

            var query = "get_carti";

            var carte = connection.Query<Carte>(query, commandType: CommandType.StoredProcedure); 
            return carte.ToList();
        }

        public Carte GetCarteByID(int IdCarte)
        {
            using var connection = dapperContext.CreateConnection();
            var sql = "get_carte";
            var paramms = new
            {
                Id = IdCarte
            };
            var carte = connection.QueryFirstOrDefault<Carte>(sql, paramms, commandType: CommandType.StoredProcedure);
            return carte;
        }

        public List<Carte> GetCarteByName(string carteName)
        {
            using var connection = dapperContext.CreateConnection();
            var sql = "search_carte_by_name";
            var paramms = new
            {
                @Titlu = carteName
            };
            var carte = connection.Query<Carte>(sql, paramms, commandType: CommandType.StoredProcedure);
            return carte.ToList();
        }

        public int UpdateCarte(int CarteIdToBeUpdated, int AnPublicare, string Titlu = null, string Autor = null, string Categorie = null)
        {
            using var connection = dapperContext.CreateConnection();

            var sql = "upd_carte";


            var paramms = new
            {
                Id = CarteIdToBeUpdated,
                Anpublicare = AnPublicare,
                Titlu = Titlu,
                Autor = Autor,
                Categorie = Categorie
            };
            var rowsAffect = connection.Execute(sql, paramms, commandType: CommandType.StoredProcedure);
            return rowsAffect;
        }
    }
}
