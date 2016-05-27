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
        ArrayList tilgængeligtid = new ArrayList(18);
        Lokale Lok1 = new Lokale(true, "Lokale 101");
        List<Reservation> testlist = SQLkommandoer.HentReservation(new DateTime(2016,1,1),new DateTime(2016,8,15));
        public Reservering()
        {
            InitializeComponent();
            Lok1.GenererTider();
            listBox1.DataSource = Lok1.tider;
            listBox2.DataSource = testlist;
        }
        public Reservering(Patient patient)
        {
            this.patient = patient;
            InitializeComponent();
            Lok1.GenererTider();
        }

        private void Reservering_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
