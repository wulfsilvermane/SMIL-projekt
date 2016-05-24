using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Reservation
    {
        enum Status {Reserveret, Tjekketind, Faerdig, Annulleret}   //Annulleret bruges til at sørge for at tiden bliver ledig, da der ved ikke fremmøde stadig bliver trukket nogen penge.
                                                                    //Reserveret bruges som default. Når en reservation er bestilt, ligger den i databasen. Er den ikke bestilt, ligger den kun i klienten
        private Status status;
        private int id;
        public Patient Patient;
        public Ansat Læge;
        public Lokale Lokale;
        private string beskrivelse; //Noter omkring reservationen
        private DateTime starttid;
        private int varighed;   //Antal ½ timer som reservationen dækker; Tandlæger skema lægger i ½ timer.
        public Reservation(int id)
        {
            this.id = id;
        }
        public void SetLaege(Ansat Læge)
        {
            this.Læge = Læge;
        }
        public void SetLokale(Lokale Lokale)
        {
            this.Lokale = Lokale;
        }
        public void SetPatient(Patient Patient)
        {
            this.Patient = Patient;
        }
    }
}