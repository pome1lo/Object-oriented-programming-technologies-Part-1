using System;
using System.Threading;

namespace lab14
{
    internal class Program
    {
        static void Main(string[] args)
        {
        // 1, 2 

            MyStream.GetProcess();
            MyStream.GetDomain();

        // 3 
            Console.ReadKey(); Console.Clear();

            Console.Write("Input n: ");
            MyStream.n = int.Parse(Console.ReadLine());

            Thread myThread = new Thread(MyStream.func);
            myThread.Name = "Flow 1";
            myThread.Start();

            for (int i = 0; i < MyStream.n; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Flow 1: " + i);
                Console.ResetColor();
                if(i == MyStream.n / 2)
                {
                    Console.WriteLine("suspending the flow..");

                    MyStream.ThreadInfo(myThread);
                    Thread.Sleep(500);

                    Console.WriteLine("Resuming the flow");
                    myThread.Join();

                }
                Thread.Sleep(100);
            }
            myThread.Interrupt();

        // 4

            Console.Write("Enter n again: ");
            MyStream.n = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("n = " + MyStream.n);

            Console.WriteLine("First even then odd: ");

            Thread thread1 = new Thread(MyStream.ThreadOne);
            Thread thread2 = new Thread(MyStream.ThreadTwo);

            thread1.Start();
            thread2.Start();

            thread1.Priority = ThreadPriority.Highest;
            thread2.Priority = ThreadPriority.Lowest;

            Console.ReadKey(); Console.Clear();


         // 5

            Console.WriteLine("Date and time output every 2 seconds: ");

            TimerCallback tm = new TimerCallback(MyStream.Count);
            Timer timer = new Timer(tm, 0, 0, 2000);

            Console.ReadKey();
        }
    }
}
