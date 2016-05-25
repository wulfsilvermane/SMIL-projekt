using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Lokale
    {
        List<Reservation> tider = new List<Reservation>();
        public bool fuldtudstyret;
        public string LokaleNavn;
        public Lokale(bool fuldtudstyret, string navn)
        {
            this.fuldtudstyret = fuldtudstyret;
            LokaleNavn = navn;
        }
        public void GenererTider()
        {
            for(int i = 0; i > 18;i++)
            {
                tider.Add(new Reservation(DateTime.Now.AddHours(i),this));
            }
        }
    }
}
