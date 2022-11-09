using System;
using System.Diagnostics;
using System.Threading;

namespace lab14
{
    internal class MyStream
    {
        public static int n { get; set; }
        public static object locker = new object();  // stub object

        static Semaphore sem = new Semaphore(1, 1);
        Thread myThread;
        public static int count = 1;
        public static int a = 0;
        public static int b = 1;

        public static void OLD_GetProcess()
        {
            var listProcess = Process.GetProcesses();
            foreach (var item in listProcess)
            {
                Console.WriteLine($"Id:{item.Id} | " +
                                  $"Name:{item.ProcessName} | " + 
                                  $"Priority:{item.PriorityClass} | " +
                                  $"Launch time:{item.StartTime} | " +
                                  $"Condition:{item.Responding} \n");
            }
        }
        public static void GetProcess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Process Info\n".PadLeft(60));
            Console.ResetColor();

            var allProcesses = Process.GetProcesses();
            Console.Write("{0,20}", "ID:");
            Console.Write("{0,40}", "Process Name:");
            Console.Write("{0,15}", "Priority:\n");
            foreach (var process in allProcesses)
            {

                Console.Write("{0,20}", $"{process.Id}");
                Console.Write("{0,40}", $"{process.ProcessName}");
                Console.Write("{0,14}", $"{process.BasePriority}");
                Console.WriteLine();
            }
        }
        public static void GetDomain()
        {

            Console.WriteLine("Domain Info:");
            var thisAppDomain = Thread.GetDomain();

            Console.WriteLine($"\n\n\nName:  {thisAppDomain.FriendlyName}");
            Console.WriteLine($"Setup Information:  {thisAppDomain.SetupInformation}");
            Console.WriteLine("Assemblies:");

            foreach (var item in thisAppDomain.GetAssemblies())
            {
                Console.WriteLine("    " + item.FullName.ToString());
            }
        }
        public static void func()
        {
            for (int i = 0; i < n; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Flow 2: " + i);
                Console.ResetColor();
                Thread.Sleep(88);
            }
        }
        public static void ThreadInfo(Thread thread)
        {
            Console.WriteLine("Flow name: " + thread.Name);
            Console.WriteLine("Flow id: " + thread.ManagedThreadId);
            Console.WriteLine("Thread priority: " + thread.Priority);
            Console.WriteLine("Is the stream background: " + thread.IsBackground);
        }

        public static void ThreadOne()
        {
            lock(locker)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Flow 1: " + i);
                        Console.ResetColor();
                    }
                    Thread.Sleep(100);
                }
            }
            
        }
        public static void ThreadTwo()
        {
            lock(locker)
            { 
                for (int i = 0; i < n; i++)
                {
                    if (i % 2 != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Flow 2: " + i);
                        Console.ResetColor();

                    }
                    Thread.Sleep(200);
                }
            }
        }

        public static void Count(object obj) => Console.WriteLine(DateTime.Now);
        
    }
}
