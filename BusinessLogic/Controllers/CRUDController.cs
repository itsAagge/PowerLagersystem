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
        public static void OpretNyReol(string reolId, int pladserBred, int pladserHoej)
        {
            
        }

        public static void RedigerReol(Reol reol)
        {

        }

        public static void SletReol(Reol reol)
        {

        }

        //CRUD PLADS

        public static void OpretPlads(Varegruppe varegruppe, Reol reol, int pladsX, int pladsY)
        {

        }

        public static void RedigerPlads()
        {

        }

        public static void SletPlads()
        {

        }


        //CRUD VARE

        public static void OpretVare(int vareId, long ean, string model, Varegruppe varegruppe, string note)
        {
            if(ean.ToString().Length != 13)
            {
                throw new Exception("fejl");
            }
            else
            {

            }

        }


    }
}
