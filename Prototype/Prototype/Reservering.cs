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
    }
}
