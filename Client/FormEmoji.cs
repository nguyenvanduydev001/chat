using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FormEmoji : Form
    {
        public event Action<string> OnEmojiSelected;

        public FormEmoji()
        {
            InitializeComponent();
            LoadEmojis();
        }

        private void FormEmoji_Load(object sender, EventArgs e)
        {
        }

        // Danh sách các emoji Unicode
        string[] emojis = new string[]
        {
            "\U0001F600", "\U0001F609", "\U0001F44D", "\U0001F622", "\U0001F60E",
            "\U0001F618", "\U0001F60D", "\U0001F61E", "\U0001F636", "\U0001F910",
            "\U0001F496", "\U0001F319", "\U0001F525", "\U0001F4A9", "\U0001F4A3",
            "\U0001F4A8", "\U0001F4A6", "\U0001F4A5", "\U0001F4AB", "\U0001F4AC",
            "\U0001F4AD", "\U0001F6C0", "\U0001F6C1", "\U0001F6C2", "\U0001F6C3",
            "\U0001F6C4", "\U0001F6C5", "\U0001F6CB", "\U0001F6CC", "\U0001F6CD",
            "\U0001F44F", "\U0001F631", "\U0001F637", "\U0001F639", "\U0001F61C",
            "\U0001F633", "\U0001F643", "\U0001F923", "\U0001F602", "\U0001F609",
            "\U0001F615", "\U0001F635", "\U0001F631", "\U0001F616", "\U0001F624",
            "\U0001F60B", "\U0001F607", "\U0001F62D", "\U0001F62C", "\U0001F92F",
            "\U0001F973", "\U0001F974", "\U0001F975", "\U0001F60F", "\U0001F62E",
            "\U0001F60A", "\U0001F618", "\U0001F92A", "\U0001F9D0", "\U0001F607"
        };


        // Hàm LoadEmojis để hiển thị emoji từ mảng
        private void LoadEmojis()
        {
            flowLayoutPanelEmojis.AutoScroll = true; // Bật cuộn cho FlowLayoutPanel
            flowLayoutPanelEmojis.WrapContents = true; // Cho phép xuống hàng khi không đủ không gian
            flowLayoutPanelEmojis.FlowDirection = FlowDirection.LeftToRight; // Đảm bảo emoji hiển thị từ trái sang phải
            flowLayoutPanelEmojis.AutoScrollMinSize = new Size(0, 0); // Không giới hạn chiều cao, giúp cuộn mượt mà

            // Duyệt qua mảng emoji và tạo các Label hoặc Button để hiển thị
            foreach (string emoji in emojis)
            {
                Label emojiLabel = new Label
                {
                    Text = emoji,
                    Font = new Font("Segoe UI", 20), // Phông chữ hỗ trợ emoji
                    AutoSize = true,
                    Cursor = Cursors.Hand,
                    Tag = emoji // Lưu emoji vào Tag để chọn khi nhấp
                };

                // Khi nhấp vào emoji, gọi sự kiện chọn emoji
                emojiLabel.Click += Emoji_Click;

                // Thêm emoji vào FlowLayoutPanel
                flowLayoutPanelEmojis.Controls.Add(emojiLabel);
            }
        }


        // Sự kiện khi người dùng chọn một emoji
        private void Emoji_Click(object sender, EventArgs e)
        {
            Label emojiLabel = sender as Label;
            if (emojiLabel != null)
            {
                // Gửi emoji được chọn dưới dạng Unicode
                OnEmojiSelected?.Invoke(emojiLabel.Text);
                this.Close(); // Đóng FormEmoji sau khi chọn emoji
            }
        }
    }
}
