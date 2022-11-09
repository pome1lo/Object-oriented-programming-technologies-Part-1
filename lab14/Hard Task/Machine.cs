using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace HardTask
{
    internal class Machine
    {
        private static object locker = new object();  
        private static string[,] Product = new string[3, 10];

        public static void Machine1() 
        {
            int number = 0;
            lock (locker)
            {
                Print("\n\tFirst car: unloading", ConsoleColor.DarkGreen);
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                Unloading(200, number);


                stopwatch.Stop();
                Print($"Time spent on unloading: {(double)stopwatch.ElapsedMilliseconds} milliseconds\n\n", ConsoleColor.Yellow);

                /// 

                Print("\n\tLoading", ConsoleColor.DarkGreen);
                stopwatch.Restart();

                Loading(300, number);

                stopwatch.Stop();
                Print($"Time spent on loading: {(double)stopwatch.ElapsedMilliseconds} milliseconds\n\n", ConsoleColor.Yellow);
            }
        }
        public static void Machine2()
        {
            int number = 1;
            lock (locker)
            {
                Print("\n\tSecond car: unloading", ConsoleColor.DarkGreen);
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                Unloading(400, number);

                stopwatch.Stop();
                Print($"Time spent on unloading: {(double)stopwatch.ElapsedMilliseconds} milliseconds\n\n", ConsoleColor.Yellow);

                /// 

                Print("\n\tLoading", ConsoleColor.DarkGreen);

                stopwatch.Restart();

                Loading(600, number);

                stopwatch.Stop();
                Print($"Time spent on loading: {(double)stopwatch.ElapsedMilliseconds} milliseconds\n\n", ConsoleColor.Yellow);
            }
        }
        public static void Machine3()
        {
            int number = 2;
            lock (locker)
            {
                Print("\n\tThird machine: unloading", ConsoleColor.DarkGreen);
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                Unloading(600, number);

                stopwatch.Stop();
                Print($"Time spent on unloading: {(double)stopwatch.ElapsedMilliseconds} milliseconds\n\n", ConsoleColor.Yellow);

                /// 

                Print("\n\tLoading", ConsoleColor.DarkGreen);
                stopwatch.Restart();

                Loading(800, number);

                stopwatch.Stop();
                Print($"Time spent on loading: {(double)stopwatch.ElapsedMilliseconds} milliseconds\n\n", ConsoleColor.Yellow);
            }
        }

        public static void Unloading(int sleep, int IndexMachine)
        {
            var product = File.ReadAllLines(@"../../../../Storehouse.txt");

            Print("Status: Unloading has begun...", ConsoleColor.White);

            Console.WriteLine("List of products: ");

            for (int i = 0; i < product.Length; i++)
            {
                Thread.Sleep(sleep);
                Product[IndexMachine, i] = product[i];
                Console.WriteLine(": " + product[i]);
            }
            Print("Unloading was completed successfully!", ConsoleColor.Green);
        }

        public static void Loading(int sleep, int IndexMachine)
        {
            Print("Status: Download has started...", ConsoleColor.White);
            Console.WriteLine("List of products: ");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(sleep);
                Console.WriteLine(Product[IndexMachine, i]);
            }
            Print("Loading completed successfully!", ConsoleColor.Green);
        }

        public static void Print(string str, ConsoleColor clr)
        {
            Console.ForegroundColor = clr;
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }

}
