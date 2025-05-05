using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public enum Varegruppe
    {
        Standard,
        Hoej,
        Special
    }
    public class Vare
    {
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
