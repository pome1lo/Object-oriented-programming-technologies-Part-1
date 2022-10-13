using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab08
{
    internal class Program
    {
        public delegate void DelegateRemove(List<Programmer> MyList, int Index = 0);
        public delegate void DelegateMutate(Programmer Item);

        public static event DelegateRemove Remove;
        public static event DelegateMutate Mutate;

        static void Main(string[] args)
        {
            List<Programmer> MyList = new List<Programmer>();

            MyList.Add(new Programmer("Anton "));
            MyList.Add(new Programmer("Alex "));
            MyList.Add(new Programmer("Stepan "));
            MyList.Add(new Programmer("Victor "));

            Programmer.Print(MyList);

            //Programmer.Remove += Programmer.RemoveFoo;
            //Programmer.Remove(MyList);
            
            Remove += Programmer.RemoveFoo;
            Mutate += Programmer.MutateFoo;

            Remove(MyList);
            Programmer.Print(MyList);

            Remove(MyList, 2);
            Programmer.Print(MyList);

            Mutate(MyList[0]);
            Programmer.Print(MyList);

            Mutate(MyList[0]);
            Programmer.Print(MyList);

            Mutate.Invoke(MyList[0]);
            //Mutate(MyList[0]);
            Programmer.Print(MyList);

            Programmer.Сoncatenation("OOP ", "TOP )", Programmer.Add);

            Console.WriteLine(Programmer.UpperOrLower("test"));

            Console.WriteLine(Programmer.StringLen("TEST", Programmer.StrLen));


            string startStr = "StRiNg TeST";
            Console.WriteLine(startStr);
            Action<string> CurrentString = (str) => Console.WriteLine(str);
            Func<string, string> stringOperations = Programmer.RemoveExtraSpaces;

            stringOperations += Programmer.ToDefaultCase;
            CurrentString(startStr = stringOperations(startStr));

            stringOperations += Programmer.ToUp;
            CurrentString(startStr = stringOperations(startStr));

            stringOperations += Programmer.StrLeng;
            CurrentString(startStr = stringOperations(startStr));

        }
    }
}
