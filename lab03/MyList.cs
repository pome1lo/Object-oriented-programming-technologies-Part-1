using System;
using System.Linq;

namespace lab_03_list
{
    partial class List<T> where T : IComparable
    {
        private Node<T> HeadNode;
        private Node<T> TailNode;
        private int Lenght { get; set; }
        public Node<T> PropHeadNode
        {
            get { return HeadNode; }
            set { HeadNode = value; }
        }
        public Node<T> PropTailNode
        {
            get { return TailNode; }
            set { TailNode = value; }
        }

        public List()
        {
            HeadNode = null;
            TailNode = null;
        }


        public void AddNode(T data)
        {
            if (HeadNode == null)
            {
                PropHeadNode = new Node<T>(data);
                PropTailNode = PropHeadNode;
            }
            else
            {
                Node<T> newNode = new Node<T>(data);
                TailNode.NextNode = newNode;
                TailNode = newNode;

            }
            Lenght++;
        }
        public void WriteItemList()
        {
            Node<T> tempNode = PropHeadNode;
            while (tempNode != null)
            {
                Console.Write(tempNode.Data + "\n");
                tempNode = tempNode.NextNode;
            }
            Console.WriteLine();
        }

        public static List<T> operator +(List<T> List, T Item)
        {
            Node<T> newNode = new Node<T>(Item);
            newNode.NextNode = List.PropHeadNode;
            List.PropHeadNode = newNode;
            List.Lenght++;
            return List;
        }
        public static List<T> operator --(List<T> List)
        {
            List.HeadNode = List.HeadNode.NextNode;
            List.Lenght--;
            return List;
        }
        public static bool operator !=(List<T> List1, List<T> List2)
        {
            if(List1.Lenght != List2.Lenght)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator ==(List<T> List1, List<T> List2)
        {
            if (List1.Lenght == List2.Lenght)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static List<T> operator *(List<T> List1, List<T> List2)
        {
            List1.TailNode.NextNode = List2.HeadNode;
            return List1;
        }


        public int UpperLet(List<T> List)
        {
            int quanity = 0;
            int buf;
            if (List.HeadNode.Data is String)
            {
                String temp = List.HeadNode.Data as String;

                Node<T> tempNode = PropHeadNode;
                while (tempNode != null)
                {
                    buf = (int)temp.First();
                    if (buf >= 1040 && buf <= 1071 || buf >= 65 && buf <= 90)
                    {
                        quanity++;
                    }
                    tempNode = tempNode.NextNode;
                }
                return quanity / 2;
            }
            else
            {
                Console.WriteLine("The list items are not a string!");
                return 0;
            }
        }


        public bool EqualsElemnt(List<T> List)
        {
            return Equals(List);
        }
    }
}
