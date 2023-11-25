using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{

    //تم تعريف الواجهة IReceiptGenerator لتوليد إيصال الشراء.
    //تحتوي الواجهة على وظيفة واحدة لتوليد إيصال الشراء(GenerateReceipt).
    interface IReceiptGenerator
    {
        void GenerateReceipt(Product product);
    }

}
