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
        private Patient patient;
        public PatientInfo()
        {
            InitializeComponent();
        }

        private void PatientInfo_Load(object sender, EventArgs e)
        {
            // Event executes når formen er helt loadet
        }

        private void btnSøg_Click(object sender, EventArgs e)
        {
            // event executes når søg-knappen klikkes
            patient = new Patient("Hans", "Petersen", "Jeevej 22", 5100, "Leeby", "22 22 22 22", "33 33 33 33", "2103932103", 315609, "Drastisk brug for ny krone!");

            txtFornavn.Text = patient.fornavn;
            txtEfternavn.Text = patient.efternavn;
            txtAdresse.Text = patient.adresse;
            txtPostnummer.Text = patient.postnummer.ToString();
            txtBy.Text = patient.by;
            txtMobil.Text = patient.mobil;
            txtTelefon.Text = patient.telefon;
            txtPatientId.Text = patient.patientid.ToString();
            txtBemærkninger.Text = patient.bemærkninger;
            txtCprNummer.Text = patient.cprnummer;
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
            // txtCprNummer.ReadOnly = !chkÆndreOplysninger.Checked;

            btnGemPatient.Enabled = chkÆndreOplysninger.Checked;
        }
    }
}
