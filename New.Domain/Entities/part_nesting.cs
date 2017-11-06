using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New.Domain.Entities
{
   public class part_nesting
    {
        public int Number { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int Length;
        public int width;
        public void RaschetReza()
        {
            throw new NotImplementedException();
        }

        public int rotate { get; set; }

        public string note { get; set; }
    }
}
