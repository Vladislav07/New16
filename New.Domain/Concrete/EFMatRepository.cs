using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using New.Domain.Entities;
using New.Domain.Abstract;

namespace New.Domain.Concrete
{
   public class EFMatRepository : IMatRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Material> Materials
        {
            get { return context.Materials; }

        }
    }
}