using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BusinessLogic.Controllers
{
    public class CRUDController
    {

        //CRUD Reol
        public static void OpretNyReol(string reolNavn, int pladserBred, int pladserHoej)
        {
            DataAccess.Repository.LagerRepository.AddReol(new Reol(reolNavn, pladserBred, pladserHoej));
        }

        public static void RedigerReol(Reol reol)
        {
            DataAccess.Repository.LagerRepository.EditReol(reol);
        }

        public static void SletReol(Reol reol)
        {
            DataAccess.Repository.LagerRepository.DeleteReol(reol);

        }

        //CRUD PLADS

        public static void OpretPlads(Varegruppe varegruppe, int reolId, int pladsX, int pladsY)
        {
            DataAccess.Repository.LagerRepository.AddPladser(new Plads(varegruppe, reolId, pladsX, pladsY));
        }

        public static void RedigerPlads(Plads plads)
        {
            DataAccess.Repository.LagerRepository.EditPlads(plads);

        }

        public static void SletPlads(Plads plads)
        {
            DataAccess.Repository.LagerRepository.DeletePlads(plads);

        }


        //CRUD VARE

        public static void OpretVare(int pladsId, long ean, string model, Varegruppe varegruppe, string note)
        {
            if(ean.ToString().Length != 13)
            {
                throw new Exception("fejl");
            }
            else
            {
                DataAccess.Repository.LagerRepository.AddVarer(new Vare(pladsId, ean, model, varegruppe, note));
            }

        }

        public static void RedigerVare(Vare vare)
        {
            DataAccess.Repository.LagerRepository.EditVare(vare);

        }

        public static void SletVare(Vare vare)
        {
            DataAccess.Repository.LagerRepository.DeleteVare(vare);
        }


    }
}
