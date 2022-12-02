using Final_Project.Databases;
using Final_Project.TemplateClasses;
using System;

namespace Final_Project.Commands
{
    class KeywordCommands : Keywords
    {
        public void Commands(string commandUsed, ref SaveData saveData, ref Save save)
        {
            Keywords keyword = new Keywords();
            commandUsed = commandUsed.ToUpper();
            if ((commandUsed == keyword.ListOfKeywords[5].ToUpper()) || commandUsed == keyword.ListOfKeywords[16].ToUpper())
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
                    }
                    else
                    {
                        listOfWords += word;
                    }
                }
                Console.WriteLine(listOfWords);
            }
            else if ((commandUsed == keyword.ListOfKeywords[6].ToUpper()) || (commandUsed == keyword.ListOfKeywords[7].ToUpper()))
            {
                //Exit or Close
                Console.WriteLine("Would you like to Save? Y/N");
                string response = Console.ReadLine().ToUpper();
                if (response == "Y" || response == "YES")
                {
                    Commands("Save", ref saveData, ref save);
                } else if (response == "N" || response == "NO")
                {
                    Environment.Exit(0);
                }
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
                //Load
            }
            else if (commandUsed == keyword.ListOfKeywords[17].ToUpper())
            {
                //Save
                Environment.Exit(0);
            } else if (commandUsed == keyword.ListOfKeywords[18].ToUpper())
            {
                //Stats
            }
        }

        public void Commands(string commandUsed, MonsterTemplate monster, CharacterTemplate mainCharacter, ref SaveData saveData, ref Save save)
        {
            Keywords keyword = new Keywords();
            commandUsed = commandUsed.ToUpper();
            if (commandUsed == keyword.ListOfKeywords[0].ToUpper())
            {
                double probability = (mainCharacter.HealthPoints / monster.HealthPoints)*100;
                Random rand = new Random();
                double random=rand.Next(0, 101);
                if(random>probability)
                {
                    Console.WriteLine("You Lose!");
                }
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
                double probability = ((getStrengthValue(mainCharacter)) / (monster.HealthPoints+monster.Strength)) * 100;
                Random rand = new Random();
                double random = rand.Next(0, 101);
                if (random > probability)
                {
                    Console.WriteLine("You Lose! Press any key to admit defeat!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("You won the fight!");
                }
            }
            else if (commandUsed == keyword.ListOfKeywords[4].ToUpper())
            {
                //Heal
            }
            else
            {
                Commands(commandUsed, ref saveData, ref save);
            }
        }
        public double getStrengthValue( CharacterTemplate mainCharacter)
        {
            double petStrength = mainCharacter.Strength;
            if (mainCharacter.Pets.Count != 0)
            {
                for (int i = 0; i < mainCharacter.Pets.Count; i++)
                {
                    petStrength = petStrength + mainCharacter.Pets[i].Strength;
                }
            }
            return petStrength;
        }
    }
}