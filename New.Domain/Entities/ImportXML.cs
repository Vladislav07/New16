using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace New.Domain.Entities
{
  public  class ImportXML
  {

      public XDocument document; 

        public void import(data_order order)
        {
             document =new XDocument(new XDeclaration("1.0","windows-1251",null),

            new XElement("data"));
         XElement u=new XElement("data_order",
                 new XAttribute("name", order.name),
                  new XAttribute("note", order.note));
           // XDeclaration xDeclaration = new XDeclaration("1.0", "windows-1251", "yes");
           
           XElement X_list_mat = new XElement("list_materials");
            

            foreach (Material mat in order.materials)
            {
                XElement XMat = new XElement("material",
                    new XAttribute("name", mat.name));

                XElement X_list_parts = new XElement("list_parts");
                XElement X_list_sheet = new XElement("list_sheets");
               
                foreach (part part in mat.parts)
                {
                    XElement XPart = new XElement("part",
                        new XAttribute("number", part.number),
                        new XAttribute("length", part.Length),
                        new XAttribute("width", part.width),
                        new XAttribute("thick", part.thick),
                        new XAttribute("quantity", part.quantitu),
                         new XAttribute("rotate", part.rotate));
                    X_list_parts.Add(XPart);
                }
                XMat.Add(X_list_parts);               
                foreach (Sheet sheet in mat.sheets)
                {
                    XElement XSheet = new XElement("sheet",                       
                        new XAttribute("length", sheet.length),
                        new XAttribute("width", sheet.width),
                        new XAttribute("thick", sheet.thick),
                        new XAttribute("quantity", sheet.quantity));
                    X_list_sheet.Add(XSheet);
                } 
                XMat.Add(X_list_sheet);
                X_list_mat.Add(XMat);
            }         


           // xE.Add(X_list_mat);
            u.Add(X_list_mat);
            document.Root.Add(u);
            document.Save(@"D:\import.xml");
            return ;

        }

      

    }
}
