using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PatientInfo patientInfo = new PatientInfo();
            patientInfo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reservering reservering = new Reservering();
            reservering.Show();
            /*
            PatientInfo patientinfo = new PatientInfo();
            List<string> reseroversigt = new List<string>();
            reseroversigt.Add(string.Format("Lokale: {0}", patientinfo.lokalenr));
            reseroversigt.Add(string.Format(""));
            reseroversigt.Add(string.Format("Reserverede tider: {0}", patientinfo.tid));
            reseroversigt.Add(string.Format(""));
            reseroversigt.Add(string.Format("Specialudstyr: {0}", patientinfo.specialudstyr));
            reseroversigt.Add(string.Format(""));


            try
            {
                string filsti = string.Format("E:\\Tandlægerne Smil\\Lokale{0}.txt", patientinfo.lokalenr);
                File.WriteAllLines(filsti, reseroversigt);
            }
            catch (NotSupportedException e3)
            {

                Console.WriteLine("----------------------------");
                Console.WriteLine(e3);
                Console.WriteLine("----------------------------");*/
            }
        }
    }
}
