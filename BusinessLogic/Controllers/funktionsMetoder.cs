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
        public static List<Plads> FindPladserTilVare(Varegruppe varegruppe)
        {
            return LagerRepository.GetFreePladser(varegruppe);
        }

        public static List<Vare> FindVare(long ean)
        {
            return LagerRepository.GetVareEAN(ean);
        }

        public static List<Plads> HeltAllePladserPaaReol(int reolId)
        {
            return LagerRepository.getAllPladserInReol(reolId);
        }

        public static List<Vare> HentAlleVarerPåPlads(int pladsId)
        {
            return LagerRepository.getAllVareOnPlads(pladsId);
        }
    }
}
