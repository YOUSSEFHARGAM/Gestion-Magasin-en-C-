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
    public partial class Form1 : Form
    {
        DbCon hornel = new DbCon();
        string codecli = "";
        int numero_commande = -1;
        Random rnd = new Random();
        int alea = 0;
        int generate;
        string valeur;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
          
        }

        private void cbojrs_DropDown(object sender, EventArgs e)
        {
            cbojrs.Items.Clear();
            for (int j = 1; j < 32; j++)

            {
                cbojrs.Items.Add(j);
            }        
        }

        private void cbomois_DropDown(object sender, EventArgs e)
        {
            string[] mois = new string[12];
            mois[0] = "Janvier";
            mois[1] = "Fevrier";
            mois[2] = "Mars";
            mois[3] = "Avril";
            mois[4] = "Mai";
            mois[5] = "Juin";
            mois[6] = "Juillet";
            mois[7] = "Août";
            mois[8] = "Septembre";
            mois[9] = "Octobre";
            mois[10] = "Novembre";
            mois[11] = "Decembre";

            cbomois.Items.Clear();

            for (int x = 0; x < 12; x++)
            {
                cbomois.Items.Add(mois[x]);
            }
        }

        private void cboan_DropDown(object sender, EventArgs e)
        {
            cboan.Items.Clear();
            for (int y = 2000; y < (DateTime.Now.Year + 1); y++)
            {
                cboan.Items.Add(y);
            }
        }

        private void btnenreg_Click(object sender, EventArgs e)
        {
            
           
            if (MessageBox.Show("Êtes-vous Sûr d'enregistrer ces données?", "Tentative d'enregistrément", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    hornel.req = "Insert Into Client(NunCli,Nom,PostNom,Prenom,Sexe,Rue,Nrue,Quart,Com,Tel,Categorie_Client)values('" + txtnum.Text + "','" + txtnom.Text + "','" + txtpostnom.Text + "','" + txtprenom.Text + "','" + cbosexe.Text + "','" + txtrue.Text + "','" + txtnrue.Text + "','" + txtquart.Text + "','" + txtcom.Text + "','" + txtphone.Text + "','" + cbocateg.Text + "')";
                    hornel.Me_Connecter();
                    hornel.Me_Deconnecter();

                    MessageBox.Show("Données enregistrée !", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


               
            }
           
        }

        private void cborech_DropDown(object sender, EventArgs e)
        {
            hornel.req = "Select * FROM Client";
            hornel.Me_Connecter();

            cborech.Items.Clear();
            while (hornel.rdr.Read())
            {
                cborech.Items.Add(hornel.rdr.GetValue(0));
            }
            hornel.Me_Deconnecter();
        }

        private void cbocateg_DropDown(object sender, EventArgs e)
        {
            hornel.req = "Select * FROM Categorie_Client";
            hornel.Me_Connecter();

            cbocateg.Items.Clear();
            while (hornel.rdr.Read())
            {
                cbocateg.Items.Add(hornel.rdr.GetValue(0));
            }
            hornel.Me_Deconnecter();
        }

        private void btnrech_Click(object sender, EventArgs e)
        {
            try
            {
                hornel.req = "Select * FROM Client Where NunCli='" + cborech.Text + "'";
                hornel.Me_Connecter();

                hornel.rdr.Read();

                txtnum.Text= hornel.rdr.GetValue(0).ToString().ToUpper();
                txtnom.Text = hornel.rdr.GetValue(1).ToString().ToUpper();
                txtpostnom.Text = hornel.rdr.GetValue(2).ToString().ToUpper();
                txtprenom.Text = hornel.rdr.GetValue(3).ToString().ToUpper();
                cbosexe.Text = hornel.rdr.GetValue(4).ToString().ToUpper();
                txtrue.Text = hornel.rdr.GetValue(5).ToString().ToUpper();
                txtnrue.Text = hornel.rdr.GetValue(6).ToString();
                txtquart.Text = hornel.rdr.GetValue(7).ToString().ToUpper();
                txtcom.Text = hornel.rdr.GetValue(8).ToString().ToUpper();
                txtphone.Text = hornel.rdr.GetValue(9).ToString();
                cbocateg.Text = hornel.rdr.GetValue(10).ToString();

                hornel.Me_Deconnecter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((string.Compare(txtnum.Text , txtclient.Text, true) != 0)) // compare si les noms du client sont differents et leurs Codes
            {
                MessageBox.Show("Les noms du Client sont different", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


         
            try
            {
                if (MessageBox.Show("Voulez-vous Sauvegarder ces données", "Enregistrer une commande", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    hornel.req = "Insert Into Commande(Numcom,NumCli,JrsCom,MoisCom,AnCom,desig)values('" + txtnumcom.Text + "','" + codecli + "','" + cbojrs.Text + "','" + cbomois.Text + "','" + cboan.Text + "','" + cboprodcom.Text + "')";
                    hornel.Me_Connecter();
                    hornel.Me_Deconnecter();

                    MessageBox.Show("La commande vient d'être enregistrée !", "Enregistrement Commande", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }



        private void cbocateg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbomois_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboprodcom_DropDown(object sender, EventArgs e)
        {
            hornel.req = "Select Desig FROM Produit";
            hornel.Me_Connecter();
            cboprodcom.Items.Clear();

            while (hornel.rdr.Read())
            {
                cboprodcom.Items.Add(hornel.rdr.GetValue(0).ToString());
 
            }

            hornel.Me_Deconnecter();

        }

        private void cborechcom_DropDown(object sender, EventArgs e)
        {
            hornel.req = "Select NumCom FROM Commande ";
            hornel.Me_Connecter();

            cborechcom.Items.Clear();
            while (hornel.rdr.Read())
            {
                cborechcom.Items.Add(hornel.rdr.GetValue(0).ToString());
            }
            hornel.Me_Deconnecter();
        }

        private void cborechcom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            hornel.req = "Select * FROM Commande where NumCom='" + cborechcom.Text + "'";
            hornel.Me_Connecter();

            while (hornel.rdr.Read())
            {
                txtnumcom.Text = hornel.rdr.GetValue(0).ToString();
                txtclient.Text = hornel.rdr.GetValue(1).ToString();
                cbojrs.Text = hornel.rdr.GetValue(2).ToString();
                cbomois.Text = hornel.rdr.GetValue(3).ToString();
                cboan.Text = hornel.rdr.GetValue(4).ToString();
                cboprodcom.Text = hornel.rdr.GetValue(5).ToString();
            }
            hornel.Me_Deconnecter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtnum.Text == "" || txtnom.Text == "")
                {
                    MessageBox.Show("Impossible car le(s) champs Nom et Numero sont vide(s)....", "Erreur ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    alea = txtnom.Text.Length; // Récupère la longueur du Nom
                    generate = (int)((rnd.NextDouble() * alea) + 1); // génère un nombre aléatoire par rapport à la Longueur du Nom

                    valeur = txtnom.Text.Substring(generate, 1); //Trie un caractère dans le nom
                    string code = @"Shop\" + txtnum.Text + @"\ " + valeur + Convert.ToInt32(Convert.ToChar(valeur)); // La concaténation du Resultat
                    txtnumcom.Text = code;
                    codecli = txtnum.Text; // Recupère le Numero du Client
                    txtclient.Text = codecli;
                    
                }
            }
            catch (Exception ex)
            {
                txtnumcom.Text = @"Shop\" + txtnum.Text + @"\" + "err"; //Au cas ou l'algorithme génère une erreur  
                txtclient.Text = txtnum.Text;
            }
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtnum.Text == "" && txtnom.Text == "") // si les champs sont vides alors il y a erreur 
                {
                    MessageBox.Show("Impossible car le(s) champs Nom et Numero sont vide(s)....", "Erreur ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    alea = txtnom.Text.Length; // Récupère la longueur du Nom
                    generate = (int)((rnd.NextDouble() * alea) + 1);// génère un nombre aléatoire par rapport à la Longueur du Nom
                    if (generate > alea)
                    {
                        generate -= alea;
                    }
                    valeur = txtnom.Text.Substring(generate, 1); //Trie un caractère dans le nom
                    string code = @"Shop\" + txtnum.Text + @"\ " + valeur + Convert.ToInt32(Convert.ToChar(valeur)); // La concaténation du Resultat
                    txtnumcom.Text = code;
                    codecli = txtnum.Text; // Recupère le Numero du Client
                    txtclient.Text = codecli;
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
               

            }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 frm_menu = new Form2();
            this.Visible = false;
            frm_menu.Visible = true;
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de quitter?", "Sortie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();

            }
        }
        }
    }


