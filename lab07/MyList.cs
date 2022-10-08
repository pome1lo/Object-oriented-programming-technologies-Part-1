using System;
using System.Linq;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace lab_03_list
{
    partial class List<T> : IMyInterface<T> where T : IComparable
    {
        private const string path = "\\Log.txt";
        private static int index = 0;
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

            if (index == 0)
            {
                File.Create(path).Close();
                File.AppendAllText(path, $"❛━━━━━━━ Logger ━━━━━━━❜\nCreation {index + 1} list instance List CollectionType<T> $$$" + "\n");
            }
        }
        public void WriteFileLogger(T data)
        {
            if(data is String)
            {
                String str = data as String;
                File.AppendAllText(path, str + "\n");
                index++;
            } 
        }
        public static string[] ReadFileLogger()
        {
            string[] arr = File.ReadAllLines(path);
            return arr;
        }
        public void RemoveNode(T RemovData)
        {
            Node<T> tempNode = HeadNode;

            if (HeadNode.Data is String)
            {
                String tempStringData = HeadNode.Data as String;
                if (tempStringData.CompareTo(RemovData) == 0)
                {
                    HeadNode = HeadNode.NextNode;
                    Lenght--;
                    return;
                }
                while (tempNode != null)
                {
                    String str = tempNode.NextNode.Data as String;
                    if (str.CompareTo(RemovData) == 0)
                    {
                        tempNode.NextNode = tempNode.NextNode.NextNode;
                        Lenght--;
                        return;
                    }
                    tempNode = tempNode.NextNode;
                }
            }
        }
        public void AddNode(T data)
        {
            if (HeadNode == null)
            {
                PropHeadNode = new Node<T>(data);
                PropTailNode = PropHeadNode;
                File.AppendAllText(path, "[ Adding an element ]: ");
                WriteFileLogger(data);
            }
            else
            {
                Node<T> newNode = new Node<T>(data);
                TailNode.NextNode = newNode;
                TailNode = newNode;
                File.AppendAllText(path, "[ Adding an element ]: ");
                WriteFileLogger(data);
            }
            Lenght++;
        }
        public void PrintList()
        {
            int i = 1;
            Node<T> tempNode = PropHeadNode;
            while (tempNode != null)
            {
                Console.Write($"{i})\t {tempNode.Data}\n");
                tempNode = tempNode.NextNode;
                i++;
            }
            Console.WriteLine();
        }

        public string IsUpperLet(List<T> List)
        {
            Predicate<string> PredicateUpLetter = (string str) => (str.First() >= 1040 && str.First() <= 1071 || str.First() >= 65 && str.First() <= 90);
            
            if (List.HeadNode.Data is String)
            {
                String temp = List.HeadNode.Data as String;
                Node<T> tempNode = HeadNode;
                while (tempNode != null)
                {
                    temp = tempNode.Data as String;
                    if(PredicateUpLetter(temp))
                    {
                        return temp;
                    }
                    tempNode = tempNode.NextNode;
                }
                return "Elements starting with a capital letter were not found.";
            }
            else
            {
                return "Элементы списка не являются строкой!";
            }
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



        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
