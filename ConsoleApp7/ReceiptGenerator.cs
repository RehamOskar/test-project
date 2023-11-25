using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{

    //يقوم كلاس ReceiptGenerator بتنفيذ واجهة IReceiptGenerator لتوليد إيصال الشراء.
    //يحتوي الكلاس على وظيفة GenerateReceipt التي تقوم بطباعة إيصال الشراء.

    class ReceiptGenerator : IReceiptGenerator
    {
        public void GenerateReceipt(Product product)
        {
            Console.WriteLine("Receipt:");
            Console.WriteLine($"Product: {product.Name}");
            Console.WriteLine($"Price: ${product.Price}");
            Console.WriteLine("Thank you for your purchase!");
        }
    }
}
