using System;

namespace lab04
{
    // Дата
    class Date
    {
        public DateTime TimeDate = DateTime.Now;

        public virtual void PrintObj(object obj) { }

        public override string ToString()
        {
            return $"Classes Date (Date)\n" +
                       $"Class fields: \n" +
                           $"• TimeDate - Date\n";
        }
    }
}
