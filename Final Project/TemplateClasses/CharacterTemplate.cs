namespace Final_Project.TemplateClasses
{
    public class CharacterTemplate : LifeformTemplate
    {
        private string _Alignment;
        private string _Species;
        public CharacterTemplate()//default constructor
        {
            this.Name = "";
            _Alignment = "";
            _Species = "";
            this.HealthPoints = getHealth();
        }

        public CharacterTemplate(string Name, string Alignment, string Species, double healthPoints, double strength)//non-default constructor
        {
            this.Name = Name;
            _Alignment = Alignment;
            _Species = Species;
            this.HealthPoints = healthPoints;
            this.Strength = strength;
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

        public override string ToString()
        {
            return "Character*" + this.Name + "*" + _Alignment + "*" +;
        }
    }
}