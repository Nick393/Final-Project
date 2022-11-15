using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project.TemplateClasses
{
    public class NameList
    {
        private string[] fNameList;
        private string[] lNameList;
        private string[] monsterNames;
        private string[] cityNames;
        private string[] placeNames;

        public string getFullName()
        {
            Random rand = new Random();
            string randFName = fNameList[rand.Next(fNameList.Length)];
            string randLName = lNameList[rand.Next(lNameList.Length)];
            return randFName + " " + randLName;
        }

        public string getValue(string[] mrList)
        {
            Random rand = new Random();
            string returnValue = mrList[rand.Next(mrList.Length)];
        }

        //his name is kevin
        public string[] getList(int index)
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
            } else
            {
                string[] mrKevin = new string[0];
                return mrKevin;
            }
        }
    }
}
