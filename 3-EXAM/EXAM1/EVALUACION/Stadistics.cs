using System;


namespace EVALUACION
{
    public class ClassroomOverallMarks
    {                                           // los 7 van en la 2da, los 5 en la tercera, los 3 en la cuarta
        public int StudentsHigherThan9;
        public int StudentsBetween9and7;
        public int StudentsBetween7and5;
        public int StudentsBetween5and3;
        public int StudentsBetween3and0;

        public ClassroomOverallMarks(int count1, int count2, int count3, int count4, int count5)
        { 
            StudentsHigherThan9 = count1;
            StudentsBetween9and7 = count2;
            StudentsBetween7and5 = count3;
            StudentsBetween5and3 = count4;
            StudentsBetween3and0 = count5;

        }


    }
    public class Stadistics
    {
        public static double GetAverageIMC(Classroom classroom)
        {
            double result = 0;
            int count = 0;
            for (int i = 0; i < classroom.GetStudentsCount(); i++)
            {
                result += classroom.GetStudentAt(i).GetIMC();
                count++;
            }
            return result / count;
        }

        public static Student GetBestStudent(Classroom classroom)
        {
            Student result = classroom.GetStudentAt(0);
            for (int i = 1; i < classroom.GetStudentsCount();i++)
            {
                if (classroom.GetStudentAt(i).GetBestMark() > result.GetBestMark())
                    result = classroom.GetStudentAt(i);
            }
            return result;
        }

        public static Student GetYoungestStudent(Classroom classroom)
        {
            Student result = classroom.GetStudentAt(0);
            for (int i = 1; i < classroom.GetStudentsCount(); i++)
            {
                if (classroom.GetStudentAt(i).GetAge() < result.GetAge())
                    result = classroom.GetStudentAt(i);
            }
            return result;
        }

        public static List<Student> OrderStudentsByAge(List<Student> list)
        {
            Student aux;
            for (int i = 0; i < list.Count - 1; i++)
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i].GetAge() > list[j].GetAge())
                    {
                        aux = list[i];
                        list[i] = list[j];
                        list[j] = aux;
                    }
                }
            return list;
        }

        public static List<Student> GetStudentsWithGenderOrderedByAge(GenderType gender, Classroom classroom)  // GetStudentsWithGender 
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < classroom.GetStudentsCount(); i++)
                if (classroom.GetStudentAt(i).GetGender() == gender)
                    students.Add(classroom.GetStudentAt(i));
            return OrderStudentsByAge(students);
        }

        public static ClassroomOverallMarks GetStadistics(Classroom classroom)
        {
            int count1 = 0, count2 = 0, count3 = 0, count4 = 0, count5 = 0;
            for (int i = 0; i < classroom.GetStudentsCount(); i++)
            {
                double mark = classroom.GetStudentAt(i).GetOverallMark();
                if (mark >= 9)
                    count1++;
                else if (mark >= 7)
                    count2++;
                else if (mark >= 5)
                    count3++;
                else if (mark >= 3)
                    count4++;
                else count5++;
            }
            return new ClassroomOverallMarks(count1, count2, count3, count4, count5);
        }
    }
}
