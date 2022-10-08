
namespace lab04
{
    class Organization : Document
    {
        public Organization()
        {
            Name = "No information available";
            Activity = "No information available";
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

        public override string ToString()
        {
            return $"Organization class\n" +
                        $" Classaa fields: \n" +
                            $"• Name - organization name\n" +
                                $"• Activity - activity\n" +
                                    $"Inherited fields:\n" +
                                        $"• NumberOfDuplicates - number of copies (Document class)\n" +
                                            $"• Classification - type (Document class | constant field)\n" +
                                                $"• TimeDate - date (Date class)\n";
        }
    }
}
