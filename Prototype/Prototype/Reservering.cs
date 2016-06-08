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
using System.IO;

namespace Prototype
{
    public partial class Reservering : Form
    {
        public Patient patient;
        private Reservation reservation;
        private Behandling behandling;
        private int lokale = 1;
        private int speciale = 0;
        private string specialetekst = "ingen";
        static DateTime startsøgning = DateTime.Today.AddDays(-1);
        static DateTime slutsøgning = DateTime.Today.AddDays(28);
        List<Reservation> ResListe = SQLkommandoer.HentReservation(startsøgning, slutsøgning);
        
        public Reservering()
        {
            InitializeComponent();
            buttonReserverTid.Enabled = false;
        }
        public Reservering(Patient patient, Behandling behandling)
        {
            this.patient = patient;
            this.behandling = behandling;
            InitializeComponent();
            textFornavn.Text = patient.fornavn;
            textEfternavn.Text = patient.efternavn;
            textCprNummer.Text = patient.cprnummer;
        }

        private void Reservering_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = DagsDato(1);
            listBox2.DataSource = DagsDato(2);
            listBox3.DataSource = DagsDato(3);
            listBox4.DataSource = DagsDato(4);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = DagsDato(1);
            listBox2.DataSource = DagsDato(2);
            listBox3.DataSource = DagsDato(3);
            listBox4.DataSource = DagsDato(4);
        }
        private List<Reservation> DagsDato(int lokale) //Udvælger de reservationer der har tider idag, filtre fra på lokale også, og returnere det som en liste
        {
            List<Reservation> reslist = new List<Reservation>();
            for (int i = ResListe.Count-1; i >= 0; i--)
            {
                if ((ResListe[i].starttid.DayOfYear == dateTimePickerDato.Value.DayOfYear) && (ResListe[i].lokaleid == lokale))
                    reslist.Add(ResListe[i]);
            }
            return reslist;
        }

        private void buttonForrigedag_Click(object sender, EventArgs e)
        {
            dateTimePickerDato.Value = dateTimePickerDato.Value.AddDays(-1);
        }

        private void buttonNæstedag_Click(object sender, EventArgs e)
        {
            dateTimePickerDato.Value = dateTimePickerDato.Value.AddDays(1);
        }

        private void buttonReserverTid_Click(object sender, EventArgs e)
        {
            reservation = new Reservation(patient,dateTimePickerDato.Value, dateTimePickerTid.Value,lokale, Convert.ToInt32(numericUpDown1.Value),specialetekst);
            if (gyldigReservation(reservation, ResListe))
            {
                SQLkommandoer.NyReservation(reservation, behandling, speciale);
                MessageBox.Show("Reservation udført og gemt", "Udført", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void radioLok1_CheckedChanged(object sender, EventArgs e)
        {
            lokale = 1;
        }

        private void radioLok2_CheckedChanged(object sender, EventArgs e)
        {
            lokale = 2;
        }

        private void radioLok3_CheckedChanged(object sender, EventArgs e)
        {
            lokale = 3;
        }

        private void radioLok4_CheckedChanged(object sender, EventArgs e)
        {
            lokale = 4;
        }

        private void buttonLok1Udskriv_Click(object sender, EventArgs e)
        {
            udskrivDagsorden(listBox1, "Lokale 1", dateTimePickerDato.Value.Date);
        }
        

        private void buttonLok2Udskriv_Click(object sender, EventArgs e)
        {
            udskrivDagsorden(listBox2, "Lokale 2", dateTimePickerDato.Value.Date);
        }
        
        private void buttonLok3Udskriv_Click(object sender, EventArgs e)
        {
            udskrivDagsorden(listBox3, "Lokale 3", dateTimePickerDato.Value.Date);
        }

        private void buttonLok4Udskriv_Click(object sender, EventArgs e)
        {
            udskrivDagsorden(listBox4, "Lokale 4", dateTimePickerDato.Value.Date);
        }
        private void udskrivDagsorden(ListBox liste, string lokale, DateTime dato)
        {
            List<Reservation> LokListe = (List<Reservation>)liste.DataSource;
            List<string> reseroversigt = new List<string>();
            foreach (Reservation res in LokListe)
            {
                reseroversigt.Add(string.Format("Tid: {0} - {1}, {2}", res.starttid.TimeOfDay, res.Patient.efternavn, res.Patient.fornavn));
                reseroversigt.Add(string.Format("Medarbejder: {0} - {1,35}", res.medarbejder, res.special));
                reseroversigt.Add(string.Format("Beskrivelse: {0}", res.behandling));
                reseroversigt.Add(string.Format(""));
            }
            try
            {
                string filsti = string.Format("C:\\Smil\\{0} - {1}.txt", lokale, dato.ToShortDateString());
                File.WriteAllLines(filsti, reseroversigt);
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine(e);
                Console.WriteLine("----------------------------");
            }
        }

        private void radioButtonAkupunktur_CheckedChanged(object sender, EventArgs e)
        {
            speciale = 1;
            specialetekst = "Akupunktur";
        }

        private void radioButtonKronefræser_CheckedChanged(object sender, EventArgs e)
        {
            speciale = 2;
            specialetekst = "Kronefræser";
        }

        private void radioButtonRøntgen_CheckedChanged(object sender, EventArgs e)
        {
            speciale = 3;
            specialetekst = "Røntgen";
        }

        private void radioButtonIngen_CheckedChanged(object sender, EventArgs e)
        {
            speciale = 0;
            specialetekst = "ingen";
        }
        private bool gyldigReservation(Reservation ny, List<Reservation> gammel)
        {
            //tids tjek
            foreach (Reservation res in gammel)
            {
                if (ny.lokaleid == res.lokaleid)//Tidstjek skal kun køres på de reservationer der har samme lokale som den nye.
                    if (ny.startdato.DayOfYear == res.startdato.DayOfYear)//Tjekker at den nye tid og de tider der sammenlignes med er på samme dag
                    if (gyldigTid(ny.starttid, res.starttid, res.starttid.AddMinutes(res.længde)) &&
                        gyldigTid(ny.starttid.AddMinutes(ny.længde), res.starttid, res.starttid.AddMinutes(res.længde)))//Den reelle tjekkning af tid. Se nedenstående metode- Hvis begge er true, ligge både slut og start uden for mellemrummet mellem start og slut i den nye tid
                        ;// Skal være tom, for at if statement ingenting gør. Det er kun hvis begge tider, start og slut, er ugyldige, at der skal ske noget, som sker i else
                    else {
                        MessageBox.Show("Den valgte tid er i konflikt med en eksisterende reservation for lokalet. Prøv venligst igen.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; }                    
            }
            if (ny.special != "ingen")//Hvis der ikke er noget speciale i den nye reservation skal der ikke tjekkes for om det matcher
            foreach (Reservation res in gammel)//speciale tjek
                {
                    if (!gyldigTid(ny.starttid, res.starttid, res.starttid.AddMinutes(res.længde)) ||
                        !gyldigTid(ny.starttid.AddMinutes(ny.længde), res.starttid, res.starttid.AddMinutes(res.længde)))
                        if (ny.special == res.special)
                        {
                            MessageBox.Show("Den valgte speciale er reserveret til dette tidspunkt. Prøv en anden tid.", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                }
                return true;
        }
        private bool gyldigTid(DateTime ny, DateTime gammelstart, DateTime gammelslut)//En simpel tjek for om en date time ligger uden for mellem rummet for to andre tider
        {
            if (ny > gammelstart && ny > gammelslut)
                return true;
            else if (ny < gammelstart && ny < gammelslut)
                return true;
            else return false;
        }
    }
}
