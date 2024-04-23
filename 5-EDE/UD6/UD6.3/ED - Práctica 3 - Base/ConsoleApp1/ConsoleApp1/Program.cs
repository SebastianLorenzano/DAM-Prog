namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Alumnos misAlumnos = new Alumnos();
     
            bool continuar = true;

            do {

                Alumno miAlumno = new Alumno();
                String miAlumnoStr;

                Console.Write("Escribe el nombre del alumno: ");
                miAlumno.Nombre = Convert.ToString(Console.ReadLine());

                Console.Write("Escribe la nota del alumno: ");
                miAlumno.Nota = Convert.ToInt32(Console.ReadLine());

                miAlumnoStr = miAlumno.Nombre + " " + miAlumno.Nota + (miAlumno.Aprobado ? " Aprobado" : " Suspenso");
                Console.Write(miAlumnoStr);
                Console.WriteLine("\n");
                misAlumnos.Agregar(miAlumno);

                Console.Write("¿Deseas continuar metiendo datos? S/N: ");
                continuar = (Convert.ToString(Console.ReadLine()) == "S") ? true : false;
                Console.WriteLine("\n");

            } while (continuar);

        }
    }
}
