using System.IO;

namespace Lab11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reflector.Test("Lab11.Program");
            Reflector.Test("Lab11.Receipt");
            Reflector.Test("Lab11.Invoice", "System.Int32");

            string[] file = File.ReadAllLines(@"..\..\..\..\Params.txt");
            
            string FromFileClassName  = file[0];
            string FromFileMethodName = file[1];

            object[] objArr = { FromFileClassName, null };
            Reflector.Invoke(null, FromFileMethodName, objArr);

            object[] objArr2 = { "Lab11.Receipt", null };
            Reflector.Invoke(null, "Test", objArr2);

            Reflector.Generator();

            Reflector.Create<int>("System.Int32");
            Reflector.Create<char>("System.Char");
            Reflector.Create<float>("System.Single");
        }
    }

}
