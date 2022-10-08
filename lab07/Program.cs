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
                Test.AddNode("я первый");
                Test.AddNode("я второй");
                Test.AddNode("я третий");
                Test.AddNode("Удаляй меня полностью");
                Test.AddNode("я четвертый");
                Test.AddNode("Я пятый");

                Test.PrintList();

                Test.RemoveNode("Удаляй меня полностью");

                Test.PrintList();

                Console.WriteLine(Test.IsUpperLet(Test));

                var ss = new Production();

                Console.WriteLine("\nПользовательский класс, который будет использоваться в качестве параметра обобщения.");
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
