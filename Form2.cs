using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Win_Commerce
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            swf.Movie = Application.StartupPath + @"\bread.swf";
            
          
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frmcom = new Form1();
            this.Visible = false;
            frmcom.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
                Application.Exit();
           
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 frm_prod = new Form4();
            this.Visible = false;
            frm_prod.Visible = true;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            
                Application.Exit();

        }
    }
}
