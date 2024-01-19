
namespace basura12_12_23
{
    public class Teacher : Person
    {
        public double bloodlust;

        public Teacher() : this(0.7)
            { }
   

        public Teacher(double bloodlust)
        {
            this.bloodlust = bloodlust;
        }

        public Teacher(string name = "", double bloodlust = 0.1) : base()
        {

        }
    }
}
