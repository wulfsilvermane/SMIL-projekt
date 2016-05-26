using System;
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
    public partial class OpretReservation : Form
    {
        private Patient patient;
        private Ansat ansat;
        private Reservation reservation;

        public OpretReservation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // gem i db
        }
    }
}
