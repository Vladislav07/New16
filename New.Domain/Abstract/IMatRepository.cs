using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using New.Domain.Entities;

namespace New.Domain.Abstract
{
   public interface IMatRepository
    {
        IEnumerable<Material> Materials { get; }
    }
}
