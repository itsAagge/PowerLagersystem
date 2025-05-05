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
        public string ReolId { get; set; }  
        public Reol() { }
        public Reol(string reolId, int pladserBred, int pladserHoej)
        {
            ReolId = reolId;
            PladserBred = pladserBred;
            PladserHoej = pladserHoej;
            Pladser = new List<Plads>();
        }
    }
}
