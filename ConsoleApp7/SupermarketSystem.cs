using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{

    //يقوم كلاس SupermarketSystem بتنفيذ واجهة ISupermarketSystem لتنفيذ وظائف النظام الأساسية للسوبرماركت.
    //يحتوي الكلاس على متغيرات productRepository و receiptGenerator للوصول إلى وظائف قاعدة بيانات المنتجات وتوليد إيصال الشراء على التوالي.
    //يتضمن الكلاس وظائف مثل إضافة منتج، بيع منتج، تحديث المخزون، عرض جميع المنتجات، وحذف منتج.
    class SupermarketSystem : ISupermarketSystem
    {
        private IProductRepository productRepository;
        private IReceiptGenerator receiptGenerator;

        public SupermarketSystem(IProductRepository productRepository, IReceiptGenerator receiptGenerator)
        {
            this.productRepository = productRepository;
            this.receiptGenerator = receiptGenerator;
        }

        public void AddProduct()
        {
            Console.Write("Enter the name of the product: ");
            string name = Console.ReadLine();

            double price = 0;
            bool validPrice = false;
            while (!validPrice)
            {
                Console.Write("Enter the price of the product: ");
                string priceInput = Console.ReadLine();

                validPrice = double.TryParse(priceInput, out price);

                if (!validPrice)
                {
                    Console.WriteLine("Invalid price. Please enter a valid number.");
                }
            }

            string barcode = "";
            bool validBarcode = false;
            while (!validBarcode)
            {
                Console.Write("Enter the barcode of the product (5-digit number): ");
                barcode = Console.ReadLine();

                validBarcode = productRepository.ValidateBarcode(barcode);
            }

            Product product = new Product { Name = name, Price = price, Barcode = barcode, Stock = 0 };
            productRepository.AddProduct(product);

            Console.WriteLine("Product added successfully.");
        }

        public void SellProduct()
        {
            Console.Write("Enter the barcode of the product to sell: ");
            string barcode = Console.ReadLine();

            Product product = productRepository.GetProductByBarcode(barcode);

            if (product != null)
            {
                if (product.Stock > 0)
                {
                    product.Stock--;
                    Console.WriteLine($"Product sold: {product.Name}. Remaining stock: {product.Stock}");
                }
                else
                {
                    Console.WriteLine("Product is out of stock.");
                }
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void UpdateStock()
        {
            Console.Write("Enter the barcode of the product to update stock: ");
            string barcode = Console.ReadLine();

            Console.Write("Enter the quantity to add (use negative value to subtract): ");
            string quantityInput = Console.ReadLine();

            int quantity = 0;
            bool validQuantity = int.TryParse(quantityInput, out quantity);

            if (validQuantity)
            {
                productRepository.UpdateStock(barcode, quantity);
            }
            else
            {
                Console.WriteLine("Invalid quantity. Please enter a valid number.");
            }
        }

        public void ShowAllProducts()
        {
            List<Product> products = productRepository.GetProducts();

            if (products.Count > 0)
            {
                Console.WriteLine("All Products:");

                foreach (Product product in products)
                {
                    Console.WriteLine($"{product.Name} - Price: ${product.Price} - Barcode: {product.Barcode} - Stock:{product.Stock}");
                }
            }
            else
            {
                Console.WriteLine("No products found.");
            }
        }

        public void DeleteProduct()
        {
            Console.Write("Enter the barcode of the product to delete: ");
            string barcode = Console.ReadLine();

            Product product = productRepository.GetProductByBarcode(barcode);

            if (product != null)
            {
                productRepository.GetProducts().Remove(product);
                Console.WriteLine($"Product deleted: {product.Name}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }

}
