using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using New.Domain.Abstract;
using New.Domain.Entities;
using New.Web.Models;
using System.Xml.Linq;
using System.Diagnostics;
using System.ComponentModel;

namespace New.Web.Controllers
{
    public class OrderController : Controller
    {

        private IMatRepository repository;

        public OrderController(IMatRepository repo)
        {
            repository = repo;

        }
        public OrderController()
        {
            

        }

       public ActionResult Raskroy(int index)
        {
            
            return View(new part());
        }

       [HttpPost]
       public ActionResult Raskroy(data_order order,part part)
       {  
           
           Material mater = null;
           int n = part.index;
           
           
            if (order.materials.Any(m => m.index == n))
            {
               mater = order.materials.Where(m => m.index == n).First();                  
           }
           
           else
           {
               mater = repository.Materials.Where(m => m.index == n).First();
               Sheet sheet = new Sheet();
               sheet.length = mater.Dlina;
               sheet.quantity = 100;
             
               
               
                   sheet.width = 1500;
                   sheet.thick = part.thick;
              

               mater.AddSheet(sheet);
               order.AddMat(mater);
           }

           if (part.Length != 0)
           {
               mater.AddItem(part);
               
           }
           ViewBag.name = mater.type + " " + mater.name + " " + mater.Dlina;
           ViewBag.n = mater.type;
               return View();
          
       } 

        public PartialViewResult Index1(data_order d)
        {   
            return PartialView(d.materials);
        }



     /*   public PartialViewResult Index2(data_order order)
        {
            return PartialView(order.list_materials.First().list_parts);
        }
        */
       
        public RedirectToRouteResult RaskroyAction(data_order order)
        {
            
           ImportXML imp=new ImportXML();
           imp.import(order);
               
            Process myProcess = new Process();
            myProcess.StartInfo.Arguments = @"D:\import.xml & -i & -n";
          //  myProcess.StartInfo.Arguments = @-i;
          //  myProcess.StartInfo.FileName = @"Z:\AstraRaskroy\Astra\Astra.exe";
          //  myProcess.StartInfo.CreateNoWindow = true;
            myProcess.Start();
       
            return RedirectToAction("KartaRaskroj","Nesting");
        }

        

    }

    
}