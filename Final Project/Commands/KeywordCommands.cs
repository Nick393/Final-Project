using Final_Project.Databases;
using Final_Project.TemplateClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
                string listOfWords = "The keywords used in this game are: ";
                foreach (string word in keyword.operateKeywords)
                {
                    if ((word == "Y") || (word == "N") || (word == ""))
                    {

                    }
                    else if (word != "Stats")
                    {
                        listOfWords += word + ", ";
                    }
                    else
                    {
                        listOfWords += "and " + word;
                    }
                }
                Console.WriteLine(listOfWords);
            }
            

            else if (commandUsed == keyword.ListOfKeywords[8].ToUpper())
            {
                try
                {
                    Process.Start("Final Project.exe");
                    Environment.Exit(1);
                }
                catch 
                {
                    try
                    {
                        Process.Start("Final Project");
                        Environment.Exit(1);
                    }
                    catch { Console.WriteLine("Unknown failure.  Do not rename the executable; possible platform incompatibility"); }
                }
                
            }
            else if ((commandUsed == keyword.ListOfKeywords[13].ToUpper()) || (commandUsed == keyword.ListOfKeywords[14].ToUpper()))
            {
                //Begin/Start
                Console.WriteLine("This command is unavailable during this stage.");
            }
            else if (commandUsed == keyword.ListOfKeywords[15].ToUpper())
            {
                //Load
                Console.WriteLine("This command is unavailable during this stage.");

            }

        }

        public void Commands(string commandUsed, ref MonsterTemplate monster, ref CharacterTemplate mainCharacter, ref SaveData saveData, ref Save save, ref bool ranAway)
        {
            if (mainCharacter.HealthPoints <= 0)
            {
                Console.WriteLine("You lost!"); Console.WriteLine("Press any key to admit defeat");
                Console.ReadKey();
                Environment.Exit(1);
            }
            Keywords keyword = new Keywords();
            commandUsed = commandUsed.ToUpper();
            int probabilityfix = 0;
            if (commandUsed == keyword.ListOfKeywords[0].ToUpper())
            {
                List<PetTemplate> newPets = new List<PetTemplate>();
                newPets = modifyPetHealth(monster.HealthPoints, monster.Strength, mainCharacter);
                mainCharacter.Pets.Clear();
                mainCharacter.Pets = newPets;
                Random rand = new Random();
                int randomizer = rand.Next(0, 101);
                double randomizerPercentage = randomizer / 100;
                double strengthComparison = (mainCharacter.Strength) / (monster.Strength);
                if (strengthComparison >= 1.125)
                {
                    Console.WriteLine("You won the fight against " + monster.Name + " with no injuries!");
                }
                else if (strengthComparison >= 1)
                {
                    double healthLost = monster.Strength * randomizerPercentage * 0.5;
                    int amountLost = (int)(mainCharacter.HealthPoints - healthLost);
                    Console.WriteLine("You won the fight against " + monster.Name + "!");
                    Console.WriteLine("You have lost " + amountLost + " hit points.");
                    mainCharacter.HealthPoints = mainCharacter.HealthPoints - amountLost;
                }
                else
                {
                    if (strengthComparison > randomizerPercentage)
                    {
                        double healthLost = monster.Strength * randomizerPercentage;
                        int amountLost = (int)(mainCharacter.HealthPoints - healthLost);
                        Console.WriteLine("You won the fight against " + monster.Name + "!");
                        Console.WriteLine("You have lost " + amountLost + " hit points.");
                        mainCharacter.HealthPoints = mainCharacter.HealthPoints - amountLost;
                    }
                    else
                    {
                        double healthLost = monster.Strength * randomizerPercentage * 2;
                        int amountLost = (int)(mainCharacter.HealthPoints - healthLost);
                        Console.WriteLine("You lost the fight against " + monster.Name + "!");
                        Console.WriteLine("You have lost " + amountLost + " hit points.");
                        mainCharacter.HealthPoints = mainCharacter.HealthPoints - amountLost;
                    }
                }
                // Console.WriteLine("Your health is now " + mainCharacter.HealthPoints+" hitpoints");
                //Fight

            }
            else if ((commandUsed == keyword.ListOfKeywords[6].ToUpper()) || (commandUsed == keyword.ListOfKeywords[7].ToUpper()))
            {
                string response = "";
                while (response != "Y" || response != "N")
                {
                    //Exit or Close
                    Console.WriteLine("Would you like to Save? Y/N");
                    response = Console.ReadLine().ToUpper();
                    if (response == "Y" || response == "YES")
                    {
                        Console.WriteLine("What would you like to call this save?");
                        string name = Console.ReadLine();
                        Save.saveState(mainCharacter, monster, name);
                        Console.WriteLine("Game saved.  Press any key to continue");
                        Console.ReadKey();
                        Environment.Exit(1);
                        response = "Y";
                    }
                    else if (response == "N" || response == "NO")
                    {
                        response = "N";
                        Console.WriteLine("Game terminated without saving.  Press any key to continue.");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                    else
                    {
                        Console.WriteLine("Unknown response");
                    }
                }
            }
            else if (commandUsed == keyword.ListOfKeywords[17].ToUpper())
            {
                Console.WriteLine("What would you like to call this save?");
                string name = Console.ReadLine();
                //Save
                Save.saveState(mainCharacter, monster, name);
                Console.WriteLine("Game saved.  Press any key to exit.");
                Environment.Exit(1);
            }
            else if (commandUsed == keyword.ListOfKeywords[1].ToUpper())
            {
                //Flee
                /*if (((monster.HealthPoints / 3 > mainCharacter.HealthPoints ) || monster.Strength / 2 > mainCharacter.Strength ))
                {
                    Console.WriteLine(monster.Name + " is too strong. You cannot flee!");
                }
                else
                {
                    Console.WriteLine("You have fled " + monster.Name + "!");
                }*/
                double strengthComparison = (mainCharacter.HealthPoints + mainCharacter.Strength) / (monster.HealthPoints + monster.Strength);
                if (strengthComparison >= 1)
                {
                    Console.WriteLine("You have successfully fled from " + monster.Name + "!");
                    ranAway = true;
                }
                else
                {
                    Random rand = new Random();
                    int duuble = rand.Next(1, 100);
                    double duublePercentage = duuble / 100;
                    if (duublePercentage >= strengthComparison)
                    {
                        Console.WriteLine("You have successfully fled from " + monster.Name + "!");
                        ranAway = true;
                    }
                    else
                    {
                        int amountLost = 0;
                        int duuuble = rand.Next(1, 100);
                        double duuublePercentage = duuuble / 100;
                        double duuubleLost = duuublePercentage * monster.Strength;
                        amountLost = (int)duuubleLost;
                        Console.WriteLine("You have failed to flee from " + monster.Name + "!");
                        Console.WriteLine("You have taken " + amountLost + " damage.");
                        ranAway = false;
                    }
                }

            }
            else if ((commandUsed == keyword.ListOfKeywords[6]) || (commandUsed == keyword.ListOfKeywords[7]))
            {
                string determine = "";
                //Exit or CloseC
                while (determine != "Y" || determine != "N")
                {
                    Console.WriteLine("Would you like to save? (y/n)");
                    determine = Console.ReadLine().ToUpper();
                }
                if (determine == "Y")
                //string determine = Console.ReadLine();
                {
                    Console.WriteLine("What would you like to call this save?");
                    string name = Console.ReadLine();
                    //Save
                    Save.saveState(mainCharacter, monster, name);
                    Console.WriteLine("Game saved.  Press any key to exit");
                    Console.ReadKey();
                    Environment.Exit(1);
                }

            }
            else if (commandUsed == keyword.ListOfKeywords[2].ToUpper())
            {
                //Tame
                if ((monster.HealthPoints > mainCharacter.HealthPoints / 2) || monster.Strength > mainCharacter.Strength / 2)
                {
                    Console.WriteLine("You cannot tame " + monster.Name + ". It is too powerful");
                }
                else
                {
                    Console.WriteLine("You have tamed " + monster.Name);
                    Random rand = new Random();
                    double healthLost = monster.Strength * (rand.Next(1, 11) * 0.1);
                    mainCharacter.HealthPoints = mainCharacter.HealthPoints - healthLost;
                    Console.WriteLine("Unfortunately, you have lost " + healthLost + " hitpoints.");
                    PetTemplate pet = new PetTemplate(monster, mainCharacter);
                    pet.HealthPoints = pet.HealthPoints * 0.75;
                    mainCharacter.Pets.Add(pet);
                    ranAway = true;
                }
            }
            else if (commandUsed == keyword.ListOfKeywords[3].ToUpper())
            {
                int repair = 0;
                int proabilityfix = 0;
                //kill
                try
                {
                    List<PetTemplate> newPets = new List<PetTemplate>();
                    newPets = modifyPetHealth(monster.HealthPoints, monster.Strength, mainCharacter);
                    mainCharacter.Pets.Clear();
                    mainCharacter.Pets = newPets;
                    double probability = ((mainCharacter.HealthPoints + getStrengthValue(mainCharacter) + mainCharacter.Strength) / (monster.HealthPoints + monster.Strength)) * 100;
                    Random rand = new Random();
                    double loseRand = 0;

                    double intprob = (mainCharacter.HealthPoints) / monster.HealthPoints * 100;
                    int intProbPercentage = (int)intprob;
                    if ((mainCharacter.HealthPoints + mainCharacter.Strength) > (monster.HealthPoints + monster.Strength))
                    {
                        loseRand = 7.5;
                    }
                    else
                    {
                        loseRand = rand.Next(0, intProbPercentage);
                    }
                    double random = rand.Next(0, 100);
                    probabilityfix = intProbPercentage;

                    double amountLost = mainCharacter.HealthPoints * (loseRand / 100);
                    if (amountLost > (monster.Strength + monster.HealthPoints))
                    {
                        amountLost = (monster.Strength + monster.HealthPoints) / 5;
                    }
                    mainCharacter.HealthPoints = mainCharacter.HealthPoints - amountLost;
                    if (random > probability)
                    {
                        Console.WriteLine("You Lose!"); Console.WriteLine("press any key to admit defeat!");
                        Console.ReadKey();
                        Console.ReadKey();
                        Environment.Exit(5);
                    }
                    else
                    {
                        Console.WriteLine("You won the fight against " + monster.Name + "!");
                        Console.WriteLine("You have lost " + amountLost + " hitpoints");
                        if (mainCharacter.HealthPoints <= 0)
                        {
                            Console.WriteLine("You lost");
                            Console.WriteLine("press any key to admit defeat");
                            Console.ReadKey();
                            Environment.Exit(1);
                        }

                    }
                }
                catch (Exception ex)
                {
                    Random rand = new Random();

                    int probabilityfixer = probabilityfix + 1;
                    int random = rand.Next(0, probabilityfixer);
                    mainCharacter.HealthPoints = mainCharacter.HealthPoints = random;
                    Console.WriteLine("You have lost " + random + "Hitpoints");
                    //Console.WriteLine(ex);
                    if (mainCharacter.HealthPoints <= 0)
                    {
                        Console.WriteLine("You lost");
                        Console.WriteLine("press any key to admit defeat");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }


                }
            }
            else if (commandUsed == keyword.ListOfKeywords[4].ToUpper())
            {
                //Heal
                int medkitRestoreValue = 50;
                if (mainCharacter.numMedkits != 0)
                {
                    mainCharacter.HealthPoints = mainCharacter.HealthPoints + medkitRestoreValue;
                    mainCharacter.numMedkits = mainCharacter.numMedkits - 1;
                    foreach (PetTemplate pet in mainCharacter.Pets)
                    {
                        pet.HealthPoints = pet.HealthPoints + medkitRestoreValue;
                    }
                    Console.WriteLine("You have been healed! Your new health is " + mainCharacter.HealthPoints + ".  You have " + mainCharacter.numMedkits + " medkits remaining.");
                }
                else
                {
                    Console.WriteLine("Unable to heal! You have no medkits");
                }
            }
            else if (commandUsed == ListOfKeywords[19])
            {
                //cheat
                Console.WriteLine(monster.cheat());
                Console.WriteLine(mainCharacter.cheat());
            }
            else if (commandUsed == keyword.ListOfKeywords[18].ToUpper())
            {
                //Stats
                Console.WriteLine("\n" + mainCharacter.Name + " Statboard" + "\n" + "\n" + "Species: " + mainCharacter.Species + "\n" + "Faction: " + mainCharacter.Alignment + "\n" + "Strength: " + mainCharacter.Strength + "\n" + "Health: " + mainCharacter.HealthPoints + "\n" + "Number of Medkits: " + mainCharacter.numMedkits + "\n");
                foreach (PetTemplate pet in mainCharacter.Pets)
                {
                    Console.WriteLine("\n" + pet.Name + " Statboard" + "\n" + "\n" + "Species: " + pet.Species + "\n" + "Owner: " + mainCharacter.Name + "\n" + "Strength: " + pet.Strength + "\n" + "Health: " + pet.HealthPoints + "\n");
                }
            }
            else
            {
                Commands(commandUsed, ref saveData, ref save);
            }
        }
        public double getStrengthValue(CharacterTemplate mainCharacter)
        {
            double petStrength = mainCharacter.Strength;
            if (mainCharacter.Pets.Count != 0)
            {
                for (int i = 0; i < mainCharacter.Pets.Count; i++)
                {
                    petStrength = petStrength + mainCharacter.Pets[i].Strength;
                }

            }
            else return 0;
            return petStrength;
        }

        public void Commands(string commandUsed, ref CharacterTemplate enemy, ref CharacterTemplate mainCharacter, ref SaveData saveData, ref Save save, ref bool ranAway)
        {

            if (mainCharacter.HealthPoints <= 0)
            {
                Console.WriteLine("You lost!"+" Your final health was "+mainCharacter.HealthPoints); 
                Console.WriteLine("Press any key to admit defeat");
                Console.ReadKey();
                Environment.Exit(1);
            }
            Keywords keyword = new Keywords();
            commandUsed = commandUsed.ToUpper();
            int probabilityfix = 0;
            if (commandUsed == keyword.ListOfKeywords[0].ToUpper())
            {
                List<PetTemplate> newPets = new List<PetTemplate>();
                newPets = modifyPetHealth(enemy.HealthPoints, enemy.Strength, mainCharacter);
                mainCharacter.Pets.Clear();
                mainCharacter.Pets = newPets;
                Random rand = new Random();
                int randomizer = rand.Next(0, 101);
                double randomizerPercentage = randomizer / 100;
                double strengthComparison = ( mainCharacter.Strength) / ( enemy.Strength);
                if (strengthComparison >= 1.125)
                {
                    int doSlightHurt = rand.Next(0, 3);
                    if (doSlightHurt < 3)
                    {
                        int slightHurt = rand.Next(1, 5);
                        mainCharacter.HealthPoints = mainCharacter.HealthPoints - slightHurt;
                        Console.WriteLine("You have won the fight, but have been hurt slightly.  You lost " + slightHurt + " hitpoints.");

                    }
                    else { 
                    Console.WriteLine("You won the fight against " + enemy.Name + " with no injuries!");
                    }
                } else if (strengthComparison >= 1)
                {
                    double healthLost = enemy.Strength * randomizerPercentage * 0.5;
                    int amountLost = (int)(mainCharacter.HealthPoints - healthLost*10);
                    Console.WriteLine("You won the fight against " + enemy.Name + "!");
                    Console.WriteLine("You have lost " + amountLost + " hit points.");
                    mainCharacter.HealthPoints = mainCharacter.HealthPoints - amountLost;
                } else
                {
                    if (strengthComparison > randomizerPercentage)
                    {
                        double healthLost = enemy.Strength * randomizerPercentage;
                        int amountLost = (int)(mainCharacter.HealthPoints - healthLost);
                        Console.WriteLine("You won the fight against " + enemy.Name + "!");
                        Console.WriteLine("You have lost " + amountLost + " hit points.");
                        mainCharacter.HealthPoints = mainCharacter.HealthPoints - amountLost;
                    } else
                    {
                        double healthLost = enemy.Strength * randomizerPercentage * 2;
                        int amountLost = (int)(mainCharacter.HealthPoints - healthLost);
                        Console.WriteLine("You lost the fight against " + enemy.Name + "!");
                        Console.WriteLine("You have lost " + amountLost + " hit points.");
                        mainCharacter.HealthPoints = mainCharacter.HealthPoints - amountLost;
                    }
                }
                /*double probability = (mainCharacter.HealthPoints / enemy.HealthPoints) * 100;
                Random rand = new Random();
                int intprob = (int)probability;
                //int intprob=(int)((mainCharacter.HealthPoints)/(int)monster.HealthPoints)*100;
                int loseRand = rand.Next(0, intprob);
                double realLoseRand = loseRand / 100;
                mainCharacter.HealthPoints = mainCharacter.HealthPoints - realLoseRand;
                double random = rand.Next(0, 101);
                if (random > probability)
                {
                    Console.WriteLine("You lost the fight against " + enemy.Name + "!");
                }
                else
                {
                    Console.WriteLine("You won the fight against " + enemy.Name + "!");
                }
                 Console.WriteLine("Your health is now " + mainCharacter.HealthPoints+" hitpoints");*/
                //Fight

            }
            else if (commandUsed == keyword.ListOfKeywords[17].ToUpper())
            {
                Console.WriteLine("What would you like to call this save?");
                string name = Console.ReadLine();
                //Save
                Save.saveState(mainCharacter, enemy, name);
                Console.WriteLine("Game saved. Press any key to exit.");
                Environment.Exit(1);
            }
            else if (commandUsed == keyword.ListOfKeywords[1].ToUpper())
            {
                //Flee
                double strengthComparison = (mainCharacter.Strength) / (enemy.Strength);
                if (strengthComparison >= 1)
                {
                    Console.WriteLine("You have successfully fled from " + enemy.Name + "!");
                    ranAway = true;
                }
                else
                {
                    Random rand = new Random();
                    int duuble = rand.Next(1, 100);
                    double duublePercentage = duuble / 100;
                    if (duublePercentage >= strengthComparison)
                    {
                        Console.WriteLine("You have successfully fled from " + enemy.Name + "!");
                        ranAway = true;
                    }
                    else
                    {
                        int amountLost = 0;
                        int duuuble = rand.Next(1, 100);
                        double duuublePercentage = duuuble / 100;
                        double duuubleLost = duuublePercentage * enemy.Strength;
                        amountLost = (int)duuubleLost;
                        Console.WriteLine("You have failed to flee from " + enemy.Name + "!");
                        Console.WriteLine("You have taken " + amountLost + " damage.");
                        ranAway = false;
                    }
                }

            }
            else if ((commandUsed == keyword.ListOfKeywords[6]) || (commandUsed == keyword.ListOfKeywords[7]))
            {
                string determine = "";
                //Exit or Close
                while (determine != "Y" || determine != "N")
                {
                    Console.WriteLine("Would you like to save? (y/n)");
                    determine = Console.ReadLine().ToUpper();
                }
                if (determine == "Y")
                //string determine = Console.ReadLine();
                {
                    Console.WriteLine("What would you like to call this save?");
                    string name = Console.ReadLine();
                    //Save
                    Save.saveState(mainCharacter, enemy, name);
                    Console.WriteLine("Game saved.  Press any key to exit");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("Game terminated without saving.  Press any key to continue.");
                    Environment.Exit(1);
                }

            }
            else if (commandUsed == keyword.ListOfKeywords[2].ToUpper())
            {
                Console.WriteLine("You cannot tame a person!");
            }
            else if (commandUsed == keyword.ListOfKeywords[3].ToUpper())
            {
                int repair = 0;
                int proabilityfix = 0;
                //kill
                try
                {
                    List<PetTemplate> newPets = new List<PetTemplate>();
                    newPets = modifyPetHealth(enemy.HealthPoints, enemy.Strength, mainCharacter);
                    mainCharacter.Pets.Clear();
                    mainCharacter.Pets = newPets;
                    double probability = ((getStrengthValue(mainCharacter) + mainCharacter.HealthPoints + mainCharacter.Strength) / (enemy.HealthPoints + enemy.Strength)) * 100;
                    Random rand = new Random();
                    double loseRand = 0;

                    double intprob = (mainCharacter.HealthPoints) / enemy.HealthPoints * 100;
                    int intProbPercentage = (int)intprob;
                    if ((mainCharacter.HealthPoints + mainCharacter.Strength) > (enemy.HealthPoints + enemy.Strength))
                    {
                        loseRand = 7.5;
                    }
                    else
                    {
                        loseRand = rand.Next(0, intProbPercentage);
                    }
                    double random = rand.Next(0, 100);
                    probabilityfix = intProbPercentage;

                    double amountLost = mainCharacter.HealthPoints * (loseRand / 100);
                    if (amountLost > (enemy.Strength + enemy.HealthPoints))
                    {
                        amountLost = (enemy.Strength + enemy.HealthPoints) / 5;
                    }
                    mainCharacter.HealthPoints = mainCharacter.HealthPoints - amountLost;
                    if (random > probability)
                    {
                        Console.WriteLine("You lost!"); Console.WriteLine("Press any key to admit defeat");
                        Console.ReadKey();
                        Console.ReadKey();
                        Environment.Exit(5);
                    }
                    else
                    {
                        Console.WriteLine("You won the fight!");
                        Console.WriteLine("You have lost " + amountLost + " hitpoints");
                        if (mainCharacter.HealthPoints <= 0)
                        {
                            Console.WriteLine("You lost");
                            Console.WriteLine("press any key to admit defeat");
                            Console.ReadKey();
                            Environment.Exit(1);
                        }

                    }
                }
                catch (Exception ex)
                {
                    Random rand = new Random();

                    int probabilityfixer = probabilityfix + 1;
                    int random = rand.Next(0, probabilityfixer);
                    mainCharacter.HealthPoints = mainCharacter.HealthPoints = random;
                    Console.WriteLine("You have lost " + random + "Hitpoints");
                    //Console.WriteLine(ex);
                    if (mainCharacter.HealthPoints <= 0)
                    {
                        Console.WriteLine("You lost");
                        Console.WriteLine("press any key to admit defeat");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }


                }
            }
            else if (commandUsed == keyword.ListOfKeywords[4].ToUpper())
            {
                //Heal
                int medkitRestoreValue = 50;
                if (mainCharacter.numMedkits != 0)
                {
                    mainCharacter.HealthPoints = mainCharacter.HealthPoints + medkitRestoreValue;
                    foreach (PetTemplate pet in mainCharacter.Pets)
                    {
                        pet.HealthPoints = pet.HealthPoints + medkitRestoreValue;
                    }
                    mainCharacter.numMedkits = mainCharacter.numMedkits - 1;
                    Console.WriteLine("You have been healed! Your new health is " + mainCharacter.HealthPoints + ".  You have " + mainCharacter.numMedkits + " medkits remaining.");
                }
                else
                {
                    Console.WriteLine("Unable to heal! You have no medkits");
                }
            }
            else if (commandUsed == ListOfKeywords[19])
            {
                //cheat
                Console.WriteLine(enemy.cheat());
                PetTemplate test = new PetTemplate("bob", "dragon", 34, 1, mainCharacter);
                mainCharacter.Pets.Add(test);
                Console.WriteLine(mainCharacter.cheat());
            }
            else if (commandUsed == keyword.ListOfKeywords[18].ToUpper())
            {
                //Stats
                Console.WriteLine("\n" + mainCharacter.Name + " Statboard" + "\n" + "\n" + "Species: " + mainCharacter.Species + "\n" + "Faction: " + mainCharacter.Alignment + "\n" + "Strength: " + mainCharacter.Strength + "\n" + "Health: " + mainCharacter.HealthPoints + "\n" + "Number of Medkits: " + mainCharacter.numMedkits + "\n");
                Console.WriteLine("Health: " + mainCharacter.HealthPoints);
                Console.WriteLine("Number of Medkits: " + mainCharacter.numMedkits);
                foreach (PetTemplate pet in mainCharacter.Pets)
                {
                    Console.WriteLine("\n" + pet.Name + " Statboard" + "\n" + "\n" + "Species: " + pet.Species + "\n" + "Owner: " + mainCharacter.Name + "\n" + "Strength: " + pet.Strength + "\n" + "Health: " + pet.HealthPoints);
                }
            }
            else
            {
                Commands(commandUsed, ref saveData, ref save);
            }
        }

        public List<PetTemplate> modifyPetHealth(double enemyHp, double enemyStrength, CharacterTemplate character)
        {
            List<PetTemplate> petlist = new List<PetTemplate>();
            if (character.Pets.Count != 0)
            {

                foreach (PetTemplate pet in character.Pets)
                {
                    Random rand = new Random();
                    int hurt = rand.Next(0, (int)(enemyHp + enemyStrength / 2));
                    pet.HealthPoints = pet.HealthPoints - hurt;
                    if (pet.HealthPoints <= 0)
                    {
                        Console.WriteLine("You have lost your pet " + pet.Name);
                    }
                    else
                    {
                        petlist.Add(pet);
                    }
                }
            }
            return petlist;
        }

        public void invalidCommand()
        {
            Console.WriteLine("Please enter a valid Command");
        }

    }
}
