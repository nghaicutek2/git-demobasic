using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public class TaiKhoan
    {
        public string Username { get; set; }
        public string MatKhau { get; set; }  // Public property

        public TaiKhoan(string username, string matKhau)
        {
            Username = username;
            MatKhau = matKhau;
        }
    }
}
