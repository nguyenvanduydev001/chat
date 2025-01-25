using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Client
{
    public partial class Client : Form
    {
        TcpClient client;
        NetworkStream stream;
        private List<string> messageHistory = new List<string>();

        public Client()
        {
            InitializeComponent();
            ConnectToServer();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            textBoxMessage.KeyDown += new KeyEventHandler(richTextBoxMessages_KeyDown);
        }
        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn ngắn kết nối server!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void richTextBoxMessages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSend_Click(sender, e);

                e.SuppressKeyPress = true;
            }
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 5000);
                stream = client.GetStream();

                Thread clientThread = new Thread(() =>
                {
                    byte[] buffer = new byte[1024];
                    while (true)
                    {
                        try
                        {
                            int bytesRead = stream.Read(buffer, 0, buffer.Length);
                            if (bytesRead == 0) break;

                            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            string timeStamp = DateTime.Now.ToString("HH:mm:ss");

                            if (message.StartsWith("FILE:"))
                            {
                                string[] parts = message.Split(':');
                                string fileName = parts[1];
                                int fileSize = int.Parse(parts[2]);

                                string fileSizeFormatted = FormatFileSize(fileSize);

                                string formattedMessage = $"FILE: {fileName} | {fileSizeFormatted} : Server [{timeStamp}]";

                                Invoke(new Action(() =>
                                {
                                    richTextBoxMessages.SelectionAlignment = HorizontalAlignment.Right;
                                    richTextBoxMessages.AppendText($"{formattedMessage}\n");
                                    richTextBoxMessages.SelectionAlignment = HorizontalAlignment.Left;
                                }));

                                byte[] fileBuffer = new byte[fileSize];
                                int totalBytesRead = 0;

                                while (totalBytesRead < fileSize)
                                {
                                    int bytesToRead = Math.Min(fileBuffer.Length - totalBytesRead, 1024);
                                    int bytesReceived = stream.Read(fileBuffer, totalBytesRead, bytesToRead);
                                    totalBytesRead += bytesReceived;
                                }

                                string savePath = Path.Combine("D:\\University\\Nam4_1\\Lap_trinh_windowns\\CHAT\\File", fileName); // Đường dẫn lưu tệp
                                File.WriteAllBytes(savePath, fileBuffer);
                            }
                            else
                            {
                                string fullMessage = $"{message}: Server [{timeStamp}]";

                                // Thêm tin nhắn vào danh sách nhận được từ Server
                                receivedMessages.Add(fullMessage);

                                Invoke(new Action(() =>
                                {
                                    richTextBoxMessages.SelectionAlignment = HorizontalAlignment.Right;
                                    richTextBoxMessages.AppendText($"{fullMessage}\n");
                                    richTextBoxMessages.SelectionAlignment = HorizontalAlignment.Left;
                                }));
                            }
                        }
                        catch
                        {
                            break;
                        }
                    }
                });
                clientThread.IsBackground = true;
                clientThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối đến Server: {ex.Message}", "Lỗi");
            }
        }

        // Hàm để format dung lượng tệp
        private string FormatFileSize(int fileSize)
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

        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                    string message = textBoxMessage.Text;

                // Nếu có emoji, thêm emoji vào tin nhắn
                if (!string.IsNullOrEmpty(selectedEmojiPath))
                {
                    message += $" {selectedEmojiPath}";
                }

                // Gửi tin nhắn
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                stream.Write(buffer, 0, buffer.Length);

                string timeStamp = DateTime.Now.ToString("HH:mm:ss");
                string formattedMessage = $"[{timeStamp}] You : {message}";

                sentMessages.Add(formattedMessage);   

                Invoke(new Action(() =>
                    {
                        richTextBoxMessages.SelectionAlignment = HorizontalAlignment.Left;
                        richTextBoxMessages.AppendText($"{formattedMessage}\n");
                    }));

                    textBoxMessage.Clear();
                    selectedEmojiPath = "";  
            }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi gửi tin nhắn: {ex.Message}", "Lỗi");
                }
        }



        // Xóa tin nhắn của chính mình gởi, nhận 
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

            RefreshRichTextBox();
        }


        private void RefreshRichTextBox()
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


        // Gửi file
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

                        string fileInfoMessage = $"FILE:{fileName}:{fileSize}";
                        byte[] fileInfoBytes = Encoding.UTF8.GetBytes(fileInfoMessage);
                        stream.Write(fileInfoBytes, 0, fileInfoBytes.Length);

                        int offset = 0;
                        int bufferSize = 4096;  

                        while (offset < fileSize)
                        {
                            int bytesToSend = Math.Min(bufferSize, (int)(fileSize - offset));
                            stream.Write(fileData, offset, bytesToSend);
                            offset += bytesToSend;
                        }

                        string timeStamp = DateTime.Now.ToString("HH:mm:ss");
                        Invoke(new Action(() =>
                        {
                            richTextBoxMessages.AppendText($"[{timeStamp}] You : {fileName} | {fileSizeFormatted}\n");
                        }));
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
        private string FormatFileSize(long fileSize)
        {
            double sizeInBytes = fileSize;
            if (sizeInBytes < 1024)
                return $"{sizeInBytes} B";

            double sizeInKB = sizeInBytes / 1024;
            if (sizeInKB < 1024)
                return $"{sizeInKB:0.##} KB";

            double sizeInMB = sizeInKB / 1024;
            if (sizeInMB < 1024)
                return $"{sizeInMB:0.##} MB";

            double sizeInGB = sizeInMB / 1024;
            return $"{sizeInGB:0.##} GB";
        }

        // Gửi ảnh
        private void buttonSendImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Select an Image File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (Image originalImage = Image.FromFile(openFileDialog.FileName))
                        using (Image resizedImage = ResizeImage(originalImage, 200, 100))
                        {
                            string timeStamp = DateTime.Now.ToString("HH:mm:ss");
                            DisplayMessage($"[{timeStamp}] You: Sending image...");

                            using (MemoryStream ms = new MemoryStream())
                            {
                                resizedImage.Save(ms, originalImage.RawFormat);
                                byte[] imageBytes = ms.ToArray();

                                stream.Write(imageBytes, 0, imageBytes.Length); 
                                DisplayImage(resizedImage); 
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error sending image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private Image ResizeImage(Image imgToResize, int targetWidth, int targetHeight)
        {
            float ratioX = (float)targetWidth / imgToResize.Width;
            float ratioY = (float)targetHeight / imgToResize.Height;
            float ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(imgToResize.Width * ratio);
            int newHeight = (int)(imgToResize.Height * ratio);

            Bitmap newBitmap = new Bitmap(newWidth, newHeight);

            using (Graphics graphics = Graphics.FromImage(newBitmap))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(imgToResize, 0, 0, newWidth, newHeight);
            }

            return newBitmap;
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
        private void DisplayMessage(string message)
        {
            if (richTextBoxMessages.InvokeRequired)
            {
                richTextBoxMessages.Invoke(new Action(() => AppendMessage(message)));
            }
            else
            {
                AppendMessage(message);
            }
        }

        private void AppendMessage(string message)
        {
            richTextBoxMessages.AppendText(message + Environment.NewLine);
            richTextBoxMessages.ScrollToCaret();
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
    }
}
