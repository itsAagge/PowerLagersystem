using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappings
{
    internal static class ReolMappings
    {
        internal static DTO.Model.Reol Map(this DataAccess.Model.Reol daReol)
        {
            return new DTO.Model.Reol(daReol.ReolId, daReol.ReolNavn, daReol.PladserBred, daReol.PladserHoej);
        }

        internal static DataAccess.Model.Reol Map(this DTO.Model.Reol dtoReol)
        {
            return new DataAccess.Model.Reol(dtoReol.ReolNavn, dtoReol.PladserBred, dtoReol.PladserHoej);
        }

        internal static void UpdateFrom(this DataAccess.Model.Reol daReol, DTO.Model.Reol dtoReol)
        {
            daReol.ReolNavn = dtoReol.ReolNavn;
            daReol.PladserBred = dtoReol.PladserBred;
            daReol.PladserHoej = dtoReol.PladserHoej;
        }
    }
}