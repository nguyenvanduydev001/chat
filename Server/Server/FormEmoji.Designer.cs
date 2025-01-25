namespace Client
{
    partial class FormEmoji
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmoji));
            this.flowLayoutPanelEmojis = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelEmojis
            // 
            this.flowLayoutPanelEmojis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelEmojis.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelEmojis.Name = "flowLayoutPanelEmojis";
            this.flowLayoutPanelEmojis.Size = new System.Drawing.Size(823, 291);
            this.flowLayoutPanelEmojis.TabIndex = 0;
            // 
            // FormEmoji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 291);
            this.Controls.Add(this.flowLayoutPanelEmojis);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEmoji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emoji";
            this.Load += new System.EventHandler(this.FormEmoji_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelEmojis;
    }
}