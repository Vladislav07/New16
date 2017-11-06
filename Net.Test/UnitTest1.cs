using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using New.Domain.Entities;
using New.Web.Controllers;
using System.Linq;
using System.Xml.Linq;
using New.Web.Helpers;
using System.Web.Mvc;

namespace Net.Test
{
    [TestClass]
    public class UnitTestCart
    {
       /* 
       [TestMethod]
        public void Test_Raskroy()
        {
          //Arrange
            NestingController NesKontr = new NestingController();

           //Act
           data_order result = (data_order)NesKontr.Index().Model;

          

           Assert.AreEqual(result.materials.Count(), 1);
          
           
        }

       [TestMethod]
       public void Test_Raskroy1()
       {
           //Arrang
           XDocument xd=XDocument.Load(@"D:\AstraOut.xml");
        
           //Act
           EcsportXML ecsport = new EcsportXML();
           ecsport.D(xd);
         
           //Assert
           Material m=ecsport.order.list_materials[0];
           nesting_plan np = m.list_nesting_plans[0];
           Assert.AreEqual(ecsport.order.name, "new11");
           Assert.AreEqual(ecsport.order.list_materials[0].index, 4);
           Assert.AreEqual(ecsport.order.list_materials[0].name, "г/к");
           Assert.AreEqual(m.type, "");
           Assert.AreEqual(m.list_parts[0].width, 35);
           Assert.AreEqual(m.list_parts[0].Length, 250);
           Assert.AreEqual(m.list_nesting_plans[0].length, 6000);
           Assert.AreEqual(m.list_nesting_plans.Count, 1);
          Assert.AreEqual(m.list_nesting_plans[0].width, 1500);
          Assert.AreEqual(np.list_parts_nesting[0].x,0);
          Assert.AreEqual(np.list_parts_nesting[0].y, 0);
          Assert.AreEqual(np.list_parts_nesting[1].y, 35);
          Assert.AreEqual(np.list_parts_nesting[0].number, 0);
       }
    /*
        [TestMethod]
        public void Test_Helper()
    {
        // Arrang
        HtmlHelper myHelper = null;

        XDocument xd = XDocument.Load(@"D:\AstraOut.xml");
        EcsportXML ecsp = new EcsportXML();
        nesting_plan n_p = ecsp.order.list_materials[0].list_nesting_plans[0];

        //Act
        MvcHtmlString result = myHelper.CreateList(n_p);

        //Assert
        Assert.AreEqual(@"<div id=""1"" style=""position:relative; width:100%; height:""><div\>", result.ToString());  
    }
    [TestMethod]
    public void Test_Pereschet()
    {
        //Arrang

    }

        */
        /*
         создать деталь
         
         */

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

            Sheet scheet1 = new Sheet {MatID = 1, length = 11750, quantity = 100};
            Sheet scheet2 = new Sheet {MatID = 2, length = 6000, width = 1500, thick = 10, quantity = 100};
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

            mat2.AddItem(Part1);
            mat2.AddItem(Part2);
            order1.AddMat(mat1);
            order1.AddMat(mat2);
            return order1;
        }
      
        /*
        Список: единиц работы
         * отправка  
           [TestMethod]
       public void Test_RaskroyAction()
           {
           data_order data = Arrang();
           OrderController order = new OrderController();
           
           //Act
           order.RaskroyAction(data);

           //Assert
           
           Assert.IsNotNull(order);
       }
         * */
    } 
}