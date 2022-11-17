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
        private List<string> placeNames = new List<string>() { "Forest", "Desert", "Ocean" };
        private List<string> placeSuffixes = new List<string>() { "Forest", "Desert", "Ocean" };
        private List<string> factions = new List<string>() { "Good", "Neutral", "Evil" };

        public string getFullName()
        {
            Random rand = new Random();
            string randFName = fNameList[rand.Next(fNameList.Count)];
            string randLName = lNameList[rand.Next(lNameList.Count)];
            return randFName + " " + randLName;
        }

        public string getValue(string[] mrList)
        {
            Random rand = new Random();
            string returnValue = mrList[rand.Next(mrList.Length)];
            return returnValue;
        }

        //his name is kevin
        public List<string> getList(int index)
        {
            if (index == 0)
            {
                return fNameList;
            }
            if (index == 1)
            {
                return lNameList;
            }
            if (index == 2)
            {
                return monsterNames;
            }
            if (index == 3)
            {
                return cityNames;
            }
            if (index == 4)
            {
                return placeNames;
            }
            if (index == 4)
            {
                return placeSuffixes;
            }
            if (index == 6)
            {
                return factions;
            }
            else
            {
                List<string> mrKevin = new List<string>(0);
                return mrKevin;
            }
        }
    }
}
