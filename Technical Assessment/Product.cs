using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technical_Assessment
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }

        // Constructor to initialize the Product
        public Product(int productId, string name, int quantityInStock, decimal price)
        {
            ProductId = productId;
            Name = name;
            QuantityInStock = quantityInStock;
            Price = price;
        }
    }
}
