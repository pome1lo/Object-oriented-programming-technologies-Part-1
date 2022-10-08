
namespace lab04
{
    class Program
    {

        static void Main(string[] args)
        {
           
            Bookkeeping test = new Bookkeeping();

            test.Log();


            test.Print();
            test.AddItem(new Organization());

            test.AddItem(new Receipt());
            test.AddItem(new Receipt());

            test.AddItem(new Invoice());
            test.AddItem(new Invoice());

            test.Print();

            test.SumPrice();
            test.SumPrice();
        }
    }
}
