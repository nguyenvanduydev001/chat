using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using Client;

namespace Server
{
    public partial class Server : Form
    {
        TcpListener server;
        List<TcpClient> clients = new List<TcpClient>();
        private List<string> messageHistory = new List<string>();

        public Server()
        {
            InitializeComponent();
            StartServer();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            textBoxMessage.KeyDown += new KeyEventHandler(textBoxMessage_KeyDown);
        }

        private bool isServerClosed = false;

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn tắt server?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void textBoxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSend_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void StartServer()
        {
            Thread serverThread = new Thread(() =>
            {
                server = new TcpListener(IPAddress.Any, 5000);
                server.Start();

                Invoke(new Action(() =>
                {
                    richTextBoxMessages.SelectionColor = Color.Green;
                    richTextBoxMessages.AppendText("Server started...\n");
                    richTextBoxMessages.SelectionColor = richTextBoxMessages.ForeColor;
                }));

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    clients.Add(client);

                    Invoke(new Action(() => checkedListBoxClients.Items.Add(client.Client.RemoteEndPoint.ToString())));

                    Thread clientThread = new Thread(HandleClient);
                    clientThread.Start(client);
                }
            });
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[4096];

            while (true)
            {
                try
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (IsImage(buffer, bytesRead))
                    {
                        using (MemoryStream ms = new MemoryStream(buffer, 0, bytesRead))
                        {
                            Image receivedImage = Image.FromStream(ms);
                            Invoke(new Action(() => DisplayImage(receivedImage))); // Hiển thị ảnh
                        }
                    }

                    if (receivedData.StartsWith("FILE:"))
                    {
                        string[] fileInfo = receivedData.Split(':');
                        string fileName = fileInfo[1];
                        int fileSize = int.Parse(fileInfo[2]);

                        byte[] fileData = new byte[fileSize];
                        int totalBytesRead = 0;

                        while (totalBytesRead < fileSize)
                        {
                            bytesRead = stream.Read(fileData, totalBytesRead, fileSize - totalBytesRead);
                            totalBytesRead += bytesRead;
                        }

                        // Lưu tệp
                        string savePath = Path.Combine("D:\\University\\Nam4_1\\Lap_trinh_windowns\\CHAT\\File", fileName);
                        Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                        File.WriteAllBytes(savePath, fileData);

                        string formattedSize = FormatFileSize(fileSize);
                        string timeStamp = DateTime.Now.ToString("HH:mm:ss");
                        Invoke(new Action(() =>
                        {
                            richTextBoxMessages.SelectionAlignment = HorizontalAlignment.Right;
                            richTextBoxMessages.AppendText($"FILE: {fileName} | {formattedSize} : Client [{timeStamp}]\n");
                            richTextBoxMessages.SelectionAlignment = HorizontalAlignment.Left;
                        }));
                    }
                    else
                    {
                        string timeStamp = DateTime.Now.ToString("HH:mm:ss");
                        string fullMessage = $"{receivedData}: Client [{timeStamp}]";

                        receivedMessages.Add(fullMessage);

                        Invoke(new Action(() =>
                        {
                            richTextBoxMessages.SelectionAlignment = HorizontalAlignment.Right;
                            richTextBoxMessages.AppendText($"{receivedData} : Client [{timeStamp}]\n");
                            richTextBoxMessages.SelectionAlignment = HorizontalAlignment.Left;
                        }));

                        foreach (var otherClient in clients)
                        {
                            if (otherClient != client)
                            {
                                NetworkStream otherStream = otherClient.GetStream();
                                otherStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
                catch
                {
                    break;
                }
            }
            // Dọn dẹp
            if (clients.Contains(client))
            {
                clients.Remove(client);
            }

            Invoke(new Action(() =>
            {
                if (checkedListBoxClients.Items.Contains(client.Client.RemoteEndPoint.ToString()))
                {
                    checkedListBoxClients.Items.Remove(client.Client.RemoteEndPoint.ToString());
                }
            }));
        }

        private bool IsImage(byte[] data, int length)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(data, 0, length))
                {
                    Image img = Image.FromStream(ms);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void DisplayImage(Image image)
        {
            if (richTextBoxMessages.InvokeRequired)
            {
                richTextBoxMessages.Invoke(new Action(() => InsertImage(image)));
            }
            else
            {
                InsertImage(image);
            }
        }

        private void InsertImage(Image image)
        {
            Bitmap bitmap = new Bitmap(image);
            Clipboard.SetImage(bitmap);
            richTextBoxMessages.Select(richTextBoxMessages.TextLength, 0);
            richTextBoxMessages.Paste();
            richTextBoxMessages.AppendText("\n");
            bitmap.Dispose();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string message = textBoxMessage.Text + " " + selectedEmojiPath;
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            string timeStamp = DateTime.Now.ToString("HH:mm:ss");
            string fullMessage = $"[{timeStamp}] Server : {message}";

            sentMessages.Add(fullMessage);  

            foreach (string selectedClient in checkedListBoxClients.CheckedItems)
            {
                TcpClient client = clients.FirstOrDefault(c =>
                    c.Client.RemoteEndPoint.ToString() == selectedClient);

                if (client != null)
                {
                    try
                    {
                        NetworkStream stream = client.GetStream();
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() =>
                            richTextBoxMessages.AppendText($"Lỗi gửi tin nhắn đến {selectedClient}: {ex.Message}\n")));
                    }
                }
            }

            // Cập nhật giao diện sau khi gửi tin nhắn
            Invoke(new Action(() =>
            {
                richTextBoxMessages.AppendText(fullMessage + "\n");
                textBoxMessage.Clear();
            }));
        }

        private void buttonSendFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        if (!File.Exists(filePath))
                        {
                            MessageBox.Show("Tệp không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        byte[] fileData = File.ReadAllBytes(filePath);
                        string fileName = Path.GetFileName(filePath);
                        long fileSize = fileData.Length;

                        string fileSizeFormatted = FormatFileSize(fileSize);

                        if (fileSize > 3 * 1024 * 1024)
                        {
                            MessageBox.Show("Giới hạn dung lượng là 3MB", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string timeStamp = DateTime.Now.ToString("HH:mm:ss");

                        foreach (string selectedClient in checkedListBoxClients.CheckedItems)
                        {
                            TcpClient client = clients.FirstOrDefault(c =>
                                c.Client.RemoteEndPoint.ToString() == selectedClient);

                            if (client != null)
                            {
                                try
                                {
                                    NetworkStream stream = client.GetStream();

                                    byte[] nameData = Encoding.UTF8.GetBytes($"FILE:{fileName}:{fileSize}");
                                    stream.Write(nameData, 0, nameData.Length);

                                    int offset = 0;
                                    int bufferSize = 4096;

                                    while (offset < fileSize)
                                    {
                                        int bytesToSend = Math.Min(bufferSize, (int)(fileSize - offset));
                                        stream.Write(fileData, offset, bytesToSend);
                                        offset += bytesToSend;
                                    }

                                    Invoke(new Action(() =>
                                    {
                                        richTextBoxMessages.AppendText($"[{timeStamp}] Server : {fileName} | {fileSizeFormatted}\n");
                                    }));
                                }
                                catch (Exception ex)
                                {
                                    Invoke(new Action(() =>
                                        richTextBoxMessages.AppendText($"Lỗi gửi tệp tới {selectedClient}: {ex.Message}\n")));
                                }
                            }
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Lỗi khi đọc tệp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Hàm để format dung lượng tệp
        private string FormatFileSize(long fileSize)
        {
            double sizeInBytes = fileSize;
            if (sizeInBytes < 1024)
                return $"{sizeInBytes} bytes";

            double sizeInKB = sizeInBytes / 1024;
            if (sizeInKB < 1024)
                return $"{sizeInKB:0.##} KB";

            double sizeInMB = sizeInKB / 1024;
            if (sizeInMB < 1024)
                return $"{sizeInMB:0.##} MB";

            double sizeInGB = sizeInMB / 1024;
            return $"{sizeInGB:0.##} GB";
        }

        private List<string> sentMessages = new List<string>();  
        private List<string> receivedMessages = new List<string>(); 

        private void buttonDeleteMessage_Click(object sender, EventArgs e)
        {
            if (sentMessages.Count > 0)
            {
                sentMessages.RemoveAt(sentMessages.Count - 1);
            }
            else if (receivedMessages.Count > 0)
            {
                receivedMessages.RemoveAt(receivedMessages.Count - 1);
            }
            else
            {
                MessageBox.Show("Không có tin nhắn nào để xóa.", "Thông báo");
                return;
            }

            RefreshMessages();
        }
        private void RefreshMessages()
        {
            richTextBoxMessages.Clear();

            foreach (var message in sentMessages)
            {
                richTextBoxMessages.AppendText(message + "\n");
            }

            foreach (var message in receivedMessages)
            {
                richTextBoxMessages.AppendText(message + "\n");
            }
        }

        private void btnEmoji_Click(object sender, EventArgs e)
        {
            FormEmoji emojiForm = new FormEmoji();
            emojiForm.OnEmojiSelected += EmojiSelected;
            emojiForm.ShowDialog();
        }
        private string selectedEmojiPath = "";
        private void EmojiSelected(string emojiPath)
        {
            try
            {
                selectedEmojiPath += emojiPath + " "; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm emoji: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSendImage_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở hộp thoại để người dùng chọn ảnh
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff"; 
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName; 

                    byte[] imageBytes = File.ReadAllBytes(imagePath);

                    foreach (TcpClient client in clients)
                    {
                        NetworkStream stream = client.GetStream();

                        string header = $"IMG:{imageBytes.Length}\n"; 
                        byte[] headerBytes = Encoding.UTF8.GetBytes(header);
                        stream.Write(headerBytes, 0, headerBytes.Length); 

                        stream.Write(imageBytes, 0, imageBytes.Length); 

                        Invoke(new Action(() =>
                        {
                            richTextBoxMessages.AppendText("Đã gửi ảnh: " + Path.GetFileName(imagePath) + "\n");
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
