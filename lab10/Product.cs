using System;
using System.Collections.Generic;
using System.Linq;

namespace lab02
{
    partial class Product
    {
        public Product()
        {
            Name = "No information available.";
            UPC = 0;
            Producer = "No information available.";
            Price = 0;
            ShelfLife = "No information available.";
            Quanity = 0;

            Index++;
        }
        public Product(Guid Id)
        {
            this.Id = Id;
            Name = "No information available.";
            UPC = 0;
            Producer = "No information available.";
            Price = 0;
            ShelfLife = "No information available.";
            Quanity = 0;

            Index++;
        }
        static Product()
        {
            Index = 0;
        }
        public Product(Guid Id, string Name, uint UPC, string Producer, float Price, string ShelfLife, int Quanity)
        {
            this.Id = Id;
            this.Name = Name;
            this.UPC = UPC;
            this.Producer = Producer;
            this.Price = Price;
            this.ShelfLife = ShelfLife;
            this.Quanity = Quanity;

            Index++;
        }

        static int Index { get; set; }

        private Guid Id { get; }
        private string Name;
        private uint UPC;
        private string Producer;
        private float Price;
        private string ShelfLife;
        private int Quanity;
        private const string TypeProduct = "Meal";




        public string PropName
        {
            get { return Name; }
            set { Name = value; }
        }
        public uint PropUPC
        {
            get { return UPC; }
            set { UPC = value; }
        }
        public string PropProducer
        {
            get { return Producer; }
            set { Producer = value; }
        }
        public float PropPrice
        {
            get { return Price; }
            set { Price = value; }
        }
        public string PropShelfLife
        {
            get { return ShelfLife; }
            set { ShelfLife = value; }
        }
        public int PropQuanity
        {
            get { return Quanity; }
            set { Quanity = value; }
        }




        /// <summary>
        /// Printing a list item
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Id:\t\t{Id}\n" +
                              $"Name:\t{Name}\n" +
                              $"UPC:\t\t{UPC}\n" +
                              $"Product Type: \t{TypeProduct} \n" +
                              $"Manufacturer:\t{Producer}\n" +
                              $"Price:\t\t{Price} $\n" +
                              $"Expiration date:\t{ShelfLife}\n" +
                              $"Quantity:\t{Quanity}\n");
        }
        /// <summary>
        /// Printing the entire list of the list
        /// </summary>
        /// <param name="List"></param>
        public static void PrintList(ref Product[] List)
        {
            for (int i = 0; i < List.Length; i++)
            {
                Console.WriteLine($"{i + 1} position in the list:\n");
                List[i].Print();
            }
        }
        /// <summary>
        /// Entering the list manually
        /// </summary>
        /// <param name="List"></param>
        /// <returns></returns>
        public static Product[] WriteListElement(ref Product[] List)
        {
            for (int i = 0; i < List.Length; i++)
            {
                Guid id = Guid.NewGuid();

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("UPC product: ");
                uint upc = uint.Parse(Console.ReadLine());

                Console.Write("Product Type: ");
                string producer = Console.ReadLine();

                Console.Write("Product price: ");
                float price = float.Parse(Console.ReadLine());

                Console.Write("Expiration date: ");
                string shelfLife = Console.ReadLine();

                Console.Write("Quanity: ");
                int quanity = int.Parse(Console.ReadLine());

                List[i] = new Product(id, name, upc, producer, price, shelfLife, quanity);
                Console.WriteLine();
            }
            return List;
        }
        /// <summary>
        /// Method describing the class
        /// </summary>
        public static void QuanityObject()
        {
            Console.WriteLine($"\nClass Product\nClass name: Product();\nCreated instances: {Index};\n"); ;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            Product temp = obj as Product;

            return temp.Name == this.Name;
        }
        public override string ToString()
        {
            return String.Concat(Name, Producer, Price + " $", ShelfLife);
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + Name.GetHashCode();
            hash = hash * 31 + Price.GetHashCode();
            hash = hash * 31 + Quanity.GetHashCode();
            return hash;
        }






        
        public static void PrintNameIf(List<Product> List, string str)
        {
            var newList = List.Where(x => x.Name == str);
            Console.WriteLine('\n' + string.Join(Environment.NewLine, newList));
        }
        public static void PrintPriceIf(List<Product> MyList, string Str, float Price)
        {
            var newList = MyList.Where(x => x.Name == Str && x.Price < Price);
            Console.WriteLine('\n' + string.Join(Environment.NewLine, newList));
        }
        public static void PriceOverHungred(List<Product> MyList)
        {
            var newList = MyList.Where(x => x.Price > 1F);
            Console.WriteLine('\n' + string.Join(Environment.NewLine, "The number of items whose price is more than 100 ( or $ 1 ):" + newList.Count()));
        }
        public static void BestItem(List<Product> MyList)
        {
            var newList = MyList.OrderByDescending(x => x.Price);
            Console.WriteLine('\n' + string.Join(Environment.NewLine, "Product with max. price: " + newList.First()));
        }

        public static void OrderItem(List<Product> MyList)
        {
            var newList1 = MyList.OrderByDescending(x => x.Producer);
            Console.WriteLine("\nOrdered set of products by manufacturer:\n" + string.Join(Environment.NewLine, newList1));

            var newList2 = MyList.OrderBy(x => x.PropQuanity);
            Console.WriteLine("\nOrdered set of products by quantity: \n" + string.Join(Environment.NewLine, newList2));
        }
    }
}
