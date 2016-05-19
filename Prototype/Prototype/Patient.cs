using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Patient
    {
        public string fornavn;
        public string efternavn;
        public string adresse;
        public int postnummer;
        public string by;
        public string mobil;
        public string telefon;
        public string cprnummer;
        // public string email; Tilføj til winform.
        public int patientid;
        public string bemærkninger;
        
        public Patient(string fornavn, string efternavn, string adresse, int postnummer, string by, string mobil, string telefon, string cprnummer, int patientid,  /*string email*/ string bemærkninger)
        {
            this.fornavn = fornavn;
            this.efternavn = efternavn;
            this.adresse = adresse;
            this.postnummer = postnummer;
            this.by = by;
            this.mobil = mobil;
            this.telefon = telefon;
            //this.email = email;
            this.cprnummer = cprnummer;
            this.patientid = patientid;
            this.bemærkninger = bemærkninger;
        }
    }
}
