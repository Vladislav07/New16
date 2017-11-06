using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using New.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.SqlServerCompact;

namespace New.Domain.Concrete
{
    class EFDbContext:DbContext
    {
        public EFDbContext(): base("Tovar")
        {
            
        }
        public DbSet<Material> Materials { get; set; }
    }
}
