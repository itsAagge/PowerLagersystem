using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class TemplateVare
    {
        public long EAN { get; set; }
        public string Model { get; set; }
        public Varegruppe Varegruppe { get; set; }

        public TemplateVare(long ean, string model, Varegruppe varegruppe)
        {
            EAN = ean;
            Model = model;
            Varegruppe = varegruppe;
        }
    }
}
