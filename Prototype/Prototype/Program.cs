﻿using System;
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
        public static string SQLforbindelse = "Server=SUPERLAPPY\\DATAMATSERVER;Database=SMIL_projekt;user id=tinker;password=Tink";
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
