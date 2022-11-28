using Final_Project.Databases;
using System;
using System.Collections.Generic;
using System.IO;
using Final_Project.TemplateClasses;
namespace Final_Project.Commands
{
    class Save
    {
        //remember to put path
        //StreamWriter writer = new StreamWriter("save.txt");
        
        //SaveData saveData;


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
           string data= r.ReadToEnd();
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
                    List<Object> error = new List<object>();;
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


