using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Win_Commerce
{
    class DbCon
    {
        public string req;
        public OleDbDataReader rdr;
        OleDbCommand cmd;
        OleDbConnection con;
        string strcon;
        public DbCon()
        {
            strcon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\Commerce.accdb";
 
        }
        public void Me_Connecter()
        {
            con = new OleDbConnection(strcon);
            con.Open();
            cmd = new OleDbCommand(req, con);
            rdr = cmd.ExecuteReader();
        }
        public void Me_Deconnecter()
        {
            rdr.Dispose();
            con.Dispose();
        }
    }
}
