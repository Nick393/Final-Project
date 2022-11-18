namespace Final_Project.TemplateClasses
{
    public class CharacterTemplate : NameList
    {

        private string _Name;
        private string _Alignment;
        private string _Race;
        public CharacterTemplate()//default constructor
        {
            _Name = "";
            _Alignment = "";
            _Race = "";
        }

        public CharacterTemplate(string Name, string Alignment, string Race)//non-default constructor
        {
            _Name = Name;
            _Alignment = Alignment;
            _Race = Race;
        }
        public string Name//gets and sets
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Race
        {
            get { return _Race; }
            set { _Race = value; }
        }
        public string Alignment
        {
            get { return _Alignment; }
            set { _Alignment = value; }
        }
    }
}