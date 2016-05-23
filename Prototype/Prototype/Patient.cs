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
        public string email;
        public string cprnummer;
        public int patientid;
        public string bemærkninger;
        public int sikringsgruppe;


        public Patient(string fornavn, string efternavn, string adresse, int postnummer, string by, string mobil, string telefon, string email, string cprnummer, int patientid,  /*string email*/ string bemærkninger)
        //Kan slettes?
        {
            this.fornavn = fornavn;
            this.efternavn = efternavn;
            this.adresse = adresse;
            this.postnummer = postnummer;
            this.by = by;
            this.mobil = mobil;
            this.telefon = telefon;
            this.email = email;
            this.cprnummer = cprnummer;
            this.patientid = patientid;
            this.bemærkninger = bemærkninger;
        }

        public Patient(int patientid, string cprnummer, string fornavn, string efternavn, string adresse, int postnummer, string by, string telefon, string mobil, string email, string bemærkninger, int sikringsgruppe)
        {
            this.patientid = patientid;
            this.cprnummer = cprnummer;
            this.fornavn = fornavn;
            this.efternavn = efternavn;
            this.adresse = adresse;
            this.postnummer = postnummer;
            this.by = by;
            this.telefon = telefon;
            this.mobil = mobil;
            this.email = email;
            this.bemærkninger = bemærkninger;
            this.sikringsgruppe = sikringsgruppe;
        }
        public Patient() { }
    }
}