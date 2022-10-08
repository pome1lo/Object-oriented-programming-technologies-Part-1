using System;

namespace lab04
{
    class Container : Receipt
    {

        public static object WriteElement(Object obj)
        {
            if(obj is Organization)
            {
                Console.Write("\nEnter the name of the organization: ");
                string Name = Console.ReadLine();
                Console.Write("Enter the type of activity of the organization: ");
                string Activity = Console.ReadLine();

                var temp = new Organization(Name, Activity);
                return temp;
            } 
            else if (obj is Receipt)
            {
                Console.Write("\nEnter the type of payment for the receipt: ");
                string TypeOfPayment = Console.ReadLine();

                Console.Write("Enter the payment amount: \t");
                decimal PaymentAmount = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Payment date: current");

                DateTime TimeDate = DateTime.Today;

                var temp = new Receipt(TypeOfPayment, TimeDate, PaymentAmount);
                return temp;
            } 
            else if (obj is Invoice)
            {
                Console.Write("\nEnter the product names: ");
                string ProductName = Console.ReadLine();

                Console.Write("Enter the quantity of the product: ");
                uint Activity = uint.Parse(Console.ReadLine());

                Console.Write("Enter the product price: ");
                decimal Price = decimal.Parse(Console.ReadLine());

                var temp = new Invoice(ProductName, Price);
                return temp;
            } 
            else if (obj is Сheque)
            {
                Console.Write("\nEnter the total amount of the receipt:");
                decimal price = decimal.Parse(Console.ReadLine());
                var temp = new Сheque(price);
                return temp;
            }
            else
            {
                return 0;
            }
        }
        public static void PrintObj(object obj)
        {
            if(obj is Organization)
            {
                var tempOrg = obj as Organization;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("( Instance of the class Organization )");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\nOrganization name: {tempOrg.PropName}\type of activity: {tempOrg.PropActivity}");
            }
            else if(obj is Invoice)
            {
                var temp = obj as Invoice;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("( Instance of the classInoice )");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\nName of load:\t {temp.PropProductName}\ncartload: {temp.PropQuanity}\ncharge: {temp.PropPrice} $\nPDATA pickups: {temp.PropTimeDate}\n");
            }
            else if(obj is Receipt)
            {
                var temp = obj as Receipt;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n( Instance of the class Receipt )");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\nType of payment\t: {temp.PropTypeOfPayment}\nPayment amount\t: {temp.PropPaymentAmount} $\nPayment date\t: {temp.PropPaymentDate}\nNumber of copies\t: {temp.PropNumberOfDuplicates}\nDocument type\t: {Classification}\n");
            }
            else if (obj is Сheque)
            {
                var temp = obj as Сheque;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n( Instance of the class Cheque )");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\nUnique id\t: {temp.PropId}\nTotal amount\t: {temp.PropTotalAmount} $");
            }
        }
    }
}
