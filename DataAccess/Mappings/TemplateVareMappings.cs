using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappings
{
    internal static class TemplateVareMappings
    {
        internal static DTO.Model.TemplateVare Map(this DataAccess.Model.TemplateVare daTemplate)
        {
            return new DTO.Model.TemplateVare(daTemplate.EAN, daTemplate.Model, (DTO.Model.Varegruppe)daTemplate.Varegruppe);
        }

        internal static DataAccess.Model.TemplateVare Map(this DTO.Model.TemplateVare dtoTemplate)
        {
            return new DataAccess.Model.TemplateVare(dtoTemplate.EAN, dtoTemplate.Model, (DataAccess.Model.Varegruppe)dtoTemplate.Varegruppe);
        }

        internal static void UpdateFrom(this DataAccess.Model.TemplateVare daTemplate, DTO.Model.TemplateVare dtoTemplate)
        {
            daTemplate.EAN = dtoTemplate.EAN;
            daTemplate.Model = dtoTemplate.Model;
            daTemplate.Varegruppe = (DataAccess.Model.Varegruppe)dtoTemplate.Varegruppe;
        }
    }
}
