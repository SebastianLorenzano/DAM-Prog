using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IDatabase
    {
        long AddStudent(Student student);
        void RemoveStudent(long id);
        bool UpdateStudent(long id, Student student);
        long GetIdWithStudent(Student student);
        Student? GetStudentWithId(long id);


    }
}
