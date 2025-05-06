using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class Reol
    {
        public int ReolId { get; set; }
        [Required(ErrorMessage = "Reolen skal navngives")]
        public string ReolNavn { get; set; }
        [Required(ErrorMessage = "Pladser bred skal have en værdi")]
        public int PladserBred { get; set; }
        [Required(ErrorMessage = "Pladser høj skal have en værdi")]
        public int PladserHoej { get; set; }

        public Reol(string reolNavn, int pladserBred, int pladserHoej)
        {
            ReolNavn = reolNavn;
            PladserBred = pladserBred;
            PladserHoej = pladserHoej;
        }
        public Reol(int reolId, string reolNavn, int pladserBred, int pladserHoej)
        {
            ReolId = reolId;
            ReolNavn = reolNavn;
            PladserBred = pladserBred;
            PladserHoej = pladserHoej;
        }
    }
}
