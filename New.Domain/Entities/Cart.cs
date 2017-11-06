using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New.Domain.Entities
{
   public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Material Material, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Material.index == Material.index)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Material = Material,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Material Material)
        {
            lineCollection.RemoveAll(l => l.Material.index == Material.index);
        }

       public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Material.Cena * e.Quantity);

        }
    
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Material Material { get; set; }
        public int Quantity { get; set; }

    }
}
