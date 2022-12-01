using System;
using System.Collections.Generic;
using System.Text;
using Final_Project.TemplateClasses;

namespace Final_Project.Commands
{
    class Story
    {
        private List<object> avatars = new List<object>(1);
        private KeywordCommands commands = new KeywordCommands();
        private NameList names = new NameList();
        public CharacterTemplate createMainCharacter()
        {
            string name = RequestInformation("Name");
            string alignment = RequestInformation("Species");
            string species =  RequestInformation("Faction");
            int index = 0;
            CharacterTemplate mc = new CharacterTemplate(name, alignment, species);
            mc.Index = index;
            return mc;
        }
        public void startStory()
        {
            Console.WriteLine("We shall now begin!");
        }
        
        public string RequestInformation(string infoName)
        {
            Console.WriteLine("Please enter your " + infoName);
            string tempReturn = Console.ReadLine();
            if (commands.isKeyword(tempReturn))
            {
                commands.Commands(tempReturn);
                //put command method when done
                return RequestInformation(infoName);
            } if (infoName.ToUpper() == "SPECIES")
            {
                List<string> species = new List<string>();
                species = names.getList(3);
                foreach (string race in species)
                {
                    if (tempReturn.ToUpper() == race.ToUpper())
                    {
                        return race;
                    }
                    
                }
                string acceptableRaces = "";
                for (int i = 0; i < species.Count; i++)
                {
                    if (i != species.Count - 1)
                    {
                        acceptableRaces = acceptableRaces + species[i] + ", ";
                    }
                    else
                    {
                        acceptableRaces = acceptableRaces + species[i];
                    }
                }
                Console.WriteLine(acceptableRaces);
               return RequestErrorInformation(infoName);
            }
             if (infoName.ToUpper() == "FACTION")
            {
                List<string> factions = new List<string>();
                factions = names.getList(8);
                foreach (string faction in factions)
                {
                    if (tempReturn.ToUpper() == faction.ToUpper())
                    {
                        return faction;
                    }
                    
                }
                string acceptableRaces = "";
                for (int i = 0; i < factions.Count; i++)
                {
                    if (i != factions.Count - 1)
                    {
                        acceptableRaces = acceptableRaces + factions[i] + ", ";
                    }
                    else
                    {
                        acceptableRaces = acceptableRaces + factions[i];
                    }
                }
                Console.WriteLine(acceptableRaces);

                //if

                return RequestErrorInformation(infoName);
            }
            if ((infoName == "Name") &&((tempReturn.Contains("/")) || (tempReturn.Contains("*"))))
            {
                return RequestErrorInformation(infoName);
            }
            return tempReturn;
          
        }

        public string RequestErrorInformation(string infoName)
        {
            Console.WriteLine("Please enter a valid " + infoName);
           // Console.WriteLine("Would you likje to list out the ")
            /*Console.WriteLine("the list of available " + infoName + " is ");
            switch (infoName)
            {

            }*/
            string tempReturn = Console.ReadLine();
            if (commands.isKeyword(tempReturn))
            {
                commands.Commands(tempReturn);
                //put command method when done
                return RequestErrorInformation(infoName);
            }
            if (infoName.ToUpper() == "SPECIES")
            {
                List<string> species = new List<string>();
                species = names.getList(3);
                foreach (string race in species)
                {
                    if (tempReturn.ToUpper() == race.ToUpper())
                    {
                        return tempReturn;
                    }
                }
                string acceptableRaces = "";
                for (int i = 0; i < species.Count; i++)
                {
                    if (i != species.Count - 1)
                    {
                        acceptableRaces = acceptableRaces + species[i] + ", ";
                    }
                    else
                    {
                        acceptableRaces = acceptableRaces + species[i];
                    }
                }
                Console.WriteLine(acceptableRaces);
                return RequestErrorInformation(infoName);
            }
            else if (infoName.ToUpper() == "ALIGNMENT")
            {
                List<string> factions = new List<string>();
                factions = names.getList(8);
                foreach (string faction in factions)
                {
                    if (tempReturn.ToUpper() == faction.ToUpper())
                    {
                        return faction;
                    }
                }
                string acceptableRaces = "";
                for (int i = 0; i < factions.Count; i++)
                {
                    if (i != factions.Count - 1)
                    {
                        acceptableRaces = acceptableRaces + factions[i] + ", ";
                    }
                    else
                    {
                        acceptableRaces = acceptableRaces + factions[i];
                    }
                }
                Console.WriteLine(acceptableRaces);
                return RequestErrorInformation(infoName);
            }
            if ((infoName == "Name") && ((tempReturn.Contains("/")) || (tempReturn.Contains("*"))))
            {
                return RequestErrorInformation(infoName);
            }
            return RequestErrorInformation(infoName); 
        }
      
        //Use this to put to start the game from the save data
        public void loadSave()
        {

        }
    }
}
