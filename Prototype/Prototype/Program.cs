using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        /// !!!!!!!! SKAL IKKE COMMITES - SKIP !!!!!!!! ///
        public static string SQLforbindelse = "Server=localhost;Database=smildb;Integrated Security=True;";
        /// !!!!!!!! SKAL IKKE COMMITES - SKIP !!!!!!!! ///

        [STAThread]
        static void Main()
        {
            //SQLkommandoer.IndsaetBynavn(6000, "Kolding");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartMenu());
        }
    }
}
