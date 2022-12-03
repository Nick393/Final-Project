using Final_Project.Databases;
using Final_Project.TemplateClasses;
using System;
using System.Collections.Generic;
using Final_Project.Commands;


namespace Final_Project.Commands
{
    class Story
    {
        private List<object> avatars = new List<object>(1);
        private KeywordCommands commands = new KeywordCommands();
        private NameList names = new NameList();
        private SaveData saveData = new SaveData();
        private Save save = new Save();
        public CharacterTemplate createMainCharacter()
        {
            string name = RequestInformation("Name");
            string species = RequestInformation("Species");
            string alignment = RequestInformation("Faction");
            int index = 0;
            const int START_STAGE = 0;
            CharacterTemplate mc = new CharacterTemplate(name, alignment, species, START_STAGE);
            mc.Index = index;
            mc.HealthPoints = 1000;
            mc.Strength = 1000;
            return mc;
        }
        public void startStory(CharacterTemplate mainCharacter)
        {
            Console.WriteLine("Welcome "+mainCharacter.Name+" of the "+mainCharacter.Species+" species.  You are now a member of the "+mainCharacter.Alignment+" side.  We shall now begin!");
        }

        public string RequestInformation(string infoName)
        {
            Console.WriteLine("Please enter your " + infoName);
            string tempReturn = Console.ReadLine();
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
            if ((infoName == "Name") && ((tempReturn.Contains("/")) || (tempReturn.Contains("*"))))
            {
                Console.WriteLine("Please enter a " + infoName + " that is does not contain / or *");
                return RequestInformation(infoName);
            }
            return tempReturn;
        }

        public bool listInputsPrompt(string infoName)
        {
            Console.WriteLine("Would you like to see a list of Valid " + infoName + "? Y/N");
            string test = Console.ReadLine();
            if (commands.isKeyword(test))
            {
                commands.Commands(test, ref saveData, ref save);

            }
            if ((test.ToUpper() == "Y") || (test.ToUpper() == "YES")) { return true; }
            else if ((test.ToUpper() == "N") || (test.ToUpper() == "NO")) { return false; }
            else { return listInputsPrompt(infoName); }
        }

        public object RandomEncounter(int randNum, string mcAlignment, int gameStage)
        {
            if (randNum == 0)
            {

                Random rand = new Random();
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
                return RandomEncounter(multiplier, mcAlignment, gameStage);

            }
            else if (randNum < 0)
            {
                if (Math.Abs(randNum) == 1)
                {
                    //put boss method here
                    const int BUFF_POWER = 3;
                    MonsterTemplate encounter = makeEncounter(BUFF_POWER, gameStage);
                    return encounter;
                }
                else
                {
                    const int BUFF_POWER = 0;
                    MonsterTemplate encounter = makeEncounter(BUFF_POWER, gameStage);
                    return encounter;
                }

            }
            else
            {
                if (Math.Abs(randNum) == 1)
                {
                    //put boss method here
                    const int BUFF_POWER = 3;
                    CharacterTemplate encounter = makeEncounter(BUFF_POWER, gameStage, mcAlignment);
                    return encounter;
                }
                else if (Math.Abs(randNum) < 100)
                {
                    const int BUFF_POWER = 2;
                    CharacterTemplate encounter = makeEncounter(BUFF_POWER, gameStage, mcAlignment);
                    return encounter;
                }
                else if (Math.Abs(randNum) < 10000)
                {
                    const int BUFF_POWER = 1;
                    CharacterTemplate encounter = makeEncounter(BUFF_POWER, gameStage, mcAlignment);
                    return encounter;
                }
                else
                {
                    const int BUFF_POWER = 0;
                    CharacterTemplate encounter = makeEncounter(BUFF_POWER, gameStage, mcAlignment);
                    return encounter;
                }

            }
        }

        public MonsterTemplate makeEncounter(int BUFF_POWER, int gameStage)
        {
            string name = names.getMonsterName();
            string species = names.getMonsterSpecies();
            MonsterTemplate returnMonster = new MonsterTemplate(name, species, BUFF_POWER, gameStage);
            return returnMonster;
        }

        public CharacterTemplate makeEncounter(int BUFF_POWER, int gameStage, string mcAlignment)
        {
            string name = names.getHumanName();
            string species = names.getHumanSpecies();
            string alignment = names.getOpposingFaction(mcAlignment);
            CharacterTemplate returnCharacter = new CharacterTemplate(name, alignment, species, BUFF_POWER, gameStage);
            return returnCharacter;
        }

        public void runEncounter(CharacterTemplate enemy, string mcAlignment, bool isBoss,CharacterTemplate mainCharacter)
        {
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
                    message = beginEncounter + enemy.Name + ", the Destroyer of Worlds, the Demon of" + names.getCity() + ", and the Devourer of Souls" + "." ;
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
            } else
            {
                if (isBoss)
                {
                    message = beginEncounter + enemy.Name + ", the Saint King, the Protector of" + names.getCity() + ", and the Sword of Justice" + ".";
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

            
            bool encounterDone = false;
            KeywordCommands keywords = new KeywordCommands();
            MonsterTemplate monster1 = new MonsterTemplate(enemy.Name, enemy.Species, enemy.Strength, enemy.HealthPoints);
            while (encounterDone == false)
            {
                Console.WriteLine("What would you like to do next?");
                string command = Console.ReadLine();

                keywords.Commands(command, monster1, mainCharacter, ref saveData, ref save);
                if (mainCharacter.HealthPoints <= 0)
                {
                    encounterDone = true;
                }
                else if (command == "kill"||command=="tame"||command=="fight")
                {
                    encounterDone=true;
                }
                Console.WriteLine("Your health is now " + mainCharacter.HealthPoints.ToString());

            }

        }

        public void runEncounter(MonsterTemplate enemy, string mcAlignment, bool isBoss, CharacterTemplate mainCharacter)
        {
            string message = "ERROR MESSAGE, SHOULD NOT BE SHOWN";
            const string beginEncounter = "You have encountered ";
            Random rand = new Random();
            int randomizer = rand.Next(0, 8);
            if (isBoss)
            {
                message = beginEncounter + enemy.Name + ", the " + enemy.Species + ", the Destroyer of Worlds, the Demon of " + names.getCity() + ", and the Devourer of Souls" + ".";
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
            //Console.WriteLine("What would you like to do next?");
            bool encounterDone = false;
            KeywordCommands keywords = new KeywordCommands();
            while (encounterDone == false)
            {
                Console.WriteLine("What would you like to do next?");
                string command = Console.ReadLine();
                keywords.Commands(command,enemy,mainCharacter,ref saveData,ref save);
                if (mainCharacter.HealthPoints <= 0)
                {
                    encounterDone = true;
                }
                else if (command == "kill" || command == "tame")
                {
                    encounterDone = true;
                }
                Console.WriteLine("Your health is now "+mainCharacter.HealthPoints.ToString());
            }
        }
        //Use this to put to start the game from the save data
        public void loadSave()
        {

        }

       
    }
}
