using System;

namespace lab04
{
    class Operation : IPrint
    {
        public static void Print(object obj)
        {
            var tempRec = obj as Receipt;
            var tempInv = obj as Invoice;
            var tempOrg = obj as Organization;

            if (tempOrg != null)
            {
                tempOrg.PrintObj(tempOrg);
            }
            else if (tempRec != null)
            {
                tempRec.PrintObj(tempRec);
            }
            else if (tempInv != null)
            {
                tempInv.PrintObj(tempInv);
            }
        }
    }
    class Printer : Invoice
    {
        public static void IAmPrinting(Object obj)
        {
            Console.WriteLine(obj.ToString());
            Console.WriteLine("========================================================================================================================");
        }
    }
}
