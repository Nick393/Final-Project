using Final_Project.TemplateClasses;
using System;

namespace Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {
           
            CharacterTemplate Tom = new CharacterTemplate("Kevin", "Good");
            NameList nameList = new NameList();
            
            Console.WriteLine(Tom.name);
            Console.WriteLine(Tom.Alignment);
            Console.WriteLine(Tom.getList(-2).Count);
            foreach (string place in nameList.getList(4))
            {
                Console.WriteLine(place);
            }
        }
    }
}
