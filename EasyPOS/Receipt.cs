using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyPOS
{
   public class Receipt
    {
       public int Id { get; set; }

       public int ProductNo { get; set; }

       public string ProductName { get; set; }

       public int unitprice { get; set; }

       public int Quantity { set; get; }

       public double VAT { set; get; }
       
       public string Total {get {return string.Format("{0}/=",unitprice*Quantity);}}
    }
}
