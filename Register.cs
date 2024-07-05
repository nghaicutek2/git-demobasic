using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static WindowsFormsApp4.Login;

namespace WindowsFormsApp4
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        // Trình xử lý sự kiện khi click vào nút đăng ký
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text;
            string confirmPassword = textBoxConfirmPassword.Text;

            // Kiểm tra xem các trường thông tin có bị trống không
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem mật khẩu và xác nhận mật khẩu có khớp không
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem tên tài khoản đã tồn tại chưa
            if (IsExistingUser(username))
            {
                MessageBox.Show("Tên tài khoản đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm người dùng mới vào cơ sở dữ liệu người dùng
            Login.UserDatabase.Users.Add(new Login.User { Username = username, Password = password });

            MessageBox.Show("Đăng ký thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        // Hàm kiểm tra xem tên tài khoản đã tồn tại chưa
        private bool IsExistingUser(string username)
        {
            return Login.UserDatabase.Users.Any(u => u.Username == username);
        }
    }
}
