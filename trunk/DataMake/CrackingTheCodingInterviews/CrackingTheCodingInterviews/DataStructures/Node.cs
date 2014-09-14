using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviews.DataStructures
{
    class Node<T>
    {
        public T data;
        public Node<T> next;
    }

    class Node
    {
        public int i;
        public Node right;
        public Node left;
    }
}
