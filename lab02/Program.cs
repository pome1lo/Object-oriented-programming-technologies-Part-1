using System;

namespace lab02
{
    public partial class Product
    {
        public Product()
        {
            Name = "There is no information.";
            UPC = 0;
            Producer = "There is no information.";
            Price = 0;
            ShelfLife = "There is no information.";
            Quanity = 0;

            Index++;
        }
        public Product(Guid Id)
        {
            this.Id = Id;
            Name = "There is no information.";
            UPC = 0;
            Producer = "There is no information.";
            Price = 0;
            ShelfLife = "There is no information.";
            Quanity = 0;

            Index++;
        }
        static Product()
        {
            Index = 0;
        }
        private Product(Guid Id, string Name, uint UPC, string Producer, float Price, string ShelfLife, int Quanity)
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
        private string Name { get; set; }
        private uint UPC { get; set; }
        private string Producer { get; set; }
        private float Price { get; set; }
        private string ShelfLife { get; set; }
        private int Quanity { get; set; }
        private const string TypeProduct = "Yeat";



        class Partial 
        {
            public class MyPartialClass
            {
                public void Info()
                {
                    Console.WriteLine("MyPartialClass class in MyPartial");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the size of the list of products: ");
            int SIZE = int.Parse(Console.ReadLine());

            Product[] ListProducts = new Product[SIZE];

            bool check = true;
            do
            {
                Console.WriteLine("\nChoose what you want to do:\n" +
                                "1 => Enter the list manually \n" +
                                    "2 => Display the entire list of products \n" +
                                        "3 => Display a list of products for a given name \n" +
                                            "4 => a list of products for a given name, the price of which does not exceed the specified; \n" +
                                                "5 => Checking redefined methods; \n" +
                                                    "6 => Class information; \n" +
                                                        "7 => exiting the program;\n");

                int choise = int.Parse(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        {
                            Product.WriteListElement(ref ListProducts);
                            break;
                        }
                    case 2:
                        {
                            Product.PrintList(ref ListProducts);
                            break;
                        }
                    case 3:
                        {
                            Product.PrintNameIf(ListProducts);
                            break;
                        }
                    case 4:
                        {
                            Product.PrintPriceIf(ListProducts);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Equals() method: result \t| " + ListProducts[1].Equals(ListProducts[0]));
                            Console.WriteLine("GetHashCode() method: result  | " + ListProducts[1].GetHashCode());
                            Console.WriteLine("ToString() method: result\t| " + ListProducts[0].ToString());

                            Console.WriteLine("Anonymous type: ");
                            var crisp = new Product(Guid.NewGuid());
                            crisp.Print();

                            Console.WriteLine("Constructor with default parameters: \n");
                            Product test = new Product();
                            test.Print();
                            break;
                        }
                    case 6:
                        {
                            Product.QuanityObject();
                            break;
                        }
                    case 7:
                        {
                            check = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("You did something wrong. Choose one of the suggested options..");
                            break;
                        }
                }
            } while (check);
        }
    }
}