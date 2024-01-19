using System.Runtime.Intrinsics.Arm;

namespace ClaseDeObjetos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character c1 = new Character();
            Character c2 = c1;
            Character c3;
            c1.name = "Poli1";

            List<Character> list = new List<Character>();
            list.Add(c1);
            c1 = null;
            c2 = null;
            list.Add(new Character());
            list[1].name = "Ana";
            list[0].name = list[1].name;
            list.Add(list[0]);
            c3 = CharacterUtils.FindObject(list, "Ana");
            Console.WriteLine(c3.name);
        }
    }
}