using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    class Date : Сheque
    {
        enum EnumDate
        {
            DateOfReceiptDoc, 
            DateOfDispatch,   
            DateOfApproval    
        }
        struct Struct
        {
            public int Index { get; set; }
            public void CwPrint()
            {
                Console.WriteLine("I am a structure ! ☻");
            }
        }

        public DateTime TimeDate = DateTime.Today;

        public override string ToString()
        {
            return $"Class Date (Date)\n" +
                        $"Class fields: \n"+
                            $"• TimeDate - date\n";
        }
    }
}
