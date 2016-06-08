using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Reservation
    {
        private int id;
        public int lokaleid;
        public Patient Patient;
        public DateTime startdato;
        public DateTime starttid;
        public int længde;
        public string behandling;
        public string special;

        public Reservation(Patient patient , DateTime dato, DateTime tid, int Lokale, int længde, string special)//Bruges til oprettelse af reservation
        {
            Patient = patient;
            startdato = dato;
            starttid = tid;
            lokaleid = Lokale;
            this.længde = længde;
            this.special = special;
        }
        public Reservation(int resid, DateTime dato, int LokaleID,string fnavn, string enavn, string tekst, int længde)//Bruges når reservationer skal hentes
        {
            id = resid;
            starttid = dato;
            Patient = new Patient();
            Patient.efternavn = enavn;
            Patient.fornavn = fnavn;
            lokaleid = LokaleID;
            behandling = tekst;
            special = "ingen";
            this.længde = længde;
        }
        public Reservation(int resid, DateTime dato, int LokaleID, string fnavn, string enavn, string tekst, string special, int længde)//Bruges når reservationer skal hentes
        {
            id = resid;
            starttid = dato;
            Patient = new Patient();
            Patient.efternavn = enavn;
            Patient.fornavn = fnavn;
            lokaleid = LokaleID;
            behandling = tekst;
            this.special = special;
            this.længde = længde;
        }
        public override string ToString()
        {
            return String.Format("{0} -{1} : {2}", starttid.TimeOfDay,Patient.efternavn,behandling);
        }
    }
}