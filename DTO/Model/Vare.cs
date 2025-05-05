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
        public int VareId { get; set; }
        public int PladsId { get; set; }
        public long EAN { get; set; }
        public string Model { get; set; }
        public Varegruppe Varegruppe { get; set; }
        public string? Note { get; set; }

        public Vare(int pladsId, long ean, string model, Varegruppe varegruppe, string? note = null)
        {
            PladsId = pladsId;
            EAN = ean;
            Model = model;
            Varegruppe = varegruppe;
            Note = note;
        }
        public Vare(int vareId, int pladsId, long ean, string model, Varegruppe varegruppe, string? note = null)
        {
            VareId = vareId;
            PladsId = pladsId;
            EAN = ean;
            Model = model;
            Varegruppe = varegruppe;
            Note = note;
        }
    }
}
