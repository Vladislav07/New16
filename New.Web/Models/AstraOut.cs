using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using New.Domain.Entities;

namespace New.Web.Models
{
    public class AstraOut
    {   

        public IEnumerable<Material> Materials { get; set; }
        public IEnumerable<part> Parts { get; set; }
        public IEnumerable<Sheet> Sheets { get; set; }
        public IEnumerable<nesting_plan> NestingPlans { get; set; }
        public IEnumerable<part_nesting> PartNestings { get; set; }
    }
}