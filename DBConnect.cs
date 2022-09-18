using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2
{
    internal class DBConnect
    {
        private static SqlConnection conn;

        public static SqlConnection getConn()
        {
            if (conn == null)
            {
                conn = new SqlConnection(@"Initial Catalog = MCP1\SQLEXPRESS; Database = session2; User ID = sa; Password = itssb09");
            }

            return conn;
        }
    }
}
