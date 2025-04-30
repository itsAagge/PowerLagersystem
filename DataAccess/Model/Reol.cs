using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    [Table("Reol")]
    public class Reol
    {
        [Key]
        public int ReolId { get; set; }
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