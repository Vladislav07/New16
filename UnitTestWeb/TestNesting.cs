using System.Collections.Generic;
using NUnit.Framework;
using New.Web.Controllers;
using System.Web.Mvc;
using NSubstitute;
using New.Domain.Entities;

namespace UnitTestWeb
{
    /// <summary>
    /// Сводное описание для TestNesting
    /// </summary>
    [TestFixture]
    public class TestNesting
    {
       
     
        public data_order Arrang()
        {
            //Arrang
            data_order order1 = new data_order();
            order1.name = "USA";
            order1.note = "Proba";
            Material mat1 = new Material
            {
                index = 1,
                type = "Балка",
                name = "Б1",
                Description = "8",
                Dlina = 11750,
                Cena = 40
            };
            Material mat2 = new Material
            {
                index = 2,
                type = "Лист",
                name = "г/к",
                Description = "16",
                
                Dlina = 6000,
                Cena = 40
            };

            Sheet scheet1 = new Sheet { MatID = 1, length = 11750, quantity = 100 };
            Sheet scheet2 = new Sheet { MatID = 2, length = 6000, width = 1500, thick = 10, quantity = 100 };
            mat1.AddSheet(scheet1);
            mat2.AddSheet(scheet2);
            part Part1 = new part
            {
                index = 2,
                Length = 500,
                number = 101,
                quantitu = 20,
                rotate = 1,
                thick = 10,
                width = 600
            };
            part Part2 = new part
            {
                index = 2,
                Length = 300,
                number = 102,
                quantitu = 40,
                rotate = 1,
                thick = 10,
                width = 400
            };
            nesting_plan karta_raskroj = new nesting_plan
                {
                    number = 1,
                    length = 6000,
                    width = 1500,
                    thick = 10,
                    quantitu = 1,
                    cut_length = 35.1
                };
            part_nesting pn1 = new part_nesting
                {
                   Number = 101,
                   x=0,
                   y=0              
                };
            part_nesting pn2 = new part_nesting
            {
                Number = 101,
                x = 500,
                y = 0
            };
            part_nesting pn3 = new part_nesting
            {
                Number = 101,
                x = 500,
                y = 600
            };
            part_nesting pn4 = new part_nesting
            {
                Number = 101,
                x = 0,
                y = 600
            };
            karta_raskroj.AddPartNesting(pn1);
            karta_raskroj.AddPartNesting(pn2);
            karta_raskroj.AddPartNesting(pn3);
            karta_raskroj.AddPartNesting(pn4);
            Cut cut1 = new Cut {x1 = 500, x2 = 500, y1 = 1500, y2 = 0, type = TypeM.main};
            Cut cut2 = new Cut { x1 = 0, x2 = 500, y1 = 600, y2 = 600 };
            Cut cut3 = new Cut { x1 = 0, x2 = 500, y1 = 1200, y2 = 1200 };

            mat2.AddItem(Part1);
            mat2.AddItem(Part2);
            karta_raskroj.AddCut(cut1);
            karta_raskroj.AddCut(cut2);
            karta_raskroj.AddCut(cut3);
            mat2.AddNesting(karta_raskroj);
            order1.AddMat(mat1);
            order1.AddMat(mat2);
            return order1;
        }

       

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [Test]
        public void IndexTest_ViewModel_OrderData()
        {
            //Arrang
            NestingController nestigContr=new NestingController();
            data_order zakaz = Arrang();
            IExsportXML podstava = Substitute.For<IExsportXML>();
            podstava.D().Returns(zakaz);
            nestigContr.e = podstava;
            // Act
            ViewResult viewreult=nestigContr.Index();
            data_order d ;
            d= (data_order) viewreult.Model;

            //Assert
            Assert.AreEqual(d.name, "USA");

        }
        [Test]
        public void KartaRaskroj_Rendering_View()
        {
            //Arrang
            nesting_plan ns=new nesting_plan();
            ns.width = 1250;
            NestingController nestingContr=new NestingController();
            //Act
           PartialViewResult view_karta= nestingContr.KartaRaskroj(ns);
            //Assert
            nesting_plan ns_in = (nesting_plan) view_karta.Model;
            Assert.AreEqual(1250,ns.width);
        }

    }
}
