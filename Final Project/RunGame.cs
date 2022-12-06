﻿using Final_Project.Commands;
using Final_Project.Databases;
using Final_Project.TemplateClasses;

using System;
using System.IO;

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
                    bool startgame = true;
                    isNotWorking = false;
                    CharacterTemplate mainCharacter = story.createMainCharacter();
                    saveData.addObject(mainCharacter);
                    story.startStory(mainCharacter);
                    bool gameNotEnded = true;
                    double SMult = 1;
                    while (gameNotEnded)
                    {
                        int randNum = rand.Next(0, 501);
                        if (randNum >= 251)
                        {

                            startgame = false;
                            CharacterTemplate newVillian = (CharacterTemplate)story.RandomEncounter(rand.Next(2, 100000), mainCharacter.Alignment, gameStage);
                            newVillian.HealthPoints = rand.Next(20, 250);
                            story.runEncounter(newVillian, mainCharacter.Alignment, false, mainCharacter, SMult);
                        }
                        else
                        {
                            MonsterTemplate newMonster = (MonsterTemplate)story.RandomEncounter(rand.Next(-100000, -2), mainCharacter.Alignment, gameStage);
                            newMonster.HealthPoints = rand.Next(20, 250);
                            story.runEncounter(newMonster, mainCharacter.Alignment, false, mainCharacter, SMult);
                        }
                        if (startgame == true)
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
                        SMult = SMult + 1;
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
            Console.WriteLine("to change the settings, type \"config\"");
            string[] config = File.ReadAllLines("config.json");
            string mode = config[0];
            mode = mode.Substring(13);
            int num = 0;
            StreamReader w = new StreamReader("highScore.json");
            int hscore = 0;
            try
            {
                hscore = int.Parse(w.ReadLine());
            }
            catch
            {
                w.Close();
                StreamWriter a = new StreamWriter("highScore.json");
                a.Write(0);
                a.Close();

            }
            Console.WriteLine("Your high score is " + hscore);
            Console.WriteLine(mode);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("The game is now playable!");

            switch (mode)
            {
                case "Safe":
                    {
                        Console.ForegroundColor = ConsoleColor.Green;


                        Console.WriteLine("The game is in Safe mode,this is for a new feature not implemented yet");
                        Console.WriteLine("endgame functionality may be limited");
                        break;

                    }
                case "Semi-Full":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The game is in Semi-Full Mode");
                        break;
                    }
                case "Full":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The game is in Full mode");
                        break;
                    }
                case "Danger":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The game is in Danger mode");
                        Console.WriteLine("Warning! This mode can cause loss of data");
                        break;
                    }

                    //these modes are not implemented.  they are for a planned "Master Hacker" super boss.
                    //Loss to this boss will shut down the computer.  Hence the warning. ?purprle text? 
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("to change the mode, enable the alternate modes and set it in the config.json file. ");
            Console.WriteLine("WARNING! Alternate modes may cause accidental data loss");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("If you are ready to begin your adventure, type Begin. If you would like to load a previous save, please type Load");
        }

    }
}
