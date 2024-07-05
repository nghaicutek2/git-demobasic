using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp4
{
    public partial class Forgotpassword : Form
    {
        public Forgotpassword()
        {
            InitializeComponent();
            label4.Text = " ";
        }

        private void Forgotpassword_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox3.Text;
            if (email.Trim() == "")
            {
                MessageBox.Show("vui nhập email lại!");
                return;
            } else
            {
                string query = "select * from information where  Email ='" + email + "'";
                if (Modify.GetTaiKhoans(query).Count != 0)
                {
                    label3.ForeColor = Color.Blue;
                    label3.Text = "Mật Khẩu: " + Modify.GetTaiKhoans(query)[0].MatKhau;
                } else
                {
                    label3.ForeColor = Color.Blue;
                    label3.Text = "email này chưa được đăng kí ";

                }
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
