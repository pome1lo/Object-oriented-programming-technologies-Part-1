using System;

namespace lab_03_list
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> ListOne = new List<string>();

            ListOne.AddNode(" 1 element..  ");
            ListOne.AddNode(" 2 element..  ");
            ListOne.AddNode(" 3 element..  ");

            //ListOne.AddNode("Oooo");
            //ListOne.AddNode("fff");
            //ListOne.AddNode("1234");
            //ListOne.AddNode("qwerty");
            //ListOne.AddNode("First");
            //ListOne.AddNode("Quanity");



            /* */
            Console.WriteLine("\n");

            ListOne.WriteItemList();

            string item = " I 0 element..   ";

            ListOne += item;
            
            ListOne.WriteItemList();

            --ListOne;

            ListOne.WriteItemList();

            /* */ Console.WriteLine("\n");

            Console.WriteLine("Creating a second list..");

            List<string> ListTwo = new List<string>();
            ListTwo.AddNode("I'm the second list");
            ListTwo.AddNode(" element 1. ");
            ListTwo.AddNode(" element 2. ");
            ListTwo.AddNode(" element 3. ");
            
            ListTwo.WriteItemList();

            /* */ Console.WriteLine("\n");

            Console.WriteLine(ListOne==ListTwo);

            /* */ Console.WriteLine("\n");

            List<string>.StatisticOperation.Sum(ListTwo, ListOne);



            Console.WriteLine(ListOne.EqualsElemnt(ListTwo) + "\n");

            ListOne.WriteItemList();

            Console.WriteLine(ListOne.UpperLet(ListOne)); 
        }
    }
}
