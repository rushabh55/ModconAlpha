using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviews.DataStructures
{
    class Queue<T>
    {
        
        Node<T> head;
        public Queue()
        {
            head = null;
        }

        public void Enqueue( T data )
        {
            if( head == null )
            {
                head = new Node<T>();
                head.data = data;
                ToString();
                return;
            }

            Node<T> tail = this.head;
            while ( tail.next != null )
            {
                tail = tail.next;
            }
            Node<T> temp = tail.next;
            temp = new Node<T>();
            temp.data = data;
            tail = temp;
            ToString();
        }

        public void Dequeue()
        {
            if ( head == null )
            {
                Console.WriteLine("No data found!");
                throw new NullReferenceException();
            }

            Node<T> tail = head;

            while ( tail.next != null )
            {
                tail = tail.next;
            }

            tail = null;
        }

        public Node<T> Peek()
        {
            if ( head == null )
            {
                Console.WriteLine("No data found!");
                throw new NullReferenceException();
            }

            if (head.next == null)
                return head;

            Node<T> tail = head;
            while( tail.next != null )
            {
                tail = tail.next;
            }

            return tail;
        }

        public override string ToString()
        {
            Node<T> iterator = head;
            StringBuilder sb = new StringBuilder();
            while (iterator != null)
            {
                sb.Append(iterator.data);
                iterator = iterator.next;
            }
            Console.WriteLine("Queue : " + sb.ToString());
            return base.ToString();
        }
    }
}
