using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string givenString = @"startswith(ProductName, 'Louisiana')
UnitsOnOrder gt 9 and not (CategoryID eq 1)
Discontinued ne true and CategoryID eq 3
substringof('tofu', QuantityPerUnit) or substringof('Tofu', QuantityPerUnit)
CategoryID ge 5
Discontinued or UnitsInStock lt 5
UnitsInStock lt 7 and SupplierID eq 2
ReorderLevel lt 10 and (SupplierID eq 1 or SupplierID eq 3)
substringof('Hot', ProductName)
CategoryID eq 7
substringof('pp', ProductName) or substringof('cc', ProductName)
UnitsOnOrder ge 50
UnitsOnOrder gt 9 and not (CategoryID eq 1)
Discontinued ne true and CategoryID eq 3
substringof('''', ProductName)
Discontinued ne true and CategoryID eq 3
substringof('oz', QuantityPerUnit) or substringof('lb', QuantityPerUnit)
Discontinued ne true and CategoryID eq 3
25 eq ReorderLevel
substringof('pkg', QuantityPerUnit) and substringof(' - ', QuantityPerUnit)
UnitsOnOrder gt 20
CategoryID le 3 or UnitsOnOrder ge 4
4 eq SupplierID or substringof('cans', QuantityPerUnit)
UnitsInStock lt 4 and SupplierID eq 3
not Discontinued and UnitsInStock lt 10
substringof('Dried', ProductName) or substringof('dried', ProductName)
CategoryID eq 7";
            string[] inputString = givenString.Split('\n');
            foreach (var t in inputString)
            {
                var tempt = t.Trim('\r');
                var mainStr = System.Web.HttpUtility.UrlPathEncode(tempt);
                var inp = @"http://services.odata.org/Northwind/Northwind.svc/Products/$count?$filter=" + mainStr;
                var tww2 = new WebClient().DownloadString(inp);

                Console.WriteLine(tww2);
            }
            Console.ReadLine();
        }
    }
}
