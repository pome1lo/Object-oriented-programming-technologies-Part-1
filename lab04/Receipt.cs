using System;

namespace lab04
{
    class Receipt : Document, IWriteEl
    {
        public Receipt()
        {
            Index++;
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

        static int Index { get; set; }

        public object WriteElement(object obj)
        {
            var temp = obj as Receipt;
            if (temp != null)
            {
                Console.Write("Enter the type of payment for the receipt: ");
                string TypeOfPayment = Console.ReadLine();

                Console.Write("Enter the payment amount: \t");
                decimal PaymentAmount = decimal.Parse(Console.ReadLine());
                
                Console.WriteLine("Payment date: current");
                DateTime Time = TimeDate;

                NumberOfDuplicates = Index;
                temp = new Receipt(TypeOfPayment, TimeDate, PaymentAmount);
                return temp;
            }
            else
            {
                return 0;
            }
        }

        public override void PrintObj(object obj)
        {
            var tempRec = obj as Receipt;
            if (tempRec.PaymentAmount == 0 || tempRec.PaymentDate == null || tempRec.TypeOfPayment == null)
            {
                Console.WriteLine("There is no data in the fields, they need to be entered.");
                tempRec = WriteElement(tempRec) as Receipt;
            }
            Console.WriteLine($"\nType of payment\t: {tempRec.TypeOfPayment}\n" +
                                  $"Payment amount\t: { tempRec.PaymentAmount} $\n"+
                                      $"Payment date\t: {tempRec.PaymentDate}\n" +
                                          $"Number of copies\t: {NumberOfDuplicates}\n" +
                                              $"Document type\t: {Classification}\n" +
                                                  $"\n");
        }

        public override string ToString()
        {
            return $"Класс Receipt (Квитанция)\n" +
                       $"Class fields: \n"+
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
