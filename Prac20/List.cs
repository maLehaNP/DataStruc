using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Prac20
{
    public class List
    {
        private class Node //вложенный класс, реализующий элемент стека
        {
            private object inf;
            private Node next;
            public Node(object nodeInfo)
            {
                inf = nodeInfo;
                next = null;
            }
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
            public object Inf
            {
                get { return inf; }
                set { inf = value; }
            }
        }
        private Node head;
        private Node tail;
        public List()
        {
            head = null;
            tail = null;
        }
        public void AddBegin(object nodeInfo)
        {
            Node r = new Node(nodeInfo);
            if (head == null)
            {
                head = r;
                tail = r;
            }
            else
            {
                r.Next = head;
                head = r;
            }
        }
        public void AddEnd(object nodeInfo)
        {
            Node r = new Node(nodeInfo);
            if (head == null)
            {
                head = r;
                tail = r;
            }
            else
            {
                tail.Next = r;
                tail = r;
            }
        }
        public object TakeBegin()
        {
            if (head == null)
            {
                throw new Exception("Список пуст");
            }
            else
            {
                Node r = head;
                head = head.Next;
                if (head == null)
                {
                    tail = null;
                }
                return r.Inf;
            }
        }
        public object TakeEnd()
        {
            if (head == null)
            {
                throw new Exception("Список пуст");
            }
            else
            {
                Node r = head;
                if (head.Next == null) //если элемент в списке единственный, то
                {
                    head = null; //список «обнуляется»
                    tail = null;
                }
                else
                {
                    //в противном случае мы перемещаемся по ссылкам до предпоследнего элемента в
                    // списке и исключаем его из списка
                    while (r.Next != tail)
                    {
                        r = r.Next;
                    }
                    Node temp = tail;
                    tail = r;
                    r = temp;
                    tail.Next = null;
                }
                return r.Inf;
            }
        }
        public bool IsEmpty
        {
            get
            {
                if (head == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private Node Find(object key)
        {
            Node r = head;
            while (r != null)
            {
                if (((IComparable)(r.Inf)).CompareTo(key) == 0)
                {
                    break;
                }
                else
                {
                    r = r.Next;
                }
            }
            return r;
        }
        public void Insert(object key, object item)
        {
            Node r = Find(key);
            if (r != null)
            {
                Node p = new Node(item);
                p.Next = r.Next;
                r.Next = p;
            }
        }
        public void Delete(object key)
        {
            if (head == null)
            {
                throw new Exception("Список пуст");
            }
            else
            {
                if (((IComparable)(head.Inf)).CompareTo(key) == 0)
                {
                    head = head.Next;
                }
                else
                {
                    Node r = head;
                    while (r.Next != null)
                    {
                        if (((IComparable)(r.Next.Inf)).CompareTo(key) == 0)
                        {
                            r.Next = r.Next.Next;
                            break;
                        }
                        else
                        {
                            r = r.Next;
                        }
                    }
                }
            }
        }
        public void Show()
        {
            Node r = head; //устанавливаем ссылку на начало списка
            while (r != null) //пока не достигли конца списка
            {
                //выводим на экран содержимое информационного поля
                Console.Write("{0} ", r.Inf);
                r = r.Next; //перемещаем ссылку на следующий элемент списка
            }
            Console.WriteLine();
        }

        public double Mean()
        {
            Node r = head;
            int sum = 0;
            int count = 0;
            while (r != null)
            {
                sum += (int)r.Inf;
                count++;
                r = r.Next;
            }
            return sum / count;
        }

        public void doTask(int x)
        {
            Node r = head;
            double mean = Mean();
            while (r != null)
            {
                if (r.Next != null && (int)r.Next.Inf > mean)
                {
                    Node p = new Node(x);
                    p.Next = r.Next;
                    r.Next = p;
                    r = p.Next;
                } else r = r.Next;
            }
        }

        public override string ToString()
        {
            Node r = head;
            string stroke = "";
            while (r != null)
            {
                stroke += r.Inf.ToString() + " ";
                r = r.Next;
            }
            return stroke;
        }
    }
}