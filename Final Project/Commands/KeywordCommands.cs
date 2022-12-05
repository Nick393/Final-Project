﻿using Final_Project.Databases;
using Final_Project.TemplateClasses;
using System;
using System.Collections.Generic;

namespace Final_Project.Commands
{
    class KeywordCommands : Keywords
    {
        public void Commands(string commandUsed)
        {
            Keywords keyword = new Keywords();

            if (commandUsed == keyword.ListOfKeywords[5])
            {
                //Keywords
            }
            else if ((commandUsed == keyword.ListOfKeywords[6]) || (commandUsed == keyword.ListOfKeywords[7]))
            {
                //Exit or CloseC
                Console.WriteLine("Would you like to save? (y/n)");
                //if(determine=="Y")
                //string determine = Console.ReadLine();
                {

                    //Save.SaveObjects(SaveData.objects);
                }

            }
            else if (commandUsed == keyword.ListOfKeywords[8])
            //Reset
            {

            }
            else if ((commandUsed == keyword.ListOfKeywords[9]) || (commandUsed == keyword.ListOfKeywords[10]))
            {

                //Yes
            }
            //Console.WriteLine("Yes");
            else if (commandUsed == keyword.ListOfKeywords[12] || commandUsed == keyword.ListOfKeywords[11])
            {
                //No
            }
            else if (commandUsed == keyword.ListOfKeywords[13])
            {

            }

            else if (commandUsed == keyword.ListOfKeywords[14])
            {
            }

            else if (commandUsed == keyword.ListOfKeywords[15])
            {
            }

            else if (commandUsed == keyword.ListOfKeywords[16])
            {
            }
            
        }
        public void Commands(string commandUsed, ref SaveData saveData, ref Save save)
        {
            Keywords keyword = new Keywords();
            commandUsed = commandUsed.ToUpper();
            if ((commandUsed == keyword.ListOfKeywords[5].ToUpper()) || commandUsed == keyword.ListOfKeywords[16].ToUpper())
            {
                //Keywords
                string listOfWords = null;
                foreach (string word in keyword.operateKeywords)
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
                List<PetTemplate> newPets = new List<PetTemplate>();
                newPets = modifyPetHealth(monster.HealthPoints, monster.Strength, mainCharacter);
                mainCharacter.Pets.Clear();
                mainCharacter.Pets = newPets;
                double probability = (mainCharacter.HealthPoints / monster.HealthPoints)*100;
                Random rand = new Random();
                int intprob=(int)(mainCharacter.HealthPoints)/(int)monster.HealthPoints;
                int loseRand= rand.Next(0,intprob);
                mainCharacter.HealthPoints = mainCharacter.HealthPoints-loseRand;
                double random=rand.Next(0, 101);

                if(random>probability)
                {
                    Console.WriteLine("You Lose!");
                }
                else
                {
                    Console.WriteLine("You won the fight!");
                }
                Console.WriteLine("Your health is now " + mainCharacter.HealthPoints+" hitpoints");
                //Fight

            }
            else if (commandUsed == keyword.ListOfKeywords[1].ToUpper())
            {
                //Flee
                if (((monster.HealthPoints > mainCharacter.HealthPoints / 3) || monster.Strength > mainCharacter.Strength / 2))
                {
                    Console.WriteLine("This monster is too strong.  You cannot flee!");
                }
                else
                {
                    Console.WriteLine("You have fled " + monster.Name+"!");
                }

            }
            else if (commandUsed == keyword.ListOfKeywords[2].ToUpper())
            {
                //Tame
                if((monster.HealthPoints>mainCharacter.HealthPoints/3)||monster.Strength>mainCharacter.Strength/2)
                {
                    Console.WriteLine("You cannot tame this monster");
                }
                else
                {
                    Console.WriteLine("You have tamed " + monster.Name);
                    double healthLost =  monster.Strength/2;
                    mainCharacter.HealthPoints = mainCharacter.HealthPoints - healthLost;
                    Console.WriteLine("Unfortunately, you have lost " + healthLost+" hitpoints.");
                    PetTemplate pet = new PetTemplate(monster,mainCharacter);
                    pet.HealthPoints = pet.HealthPoints * 0.75;
                    mainCharacter.Pets.Add(pet);
                }
            }
            else if (commandUsed == keyword.ListOfKeywords[3].ToUpper())
            {
                //kill
                try
                {
                    List<PetTemplate> newPets = new List<PetTemplate>();
                    newPets = modifyPetHealth(monster.HealthPoints, monster.Strength, mainCharacter);
                    mainCharacter.Pets.Clear();
                    mainCharacter.Pets = newPets;
                    double probability = ((getStrengthValue(mainCharacter) + mainCharacter.Strength) / (monster.HealthPoints + monster.Strength)) * 100;
                    Random rand = new Random();
                    int randstart=rand.Next(0,50);
                    int randEnd = rand.Next(51, 101);
                    double random = rand.Next((int)randstart, randEnd);
                    int intprob = (int)(mainCharacter.HealthPoints) / (int)monster.HealthPoints;
                    int loseRand = rand.Next((int)randstart, intprob*100);//bug here
                    mainCharacter.HealthPoints = mainCharacter.HealthPoints - loseRand;
                    if (random > probability)
                    {
                        Console.WriteLine("You Lose! Press any key to admit defeat!");
                        Console.ReadKey();
                        Environment.Exit(5);
                    }
                    else
                    {
                        Console.WriteLine("You won the fight!");
                        Console.WriteLine("You have lost " + loseRand + " hitpoints");
                        
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    
                }
            }
            else if (commandUsed == keyword.ListOfKeywords[4].ToUpper())
            {
                //Heal
                int medkitRestoreValue = 50;
                if(mainCharacter.numMedkits!=0)
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
            else return 0;
            return petStrength;
        }
        public List<PetTemplate> modifyPetHealth(double enemyHp, double enemyStrength, CharacterTemplate character)
        {
            List<PetTemplate> petlist = new List<PetTemplate>();
            if(character.Pets.Count!=0)
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
    }
}