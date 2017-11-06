using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New.Domain.Entities
{
   public  class data_order
    {
        public string name { get; set; }
        public string note { get; set; }
       public List<Material> list_materials = new List<Material>();
       

        public void AddMat(Material material)
        {
                    list_materials.Add(material);
                       
        }
        public IEnumerable<Material> materials
        {
            get { return list_materials; }
        }
       
       

    }
}
