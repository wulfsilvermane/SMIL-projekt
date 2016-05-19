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
        private Patient patient;
        private bool opretNyPatient; // flag til at indikere om der skal oprettes ny patient

        public PatientInfo()
        {
            opretNyPatient = false;
            InitializeComponent();
        }

        public bool FindesCpr(string cpr)
        {
            bool findes;
            // Pre-condition: CPR nummeret må ikke have mellemrum eller specialtegn, som bindestreg
            // OK:      "1212851234"
            // Ikke OK: "12 12 85 1234"
            //          "121285-1234"     osv.

            // TODO: Indsæt kode her, som kigger op på databasen
            // Hvis den findes, skal der returneres 'true', ellers skal den returnere 'false'
            findes = false; // PLACEHOLDER

            return findes;
        }

        /*public Patient FindPatient(string cpr)
        {
            
        }*/

        public void OpretPatient(Patient patient)
        {
            // TODO: Kode til at oprette patient i databasen

            opretNyPatient = false; // SKAL være den sidste linje i metoden!
                                    // Må ikke executes hvis oprettelsen fejler.
        }

        public void OpdaterPatient(Patient patient)
        {
            // TODO: Kode til at opdatere patient i databasen
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

            // Tjek om CPR nummeret findes
            nyPatient = !FindesCpr(cpr);

            // Tjek om CPR nummeret findes i databasen
            if (nyPatient)
            {
                DialogResult result = MessageBox.Show(
                    "En patient med det indtastede CPR nummer findes ikke i systemet. \n" +
                    "Skal en ny patient med CPR nummeret " + txtSøgefelt.Text + " oprettes i systemet?",
                    "Ny Patient",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if(result == DialogResult.Yes)
                {
                    opretNyPatient = true;
                }
                else
                {
                    return; // Abryd event, og gå tilbage til start.
                }
            }
            else // Hvis patienten findes, executes følgende kode
            {
                // PLACEHOLDER OBJEKT - ERSTAT MED DB KODE
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
            // txtPatientId.ReadOnly = !chkÆndreOplysninger.Checked;
            txtBemærkninger.ReadOnly = !chkÆndreOplysninger.Checked;
            // txtCprNummer.ReadOnly = !chkÆndreOplysninger.Checked;

            btnGemPatient.Enabled = chkÆndreOplysninger.Checked;
        }

        private void btnGemPatient_Click(object sender, EventArgs e)
        {
            if (opretNyPatient == true)
            {
                OpretPatient(patient);
                chkÆndreOplysninger.Enabled = true;
            }
            else
            {
                OpdaterPatient(patient);
            }
        }
    }
}
