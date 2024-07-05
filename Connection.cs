using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace WindowsFormsApp4
{
    internal class Connection
    {
        private static string connection = "Data Source=desktop-72pg9mc\\mysqlsever1;Initial Catalog=tempdb;Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connection);
        }
    }
}
