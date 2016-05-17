using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Patient
    {
        public int id;
        public string cpr;
        public string fornavn;
        public string efternavn;
        public string addresse;
        public string bynavn;
        public int post;
        public string tlf;
        public string mobil;
        public string email;
        public string noter;
        
        public Patient Patient(int id, string cpr, string fornavn, string efternavn, string addresse,
            string bynavn, int post, string tlf, string mobil, string email, string noter)
        {
            this.id = id;
            this.cpr = cpr;
            this.fornavn = fornavn;
            this.efternavn = efternavn;
            this.addresse = addresse;
            this.bynavn = bynavn;
            this.post = post;
            this.tlf = tlf;
            this.mobil = mobil;
            this.email = email;
            this.noter = noter;
        }
    }
}
