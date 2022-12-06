namespace Final_Project.TemplateClasses
{
    public class LifeformTemplate : NameList
    {
        private string _Name;
        private double _hp;
        private double _strength;
        public string Name//gets and sets
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public double HealthPoints
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public double Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }

    }
}
