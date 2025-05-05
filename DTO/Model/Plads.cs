using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Plads
    {
        public int PladsId { get; set; }
        public int ReolId { get; set; }
        public int PladsX { get; set; }
        public int PladsY { get; set; }
        public Varegruppe Varegruppe { get; set; }

        public Plads(Varegruppe varegruppe, int reolId, int pladsX, int pladsY)
        {
            ReolId = reolId;
            PladsX = pladsX;
            PladsY = pladsY;
            Varegruppe = varegruppe;
        }
        public Plads(int pladsId, Varegruppe varegruppe, int reolId, int pladsX, int pladsY)
        {
            PladsId = pladsId;
            ReolId = reolId;
            PladsX = pladsX;
            PladsY = pladsY;
            Varegruppe = varegruppe;
        }
    }
}
