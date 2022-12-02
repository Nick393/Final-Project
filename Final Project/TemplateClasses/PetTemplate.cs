namespace Final_Project.TemplateClasses
{
    public class PetTemplate : MonsterTemplate
    {
        private CharacterTemplate _Owner;
        public PetTemplate()
        {
            Name = "";
            Species = "";
            HealthPoints = 0;
            Strength = 0;
            _Owner = new CharacterTemplate();
        }

        public PetTemplate(MonsterTemplate oldForm, CharacterTemplate Owner)
        {
            this.Name = oldForm.Name;
            this.Species = oldForm.Species;
            this.HealthPoints = oldForm.HealthPoints;
            this.Strength = oldForm.Strength;
            _Owner = Owner;
        }
        public PetTemplate(string name, string species, int strengthValue, int gameStage, CharacterTemplate owner)
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
            double health = 0;
            double strength = 0;
            determineDefault(gameStage, ref health, ref strength);
            this.HealthPoints = health * multiplier;
            this.Strength = strength * multiplier;
            _Owner = owner;
        }
    }
}
