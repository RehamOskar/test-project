using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{

    //يتم استخدام الكلاس Product لتمثيل المنتجات في السوبرماركت.
    //يحتوي الكلاس على خصائص مثل الاسم (Name) والسعر (Price) والباركود (Barcode) والمخزون (Stock)
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Barcode { get; set; }
        public int Stock { get; set; }
    }
}
