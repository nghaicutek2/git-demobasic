using System.Collections.Generic;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    class modify : Imodify
    {
        public modify()
        {
        }

        SqlCommand sqlCommand;
        SqlDataAdapter dataReader;

        public SqlCommand GetSqlCommand()
        {
            return sqlCommand;
        }

        public List<TaiKhoan> GetTaiKhoans(string query)
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();

            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            taiKhoans.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(1)));
                        }
                    }
                }
            }

            return taiKhoans; // Ensure the method returns the list
        }
        public void Command(string query)
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();

            }


        }
    }
}