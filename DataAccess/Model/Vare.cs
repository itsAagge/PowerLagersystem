using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public enum Varegruppe
    {
        Lav,
        Middel,
        Hoej
    }

    [Table("Vare")]
    public class Vare
    {
        [Key]
        public long EAN { get; set; }
        public string Model { get; set; }
        public Varegruppe Varegruppe { get; set; }
        public string? Note { get; set; }
        public Plads Plads { get; set; }

        public Vare() { }
        public Vare(long ean, string model, Varegruppe varegruppe, string? note = null)
        {
            EAN = ean;
            Model = model;
            Varegruppe = varegruppe;
            Note = note;
        }
    }
}
