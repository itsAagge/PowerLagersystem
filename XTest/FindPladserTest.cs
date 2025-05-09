using DataAccess.Repository;
using DTO.Model;
using BusinessLogic.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
namespace XTest
{
    public class FindPladserTest
    {
        [Fact]
        public void FindPladserTilVareStandard()
        {
            //standard vare opvasker
            Vare vareTest = LagerRepository.GetVare(12);
            List<Plads> pladser = funktionsMetoder.FindPladserTilVare(vareTest.Varegruppe);
            List<int> forventetPladsId = [1, 2, 3, 8, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 23, 24, 25, 26, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56];
            //Tjekker for hver plads om den er der
            foreach (int i in forventetPladsId)
            {
                Plads plads = CRUDController.HentPlads(i);
                //Assert.Contains(plads, pladser);
                Assert.Contains(plads, pladser);
            }
        }

        [Fact]
        public void FindPladserTilVareHoej()
        {
            //Hoej vare vinskab
            Vare vareTest = LagerRepository.GetVare(18);
            List<Plads> pladser = funktionsMetoder.FindPladserTilVare(vareTest.Varegruppe);
            List<int> forventetPladsId = [1, 2, 3, 23, 24, 25, 26, 28, 50, 51, 52, 53, 54, 55, 56];
            //Tjekker for hver plads om den er der
            foreach (int i in forventetPladsId)
            {
                Plads plads = CRUDController.HentPlads(i);
                //Assert.Contains(plads, pladser);
                Assert.Contains(plads, pladser);
            }
        }
        [Fact]
        public void FindPladserTilVareSpecial()
        {
            //Special vare kummefryser
            Vare vareTest = LagerRepository.GetVare(3);
            List<Plads> pladser = funktionsMetoder.FindPladserTilVare(vareTest.Varegruppe);
            List<int> forventetPladsId = [1];
            //Tjekker for hver plads om den er der
            foreach (int i in forventetPladsId)
            {
                Plads plads = CRUDController.HentPlads(i);
                //Assert.Contains(plads, pladser);
                Assert.Contains(plads, pladser);
            }
        }

        [Fact]
        public void FindPladserTilVareMedIndsatVare()
        {
            //standard vare opvasker
            Vare vareTest = LagerRepository.GetVare(12);

            Vare nyVareIndsat = new Vare(16, 733254399653, "BFS8500T", Varegruppe.Standard);

            List<Plads> pladser = funktionsMetoder.FindPladserTilVare(vareTest.Varegruppe);
            List<int> forventetPladsId = [1, 2, 3, 8, 11, 12, 13, 14, 15, 17, 18, 19, 20, 23, 24, 25, 26, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56];
            //Tjekker for hver plads om den er der
            foreach (int i in forventetPladsId)
            {
                Plads plads = CRUDController.HentPlads(i);
                //Assert.Contains(plads, pladser);
                Assert.Contains(plads, pladser);
            }
        }
    }
}