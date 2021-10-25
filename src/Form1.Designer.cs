namespace CroakTranslator
{
    partial class TIdentifier
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TIdentifier));
            this.OPbutton = new System.Windows.Forms.Button();
            this.JPbutton = new System.Windows.Forms.Button();
            this.appidText = new System.Windows.Forms.TextBox();
            this.keyText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LanguageBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // OPbutton
            // 
            this.OPbutton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OPbutton.Location = new System.Drawing.Point(37, 111);
            this.OPbutton.Name = "OPbutton";
            this.OPbutton.Size = new System.Drawing.Size(128, 52);
            this.OPbutton.TabIndex = 0;
            this.OPbutton.Text = "打开图片";
            this.OPbutton.UseVisualStyleBackColor = true;
            this.OPbutton.Click += new System.EventHandler(this.OPbutton_Click);
            // 
            // JPbutton
            // 
            this.JPbutton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.JPbutton.Location = new System.Drawing.Point(37, 169);
            this.JPbutton.Name = "JPbutton";
            this.JPbutton.Size = new System.Drawing.Size(128, 52);
            this.JPbutton.TabIndex = 0;
            this.JPbutton.Text = "截屏（CTRL+B）";
            this.JPbutton.UseVisualStyleBackColor = true;
            this.JPbutton.Click += new System.EventHandler(this.JPbutton_Click);
            // 
            // appidText
            // 
            this.appidText.Location = new System.Drawing.Point(88, 12);
            this.appidText.Name = "appidText";
            this.appidText.Size = new System.Drawing.Size(100, 23);
            this.appidText.TabIndex = 1;
            this.appidText.TextChanged += new System.EventHandler(this.appidText_TextChanged);
            // 
            // keyText
            // 
            this.keyText.Location = new System.Drawing.Point(88, 41);
            this.keyText.Name = "keyText";
            this.keyText.Size = new System.Drawing.Size(100, 23);
            this.keyText.TabIndex = 2;
            this.keyText.TextChanged += new System.EventHandler(this.keyText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "APP_ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(37, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "KEY :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LanguageBox
            // 
            this.LanguageBox.FormattingEnabled = true;
            this.LanguageBox.Items.AddRange(new object[] {
            "中文",
            "英语",
            "日语",
            "韩语",
            "法语",
            "西班牙语",
            "俄语",
            "葡萄牙语",
            "德语",
            "意大利语",
            "丹麦语",
            "荷兰语",
            "马来语",
            "瑞典语",
            "印尼语",
            "波兰语",
            "罗马尼亚语",
            "土耳其语",
            "希腊语",
            "匈牙利语"});
            this.LanguageBox.Location = new System.Drawing.Point(88, 70);
            this.LanguageBox.Name = "LanguageBox";
            this.LanguageBox.Size = new System.Drawing.Size(100, 25);
            this.LanguageBox.TabIndex = 5;
            this.LanguageBox.Tag = "";
            this.LanguageBox.SelectedIndexChanged += new System.EventHandler(this.LanguageBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(23, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "目标语言 :";
            // 
            // notify
            // 
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "CTranslator";
            this.notify.Visible = true;
            // 
            // TIdentifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(200, 233);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LanguageBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.keyText);
            this.Controls.Add(this.appidText);
            this.Controls.Add(this.JPbutton);
            this.Controls.Add(this.OPbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "TIdentifier";
            this.Text = "CTranslator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TIdentifier_FormClosed);
            this.Load += new System.EventHandler(this.TIdentifier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OPbutton;
        private System.Windows.Forms.Button JPbutton;
        private System.Windows.Forms.TextBox appidText;
        private System.Windows.Forms.TextBox keyText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox LanguageBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NotifyIcon notify;
    }
}

