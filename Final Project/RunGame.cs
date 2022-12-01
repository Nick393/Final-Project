using Final_Project.Commands;
using Final_Project.Databases;
using Final_Project.TemplateClasses;
using System;

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
            Random rand = new Random();
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
                        if (rand.Next(1, 2) == 1)
                        {
                            CharacterTemplate newVillian = (CharacterTemplate)story.RandomEncounter(rand.Next(2, 100000), mainCharacter.Alignment, gameStage);
                            Console.WriteLine(newVillian.Alignment);
                        }
                        else
                        {
                            MonsterTemplate newMonster = (MonsterTemplate)story.RandomEncounter(rand.Next(-100000, -2), mainCharacter.Alignment, gameStage);
                            Console.WriteLine(newMonster);
                        }
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
                }
                else
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
