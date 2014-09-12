using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = @"C:\Users\Rushabh\Documents\ModconAlphaMain\trunk\DataMake\ConsoleApplication3\ConsoleApplication3\bin\Debug" + "/temp.txt";
            FileStream fs = new FileStream(s, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            s = sr.ReadToEnd();
            string c = "feel".ToLowerInvariant();
            string[] input = s.Split(' ');
            int count1 =0, count2 =0;
            string match = string.Empty;
            foreach( var t in input )
            {
                var temp = t.Trim('\t', '\r', '\n');
                temp = temp.ToLowerInvariant();
                if ( temp.Contains(c) )
                {
                    count2++;
                    if (count2 == 1)
                        match = temp;
                }
                if (temp == c)
                {

                    count1++;
                }
                
            }
            Console.Write(count1 + ";" + count2 + ";" + match);
            Console.ReadLine();
        }
    }
}
