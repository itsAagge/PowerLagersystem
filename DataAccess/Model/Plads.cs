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
    public class Plads
    {
        [Key]
        public int PladsId { get; set; }
        public Reol Reol { get; set; }
        public Vare[] Varer { get; set; }
        public Varegruppe Varegruppe { get; set; }

        public Plads() { }
        public Plads(Varegruppe varegruppe, Reol reol)
        {
            Reol = reol;
            Varegruppe = varegruppe;
        }
    }
}
