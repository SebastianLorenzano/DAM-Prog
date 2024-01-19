

using System.Diagnostics.CodeAnalysis;

namespace basura12_12_23
{
    public class Student : Person
    {
        public long nia;

        public Student(long nia)
        {
            this.nia = nia;
        }

        public Student(string name, long nia) : base(name)
        {

        }




    }
}
