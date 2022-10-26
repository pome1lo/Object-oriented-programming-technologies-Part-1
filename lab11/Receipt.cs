using System;
using System.Collections;

namespace Lab11
{
    // Квитанция
    class Receipt : IEquatable<Receipt>, ICloneable, IEnumerator, IEnumerable
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

        public object Current => throw new NotImplementedException();

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

                temp = new Receipt(TypeOfPayment, DateTime.Now, PaymentAmount);
                return temp;
            }
            else
            {
                return 0;
            }
        }

        public void PrintObj(object obj)
        {
            var tempRec = obj as Receipt;
            if (tempRec.PaymentAmount == 0 || tempRec.PaymentDate == null || tempRec.TypeOfPayment == null)
            {
                Console.WriteLine("There is no data in the fields, they need to be entered.");
                tempRec = WriteElement(tempRec) as Receipt;
            }
            Console.WriteLine($"\nType of payment\t: {tempRec.TypeOfPayment}\n" +
                              $"Payment amount\t: {tempRec.PaymentAmount} $\n" +
                              $"Payment date\t: {tempRec.PaymentDate}\n" +
                              $"\n");
        }
        public void Reset() => throw new NotImplementedException();
        public object Clone() => throw new NotImplementedException();
        public bool MoveNext() => throw new NotImplementedException();
        public bool Equals(Receipt other) => throw new NotImplementedException();
        public IEnumerator GetEnumerator() => throw new NotImplementedException();
    }
}
