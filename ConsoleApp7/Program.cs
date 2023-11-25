
using System;
using System.Collections.Generic;
namespace ConsoleApp7
{
    
    class Program
    {
        static void Main(string[] args)
        {
            IProductRepository productRepository = new ProductRepository();
            IReceiptGenerator receiptGenerator = new ReceiptGenerator();
            ISupermarketSystem supermarketSystem = new SupermarketSystem(productRepository, receiptGenerator);

            bool running = true;

            while (running)
            {
                Console.WriteLine("Supermarket System Menu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Sell Product");
                Console.WriteLine("3. Update Stock");
                Console.WriteLine("4. Show All Products");
                Console.WriteLine("5. Delete Product");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                string choiceInput = Console.ReadLine();
                int choice = 0;
                bool validChoice = int.TryParse(choiceInput, out choice);

                if (validChoice)
                {
                    switch (choice)
                    {
                        case 1:
                            supermarketSystem.AddProduct();
                            break;
                        case 2:
                            supermarketSystem.SellProduct();
                            break;
                        case 3:
                            supermarketSystem.UpdateStock();
                            break;
                        case 4:
                            supermarketSystem.ShowAllProducts();
                            break;
                        case 5:
                            supermarketSystem.DeleteProduct();
                            break;
                        case 6:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                }

                Console.WriteLine();
            }
        }
    }
}