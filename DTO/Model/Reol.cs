using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Reol
    {
        public int ReolId { get; set; }
        public string ReolNavn { get; set; }
        public int PladserBred { get; set; }
        public int PladserHoej { get; set; }

        public Reol(string reolNavn, int pladserBred, int pladserHoej)
        {
            ReolNavn = reolNavn;
            PladserBred = pladserBred;
            PladserHoej = pladserHoej;
        }
        public Reol(int reolId, string reolNavn, int pladserBred, int pladserHoej)
        {
            ReolId = reolId;
            ReolNavn = reolNavn;
            PladserBred = pladserBred;
            PladserHoej = pladserHoej;
        }
    }
}
