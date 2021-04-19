using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Model.Entities
{
    public class Cart 
    {
        private static readonly string[] items = { "вещь", "вещи", "вещей" };
        private List<CartLine> lineCollection = new List<CartLine>();
        public string Declination = items[2];
        public void AddItem(Product product, int quantity,string size)
        {            
            var lines = lineCollection.Where(p => p.Product.ProductID == product.ProductID);
            if (lines.Count() > 0)
            {
                foreach (var sizes in lines)
                {
                    if (sizes.Size == size)
                    {
                        sizes.Quantity += quantity;
                    }
                    else 
                    {
                        lineCollection.Add(new CartLine
                        {
                            Product = product,
                            Quantity = quantity,
                            Size = size
                        });
                        break;
                    }
                }
            }
            else
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity,
                    Size = size
                });
            }

            Declination = GetCase(quantity, items);
        }
        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
        private string GetCase(int value, string[] options)
        {
            value = Math.Abs(value) % 100;

            if (value > 10 && value < 15)
                return options[2];

            value %= 10;
            if (value == 1) return options[0];
            if (value > 1 && value < 5) return options[1];
            return options[2];
        }
    }

    public class CartLine
    {
      
        public Product Product { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }

    }
}
