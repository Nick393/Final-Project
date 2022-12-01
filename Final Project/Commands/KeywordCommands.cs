using System;
using System.Collections.Generic;
using System.Text;
using Final_Project.Databases;
using Final_Project.TemplateClasses;

namespace Final_Project.Commands
{
    class KeywordCommands : Keywords
    {
        public void Commands(string commandUsed)
        {
            Keywords keyword = new Keywords();
            if (commandUsed == keyword.ListOfKeywords[5])
            {
                //Keywords
            }
            else if ((commandUsed == keyword.ListOfKeywords[6]) || (commandUsed == keyword.ListOfKeywords[7]))
            {
                //Exit or CloseC
                Console.WriteLine("Would you like to save? (y/n)");
                string determine = Console.ReadLine();
                if(determine=="Y")
                {

                    Save.SaveObjects(SaveData.objects);
                }
            }

            else if (commandUsed == keyword.ListOfKeywords[8])
            {
                //Reset
            }
            else if ((commandUsed == keyword.ListOfKeywords[9]) || (commandUsed == keyword.ListOfKeywords[10]))
            {
                //Yes
                Console.WriteLine("Yes");
            }
            else if (commandUsed == keyword.ListOfKeywords[12] || commandUsed == keyword.ListOfKeywords[11])
            {
                //No
            }
            else if (commandUsed == keyword.ListOfKeywords[13])
            {

            }
            else if (commandUsed == keyword.ListOfKeywords[14])
            {

            }
            else if (commandUsed == keyword.ListOfKeywords[15])
            {

            }
            else if (commandUsed == keyword.ListOfKeywords[16])
            {

            }
        }
        public void Commands(string commandUsed, ref SaveData saveData, ref Save save)
        {
            Keywords keyword = new Keywords();
            if (commandUsed == keyword.ListOfKeywords[0])
            {
                //Fight
            }
            else if (commandUsed == keyword.ListOfKeywords[1])
            {
                //Flee
            }
            else if (commandUsed == keyword.ListOfKeywords[2])
            {
                //Tame
            }
            else if (commandUsed == keyword.ListOfKeywords[3])
            {
                //kill
            }
            else if (commandUsed == keyword.ListOfKeywords[4])
            {
                //Heal
            }
            else if (commandUsed == keyword.ListOfKeywords[5])
            {
                //Keywords
            }
            else if ((commandUsed == keyword.ListOfKeywords[6]) || (commandUsed == keyword.ListOfKeywords[7]))
            {
                //Exit or Close
            }

            else if (commandUsed == keyword.ListOfKeywords[8])
            {
                //Reset
            }
            else if ((commandUsed == keyword.ListOfKeywords[9]) || (commandUsed == keyword.ListOfKeywords[10]))
            {
                //Yes
                Console.WriteLine("Yes");
            }
            else if ((commandUsed == keyword.ListOfKeywords[11]) || (commandUsed == keyword.ListOfKeywords[12]))
            {
                //No
            }
            else if ((commandUsed == keyword.ListOfKeywords[13]) || (commandUsed == keyword.ListOfKeywords[14]))
            {
                //Begin/Start
            }
            else if (commandUsed == keyword.ListOfKeywords[15])
            {

            }
            else if (commandUsed == keyword.ListOfKeywords[16])
            {

            }
        }
    }
}
