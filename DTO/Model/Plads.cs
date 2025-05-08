using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO.Model
{
    public class Plads
    {
        public int PladsId { get; set; }

        [Required(ErrorMessage = "Reol ID skal udfyldes")]
        public int ReolId { get; set; }

        [Required(ErrorMessage ="Plads X skal udfyldes")]
        public int PladsX { get; set; }

        [Required(ErrorMessage = "Plads y skal udfyldes")]
        public int PladsY { get; set; }

        [Required(ErrorMessage = "Type af Varegruppe skal udvælges")]
        public Varegruppe Varegruppe { get; set; }

        public int PladsPoint { get; set; }

        public Plads(Varegruppe varegruppe, int reolId, int pladsX, int pladsY)
        {
            ReolId = reolId;
            PladsX = pladsX;
            PladsY = pladsY;
            Varegruppe = varegruppe;
            PladsPoint = 0;
            
        }

        public Plads(int pladsId, Varegruppe varegruppe, int reolId, int pladsX, int pladsY, int pladsPoint)
        {
            PladsId = pladsId;
            ReolId = reolId;
            PladsX = pladsX;
            PladsY = pladsY;
            Varegruppe = varegruppe;
            PladsPoint = pladsPoint;
        }

        public override string ToString()
        {
            return $"Plads: {PladsX}, {PladsY}" ;
        }

        public override bool Equals(object? obj)
        {
            Plads plads = obj as Plads;
            if (plads == null) return false;
            return PladsId == plads.PladsId;
        }

        public override int GetHashCode()
        {
            return PladsId.GetHashCode();
        }
    }
}
