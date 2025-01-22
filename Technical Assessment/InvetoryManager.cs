using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technical_Assessment
{
    public class InventoryManager
    {
        private List<Product> _inventory = new List<Product>();

        // adds a product to the inventory
        public void AddProduct(Product product)
        {
            _inventory.Add(product);
            Console.WriteLine($"Product {product.Name} added to inventory.");
        }

        // removes a product from the inventory based on its productId
        public void RemoveProduct(int productId)
        {
            var product = _inventory.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                _inventory.Remove(product);
                Console.WriteLine($"Product {product.Name} removed from inventory.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        // update the quantity of a product based on its productId
        public void UpdateProduct(int productId, int newQuantity)
        {
            var product = _inventory.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                product.QuantityInStock = newQuantity;
                Console.WriteLine($"Quantity of {product.Name} updated to {newQuantity}.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        // list all products in the inventory
        public void ListProducts()
        {
            if (_inventory.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
            }
            else
            {
                foreach (var product in _inventory)
                {
                    Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Quantity: {product.QuantityInStock}, Price: {product.Price:C}");
                }
            }
        }

        // calculates the total value of the inventory
        public decimal GetTotalValue()
        {
            return _inventory.Sum(p => p.QuantityInStock * p.Price);
        }
    }
}
