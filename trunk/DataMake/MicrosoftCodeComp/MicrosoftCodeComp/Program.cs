using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;

namespace MicrosoftCodeComp
{
    class Node
    {
        int i;
        Node left;
        Node right;
    }
    class Program
    {
        static void Main(string[] args)
        {

            
        //    string[] array = givenString.Split(' ', '.', '&', '!', '@', '#', '$', '%', '^', '*', '(', ')');

            //string givenString = args[0];
            string givenString = "0,87,154,97,63,149,107,2,34,78,147,64,100,20,98,38,22,40,59,67,51,93,53,46,72,158,136,35,33,83,156,10,75,99,39,42,89,153,49,30,77,134,128,137,105,142,54,127,6,111,65,44,76,122,106,123,151,146,118,9,103,55,31,25,23,132,143,68,74,96,80,21,114,91,60,36,131,81,14,27,50,145,139,7,82,159,117,167,126,62,85,173,144,152,148,164,28,1,13,69,168,18,119,52,66,157,171,11,71,138,61,150,165,15,130,112,155,48,94,3,102,29,174,24,169,121,135,16,5,109,160,37,17,12,113,41,26,86,84,110,115,120,43,70,141,104,163,172,125,4,166,108,56,161,19,8,32,88,47,90,95,73,170,45,162,129,124,140,58,57,116,92,133,101,79";
            string[] inputString = givenString.Split(',');
            int[] input = new int[inputString.Length];
            int i =0 ;
            foreach ( var t in inputString )
            {
               
                if (!Int32.TryParse (t, out input[i]))
                {
                    throw new Exception();
                }
                i++;
            }
            int length = input.Length / 2;

            Array.Sort(input);

            foreach( var res in input )
            {
                Console.Write(res);
                Console.Write(',');
            }
        }
    }
}
