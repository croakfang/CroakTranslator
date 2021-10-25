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
    public partial class Form3 : Form
    {
        public Label label;
        
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.label, "label");
            this.label.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label.Name = "label";
            this.label.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form3
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.label);
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.Form3_Deactivate);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Click += new System.EventHandler(this.Form3_Click);
            this.Leave += new System.EventHandler(this.Form3_Leave);
            this.ResumeLayout(false);

        }

        private void Form3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
