using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace lab09
{
    internal class Col
    {
        public Col()
        {
            MyList = new List<Game>();
        }
        private List<Game> MyList { get; set; }
        public void Add(string Name, string Genre) => MyList.Add(new Game(Name, Genre));
        public void Remove(int index = 0) => MyList.RemoveAt(index);

        public static void Search(string Name, object obj)
        {
            int i = 0;
            int j = 0;
            if (obj is Col)
            {
                var FirstCol = obj as Col;
                foreach (var item in FirstCol.MyList)
                {
                    if (item.PropName == Name)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"The element with the name {Name} is located under the index {i}\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        j++;
                    }
                    i++;
                }
            }
            else
            {
                var Dict = obj as Dictionary<char, object>;
                foreach (var item in Dict)
                {
                    if ((string)item.Value == Name)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"The element with the name {Name} is located under the index {i}\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        j++;
                    }
                    i++;
                }
            }
            if (j == 0)
            {
                Console.WriteLine($"The element named {Name} does not exist in the current collection.");
            }
        }

        public static BlockingCollection<object> Collection = new BlockingCollection<object>();

        public static void Print(object obj)
        {
            Console.WriteLine();
            if (obj is Col)
            {
                var FirstCol = obj as Col;
                foreach (var item in FirstCol.MyList)
                {
                    Console.WriteLine($"Name of the game: {item.PropName}\nGenre of the game: {item.PropGenre}\n");
                }
                Console.WriteLine();
            }
            else if (obj is BlockingCollection<object>)
            {
                foreach (var item in Collection)
                {
                    Console.WriteLine($"Element: {item}");
                }
            }
            else
            {
                foreach (var item in Dict)
                {
                    Console.WriteLine(item.Key + ". " + item.Value);
                }
            }
        }
        public static void RemoveF(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Collection.Take();
            }
        }
        public static void AddItemAll()
        {
            Collection.TryAdd("Test String");
            Collection.Add(228);
            Collection.Add("I`am a new element!");
        }

        public static Dictionary<char, object> Dict = new Dictionary<char, object>();

        public static void Clone()
        {
            int index = 49;
            foreach (var item in Collection)
            {
                Dict.Add((char)index, item.ToString());
                index++;
            }
        }

        public static System.Collections.Specialized.NotifyCollectionChangedEventHandler Foo()
        {
            Console.WriteLine("I subscribed to the CollectionChanged event and I was called:(");
            return null;
        }
    }
}
