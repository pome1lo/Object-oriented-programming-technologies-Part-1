using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03_list
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var Test = new List<string>();
                Test.AddNode("1 element");
                Test.AddNode("2 element");
                Test.AddNode("3 element");
                Test.AddNode("Delete me");
                Test.AddNode("4 element");
                Test.AddNode("5 element");

                Test.PrintList();

                Test.RemoveNode("Delete me");

                Test.PrintList();

                Console.WriteLine(Test.IsUpperLet(Test));

                var ss = new Production();

                List<int>.Foo<Production>(ss);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{e.Message}\n");
                Console.ResetColor();
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Я блок finally.");
                Console.ResetColor();


                Console.WriteLine("\nСодержимое файла:\n");
                string[] arr = List<string>.ReadFileLogger();

                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                }
            }
        }

        class Account<T>
        {
            public Account(T id)
            {

            }
        }
        class UniversalAccount<T> : Account<T>
        {
            public UniversalAccount(T id) : base(id)
            {

            }
        }
    }
}
