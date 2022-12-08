using Final_Project.TemplateClasses;
using System;
using System.Collections.Generic;
using System.IO;
namespace Final_Project.Commands
{
    class Save
    {
        private static object loadCharacter(string fileName)
        {
            List<string> properties = new List<string>();
            StreamReader p = new StreamReader(fileName + " character.csv");
            string PlayerData = p.ReadToEnd();
            int z = 0;
            int index = PlayerData.IndexOf("/");
            string use;
            bool hasPets;
            if (index == 0 || index == -1)
            {
                hasPets = false;
                use = PlayerData;
            }
            else
            {
                hasPets = true;
                use = PlayerData.Substring(0, PlayerData.IndexOf("/"));
            }
            while (use.Contains(","))//this while loop formats each word in a city name beyond the first two.  
            {
                int nextWordLoc = use.IndexOf(",") + 1;//this finds the start of the next word
                if (z == 0)
                {
                    properties.Add(use.Substring(0, nextWordLoc-1));
                }
                //nextWordLoc++;//this sets the location to the first letter of the word
                string tempWordTwo = use.Substring(nextWordLoc);//this stores the full end of the string so it can be fed back to the while loop
                string process;//this variable holds the word while it is being processed
                use = tempWordTwo;
                if (tempWordTwo.Contains(",")) { process = tempWordTwo.Substring(0, tempWordTwo.IndexOf(",")); }//this determines whether the word is the last word in a string and selects the word.
                else { process = tempWordTwo; }//if it is the program doesn't need to remove the ending of the string.

                //string letterOne = process.Substring(0, 1);//this gets the first letter in the word
                //string endOfWord = process.Substring(1);//this gets the end of the word
                //letterOne = letterOne.ToUpper();//this changes the first letter to uppercase.  

                //string rebuiltWord = letterOne + endOfWord;//this reassembles the word

                string save;
                if (tempWordTwo.Contains(","))
                {
                    save = tempWordTwo.Substring(0, tempWordTwo.IndexOf(","));
                }
                else { save = tempWordTwo; }
                properties.Add(save);//this adds the word to the list
                z++;
            }
            foreach (string porperty in properties)
            {
                Console.WriteLine(porperty);
            }
            CharacterTemplate character = new CharacterTemplate();
            character.Name = properties[0];
            character.Alignment = properties[1];
            character.Species = properties[2];
            try
            {
                character.Strength = int.Parse(properties[3]);
            }
            catch { Console.WriteLine("strength was " + properties[3] + " expected int"); }
            //////////////////////////////////////////////////////////
            //Console.WriteLine(properties[4]);
            character.HealthPoints = double.Parse(properties[4]);
            return character;
        }
        private static object loadEnemy(string fileName)
        {
            MonsterTemplate curMonster = new MonsterTemplate();
            List<string> properties = new List<string>();
            //try
            //{
            StreamReader r = new StreamReader(fileName + " enemy.csv");
            string monsterData = r.ReadToEnd();
            int i = 0;
            while (monsterData.Contains(","))//this while loop formats each word in a city name beyond the first two.  
            {
                int nextWordLoc = monsterData.IndexOf(",");//this finds the start of the next word
                if (i == 0)
                {
                    properties.Add(monsterData.Substring(0, nextWordLoc-1));
                }
                nextWordLoc++;//this sets the location to the first letter of the word
                string tempWordTwo = monsterData.Substring(nextWordLoc);//this stores the full end of the string so it can be fed back to the while loop
                string process;//this variable holds the word while it is being processed
                monsterData = tempWordTwo;
                if (tempWordTwo.Contains(",")) { process = tempWordTwo.Substring(0, tempWordTwo.IndexOf(",")); }//this determines whether the word is the last word in a string and selects the word.
                else { process = tempWordTwo; }//if it is the program doesn't need to remove the ending of the string.

                //string letterOne = process.Substring(0, 1);//this gets the first letter in the word
                //string endOfWord = process.Substring(1);//this gets the end of the word
                //letterOne = letterOne.ToUpper();//this changes the first letter to uppercase.  

                //string rebuiltWord = letterOne + endOfWord;//this reassembles the word

                string save;
                if (tempWordTwo.Contains(","))
                {
                    save = tempWordTwo.Substring(0, tempWordTwo.IndexOf(","));
                }
                else { save = tempWordTwo; }
                properties.Add(save);//this adds the word to the list
                i++;




            }
            curMonster.Name = properties[0];
            curMonster.Species = properties[1];
            curMonster.Strength = double.Parse(properties[2]);
            curMonster.HealthPoints = double.Parse(properties[3]);
            r.Close();
            return curMonster;
        }
        private static List<PetTemplate> loadPets(string fileName, int numPets)
        {
            int it = 0;
            List<PetTemplate> pets = new List<PetTemplate>();
            while (it < numPets)
            {
                List<string> properties = new List<string>();
                StreamReader p = new StreamReader(fileName + it + " pet.csv");
                string PlayerData = p.ReadToEnd();
                int z = 0;
                int index = PlayerData.IndexOf("/");
                string use;
                bool hasPets;
                if (index == 0 || index == -1)
                {
                    hasPets = false;
                    use = PlayerData;
                }
                else
                {
                    hasPets = true;
                    use = PlayerData.Substring(0, PlayerData.IndexOf("/"));
                }
                while (use.Contains(","))//this while loop formats each word in a city name beyond the first two.  
                {
                    int nextWordLoc = use.IndexOf(",") + 1;//this finds the start of the next word
                    if (z == 0)
                    {
                        properties.Add(use.Substring(0, nextWordLoc-1));
                    }
                    //nextWordLoc++;//this sets the location to the first letter of the word
                    string tempWordTwo = use.Substring(nextWordLoc);//this stores the full end of the string so it can be fed back to the while loop
                    string process;//this variable holds the word while it is being processed
                    use = tempWordTwo;
                    if (tempWordTwo.Contains(",")) { process = tempWordTwo.Substring(0, tempWordTwo.IndexOf(",")); }//this determines whether the word is the last word in a string and selects the word.
                    else { process = tempWordTwo; }//if it is the program doesn't need to remove the ending of the string.

                    //string letterOne = process.Substring(0, 1);//this gets the first letter in the word
                    //string endOfWord = process.Substring(1);//this gets the end of the word
                    //letterOne = letterOne.ToUpper();//this changes the first letter to uppercase.  

                    //string rebuiltWord = letterOne + endOfWord;//this reassembles the word
                    string save;
                    if(tempWordTwo.Contains(","))
                    {
                        save = tempWordTwo.Substring(0, tempWordTwo.IndexOf(","));
                    }
                    else { save = tempWordTwo; }
                    properties.Add(save);//this adds the word to the list
                    z++;
                }
                foreach (string porperty in properties)
                {
                    Console.WriteLine(porperty+"modifies");
                }
                PetTemplate character = new PetTemplate();
                character.Name = properties[0];

                character.Species = properties[1];
                character.Strength = int.Parse(properties[2]);
                //////////////////////////////////////////////////////////
                //Console.WriteLine(properties[4]);
                character.HealthPoints = double.Parse(properties[3]);
                it++;
            }
            return pets;
        }
        public static List<object> loadState()
        {
            try { 
            StreamReader reader = new StreamReader("names.data");
            List<string> names = new List<string>();

            string path = "names.data";
            var a = File.ReadAllLines(path);
            string[] text = a;
            /*foreach (string s in text)
            {
                Console.WriteLine(s);
            }
            //a.Close();
            //List <string>other=new List<string> ();
            /*try
            {
                int e = 0;
                while(true)
                {
                    
                    
                   string[]data= File.ReadAllLines("names"+e+".data");
                    foreach (string s in data)
                    {
                        other.Add(s);
                    }
                    e++;
                }
            }
            catch (Exception ex)
            {
                return null;
                //do nothing, exception expected
            }*/


            Console.WriteLine("Please pick a save from below.  type exactly as shown.");
            foreach (string line in text)
            {
                Console.WriteLine(line);
            }
            /*foreach (string line in other)
            {
                Console.WriteLine(line);
            }*/

            string fileName = Console.ReadLine();

            for (int g = 0; g < text.Length; g++)
            {

                Console.WriteLine(text[g]);
            }
            object curMonster = loadEnemy(fileName);

            List<object> list = new List<object>();
            list.Add(curMonster);
            CharacterTemplate character = (CharacterTemplate)loadCharacter(fileName);
            int numPets = 0;
            List<PetTemplate> pets = new List<PetTemplate>();
            if (File.Exists(fileName + " numPets.pet"))
            {
                var read = File.OpenText(fileName + " numPets.pet");
                numPets = int.Parse(read.ReadLine());
            }
            if (numPets != 0)
            {
                pets = loadPets(fileName, numPets);
            }
            character.Pets = pets;
            list.Add(character);

            //Console.WriteLine(curMonster.ToString());
            /////////////////////////////////////////
            ///
            /*try
            {

            if (hasPets == true)
            { 
                string petData = PlayerData.Substring(PlayerData.IndexOf("/"));
                if (petData.Contains("*"))

                {
                    string curpet;
                    int length = petData.Length;
                    length--;
                    if (petData.Substring(petData.IndexOf("*" + 1), length).Contains("*"))
                    {

                        List<PetTemplate> listPet = new List<PetTemplate>();
                        while (petData.Contains('*'))
                        {
                            curpet = petData.Substring(1, petData.IndexOf("*" + 1));
                            petData = petData.Substring(petData.IndexOf('*') + 1);

                            List<string> curPetProperties = new List<string>();
                            while (curpet.Contains(","))//this while loop formats each word in a city name beyond the first two.  
                            {


                                int petloc = curpet.IndexOf(",");//this finds the start of the next word
                                if (z == 0)
                                {
                                    curPetProperties.Add(curpet.Substring(0, petloc));
                                }
                                petloc++;//this sets the location to the first letter of the word
                                string tempetloc = curpet.Substring(petloc);//this stores the full end of the string so it can be fed back to the while loop
                                string processpet;//this variable holds the word while it is being processed
                                curpet = tempetloc;
                                if (tempetloc.Contains(",")) { processpet = tempetloc.Substring(0, tempetloc.IndexOf(",")); }//this determines whether the word is the last word in a string and selects the word.
                                else { processpet = tempetloc; }//if it is the program doesn't need to remove the ending of the string.

                                //string letterOne = process.Substring(0, 1);//this gets the first letter in the word
                                //string endOfWord = process.Substring(1);//this gets the end of the word
                                //letterOne = letterOne.ToUpper();//this changes the first letter to uppercase.  

                                //string rebuiltWord = letterOne + endOfWord;//this reassembles the word
                                properties.Add(tempetloc);
                            }
                            PetTemplate thispet = new PetTemplate();
                            thispet.Name = properties[0];
                            thispet.Species = properties[1];
                            thispet.Strength = int.Parse(properties[2]);
                            thispet.HealthPoints = int.Parse(properties[3]);
                            listPet.Add(thispet);


                        }
                        character.Pets = listPet;
                    }
                    else
                    {
                        List<PetTemplate> listPet = new List<PetTemplate>();
                        while (petData.Contains('*'))
                        {
                            curpet = petData.Substring(1, petData.IndexOf("*" + 1));
                            petData = petData.Substring(petData.IndexOf('*') + 1);

                            List<string> curPetProperties = new List<string>();
                            while (curpet.Contains(","))//this while loop formats each word in a city name beyond the first two.  
                            {


                                int petloc = curpet.IndexOf(",");//this finds the start of the next word
                                if (z == 0)
                                {
                                    curPetProperties.Add(curpet.Substring(0, petloc));
                                }
                                petloc++;//this sets the location to the first letter of the word
                                string tempetloc = curpet.Substring(petloc);//this stores the full end of the string so it can be fed back to the while loop
                                string processpet;//this variable holds the word while it is being processed
                                curpet = tempetloc;
                                if (tempetloc.Contains(",")) { processpet = tempetloc.Substring(0, tempetloc.IndexOf(",")); }//this determines whether the word is the last word in a string and selects the word.
                                else { processpet = tempetloc; }//if it is the program doesn't need to remove the ending of the string.

                                //string letterOne = process.Substring(0, 1);//this gets the first letter in the word
                                //string endOfWord = process.Substring(1);//this gets the end of the word
                                //letterOne = letterOne.ToUpper();//this changes the first letter to uppercase.  

                                //string rebuiltWord = letterOne + endOfWord;//this reassembles the word
                                properties.Add(tempetloc);
                            }
                            PetTemplate thispet = new PetTemplate();
                            thispet.Name = properties[0];
                            thispet.Species = properties[1];
                            thispet.Strength = int.Parse(properties[2]);
                            thispet.HealthPoints = int.Parse(properties[3]);
                            listPet.Add(thispet);
                        }
                        character.Pets = listPet;
                    }
                    }
                    list.Add(character);*/
            //return list;
            //}
            return list;

        }

        catch (MissingFieldException)
        {
            Console.WriteLine("Error loading file ");
            return null;
        }
    }

           // catch
            //{
              //  Console.WriteLine("error");
                //return null;
            //}
        
        public static void saveState(CharacterTemplate character, MonsterTemplate monster, string name)
        {
            if (name != "")
            {
                try
                {
                    //StreamWriter n = new StreamWriter("names.data");

                    var a = File.AppendText("names.data");
                    //n.Close();
                    a.WriteLine(name);
                    a.Close();
                }
                catch (Exception e)
                {
                    StreamReader a = new StreamReader("iterator.data");
                    int s = a.Read();
                    a.Close();
                    StreamWriter n = new StreamWriter("names" + a + ".data");
                    n.WriteLine(name);
                    n.Close();
                    s++;
                    File.Delete("iterator.data");
                    StreamWriter w = new StreamWriter("iterator.data");
                    w.Write(s);
                    w.Close();

                }
            }
            //Console.WriteLine("What would you like to call this save?");
            //string name = Console.ReadLine();
            if (!File.Exists(name + " character.csv"))
            {
                StreamWriter w = new StreamWriter(name + " character.csv");
                w.Write(character.Name + "," + character.Alignment + "," + character.Species + "," + character.Strength + "," + character.HealthPoints);
                //w.Write("/");
                if (character.Pets.Count != 0)
                {
                    int iterator = 0;
                    //w.Write("*");
                    foreach (PetTemplate pet in character.Pets)
                    {
                        var petsci=File.CreateText((name + iterator.ToString() + " pet.csv"));
                        //w.Write("*");
                        petsci.Write(pet.Name + "," + pet.Species + "," + pet.Strength + "," + pet.HealthPoints);
                        petsci.Close();
                        iterator++;
                    }
                    var p = File.CreateText(name+" numPets.pet");
                    p.Write(iterator);
                    p.Close();
                }
                w.Close();

            }
            else
            {
                StreamWriter w = new StreamWriter(DateTime.Now.ToString() + " " + name + " character.csv");
                w.Write(character.Name + "," + character.Alignment + "," + character.Species + "," + character.Strength + "," + character.HealthPoints);
                if (character.Pets.Count != 0)
                {
                    w.Write("/");
                    int iterator = 0;
                    foreach (PetTemplate pet in character.Pets)
                    {
                        File.CreateText((DateTime.Now.ToString() + " " + name + iterator + " pet.csv"));
                        //w.Write(pet.Name + "," + pet.Species + "," + pet.Strength + "," + pet.HealthPoints);
                        iterator++;
                    }
                    var p = File.CreateText(DateTime.Now.ToString() + " " + name + " numPets.pet");
                    p.Write(iterator);
                    p.Close();
                }
                w.Close();

            }
            if (!File.Exists(name + "enemy.csv"))
            {
                StreamWriter m = new StreamWriter(name + " enemy.csv");
                m.Write(monster.Name + "," + monster.Species + "," + monster.Strength + "," + monster.HealthPoints);
                m.Close();
            }
            else
            {
                StreamWriter m = new StreamWriter(DateTime.Now.ToString() + " " + name + " enemy.csv");
                m.Write(monster.Name + "," + monster.Species + "," + monster.Strength + "," + monster.HealthPoints);
                m.Close();
            }
        }
        //remember to put path
        //StreamWriter writer = new StreamWriter("save.txt");

        //SaveData saveData;
        public static void saveState(CharacterTemplate character, CharacterTemplate enemy, string name)
        {
            if (name != "")
            {
                try
                {
                    //StreamWriter n = new StreamWriter("names.data");

                    var a = File.AppendText("names.data");
                    //n.Close();
                    a.WriteLine(name);
                    a.Close();
                }
                catch (Exception e)
                {
                    StreamReader a = new StreamReader("iterator.data");
                    int s = a.Read();
                    a.Close();
                    StreamWriter n = new StreamWriter("names" + a + ".data");
                    n.WriteLine(name);
                    n.Close();
                    s++;
                    File.Delete("iterator.data");
                    StreamWriter w = new StreamWriter("iterator.data");
                    w.Write(s);
                    w.Close();

                }
            }
            //Console.WriteLine("What would you like to call this save?");
            //string name = Console.ReadLine();
            if (!File.Exists(name + " character.csv"))
            {
                StreamWriter w = new StreamWriter(name + " character.csv");
                w.Write(character.Name + "," + character.Alignment + "," + character.Species + "," + character.Strength + "," + character.HealthPoints);
                //w.Write("/");
                if (character.Pets.Count != 0)
                {
                    int iterator = 0;
                    //w.Write("*");
                    foreach (PetTemplate pet in character.Pets)
                    {
                        var petsci = File.CreateText((name + iterator + " pet.csv"));
                        //w.Write("*");
                        petsci.Write(pet.Name + "," + pet.Species + "," + pet.Strength + "," + pet.HealthPoints);
                        iterator++;
                    }
                    var p = File.CreateText(name+" numPets.pet");
                    p.Write(iterator);
                    p.Close();
                }
                w.Close();

            }
            else
            {
                StreamWriter w = new StreamWriter(DateTime.Now.ToString() + " " + name + " character.csv");
                w.Write(character.Name + "," + character.Alignment + "," + character.Species + "," + character.Strength + "," + character.HealthPoints);
                if (character.Pets.Count != 0)
                {
                    w.Write("/");
                    int iterator = 0;
                    foreach (PetTemplate pet in character.Pets)
                    {
                        File.CreateText((DateTime.Now.ToString() + " " + name + iterator + " pet.csv"));
                        //w.Write(pet.Name + "," + pet.Species + "," + pet.Strength + "," + pet.HealthPoints);
                        iterator++;
                    }
                    var p = File.CreateText(DateTime.Now.ToString() + " " + name + " numPets.pet");
                    p.Write(iterator);
                    p.Close();
                }
                w.Close();

            }
            if (!File.Exists(name + "enemy.csv"))
            {
                StreamWriter m = new StreamWriter(name + " enemy.csv");
                m.Write(enemy.Name + "," + enemy.Species + "," + enemy.Strength + "," + enemy.HealthPoints);
                m.Close();
            }
            else
            {
                StreamWriter m = new StreamWriter(DateTime.Now.ToString() + " " + name + " enemy.csv");
                m.Write(enemy.Name + "," + enemy.Species + "," + enemy.Strength + "," + enemy.HealthPoints);
                m.Close();
            }
        }

        public static void SaveObjects(List<object> objects)
        {
            StreamWriter stream = new StreamWriter("save.txt");
            foreach (object obj in objects)
            {

                stream.Write(obj.ToString() + "/");

            }
            stream.Close();
        }


        public static List<object> GetObjects()//this method formats the strings for output
        {
            StreamReader r = new StreamReader("save.txt");
            string data = r.ReadToEnd();
            string st = data;
            try
            {
                string lastLetterOfInput = st.Substring(st.Length - 1);

                if (lastLetterOfInput == "/")
                {
                    while (lastLetterOfInput == "/")
                    {

                        int len = st.Length - 1;
                        st = st.Substring(0, len);
                        lastLetterOfInput = st.Substring(st.Length - 1);
                    }



                }


                string Letter1 = st.Substring(0, 1);//this gets the first letter of the string.  
                string lastLetters = st.Substring(1);//this gets the end of the string
                Letter1 = Letter1.ToUpper();//this changes the first letter to uppercase
                lastLetters = lastLetters.ToLower();//this changes all following letters to lowercase
                string CityName = Letter1 + lastLetters;//this recreates the string, now formatted properly.  

                string finalWord;
                List<string> wordsList = new List<string>();//this list contains the words within each city name during processing.  

                string subWord;
                if (CityName.Contains("/"))//this ensures that the word is isolated
                {
                    subWord = CityName.Substring(0, CityName.IndexOf("/"));
                }
                else
                {
                    subWord = CityName;
                }
                wordsList.Add(subWord);
                if (CityName.Contains("/"))//handles two word names
                {
                    int secondwordLoc = CityName.IndexOf("/");//finds the space in the city name
                    secondwordLoc++;//moves the location forward one space
                    string secondWord = CityName.Substring(secondwordLoc);//pulls the second word from the string
                    if (secondWord.Contains("/"))//this ensures that the second word is isolated from the rest of the string
                    {
                        subWord = secondWord.Substring(0, secondWord.IndexOf("/"));
                    }
                    else
                    {
                        subWord = secondWord;
                    }
                    string fLetterSecondWd = subWord.Substring(0, 1);//gets the first letter
                    string lLetterSecondWd = subWord.Substring(1);//gets the rest of the word
                    fLetterSecondWd = fLetterSecondWd.ToUpper();//makes the first letter capitalized
                    string fstWd = CityName.Substring(0, secondwordLoc);//gets the first word so it can be appended
                    string scndWd = fLetterSecondWd + lLetterSecondWd;//rebuilds the second word
                    string twoWd = fstWd + scndWd;//reattaches the two words
                    finalWord = twoWd;//sets the output to the combined words
                    wordsList.Add(scndWd);//adds the second word to the list

                    if (secondWord.Contains("/"))//this loop handles all further words in the city name
                    {

                        string nextWord = secondWord;//this gives the nextWord variable an initial vale of the second word from the first block

                        while (nextWord.Contains("/"))//this while loop formats each word in a city name beyond the first two.  
                        {
                            int nextWordLoc = nextWord.IndexOf("/");//this finds the start of the next word

                            nextWordLoc++;//this sets the location to the first letter of the word
                            string tempWordTwo = nextWord.Substring(nextWordLoc);//this stores the full end of the string so it can be fed back to the while loop
                            string process;//this variable holds the word while it is being processed
                            nextWord = tempWordTwo;
                            if (tempWordTwo.Contains("/")) { process = tempWordTwo.Substring(0, tempWordTwo.IndexOf("/")); }//this determines whether the word is the last word in a string and selects the word.
                            else { process = tempWordTwo; }//if it is the program doesn't need to remove the ending of the string.

                            string letterOne = process.Substring(0, 1);//this gets the first letter in the word
                            string endOfWord = process.Substring(1);//this gets the end of the word
                            letterOne = letterOne.ToUpper();//this changes the first letter to uppercase.  

                            string rebuiltWord = letterOne + endOfWord;//this reassembles the word

                            wordsList.Add(rebuiltWord);//this adds the word to the list



                        }
                        finalWord = "";//ensures that the finalWord variable is empty
                        List<string> objList = new List<string>();
                        List<object> outObjects = new List<object>();
                        List<Single> d3 = new List<Single>();
                        List<List<Single>> d2 = new List<List<Single>> { d3 };
                        foreach (string item in wordsList)//assembles the final output
                        {

                            string nextobj = item;
                            while (nextobj.Contains("*"))//this while loop formats each word in a city name beyond the first two.  
                            {
                                int nextWordLoc = nextobj.IndexOf("*");//this finds the start of the next word

                                nextWordLoc++;//this sets the location to the first letter of the word
                                string tempWordTwo = nextobj.Substring(nextWordLoc);//this stores the full end of the string so it can be fed back to the while loop
                                string process;//this variable holds the word while it is being processed
                                nextobj = tempWordTwo;
                                if (tempWordTwo.Contains("*")) { process = tempWordTwo.Substring(0, tempWordTwo.IndexOf("*")); }//this determines whether the word is the last word in a string and selects the word.
                                else { process = tempWordTwo; }//if it is the program doesn't need to remove the ending of the string.

                                string letterOne = process.Substring(0, 1);//this gets the first letter in the word
                                string endOfWord = process.Substring(1);//this gets the end of the word
                                letterOne = letterOne.ToUpper();//this changes the first letter to uppercase.  

                                string rebuiltWord = letterOne + endOfWord;//this reassembles the word

                                objList.Add(rebuiltWord);//this adds the word to the list


                            }
                            if (objList.Contains("Character"))
                            {
                                CharacterTemplate Character = new CharacterTemplate();
                                Character.Name = objList[1];
                                Character.HealthPoints = int.Parse(objList[2]);
                                Character.Species = objList[3];
                                Character.Strength = int.Parse(objList[4]);
                                outObjects.Add(Character);
                            }
                            else if (objList.Contains("Monster"))
                            {
                                MonsterTemplate monster = new MonsterTemplate();
                                monster.Name = objList[1];
                                monster.HealthPoints = int.Parse(objList[2]);
                                monster.Species = objList[3];
                                monster.Strength = int.Parse(objList[4]);
                                outObjects.Add(monster);

                            }
                            else if (objList.Contains("Pet"))
                            {
                                PetTemplate pet = new PetTemplate();
                                pet.Name = objList[1];
                                pet.HealthPoints = int.Parse(objList[2]);
                                pet.Species = objList[3];
                                pet.Strength = int.Parse(objList[4]);
                                outObjects.Add(pet);

                            }
                            else if (objList.Contains("Location"))
                            {
                                LocationTemplate location = new LocationTemplate();
                                //finish when class is done
                                outObjects.Add(location);

                            }

                            //d2.Add(objList)
                        }
                        return outObjects;//returns the two words formatted
                    }
                    else
                    {
                        List<Object> error = new List<object>();
                        return error;//this returns the new string.
                    }
                }
                else
                {
                    List<Object> error = new List<object>(); ;
                    return error;//this returns the new string.
                }
            }
            catch (NullReferenceException)//this catches a specific error I received
            {
                List<Object> error = new List<object>();
                return error;
            }

        }
    }
}


