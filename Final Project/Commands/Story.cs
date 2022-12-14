using Final_Project.Databases;
using Final_Project.TemplateClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Final_Project.Commands
{
    class Story
    {
        private List<object> avatars = new List<object>(1);
        private KeywordCommands commands = new KeywordCommands();
        private NameList names = new NameList();
        private SaveData saveData = new SaveData();
        private Save save = new Save();
        Random rand = new Random();
        public CharacterTemplate createMainCharacter(double sMult)
        {
            string name = RequestInformation("Name");
            List<string> speciesList = new List<string>();
            speciesList = names.getList(3);
            Console.WriteLine("The available species are: ");
            foreach (string Species in speciesList)
            {
                Console.WriteLine(Species);
            }
            string species = RequestInformation("Species");
            List<string> factions = new List<string>();
            factions = names.getList(8);
            Console.WriteLine("The available factions are: ");
            foreach (string faction in factions)
            {
                Console.WriteLine(faction);
            }
            string alignment = RequestInformation("Faction");
            const int START_STAGE = 0;
            CharacterTemplate mc = new CharacterTemplate();
            mc.Name = name;
            mc.Species = species;
            mc.Alignment = alignment;
            mc.Strength = 60;
            mc.HealthPoints = 45;
            StreamReader r = new StreamReader("highScore.json");
            if (mc.Name == "HaCKEr")
            {
                mc.Name = "Developer";
                Console.Write("Developer mode ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("enabled");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Developer Settings:");
                Console.WriteLine("Enter your starting health");
                Console.ForegroundColor = ConsoleColor.Magenta;
                double sHealth = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Enter your starting Strength");
                Console.ForegroundColor = ConsoleColor.Magenta;
                double sStrength = int.Parse(Console.ReadLine());
                mc.HealthPoints = sHealth;
                mc.Strength = sStrength;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            int score = int.Parse(r.ReadLine());
            r.Close();
            mc.score = score;
            return mc;
        }
        public void startStory(CharacterTemplate mainCharacter)
        {
            Console.WriteLine("Welcome " + mainCharacter.Name + " of the " + mainCharacter.Species + " species. You are now a member of the " + mainCharacter.Alignment + " side. We shall now begin!");
            Console.WriteLine("Your starting health is: " + mainCharacter.HealthPoints);
            Console.WriteLine("Your starting strength is: " + mainCharacter.Strength);
        }

        public string RequestInformation(string infoName)
        {
            Console.WriteLine("Please enter your " + infoName);
            Console.ForegroundColor = ConsoleColor.Yellow;
            string tempReturn = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            if (commands.isKeyword(tempReturn))
            {
                if (commands.isSystemKeyword(tempReturn))
                {
                    commands.Commands(tempReturn, ref saveData, ref save);
                }
                else
                {
                    Console.WriteLine("Please enter a " + infoName + " that is not a keyword");
                }
                //put command method when done
                return RequestInformation(infoName);
            }
            else if (infoName.ToUpper() == "SPECIES")
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
                if (listInputsPrompt(infoName))
                {
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
                }
                return RequestInformation(infoName);
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
                if (listInputsPrompt(infoName))
                {
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
                }

                return RequestInformation(infoName);
            }
            if ((infoName == "Name") && ((tempReturn.Contains("/")) || (tempReturn.Contains(",") || (tempReturn.Contains("?")))))
            {
                Console.WriteLine("Please enter a " + infoName + " that is does not contain comma (,), a question mark (?), or a slash (/)");
                return RequestInformation(infoName);
            }
            return tempReturn;
        }

        public bool listInputsPrompt(string infoName)
        {
            Console.WriteLine("Would you like to see a list of Valid " + infoName + "? Y/N");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string test = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            if (commands.isKeyword(test))
            {
                commands.Commands(test, ref saveData, ref save);
            }
            if ((test.ToUpper() == "Y") || (test.ToUpper() == "YES")) { return true; }
            else if ((test.ToUpper() == "N") || (test.ToUpper() == "NO")) { return false; }
            else { return listInputsPrompt(infoName); }
        }

        public object RandomEncounter(int randNum, string mcAlignment, int gameStage, double sMult)
        {
            if (randNum == 0)
            {
                int sign = rand.Next(1, 2);
                int multiplier = 0;
                if (sign == 1)
                {
                    multiplier = -1;
                }
                else if (sign == 2)
                {
                    multiplier = 1;
                }
                return RandomEncounter(multiplier, mcAlignment, gameStage, sMult);
            }
            else if (randNum < 0)
            {
                if (Math.Abs(randNum) == 1)
                {
                    //put boss method here
                    const int BUFF_POWER = 3;
                    sMult = sMult * 4;
                    MonsterTemplate encounter = makeEncounter(BUFF_POWER, gameStage, sMult);
                    return encounter;
                }
                else if (Math.Abs(randNum) < 100)
                {
                    const int BUFF_POWER = 2;
                    sMult = sMult * 3;
                    MonsterTemplate encounter = makeEncounter(BUFF_POWER, gameStage, sMult);
                    return encounter;
                }
                else if (Math.Abs(randNum) < 10000)
                {
                    const int BUFF_POWER = 1;
                    sMult = sMult * 2;
                    MonsterTemplate encounter = makeEncounter(BUFF_POWER, gameStage, sMult);
                    return encounter;
                }
                else
                {
                    const int BUFF_POWER = 0;
                    MonsterTemplate encounter = makeEncounter(BUFF_POWER, gameStage, sMult);
                    return encounter;
                }

            }
            else
            {
                if (Math.Abs(randNum) == 1)
                {
                    //put boss method here
                    const int BUFF_POWER = 3;
                    sMult = sMult * 4;
                    CharacterTemplate encounter = makeEncounter(BUFF_POWER, gameStage, mcAlignment, sMult);
                    return encounter;
                }
                else if (Math.Abs(randNum) < 100)
                {
                    const int BUFF_POWER = 2;
                    CharacterTemplate encounter = makeEncounter(BUFF_POWER, gameStage, mcAlignment, sMult);
                    return encounter;
                }
                else if (Math.Abs(randNum) < 10000)
                {
                    const int BUFF_POWER = 1;
                    CharacterTemplate encounter = makeEncounter(BUFF_POWER, gameStage, mcAlignment, sMult);
                    return encounter;
                }
                else
                {
                    const int BUFF_POWER = 0;
                    CharacterTemplate encounter = makeEncounter(BUFF_POWER, gameStage, mcAlignment, sMult);
                    return encounter;
                }

            }
        }

        public MonsterTemplate makeEncounter(int BUFF_POWER, int gameStage, double sMult)
        {
            string name = names.getMonsterName();
            string species = names.getMonsterSpecies();
            MonsterTemplate returnMonster = new MonsterTemplate(name, species, BUFF_POWER, gameStage, sMult);
            return returnMonster;
        }

        public CharacterTemplate makeEncounter(int BUFF_POWER, int gameStage, string mcAlignment, double sMult)
        {
            string name = names.getHumanName();
            string species = names.getHumanSpecies();
            string alignment = names.getOpposingFaction(mcAlignment);
            CharacterTemplate returnCharacter = new CharacterTemplate(name, alignment, species, BUFF_POWER, gameStage, sMult);
            return returnCharacter;
        }

        public void runEncounter(ref CharacterTemplate enemy, string mcAlignment, bool isBoss, ref CharacterTemplate mainCharacter, ref SaveData saveData, ref Save save)
        {
            Random rando = new Random();
            int add = rando.Next(0, 12);
            if (add == 5)
            {
                mainCharacter.numMedkits = mainCharacter.numMedkits + 1;
                Console.WriteLine("You have found a medkit!");
            }
            string message = "ERROR MESSAGE, SHOULD NOT BE SHOWN";
            const string beginEncounter = "You have encountered ";
            Random rand = new Random();
            int randomizer = rand.Next(0, 8);
            int neutralCalc = 0;
            if (mcAlignment.ToUpper() == "NEUTRAL")
            {
                int newRandomizer = rand.Next(0, 201);
                if (newRandomizer > 100)
                {
                    neutralCalc = 1;
                }
            }
            if ((mcAlignment.ToUpper() == "GOOD") || (neutralCalc >= 1))
            {
                if (isBoss)
                {
                    message = "You are confronted with your own mortality by " + enemy.Name + ", the Destroyer of Worlds, the Demon of " + names.getCity() + ", and the Devourer of Souls" + ".";
                }
                else
                {
                    switch (randomizer)
                    {
                        case 0:
                            message = beginEncounter + enemy.Name + ", the Destroyer of Worlds.";
                            break;
                        case 1:
                            message = beginEncounter + enemy.Name + ", the Eater of Dreams.";
                            break;
                        case 2:
                            message = beginEncounter + enemy.Name + ", the Soul Eater.";
                            break;
                        case 3:
                            message = beginEncounter + enemy.Name + ", the Barbarian.";
                            break;
                        case 4:
                            message = beginEncounter + enemy.Name + ", the Calamity.";
                            break;
                        case 5:
                            message = beginEncounter + enemy.Name + ", the Demon King.";
                            break;
                        case 6:
                            message = beginEncounter + enemy.Name + ", the Butcher of " + names.getCity() + ".";
                            break;
                        case 7:
                            message = beginEncounter + enemy.Name + ", the Asura.";
                            break;
                        default:
                            message = beginEncounter + enemy.Name + ".";
                            break;
                    }
                }
            }
            else
            {
                if (isBoss)
                {
                    message = "You are confronted with your own mortality by " + enemy.Name + ", the Saint King, the Protector of " + names.getCity() + ", and the Sword of Justice" + ".";
                }
                else
                {
                    switch (randomizer)
                    {
                        case 0:
                            message = beginEncounter + enemy.Name + ", the Conquerer.";
                            break;
                        case 1:
                            message = beginEncounter + enemy.Name + ", the Builder.";
                            break;
                        case 2:
                            message = beginEncounter + enemy.Name + ", the Sword of Justice.";
                            break;
                        case 3:
                            message = beginEncounter + enemy.Name + ", the Demon Slayer.";
                            break;
                        case 4:
                            message = beginEncounter + enemy.Name + ", the Good.";
                            break;
                        case 5:
                            message = beginEncounter + enemy.Name + ", the Saint King.";
                            break;
                        case 6:
                            message = beginEncounter + enemy.Name + ", the Just.";
                            break;
                        case 7:
                            message = beginEncounter + enemy.Name + ", the Defender of the World.";
                            break;
                        default:
                            message = beginEncounter + enemy.Name + ".";
                            break;
                    }
                }
            }
            Console.WriteLine(message);
            Console.WriteLine(enemy.Name + "'s health is " + enemy.HealthPoints);
            Console.WriteLine(enemy.Name + "'s strength is " + enemy.Strength);
            bool encounterDone = false;
            KeywordCommands keywords = new KeywordCommands();
            while (encounterDone == false)
            {
                Console.WriteLine("What would you like to do next?  (type \"help\" for help.)");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string command = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Green;
                if (!(Keywords.keywordsVerify.Contains(command.ToUpper())))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Command.  Type \"help\" for a list of valid commands");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (command == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must enter a command. Type \"help\" for a list of valid commands");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                bool ranAway = false;
                keywords.Commands(command, ref enemy, ref mainCharacter, ref saveData, ref save, ref ranAway, isBoss);
                if (mainCharacter.HealthPoints <= 0)
                {
                    encounterDone = true;
                }
                else if (command == "kill" || command == "fight" || ((command == "flee" && ranAway && !isBoss)))
                {
                    encounterDone = true;
                    Console.WriteLine("Your health is now " + mainCharacter.HealthPoints.ToString());
                    Console.WriteLine("Your strength is " + mainCharacter.Strength);
                }

                else
                {
                    Console.WriteLine("You are facing " + enemy.Name);
                    Console.WriteLine(enemy.Name + "'s health is " + enemy.HealthPoints);
                    Console.WriteLine(enemy.Name + "'s strength is " + enemy.Strength);
                }
                if (mainCharacter.Pets.Count != 0)
                {
                    Console.WriteLine("You have " + mainCharacter.Pets.Count + " pets.  They are:");
                    foreach (object pet in mainCharacter.Pets)
                    {
                        Console.WriteLine(pet.ToString());
                    }

                }
                if (command == "" || command == "save" || command == "load" || command == "start" || command == "begin" || command == "stats" || command == "keywords" || command == "exit" || command == "reset" || command == "help" || command == "heal" || command == "close" || !(Keywords.keywordsVerify.Contains(command.ToUpper())))
                {
                    encounterDone = false;
                }


            }
            mainCharacter.score = mainCharacter.score + 1;
            StreamReader r = new StreamReader("highScore.json");
            int score = int.Parse(r.ReadLine());
            r.Close();
            score++;
            //StreamWriter W = new StreamWriter("highScore.json");
            //W.Write(score);
            //W.Close();



        }

        public void runEncounter(ref MonsterTemplate enemy, string mcAlignment, bool isBoss, ref CharacterTemplate mainCharacter, ref Save save, ref SaveData saveData)
        {
            Random rando = new Random();
            int add = rando.Next(0, 12);
            if (add == 5)
            {
                mainCharacter.numMedkits = mainCharacter.numMedkits + 1;
                Console.WriteLine("You have found a medkit!");
            }
            string message = "ERROR MESSAGE, SHOULD NOT BE SHOWN";
            const string beginEncounter = "You have encountered ";
            Random rand = new Random();
            int randomizer = rand.Next(0, 8);
            if (isBoss)
            {
                message = "You are confronted with your own mortality by " + enemy.Name + ", the " + enemy.Species + ", the Destroyer of Worlds, the Demon of " + names.getCity() + ", and the Devourer of Souls" + ".";
            }
            else
            {
                switch (randomizer)
                {
                    case 0:
                        message = beginEncounter + enemy.Name + ", the " + enemy.Species + ", the Destroyer of Worlds.";
                        break;
                    case 1:
                        message = beginEncounter + enemy.Name + ", the " + enemy.Species + ", the Eater of Dreams.";
                        break;
                    case 2:
                        message = beginEncounter + enemy.Name + ", the " + enemy.Species + ", the Soul Eater.";
                        break;
                    case 3:
                        message = beginEncounter + enemy.Name + ", the " + enemy.Species + ", the Barbarian.";
                        break;
                    case 4:
                        message = beginEncounter + enemy.Name + ", the " + enemy.Species + ", the Calamity.";
                        break;
                    case 5:
                        message = beginEncounter + enemy.Name + ", the " + enemy.Species + ", the Demon King.";
                        break;
                    case 6:
                        message = beginEncounter + enemy.Name + ", the " + enemy.Species + ", the Butcher of " + names.getCity() + ".";
                        break;
                    case 7:
                        message = beginEncounter + enemy.Name + ", the " + enemy.Species + ", the Asura.";
                        break;
                    default:
                        message = beginEncounter + enemy.Name + ", the " + enemy.Species + ".";
                        break;
                }
            }

            Console.WriteLine(message);
            Console.WriteLine(enemy.Name + "'s health is " + enemy.HealthPoints);
            Console.WriteLine(enemy.Name + "'s strength is " + enemy.Strength);
            //Console.WriteLine("What would you like to do next?");
            bool encounterDone = false;
            KeywordCommands keywords = new KeywordCommands();
            enemy.HealthPoints = enemy.HealthPoints;
            enemy.Strength = enemy.Strength;
            while (encounterDone == false)
            {
                Console.WriteLine("What would you like to do next?  (type \"help\" for help.)");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string command = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Green;
                if (!(Keywords.keywordsVerify.Contains(command.ToUpper())))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Command.  Type \"help\" for a list of valid commands");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (command == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must enter a command. Type \"help\" for a list of valid commands");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                bool ranAway = false;
                keywords.Commands(command, ref enemy, ref mainCharacter, ref saveData, ref save, ref ranAway, isBoss);
                if (mainCharacter.HealthPoints <= 0)
                {
                    encounterDone = true;
                }
                else if (command == "kill" || command == "fight" || (command == "tame" && ranAway && !(isBoss)) || (command == "flee" && ranAway && !isBoss))
                {
                    encounterDone = true;
                    Console.WriteLine("Your health is now " + mainCharacter.HealthPoints.ToString());
                }
                else
                {

                    Console.WriteLine("You are facing " + enemy.Name);
                    Console.WriteLine(enemy.Name + "'s health is " + enemy.HealthPoints);
                    Console.WriteLine(enemy.Name + "'s strength is " + enemy.Strength);
                }
                if (command == "" || command == "save" || command == "load" || command == "start" || command == "begin" || command == "stats" || command == "keywords" || command == "exit" || command == "reset" || command == "help" || command == "heal" || command == "close" || !(commands.isKeyword(command)))
                {
                    encounterDone = false;
                }
            }
            mainCharacter.score = mainCharacter.score + 1;

            //treamWriter W = new StreamWriter("highScore.json");
            //W.Write(mainCharacter.score);
            //W.Close();

        }
        //Use this to put to start the game from the save data
        public void loadSave()
        {

        }


    }
}
