using System;

namespace lab02
{
    partial class Product
    {
        public void Print()
        {
            Console.WriteLine($"Id:\t\t{Id}\n" +
                                $"Name:\t{Name}\n" +
                                    $"UPC:\t\t{UPC}\n" +
                                        $"Product type: \t{TypeProduct} \n" +
                                            $"Manufacturer:\t{Producer}\n" +
                                                $"Price:\t\t{Price} $\n" +
                                                    $"Expiration date:\t{ShelfLife}\n" +
                                                        $"Quantity:\t{Quanity}\n");
        }
        public static void PrintList(ref Product[] List)
        {
            for (int i = 0; i < List.Length; i++)
            {
                Console.WriteLine($"{i + 1}-st position in the list:\n");
                List[i].Print();
            }
        }
        public static void PrintNameIf(Product[] List)
        {
            int check = 0;

            Console.Write("Set the name for the list output: ");
            string nameIf = Console.ReadLine();

            for (int i = 0; i < List.Length; i++)
            {
                if (List[i].Name == nameIf)
                {
                    Console.WriteLine($"{i + 1}-th position in the list of the name you specified ({nameIf}):\n");
                    List[i].Print();
                    check++;
                }
            }
            if (check == 0)
            {
                Console.WriteLine("\nThere are no products with the name you specified..");
            }
        }
        public static void PrintPriceIf(Product[] List)
        {
            int check = 0;

            Console.Write("Set the name for the list output:");
            string nameIf = Console.ReadLine();

            Console.Write("The price limit for the withdrawal of goods:");
            float priceIf = float.Parse(Console.ReadLine());

            for (int i = 0; i < List.Length; i++)
            {
                if (List[i].Name == nameIf)
                {
                    if (List[i].Price <= priceIf)
                    {
                        Console.WriteLine($"{i + 1}-nd the position in the list of the name you specified ({nameIf}) and the price not exceeding {priceIf} $:\n");
                        List[i].Print();
                        check++;
                    }
                }
            }
            if (check == 0)
            {
                Console.WriteLine("\nThere are no products with the name or price limit you specified..");
            }
        }
        public static Product[] WriteListElement(ref Product[] List)
        {
            for (int i = 0; i < List.Length; i++)
            {
                Guid id = Guid.NewGuid();

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("UPC product: ");
                uint upc = uint.Parse(Console.ReadLine());

                Console.Write("Producer: ");
                string producer = Console.ReadLine();

                Console.Write("Product price: ");
                float price = float.Parse(Console.ReadLine());

                Console.Write("Product helfLife: ");
                string shelfLife = Console.ReadLine();

                Console.Write("Quanity: ");
                int quanity = int.Parse(Console.ReadLine());

                List[i] = new Product(id, name, upc, producer, price, shelfLife, quanity);
                Console.WriteLine();
            }
            return List;
        }
        public static void QuanityObject()
        {
            Console.WriteLine($"\nClass Product\nClass name: Product();\ncreated instances:{Index};\n"); ;
        }
        
        //
        
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
            int hash = 17; // 17 arbitrary prime number
            hash = hash * 31 + Name.GetHashCode();
            hash = hash * 31 + Price.GetHashCode();
            hash = hash * 31 + Quanity.GetHashCode();
            return hash;
        }
    }
}
