using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Behandling
    {
        public int BehandlingsID;
        string BehandlingsTekst;
        public Behandling(int bID, string Tekst)
        {
            BehandlingsID=bID;
            BehandlingsTekst = Tekst;
        }
        public override string ToString()
        {
                return String.Format("ID:{0} - {1}", BehandlingsID, BehandlingsTekst);
        }
        public Behandling returnself()
        {
            return this;
        }
    }
}
