using System.Data.SqlClient;
using System.Data;
using Domain.Models;

namespace DataAccessLayer.DataStores
{
    public class DataStoreImprumut : IDataStoreImprumut
    {
        private readonly string connectionString;

        public DataStoreImprumut(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Imprumut> GetAllImprumuturi()
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = new SqlCommand("SELECT * FROM Imprumut", sqlConnection);
            using SqlDataReader reader = command.ExecuteReader();
            var imprumut = new List<Imprumut>();

            while (reader.Read())
            {
                imprumut.Add(new Imprumut()
                {
                    MembruId = int.Parse(reader["membruId"].ToString()),
                    CarteId = int.Parse(reader["CarteId"].ToString()),
                    DataImprumut = DateTime.Parse(reader["DataImprumut"].ToString()),

                });
            }
            return imprumut;
        }
        public Imprumut GetImprumutByID(int membruId)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = new SqlCommand("SELECT * FROM Imprumut WHERE membruId = @membruId", sqlConnection);
            command.Parameters.AddWithValue("@membruId", membruId);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                var imprumut = new Imprumut()
                {
                    MembruId = int.Parse(reader["membruId"].ToString()),
                    CarteId = int.Parse(reader["CarteId"].ToString()),
                    DataImprumut = DateTime.Parse(reader["DataImprumut"].ToString()),

                };
                return imprumut;
            }
            return default;

        }
        public List<Imprumut> GetImprumutByDate(DateTime ImprumutDate)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using SqlCommand command = new SqlCommand("search_imprumut_by_date", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@DataImprumut", ImprumutDate);

            using SqlDataReader reader = command.ExecuteReader();

            var imprumut = new List<Imprumut>();

            while (reader.Read())
            {
                imprumut.Add(new Imprumut()
                {
                    ImprumutId = int.Parse(reader["ImprumutId"].ToString()),
                    DataImprumut = DateTime.Parse(reader["DataImprumut"].ToString())
                });
            }

            return imprumut;
        }
        public  void AddImprumut(Imprumut imprumut)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = new SqlCommand("add_imprumut", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@membruId", imprumut.MembruId);
            command.Parameters.AddWithValue("@CarteId", imprumut.CarteId);
            command.Parameters.AddWithValue("@DataImprumut", imprumut.DataImprumut);
            command.ExecuteNonQuery();

            
        }
        public int UpdateImprumut(
               string ImprumutIdToBeUpdated,
               string MembruId = null,
               string CarteId = null,
               string DataImprumut = null)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = new SqlCommand("upd_imprumut", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ImprumutId", ImprumutIdToBeUpdated);
            command.Parameters.AddWithValue("@MembruId", MembruId);
            command.Parameters.AddWithValue("@CarteId", CarteId);
            command.Parameters.AddWithValue("@DataImprumut", DataImprumut);
            var rowsAfected = command.ExecuteNonQuery();
            Console.WriteLine("Rows Affected: " + rowsAfected);
            Console.ReadKey(true);
            return rowsAfected;
        }
        public int DeleteImprumut(
                   int ImprumutIdToBeDeleted)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using SqlCommand command = new SqlCommand("del_imprumut", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@membruId", ImprumutIdToBeDeleted);
            var rowsAfected = command.ExecuteNonQuery();
            Console.WriteLine("Rows Affected: " + rowsAfected);
            Console.ReadKey(true);
            return rowsAfected;
        }


    }
}
