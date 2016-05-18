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
    public partial class PatientInfo : Form
    {
        public PatientInfo()
        {
            InitializeComponent();
        }

        private void btnSøg_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void PatientInfo_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtFornavn.ReadOnly = !chkÆndreOplysninger.Checked;
            txtEfternavn.ReadOnly = !chkÆndreOplysninger.Checked;
            txtAdresse.ReadOnly = !chkÆndreOplysninger.Checked;
            txtPostnummer.ReadOnly = !chkÆndreOplysninger.Checked;
            txtBy.ReadOnly = !chkÆndreOplysninger.Checked;
            txtMobil.ReadOnly = !chkÆndreOplysninger.Checked;
            txtTelefon.ReadOnly = !chkÆndreOplysninger.Checked;
            // txtPatientId.ReadOnly = !chkÆndreOplysninger.Checked;
            txtBemærkninger.ReadOnly = !chkÆndreOplysninger.Checked;
            txtCprNummer.ReadOnly = !chkÆndreOplysninger.Checked;

            btnGemPatient.Enabled = chkÆndreOplysninger.Checked;
        }
    }
}
