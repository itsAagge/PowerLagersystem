using DataAccess.Context;
using DataAccess.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public static class LagerRepository
    {
        public static DTO.Model.Vare GetVare(int vareId)
        {
            using (LagerContext context = new LagerContext())
            {
                DataAccess.Model.Vare? daVare = context.Varer.Find(vareId);
                if (daVare == null) throw new NullReferenceException("Der findes ikke en vare med vareId: " + vareId + " i databasen");
                return daVare.Map();
            }
        }

        public static void EditVare(DTO.Model.Vare dtoVare)
        {
            using (LagerContext context = new LagerContext())
            {
                DataAccess.Model.Vare? daVare = context.Varer.Find(dtoVare.VareId);
                if (daVare == null) throw new NullReferenceException("Kan ikke gemme varen. Denne vare findes ikke i databasen");
                daVare.UpdateFrom(dtoVare);
                context.SaveChanges();
            }
        }

        public static void AddVarer(params DTO.Model.Vare[] dtoVarer)
        {
            using (LagerContext context = new LagerContext())
            {
                foreach (DTO.Model.Vare dtoVare in dtoVarer)
                {
                    DataAccess.Model.Vare daVare = dtoVare.Map();
                    context.Varer.Add(daVare);
                }
                context.SaveChanges();
            }
        }

        public static void DeleteVare(DTO.Model.Vare dtoVare)
        {
            using (LagerContext context = new LagerContext())
            {
                DataAccess.Model.Vare? daVare = context.Varer.Find(dtoVare.VareId);
                if (daVare == null) throw new NullReferenceException("Kan ikke slette varen. Denne vare findes ikke i databasen");
                context.Varer.Remove(daVare);
                context.SaveChanges();
            }
        }

        public static DTO.Model.Plads GetPlads(int pladsId)
        {
            using (LagerContext context = new LagerContext())
            {
                DataAccess.Model.Plads? daPlads = context.Pladser.Find(pladsId);
                if (daPlads == null) throw new NullReferenceException("Der findes ikke en plads med pladsId: " + pladsId + " i databasen");
                return daPlads.Map();
            }
        }

        public static void EditPlads(DTO.Model.Plads dtoPlads)
        {
            using (LagerContext context = new LagerContext())
            {
                DataAccess.Model.Plads? daPlads = context.Pladser.Find(dtoPlads.PladsId);
                if (daPlads == null) throw new NullReferenceException("Kan ikke gemme pladsen. Denne plads findes ikke i databasen");
                daPlads.UpdateFrom(dtoPlads);
                context.SaveChanges();
            }
        }

        public static void AddPladser(params DTO.Model.Plads[] dtoPladser)
        {
            using (LagerContext context = new LagerContext()) {
                foreach (DTO.Model.Plads dtoPlads in dtoPladser)
                {
                    DataAccess.Model.Plads daPlads = dtoPlads.Map();
                    context.Pladser.Add(daPlads);
                }
                context.SaveChanges();
            }
        }

        public static void DeletePlads(DTO.Model.Plads dtoPlads)
        {
            using (LagerContext context = new LagerContext())
            {
                DataAccess.Model.Plads? daPlads = context.Pladser.Find(dtoPlads.PladsId);
                if (daPlads == null) throw new NullReferenceException("Kan ikke slette pladsen. Denne plads findes ikke i databasen");
                context.Pladser.Remove(daPlads);
                context.SaveChanges();
            }
        }

        public static DTO.Model.Reol GetReol(int reolId)
        {
            using (LagerContext context = new LagerContext())
            {
                DataAccess.Model.Reol? daReol = context.Reoler.Find(reolId);
                if (daReol == null) throw new NullReferenceException("Der findes ikke en reol med reolId: " + reolId + " i databasen");
                return daReol.Map();
            }
        }

        public static void EditReol(DTO.Model.Reol dtoReol)
        {
            using (LagerContext context = new LagerContext())
            {
                DataAccess.Model.Reol? daReol = context.Reoler.Find(dtoReol.ReolId);
                if (daReol == null) throw new NullReferenceException("Kan ikke gemme reolen. Denne reol findes ikke i databasen");
                daReol.UpdateFrom(dtoReol);
                context.SaveChanges();
            }
        }

        public static void AddReol(DTO.Model.Reol dtoReol)
        {
            using (LagerContext context = new LagerContext())
            {
                DataAccess.Model.Reol daReol = dtoReol.Map();
                context.Reoler.Add(daReol);
                context.SaveChanges();
            }
        }

        public static void DeleteReol(DTO.Model.Reol dtoReol)
        {
            using (LagerContext context = new LagerContext())
            {
                DataAccess.Model.Reol? daReol = context.Reoler.Find(dtoReol.ReolId);
                if (daReol == null) throw new NullReferenceException("Kan ikke slette reolen. Denne reol findes ikke i databasen");
                context.Reoler.Remove(daReol);
                context.SaveChanges();
            }
        }

        public static List<DTO.Model.Plads> getAllPladserInReol(int reolId)
        {
            using (LagerContext context = new LagerContext())
            {
                IQueryable<DataAccess.Model.Plads> daPladser = context.Pladser.Where(plads => plads.ReolId == reolId);
                List<DTO.Model.Plads> dtoPladser = new List<DTO.Model.Plads>();
                foreach (DataAccess.Model.Plads daPlads in daPladser)
                {
                    dtoPladser.Add(daPlads.Map());
                }
                return dtoPladser;
            }
        }

        public static List<DTO.Model.Vare> getAllVareOnPlads(int pladsId)
        {
            using (LagerContext context = new LagerContext())
            {
                IQueryable<DataAccess.Model.Vare> daVarer = context.Varer.Where(vare => vare.PladsId == pladsId);
                List<DTO.Model.Vare> dtoVarer = new List<DTO.Model.Vare>();
                foreach (DataAccess.Model.Vare vare in daVarer)
                {
                    dtoVarer.Add(vare.Map());
                }
                return dtoVarer;
            }
        }
    }
}
