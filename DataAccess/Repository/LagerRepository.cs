using DataAccess.Context;
using DataAccess.Mappings;
using DataAccess.Model;
using DTO.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

        public static void AddVare(DTO.Model.Vare dtoVare)
        {
            using (LagerContext context = new LagerContext())
            {
                DataAccess.Model.Vare daVare = dtoVare.Map();
                context.Varer.Add(daVare);
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

        public static void AddPlads(DTO.Model.Plads dtoPlads)
        {
            using (LagerContext context = new LagerContext()) {
                DataAccess.Model.Plads daPlads = dtoPlads.Map();
                context.Pladser.Add(daPlads);
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

        public static DTO.Model.Reol GetNyesteReol()
        {
            using (LagerContext context = new LagerContext())
            {
                DataAccess.Model.Reol? daReol = context.Reoler.OrderByDescending(r => r.ReolId).First();
                if (daReol == null) throw new NullReferenceException("Ingen reoler i databasen");
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

        public static List<DTO.Model.Reol> GetAllReoler()
        {
            using (LagerContext context = new LagerContext())
            {
                IQueryable<DataAccess.Model.Reol> daReoler = context.Reoler;
                List<DTO.Model.Reol> dtoReoler = new List<DTO.Model.Reol>();
                foreach (DataAccess.Model.Reol reol in daReoler)
                {
                    dtoReoler.Add(reol.Map());
                }
                return dtoReoler;
            }
        }

        public static List<DTO.Model.Vare> GetAllVarer()
        {
            using (LagerContext context = new LagerContext())
            {
                IQueryable<DataAccess.Model.Vare> daVarer = context.Varer;
                List<DTO.Model.Vare> dtoVarer = new List<DTO.Model.Vare>();
                foreach (DataAccess.Model.Vare vare in daVarer)
                {
                    dtoVarer.Add(vare.Map());
                }
                return dtoVarer;
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

        public static List<DTO.Model.Vare> GetVareEAN(long Ean)
        {
            using (LagerContext context = new LagerContext())
            {

                IQueryable<DataAccess.Model.Vare> daVarer = context.Varer.Where(vare => vare.EAN == Ean);
                List<DTO.Model.Vare> dtoVarer = new List<DTO.Model.Vare>();
                foreach (DataAccess.Model.Vare vare in daVarer)
                {
                    dtoVarer.Add(vare.Map());
                }
                return dtoVarer;
            }
        }

        public static List<DTO.Model.Plads> GetFreePladser(DTO.Model.Varegruppe varegruppe)
        {
            using (LagerContext context = new LagerContext())
            {
                IQueryable<DataAccess.Model.Plads> daPladser = context.Pladser;
                List<DTO.Model.Plads> dtoPladser = new List<DTO.Model.Plads>();
                int PladsPointsNeeded = (varegruppe == DTO.Model.Varegruppe.Standard) ? 1 : 2;

                foreach (DataAccess.Model.Plads plads in daPladser)
                {
                    int MaxPointPåPladsen = (plads.Varegruppe == DataAccess.Model.Varegruppe.Standard) ? 2 : 4;
                    if (plads.PladsPoint + PladsPointsNeeded <= MaxPointPåPladsen) dtoPladser.Add(plads.Map());
                }

                return dtoPladser;
            }
        }

        public static List<DTO.Model.TemplateVare> GetAllTemplateVarer()
        {
            using (LagerContext context = new LagerContext())
            {
                IQueryable<DataAccess.Model.TemplateVare> daTemplates = context.TemplateVarer;
                List<DTO.Model.TemplateVare> dtoTemplates = new List<DTO.Model.TemplateVare>();
                foreach (DataAccess.Model.TemplateVare daTemplate in daTemplates)
                {
                    dtoTemplates.Add(daTemplate.Map());
                }
                return dtoTemplates;
            }
        }

        public static DTO.Model.TemplateVare GetTemplateVare(long ean)
        {
            using (LagerContext context = new LagerContext())
            {
                DataAccess.Model.TemplateVare? daTemplate = context.TemplateVarer.Find(ean);
                if (daTemplate == null) throw new NullReferenceException("Varen tilhørende dette EAN-nummer findes ikke i databasen");
                return daTemplate.Map();
            }
        }

        public static void AddTemplateVare(DTO.Model.TemplateVare dtoTemplate)
        {
            using (LagerContext context = new LagerContext())
            {
                DataAccess.Model.TemplateVare daTemplate = dtoTemplate.Map();
                context.TemplateVarer.Add(daTemplate);
                context.SaveChanges();
            }
        }

        public static void EditTemplateVare(DTO.Model.TemplateVare dtoTemplate)
        {
            using (LagerContext context = new LagerContext())
            {
                DataAccess.Model.TemplateVare? daTemplate = context.TemplateVarer.Find(dtoTemplate.EAN);
                if (daTemplate == null) throw new NullReferenceException("Kan ikke gemme denne vare template. Den findes ikke i databasen");
                daTemplate.UpdateFrom(dtoTemplate);
                context.SaveChanges();
            }
        }

        public static void DeleteTemplateVare(DTO.Model.TemplateVare dtoTemplate)
        {
            using (LagerContext context = new LagerContext())
            {
                DataAccess.Model.TemplateVare? daTemplate = context.TemplateVarer.Find(dtoTemplate.EAN);
                if (daTemplate == null) throw new NullReferenceException("Kan ikke slette denne vare template. Den findes ikke i databasen");
                context.TemplateVarer.Remove(daTemplate);
                context.SaveChanges();
            }
        }
        public static int GetSenesteVareId()
        {
            using (LagerContext context = new LagerContext())
            {
                if (!context.Varer.Any()) throw new NullReferenceException("Der er ingen varer");
                return context.Varer.Max(v => v.VareId);
            }
        }
    }
}
