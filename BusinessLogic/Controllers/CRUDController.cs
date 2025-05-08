using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Diagnostics;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogic.Controllers
{
    public class CRUDController
    {

        //CRUD Reol
        public static Reol HentReol(int reolId)
        {
            return LagerRepository.GetReol(reolId);
        }

        public static List<Reol> HentAlleReoler()
        {
            return LagerRepository.GetAllReoler();
        }

        public static List<Vare> HentAlleVarer()
        {
            return LagerRepository.GetAllVarer();
        }

        public static void OpretNyReol(string reolNavn, int pladserBred, int pladserHoej)
        {
            LagerRepository.AddReol(new Reol(reolNavn, pladserBred, pladserHoej));
            //Lav pladser
        }
        public static Reol GetNyesteReol()
        {
            return LagerRepository.GetNyesteReol();
        }

        public static void RedigerReol(Reol valgtReol, string reolNavn, int pladserBred, int pladserHoej)
        {
            valgtReol.ReolNavn = reolNavn;
            valgtReol.PladserBred = pladserBred;
            valgtReol.PladserHoej = pladserHoej;

            LagerRepository.EditReol(valgtReol);
        }

        public static void SletReol(Reol reol)
        {
            if (reol.ReolNavn == "Butik") throw new ArgumentException("Du kan ikke slette butikken");
            LagerRepository.DeleteReol(reol);

        }

        //CRUD PLADS

        public static Plads HentPlads(int pladsId)
        {
            return LagerRepository.GetPlads(pladsId);
        }

        public static void OpretPlads(int reolId, int pladsX, int pladsY)
        {
            Reol reol = LagerRepository.GetReol(reolId);
            if (pladsX > reol.PladserBred || pladsY > reol.PladserHoej) throw new ArgumentException("Pladsen kan ikke oprettes med disse x og y koordinater");
            if (LagerRepository.GetPladsOrNull(reolId, pladsX, pladsY) != null) throw new ArgumentException("Denne plads findes allerede");

            Varegruppe varegruppe = Varegruppe.Hoej;
            if (LagerRepository.GetPladsOrNull(reolId, pladsX, pladsY + 1) != null) varegruppe = Varegruppe.Standard;

            funktionsMetoder.FormindskVaregruppePåPladsenUnder(reolId, pladsX, pladsY);
            LagerRepository.AddPlads(new Plads(varegruppe, reolId, pladsX, pladsY));
        }

        public static void RedigerPlads(Plads valgtPlads, Varegruppe varegruppe, int reolId, int pladsX, int pladsY)
        {
            valgtPlads.Varegruppe = varegruppe;
            valgtPlads.ReolId = reolId;
            valgtPlads.PladsX = pladsX;
            valgtPlads.PladsY = pladsY;

            LagerRepository.EditPlads(valgtPlads);
        }

        public static void SletPlads(Plads plads)
        {
            if (!funktionsMetoder.HentAlleVarerPåPlads(plads.PladsId).IsNullOrEmpty()) throw new ArgumentException("Du kan ikke slette en plads, der står varer på");
            funktionsMetoder.ForøgVaregruppePåPladsenUnder(plads.PladsId, plads.PladsX, plads.PladsY);
            LagerRepository.DeletePlads(plads);
        }


        //CRUD VARE

        public static Vare HentVare(int vareId)
        {
            return LagerRepository.GetVare(vareId);
        }
        public static int HentSenesteVare()
        {
            return LagerRepository.GetSenesteVareId();
        }

        public static void OpretVare(int pladsId, long ean, string model, Varegruppe varegruppe, string note)
        {

            if (!validerEAN(ean)) throw new ArgumentException("EAN skal være på præcis 13 cifre");
            Plads plads = LagerRepository.GetPlads(pladsId);

            if (varegruppe == Varegruppe.Standard || varegruppe == plads.Varegruppe)
            {
                LagerRepository.AddVare(new Vare(pladsId, ean, model, varegruppe, note));

                plads.PladsPoint += (varegruppe == Varegruppe.Standard) ? 1 : 2;
                LagerRepository.EditPlads(plads);
            } else
            {
                throw new ArgumentException("Varen Kan ikke være på angivne plads");
            }
        }

        public static void RedigerVare(Vare valgtVare, int pladsId, long ean, string model, Varegruppe varegruppe, string note)
        {
            valgtVare.PladsId = pladsId;
            valgtVare.EAN = ean;
            valgtVare.Model = model;
            valgtVare.Varegruppe = varegruppe;
            valgtVare.Note = note;

            LagerRepository.EditVare(valgtVare);
        }

        public static void SletVare(Vare valgtVare)
        {
            FlytVare(valgtVare, null);
        }

        public static void FlytVare(Vare valgtVare, Plads? nyPlads)
        {
            Plads gammelPlads = LagerRepository.GetPlads(valgtVare.PladsId);
            if (gammelPlads.PladsPoint != -1)
            {
                gammelPlads.PladsPoint -= (valgtVare.Varegruppe == Varegruppe.Standard) ? 1 : 2; //Man bør nok sikre, at PladsPoint ikke kommer under 0 (Kun butik pladsen bør have -1)
                LagerRepository.EditPlads(gammelPlads);
            }
            if (nyPlads != null)
            {
                if (nyPlads.PladsPoint != -1)
                {
                    nyPlads.PladsPoint += (valgtVare.Varegruppe == Varegruppe.Standard) ? 1 : 2; //Samme her
                    LagerRepository.EditPlads(nyPlads);
                }
                valgtVare.PladsId = nyPlads.PladsId;
                LagerRepository.EditVare(valgtVare);
            } else
            {
                LagerRepository.DeleteVare(valgtVare);
            }
        }

        //CRUD TemplateVarer
        public static TemplateVare HentTemplateVare(long ean)
        {
            return LagerRepository.GetTemplateVare(ean);
        }

        public static List<TemplateVare> HentAlleTemplateVarer()
        {
            return LagerRepository.GetAllTemplateVarer();
        }

        public static void OpretTemplateVare(long ean, string model, Varegruppe varegruppe)
        {
            if (!validerEAN(ean)) throw new ArgumentException("EAN skal være på præcis 13 cifre");
            LagerRepository.AddTemplateVare(new TemplateVare(ean, model, varegruppe));
        }

        public static void RedigerTemplateVare(TemplateVare valgtTemplate, long ean, string model, Varegruppe varegruppe)
        {
            valgtTemplate.EAN = ean;
            valgtTemplate.Model = model;
            valgtTemplate.Varegruppe = varegruppe;

            LagerRepository.EditTemplateVare(valgtTemplate);
        }

        public static void SletTemplateVare(TemplateVare template)
        {
            LagerRepository.DeleteTemplateVare(template);
        }

        //Hjælpemetoder
        public static bool validerEAN(long ean)
        {
            if (ean.ToString().Length != 13)
            {
                return false;
            }
            return true;
        }
    }
}
