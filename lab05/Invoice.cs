using System;

namespace lab04
{
    class Invoice : Date
    {
        public Invoice()
        {
            index++;
        }
        public Invoice(string ProductName, decimal Price)
        {
            this.ProductName = ProductName;
            this.Price = Price;
            this.Quanity = index;
        }

        private static uint index;
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

        public DateTime PropTimeDate = DateTime.Today;

        public override string ToString()
        {
            return $"Invoice class (Invoice)\n" +
                        $"Class fields: \n" +
                            $"• ProductName - product name\n" +
                                $"• Quantity - quantity\n" +
                                    $"• Price - price" +
                                        $"Inherited fields:\n" +
                                            $"• TimeDate - date (Date class)\n";
        }
    }
}
