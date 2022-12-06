﻿namespace Final_Project.TemplateClasses
{
    public class MonsterTemplate : LifeformTemplate
    {
        private string _Species;

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
            this.HealthPoints = health * multiplier;
            this.Strength = strengthValue * multiplier;
        }

        public MonsterTemplate(string name, string species, double strengthValue, int gameStage, double nicksMultiplier)
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
            this.HealthPoints = health * multiplier * nicksMultiplier;
            this.Strength = strength * multiplier * nicksMultiplier;
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
