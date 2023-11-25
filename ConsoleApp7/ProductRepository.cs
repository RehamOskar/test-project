using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{

    //يقوم كلاس ProductRepository بتنفيذ واجهة IProductRepository لتنفيذ عمليات قاعدة بيانات المنتجات.
    //يستخدم الكلاس قائمة(List) لتخزين المنتجات وتنفيذ العمليات المطلوبة مثل إضافة منتج، استرجاع قائمة المنتجات، البحث عن منتج بواسطة الباركود، تحديث المخزون، والتحقق من صحة الباركود.
        class ProductRepository : IProductRepository
        {
            private List<Product> products = new List<Product>();

            public void AddProduct(Product product)
            {
                products.Add(product);
            }

            public List<Product> GetProducts()
            {
                return products;
            }

            public Product GetProductByBarcode(string barcode)
            {
                return products.Find(p => p.Barcode == barcode);
            }

            public void UpdateStock(string barcode, int quantity)
            {
                Product product = GetProductByBarcode(barcode);

                if (product != null)
                {
                    product.Stock += quantity;
                    Console.WriteLine($"Stock updated for product: {product.Name}. New stock: {product.Stock}");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }

            private bool IsNumeric(string input)
            {
                return int.TryParse(input, out _);
            }

            private bool IsValidBarcode(string barcode)
            {
                return barcode.Length == 5 && IsNumeric(barcode);
            }

            public bool ValidateBarcode(string barcode)
            {
                if (!IsValidBarcode(barcode))
                {
                    Console.WriteLine("Invalid barcode. Barcode must be a 5-digit number.");
                    return false;
                }

                return true;
            }
        }
    }

