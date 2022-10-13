using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace lab08
{

    internal class Programmer
    {
        public Programmer()
        {

        }
        public Programmer(string Name)
        {
            this.Name = Name;
        }

        // поля

        //private ConsoleColor MutateColor = ConsoleColor.White;
        private string Name = "there is no information.";
        private string MutationStatus = "there is no information.";
        public ConsoleColor MutateColor = ConsoleColor.Green;
        private int ColorIndex = 1;

        public int PropColorIndex
        {
            get { return ColorIndex; }
            set { ColorIndex = value; }
        }

        public string PropMutationStatus
        {
            get { return MutationStatus; }
            set { MutationStatus = value; }
        }
        public string PropName
        {
            get { return Name; }
            set { Name = value; }
        }
        public ConsoleColor PropMutateColor
        {
            get { return MutateColor; }
            set { MutateColor = value; }
        }

        public static void MutateFoo(Programmer Item) => Item.PropColorIndex++;

        public static void RemoveFoo(List<Programmer> MyList, int Index = 0) => MyList.RemoveAt(Index);

        public static void Print(List<Programmer> MyList, ConsoleColor Color = ConsoleColor.White)
        {
            int i = 1;
            foreach (var item in MyList)
            {
                Console.Write($"{i}) Programmer's name: {item.Name}\t\t|\t");

                if (item.PropColorIndex == 2)
                {
                    item.PropMutateColor = ConsoleColor.White;
                    item.MutationStatus = "There is an infection";
                }
                if (item.PropColorIndex == 3)
                {
                    item.PropMutateColor = ConsoleColor.Yellow;
                    item.MutationStatus = "The mutation of the cells has begun";
                }
                if (item.PropColorIndex == 4)
                {
                    item.PropMutateColor = ConsoleColor.Red;
                    item.MutationStatus = $"{item.Name}became a mutated monster!";
                }

                Console.ForegroundColor = item.MutateColor;
                Console.WriteLine($"Mutation: {item.MutationStatus}");
                Console.ResetColor();

                i++;
            }
            Console.WriteLine();
        }

        public static void Сoncatenation(string a, string b, Action<string, string> conc) => conc(a, b);
        public static void Add(string a, string b) => Console.WriteLine($"Concatenation: {a + b}");

        public static Predicate<string> UpperOrLower = (string str) => (str.First() >= 1040 && str.First() <= 1071 || str.First() >= 65 && str.First() <= 90);

        public static int StringLen(string str, Func<string, int> operation) => operation(str);
        public static int StrLen(string str) => str.Length;


        public static string RemoveExtraSpaces(string str) => Regex.Replace(str.Trim(), @"", " ");
        public static string ToDefaultCase(string str) => $"{str.ToUpper().First()}{str.ToLower().Substring(1)}";
        public static string ToUp(string str) => str.ToUpper();
        public static string StrLeng(string str) => $"Number of characters {str.Length}";
    }
}
