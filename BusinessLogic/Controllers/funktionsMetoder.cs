using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DataAccess.Repository;
using Microsoft.IdentityModel.Tokens;

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

        public static void ForøgVaregruppePåPladsenUnder(int reolId, int pladsX, int pladsY)
        {
            Plads? pladsBelow = LagerRepository.GetPladsOrNull(reolId, pladsX, pladsY - 1);
            if (pladsBelow != null && pladsBelow.Varegruppe == Varegruppe.Standard)
            {
                pladsBelow.Varegruppe = Varegruppe.Hoej;
                LagerRepository.EditPlads(pladsBelow);
            }
        }

        public static void FormindskVaregruppePåPladsenUnder(int reolId, int pladsX, int pladsY) 
        {
            Plads? pladsBelow = LagerRepository.GetPladsOrNull(reolId, pladsX, pladsY - 1);
            if (pladsBelow != null && pladsBelow.Varegruppe == Varegruppe.Hoej)
            {
                List<Vare> vareOnPladsBelow = LagerRepository.getAllVareOnPlads(pladsBelow.PladsId);
                if (!vareOnPladsBelow.IsNullOrEmpty()) {

                    bool højVarePåPlads = false;
                    foreach (Vare vare in vareOnPladsBelow)
                    {
                        if (vare.Varegruppe == Varegruppe.Hoej) højVarePåPlads = true;
                    }
                    if (højVarePåPlads) throw new ArgumentException("Der står en høj vare på pladsen under, som skal fjernes først");
                    if (pladsBelow.PladsPoint > 2) throw new ArgumentException("Der er for mange varer på pladsen under, fjern dem til der maks er 2 standardvarer på pladsen");
                }
                pladsBelow.Varegruppe = Varegruppe.Standard;
                LagerRepository.EditPlads(pladsBelow);
            }
        }
    }
}
