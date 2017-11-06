using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New.Domain.Entities
{
   public class Material
    {
        public int index { get;  set; }
        public string name { get; set; }          //вид
        public string Description { get; set; }  // типоразмер
        public string type { get; set; }     // категория
        public int Dlina { get; set; }
        public float Sechenie { get; set; }
        public int Ves { get; set; }
        
        public decimal Cena { get; set; }
        public List<part> list_parts=new List<part>();
        public List<Sheet> list_sheets = new List<Sheet>();
        public List<nesting_plan> list_nesting_plans = new List<nesting_plan>();

        public void AddNesting(nesting_plan n)
        {
            list_nesting_plans.Add(n);
        }

        public void AddItem(part part1)
        {
            
                list_parts.Add(part1);
        

        }
        public void AddSheet(Sheet sheet)
        {

            list_sheets.Add(sheet);

        }
       public IEnumerable<part> parts
       {
           get { return list_parts; }
       }
       public IEnumerable<Sheet> sheets
       {
           get { return list_sheets; }
       }
    }
}
