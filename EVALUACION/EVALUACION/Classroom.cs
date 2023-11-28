using System;


namespace EVALUACION
{
    public class Classroom
    {
        private List<Student> _students = new List<Student>();
        private string _name = "";

        public Classroom()
        {

        }

        public Classroom(List<Student> students)
        {
            _students = students;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            if (name != null && name != "")
                _name = name;
        }
        public int GetStudentsCount()
        {
            return _students.Count;
        }

        public Student? GetStudentAt(int index)
        {
            if (index >= 0 && index < _students.Count)
                return _students[index];
            return null;
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public void RemoveStudentAt(int index)
        {
            if (index >= 0 && index < _students.Count)
            _students.RemoveAt(index);
        }

        public int? GetStudentIndexWithName(string name) //Agregado
        {
            for (int i = 0; i < _students.Count; i++)
            {
                if (_students[i].GetName() == name)
                    return i;
            }
            return null;
        }

        public List<int> GetStudentsIndexWithName(string name) //Agregado
        {
            List<int> result = new List<int>();
            for (int i = 0; i < _students.Count; i++)
            {
                if (_students[i].GetName() == name)
                    result.Add(i);
            }
            return result;
        }

        public bool ContainsStudentWithName(string name)
        {
            return (GetStudentIndexWithName != null);
        }

        public void RemoveStudentsWithName(string name)
        {
            int deleteCount = 0;
            List<int> result = GetStudentsIndexWithName(name);
            for (int i = 0; i < result.Count; i++)
            {
                _students.RemoveAt(result[i] - deleteCount);
                deleteCount++;
            }
        }
    }
}
