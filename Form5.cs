using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Win_Commerce
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation=Application.StartupPath + "\\bread.jpg";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Voulez-vous lire le Guide d'utilisation pour comprendre le fonctionnement?","Aide",MessageBoxButtons.YesNo ,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Form3 frmSec=new Form3();
                Process pr=new Process();
                frmSec.Visible = true;
                this.Visible = false;

                //****************************************************************************//**************

                pr.StartInfo.FileName=Application.StartupPath + "\\GUIDE\\GUIDE D'UTILISATION.docx";
                pr.Start();
                

            }
            
            }
    }
}
