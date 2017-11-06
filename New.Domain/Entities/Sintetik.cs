using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace New.Domain.Entities
{
   public class Sintetik
    {
private XDocument xDocument;
      
        //public data_order m_data_order = null;
        public Material m = null;
        public List<Material> l_m = null;
        public List<part> L_p = null;
       public data_order m_data_order = null;
       public part part_z = null;
       public List<nesting_plan> N_p = null;
       public int count_p = 0;
       public nesting_plan np = null;
       public List<part_nesting> partnesting = null;
      public part_nesting pnest = null;

        public Sintetik()
        {
            // TODO: Complete member initialization
           // this.xDocument = xDocument;
           // E(xDocument.Elements());
        }

        
        
      

        public  void Atr(IEnumerable<XAttribute> elements,string t) 
        {

            // Отображаем атрибуты элемента
            foreach (XAttribute attr in elements)
            {
               
               // Console.WriteLine("Атрибут: {0} : значение = {1}", attr.Name, attr.Value);
                switch (t)
                {
                    case "data_order":
                         m_data_order = new data_order();
                        break;
                    case "material":
                        //string e;
                       // int q;
                        if (attr.Name == "name")
                          m.name=attr.Value;
                        else if (attr.Name == "index")
                            m.index = Convert.ToInt32(attr.Value);
                             
                           //  l_m.Add(m);
                            break;
                    case "part":
                            if (attr.Name == "number")
                                part_z.number = Convert.ToInt32(attr.Value);
                            else if (attr.Name == "rotate")
                                part_z.rotate = Convert.ToInt32(attr.Value);
                            else if (attr.Name == "quantitu")
                                part_z.quantitu = Convert.ToInt32(attr.Value);
                            else if (attr.Name == "thick")
                                part_z.thick = Convert.ToInt32(attr.Value);
                            else if (attr.Name == "width")
                                part_z.width = Convert.ToInt32(attr.Value);
                            else if (attr.Name == "length")
                                part_z.Length = Convert.ToInt32(attr.Value);                                                    
                            break;
                    case "nesting_plan":
                            if (attr.Name == "number")
                                np.number = Convert.ToInt32(attr.Value);
                            else if (attr.Name == "code")
                                np.code = attr.Value;
                            else if (attr.Name == "cut_legth")
                                np.cut_length = Convert.ToDouble(attr.Value);
                            else if (attr.Name == "length")
                                np.length = Convert.ToInt32(attr.Value);
                            else if (attr.Name == "quantitu")
                                np.quantitu = Convert.ToInt32(attr.Value);
                            else if (attr.Name == "width")
                                np.width = Convert.ToInt32(attr.Value);
                            else if (attr.Name == "thick")
                                np.thick = Convert.ToInt32(attr.Value);
                            break;
                    case "part_n":
                            if (attr.Name == "number")
                                pnest.Number = Convert.ToInt32(attr.Value);
                            else if (attr.Name == "rotate")
                                pnest.rotate = Convert.ToInt32(attr.Value);
                            else if (attr.Name == "note")
                                pnest.note = attr.Value;                          
                            else if (attr.Name == "width")
                                pnest.width = Convert.ToInt32(attr.Value);
                            else if (attr.Name == "length")
                                pnest.Length = Convert.ToInt32(attr.Value);
                            else if (attr.Name == "x")
                                pnest.x = Convert.ToInt32(attr.Value);
                            else if (attr.Name == "y")
                                pnest.y = Convert.ToInt32(attr.Value);
                            break;
                        
                }
                
            }
        }
        public  void E(IEnumerable<XElement> elements)
        {

            // перебираем все дочерние элементы
            foreach (XElement tr in elements)
            {
                switch (Convert.ToString(tr.Name))
                {
                case  "data_order":
             
                    Atr(tr.Attributes(), "data_order");
                    break;
              
                    case "list_materials":
                  //  l_m = new List<Material>();
                        break;

                    case  "material":
                
                    m = new Material();

                    Atr(tr.Attributes(), "material");
                    l_m.Add(m);
                        break;
                

                    case "list_parts":
                    if (tr.Parent.Name == "material")
                        L_p = new List<part>();
                    else if (tr.Parent.Name == "nesting_plan")
                        partnesting = new List<part_nesting>();
                        break;

                    case  "part":
                        if (tr.Parent.Parent.Name == "material")
                        {
                            count_p = count_p + 1;
                          //  part_z = new part();
                            Atr(tr.Attributes(), "part");
                            L_p.Add(part_z);
                        }
                        else if (tr.Parent.Parent.Name == "nesting_plan")
                        {
                            pnest = new part_nesting();
                            Atr(tr.Attributes(), "part_n");
                            partnesting.Add(pnest);
                        }
                         break;
                        
                    case  "list_nesting_plans":
                            N_p = new List<nesting_plan>();
                            break;
                    case "nesting_plan":
                            np = new nesting_plan();
                            Atr(tr.Attributes(), "nesting_plan");
                            N_p.Add(np);
                        break;
                    

                

                }

                if(tr.HasElements)
                E(tr.Elements());
            }
        }
    }
}
