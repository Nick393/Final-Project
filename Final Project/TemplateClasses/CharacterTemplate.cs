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
        private List<PetTemplate> _Pets = new List<PetTemplate>();
        public CharacterTemplate()//default constructor
        {
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
            this.Name = Name;
            _Alignment = Alignment;
            _Species = Species;
            //_Score = 0;

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
            this.HealthPoints = health * multiplier * nicksMultiplier;
            this.Strength = strength * multiplier * nicksMultiplier;
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

        /*public void addPets(MonsterTemplate newPet)
        {

        }*/
        public void updateHealth(int gameStage)
        {
            int newStage = gameStage - 1;
            switch (newStage)
            {
                case 0:
                    this.HealthPoints = 15;
                    this.Strength = 20;
                    break;
                case 1:
                    this.HealthPoints = 22.5;
                    this.Strength = 30;
                    break;
                case 2:
                    this.HealthPoints = 30;
                    this.Strength = 40;
                    break;
                case 3:
                    this.HealthPoints = 37.5;
                    this.Strength = 50;
                    break;
                case 4:
                    this.HealthPoints = 45;
                    this.Strength = 60;
                    break;
                case 5:
                    this.HealthPoints = 52.5;
                    this.Strength = 70;
                    break;
                case 6:
                    this.HealthPoints = 60;
                    this.Strength = 80;
                    break;
                default:
                    this.HealthPoints = 60;
                    this.Strength = 80;
                    break;
            }
            this.Strength = this.Strength * 2;
            this.HealthPoints = this.HealthPoints * 2;
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