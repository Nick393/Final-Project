using Final_Project.TemplateClasses;
using System.Collections.Generic;

namespace Final_Project.Databases
{
    class SaveData
    {
        private List<object> objects = new List<object>();



        public void addObject(CharacterTemplate character)
        {
            objects.Add(character);
        }

        public void addObject(MonsterTemplate Monster)
        {

            objects.Add(Monster);
        }

        public List<object> getSaveData()
        {
            return objects;
        }
    }
}
