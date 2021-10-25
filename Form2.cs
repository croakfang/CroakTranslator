using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CroakTranslator
{
    public partial class Form2 : Form
    {
        public Image ig;
        public TIdentifier Form;
        public int OriX, OriY,EndX,EndY;
        public int DrawW = 0, DrawH = 0;
        Pen pen = new Pen(Color.Red, 3);
        public Rectangle Rect;
        public Graphics MainPainter;
        public bool isDowned;

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            OriX = MousePosition.X;
            OriY = MousePosition.Y;
            isDowned = true;
        }

        private void Form2_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            isDowned = false;
            if (EndX>OriX&&EndY>OriY)
            {
                this.Opacity = 0;
                Image img = new Bitmap(DrawW, DrawH);
                Graphics g = Graphics.FromImage(img);
                g.CopyFromScreen(OriX,OriY,0,0,img.Size);
                Form.ImageTranslate(img,new Point(OriX,OriY));
            }
            this.Close();
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            
            
            if (isDowned)
            {
                EndX = MousePosition.X;
                EndY = MousePosition.Y;
                DrawW = EndX - OriX;
                DrawH = EndY - OriY;
                MainPainter.Clear(Color.Black);
                MainPainter.DrawRectangle(pen, OriX, OriY, DrawW, DrawH);      
            }
        }

        public void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form2
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Opacity = 0.5D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Deactivate += new System.EventHandler(this.Form2_Deactivate);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseUp);
            this.ResumeLayout(false);
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MainPainter = this.CreateGraphics();
        }


    }
}
