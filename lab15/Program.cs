using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace lab15
{
    internal class Program
    {
        public static void Febonachi(int number = 48)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int one = 1;
            int two = 1;
            int sum;

            int j = 2;
            while (j <= number)
            {
                Thread.Sleep(100);
                sum = one + two;
                one = two;
                two = sum;
                j++;
            }
            stopwatch.Stop();
            Console.WriteLine("Under the number {0} in the Fibonacci series is the number {1}", number, one);

            Console_Print($"Time spent on unloading: {(double)stopwatch.ElapsedMilliseconds} milliseconds\n\n", ConsoleColor.Yellow);

        }
        static void Main(string[] args)
        {
            int j = 0;

            #region Task 1

            Console_Print("First pass", ConsoleColor.DarkGreen);
            Task task1 = new Task(() => Febonachi());
            task1.Start();

            Thread.Sleep(2500);

            Console.WriteLine("Status of the current task: {0}", task1.Status);
            Console.WriteLine("ID of the current task: {0}", task1.Id);

            task1.Wait();


            Console_Print("Second pass", ConsoleColor.DarkGreen);
            Task task2 = new Task(() => Febonachi());
            task2.Start();
            task2.Wait();


            Console_Print("Third pass", ConsoleColor.DarkGreen);
            Task task3 = new Task(() => Febonachi());
            task3.Start();
            task3.Wait();

            #endregion
            #region Task 2
            Console.ReadKey(); Console.Clear();

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task task4 = new Task(() =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                int One = 1;
                int Two = 1;
                int sum;
                int k = 2;

                while (k <= 48)
                {
                    if (token.IsCancellationRequested)  
                    {
                        Console_Print("The operation was aborted using a cancellation token", ConsoleColor.Red);
                        return;                         
                    }
                    Thread.Sleep(50);
                    sum = One + Two;
                    One = Two;
                    Two = sum;
                    k++;

                    Console.Clear();
                    Console.WriteLine(sum);
                }
                stopwatch.Stop();
                Console.WriteLine("Under the number {0} in the Fibonacci series is the number{1}", 48, One);

                Console_Print($"Time spent on unloading: {(double)stopwatch.ElapsedMilliseconds} milliseconds\n\n", ConsoleColor.Yellow);

            }, token);
            task4.Start();

            Thread.Sleep(3000);

            cancelTokenSource.Cancel();                        
            Thread.Sleep(1000);                                
            Console.WriteLine($"Task Status: {task4.Status}"); 
            cancelTokenSource.Dispose();                       

            #endregion
            #region  Task 3
            Console.ReadKey(); Console.Clear();

            Task start = new Task(() => Console.WriteLine("Sum of squares of numbers 3 3 9"));
            Task<int> pow1 = start.ContinueWith(sum1 => Pow(3));
            Task<int> pow2 = pow1.ContinueWith(sum2 => Pow(3));
            Task<int> pow3 = pow2.ContinueWith(sum3 => Pow(9));
            Task printTask = pow3.ContinueWith(task => PrintResult(pow1.Result + pow2.Result + pow3.Result));

            start.Start();

            printTask.Wait();

            int Pow(int a) => a * a;
            void PrintResult(int sum) => Console.WriteLine($"Sum: {sum}");

            #endregion
            #region Task 4
            Console.ReadKey(); Console.Clear();

            Task task4_1 = new Task(() =>
            {
                Console_Print("I am the task 1", ConsoleColor.DarkGreen);
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(100);
                    Console_Print("I'm being executed..", ConsoleColor.White);
                }
                Console_Print("I've finished!\n", ConsoleColor.DarkYellow);
            });


            Task task4_2 = task4_1.ContinueWith((Task task) =>
            {
                Console_Print("I am the task 2", ConsoleColor.DarkGreen);
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(100);
                    Console_Print("I'm being executed..", ConsoleColor.White);
                }
                Console_Print("I've finished!", ConsoleColor.DarkYellow);
            });

            task4_1.Start();
            task4_2.Wait();

            //

            int one = GetOneAsync().GetAwaiter().GetResult();
            Console.WriteLine("\nUsing .GetAwaiter().GetResult() : one = {0}", one);
            async Task<int> GetOneAsync()
            {
                await Task.Delay(1000);
                return 1;
            }

            #endregion
            #region Task 5
            Console.ReadKey(); Console.Clear();

            Console_Print("(Parallel) Cycle for: ", ConsoleColor.DarkGreen);

            Stopwatch stopwatch3 = new Stopwatch();
            stopwatch3.Start();

            ParallelLoopResult res1 = Parallel.For(1, 5, Square);


            Console_Print("\n(Parallel) Cycle foreach: ", ConsoleColor.DarkGreen);

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();

            ParallelLoopResult res2 = Parallel.ForEach<int>(
                new List<int>() { 1, 3, 5, 8 }, 
                // new ParallelOptions { CancellationToken = token }, Square
                Square
            );

            void Square(int n)
            {
                Console.WriteLine($"The task is in progress {Task.CurrentId}");
                Console.WriteLine($"The square of the number {n} is equal to {n * n}");
                Thread.Sleep(2000);
            }

            if (res1.IsCompleted == true)
            {
                stopwatch3.Stop();
                Console_Print($"Cycle execution time for: {(double)stopwatch3.ElapsedMilliseconds} milliseconds", ConsoleColor.Yellow);
            }
            if (res2.IsCompleted == true)
            {
                stopwatch2.Stop();
                Console_Print($"Cycle execution time foreach: {(double)stopwatch2.ElapsedMilliseconds} milliseconds", ConsoleColor.Yellow);
            }

            #endregion
            #region Task 6
            Console.ReadKey(); Console.Clear();

            Parallel.Invoke(
                () =>
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("Method 1 : I am the number {0} in the invoke", i);
                    }
                },
                () => Console_Print("method 2 : I'm some kind of string in the invoke", ConsoleColor.Red),
                Sum
                );

            #endregion
            #region Task 7
            Console.ReadKey(); Console.Clear();

            BlockingCollection<string> col = new BlockingCollection<string>();
            Task provider1 = new Task(() => { Thread.Sleep(200); col.Add($"product {j++}"); });
            Task provider2 = new Task(() => { Thread.Sleep(500); col.Add($"product {j++}"); });
            Task provider3 = new Task(() => { Thread.Sleep(800); col.Add($"product {j++}"); });
            Task provider4 = new Task(() => { Thread.Sleep(1100); col.Add($"product {j++}"); });
            Task provider5 = new Task(() => { Thread.Sleep(1400); col.Add($"product {j++}"); });
            provider1.Start();
            provider2.Start();
            provider3.Start();
            provider4.Start();
            provider5.Start();

            for (int i = 0; i < 10; i++)
            {
                Console_Print($"Number of products: {col.Count}", ConsoleColor.DarkGray);
                Thread.Sleep(500);
                Thread thr = new Thread(Client);
                thr.Start();
            }

            void Client()
            {
                if (col.Count == 0)
                {
                    Console_Print("The buyer has a non-payment", ConsoleColor.Red);
                    return;
                }
                col.Take();
                Console_Print("The buyer bought", ConsoleColor.White);
            }
            #endregion
            // Task 8 in Task 4
        }


        public static void Sum() => Console.WriteLine("method 3 : 2 + 2 = 5000");
        public static void Console_Print(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }

    }
}
