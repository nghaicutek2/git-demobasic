using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp4
{
    public partial class Main : Form
    {
        private TcpClient client;
        private NetworkStream stream;

        public Main()
        {
            InitializeComponent();
        }

        // Trình xử lý sự kiện khi form tải
        private void Main_Load(object sender, EventArgs e)
        {

        }

        // Gửi câu hỏi
        private async void button1_Click(object sender, EventArgs e)
        {
            if (client == null || !client.Connected)
            {
                MessageBox.Show("Vui lòng kết nối trước khi gửi câu hỏi.");
                return;
            }

            string question = txtQuestion.Text;
            if (string.IsNullOrWhiteSpace(question))
            {
                MessageBox.Show("Vui lòng nhập câu hỏi.");
                return;
            }

            try
            {
                // Tạo và gửi thông điệp đến server
                string message = $"MESSAGE|User|{question}";
                byte[] data = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(data, 0, data.Length);

                // Nhận câu trả lời từ server
                data = new byte[1024];
                int bytes = await stream.ReadAsync(data, 0, data.Length);
                string answer = Encoding.UTF8.GetString(data, 0, bytes);

                txtAnswer.Text = answer;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi/nhận câu hỏi: {ex.Message}");
            }
        }

        // Kết nối đến server
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string ipAddress = txtIpAddress.Text;
                int port = int.Parse(txtPort.Text);
                client = new TcpClient(ipAddress, port);
                stream = client.GetStream();
                MessageBox.Show("Kết nối thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        // Xử lý sự kiện khi form đóng
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            client?.Close();
        }

        // Gửi tập tin đến server
        private async Task SendFileToServer(string serverIp, int port, string filePath)
        {
            try
            {
                using (TcpClient client = new TcpClient(serverIp, port))
                using (NetworkStream networkStream = client.GetStream())
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // Gửi tên tập tin đến server
                    string fileName = Path.GetFileName(filePath);
                    string message = $"FILE|{fileName}|";
                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    await networkStream.WriteAsync(messageBytes, 0, messageBytes.Length);

                    // Gửi nội dung tập tin đến server
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await networkStream.WriteAsync(buffer, 0, bytesRead);
                    }

                    MessageBox.Show("Gửi tập tin thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        // Trình xử lý sự kiện khi click vào nút gửi tập tin
        private async void SendFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                if (client == null || !client.Connected)
                {
                    MessageBox.Show("Vui lòng kết nối trước khi gửi tập tin.");
                    return;
                }

                string filePath = textBox1.Text;
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    MessageBox.Show("Vui lòng chọn tập tin.");
                    return;
                }

                string ipAddress = txtIpAddress.Text;
                int port = int.Parse(txtPort.Text);

                await SendFileToServer(ipAddress, port, filePath);
            }
        }

        // Trình xử lý sự kiện khi textBox1 thay đổi nội dung
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Trình xử lý sự kiện khi openFileDialog hoàn thành
        private void openFileDialog_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        // Trình xử lý sự kiện khi click vào một nút (không sử dụng)
        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        // Trình xử lý sự kiện khi txtIpAddress thay đổi nội dung
        private void txtIpAddress_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = openFileDialog1.FileName;
        }
    }
}
