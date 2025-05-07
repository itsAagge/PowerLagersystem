using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    [Table("TemplateVare")]
    internal class TemplateVare
    {
        [Key]
        public long EAN { get; set; }
        public string Model { get; set; }
        public Varegruppe Varegruppe { get; set; }

        public TemplateVare() { }

        public TemplateVare(long ean, string model, Varegruppe varegruppe)
        {
            EAN = ean;
            Model = model;
            Varegruppe = varegruppe;
        }
    }
}
