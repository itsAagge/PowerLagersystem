using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    [Table("Plads")]
    internal class Plads
    {
        [Key]
        public int PladsId { get; set; }

        [ForeignKey("Reol")]
        public int ReolId { get; set; }

        public int PladsX { get; set; }
        public int PladsY { get; set; }
        public Varegruppe Varegruppe { get; set; }
        public int PladsPoint { get; set; }
       
        public Plads() { }
        public Plads(Varegruppe varegruppe, int reolId, int pladsX, int pladsY, int pladsPoint)
        {
            ReolId = reolId;
            PladsX = pladsX;
            PladsY = pladsY;
            Varegruppe = varegruppe;
            PladsPoint = pladsPoint;
        }
    }
}
