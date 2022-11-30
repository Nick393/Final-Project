using System;
using System.Collections.Generic;
using System.Text;
using Final_Project.Databases;
using Final_Project.TemplateClasses;

namespace Final_Project.Commands
{
    class KeywordCommands : Keywords
    {
        public void Commands(string commandUsed, ref SaveData saveData, ref Save save)
        {
            Keywords keyword = new Keywords();
            commandUsed = commandUsed.ToUpper();
            if (commandUsed == keyword.ListOfKeywords[0].ToUpper())
            {
                //Fight
            }
            else if (commandUsed == keyword.ListOfKeywords[1].ToUpper())
            {
                //Flee
            }
            else if (commandUsed == keyword.ListOfKeywords[2].ToUpper())
            {
                //Tame
            }
            else if (commandUsed == keyword.ListOfKeywords[3].ToUpper())
            {
                //kill
            }
            else if (commandUsed == keyword.ListOfKeywords[4].ToUpper())
            {
                //Heal
            }
            else if (commandUsed == keyword.ListOfKeywords[5].ToUpper())
            {
                //Keywords
                string listOfWords = null;
                foreach (string word in keyword.ListOfKeywords)
                {
                    if ((word == "Y") || (word == "N")) 
                    {
                        
                    }
                    else if (word != "Save")
                    {
                        listOfWords += word + ", ";
                    } else
                    {
                        listOfWords += word;
                    }
                }
                Console.WriteLine(listOfWords);
                Console.ReadLine();
            }
            else if ((commandUsed == keyword.ListOfKeywords[6].ToUpper()) || (commandUsed == keyword.ListOfKeywords[7].ToUpper()))
            {
                //Exit or Close
            }

            else if (commandUsed == keyword.ListOfKeywords[8].ToUpper())
            {
                //Reset
            }
            else if ((commandUsed == keyword.ListOfKeywords[9].ToUpper()) || (commandUsed == keyword.ListOfKeywords[10].ToUpper()))
            {
                //Yes
                Console.WriteLine("Yes");
            }
            else if ((commandUsed == keyword.ListOfKeywords[11].ToUpper()) || (commandUsed == keyword.ListOfKeywords[12].ToUpper()))
            {
                //No
            }
            else if ((commandUsed == keyword.ListOfKeywords[13].ToUpper()) || (commandUsed == keyword.ListOfKeywords[14].ToUpper()))
            {
                //Begin/Start
            }
            else if (commandUsed == keyword.ListOfKeywords[15].ToUpper())
            {

            }
            else if (commandUsed == keyword.ListOfKeywords[16].ToUpper())
            {

            }
        }
    }
}
