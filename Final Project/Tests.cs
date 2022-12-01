using Final_Project.Commands;
using Final_Project.Databases;
using Final_Project.TemplateClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Project
{
    class Tests
    {
        static void Test(string[] args)
        {
            //declares all of the classes for easy method use
            Save save = new Save();
            Story story = new Story();
            NameList nameList = new NameList();
            Keywords keyword = new Keywords();
            SaveData saveData = new SaveData();
            KeywordCommands commands = new KeywordCommands();

            

           /*List<object> Objects = new List<object>();
            Objects = Save.GetObjects();
            foreach(object obj in Objects)
            {
                Console.WriteLine(obj.ToString());
            }*/
            /*CharacterTemplate Tom = new CharacterTemplate("Tom", "Good", "Human");
            
            LocationTemplate location= new LocationTemplate();
            PetTemplate Kevin = new PetTemplate(nameList.getValue(nameList.getList(2)), "Pig", 0, Tom);
            
            

            
            string testKeyword = "n";


 
            story.createMainCharacter();

            Console.WriteLine(Tom.Name);
            Console.WriteLine(Tom.Alignment);
            Console.WriteLine(Tom.getList(-2).Count);
            Console.WriteLine(Tom.HealthPoints);
            Kevin.Name = Kevin.getValue(Kevin.getList(2));
            Console.WriteLine(Kevin.Name);
            saveData.addObject(Kevin);
            saveData.addObject(Tom);*/
            List<object> save1 = new List<object>();
           save1= saveData.getSaveData();
            Save.SaveObjects(save1);
            
            foreach (string place in nameList.getList(4))
            {
                Console.WriteLine(place);
            }
            /*if (keyword.isKeyword(testKeyword))
            {
                if (keyword.detectKeyword(testKeyword) == "Save")
                {
                    object data = saveData.getSaveData();

                }
            }*/
            Console.WriteLine(nameList.getHumanName());
            Console.WriteLine(nameList.getLocation());
            //make this a method
            /*List<object> characters = new List<object>();
            foreach( string i in objects)
            {
                if (i.Contains("Monster"))
                {
                    MonsterTemplate objectexample = new MonsterTemplate();
                    objectexample.Name = "kevin";
                    characters.Append(objectexample);
                }
                
                
            }*/
        }

    }
}
