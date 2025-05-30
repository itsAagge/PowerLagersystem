﻿using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    internal class LagerContext : DbContext
    {
        internal LagerContext() 
        {
            bool created = Database.EnsureCreated();
            if (created)
            {
                Debug.WriteLine("Database created");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Connection.ConnectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reol>().HasData(new Reol[]
            {
                new Reol{ReolId=1, ReolNavn="A", PladserBred=7, PladserHoej=4},
                new Reol{ReolId=2, ReolNavn="B", PladserBred=7, PladserHoej=4},
                new Reol{ReolId=3, ReolNavn="C", PladserBred=7, PladserHoej=4},
                new Reol{ReolId=4, ReolNavn="D", PladserBred=6, PladserHoej=4},
                new Reol{ReolId=5, ReolNavn="TV", PladserBred=3, PladserHoej=2},
                new Reol{ReolId=6, ReolNavn="Emhætter", PladserBred=3, PladserHoej=1},
                new Reol{ReolId=7, ReolNavn="E", PladserBred=6, PladserHoej=4 },
                new Reol{ReolId=8, ReolNavn="Butik", PladserBred=-1, PladserHoej=-1}

            });

            modelBuilder.Entity<Plads>().HasData(new Plads[]
           {
               new Plads{PladsId=1, Varegruppe=Varegruppe.Special, ReolId=8, PladsX=-1, PladsY=-1, PladsPoint=-1},
               new Plads{PladsId=2, Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=1, PladsY=1},
               new Plads{PladsId=3, Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=2, PladsY=1},
               new Plads{PladsId=4, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=3, PladsY=1},
               new Plads{PladsId=5, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=4, PladsY=1},
               new Plads{PladsId=6, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=5, PladsY=1},
               new Plads{PladsId=7, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=6, PladsY=1},
               new Plads{PladsId=8, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=7, PladsY=1},
               new Plads{PladsId=9, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=3, PladsY=2},
               new Plads{PladsId=10, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=4, PladsY=2},
               new Plads{PladsId=11, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=5, PladsY=2},
               new Plads{PladsId=12, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=6, PladsY=2},
               new Plads{PladsId=13, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=7, PladsY=2},
               new Plads{PladsId=14, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=1, PladsY=3},
               new Plads{PladsId=15, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=2, PladsY=3},
               new Plads{PladsId=16, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=3, PladsY=3},
               new Plads{PladsId=17, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=4, PladsY=3},
               new Plads{PladsId=18, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=5, PladsY=3},
               new Plads{PladsId=19, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=6, PladsY=3},
               new Plads{PladsId=20, Varegruppe=Varegruppe.Standard, ReolId=1, PladsX=7, PladsY=3},
               new Plads{PladsId=21, Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=1, PladsY=4},
               new Plads{PladsId=22, Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=2, PladsY=4},
               new Plads{PladsId=23, Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=3, PladsY=4},
               new Plads{PladsId=24, Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=4, PladsY=4},
               new Plads{PladsId=25, Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=5, PladsY=4},
               new Plads{PladsId=26, Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=6, PladsY=4},
               new Plads{PladsId=28, Varegruppe=Varegruppe.Hoej, ReolId=1, PladsX=7, PladsY=4},

               new Plads{PladsId=29, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=1, PladsY=1},
               new Plads{PladsId=30, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=2, PladsY=1},
               new Plads{PladsId=31, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=3, PladsY=1},
               new Plads{PladsId=32, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=4, PladsY=1},
               new Plads{PladsId=33, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=5, PladsY=1},
               new Plads{PladsId=34, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=6, PladsY=1},
               new Plads{PladsId=35, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=7, PladsY=1},
               new Plads{PladsId=36, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=1, PladsY=2},
               new Plads{PladsId=37, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=2, PladsY=2},
               new Plads{PladsId=38, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=3, PladsY=2},
               new Plads{PladsId=39, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=4, PladsY=2},
               new Plads{PladsId=40, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=5, PladsY=2},
               new Plads{PladsId=41, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=6, PladsY=2},
               new Plads{PladsId=42, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=7, PladsY=2},
               new Plads{PladsId=43, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=1, PladsY=3},
               new Plads{PladsId=44, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=2, PladsY=3},
               new Plads{PladsId=45, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=3, PladsY=3},
               new Plads{PladsId=46, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=4, PladsY=3},
               new Plads{PladsId=47, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=5, PladsY=3},
               new Plads{PladsId=48, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=6, PladsY=3},
               new Plads{PladsId=49, Varegruppe=Varegruppe.Standard, ReolId=2, PladsX=7, PladsY=3},
               new Plads{PladsId=50, Varegruppe=Varegruppe.Hoej, ReolId=2, PladsX=1, PladsY=4},
               new Plads{PladsId=51, Varegruppe=Varegruppe.Hoej, ReolId=2, PladsX=2, PladsY=4},
               new Plads{PladsId=52, Varegruppe=Varegruppe.Hoej, ReolId=2, PladsX=3, PladsY=4},
               new Plads{PladsId=53, Varegruppe=Varegruppe.Hoej, ReolId=2, PladsX=4, PladsY=4},
               new Plads{PladsId=54, Varegruppe=Varegruppe.Hoej, ReolId=2, PladsX=5, PladsY=4},
               new Plads{PladsId=55, Varegruppe=Varegruppe.Hoej, ReolId=2, PladsX=6, PladsY=4},
               new Plads{PladsId=56, Varegruppe=Varegruppe.Hoej, ReolId=2, PladsX=7, PladsY=4}
            });

            modelBuilder.Entity<Vare>().HasData(new Vare[]
            {
                new Vare{VareId=1, PladsId=4, EAN=8806088219394, Model="MS23K3555EW", Varegruppe=Varegruppe.Standard}, //mikrobølgeovn
                new Vare{VareId=2, PladsId=21, EAN=7333394059730, Model="NNP6ME32U", Varegruppe=Varegruppe.Hoej}, //Køleskab
                new Vare{VareId=3, PladsId=1, EAN=4894526095192, Model="KCF500EW", Varegruppe=Varegruppe.Special}, //Kummefryser **Special tilfælde
                new Vare{VareId=4, PladsId=4, EAN=4242005459162, Model="SMU4HMWOOS", Varegruppe=Varegruppe.Standard}, //Opvaskemaskine
                new Vare{VareId=5, PladsId=16, EAN=5703347533051, Model="T80025662", Varegruppe=Varegruppe.Standard},  //emhætte
                new Vare{VareId=6, PladsId=21, EAN=7333394059730, Model="NNP6ME32U", Varegruppe=Varegruppe.Hoej},
                new Vare{VareId=7, PladsId=10, EAN=4242005459162, Model="SMU4HMWOOS", Varegruppe=Varegruppe.Standard, Note="Ridset side"},
                new Vare{VareId=8, PladsId=10, EAN=4242005459162, Model="SMU4HMWOOS", Varegruppe=Varegruppe.Standard},
                new Vare{VareId=9, PladsId=5, EAN=4242005459162, Model="SMU4HMWOOS", Varegruppe=Varegruppe.Standard, Note="EMB beskadiget"},
                new Vare{VareId=10, PladsId=22, EAN=8806091538420, Model="GFT61MBCSZ", Varegruppe=Varegruppe.Hoej}, //Fryser
                new Vare{VareId=11, PladsId=5, EAN=4242003955864, Model="HB273ABS3", Varegruppe=Varegruppe.Standard}, //Ovn
                new Vare{VareId=12, PladsId=9, EAN=7332543977994, Model="FBB63927ZW", Varegruppe=Varegruppe.Standard}, //Opvaskemaskine
                new Vare{VareId=13, PladsId=9, EAN=7332543977994, Model="FBB63927ZW", Varegruppe=Varegruppe.Standard},
                new Vare{VareId=14, PladsId=2, EAN=3838782745515, Model="EC9647PW", Varegruppe=Varegruppe.Hoej}, //komfur
                new Vare{VareId=15, PladsId=6, EAN=4894526081713, Model="SEWM1D712S", Varegruppe=Varegruppe.Standard}, //vaskemaskine
                new Vare{VareId=16, PladsId=6, EAN=8806094559279, Model="DV90BB7445GBS4", Varegruppe=Varegruppe.Standard}, //tørretumbler
                new Vare{VareId=17, PladsId=7, EAN=8806091335661, Model="P0AVVR2W9", Varegruppe=Varegruppe.Standard}, //tørretumbler
                new Vare{VareId=18, PladsId=22, EAN=4894526082482, Model="POWF51712", Varegruppe=Varegruppe.Hoej}, //vinskab
                new Vare{VareId=19, PladsId=23, EAN=7333394077178, Model="TK6DS18XDC", Varegruppe=Varegruppe.Hoej}, //køleskab
                new Vare{VareId=20, PladsId=7, EAN=4002516467106, Model="WWD020WCS", Varegruppe=Varegruppe.Standard} //vaskemaskine
            });
            
            modelBuilder.Entity<TemplateVare>().HasData(new TemplateVare[]
            {
                new TemplateVare{EAN=8806088219394, Model="MS23K3555EW", Varegruppe=Varegruppe.Standard}, //mikrobølgeovn
                new TemplateVare{EAN=7333394059730, Model="NNP6ME32U", Varegruppe=Varegruppe.Hoej}, //Køleskab
                new TemplateVare{EAN=4894526095192, Model="KCF500EW", Varegruppe=Varegruppe.Special}, //Kummefryser **Special tilfælde
                new TemplateVare{EAN=4242005459162, Model="SMU4HMWOOS", Varegruppe=Varegruppe.Standard}, //Opvaskemaskine
                new TemplateVare{EAN=5703347533051, Model="T80025662", Varegruppe=Varegruppe.Standard},  //emhætte
                new TemplateVare{EAN=8806091538420, Model="GFT61MBCSZ", Varegruppe=Varegruppe.Hoej}, //Fryser
                new TemplateVare{EAN=4242003955864, Model="HB273ABS3", Varegruppe=Varegruppe.Standard}, //Ovn
                new TemplateVare{EAN=7332543977994, Model="FBB63927ZW", Varegruppe=Varegruppe.Standard}, //Opvaskemaskine
                new TemplateVare{EAN=3838782745515, Model="EC9647PW", Varegruppe=Varegruppe.Hoej}, //komfur
                new TemplateVare{EAN=4894526081713, Model="SEWM1D712S", Varegruppe=Varegruppe.Standard}, //vaskemaskine
                new TemplateVare{EAN=8806094559279, Model="DV90BB7445GBS4", Varegruppe=Varegruppe.Standard}, //tørretumbler
                new TemplateVare{EAN=8806091335661, Model="P0AVVR2W9", Varegruppe=Varegruppe.Standard}, //tørretumbler
                new TemplateVare{EAN=4894526082482, Model="POWF51712", Varegruppe=Varegruppe.Hoej}, //vinskab
                new TemplateVare{EAN=7333394077178, Model="TK6DS18XDC", Varegruppe=Varegruppe.Hoej}, //køleskab
                new TemplateVare{EAN=4002516467106, Model="WWD020WCS", Varegruppe=Varegruppe.Standard}, //vaskemaskine
                new TemplateVare{EAN=4002516467109, Model="Testing123", Varegruppe=Varegruppe.Standard} //Testvare - findes ikke i virkeligheden
            });
        }
          
        public DbSet<Plads> Pladser { get; set; }
        public DbSet<Reol> Reoler { get; set; }
        public DbSet<Vare> Varer { get; set; }
        public DbSet<TemplateVare> TemplateVarer { get; set; }
    }
}
