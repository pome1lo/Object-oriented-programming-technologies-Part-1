using System;

namespace lab_03_list
{
    partial class List<T>
    {
        public class Developer
        {
            public Developer()
            {

            }
            public Developer(string FIO, Guid id, string Department)
            {
                this.FIO = FIO;
                this.id = id;
                this.Department = Department;
            }

            private string FIO { get; set; }
            private string Department { get; set; }
            private Guid id { get; set; }
        }

        public static void Foo<Production>(Production Prod)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Prod + "\n");
            Console.ResetColor();
        }
        public static class StatisticOperation
        {
            public static void Sum(List<T> List1, List<T> List2)
            {
                Console.WriteLine($"Сумма элементов первого и второго списка равна {List1.Lenght + List2.Lenght}");
            }
            public static void DifferenceMaxMin(List<T> List1, List<T> List2)
            {
                int res = List2.Lenght - List1.Lenght;
                if (res < 0)
                {
                    res = -res;
                }
                Console.WriteLine($"Разница в размере первого и второго списка равна {res}");
            }
            public static void Quanity(List<T> MyList)
            {
                Console.WriteLine($"Количество элементов в списке равно {MyList.Lenght}");
            }
        }
    }
    public class Production
    {
        public Production()
        {

        }
        public Production(Guid id, string NameOrg)
        {
            this.id = id;
            this.NameOrg = NameOrg;
        }

        private Guid id { get; set; }
        private string NameOrg { get; set; }
    }
}
