using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class LagerContext : DbContext
    {
        public LagerContext() 
        {
            bool created = Database.EnsureCreated();
            if (created)
            {
                Debug.WriteLine("Database created");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("Power_DB_Connection_String"));
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vare>().HasData(new Vare[]
            {
                new Vare{VareId=1, EAN=8806088219394, Model="Samsung MS23K3555EW Mikroovn", Varegruppe=Varegruppe.Standard}, //mikrobølgeovn
                new Vare{VareId=2, EAN=7333394059730, Model="Electrolux 600-serien NNP6ME32U Kombineret køleskab", Varegruppe=Varegruppe.Hoej}, //Køleskab
                new Vare{VareId=3, EAN=4894526095192, Model="Kulz KCF500EW Kummefryser", Varegruppe=Varegruppe.Special}, //Kummefryser **Special tilfælde
                new Vare{VareId=4, EAN=4242005459162, Model="Bosch Serie 4 SMU4HMWOOS Opvaskemaskine", Varegruppe=Varegruppe.Standard}, //Opvaskemaskine
                new Vare{VareId=5, EAN=5703347533051, Model="Thermex Design Line 8002 emhætte, 80 cm", Varegruppe=Varegruppe.Standard},  //emhætte
                new Vare{VareId=6, EAN=7333394059730, Model="Electrolux 600-serien NNP6ME32U Kombineret køleskab", Varegruppe=Varegruppe.Hoej},
                new Vare{VareId=7, EAN=4242005459162, Model="Bosch Serie 4 SMU4HMWOOS Opvaskemaskine", Varegruppe=Varegruppe.Standard},
                new Vare{VareId=8, EAN=4242005459162, Model="Bosch Serie 4 SMU4HMWOOS Opvaskemaskine", Varegruppe=Varegruppe.Standard},
                new Vare{VareId=9, EAN=4242005459162, Model="Bosch Serie 4 SMU4HMWOOS Opvaskemaskine", Varegruppe=Varegruppe.Standard},
                new Vare{VareId=10, EAN=8806091538420, Model="LG GFT61MBCSZ Fryser", Varegruppe=Varegruppe.Hoej}, //Fryser
                new Vare{VareId=11, EAN=4242003955864, Model="Siemens iQ300 HB273ABS3", Varegruppe=Varegruppe.Standard}, //Ovn
                new Vare{VareId=12, EAN=7332543977994, Model="AEG 6000-serien FBB63927ZW Opvaskemaskine", Varegruppe=Varegruppe.Standard}, //Opvaskemaskine
                new Vare{VareId=13, EAN=7332543977994, Model="AEG 6000-serien FBB63927ZW Opvaskemaskine", Varegruppe=Varegruppe.Standard},
                new Vare{VareId=14, EAN=3838782745515, Model="Gorenje Essential Line EC9647PW Keramisk Komfur", Varegruppe=Varegruppe.Standard}, //komfur
                new Vare{VareId=15, EAN=4894526081713, Model="Senz SEWM1D712S Vaskemaskine", Varegruppe=Varegruppe.Standard}, //vaskemaskine
                new Vare{VareId=16, EAN=8806094559279, Model="Samsung DV90BB7445GBS4 Tørretumbler", Varegruppe=Varegruppe.Standard}, //tørretumbler
                new Vare{VareId=17, EAN=8806091335661, Model="LG P0AVVR2W9 Tørretumbler", Varegruppe=Varegruppe.Standard}, //tørretumbler
                new Vare{VareId=18, EAN=4894526082482, Model="Point 5-Series POWF51712 Vinskab", Varegruppe=Varegruppe.Hoej}, //vinskab
                new Vare{VareId=19, EAN=7333394077178, Model="AEG 6000-serien TK6DS18XDC integreret køleskab", Varegruppe=Varegruppe.Hoej}, //køleskab
                new Vare{VareId=20, EAN=4002516467106, Model="Miele W1 WWD020 WCS Vaskemaskine", Varegruppe=Varegruppe.Standard} //vaskemaskine
            });

            //Er det korrekt forstået med bredde og højde???
            modelBuilder.Entity<Reol>().HasData(new Reol[]
            {
                new Reol{ReolId=1, ReolNavn="A", PladserBred=7, PladserHoej=4},
                new Reol{ReolNavn="B", PladserBred=7, PladserHoej=4},
                new Reol{ReolNavn="C", PladserBred=7, PladserHoej=4},
                new Reol{ReolNavn="D", PladserBred=6, PladserHoej=4},
                new Reol{ReolNavn="TV", PladserBred=3, PladserHoej=2},
                new Reol{ReolNavn="Emhætter", PladserBred=3, PladserHoej=1},
                new Reol{ReolNavn="E", PladserBred=6, PladserHoej=4 },
                new Reol{ReolNavn="Butik", PladserBred=-1, PladserHoej=-1}

            });

            //Ændre Istedet for Reol reol, at den hænger sammen med id
            //Således sammenhængen er i DB istedet for systemet, snak med gruppe
            modelBuilder.Entity<Plads>().HasData(new Plads[]
           {
               new Plads{Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=1, PladsY=1},
               new Plads{Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=2, PladsY=1},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=3, PladsY=1},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=4, PladsY=1},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=5, PladsY=1},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=6, PladsY=1},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=7, PladsY=1},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=3, PladsY=2},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=4, PladsY=2},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=5, PladsY=2},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=6, PladsY=2},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=7, PladsY=2},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=1, PladsY=3},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=2, PladsY=3},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=3, PladsY=3},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=4, PladsY=3},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=5, PladsY=3},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=6, PladsY=3},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=7, PladsY=3},
               new Plads{Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=1, PladsY=4},
               new Plads{Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=2, PladsY=4},
               new Plads{Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=3, PladsY=4},
               new Plads{Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=4, PladsY=4},
               new Plads{Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=5, PladsY=4},
               new Plads{Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=6, PladsY=4},
               new Plads{Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=7, PladsY=4},

               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=1, PladsY=1},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=2, PladsY=1},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=3, PladsY=1},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=4, PladsY=1},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=5, PladsY=1},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=6, PladsY=1},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=7, PladsY=1},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=1, PladsY=2},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=2, PladsY=2},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=3, PladsY=2},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=4, PladsY=2},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=5, PladsY=2},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=6, PladsY=2},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=7, PladsY=2},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=1, PladsY=3},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=2, PladsY=3},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=3, PladsY=3},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=4, PladsY=3},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=5, PladsY=3},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=6, PladsY=3},
               new Plads{Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=7, PladsY=3},
               new Plads{Varegruppe=Varegruppe.Hoej, ReolId=2, PladsX=1, PladsY=4},
               new Plads{Varegruppe=Varegruppe.Hoej, ReolId=2, PladsX=2, PladsY=4},
               new Plads{Varegruppe=Varegruppe.Hoej, ReolId=2, PladsX=3, PladsY=4},
               new Plads{Varegruppe=Varegruppe.Hoej, ReolId=2, PladsX=4, PladsY=4},
               new Plads{Varegruppe=Varegruppe.Hoej, ReolId=2, PladsX=5, PladsY=4},
               new Plads{Varegruppe=Varegruppe.Hoej, ReolId=2, PladsX=6, PladsY=4},
               new Plads{Varegruppe=Varegruppe.Hoej, ReolId=2, PladsX=7, PladsY=4}


           });

        }

        public DbSet<Plads> Pladser { get; set; }
        public DbSet<Reol> Reoler { get; set; }
        public DbSet<Vare> Varer { get; set; }
    }
}
