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
        public Reservation(DateTime tid, Lokale Lokale)
        {
            id = -1;
            færdig = false;
            this.Lokale = Lokale;
            starttid = tid;
        }
        public Reservation(DateTime tid)
        {
            id = -1;
            færdig = false;
            starttid = tid;
        }
        public void SetPatient(Patient Patient)
        {
            this.Patient = Patient;
        }
        public override string ToString()
        {
            if (id == -1)
                return String.Format("{0} <tom>",starttid);
            else
            {
                return String.Format("{0}{1}",starttid,Patient.efternavn);
            };
        }
    }
}