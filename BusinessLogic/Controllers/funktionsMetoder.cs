using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Model;

namespace BusinessLogic.Controllers
{
    public class funktionsMetoder
    {
        public static void findPlads(Vare vare)
        {
            
        }

        public static void findVare(long ean)
        {
            DataAccess.Repository.LagerRepository.GetVareEAN(ean);
        }


        public static void HentPlads(int pladsId) 
        {
            DataAccess.Repository.LagerRepository.GetPlads(pladsId);
        }

        public static void HentVare(int vareId) 
        {
            DataAccess.Repository.LagerRepository.GetVare(vareId);
        }

        public static void HentReol(int reolId) 
        {
            DataAccess.Repository.LagerRepository.GetReol(reolId);
        }

        public static void HentAlleVarerPaaReol(int reolId)
        {
            DataAccess.Repository.LagerRepository.getAllPladserInReol(reolId);
        }

        public static void HeltAllePladserPaaReol(int reolId)
        {
            DataAccess.Repository.LagerRepository.getAllPladserInReol(reolId);
        }

    }
}
