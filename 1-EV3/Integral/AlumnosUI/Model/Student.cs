
namespace Model
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Description { get; set; } = string.Empty;

        public static bool IsValid(Student student)
        {
            return student != null && student.Name != null && student.Name != string.Empty && 0 < student.Age && student.Age < 256 && student.Description != null;
        }
    }
}
