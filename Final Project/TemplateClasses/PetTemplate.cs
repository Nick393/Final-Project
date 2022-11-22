namespace Final_Project.TemplateClasses
{
    class PetTemplate : MonsterTemplate
    {
        private CharacterTemplate _Owner;
        public PetTemplate(string name, string species, int strengthValue, CharacterTemplate owner)
        {
            this.Name = name;
            this.Species = species;
            double multiplier = 1;
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
            this.HealthPoints = getHealth() * multiplier;
            this.Strength = getStrength() * multiplier;
            _Owner = owner;
        }
    }
}
