using System;

namespace lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Class Receipt()");
            Console.WriteLine("Creating an instance of a class without parameters:\n");
            var instance1 = new Receipt();
            Operation.Print(instance1);

            Console.WriteLine("\nCreating an instance of a class with parameters:\n");
            var instance2 = new Receipt("Безнал", DateTime.Now, 528);
            Operation.Print(instance2);
            Console.WriteLine("Calling an overridden method ToString():\n");
            Console.WriteLine(instance1.ToString());
            Console.ReadLine();
            Console.Clear();

            //

            Console.WriteLine("Class Invoice()");
            Console.WriteLine("Creating an instance of a class without parameters:\n");
            var instance3 = new Invoice();
            Operation.Print(instance3);

            Console.WriteLine("\nCreating an instance of a class with parameters:\n");
            var instance4 = new Invoice("Молоко", 1, 29);
            Operation.Print(instance4);
            Console.WriteLine("Calling an overridden method ToString():\n");
            Console.WriteLine(instance3.ToString());
            Console.ReadLine();
            Console.Clear();

            //

            Console.WriteLine("Class Organization()");
            Console.WriteLine("Creating an instance of a class without parameters:\n");
            var instance5 = new Organization();
            Operation.Print(instance5);

            Console.WriteLine("\nCreating an instance of a class with parameters:\n");
            var instance6 = new Organization("EPAM", "Confectionery");
            Operation.Print(instance6);
            Console.WriteLine("Calling an overridden method ToString():\n");
            Console.WriteLine(instance5.ToString());
            Console.ReadLine();
            Console.Clear();

            // 

            Object[] arr = { 
                new Invoice(), 
                new Printer(), 
                new Сheque(), 
                new Organization(), 
                new Date(), 
                new Receipt()
            };

            foreach (var item in arr)
            {
                Printer.IAmPrinting(item);
            }
        }
    }
}
