using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CroakTranslator
{
    public partial class TIdentifier : Form
    {
        public TIdentifier()
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

        private void OPbutton_Click(object sender, EventArgs e)
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

        private void JPbutton_Click(object sender, EventArgs e)
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

        private void TIdentifier_FormClosed(object sender, FormClosedEventArgs e)
        {
            HotKey.UnregisterHotKey(Handle, 100);
        }

        class HotKey
        {
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            public static extern bool RegisterHotKey(IntPtr hWnd,                //要定义热键的窗口的句柄
               int id,                     //定义热键ID（不能与其它ID重复）
                KeyModifiers fsModifiers,   //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效
                Keys vk                     //定义热键的内容
                );
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            public static extern bool UnregisterHotKey(
                IntPtr hWnd,                //要取消热键的窗口的句柄
                int id                      //要取消热键的ID
                );
            //定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）
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
                        case 100:
                            JPbutton.PerformClick();
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void TIdentifier_Load(object sender, EventArgs e)
        {
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.Ctrl, Keys.B);
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

        
    }
}
