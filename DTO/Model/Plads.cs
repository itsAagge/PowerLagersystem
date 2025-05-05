using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Plads
    {
        public Reol Reol { get; set; }
        public int PladsX { get; set; }
        public int PladsY { get; set; }
        public Vare[] Varer { get; set; }
        public Varegruppe Varegruppe { get; set; }
        public Plads() { }
        public Plads(Varegruppe varegruppe, Reol reol, int pladsX, int pladsY)
        {
            Reol = reol;
            PladsX = pladsX;
            PladsY = pladsY;
            Varegruppe = varegruppe;
        }
    }
}
