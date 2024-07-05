using System.Collections.Generic;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    internal interface Imodify
    {
        SqlCommand GetSqlCommand();
        List<TaiKhoan> GetTaiKhoans(string query);
    }
}