using System;
using System.Threading;

namespace HardTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread machine1 = new Thread(Machine.Machine1);
            Thread machine2 = new Thread(Machine.Machine2);
            Thread machine3 = new Thread(Machine.Machine3);

            machine1.Start();
            machine2.Start();
            machine3.Start();

            Console.ReadKey();

            for (int i = 0; i < 7; i++)
            {
                Client client = new Client(i + 1);
            }
        }
    }

    class Client 
    {
        static Semaphore sem = new Semaphore(3, 3);
        Thread myThread;
        int count = 3;

        public Client(int i)
        {
            myThread = new Thread(Pull.Func);
            myThread.Name = $"Client {i}";
            myThread.Start();
        }

    }
    class Pull
    {
        static Semaphore sem = new Semaphore(3, 3);
        Thread thread; 
        static int count = 3;
        public static void Func()
        {
            while (count > 0)
            {
                if (!sem.WaitOne(1500))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Thread.CurrentThread.Name} the client did not wait..");
                    Console.ResetColor();
                    
                    break;
                }

                Console.WriteLine($"{Thread.CurrentThread.Name} started using the channel");

                Console.WriteLine($"{Thread.CurrentThread.Name} using...");
                Thread.Sleep(1000);

                Console.WriteLine($"{Thread.CurrentThread.Name} stopped using the channel");

                sem.Release(); 

                count--;
                Thread.Sleep(2000);
            }
        }
    }
}
