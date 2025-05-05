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
        Standard,
        Hoej,
        Special
    }

    [Table("Vare")]
    public class Vare
    {
        [Key]
        public int VareId { get; set; }

        [ForeignKey("Plads")]
        public int PladsId { get; set; }

        public long EAN { get; set; }
        public string Model { get; set; }
        public Varegruppe Varegruppe { get; set; }
        public string? Note { get; set; }

        public Vare() { }
        public Vare(int pladsId, long ean, string model, Varegruppe varegruppe, string? note = null)
        {
            PladsId = pladsId;
            EAN = ean;
            Model = model;
            Varegruppe = varegruppe;
            Note = note;
        }
    }
}
