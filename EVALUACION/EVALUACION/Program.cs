namespace EVALUACION
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Classroom classroom = new Classroom();
            Notes notes = new Notes();
            notes.GetNoteAt(0).SetMark(10);
            notes.GetNoteAt(1).SetMark(9);
            notes.GetNoteAt(2).SetMark(8);

            Student student = new Student("Sebastian", 18, GenderType.HOMBRE, 1.775, 85, notes);
            Student student2 = new Student("Sebastian", 18, GenderType.HOMBRE, 1.775, 500, notes);
            Student student3 = new Student("Sebastian", 18, GenderType.HOMBRE, 1.775, 85, notes);
            Student student1 = new Student("Jorge", 24, GenderType.HOMBRE, 1.80, 75, notes);
            classroom.AddStudent(student);
            classroom.AddStudent(student1);
            classroom.AddStudent(student3);
            classroom.AddStudent(student2);
            Console.WriteLine(Stadistics.GetStudentsWithGenderOrderedByAge);
            Console.WriteLine(classroom.GetStudentAt(0).GetIMC());
            Console.WriteLine(Stadistics.GetYoungestStudent(classroom).GetName());
            Console.WriteLine(Stadistics.GetAverageIMC(classroom));
            Console.Write(Stadistics.GetStudentsWithGenderOrderedByAge(GenderType.HOMBRE, classroom)[0].GetName());
            Console.Write(Stadistics.GetStudentsWithGenderOrderedByAge(GenderType.HOMBRE, classroom)[1].GetName());
            Console.WriteLine(student.GetAssignatureWithHigherMark());
            Console.WriteLine(student.GetAssignatureWithLowerMark());
            Console.WriteLine(Stadistics.GetAverageIMC(classroom));
            classroom.RemoveStudentsWithName("Sebastian");
            Console.WriteLine(classroom.GetStudentAt(0).GetName());
            Console.WriteLine(Stadistics.GetAverageIMC(classroom));
        }
    }
}