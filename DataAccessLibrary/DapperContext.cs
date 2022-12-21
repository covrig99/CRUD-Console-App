using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DapperContext
    {
        private readonly string connectionString;
        public DapperContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
    public IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
