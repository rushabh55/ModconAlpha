using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviews.DataStructures
{
    class Stack<T>
    {
        Node<T> head;

        public Stack()
        {
            head = null;
        }

        public void Push( T data )
        {
            if ( head == null )
            {
                head = new Node<T>();
                head.data = data;
                head.next = null;
                return;
            }

            Node<T> temp = new Node<T>();
            temp.data = data;
            temp.next = head;
            head = temp;
        }

        public void Pop()
        {
            if ( head == null )
            {
                Console.WriteLine("No initialization");
                throw new NullReferenceException();
            }

            head = head.next;
        }

        public Node<T> Peek()
        {
            if ( head == null )
            {
                Console.WriteLine("No initialization");
                throw new NullReferenceException();
            }

            return head;
        }

        public override string ToString()
        {
            Node<T> iterator = head;
            StringBuilder sb = new StringBuilder();
            while ( iterator != null )
            {
                sb.Append(iterator.data + " | ");
                iterator = iterator.next;
            }
            Console.WriteLine("Queue : " + sb.ToString()  );
            return base.ToString();
        }
    }
}
