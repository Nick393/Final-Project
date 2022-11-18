using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project.TemplateClasses
{
    class MonsterTemplate : NameList
    {
        private string _Name;
        private string _Race;

        public string Name//gets and sets
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Race
        {
            get { return _Race; }
            set { _Race = value; }
        }
    }
}
