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
                Console.WriteLine($"The sum of the elements of the first and second list is equal to {List1.Lenght + List2.Lenght}");
            }
            public static void DifferenceMaxMin(List<T> List1, List<T> List2)
            {
                int res = List2.Lenght - List1.Lenght;
                if (res < 0)
                {
                    res = -res;
                }
                Console.WriteLine($"The difference in the size of the first and second list is equal to {res}");
            }
            public static void Quanity(List<T> MyList)
            {
                Console.WriteLine($"The number of items in the list is equal to {MyList.Lenght}");
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
