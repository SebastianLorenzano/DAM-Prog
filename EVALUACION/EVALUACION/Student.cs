using System;


namespace EVALUACION
{
    public enum GenderType
    {
        HOMBRE,
        MUJER,
        OTRO
    }
    public class Student
    {
        private string _name = "";
        private int _age;
        private GenderType _gender;
        private double _height, _weight;
        private Notes _notes = new Notes();

        public Student()
        {
            
        }

        public Student(string name, int age)
        {          
            if (IsNameValid(name))
                _name = name;
            if (IsAgeValid(age))
                _age = age;
        }

        public Student(string name, int age, GenderType gender, double height, double weight, Notes notes)
        {
            if (IsNameValid(name))
                _name = name;
            if (IsAgeValid(age))
                _age = age;
            _gender = gender;
            if (IsHeightValid(height))
                _height = height;
            if (IsWeightValid(weight))
                _weight = weight;
            _notes = notes;
        }

        public Student(Student student)
        {
            _name = student.GetName();
            _gender = student.GetGender();
            _height = student.GetHeight();
            _weight = student.GetWeight();
            _notes = student.CloneNotes();
        }

        public string GetName()
        {
            return _name;
        }

        public int GetAge()
        {
            return _age;
        }

        public GenderType GetGender()
        {
            return _gender;
        }

        public double GetHeight()
        {
            return _height;
        }

        public double GetWeight()
        {
            return _weight;
        }

        public void SetName(string name)
        {
            if (IsNameValid(name))
                    _name = name;
        }

        public void SetAge(int age)
        {
            if (IsAgeValid(age))
                _age = age;
        }

        public void SetGender(GenderType gender)
        {
            _gender = gender;
        }

        public void SetHeight(double height)
        {
            _height = height;
        }

        public void SetWeight(double weight)
        {
            _weight = weight;
        }
       
        public static bool IsAgeValid(int age)
        {
            return age > 0 && age < 100;
        }

        public static bool IsNameValid(string name)
        {
            return name != null && name != "";
        }

        public static bool IsHeightValid(double height)
        {
            return height > 0 && height < 4;
        }

        public static bool IsWeightValid(double weight)
        {
            return weight > 0 && weight < 1000;
        }

        public bool IsValid()
        {
            return IsAgeValid(_age) && IsNameValid(_name) && IsHeightValid(_height) && IsWeightValid(_weight);
        }

        public double GetIMC()
        {
            return _weight / (_height * _height);
        }

        public double GetBestMark()
        {
            double result = _notes.GetNoteAt(0).GetMark();
            for (int i = 1; i < _notes.GetNotesCount(); i++)
            {
                if (_notes.GetNoteAt(i).GetMark() > result)
                    result = _notes.GetNoteAt(i).GetMark();
            }
            return result;
        }
        public double GetOverallMark()
        {
            return _notes.GetOverallMark();
        }

        public Note? GetNoteWithAssignature(AssignatureType assignature)
        {
            return _notes.GetNoteWithAssignature(assignature);
        }

        public double GetMarkWithAssignature(AssignatureType assignature)
        {
            return _notes.GetMarkWithAssignature(assignature);
        }

        public void SetMarkForAssignature(AssignatureType assignature, double mark)
        {
            _notes.SetMarkForAssignature(assignature, mark);
        }

        public AssignatureType GetAssignatureWithHigherMark()
        {
            return _notes.GetAssignatureWithHigherMark();
        }

        public AssignatureType GetAssignatureWithLowerMark()
        {
            return _notes.GetAssignatureWithLowerMark();
        }
        public Note GetNoteWithHigherMark()
        {
            return _notes.GetNoteWithHigherMark();
        }

        public Note GetNoteWithLowerMark()
        {
            return _notes.GetNoteWithLowerMark();
        }

        public double GetHigherMark()
        {
            return _notes.GetHigherMark();
        }

        public double GetLowerMark()
        {
            return _notes.GetLowerMark();
        }

        public bool IsAdult()
        {
            return _age >= 18;
        }

        public Notes CloneNotes()
        {
            return _notes.Clone();
        }
        public Student Clone()
        {
            return  new Student(this);
        }


    }
}
