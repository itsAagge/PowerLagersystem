using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    [Table("Reol")]
    public class Reol
    {
        [Key]
        public int ReolId { get; set; }
        public Plads[,] Pladser {  get; set; }

        public Reol() { }
        public Reol(int pladserBred, int pladserHoej)
        {
            Pladser = new Plads[pladserBred, pladserHoej];
        }
    }
}