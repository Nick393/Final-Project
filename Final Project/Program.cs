using Final_Project.TemplateClasses;
using System;

namespace Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CharacterTemplate Tom = new CharacterTemplate();
            NameList nameList = new NameList();
            Tom.setName("Kevin");
            Tom.setAlignment("Good");
            Console.WriteLine(Tom.getName());
            Console.WriteLine(Tom.getAlignment());
            Console.WriteLine(Tom.getList(-2).Count);
            foreach (string place in nameList.getList(4))
            {
                Console.WriteLine(place);
            }
        }
    }
}
