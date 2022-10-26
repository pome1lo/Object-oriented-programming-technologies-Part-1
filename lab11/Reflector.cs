using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Reflection;
    
namespace Lab11
{
    internal class Reflector
    {
        public static void Test(object _Name, string TypeOfParams = null)
        {
            string Name = _Name as String;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\t\t\t\t\t\t=== Class {Name} ===");
            Console.ForegroundColor = ConsoleColor.Yellow;

            string AssemblyName = typeof(Reflector).Assembly.GetName().Name;
            Console.WriteLine($"Assembly name: {AssemblyName}");

            Print("Available methods and constructors: ");
            foreach (var memberInfo in Type.GetType(Name).GetMembers())
            {
                Console.WriteLine(" : " + memberInfo.Name);
            }

            Print("Implemented interfaces: ");
            foreach (var memberInfo in Type.GetType(Name).GetInterfaces())
            {
                Console.WriteLine(" : " + memberInfo.Name);
            }

            Print("Available methods: ");
            foreach (var memberInfo in Type.GetType(Name).GetMethods())
            {
                Console.WriteLine(" : " + memberInfo.Name);

            }

            if (TypeOfParams != null)
            {
                var request = Type.GetType(Name).GetMethods().Where(ы => ы.GetParameters().Any(item => item.ParameterType == Type.GetType(TypeOfParams)));

                if (request.Count() > 0)
                {
                    Print("All methods: ");
                    foreach (var item in request)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Print("There are no methods with the parameters you specified: ");
                }
            }

            File.AppendAllText(@"..\..\..\..\Json.json", JsonConvert.SerializeObject(Name));
            File.AppendAllText(@"..\..\..\..\Json.json", JsonConvert.SerializeObject(Type.GetType(Name).GetMembers()));
            File.AppendAllText(@"..\..\..\..\Json.json", JsonConvert.SerializeObject(Type.GetType(Name).GetInterfaces()));
            File.AppendAllText(@"..\..\..\..\Json.json", JsonConvert.SerializeObject(Type.GetType(Name).GetMethods()));
            
        }
        public static void Print(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public static void Invoke(Object obj, string MethodName, Object[] objArr)
        {
            MethodInfo Foo = new Reflector().GetType().GetMethod(MethodName);

            Foo.Invoke(null, objArr);
        }
        public static void Generator()
        {
            Random rnd = new Random();
            rnd.Next(0, 5);

            string[] RandClassName = { "Lab11.Program", "Lab11.Receipt", "Lab11.Invoice", "Lab11.Reflector", "System.Int32", "System.Int16", "System.Single" };
            string[] RandMethodName = { "Test", "Test", "Test", "Test", "Test" };

            object[] objArr = { RandClassName[rnd.Next(0, 7)], null };
            Reflector.Invoke(null, RandMethodName[rnd.Next(0, 5)], objArr);
        }
        public static void Create<T>(string Name) => Console.WriteLine((Activator.CreateInstance(Type.GetType(Name))) == null ? "null" : Activator.CreateInstance(Type.GetType(Name)));
        
    }
}
