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

        public Reservation(Patient patient , DateTime dato, DateTime tid, int Lokale)
        {
            Patient = patient;
            startdato = dato;
            starttid = tid;
            lokaleid = Lokale;
        }
        public Reservation(int resid, DateTime dato, int LokaleID,string fnavn, string enavn)
        {
            id = resid;
            starttid = dato;
            Patient = new Patient();
            Patient.efternavn = enavn;
            Patient.fornavn = fnavn;
            lokaleid = LokaleID;
        }
        public override string ToString()
        {
            if (id == -1)
                return String.Format("{0} - <tom>\\n\\n", starttid);
            else
                return String.Format("{0} - {3}-{1}-{2}", starttid,Patient.efternavn,lokaleid,id);
        }
    }
}