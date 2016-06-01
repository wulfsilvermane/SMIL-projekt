using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Prototype
{
    public partial class PatientInfo : Form
    {
        public Patient patient;
        private bool opretNyPatient; // flag til at indikere om der skal oprettes ny patient

        public PatientInfo()
        {
            opretNyPatient = false;
            InitializeComponent();
        }

        
        public void GenopfriskData()
        {
            Patient buffer = SQLkommandoer.FindPatient(patient.cprnummer);
            patient = buffer;

            txtFornavn.Text = patient.fornavn;
            txtEfternavn.Text = patient.efternavn;
            txtAdresse.Text = patient.adresse;
            txtPostnummer.Text = patient.postnummer.ToString();
            txtBy.Text = patient.by;
            txtMobil.Text = patient.mobil;
            txtTelefon.Text = patient.telefon;
            txtEmail.Text = patient.email;
            txtPatientId.Text = patient.patientid.ToString();
            txtBemærkninger.Text = patient.bemærkninger;
            txtCprNummer.Text = patient.cprnummer;
        }

        public void NulstilTekstfelter(bool inklusivSøgefelt = true)
        {
            txtFornavn.Text = "";
            txtEfternavn.Text = "";
            txtAdresse.Text = "";
            txtPostnummer.Text = "";
            txtBy.Text = "";
            txtMobil.Text = "";
            txtTelefon.Text = "";
            txtEmail.Text = "";
            txtPatientId.Text = "";
            txtBemærkninger.Text = "";
            txtCprNummer.Text = "";

            if (inklusivSøgefelt)
                txtSøgefelt.Text = "";
        }

        public void NulstilAlt()
        {
            patient = new Patient();
            opretNyPatient = false;
            NulstilTekstfelter();
        }




        /* ------------ EVENTS ------------ */
        private void PatientInfo_Load(object sender, EventArgs e)
        {
            // Event executes når formen er helt loadet
        }

        private void btnSøg_Click(object sender, EventArgs e)
        {
            string cpr;
            bool nyPatient;

            // Bare rolig, intet er forsvundet...
            // koden til at hente patient og replace tekstbokse er lidt længere nede her (pga flow)

            // Først, check om vi er i gang med at ændre på en ny patient
            if (opretNyPatient)
            {
                DialogResult result = MessageBox.Show(
                    "Advarsel: De nuværende patientoplysninger er ikke gemt endnu! \n\n" +
                    "Du er ved at søge efter et CPR nummer i systemet, imens at der er patientdata som ikke er gemt. \n\n" +
                    "Hvis du trykker Ja, bliver de nuværende patientoplysninger IKKE gemt i systemet. \n\n" + 
                    "Er du sikker på at du vil fortsætte?",
                    "Advarsel",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.No)
                {
                    return; // Abryd event, og gå tilbage til start.
                }
                else
                {
                    opretNyPatient = false;
                    chkÆndreOplysninger.Checked = false;
                }
            }

            // Sanitize CPR nummer
            txtSøgefelt.Text = Regex.Replace(txtSøgefelt.Text, "[^0-9]", "");
            cpr = txtSøgefelt.Text;

            // Valider CPR nummer
            if (cpr.Length != 10)
            {
                MessageBox.Show("CPR nummeret er ugyldigt. Prøv venligst igen.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Afbryd event, så brugeren kan prøve igen.
            }

            // event executes når søg-knappen klikkes. CPR-boksen skal forbindes med søgefunktionen.
            patient = SQLkommandoer.FindPatient(txtSøgefelt.Text); //new Patient("Hans", "Petersen", "Jeevej 22", 5100, "Leeby", "22 22 22 22", "33 33 33 33", "2103932103", 315609, "Drastisk brug for ny krone!");

            // Tjek om CPR nummeret findes
            if (patient.cprnummer == null)
            {
                patient = null;
                nyPatient = true;
            }
            else
            {
                nyPatient = false;
            }

            if (nyPatient)
            {
                DialogResult result = MessageBox.Show(
                    "En patient med det indtastede CPR nummer findes ikke i systemet. \n" +
                    "Skal en ny patient med CPR nummeret " + txtSøgefelt.Text + " oprettes i systemet?",
                    "Ny Patient",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    opretNyPatient = true;
                }
                else
                {
                    return; // Abryd event, og gå tilbage til start.
                }

                NulstilTekstfelter(false);
                txtCprNummer.Text = cpr.ToString();
            }
            else // Hvis patienten findes, executes følgende kode
            {
                txtFornavn.Text = patient.fornavn;
                txtEfternavn.Text = patient.efternavn;
                txtAdresse.Text = patient.adresse;
                txtPostnummer.Text = patient.postnummer.ToString();
                txtBy.Text = patient.by;
                txtMobil.Text = patient.mobil;
                txtTelefon.Text = patient.telefon;
                txtEmail.Text = patient.email;
                txtPatientId.Text = patient.patientid.ToString();
                txtBemærkninger.Text = patient.bemærkninger;
                txtCprNummer.Text = patient.cprnummer;
            }

            // Når alt er klar, så enabler vi checkboksen.
            // Checkboksen er som default unchecked, og gem-knappen er altid
            // disabled, indtil at checkboksen er blevet checked.
            if (opretNyPatient)
            {
                chkÆndreOplysninger.Checked = true;
                chkÆndreOplysninger.Enabled = false;

                // Derefter enabler vi tekstboksene
                txtFornavn.ReadOnly = false;
                txtEfternavn.ReadOnly = false;
                txtAdresse.ReadOnly = false;
                txtPostnummer.ReadOnly = false;
                txtBy.ReadOnly = false;
                txtMobil.ReadOnly = false;
                txtTelefon.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtBemærkninger.ReadOnly = false;

                // Til sidst indsætter vi CPR nummeret i sin tekstboks
                txtCprNummer.Text = cpr.ToString();
            }
            else
            {
                chkÆndreOplysninger.Enabled = true;
            }
            
        }

        private void chkÆndreOplysninger_CheckedChanged(object sender, EventArgs e)
        {
            txtFornavn.ReadOnly = !chkÆndreOplysninger.Checked;
            txtEfternavn.ReadOnly = !chkÆndreOplysninger.Checked;
            txtAdresse.ReadOnly = !chkÆndreOplysninger.Checked;
            txtPostnummer.ReadOnly = !chkÆndreOplysninger.Checked;
            txtBy.ReadOnly = !chkÆndreOplysninger.Checked;
            txtMobil.ReadOnly = !chkÆndreOplysninger.Checked;
            txtTelefon.ReadOnly = !chkÆndreOplysninger.Checked;
            txtEmail.ReadOnly = !chkÆndreOplysninger.Checked;
            // txtPatientId.ReadOnly = !chkÆndreOplysninger.Checked;
            txtBemærkninger.ReadOnly = !chkÆndreOplysninger.Checked;
            // txtCprNummer.ReadOnly = !chkÆndreOplysninger.Checked;

            btnGemPatient.Enabled = chkÆndreOplysninger.Checked;
            btnSletPatient.Enabled = chkÆndreOplysninger.Checked;
        }

        private void btnGemPatient_Click(object sender, EventArgs e)
        {
            patient = new Patient();

            patient.fornavn = txtFornavn.Text;
            patient.efternavn = txtEfternavn.Text;
            patient.adresse = txtAdresse.Text;
            patient.postnummer = Convert.ToInt32(txtPostnummer.Text);
            patient.by = txtBy.Text;
            patient.mobil = txtMobil.Text;
            patient.telefon = txtTelefon.Text;
            patient.email = txtEmail.Text;
            patient.bemærkninger = txtBemærkninger.Text;
            patient.cprnummer = txtCprNummer.Text;

            // UC 1.2 Opret Patient
            if (opretNyPatient == true)
            {
                SQLkommandoer.OpretPatient(patient);

                // hvis success
                MessageBox.Show(
                    "Den nye patient er nu gemt i systemet.",
                    "Ny Patient Gemt",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                opretNyPatient = false;

                // refresh fra DB
                GenopfriskData();

                chkÆndreOplysninger.Enabled = true;
            }
            else // UC 1.1.1 Opdater Patient
            {
                patient.patientid = Convert.ToInt32(txtPatientId.Text);

                SQLkommandoer.OpdaterPatient(patient);

                // hvis success
                MessageBox.Show(
                    "Patientoplysningerne er nu gemt i systemet.",
                    "Patientoplysninger Opdateret",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                GenopfriskData();
            }
        }

        private void btnSletPatient_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Advarsel: Denne handling vil fjerne patientoplysningerne fra databasen. Dette kan ikke fortrydes.\n\n" +
                    "Er du sikker på at du vil slette patienten fra systemet?",
                    "Sletning af patient fra systemet",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                SQLkommandoer.SletPatient(patient);

                MessageBox.Show(
                    "Patienten er nu slettet fra systemet.",
                    "Patientoplysninger Slettet",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                NulstilAlt();
                chkÆndreOplysninger.Checked = false;
                chkÆndreOplysninger.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reservering rf = new Reservering(patient);
            rf.Show();
        }
    }
}
