using System;

namespace lab04
{
    class Сheque
    {
        private Guid Id; 
        public Сheque()
        {

        }
        public Сheque(decimal TotalAmount)
        {
            this.Id = Guid.NewGuid();
            this.TotalAmount = TotalAmount;
        }
        public Guid PropId
        {
            get { return Guid.NewGuid(); }
            set { Id = value; }
        }

        private decimal TotalAmount;
        public decimal PropTotalAmount
        {
            get { return TotalAmount; }
            set { TotalAmount = value; }
        }


        public override string ToString()
        {
            return $"Class: Cheque\n" +
                        $"Class fields:\n" +
                            $"Id - unique id" +
                                $"Total Amount -the total amount"+
                                    $" of inherited fields because the sealed modifier is used";

        }
    }
}
