namespace Final_Project.TemplateClasses
{
    public class CharacterTemplate : NameList
    {

        private string name;
        private string alignment;

        public string getName()
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
        }

        public CharacterTemplate()
        {
            name = "";
            alignment = "Neutral";
        }
    }
}