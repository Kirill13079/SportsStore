using System;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Model.Entities
{
    public class Cart 
    {
        private static readonly string[] _items = { "вещь", "вещи", "вещей" };
        private List<CartLine> _lineCollection = new List<CartLine>();

        public string Declination = _items[2];

        public void AddItem(Product product, int quantity,string size)
        {            
            var lines = _lineCollection
                .Where(p => p.Product.ProductID == product.ProductID);

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
                        _lineCollection.Add(new CartLine
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
                _lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity,
                    Size = size
                });
            }

            Declination = GetCase(quantity, _items);
        }
        public void RemoveLine(Product product)
        {
            _lineCollection
                .RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return _lineCollection
                .Sum(e => e.Product.Price * e.Quantity);
        }

        public void Clear()
        {
            _lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get 
            { 
                return _lineCollection; 
            }
        }

        private string GetCase(int value, string[] options)
        {
            value = Math.Abs(value) % 100;

            if (value > 10 && value < 15)
            {
                return options[2];
            }

            value %= 10;

            if (value == 1) 
            {
                return options[0];
            }

            if (value > 1 && value < 5) 
            { 
                return options[1];
            }

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
