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
            this.HealthPoints = 0;
            this.Strength = 0;
        }

        public CharacterTemplate(string Name, string Alignment, string Species, int strengthValue, int gameStage)//non-default constructor, makes enemy NPC characters
        {
            this.Name = Name;
            _Alignment = Alignment;
            _Species = Species;
            double multiplier;
            switch (strengthValue)
            {
                case 3:
                    multiplier = 4;
                    break;
                case 2:
                    multiplier = 2;
                    break;
                case 1:
                    multiplier = 1;
                    break;
                case 0:
                    multiplier = 0.5;
                    break;
                default:
                    multiplier = 1;
                    break;
            }
            double health = 0;
            double strength = 0;
            determineDefault(gameStage, ref health, ref strength);
            this.HealthPoints = health * multiplier;
            this.Strength = strength * multiplier;
        }
        public CharacterTemplate(string Name, string Alignment, string Species, int gameStage)//non-default constructor, makes friendly NPC Characters
        {
            this.Name = Name;
            _Alignment = Alignment;
            _Species = Species;
            double health = 0;
            double strength = 0;
            determineDefault(gameStage, ref health, ref strength);
            this.HealthPoints = health;
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
            return "Character*" + this.Name + "*" + _Alignment + "*" ;
        }
    }
}