using System;
using System.Collections.Generic;

namespace Final_Project.TemplateClasses
{
    public class NameList
    {
        private List<string> fNameList;
        private List<string> lNameList;
        private List<string> monsterNames;
        private List<string> cityNames;
        private List<string> placeNames;
        private List<string> factions;

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
            if (index == 5)
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
