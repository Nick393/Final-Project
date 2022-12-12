using System;
using System.Collections.Generic;
using System.IO;

namespace Final_Project.TemplateClasses
{
    public class CharacterTemplate : LifeformTemplate
    {
        private string _Alignment;
        private string _Species;
        private int _numMedkits;
        private int _Score;
        private int _highScore;
        private int _numRounds;
        Random rand = new Random();
        private List<PetTemplate> _Pets = new List<PetTemplate>();
        public CharacterTemplate()//default constructor
        {
            _numRounds = 0;
            this.Name = "";
            _Score = 0;
            _Alignment = "";
            _Species = "";
            this.HealthPoints = 0;
            this.Strength = 0;
            this.numMedkits = 0;
            StreamReader r = new StreamReader("highScore.json");
            int score = int.Parse(r.ReadLine());
            this._highScore = score;
            r.Close();


        }

        public CharacterTemplate(string Name, string Alignment, string Species, int strengthValue, int gameStage, double nicksMultiplier)//non-default constructor, makes enemy NPC characters
        {
            _numRounds = 0;
            this.Name = Name;
            _Alignment = Alignment;
            _Species = Species;
            //_Score = 0;
            //slightly varies enemy health so all the values aren't the same
            int variable = rand.Next(0, (11 * (gameStage + 1)) + 1);
            variable = variable - (variable / 2 - 1);
            int variable2 = rand.Next(0, (11 * (gameStage + 1)) + 1);
            variable2 = variable2 - (variable2 / 2 - 1);
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
            this.HealthPoints = health * multiplier * nicksMultiplier + variable;
            this.Strength = strength * multiplier * nicksMultiplier + variable2;
            this.numMedkits = 0;
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
            this.numMedkits = 0;
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
        public int score
        {
            get { return _Score; }
            set { _Score = value; }
        }
        public List<PetTemplate> Pets
        {
            get { return _Pets; }
            set { _Pets = value; }
        }
        public int numMedkits
        {
            get { return _numMedkits; }
            set { _numMedkits = value; }
        }
        public int numRounds
        {
            get { return _numRounds; }
            set { _numRounds = value; }
        }

        /*public void addPets(MonsterTemplate newPet)
        {

        }*/
        public void updateHealth(int gameStage)
        {
            int newStage = gameStage - 1;
            double health = 15;
            int strength = 20;
            switch (newStage)
            {
                case 0:
                    health = 15;
                    strength = 20;
                    break;
                case 1:
                    health = 22.5;
                    strength = 30;
                    break;
                case 2:
                    health = 30;
                    strength = 40;
                    break;
                case 3:
                    health = 37.5;
                    strength = 50;
                    break;
                case 4:
                    health = 45;
                    strength = 60;
                    break;
                case 5:
                    health = 52.5;
                    strength = 70;
                    break;
                case 6:
                    health = 60;
                    strength = 80;
                    break;
                default:
                    health = 60;
                    strength = 80;
                    break;
            }
            this.Strength = strength * 2;
            this.HealthPoints = health * 2;
            foreach (PetTemplate pet in Pets)
            {
                if (pet != null)
                {
                    if (pet.Strength <= strength)
                    {
                        pet.Strength = strength;
                        pet.HealthPoints = health;
                    }
                    else if (pet.HealthPoints <= health)
                    {
                        pet.HealthPoints = health;
                    }
                }
            }
        }
        public override string ToString()
        {
            return "Character*" + this.Name + " " + _Alignment + " " + HealthPoints;
        }
        public string cheat()
        {
            CharacterTemplate blan = new CharacterTemplate();
            PetTemplate pet = new PetTemplate("test", "dragon", 100, 1, blan);
            this.Pets.Add(pet);
            Console.WriteLine(pet.ToString());
            return "Character " + this.Name + " " + _Alignment + " " + HealthPoints + " " + Strength;
        }
    }
}