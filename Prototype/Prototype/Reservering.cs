using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    public partial class Reservering : Form
    {
        private Patient patient;
        static DateTime starttid = DateTime.Today.AddDays(-1);
        static DateTime sluttid = DateTime.Today.AddDays(28);
        List<Reservation> ResListe = SQLkommandoer.HentReservation(starttid,sluttid);
        List<Reservation> Lok1Res = new List<Reservation>();
        List<Reservation> Lok2Res = new List<Reservation>();
        List<Reservation> Lok3Res = new List<Reservation>();
        List<Reservation> Lok4Res = new List<Reservation>();

        public Reservering()
        {
            InitializeComponent();            
        }
        public Reservering(Patient patient)
        {
            this.patient = patient;
            InitializeComponent();
        }

        private void Reservering_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
