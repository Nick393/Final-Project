namespace Final_Project.TemplateClasses
{
    public class CharacterTemplate : NameList
    {

        private string _Name;
        private string _Alignment;

        /*public string getName()
        {
            return name;
        }

        public void setName(string newName)
        {
            name = newName;
        }

        public string getAlignment()
        {
            return alignment;
        }

        public void setAlignment(string Alignment)
        {
            alignment = Alignment;
        }*/
        public CharacterTemplate()//default constructor
        {
            _Name = "";
            _Alignment = "";
            
        }

        public CharacterTemplate(string Name, string Alignment)//non-default constructor
        {
            _Name = Name;
            _Alignment = Alignment;
            
        }
        public string name//gets and sets
        {
            get { return _Name; }
            set { _Name = value; }
        }


        public string Alignment
        {
            get { return _Alignment; }
            set { _Alignment = value; }
        }
    }
}