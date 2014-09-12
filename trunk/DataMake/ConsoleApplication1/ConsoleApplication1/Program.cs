using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string givenString = @"Discontinued eq trun 
SupplierID eq 4 
CategoryID eq 2";
            string[] inputString = givenString.Split('\n');
            foreach (var t in inputString)
            {
                t.Trim('\r');
                var mainStr = System.Web.HttpUtility.UrlPathEncode("Discontinued ne true and CategoryID eq 3");
                var inp = @"http://services.odata.org/Northwind/Northwind.svc/Products/$count?$filter=" + mainStr;
                var tww2 = new WebClient().DownloadString(inp);
                
                Console.WriteLine(tww2);
            }
            Console.ReadLine();
        }
    }
}
