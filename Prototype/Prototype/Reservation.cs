using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Reservation
    {
        private bool færdig;
        private int id;
        public Patient Patient;
        public Lokale Lokale;
        private DateTime starttid;
        public Reservation() { }
        public Reservation(DateTime tid, Lokale Lokale)
        {
            id = -1;
            færdig = false;
            this.Lokale = Lokale;
            starttid = tid;
        }
        public Reservation(int resid, DateTime dato, string LokaleNavn,string fnavn, string enavn)
        {
            id = resid;
            færdig = false;
            starttid = dato;
            Patient = new Patient();
            Patient.efternavn = enavn;
            Patient.fornavn = fnavn;
            Lokale = new Lokale(true, LokaleNavn);
        }
        public override string ToString()
        {
            if (id == -1)
                return String.Format("{0} - <tom>\\n\\n", starttid);
            else
                return String.Format("{0} - {3}-{1}-{2}", starttid,Patient.efternavn,Lokale.LokaleNavn,id);
        }
    }
}