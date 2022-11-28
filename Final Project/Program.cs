using Final_Project.Commands;
using Final_Project.Databases;
using Final_Project.TemplateClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {

            CharacterTemplate Tom = new CharacterTemplate("Tom", "Good", "Human");
            NameList nameList = new NameList();
            LocationTemplate location= new LocationTemplate();
            PetTemplate Kevin = new PetTemplate(nameList.getValue(nameList.getList(2)), "Pig", 0, Tom);
            
            Keywords keyword = new Keywords();
            SaveData saveData = new SaveData();
            Save save = new Save();
            string testKeyword = "n";
            Console.WriteLine(Tom.Name);
            Console.WriteLine(Tom.Alignment);
            Console.WriteLine(Tom.getList(-2).Count);
            Console.WriteLine(Tom.HealthPoints);
            Kevin.Name = Kevin.getValue(Kevin.getList(2));
            Console.WriteLine(Kevin.Name);
            saveData.addObject(Kevin);
            saveData.addObject(Tom);
            List<object> save1 = new List<object>();
           save1= saveData.getSaveData();
            Save.SaveObjects(save1);
            
            foreach (string place in nameList.getList(4))
            {
                Console.WriteLine(place);
            }
            if (keyword.isKeyword(testKeyword))
            {
                if (keyword.detectKeyword(testKeyword) == "Save")
                {
                    object data = saveData.getSaveData();

                }
            }
            Console.WriteLine(nameList.getFullName());
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
