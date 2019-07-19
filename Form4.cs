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
    public partial class Form4 : Form
    {
        DbCon lama = new DbCon();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes-vous Sûr d'enregistrer ces dnnées?", "Enregistrement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lama.req = "Insert Into Produit(desig,datexp,PU,Categorie_Produit)values('" + txtproduit.Text + "','" + dt.Value.ToString() + "','" + txtpu.Text + "','" + cbocategprod.Text + "')";
                lama.Me_Connecter();
                lama.Me_Deconnecter();
                MessageBox.Show("Donnée enrégistrée", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbocategprod_DropDown(object sender, EventArgs e)
        {
            lama.req = "SELECT * FROM categorie_produit";
            lama.Me_Connecter();

            cbocategprod.Items.Clear();
            while (lama.rdr.Read())
            {
                cbocategprod.Items.Add(lama.rdr.GetString(0));
            }
            lama.Me_Deconnecter();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtproduit.Text == "")
                {
                    MessageBox.Show("Entrez d'abord la désignation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    lama.req = "Select * FROM produit where desig='" + txtproduit.Text + "'";
                    lama.Me_Connecter();

                    while (lama.rdr.Read())
                    {
                        txtproduit.Text = lama.rdr.GetString(0);
                        dt.Value = lama.rdr.GetDateTime(1);
                        txtpu.Text = lama.rdr.GetString(2);
                        cbocategprod.Text = lama.rdr.GetString(3);
                    }
                    lama.Me_Deconnecter();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string code_retrouve = "";
            double ctr;
            Random rnd = new Random();

            button6.Enabled = false;
            try
            {

                if (txtproduit.Text == "" || txtnumstock.Text == "")
                {
                    MessageBox.Show("Entrez la designation et le code du stock", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Voulez-vous enregistrer?", "Enregistrement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lama.req = "Insert Into Stock(CodStock,LibStock)values('" + txtnumstock.Text + "','" + txtlibstock.Text + "')";
                    lama.Me_Connecter();
                    lama.Me_Deconnecter();
                    //****************************************TABLE RELATIONNELLE (RETROUVER)*************************************
                    ctr = (rnd.NextDouble() * (txtproduit.Text.Length - 1) + 1);
                    code_retrouve = txtnumstock.Text + @"\ " + txtproduit.Text.Substring(((int)ctr), 1);
                    lama.req = "Insert into Retrouver(CodeRetr,DateRetr,CodeStock,desig)values('" + code_retrouve + "','" + DateTime.Now.Date + "','" + txtnumstock.Text + "','" + txtproduit.Text + "')";
                    lama.Me_Connecter();
                    lama.Me_Deconnecter();
                    MessageBox.Show("Données enregistrée avec succès!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                if (MessageBox.Show("Désirez-vous ajouter un produit dans ce stock?", "Ajout Produit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    button6.Enabled = true;
                    MessageBox.Show("Saisissez un nouveau produit pour ce stock,puis cliquez sur Ajouter", "Nouveau produit du Stock Actuel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    button6.Enabled = false;
                    MessageBox.Show("Saisissez un nouveau stock", "Saisir dans le stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                lama.req = "SELECT * FROM stock where codstock='" + txtnumstock.Text + "'";
                lama.Me_Connecter();

                while (lama.rdr.Read())
                {
                    txtnumstock.Text = lama.rdr.GetString(0);
                    txtlibstock.Text = lama.rdr.GetString(1);
                }
                lama.Me_Deconnecter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            button6.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string code_retrouve = "";
            double ctr;
            Random rnd = new Random();

            ctr = (rnd.NextDouble() * (txtproduit.Text.Length - 1) + 1);
            code_retrouve = txtnumstock.Text + @"\ " + txtproduit.Text.Substring(((int)ctr), 1);
            lama.req = "Insert into Retrouver(CodeRetr,DateRetr,CodeStock,desig)values('" + code_retrouve + "','" + DateTime.Now.Date + "','" + txtnumstock.Text + "','" + txtproduit.Text + "')";
            lama.Me_Connecter();
            lama.Me_Deconnecter();
            MessageBox.Show("Données enregistrée avec succès,dans le Stock" + " " + txtlibstock.Text, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cborechstock_DropDown(object sender, EventArgs e)
        {
            lama.req = "SELECT CodStock FROM Stock";
            lama.Me_Connecter();

            cborechstock.Items.Clear();
            while (lama.rdr.Read())
            {
                cborechstock.Items.Add(lama.rdr.GetString(0));
            }
            lama.Me_Deconnecter();
        }

        private void cborechstock_TextChanged(object sender, EventArgs e)
        {
            lama.req = "SELECT Desig FROM Retrouver where CodeStock='" + cborechstock.Text + "'";
            lama.Me_Connecter();

            cborechproduit.Items.Clear();
            while (lama.rdr.Read())
            {
                cborechproduit.Items.Add(lama.rdr.GetString(0));
            }
            lama.Me_Deconnecter();
        }

        private void cborechproduit_DropDown(object sender, EventArgs e)
        {
            cborechproduit.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cborechproduit.Text == "" || cborechstock.Text == "")
            { MessageBox.Show("Impossible de trouver,selectionner le Stock et le produit.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
            }
            lama.req = "SELECT * FROM Stock where CodStock='" + cborechstock.Text + "'";
            lama.Me_Connecter();

            while (lama.rdr.Read())
            {
                txtnumstock.Text = lama.rdr.GetString(0);
                txtlibstock.Text = lama.rdr.GetString(1);
            }
            lama.Me_Deconnecter();

            //***************************************************************************************

            lama.req = "SELECT * FROM Produit where Desig='" + cborechproduit.Text + "'";
            lama.Me_Connecter();

            while (lama.rdr.Read())
            {
                txtproduit.Text = lama.rdr.GetString(0);
                dt.Value = lama.rdr.GetDateTime(1);
                txtpu.Text = lama.rdr.GetString(2);
                cbocategprod.Text = lama.rdr.GetString(3);
            }
            lama.Me_Deconnecter();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 frm_menu = new Form2();
            this.Visible = false;
            frm_menu.Visible = true;
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
