using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Lokale
    {
        public List<Reservation> tider = new List<Reservation>();
        public bool fuldtudstyret;
        public int LokaleID;
        public Lokale(bool fuldtudstyret, int navn)
        {
            this.fuldtudstyret = fuldtudstyret;
            LokaleID = navn;
        }
        public void GenererTider()
        {
            for(int i = 0; i < 18;i++)
            {
                tider.Add(new Reservation(DateTime.Now.AddHours(i),this));
            }
        }
        public void test1()
        {

        }
    }
}
