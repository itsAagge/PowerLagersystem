using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Reol
    {
        public List<Plads> Pladser { get; set; }
        public int PladserBred { get; set; }
        public int PladserHoej { get; set; }
        public Reol() { }
        public Reol(int pladserBred, int pladserHoej)
        {
            PladserBred = pladserBred;
            PladserHoej = pladserHoej;
            Pladser = new List<Plads>();
        }
    }
}
