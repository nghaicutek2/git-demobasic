using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Login : Form
    {
        // Lớp tĩnh để mô phỏng cơ sở dữ liệu người dùng
        public static class UserDatabase
        {
            // Danh sách lưu trữ người dùng
            public static List<User> Users { get; set; } = new List<User>();
        }

        // Lớp đại diện cho một người dùng
        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        // Constructor
        public Login()
        {
            InitializeComponent();
        }

        // Trình xử lý sự kiện khi click vào pictureBox1
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Trình xử lý sự kiện khi form tải
        private void Login_Load(object sender, EventArgs e)
        {
            // Thêm người dùng mẫu vào cơ sở dữ liệu người dùng để kiểm tra đăng nhập
            UserDatabase.Users.Add(new User { Username = "admin", Password = "admin123" });
        }

        // Trình xử lý sự kiện khi click vào link đăng ký
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        // Trình xử lý sự kiện khi click vào link thứ hai
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        // Trình xử lý sự kiện khi click vào nút đăng nhập
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text;

            // Kiểm tra đăng nhập hợp lệ
            if (IsValidLogin(username, password))
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Đóng form đăng nhập
                this.Hide();

                // Hiển thị form chính (MainForm)
                Main main = new Main();
                main.Show();
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác.");
            }
        }

        // Hàm kiểm tra đăng nhập hợp lệ
        private bool IsValidLogin(string username, string password)
        {
            // Kiểm tra xem tên tài khoản có tồn tại và mật khẩu có khớp hay không
            return UserDatabase.Users.Any(u => u.Username == username && u.Password == password);
        }

        // Thuộc tính Username
        public string Username
        {
            get { return textBoxUsername.Text; }
            set { textBoxUsername.Text = value; }
        }
    }
}
