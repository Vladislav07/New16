using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New.Domain.Entities
{
   public class nesting_plan
    {
        public int number { get; set; }
        public string code { get; set; }
        public int quantitu { get; set; }
        public int thick { get; set; }
        public int width { get; set; }
        public int length { get; set; }
        public double cut_length { get; set; }
        public List<part_nesting> list_parts_nesting = new List<part_nesting>();
        public void AddPartNesting(part_nesting pn)
        {
            list_parts_nesting.Add(pn);
        }
       public List<Cut>Cuts=new List<Cut>();
       public void AddCut(Cut cut)
       {
           Cuts.Add(cut);
       }

    }
}
