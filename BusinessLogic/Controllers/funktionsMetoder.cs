using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DataAccess.Repository;

namespace BusinessLogic.Controllers
{
    public class funktionsMetoder
    {
        public static List<Plads> FindPladserTilVare(Vare vare)
        {
            return LagerRepository.GetFreePladser(vare.Varegruppe);
        }

        public static List<Vare> FindVare(long ean)
        {
            return LagerRepository.GetVareEAN(ean);
        }

        /* - Hvad er tanken her?
        public static void HentAlleVarerPaaReol(int reolId)
        {
            LagerRepository.getAllPladserInReol(reolId);
        }
        */

        public static List<Plads> HeltAllePladserPaaReol(int reolId)
        {
            return LagerRepository.getAllPladserInReol(reolId);
        }

    }
}
