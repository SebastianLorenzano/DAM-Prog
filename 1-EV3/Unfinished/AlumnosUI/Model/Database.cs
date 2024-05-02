
using System.ComponentModel;
using System.Security.Cryptography;

namespace Model
{
    public class Database : IDatabase
    {
        private static Database _database = new();
        private Dictionary<long, Student> _students = new();
        private long _studentId = 1;

        public static Database Instance => _database;
        public int StudentCount => _students.Count;


        private Database()
        {

        }


        public long AddStudent(Student student)
        {
            long validNum = Student.IsValid(student);
            if (validNum > 0)               // I know nobody really uses it but I wanted to try it out because it appeared in my mind
            {
                student.Id = _studentId++;
                _students.Add(student.Id, student);
                return student.Id;
            }
            return validNum;
        }

        public void RemoveStudent(long id)
        {
            _students.Remove(id);
        }

        public bool UpdateStudent(long id, Student student)
        {
            if (Student.IsValid(student) > 0 && _students.ContainsKey(id))
            {
                student.Id = id;
                _students[id] = student;
                return true;
            }
            return false;
        }

        public Student? GetStudentAt(int index)
        {
            if (0 <= index && index <  _students.Count)
                return _students.ElementAt(index).Value;
            return null;
        }
        public long GetIdWithStudent(Student student)
        {
            foreach (var item in _students) 
            {
                var s1 = item.Value;
                if (s1.Name == student.Name && s1.Age == student.Age && s1.Description == student.Description)
                    return item.Key;
            }
            return -1;
        }

        public Student? GetStudentWithId(long id)
        {
            if (_students.ContainsKey(id))
                return _students[id];
            return null;
        }
    }
}
