using System;
using System.Collections.Generic;
using System.Linq;

namespace lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Year = {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June's",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };
            int i = 1;
            var newYear = Year.Select(x => $"{i++}. {x}");
            Console.WriteLine(string.Join(Environment.NewLine, newYear) + "\n");

            // a query that selects a sequence of months with a string length equal to n
            var newYear1 = Year.Aggregate("четы", (x, y) => y.Length == x.Length ? y : x);
            Console.WriteLine(string.Join(Environment.NewLine, newYear1) + "\n");

            // a request that returns only the summer and winter months
            var newYear2 = from item in Year where (new[] { "January", "February", "June", "July", "August", "December" }.Contains(item)) select item;
            Console.WriteLine(string.Join(Environment.NewLine, newYear2) + "\n");

            // request to output months in alphabetical order
            var newYear3 = Year.OrderBy(x => x);
            Console.WriteLine(string.Join(Environment.NewLine, newYear3) + "\n");

            // a query counting months containing the letter "u" and a name length of at least 4
            var temp = Year.Where(x => x.Contains("u"));
            var newYear4 = temp.Aggregate("12345", (x, y) => y.Length > x.Length ? y : x);
            Console.WriteLine(string.Join(Environment.NewLine, newYear4) + "\n");

            List<Product> MyList = new List<Product>();

            MyList.Add(new Product(Guid.NewGuid(), "Chips ", 32312312, "Lays ", 1.4F, " 21.04.2023 ", 1));
            MyList.Add(new Product(Guid.NewGuid(), "Dewdrop ", 3231897812, "MY ", 0.5F, " 21.01.2023 ", 1));
            MyList.Add(new Product(Guid.NewGuid(), "Chips ", 34316319, "Chitos ", 0.9F, " 15.11.2022 ", 1));
            MyList.Add(new Product(Guid.NewGuid(), "Chips ", 38642312, "Onega ", 1.1F, " 11.02.2023 ", 2));
            MyList.Add(new Product(Guid.NewGuid(), "Popcorn ", 3231287912, "BUM ", 0.9F, " 11.01.2024 ", 1));
            MyList.Add(new Product(Guid.NewGuid(), "Dumplings ", 323123902, "FRING", 2.8F, " 01.01.2184 ", 1));
            MyList.Add(new Product(Guid.NewGuid(), "Cola ", 32334792, "Coca Kola ", 0.9F, " 11.09.2023 ", 3));
            MyList.Add(new Product(Guid.NewGuid(), "Sprite ", 398657312, "Coca Kola ", 0.8F, " 11.09.2023 ", 3));
            MyList.Add(new Product(Guid.NewGuid(), "Fanta ", 328792312, "Coca Kola ", 1.4F, " 11.09.2023 ", 5));
            MyList.Add(new Product(Guid.NewGuid(), "Bonaqua", 32312432, "Water228 ", 0.8F, " 01.01.2024 ", 2));

            Product.PrintNameIf(MyList, "Chips ");

            Product.PrintPriceIf(MyList, "Chips ", 1.3F);

            Product.PriceOverHungred(MyList);

            Product.BestItem(MyList);

            Product.OrderItem(MyList);

            var MyListTest = new List<string>
            {
                "Alex",
                "Vasia",
                "Ludaed",
                "Stepan",
                "Sergey",
                "Arseniy",
                "Alexsandr"
            };

            var newList = MyListTest.Aggregate("Arseniy", (x, y) => x.Length > y.Length ? x : y).OrderBy(x => x).Select(x => $":  {x}").GroupBy(g => g).First();
        }
    }
}
