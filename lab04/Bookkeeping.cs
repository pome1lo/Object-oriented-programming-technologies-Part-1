using System;
using System.Collections.Generic;
using System.IO;

namespace lab04
{
    class Bookkeeping 
    {
        public Bookkeeping()
        {
            ListRec = new List<Receipt>();
            ListOrg = new List<Organization>();
            ListInv = new List<Invoice>();
            ListChq = new List<Сheque>();
        }

        private List<Receipt> ListRec { get; set; }
        private List<Organization> ListOrg { get; set; }
        private List<Invoice> ListInv { get; set; }
        private List<Сheque> ListChq { get; set; }

        private static string path = "\\Log.txt";
        
        public void AddItem(Object obj)
        {
            if (obj is Receipt)
            {
                ListRec.Add((Receipt)Container.WriteElement(new Receipt()));
            }
            else if (obj is Organization)
            {
                ListOrg.Add((Organization)Container.WriteElement(new Organization()));
            }
            else if (obj is Invoice)
            {
                ListInv.Add((Invoice)Container.WriteElement(new Invoice()));    
                ListChq.Add((Сheque)Container.WriteElement(new Сheque()));
            }
        }

        public void RemoveItem(Object obj, int index = 0)
        {
            if(obj is Receipt)
            {
                ListRec.RemoveAt(index);
            } else if (obj is Organization)
            {
                ListOrg.RemoveAt(index);
            } else if (obj is Invoice)
            {
                ListInv.RemoveAt(index);
                ListChq.RemoveAt(index);
            }
        }
        public void Print()
        {
            Console.WriteLine("\n========================================================Print===========================================================");
            for (int i = 0; i < ListInv.Count; i++)
            {
                Container.PrintObj(ListInv[i]);
                Container.PrintObj(ListChq[i]);
            }
            for (int i = 0; i < ListRec.Count; i++)
            {
                Container.PrintObj(ListRec[i]);
            }
            for (int i = 0; i < ListOrg.Count; i++)
            {
                Container.PrintObj(ListOrg[i]);
            }
            Console.WriteLine();
        }

        public void Log()
        {
            string str;
            str = File.ReadAllText(path);
            Console.WriteLine(str);
            Organization test = new Organization(str, str);
            ListOrg.Add(test);
        }

        public void SumPrice()
        {
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();

            decimal sum = 0;
            int quanityCheck = 0;

            foreach (var item in ListInv)
            {
                if(name == item.PropProductName)
                {
                    sum += item.PropPrice;
                    quanityCheck++;
                }
            }
            Console.WriteLine($"The total cost of products \"{name}\" is equal to: {sum} $\number of receipts: {quanityCheck}");
        }
    }
}