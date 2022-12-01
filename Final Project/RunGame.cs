using System;
using System.Collections.Generic;
using System.Text;
using Final_Project.Commands;
using Final_Project.Databases;
using Final_Project.TemplateClasses;

namespace Final_Project
{
    class RunGame
    {
        static void Main(string[] args)
        {
            //declares all of the classes for easy method use
            Save save = new Save();
            Story story = new Story();
            NameList nameList = new NameList();
            Keywords keyword = new Keywords();
            SaveData saveData = new SaveData();
            KeywordCommands commands = new KeywordCommands();
            int gameStage = 0;
            //starts the story make this recursive
            StartScreen();
            bool isNotWorking = true;
            while (isNotWorking)
            {

                string userCommand = Console.ReadLine().ToUpper();
                if ((userCommand == keyword.ListOfKeywords[13].ToUpper()) || (userCommand == keyword.ListOfKeywords[14].ToUpper()))
                {
                    isNotWorking = false;
                    CharacterTemplate mainCharacter = story.createMainCharacter();
                    saveData.addObject(mainCharacter);
                    story.startStory();
                    bool gameNotEnded = true;
                    while (gameNotEnded)
                    {
                        string newUserCommand = Console.ReadLine();
                        string commandUsed = keyword.detectKeyword(newUserCommand);
                        if (commandUsed != null)
                        {
                            commands.Commands(commandUsed, ref saveData, ref save);
                        }
                        else
                        {
                            Console.WriteLine("Please Enter a Valid Command");
                        }
                    }

                }
                else if ((userCommand == keyword.ListOfKeywords[15].ToUpper()))
                {
                    isNotWorking = false;
                    //Leave this to the loaded
                } else
                {
                    Console.WriteLine("Please enter a valid Command");
                    StartScreen();
                }
            }
            //creates the main character
        }

        public static void StartScreen()
        {
            Console.WriteLine("If you are ready to begin your adventure, type Begin. If you would like to load a previous save, please type Load");
        }

    }
}
