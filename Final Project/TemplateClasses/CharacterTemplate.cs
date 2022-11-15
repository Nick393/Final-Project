namespace Final_Project.TemplateClasses
{
    public class CharacterTemplate : NameList
    {

        private string name;

        public string getName()
        {
            return name;
        }

        public void setName(string newName)
        {
            name = newName;
        }
        public CharacterTemplate()
        {
            name = "";
        }
    }
}