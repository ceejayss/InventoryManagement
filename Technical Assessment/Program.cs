using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technical_Assessment
{
    public class Program
    {
        static void Main(string[] args)
        {
            InventoryManager inventoryManager = new InventoryManager();

            //Loop that returns the user back to the menu until he exits
            while (true)
            {
                //clears the console then displays the menu
                Console.Clear();
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. List Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Remove Product");
                Console.WriteLine("5. View Total Value");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                //user input for the menu
                var option = Console.ReadLine();

                //switch case for handling all of the options 
                switch (option)
                {
                    case "1":
                        AddProductToInventory(inventoryManager);
                        break;
                    case "2":
                        inventoryManager.ListProducts();
                        break;
                    case "3":
                        UpdateProductQuantity(inventoryManager);
                        break;
                    case "4":
                        RemoveProductFromInventory(inventoryManager);
                        break;
                    case "5":
                        Console.WriteLine($"Total Inventory Value: {inventoryManager.GetTotalValue():C}");
                        break;
                    case "6":
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        
        //method to add the product to inventory
        static void AddProductToInventory(InventoryManager inventoryManager)
        {
            Console.WriteLine("\nAdd a new product to inventory");

            int productId = 0;
            while (true)
            {
                Console.Write("Enter Product ID: ");
                if (int.TryParse(Console.ReadLine(), out productId) && productId > 0)
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid Product ID. Please enter a number.");
                }
            }

            // get the product name from user input
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            int quantity = 0;
            while (true)
            {
                Console.Write("Enter Quantity in Stock ");
                if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 0)
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid quantity. Please enter a number");
                }
            }
            //get price from user input
            decimal price = 0;
            while (true)
            {
                Console.Write("Enter Price: ");
                if (decimal.TryParse(Console.ReadLine(), out price) && price >= 0)
                {
                    break; // valid price
                }
                else
                {
                    Console.WriteLine("Invalid price. Please enter a number.");
                }
            }

            // create a new product
            Product newProduct = new Product(productId, name, quantity, price);

            // add the product to the inventory
            inventoryManager.AddProduct(newProduct);
        }
        //method to update the quantity of existing product
        static void UpdateProductQuantity(InventoryManager inventoryManager)
        {   
            
            Console.WriteLine("\nUpdate Product Quantity");

            int productId = 0;
            while (true)
            {
                //get the product from user input to identify which product to update
                Console.Write("Enter Product ID: ");
                if (int.TryParse(Console.ReadLine(), out productId) && productId > 0)
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid Product ID. Please enter a number.");
                }
            }

            int newQuantity = 0;
            while (true)
            {   
                //get the new quantity from the user input 
                Console.Write("Enter the quantity: ");
                if (int.TryParse(Console.ReadLine(), out newQuantity) && newQuantity >= 0)
                {
                    break; // valid newQuantity
                }
                else
                {
                    Console.WriteLine("Invalid quantity. Please enter a number.");
                }
            }

            inventoryManager.UpdateProduct(productId, newQuantity);
        }
        //method for removing product from inventory
        static void RemoveProductFromInventory(InventoryManager inventoryManager)
        {
            Console.WriteLine("\nRemove Product from Inventory");

            int productId = 0;
            while (true)
            {
                Console.Write("Enter Product ID to remove the product: ");
                if (int.TryParse(Console.ReadLine(), out productId) && productId > 0)
                {
                    break; // valid productId
                }
                else
                {
                    Console.WriteLine("Invalid Product ID. Please enter a valid Product ID.");
                }
            }
            //remove the product from inventory using InventoryManager
            inventoryManager.RemoveProduct(productId);
        }
    }
}