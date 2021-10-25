using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CroakTranslator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.MaximumSize = new Size(
                Screen.GetWorkingArea(this).Width, 
                Screen.GetWorkingArea(this).Height
                );
            
            Client.GetSetting();
            appidText.Text = Client.APP_ID;
            keyText.Text = Client.KEY;
            LanguageBox.SelectedIndex = int.Parse(Client.DES);
        }

        private void OFbutton_Click(object sender, EventArgs e)
        {

            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = false;
            file.Filter = "JPG图片|*.jpg|PNG图片|*.png";
            file.ShowDialog();
            string currentImaPath = file.FileName;

            if (file.FileName != "")
            {
                Image Temp = Image.FromFile(currentImaPath);
                ImageTranslate(Temp,
                    new Point((Screen.PrimaryScreen.Bounds.Width - Temp.Width) / 2,
                    (Screen.PrimaryScreen.Bounds.Height - Temp.Height) / 2));
            };

        }

        private void SHbutton_Click(object sender, EventArgs e)
        {
            Image img = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            Graphics g = Graphics.FromImage(img);
            g.CopyFromScreen(0, 0, 0, 0, Screen.AllScreens[0].Bounds.Size);
            Form2 frm2 = new Form2();
            frm2.InitializeComponent();
            frm2.Show();
            frm2.Focus();
            frm2.Form = this;
        }
        
        public void ImageTranslate(Image image, Point point)
        {
            
            Form3 form3 = new Form3();
            form3.BackgroundImage = image;
            form3.InitializeComponent();
            form3.Size = image.Size;
            form3.StartPosition = FormStartPosition.Manual;
            form3.Location = point;
            form3.label.Font = new Font("黑体", MathF.Min(image.Size.Width, image.Size.Height)/4,FontStyle.Bold,GraphicsUnit.Pixel);
            form3.label.TextAlign = ContentAlignment.MiddleCenter;
            form3.Show();
            form3.Focus();
            Image result = Client.TransLate(image, "auto",Client.language[(string)LanguageBox.SelectedItem] ,out string res);
            if (result != null)
            {
                result.Save("result.jpg");
                form3.label.Text = "";
                form3.label.Image = result;
                form3.Size = result.Size;
                
            }
            else {
                form3.label.Text = "翻译失败 " + res;
            };
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HotKey.UnregisterHotKey(Handle, 100);
        }

        class HotKey
        {
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            public static extern bool RegisterHotKey(IntPtr hWnd,int id, KeyModifiers fsModifiers,Keys vk);
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            public static extern bool UnregisterHotKey(IntPtr hWnd,int id);
            [Flags()]
            public enum KeyModifiers
            {
                None = 0,
                Alt = 1,
                Ctrl = 2,
                Shift = 4,
                WindowsKey = 8
            }
        }

        protected override void WndProc(ref Message m)
        {

            const int WM_HOTKEY = 0x0312;
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 160:
                            JPbutton.PerformClick();
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            HotKey.RegisterHotKey(Handle, 160, HotKey.KeyModifiers.Ctrl| HotKey.KeyModifiers.Shift, Keys.E);
        }

        private void appidText_TextChanged(object sender, EventArgs e)
        {
            Client.APP_ID = appidText.Text;
            Client.SaveSetting();
        }

        private void keyText_TextChanged(object sender, EventArgs e)
        {
            Client.KEY = keyText.Text;
            Client.SaveSetting();
        }

        private void LanguageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Client.DES = LanguageBox.SelectedIndex.ToString();
            Client.SaveSetting();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SHMenuItem_Click(object sender, EventArgs e)
        {
            SHbutton_Click(null, null);
        }

        private void OpenfileMenuItem_Click(object sender, EventArgs e)
        {
            OFbutton_Click(null,null);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)         
            {
                e.Cancel = true;
                this.ShowInTaskbar = false;
                this.Hide();
            }
        }
        
        private void notify_DoubleClick(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
        }
    }
}
