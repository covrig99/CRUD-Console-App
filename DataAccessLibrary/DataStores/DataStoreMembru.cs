using System.Data.SqlClient;
using System.Data;
using Domain.Models;

namespace DataAccessLayer.DataStores
{
    public class DataStoreMembru : IDataStoreMembru
    {
        private readonly string connectionString;

        public DataStoreMembru(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Membru> GetAllMembri()
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = new SqlCommand("SELECT * FROM Membru", sqlConnection);
            using SqlDataReader reader = command.ExecuteReader();
            var membri = new List<Membru>();

            while (reader.Read())
            {
                membri.Add(new Membru()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Prenume = reader["Prenume"].ToString(),
                    Nume = reader["Nume"].ToString(),
                    Adresa = reader["Adresa"].ToString(),
                    NumarTelefon = reader["NumarTelefon"].ToString(),
                });
            }
            return membri;
        }
        public Membru GetMembruByID(int Id)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = new SqlCommand("SELECT * FROM Membru WHERE Id = @Id", sqlConnection);
            command.Parameters.AddWithValue("@Id", Id);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                var membru = new Membru()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Prenume = reader["Prenume"].ToString(),
                    Nume = reader["Nume"].ToString(),
                    Adresa = reader["Adresa"].ToString(),
                    NumarTelefon = reader["NumarTelefon"].ToString(),
                };
                return membru;
            }
            return default;

        }
         public List<Membru> GetMembruByName(string membruName)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString); 
            sqlConnection.Open();

            using SqlCommand command = new SqlCommand("search_membru_by_name", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Prenume" ,membruName + "%");

            using SqlDataReader reader = command.ExecuteReader();

            var membru = new List<Membru>();

            while (reader.Read())
            {
                membru.Add(new Membru()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Prenume = reader["Prenume"].ToString(),
                    NumarTelefon = reader["NumarTelefon"].ToString(),
                });
            }

            return membru;
        }


        public void  AddPerson(Membru membru1)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = new SqlCommand("add_membru", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", membru1.Id);
            command.Parameters.AddWithValue("@Prenume", membru1.Prenume);
            command.Parameters.AddWithValue("@Nume", membru1.Nume);
            command.Parameters.AddWithValue("@Adresa", membru1.Adresa);
            command.Parameters.AddWithValue("@NumarTelefon", membru1.NumarTelefon);
            command.ExecuteNonQuery();

            
        }
        public int UpdateMembru(
           int membruIdToBeUpdated,
           string Prenume = null,
           string Nume = null,
           string Adresa = null,
           string NumarTelefon = null)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = new SqlCommand("upd_membru", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", membruIdToBeUpdated);
            command.Parameters.AddWithValue("@Prenume", Prenume);
            command.Parameters.AddWithValue("@Nume", Nume);
            command.Parameters.AddWithValue("@Adresa", Adresa);
            command.Parameters.AddWithValue("@numar_telefon", NumarTelefon);
            var rowsAfected = command.ExecuteNonQuery();
            Console.WriteLine("Rows Affected: " + rowsAfected);
            return rowsAfected;
        }
        public int DeleteMembru(
                   int membruIdToBeDeleted)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = new SqlCommand("del_membru", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", membruIdToBeDeleted);
            var rowsAfected = command.ExecuteNonQuery();
            Console.WriteLine("Rows Affected: " + rowsAfected);
            return membruIdToBeDeleted;
        }

    }
}