using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyPOS
{
    class creditorsstatement
    {
       public string Date { get; set; }

       public string Naration { get; set; }

       public int Debit { get; set; }

       public int Credit { get; set; }

       public int Balance { set; get; }

       public string User { set; get; }

       //public int MemberName { set; get; }
       //public int  { set; get; }

       
      // public string Total {get {return string.Format("{0}/=",unitprice*Quantity);}
    }
}
