using System;

namespace Final_Project.TemplateClasses
{
    public class MonsterTemplate : LifeformTemplate
    {
        private string _Species;
        Random rand = new Random();

        public MonsterTemplate()
        {
            this.Name = "";
            _Species = "";
            this.HealthPoints = 0;
            this.Strength = 0;
        }
        public MonsterTemplate(string name, string species, double strengthValue, double health)
        {
            this.Name = name;
            this.Species = species;
            double multiplier = 1;
            this.HealthPoints = health;
            int variable = rand.Next(0, 12 );
            variable = variable - (variable / 2 - 1);
            int variable2 = rand.Next(0, 12);
            variable2 = variable2 - (variable2 / 2 - 1);
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
            this.HealthPoints = health * multiplier + variable;
            this.Strength = strengthValue * multiplier + variable2;
        }

        public MonsterTemplate(string name, string species, double strengthValue, int gameStage, double nicksMultiplier)
        {
            this.Name = name;
            this.Species = species;
            double multiplier = 1;
            int variable = rand.Next(0, (11* (gameStage+1)) + 1);
            variable = variable - (variable / 2 - 1);
            int variable2 = rand.Next(0, (11 * (gameStage + 1)) + 1);
            variable2 = variable2 - (variable2 / 2 - 1);
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
            this.HealthPoints = health * multiplier * nicksMultiplier + variable;
            this.Strength = strength * multiplier * nicksMultiplier + variable2;
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
        public string cheat()
        {
            return "monster " + HealthPoints + " " + Name + " " + Strength + " " + Species;
        }


    }
}
