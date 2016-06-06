﻿using System;
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
        public Patient patient;
        private Reservation reservation;
        private Behandling behandling;
        private int lokale = 1;
        static DateTime startsøgning = DateTime.Today.AddDays(-1);
        static DateTime slutsøgning = DateTime.Today.AddDays(28);
        List<Reservation> ResListe = SQLkommandoer.HentReservation(startsøgning, slutsøgning);
        List<Reservation> Lok1Res = new List<Reservation>();
        List<Reservation> Lok2Res = new List<Reservation>();
        List<Reservation> Lok3Res = new List<Reservation>();
        List<Reservation> Lok4Res = new List<Reservation>();

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
        private List<Reservation> DagsDato(int lokale)
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
            reservation = new Reservation(patient,dateTimePickerDato.Value, dateTimePickerTid.Value,lokale);
            SQLkommandoer.NyReservation(reservation,behandling,lokale,Convert.ToInt32(numericUpDown1.Value));
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
    }
}
