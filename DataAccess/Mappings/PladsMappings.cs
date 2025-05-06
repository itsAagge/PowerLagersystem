using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappings
{
    internal static class PladsMappings
    {
        internal static DTO.Model.Plads Map(this DataAccess.Model.Plads daPlads)
        {
            return new DTO.Model.Plads(daPlads.PladsId, (DTO.Model.Varegruppe)daPlads.Varegruppe, daPlads.ReolId, daPlads.PladsX, daPlads.PladsY, daPlads.PladsPoint);
        }

        internal static DataAccess.Model.Plads Map(this DTO.Model.Plads dtoPlads)
        {
            return new DataAccess.Model.Plads((DataAccess.Model.Varegruppe)dtoPlads.Varegruppe, dtoPlads.ReolId, dtoPlads.PladsX, dtoPlads.PladsY, dtoPlads.PladsPoint);
        }

        internal static void UpdateFrom(this DataAccess.Model.Plads daPlads, DTO.Model.Plads dtoPlads)
        {
            daPlads.ReolId = dtoPlads.ReolId;
            daPlads.Varegruppe = (DataAccess.Model.Varegruppe)dtoPlads.Varegruppe;
            daPlads.PladsX = dtoPlads.PladsX;
            daPlads.PladsY = dtoPlads.PladsY;
            daPlads.PladsPoint = dtoPlads.PladsPoint;
        }
    }
}