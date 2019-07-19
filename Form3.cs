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
    public partial class Form3 : Form
    {
        DbCon lama = new DbCon();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string User = "", pwd = "";
            Form2 frm_menu = new Form2();
            lama.req = "SELECT * FROM Login Where ID_USER='" + txtuser.Text + "' AND PWD='" + txtmdp.Text + "'";
            lama.Me_Connecter();
            while (lama.rdr.Read())
            {
                User = lama.rdr.GetString(0);
                pwd = lama.rdr.GetString(1);
            }
            lama.Me_Deconnecter();

            if (User=="" && pwd =="")
            {
                MessageBox.Show("Utilisateur authenfication échouée !", "Authenfication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else 
            {
                MessageBox.Show("Utilisateur Authentification reussie !", "Authentification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Visible = false;
                frm_menu.Visible = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtmdp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                string User = "", pwd = "";
                Form2 frm_menu = new Form2();
                lama.req = "SELECT * FROM Login Where ID_USER='" + txtuser.Text + "' AND PWD='" + txtmdp.Text + "'";
                lama.Me_Connecter();
                while (lama.rdr.Read())
                {
                    User = lama.rdr.GetString(0);
                    pwd = lama.rdr.GetString(1);
                }
                lama.Me_Deconnecter();

                if (User == "" && pwd == "")
                {
                    MessageBox.Show("Utilisateur authenfication échouée !", "Authenfication", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("Utilisateur Authentification reussie !", "Authentification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Visible = false;
                    frm_menu.Visible = true;
                }
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de quitter?", "Sortie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

       
    }
}
