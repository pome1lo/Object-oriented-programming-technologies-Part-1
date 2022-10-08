
namespace lab04
{
    abstract class Document : Date
    {
        public int NumberOfDuplicates;      

        public int PropNumberOfDuplicates
        {
            get { return NumberOfDuplicates; }
            set { NumberOfDuplicates = value; }
        }

        public const string Classification = "Organizational document";


        public override string ToString()
        {
            return $"Document class (Document)\n" +
                        $"Class fields: \n"+
                            $"• NumberOfDuplicates - number of copies\n" +
                                $"• Classification - type (Document class | constant field)\n" +
                                    $"Inherited fields:\n" +
                                        $"• TimeDate - date (Date class)\n";
        }
    }
}
