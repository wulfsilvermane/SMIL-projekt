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
        private Status _status;
        private int id;
        private Patient _patient;
        private Ansat _laege;
        private Lokale _lokale;
        private string beskrivelse; //Noter omkring reservationen
        private DateTime _starttid;
        private int varighed;   //Antal ½ timer som reservationen dækker; Tandlæger skema lægger i ½ timer.
        public Reservation(int id)
        {
            this.id = id;
        }
        public void SetLaege(Ansat _laege)
        {
            this._laege = _laege;
        }
        public void SetLokale(Lokale _lokale)
        {
            this._lokale = _lokale;
        }
        public void SetPatient(Patient _patient)
        {
            this._patient = _patient;
        }
    }
}