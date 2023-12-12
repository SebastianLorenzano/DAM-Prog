using System;


namespace basura12_12_23
{

    public enum GenderType
    {
        MAN,
        FEMALE, 
        OTHER,

    }
    public class Person
    {
        private string _name;
        private GenderType _gender = GenderType.OTHER;

        public string Name
        {
            get { return _name; } set { _name = value; }
        }

        public GenderType Gender
        {
            get 
            { 
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }


        public Person() : this("", GenderType.OTHER)
        {

        }

        public Person(string name, GenderType gender = GenderType.OTHER)
        {
            this._name = name;
            this._gender = gender;


        }
    }
}
