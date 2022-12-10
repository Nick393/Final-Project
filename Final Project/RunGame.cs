using Final_Project.Commands;
using Final_Project.Databases;
using Final_Project.TemplateClasses;

using System;
using System.Collections.Generic;
using System.IO;

namespace Final_Project
{
    class RunGame
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
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
            while (isNotWorking==true)
            {
                bool gameNotEnded = true;
                bool isBoss = false;
                int PositiveEnd = 100000;
                int NegativeEnd = -100000;
                int multiplier = 1;
                double sMult = 1;
                bool startgame = true;
                
                string userCommand = Console.ReadLine().ToUpper();
                if ((userCommand == keyword.ListOfKeywords[13].ToUpper()) || (userCommand == keyword.ListOfKeywords[14].ToUpper()))
                {
                    CharacterTemplate mainCharacter = story.createMainCharacter(sMult);
                    saveData.addObject(mainCharacter);
                    story.startStory(mainCharacter);
                    while (gameNotEnded==true)
                    {
                        RunTheGame(ref PositiveEnd, ref NegativeEnd, ref multiplier, ref gameStage, ref sMult, ref mainCharacter, ref story, ref save, ref saveData, ref isBoss, ref gameNotEnded, ref startgame);
                    }
                    isNotWorking = false;
                }
                else if ((userCommand == keyword.ListOfKeywords[15].ToUpper()))
                {
                    Console.WriteLine("Please enter the file name exactly.");
                    List<object> characters = new List<object>();
                    characters = Save.loadState();
                    
                    
                        MonsterTemplate character = (MonsterTemplate)characters[0];
                    
                    //object monsterTemplate = (MonsterTemplate)characters[0];
                    CharacterTemplate mainCharacter = (CharacterTemplate)characters[1];
                    story.runEncounter(ref character, mainCharacter.Alignment, isBoss, ref mainCharacter, ref save, ref saveData);
                    while (gameNotEnded)
                    {
                        RunTheGame(ref PositiveEnd, ref NegativeEnd, ref multiplier, ref gameStage, ref sMult, ref mainCharacter, ref story, ref save, ref saveData, ref isBoss, ref gameNotEnded, ref startgame);
                    }//Leave this to the loaded;
                    isNotWorking = false;
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
            // Console.WriteLine(mode);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("The game is now playable!");

            switch (mode)
            {
                case "Safe":
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;


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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("If you are ready to begin your adventure, type Begin. If you would like to load a previous save, please type Load");
        }

        public static void endGame(CharacterTemplate finalBoss)
        {
            Console.WriteLine("You have defeated " + finalBoss.Name + ". Congradulations on your victory. However, you have only finished the BETA. If you are a true warrior, you shall finish the released version");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Environment.Exit(2);
        }
        public static void endGame(MonsterTemplate finalBoss)
        {
            Console.WriteLine("You have defeated " + finalBoss.Name + ". Congradulations on your victory. However, you have only finished the BETA. If you are a true warrior, you shall finish the released version");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Environment.Exit(2);
        }


        public static void RunTheGame(ref int PositiveEnd, ref int NegativeEnd, ref int multiplier, ref int gameStage, ref double sMult, ref CharacterTemplate mainCharacter, ref Story story, ref Save save, ref SaveData saveData, ref bool isBoss, ref bool gameNotEnded, ref bool startgame)
        {
            Random rand = new Random();
            KeywordCommands commands = new KeywordCommands();
            int randNum = rand.Next(0, 501);
            if (randNum > 450)
            {
                gameStage++;
                mainCharacter.updateHealth(gameStage);
                Console.WriteLine("You have levelled up! Your stats have grown and your health has recovered.");
            }
            if (mainCharacter.HealthPoints <= 0)
            {
                bool doesNotMatter = false;
                commands.Commands(null, ref mainCharacter, ref mainCharacter, ref saveData, ref save, ref doesNotMatter);
            }
            else if (randNum >= 251)
            {

                startgame = false;
                CharacterTemplate newVillian = (CharacterTemplate)story.RandomEncounter(rand.Next(2, PositiveEnd), mainCharacter.Alignment, gameStage, sMult);

                story.runEncounter(ref newVillian, mainCharacter.Alignment, isBoss, ref mainCharacter, ref saveData, ref save);
                if (isBoss)
                {
                    endGame(newVillian);
                }
            }
            else if (randNum < 251)
            {
                MonsterTemplate newMonster = (MonsterTemplate)story.RandomEncounter(rand.Next(NegativeEnd, -2), mainCharacter.Alignment, gameStage, sMult);

                story.runEncounter(ref newMonster, mainCharacter.Alignment, isBoss, ref mainCharacter, ref save, ref saveData);
                if (isBoss)
                {
                    endGame(newMonster);
                }
            }
            /*else if (startgame == true)
            {
                string newUserCommand = Console.ReadLine();
                string commandUsed = keyword.detectKeyword(newUserCommand);

                if (commandUsed != null)
                {
                    commands.Commands(commandUsed, ref saveData, ref save);
                }
            }*/
            else
            {
                //Console.WriteLine("Please Enter a Valid Command"); //don't know what this was for, but its currently useless
            }
            for (int i = multiplier * 10; i > 0; i--)
            {
                PositiveEnd++;
                NegativeEnd--;
            }
            if (isBoss)
            {
                //gameNotEnded = false;
            }
            multiplier = multiplier * 2;
            if (multiplier >= 32768)
            {
                isBoss = true;
            }
        }
    }
}
