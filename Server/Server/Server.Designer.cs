namespace Server
{
    partial class Server
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server));
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxMessages = new System.Windows.Forms.RichTextBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.checkedListBoxClients = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDeleteMessage = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonSendFile = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.btnEmoji = new System.Windows.Forms.Button();
            this.buttonSendImage = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.panel21 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel20.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đoạn chat";
            // 
            // richTextBoxMessages
            // 
            this.richTextBoxMessages.BackColor = System.Drawing.Color.White;
            this.richTextBoxMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxMessages.Location = new System.Drawing.Point(10, 50);
            this.richTextBoxMessages.Name = "richTextBoxMessages";
            this.richTextBoxMessages.Size = new System.Drawing.Size(590, 502);
            this.richTextBoxMessages.TabIndex = 2;
            this.richTextBoxMessages.Text = "";
            this.richTextBoxMessages.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMessage_KeyDown);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMessage.Location = new System.Drawing.Point(222, 562);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(315, 35);
            this.textBoxMessage.TabIndex = 3;
            this.textBoxMessage.TabStop = false;
            // 
            // checkedListBoxClients
            // 
            this.checkedListBoxClients.BackColor = System.Drawing.SystemColors.HighlightText;
            this.checkedListBoxClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxClients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkedListBoxClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxClients.ForeColor = System.Drawing.Color.ForestGreen;
            this.checkedListBoxClients.FormattingEnabled = true;
            this.checkedListBoxClients.Location = new System.Drawing.Point(11, 45);
            this.checkedListBoxClients.Name = "checkedListBoxClients";
            this.checkedListBoxClients.Size = new System.Drawing.Size(238, 552);
            this.checkedListBoxClients.TabIndex = 5;
            this.checkedListBoxClients.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonDeleteMessage);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.buttonSendFile);
            this.panel1.Controls.Add(this.buttonSend);
            this.panel1.Controls.Add(this.btnEmoji);
            this.panel1.Controls.Add(this.textBoxMessage);
            this.panel1.Controls.Add(this.buttonSendImage);
            this.panel1.Controls.Add(this.richTextBoxMessages);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(320, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 616);
            this.panel1.TabIndex = 9;
            // 
            // buttonDeleteMessage
            // 
            this.buttonDeleteMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteMessage.FlatAppearance.BorderSize = 0;
            this.buttonDeleteMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteMessage.Image = global::Server.Properties.Resources.trash;
            this.buttonDeleteMessage.Location = new System.Drawing.Point(13, 559);
            this.buttonDeleteMessage.Name = "buttonDeleteMessage";
            this.buttonDeleteMessage.Size = new System.Drawing.Size(50, 40);
            this.buttonDeleteMessage.TabIndex = 9;
            this.buttonDeleteMessage.TabStop = false;
            this.buttonDeleteMessage.UseVisualStyleBackColor = true;
            this.buttonDeleteMessage.Click += new System.EventHandler(this.buttonDeleteMessage_Click);
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(10, 606);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(590, 10);
            this.panel5.TabIndex = 3;
            // 
            // buttonSendFile
            // 
            this.buttonSendFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSendFile.FlatAppearance.BorderSize = 0;
            this.buttonSendFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendFile.Image = global::Server.Properties.Resources.attach_file2;
            this.buttonSendFile.Location = new System.Drawing.Point(166, 559);
            this.buttonSendFile.Name = "buttonSendFile";
            this.buttonSendFile.Size = new System.Drawing.Size(50, 40);
            this.buttonSendFile.TabIndex = 6;
            this.buttonSendFile.TabStop = false;
            this.buttonSendFile.UseVisualStyleBackColor = true;
            this.buttonSendFile.Click += new System.EventHandler(this.buttonSendFile_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.White;
            this.buttonSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSend.FlatAppearance.BorderSize = 0;
            this.buttonSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSend.Image = global::Server.Properties.Resources.paper_plane;
            this.buttonSend.Location = new System.Drawing.Point(550, 558);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(42, 41);
            this.buttonSend.TabIndex = 4;
            this.buttonSend.TabStop = false;
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // btnEmoji
            // 
            this.btnEmoji.BackColor = System.Drawing.Color.White;
            this.btnEmoji.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmoji.FlatAppearance.BorderSize = 0;
            this.btnEmoji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmoji.Image = global::Server.Properties.Resources.gif;
            this.btnEmoji.Location = new System.Drawing.Point(113, 559);
            this.btnEmoji.Name = "btnEmoji";
            this.btnEmoji.Size = new System.Drawing.Size(50, 40);
            this.btnEmoji.TabIndex = 7;
            this.btnEmoji.TabStop = false;
            this.btnEmoji.UseVisualStyleBackColor = false;
            this.btnEmoji.Click += new System.EventHandler(this.btnEmoji_Click);
            // 
            // buttonSendImage
            // 
            this.buttonSendImage.BackColor = System.Drawing.Color.White;
            this.buttonSendImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSendImage.FlatAppearance.BorderSize = 0;
            this.buttonSendImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendImage.Image = global::Server.Properties.Resources.image;
            this.buttonSendImage.Location = new System.Drawing.Point(59, 560);
            this.buttonSendImage.Name = "buttonSendImage";
            this.buttonSendImage.Size = new System.Drawing.Size(52, 39);
            this.buttonSendImage.TabIndex = 8;
            this.buttonSendImage.TabStop = false;
            this.buttonSendImage.UseVisualStyleBackColor = false;
            this.buttonSendImage.Click += new System.EventHandler(this.buttonSendImage_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(600, 44);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 572);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 572);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(610, 44);
            this.panel2.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Dock = System.Windows.Forms.DockStyle.Right;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = global::Server.Properties.Resources.phone_call;
            this.button5.Location = new System.Drawing.Point(456, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(48, 32);
            this.button5.TabIndex = 7;
            this.button5.TabStop = false;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Dock = System.Windows.Forms.DockStyle.Right;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = global::Server.Properties.Resources.zoom;
            this.button4.Location = new System.Drawing.Point(504, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(48, 32);
            this.button4.TabIndex = 6;
            this.button4.TabStop = false;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::Server.Properties.Resources.more;
            this.button3.Location = new System.Drawing.Point(552, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 32);
            this.button3.TabIndex = 5;
            this.button3.TabStop = false;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Server.Properties.Resources.server;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(10, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 32);
            this.button1.TabIndex = 1;
            this.button1.TabStop = false;
            this.button1.Text = "Server";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(600, 5);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(10, 32);
            this.panel10.TabIndex = 4;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 5);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(10, 32);
            this.panel9.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(610, 5);
            this.panel8.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 37);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(610, 5);
            this.panel7.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 42);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(610, 2);
            this.panel6.TabIndex = 0;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.White;
            this.panel11.Controls.Add(this.panel15);
            this.panel11.Controls.Add(this.panel14);
            this.panel11.Controls.Add(this.checkedListBoxClients);
            this.panel11.Controls.Add(this.panel13);
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Location = new System.Drawing.Point(69, 12);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(245, 616);
            this.panel11.TabIndex = 10;
            // 
            // panel15
            // 
            this.panel15.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel15.Location = new System.Drawing.Point(235, 44);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(10, 562);
            this.panel15.TabIndex = 3;
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(0, 44);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(10, 562);
            this.panel14.TabIndex = 2;
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(0, 606);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(245, 10);
            this.panel13.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.White;
            this.panel12.Controls.Add(this.btnAddClient);
            this.panel12.Controls.Add(this.label1);
            this.panel12.Controls.Add(this.panel19);
            this.panel12.Controls.Add(this.panel18);
            this.panel12.Controls.Add(this.panel17);
            this.panel12.Controls.Add(this.panel16);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.ForeColor = System.Drawing.Color.White;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(245, 44);
            this.panel12.TabIndex = 0;
            // 
            // btnAddClient
            // 
            this.btnAddClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddClient.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddClient.FlatAppearance.BorderSize = 0;
            this.btnAddClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddClient.Image = global::Server.Properties.Resources.compose;
            this.btnAddClient.Location = new System.Drawing.Point(186, 5);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(49, 34);
            this.btnAddClient.TabIndex = 4;
            this.btnAddClient.TabStop = false;
            this.btnAddClient.UseVisualStyleBackColor = true;
            // 
            // panel19
            // 
            this.panel19.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel19.Location = new System.Drawing.Point(10, 39);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(225, 5);
            this.panel19.TabIndex = 3;
            // 
            // panel18
            // 
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(10, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(225, 5);
            this.panel18.TabIndex = 2;
            // 
            // panel17
            // 
            this.panel17.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel17.Location = new System.Drawing.Point(235, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(10, 44);
            this.panel17.TabIndex = 1;
            // 
            // panel16
            // 
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(0, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(10, 44);
            this.panel16.TabIndex = 0;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.button10);
            this.panel20.Controls.Add(this.button9);
            this.panel20.Controls.Add(this.panel21);
            this.panel20.Controls.Add(this.button8);
            this.panel20.Controls.Add(this.button7);
            this.panel20.Controls.Add(this.button6);
            this.panel20.Controls.Add(this.button2);
            this.panel20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel20.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel20.Location = new System.Drawing.Point(0, 0);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(69, 637);
            this.panel20.TabIndex = 11;
            // 
            // button10
            // 
            this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Image = global::Server.Properties.Resources.profile;
            this.button10.Location = new System.Drawing.Point(8, 556);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(44, 33);
            this.button10.TabIndex = 18;
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Image = global::Server.Properties.Resources.sidebar;
            this.button9.Location = new System.Drawing.Point(8, 600);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(44, 33);
            this.button9.TabIndex = 17;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(103)))), ((int)(((byte)(107)))));
            this.panel21.Location = new System.Drawing.Point(16, 196);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(35, 1);
            this.panel21.TabIndex = 16;
            // 
            // button8
            // 
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Image = global::Server.Properties.Resources.box;
            this.button8.Location = new System.Drawing.Point(11, 151);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(44, 33);
            this.button8.TabIndex = 15;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Image = global::Server.Properties.Resources.messger;
            this.button7.Location = new System.Drawing.Point(11, 101);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(44, 33);
            this.button7.TabIndex = 14;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Image = global::Server.Properties.Resources.marketplace;
            this.button6.Location = new System.Drawing.Point(11, 59);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(44, 33);
            this.button6.TabIndex = 13;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.button2.Image = global::Server.Properties.Resources.chat;
            this.button2.Location = new System.Drawing.Point(12, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 33);
            this.button2.TabIndex = 12;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(944, 637);
            this.Controls.Add(this.panel20);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxMessages;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.CheckedListBox checkedListBoxClients;
        private System.Windows.Forms.Button buttonSendFile;
        private System.Windows.Forms.Button btnEmoji;
        private System.Windows.Forms.Button buttonSendImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button buttonDeleteMessage;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
    }
}

