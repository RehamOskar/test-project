using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{

    //تم تعريف الواجهة IProductRepository لتعريف عمليات قاعدة بيانات المنتجات.
    //تحتوي الواجهة على عدة وظائف مثل إضافة منتج(AddProduct) واسترجاع قائمة المنتجات(GetProducts) والبحث عن منتج بواسطة الباركود(GetProductByBarcode) وتحديث المخزون(UpdateStock) والتحقق من صحة الباركود(ValidateBarcode).

    interface IProductRepository
    {
        void AddProduct(Product product);
        List<Product> GetProducts();
        Product GetProductByBarcode(string barcode);
        void UpdateStock(string barcode, int quantity);
        bool ValidateBarcode(string barcode);
    }
}
