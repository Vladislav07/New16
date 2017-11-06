using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace New.Domain.Entities
{
    public interface IExsportXML
    {
        data_order D();
        XDocument xd1 { set; }
    }

    public class EcsportXML:IExsportXML
    {
        XDocument xd;

        public XDocument xd1
        {
            set { xd = value; }
        }
        public data_order order = new data_order();


        public data_order D()
        {
            order.name = (string)xd.Root.Element("data_order").FirstAttribute;
            foreach (XElement elem in xd.Root.Element("data_order").Element("list_materials").Elements())
            {
                Material mat = new Material();
                foreach (XAttribute u in elem.Attributes())
                {
                    switch (Convert.ToString(u.Name))
                    {
                        case "name":
                            mat.name = (string)u;
                            break;
                        case "index":
                            mat.index = (int)u;
                            break;
                        case "type":
                            mat.type = (string)u;
                            break;
                        default:
                            break;
                    }

                }
                foreach (XElement u1 in elem.Element("list_parts").Elements())
                {
                    part part1 = new part();
                    foreach (XAttribute atr in u1.Attributes())
                    {
                        switch (Convert.ToString(atr.Name))
                        {
                            case "length":
                                part1.Length = (int)atr;
                                break;
                            case "width":
                                part1.width = (int)atr;
                                break;
                            case "thick":
                                part1.thick = (int)atr;
                                break;
                            case "quantity":
                                part1.quantitu = (int)atr;
                                break;
                            default:
                                break;
                        }
                    }
                    mat.AddItem(part1);
                }

                XElement xe = elem.Elements().First(r => r.Name == "list_nesting_plans");

                foreach (XElement u2 in xe.Elements())
                {
                    nesting_plan plan = new nesting_plan();
                    foreach (XAttribute atr in u2.Attributes())
                    {
                        switch (Convert.ToString(atr.Name))
                        {
                            case "width":
                                plan.width = (int)atr;
                                break;
                            case "length":
                                plan.length = (int)atr;
                                break;
                            case "thick":
                                plan.thick = (int)atr;
                                break;
                            case "quantity":
                                plan.quantitu = (int)atr;
                                break;
                            default:
                                break;
                        }
                    }

                    XElement list_part_n = u2.Element("list_parts");
                    foreach (XElement elem_part in list_part_n.Elements())
                    {
                        part_nesting part_n = new part_nesting();
                        foreach (XAttribute atr_p in elem_part.Attributes())
                        {
                            switch (Convert.ToString(atr_p.Name))
                            {
                                case "number":
                                    part_n.Number = (int)atr_p;
                                    break;
                                case "length":
                                    part_n.Length = (int)atr_p;
                                    break;
                                case "width":
                                    part_n.width = (int)atr_p;
                                    break;
                                case "x":
                                    part_n.x = (int)atr_p;
                                    break;
                                case "y":
                                    part_n.y = (int)atr_p;
                                    break;


                            }
                        }

                        plan.AddPartNesting(part_n);
                    }
                        mat.AddNesting(plan);
                    }
                    order.AddMat(mat);
                }
            return order;
            }

        
    }
    }
