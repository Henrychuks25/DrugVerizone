using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Classes
{
    public class clsDBconnection
    {
        private readonly ConnectionString _connectionString;

        public clsDBconnection()
        {

        }

        public clsDBconnection(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection OpenConnection()
        {
            string constr = _connectionString.Value;
            return new SqlConnection(constr);

        }

        public SqlConnection DbConnection()
        {
            string constr = _connectionString.Value;
            return new SqlConnection(constr);
        }
    }
}
