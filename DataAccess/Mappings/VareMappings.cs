using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappings
{
    internal static class VareMappings
    {
        internal static DTO.Model.Vare Map(this DataAccess.Model.Vare daVare)
        {
            return new DTO.Model.Vare(daVare.VareId, daVare.PladsId, daVare.EAN, daVare.Model, (DTO.Model.Varegruppe)daVare.Varegruppe, daVare.Note);
        }

        internal static DataAccess.Model.Vare Map(this DTO.Model.Vare dtoVare)
        {
            return new DataAccess.Model.Vare(dtoVare.PladsId, dtoVare.EAN, dtoVare.Model, (DataAccess.Model.Varegruppe)dtoVare.Varegruppe, dtoVare.Note);
        }

        internal static void UpdateFrom(this DataAccess.Model.Vare daVare, DTO.Model.Vare dtoVare)
        {
            daVare.PladsId = dtoVare.PladsId;
            daVare.EAN = dtoVare.EAN;
            daVare.Model = dtoVare.Model;
            daVare.Varegruppe = (DataAccess.Model.Varegruppe)dtoVare.Varegruppe;
            daVare.Note = dtoVare.Note;
        }
    }
}
