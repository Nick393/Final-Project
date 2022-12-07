using Final_Project.Databases;
using Final_Project.TemplateClasses;
using System;
using System.Collections.Generic;

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
            else if ((commandUsed == keyword.ListOfKeywords[6].ToUpper()) || (commandUsed == keyword.ListOfKeywords[7].ToUpper()))
            {
                //Exit or Close
                Console.WriteLine("Would you like to Save? Y/N");
                string response = Console.ReadLine().ToUpper();
                if (response == "Y" || response == "YES")
                {
                    Commands("Save", ref saveData, ref save);
                }
                else if (response == "N" || response == "NO")
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
                Console.WriteLine("Please enter the file name exactly.");
                Save.loadState();

            }
            else if (commandUsed == keyword.ListOfKeywords[18].ToUpper())
            {
                //Stats
            }
        }

        public void Commands(string commandUsed,ref MonsterTemplate monster, ref CharacterTemplate mainCharacter, ref SaveData saveData, ref Save save)
        {
            if (mainCharacter.HealthPoints <= 0)
            {
                Console.WriteLine("You lost!"); Console.WriteLine("Press any key to admit defeat");
                Console.ReadKey();
                Environment.Exit(0);
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
                double probability = (mainCharacter.HealthPoints / monster.HealthPoints) * 100;
                Random rand = new Random();
                int intprob = (int)probability;
                //int intprob=(int)((mainCharacter.HealthPoints)/(int)monster.HealthPoints)*100;
                int loseRand = rand.Next(0, intprob);
                mainCharacter.HealthPoints = mainCharacter.HealthPoints - loseRand;
                double random = rand.Next(0, 101);

                if (random > probability)
                {
                    Console.WriteLine("You Lost the fight against " + monster.Name + "!");
                }
                else
                {
                    Console.WriteLine("You won the fight againt " + monster.Name + "!");
                }
                // Console.WriteLine("Your health is now " + mainCharacter.HealthPoints+" hitpoints");
                //Fight

            }
            else if (commandUsed == keyword.ListOfKeywords[17].ToUpper())
            {
                Console.WriteLine("What would you like to call this save?");
                string name = Console.ReadLine();
                //Save
                Save.saveState(mainCharacter, monster, name);
                Console.WriteLine("Game saved.  Press any key to exit.");
                Environment.Exit(0);
            }
            else if (commandUsed == keyword.ListOfKeywords[1].ToUpper())
            {
                //Flee
                if (((monster.HealthPoints > mainCharacter.HealthPoints / 3) || monster.Strength > mainCharacter.Strength / 2))
                {
                    Console.WriteLine(monster.Name + " is too strong. You cannot flee!");
                }
                else
                {
                    Console.WriteLine("You have fled " + monster.Name + "!");
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
                    Environment.Exit(0);
                }

            }
            else if (commandUsed == keyword.ListOfKeywords[2].ToUpper())
            {
                //Tame
                if ((monster.HealthPoints > mainCharacter.HealthPoints / 3) || monster.Strength > mainCharacter.Strength / 2)
                {
                    Console.WriteLine("You cannot tame " + monster.Name + ". It is too powerful");
                }
                else
                {
                    Console.WriteLine("You have tamed " + monster.Name);
                    double healthLost = monster.Strength / 2;
                    mainCharacter.HealthPoints = mainCharacter.HealthPoints - healthLost;
                    Console.WriteLine("Unfortunately, you have lost " + healthLost + " hitpoints.");
                    PetTemplate pet = new PetTemplate(monster, mainCharacter);
                    pet.HealthPoints = pet.HealthPoints * 0.75;
                    mainCharacter.Pets.Add(pet);
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
                        Console.WriteLine("You won the fight against " + monster.Name+ "!");
                        Console.WriteLine("You have lost " + amountLost + " hitpoints");
                        if (mainCharacter.HealthPoints <= 0)
                        {
                            Console.WriteLine("You lost");
                            Console.WriteLine("press any key to admit defeat");
                            Console.ReadKey();
                            Environment.Exit(0);
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
                        Environment.Exit(0);
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

        public void Commands(string commandUsed, ref CharacterTemplate enemy,ref CharacterTemplate mainCharacter, ref SaveData saveData, ref Save save)
        {
            
            if (mainCharacter.HealthPoints <= 0)
            {
                Console.WriteLine("You lost!"); Console.WriteLine("Press any key to admit defeat");
                Console.ReadKey();
                Environment.Exit(0);
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
                double probability = (mainCharacter.HealthPoints / enemy.HealthPoints) * 100;
                Random rand = new Random();
                int intprob = (int)probability;
                //int intprob=(int)((mainCharacter.HealthPoints)/(int)monster.HealthPoints)*100;
                int loseRand = rand.Next(0, intprob);
                mainCharacter.HealthPoints = mainCharacter.HealthPoints - loseRand;
                double random = rand.Next(0, 101);

                if (random > probability)
                {
                    Console.WriteLine("You lost the fight against" + enemy.Name + "!");
                }
                else
                {
                    Console.WriteLine("You won the fight against "+enemy.Name+"!");
                }
                // Console.WriteLine("Your health is now " + mainCharacter.HealthPoints+" hitpoints");
                //Fight

            }
            else if (commandUsed == keyword.ListOfKeywords[17].ToUpper())
            {
                Console.WriteLine("What would you like to call this save?");
                string name = Console.ReadLine();
                //Save
                Save.saveState(mainCharacter, enemy, name);
                Console.WriteLine("Game saved. Press any key to exit.");
                Environment.Exit(0);
            }
            else if (commandUsed == keyword.ListOfKeywords[1].ToUpper())
            {
                //Flee
                if (((enemy.HealthPoints > mainCharacter.HealthPoints / 3) || enemy.Strength > mainCharacter.Strength / 2))
                {
                    Console.WriteLine(enemy.Name + " is too strong. You cannot flee!");
                }
                else
                {
                    Console.WriteLine("You have fled " + enemy.Name + "!");
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
                    Save.saveState(mainCharacter, enemy, name);
                    Console.WriteLine("Game saved.  Press any key to exit");
                    Console.ReadKey();
                    Environment.Exit(0);
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
                    double probability = ((getStrengthValue(mainCharacter)+ mainCharacter.HealthPoints + mainCharacter.Strength) / (enemy.HealthPoints + enemy.Strength)) * 100;
                    Random rand = new Random();
                    double loseRand = 0;

                    double intprob = (mainCharacter.HealthPoints) / enemy.HealthPoints * 100;
                    int intProbPercentage = (int)intprob;
                    if ((mainCharacter.HealthPoints + mainCharacter.Strength) > (enemy.HealthPoints + enemy.Strength))
                    {
                        loseRand = 7.5;
                    } else
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
                            Environment.Exit(0);
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
                        Environment.Exit(0);
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