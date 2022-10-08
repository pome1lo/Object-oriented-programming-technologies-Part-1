using System;

namespace lab04
{
    class Receipt : Document
    {
        public Receipt()
        {
            TypeOfPayment = "No information available";
            PaymentAmount = 0;
        }
        public Receipt(string TypeOfPayment, DateTime PaymentDate, decimal PaymentAmount)
        {
            this.TypeOfPayment = TypeOfPayment;
            this.PaymentAmount = PaymentAmount;
            this.PaymentDate = PaymentDate;
        }
        private string TypeOfPayment; 
        public string PropTypeOfPayment
        {
            get { return TypeOfPayment; }
            set { TypeOfPayment = value; }
        }

        private DateTime PaymentDate; 
        public DateTime PropPaymentDate
        {
            get { return PaymentDate; }
            set { PaymentDate = value; }
        }

        private decimal PaymentAmount;
        public decimal PropPaymentAmount
        {
            get { return PaymentAmount; }
            set { PaymentAmount = value; }
        }

        public override string ToString()
        {
            return $"Receipt class (Receipt)\n" +
                        $" Classaa fields: \n"+
                            $"• TypeOfPayment - type of payment;\n" +
                                $"• PaymentDate - payment date\n" +
                                    $"• PaymentAmount - payment amount\n" +
                                        $"Inherited fields:\n" +
                                            $"• NumberOfDuplicates - number of copies (Document class)\n" +
                                                $"• Classification - type (Document class | constant field)\n" +
                                                    $"• TimeDate - date (Date class)\n";
        }
    }
}
