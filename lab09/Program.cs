using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab09
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            Col FirrstCol = new Col();

            FirrstCol.Add("GTA", "simulator");
            FirrstCol.Add("Fallout", "survivor");
            FirrstCol.Add("СS go", "casino");
            FirrstCol.Add("Дока 2", "horror");
            FirrstCol.Add("Doom 4", "meat");

            Col.Print(FirrstCol);

            Col.Search("Doka 2", FirrstCol);

            FirrstCol.Remove();

            Col.Print(FirrstCol);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("================================================== BlockingCollection ==================================================");
            Console.ResetColor();

            Col.Collection.Add(2);
            Col.Collection.Add('s');
            Col.Collection.Add(153.8F);
            Col.Collection.Add(255);
            Col.Collection.Add(true);

            Col.Print(Col.Collection);

            Col.RemoveF(2);

            Col.Print(Col.Collection);

            Col.AddItemAll();

            Col.Print(Col.Collection);

            Col.Clone();

            
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=========================== The second collection of the Dictionary type < TKey, TValue> ==============================");
            Console.ResetColor();


            Col.Print(Col.Dict);

            Console.WriteLine();

            Col.Search("I`am a new element!", Col.Dict);



            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("============================================== ObservableCollection<T> ================================================");
            Console.ResetColor();

            var data = new ObservableCollection<Game>();
            data.CollectionChanged += Col.Foo();
            data.Add(new Game("one", " a"));
            data.Add(new Game("two", " b"));
            data.Add(new Game("three", " s"));
            data.Add(new Game("four", " d"));

            Console.WriteLine();
            foreach (var item in data)
            {
                Console.WriteLine(item.PropName + "\t" + item.PropGenre);
            }

            data.Insert(1, new Game("I was inserted", " "));

            Console.WriteLine();
            foreach (var item in data)
            {
                Console.WriteLine(item.PropName + "\t" + item.PropGenre);
            }

            data.Remove(data.First());

            Console.WriteLine();
            foreach (var item in data)
            {
                Console.WriteLine(item.PropName + "\t" + item.PropGenre);
            }
        }
    }
}
