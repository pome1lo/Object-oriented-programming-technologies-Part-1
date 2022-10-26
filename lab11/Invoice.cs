using System;
using System.Collections;

namespace Lab11
{
    class Invoice : ICloneable, IEnumerable
    {
        public void ExampleToInt32(int EXAMPLE) { }
        public void ISecondExampleToInt32(int EXAMPLE) { }
        public void OOP_TOP(int EXAMPLE) { }


        public Invoice()
        {

        }
        public Invoice(string ProductName, uint Quanity, decimal Price)
        {
            this.ProductName = ProductName;
            this.Quanity = Quanity;
            this.Price = Price;
        }


        private string ProductName; 
        public string PropProductName
        {
            get { return ProductName; }
            set { ProductName = value; }
        }

        private uint Quanity; 
        public uint PropQuanity
        {
            get { return Quanity; }
            set { Quanity = value; }
        }

        private decimal Price;
        public decimal PropPrice
        {
            get { return Price; }
            set { Price = value; }
        }


        public object WriteElement(Invoice temp)
        {
            Console.Write("Enter the product names: ");
            string ProductName = Console.ReadLine();

            Console.Write("Enter the quantity of the product: ");
            uint Activity = uint.Parse(Console.ReadLine());

            Console.Write("Enter the product price: ");
            decimal Price = decimal.Parse(Console.ReadLine());

            temp = new Invoice(ProductName, Quanity, Price);
            return temp;
        }

        public void PrintObj(object obj)
        {
            var tempInv = obj as Invoice;
            if (tempInv.ProductName == null || tempInv.Quanity == 0 || tempInv.Price == 0)
            {
                Console.WriteLine("There is no data in the fields, they need to be entered.");
                tempInv = WriteElement(tempInv) as Invoice;
            }
            Console.WriteLine($"Product names: {tempInv.ProductName}\nQuantity of goods: {tempInv.Quanity}\nProduct price: {tempInv.Price} $");
        }
        public override bool Equals(object obj)
        {
            var item = obj as Invoice;
            if (PropProductName == item.ProductName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            int hash = 17; 
            hash = hash * 31 + ProductName.GetHashCode();
            hash = hash * 31 + Price.GetHashCode();
            hash = hash * 31 + Quanity.GetHashCode();
            return hash;
        }

        public object Clone() => throw new NotImplementedException();
        public IEnumerator GetEnumerator() => throw new NotImplementedException();
}
}
