
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

        
        public virtual void PrintObj(object obj) { }

        public override string ToString()
        {
            return $"Class Document\n" +
                   $"Class Fields: \n" +
                   $"• NumberOfDuplicates - number of copies\n" +
                   $"• Classification - type (Document class | constant field)\n" +
                   $"Inherited fields:\n" +
                   $"• TimeDate - date (class Date)\n";
        }
    }
}
