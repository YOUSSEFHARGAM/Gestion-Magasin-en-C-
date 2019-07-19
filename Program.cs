using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Win_Commerce
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form5() );
            
        }
    }
}
