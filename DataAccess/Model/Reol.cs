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
    internal class Reol
    {
        [Key]
        public int ReolId { get; set; }

        public string ReolNavn { get; set; }
        public int PladserBred { get; set; }
        public int PladserHoej { get; set; }

        public Reol() { }
        public Reol(string reolNavn, int pladserBred, int pladserHoej)
        {
            ReolNavn = reolNavn;
            PladserBred = pladserBred;
            PladserHoej = pladserHoej;
        }
    }
}