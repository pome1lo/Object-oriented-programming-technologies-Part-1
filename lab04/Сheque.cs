using System;

namespace lab04
{
    sealed class Сheque
    {
        private Guid Id; 
        public Guid PropId
        {
            get { return Id; }
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
            return $"Класс: Cheque\n" +
                        $"Class Fields:\n" +
                            $"Id - unique id" +
                                $"Total Amount -the total amount"+
                                    $" of inherited fields because the sealed modifier is used";

        }
    }
}
