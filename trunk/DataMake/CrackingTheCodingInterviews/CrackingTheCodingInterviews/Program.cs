using CrackingTheCodingInterviews.DataStructures;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviews
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Queue<int> q = new Queue<int>();
            for ( int i = 1 ; i < 100 ; ++i )
            {
                //if ( i % 10 == 0 )
                //{
                //    q.Dequeue();
                //    q.ToString();
                //}
                //else
                {
                    q.Enqueue(i);
                }
            }
            q.ToString();
            q.Dequeue();

            q = null;
            Console.Read();
        }
    }
}
