using System.Data.SqlClient;
using System.Data;
using Domain.Models;

namespace DataAccessLayer.DataStores
{
    public class DataStoreCarte : IDataStoreCarte
    {
        private readonly string connectionString;

        public DataStoreCarte(string connectionString)
        {
            this.connectionString = connectionString;
        }
        //h
        public List<Carte> GetAllCarti()
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = new SqlCommand("SELECT * FROM Carte", sqlConnection);
            using SqlDataReader reader = command.ExecuteReader();
            var carte = new List<Carte>();

            while (reader.Read())
            {
                carte.Add(new Carte()
                {
                    IdCarte = int.Parse(reader["Id"].ToString()),
                    Titlu = reader["Titlu"].ToString(),
                    Autor = reader["Autor"].ToString(),
                    AnPublicare = int.Parse(reader["AnPublicare"].ToString()),
                    Categorie = reader["Categorie"].ToString(),
                });
            }
            return carte;
        }
        public Carte GetCarteByID(int IdCarte)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = new SqlCommand("SELECT * FROM Carte WHERE Id = @Id", sqlConnection);
            command.Parameters.AddWithValue("@Id", IdCarte);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                var carte = new Carte()
                {
                    IdCarte = int.Parse(reader["Id"].ToString()),
                    Titlu = reader["Titlu"].ToString(),
                    Autor = reader["Autor"].ToString(),
                    AnPublicare = int.Parse(reader["AnPublicare"].ToString()),
                    Categorie = reader["Categorie"].ToString(),
                };
                return carte;
            }
            return default;

        }
        public List<Carte> GetCarteByName(string carteName)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using SqlCommand command = new SqlCommand("search_carte_by_name", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Titlu", carteName + "%");

            using SqlDataReader reader = command.ExecuteReader();

            var carte = new List<Carte>();

            while (reader.Read())
            {
                carte.Add(new Carte()
                {
                    IdCarte = int.Parse(reader["Id"].ToString()),
                    Titlu = reader["Titlu"].ToString(),
                    AnPublicare = int.Parse(reader["AnPublicare"].ToString()),
                });
            }

            return carte;
        }


        public void AddCarte(Carte carte)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = new SqlCommand("add_carte", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", carte.IdCarte);
            command.Parameters.AddWithValue("@Titlu", carte.Titlu);
            command.Parameters.AddWithValue("@Autor", carte.Autor);
            command.Parameters.AddWithValue("@AnPublicare", carte.AnPublicare);
            command.Parameters.AddWithValue("@Categorie", carte.Categorie);
            command.ExecuteNonQuery();

           
        }
        public int UpdateCarte(
           int CarteIdToBeUpdated,
           int AnPublicare,
           string Titlu = null,
           string Autor = null,
           string Categorie = null)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = new SqlCommand("upd_carte", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", CarteIdToBeUpdated);
            command.Parameters.AddWithValue("@Titlu", Titlu);
            command.Parameters.AddWithValue("@Autor", Autor);
            command.Parameters.AddWithValue("@AnPublicare", AnPublicare);
            command.Parameters.AddWithValue("@Categorie", Categorie);
            var rowsAfected = command.ExecuteNonQuery();
            Console.WriteLine("Rows Affected: " + rowsAfected);
            Console.ReadKey(true);
            return rowsAfected;
        }
        public int DeleteCarte(
                   int CarteIdToBeDeleted)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = new SqlCommand("del_carte", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", CarteIdToBeDeleted);
            var rowsAfected = command.ExecuteNonQuery();
            Console.WriteLine("Rows Affected: " + rowsAfected);
            Console.ReadKey(true);
            return rowsAfected;
        }

    }
}
