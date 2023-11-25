using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{

    //تم تعريف الواجهة ISupermarketSystem لتعريف وظائف النظام الأساسية للسوبرماركت.
    //تحتوي الواجهة على وظائف مثل إضافة منتج(AddProduct) وبيع منتج(SellProduct) وتحديث المخزون(UpdateStock) وعرض جميع المنتجات(ShowAllProducts) وحذف منتج(DeleteProduct).

    interface ISupermarketSystem
    {
        void AddProduct();
        void SellProduct();
        void UpdateStock();
        void ShowAllProducts();
        void DeleteProduct();
    }
}
