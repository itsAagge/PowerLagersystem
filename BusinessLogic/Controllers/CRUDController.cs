using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public static void RedigerReol(Reol valgtReol, string reolNavn, int pladserBred, int pladserHoej)
        {
            valgtReol.ReolNavn = reolNavn;
            valgtReol.PladserBred = pladserBred;
            valgtReol.PladserHoej = pladserHoej;

            LagerRepository.EditReol(valgtReol);
        }

        public static void SletReol(Reol reol)
        {
            LagerRepository.DeleteReol(reol);

        }

        //CRUD PLADS

        public static Plads HentPlads(int pladsId)
        {
            return LagerRepository.GetPlads(pladsId);
        }

        public static void OpretPlads(Varegruppe varegruppe, int reolId, int pladsX, int pladsY)
        {
            Reol reol = LagerRepository.GetReol(reolId);
            if (pladsX > reol.PladserBred || pladsY > reol.PladserHoej) throw new ArgumentException("Pladsen kan ikke oprettes med disse x og y koordinater");

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
            LagerRepository.DeletePlads(plads);
        }


        //CRUD VARE

        public static Vare HentVare(int vareId)
        {
            return LagerRepository.GetVare(vareId);
        }

        public static void OpretVare(int pladsId, long ean, string model, Varegruppe varegruppe, string note)
        {
            if (ean.ToString().Length != 13)
            {
                throw new ArgumentException("EAN skal være på præcis 13 cifre");
            }
            LagerRepository.AddVare(new Vare(pladsId, ean, model, varegruppe, note));

            Plads plads = LagerRepository.GetPlads(pladsId);
            plads.PladsPoint += (varegruppe == Varegruppe.Standard) ? 1 : 2;
            LagerRepository.EditPlads(plads);
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
    }
}
