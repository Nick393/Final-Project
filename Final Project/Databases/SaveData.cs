using Final_Project.TemplateClasses;
using System.Collections.Generic;

namespace Final_Project.Databases
{
    class SaveData
    {
        public List<object> objects = new List<object>();



        public void addObject(CharacterTemplate character)
        {
            objects.Add(character);
        }

        public void addObject(MonsterTemplate Monster)
        {

            objects.Add(Monster);
        }
        public void addObject(PetTemplate Pet)
        {

            objects.Add(Pet);
        }
        public void addObject(LifeformTemplate LifeForm)
        {

            objects.Add(LifeForm);
        }
        public void addObject(LocationTemplate Location)
        {

            objects.Add(Location);
        }
        public List<object> getSaveData()
        {
            return objects;
        }

        public List<object> ListOfObjects
        {
            get { return objects; }
        }
    }
}
