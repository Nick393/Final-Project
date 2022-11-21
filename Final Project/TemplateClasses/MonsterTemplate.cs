namespace Final_Project.TemplateClasses
{
    class MonsterTemplate : LifeformTemplate
    {
        private string _Species;

        public MonsterTemplate()
        {
            this.Name = "";
            _Species = "";
            this.HealthPoints = 0;
            this.Strength = 0;
        }

        public MonsterTemplate(string name, string species)
        {
            this.Name = name;
            this.Species = species;
            string speciesStrength = runStrength(species);
            double multiplier = 1;
            switch (speciesStrength)
            {
                case ("BOSS"):
                    multiplier = 4;
                    break;
                case ("STRONG"):
                    multiplier = 2;
                    break;
                case ("MEDIUM"):
                    multiplier = 1;
                    break;
                case ("WEAK"):
                    multiplier = 0.5;
                    break;
                default:
                    multiplier = 1;
                    break;
            }
            this.HealthPoints = getHealth() * multiplier;
            this.Strength = getStrength() * multiplier;
        }
        public string Species
        {
            get { return _Species; }
            set { _Species = value; }
        }
        public override string ToString()
        {
            return "Monster*" + this.Name + "*" + _Species;
        }

        //there is almost certainly a better way to do this, temporary code
        public string runStrength(string species)
        {
            if((species.ToUpper() == "GOD") || (species.ToUpper() == "DEMON"))
            {
                return "BOSS";
        }else if ((species.ToUpper() == "DRAGON") || (species.ToUpper() == "PHOENIX"))
            {
                return "STRONG";
            } else if ((species.ToUpper() == "WYRM") || (species.ToUpper() == "TIGER"))
            {
                return "MEDIUM";
            } else ((species.ToUpper() == "COW") || (species.ToUpper() == "PIG")) {
                return "WEAK";
            }
        }
    }
}
