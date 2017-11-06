using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using New.Web.Models;
using System.Xml;
using System.Xml.Linq;
using New.Domain.Entities;
using New.Web.Helpers;

namespace New.Web.Controllers
{
    public class NestingController : Controller
    {
            IExsportXML ecsp;
            public IExsportXML e
                {
                set { ecsp = value; }
                }
        // Чтение из файла 
        private XDocument ReaderFailOut()
        {
            XDocument xd = XDocument.Load(@"d:\AstraOut2.xml");
            return xd;
        }

        public ViewResult Index() // Раскроенный заказ
        {
            ecsp.xd1 = ReaderFailOut();
            data_order ord = ecsp.D();            
            return View(ord);
        }

        // карта раскроя
        public PartialViewResult KartaRaskroj(nesting_plan karta_raskroj)
        {
            return PartialView(karta_raskroj);
        }
  
        // список карт раскроя
        public PartialViewResult SpisokKartRaskroj()
        {
            return PartialView();
        }
        // расчет стоимости по материалам
        public ViewResult RaschetStoimosty()
        {
            return null;
        }
        
        // расчет полной стоимости
        public ViewResult CenaZakaza()
        {
            return View();
        }
        
        // карта резки
        public ViewResult OrderRezka()
        {
            return View();
        }
        // список резов
        public PartialViewResult SpisokRezov()
        {
            return PartialView();
        }
        

    }
}