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
        bool fuldtudstyret;
        public Lokale(bool fuldtudstyret)
        {
            this.fuldtudstyret = fuldtudstyret;
        }
        public void GenererTider()
        {
            for(int i = 0; i > 18;i++)
            {
                tider.Add(new Reservation(DateTime.Now.AddHours(i)));
            }
        }
    }
}
