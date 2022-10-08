using System;

namespace lab04
{
    class Organization : Document, IWriteEl
    {
        public Organization()
        {
            Name = "There is no information.";
            Activity = "There is no information.";
            Index++;
        }
        public Organization(string Name, string Activity)
        {
            this.Name = Name;
            this.Activity = Activity;
        }

        private string Name; 
        public string PropName
        {
            get { return Name; }
            set { Name = value; }
        }

        private string Activity; 
        public string PropActivity
        {
            get { return Activity; }
            set { Activity = value; }
        }

        static int Index { get; set;}

        public object WriteElement(object obj)
        {
            var temp = obj as Organization;
            if (temp != null)
            {
                Console.Write("Enter the name of the organization: ");
                string Name = Console.ReadLine();
                Console.Write("Enter the type of activity of the organization: ");
                string Activity = Console.ReadLine();

                temp = new Organization(Name, Activity);
                return temp;
            }
            else
            {
                return 0;
            }
        }

        public override void PrintObj(object obj)
        {
            var tempOrg = obj as Organization;
            if(tempOrg.Activity == null && tempOrg.Name == null)
            {
                Console.WriteLine("There is no data in the fields, they need to be entered.");
                tempOrg = WriteElement(tempOrg) as Organization;
            }
            Console.WriteLine($"Organization name: {tempOrg.Name}\n Type of activity: {tempOrg.Activity}");
        }

        public override string ToString()
        {
            return $"Class Organization\n" +
                        $"Classaa fields: \n" +
                            $"• Name - organization name\n" +
                                $"• Activity - activity\n" +
                                    $"Inherited fields:\n" +
                                        $"• NumberOfDuplicates - number of copies (Document class)\n" +
                                            $"• Classification - type (Document class | constant field)\n" +
                                                $"• TimeDate - date (Date class)\n";
        }
    }
}
