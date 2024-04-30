
using System.Security.Permissions;

namespace Model
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Description { get; set; } = string.Empty;

        public static int IsValid(Student student)
        {
            if (student == null)
                return 0;
            if (student.Name == null || student.Name.Length == 0)
                return -1;
            if (student.Age < 0)
                return -2;
            if (student.Description == null)
                return -3;
            return 1;
        }
    }
}
