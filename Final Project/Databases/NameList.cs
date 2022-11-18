using System;
using System.Collections.Generic;

namespace Final_Project.TemplateClasses
{
    public class NameList
    {
        private List<string> fNameList = new List<string>() { "Tom", "Kevin", "Jerry" };
        private List<string> lNameList = new List<string>() { "Johnson", "Tomson", "Jerryson" };
        private List<string> monsterNames = new List<string>() { "Eagle", "Fish", "Dragon" };
        private List<string> cityNames = new List<string>() { "Des Moines", "Long John Silvers", "Jerryville" };
        private List<string> placeNames = new List<string>() { "Deertrack","Sevii", "Kevin", "Typhoon" };
        private List<string> placeSuffixes = new List<string>() { "Forest", "Desert", "Ocean" };
        private List<string> factions = new List<string>() { "Good", "Neutral", "Evil" };


        //Returns a name for NPC characters
        public string getFullName()
        {
            Random rand = new Random();
            string randFName = fNameList[rand.Next(fNameList.Count)];
            string randLName = lNameList[rand.Next(lNameList.Count)];
            return randFName + " " + randLName;
        }

        //returns a random value from a list provided
        public string getValue(string[] mrList)
        {
            Random rand = new Random();
            string returnValue = mrList[rand.Next(mrList.Length)];
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

       //returns a list based on its arbitrary index value
        public List<string> getList(int index)
        {
            switch(index)
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
                        return monsterNames;
                    }
                case 3:
                    {
                        return cityNames;
                    }
                case 4:
                    {
                        return placeNames;
                    }
                case 5:
                    {
                        return placeSuffixes;
                    }
                case 6:
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
    }
}
