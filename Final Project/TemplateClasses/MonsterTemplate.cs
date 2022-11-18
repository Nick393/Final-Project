using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project.TemplateClasses
{
    class MonsterTemplate : NameList
    {
        private string _Name;
        private string _Species;

        public string Name//gets and sets
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Species
        {
            get { return _Species; }
            set { _Species = value; }
        }
        public override string ToString()
        {
            return _Name + "*" + _Species;
        }
    }
}
