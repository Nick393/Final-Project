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

            //starts the story
            StartScreen();
            string userCommand = Console.ReadLine().ToUpper();
            if ((userCommand == keyword.ListOfKeywords[13].ToUpper()) || (userCommand == keyword.ListOfKeywords[14].ToUpper()))
            {
                CharacterTemplate mainCharacter = story.createMainCharacter();
                saveData.addObject(mainCharacter);
                story.startStory();
            }
            else if ((userCommand == keyword.ListOfKeywords[16].ToUpper()))
            {

            }
            //creates the main character
        }

        public static void StartScreen()
        {
            Console.WriteLine("If you are ready to begin your adventure, type Begin. If you would like to learn more about the game, type Settings. If you would like to load a previous save, please type Load");
        }

    }
}
