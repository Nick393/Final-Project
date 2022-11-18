namespace Final_Project.TemplateClasses
{
    public class CharacterTemplate : NameList
    {

        private string _Name;
        private string _Alignment;
        private string _Species;
        public CharacterTemplate()//default constructor
        {
            _Name = "";
            _Alignment = "";
            _Species = "";
        }

        public CharacterTemplate(string Name, string Alignment, string Species)//non-default constructor
        {
            _Name = Name;
            _Alignment = Alignment;
            _Species = Race;
        }
        public string Name//gets and sets
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Species
        {
            get { return _Species; }
            set { _Species = value; }
        }
        public string Alignment
        {
            get { return _Alignment; }
            set { _Alignment = value; }
        }
    }
}