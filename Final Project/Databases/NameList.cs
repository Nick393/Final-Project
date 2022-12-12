using System;
using System.Collections.Generic;

namespace Final_Project.TemplateClasses
{
    public class NameList
    {
        private List<string> fNameList = new List<string>() { "Tom", "Kevin", "Jerry" };
        private List<string> lNameList = new List<string>() { "Johnson", "Tomson", "Jerryson" };
        private List<string> monsterNameList = new List<string>() { "Drakthar", "Boo", "Steve" };
        private List<string> playerSpecies = new List<string>() { "Human", "Elf", "Dwarf" };
        private List<string> monsterSpecies = new List<string>() { "Eagle", "Fish", "Dragon" };
        private List<string> cityNames = new List<string>() { "Des Moines", "Long John Silvers", "Jerryville" };
        private List<string> placeNames = new List<string>() { "Deertrack", "Sevii", "Kevin", "Typhoon" }; //Remain unused
        private List<string> placeSuffixes = new List<string>() { "Forest", "Desert", "Ocean" }; //Remain unused
        private List<string> factions = new List<string>() { "Good", "Neutral", "Evil" };


        //Returns a name for NPC characters
        public string getHumanName()
        {
            Random rand = new Random();
            string randFName = fNameList[rand.Next(fNameList.Count)];
            string randLName = lNameList[rand.Next(lNameList.Count)];
            return randFName + " " + randLName;
        }

        public string getHumanSpecies()
        {
            Random rand = new Random();
            string speciesName = playerSpecies[rand.Next(playerSpecies.Count)];
            return speciesName;
        }

        public string getOpposingFaction(string mcFaction)
        {
            Random rand = new Random();
            int numNotPicked = 0;
            for (int i = 0; i < factions.Count; i++)
            {
                if (mcFaction.ToUpper() == factions[i].ToUpper())
                {
                    numNotPicked = i;
                }
            }
            int randNum = notEqualValue(numNotPicked, factions.Count - 1);
            return factions[randNum];
        }

        public int notEqualValue(int secondValue, int size)
        {
            Random rand = new Random();
            int randomValue = rand.Next(size);
            if (randomValue == secondValue)
            {
                return notEqualValue(secondValue, size);
            }
            else
            {
                return randomValue;
            }
        }

        public string getMonsterName()
        {
            Random rand = new Random();
            string monstName = monsterNameList[rand.Next(monsterNameList.Count)];
            return monstName;
        }

        public string getMonsterSpecies()
        {
            Random rand = new Random();
            string speciesName = monsterSpecies[rand.Next(monsterSpecies.Count)];
            return speciesName;
        }

        //returns a random value from a list provided
        public string getValue(List<string> mrList)
        {
            Random rand = new Random();
            string returnValue = mrList[rand.Next(mrList.Count)];
            return returnValue;
        }

        //returns a place name followed by a suffix
        public string getLocation()
        {
            Random rand = new Random();
            string randPlaceName = placeNames[rand.Next(placeNames.Count)];
            string randSuffixName = placeSuffixes[rand.Next(placeSuffixes.Count)];
            return randPlaceName + " " + randSuffixName;
        }

        public string getCity()
        {
            Random rand = new Random();
            string cityName = cityNames[rand.Next(cityNames.Count)];
            return cityName;
        }

        //returns a list based on its arbitrary index value
        public List<string> getList(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        return fNameList;
                    }
                case 1:
                    {
                        return lNameList;
                    }
                case 2:
                    {
                        return monsterNameList;
                    }
                case 3:
                    {
                        return playerSpecies;
                    }
                case 4:
                    {
                        return monsterSpecies;
                    }
                case 5:
                    {
                        return cityNames;
                    }
                case 6:
                    {
                        return placeNames;
                    }
                case 7:
                    {
                        return placeSuffixes;
                    }
                case 8:
                    {
                        return factions;
                    }
                default:
                    {
                        List<string> Null = new List<string>();
                        return Null;
                    }
            }
        }


        //sets default values based on the stage of the game
        public void determineDefault(int stage, ref double health, ref double strength)
        {
            int newStage = stage - 1;
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
                    determineDefault(1, ref health, ref strength);
                    break;
            }
        }
    }
}
