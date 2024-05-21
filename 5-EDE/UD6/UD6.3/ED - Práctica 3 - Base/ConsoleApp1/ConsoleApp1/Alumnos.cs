using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Alumno
    {
        private string nombre;
        private int nota;

        public string Nombre { get => nombre; set { nombre = value; } }
        public int Nota
        {
            get => nota;
            set
            {
                if (value >= 0 && value <= 10)
                    nota = value;
            }
        }
        public Boolean Aprobado => nota >= 5;
    }

    public class Alumnos
    {
        private ArrayList listaAlumnos = new ArrayList();

        public int Count => listaAlumnos.Count;
        // Agrega un nuevo alumno a la lista
        //        
        public void Agregar(Alumno alu)
        {
            listaAlumnos.Add(alu);
        }
        // Devuelve el alumno que está en la posición num
        //
        public Alumno Obtener(int num)
        {
            //modificación código
            if (listaAlumnos.Count == 0)
                return null;
            if (num >= 0 && num < listaAlumnos.Count) // modificación código, se modifico num <= listaAlumnos.Count por num < listaAlumnos.Count
                return ((Alumno)listaAlumnos[num]);
            return null;
        }

        // Devuelve la nota media de los alumnos
        //
        public float Media
        {
            get
            {
                if (listaAlumnos.Count == 0)
                    return 0;
                else
                {
                    float media = 0;
                    for (int i = 0; i < listaAlumnos.Count; i++)
                    {
                        media += ((Alumno)listaAlumnos[i]).Nota;
                    }
                    return (media / listaAlumnos.Count);
                }
            }
        }

        public void Imprimir()
        {
            for (int i = 0; i < Count; i++)
            {
                var alum = (Alumno)listaAlumnos[i];
                var aprobado = "No";
                if (alum.Aprobado)
                    aprobado = "Si";
                Console.WriteLine("Nombre: " + alum.Nombre);
                Console.WriteLine("Nota: " + alum.Nota);
                Console.WriteLine("Aprobado: " + aprobado);
                Console.WriteLine();
            }
        }
    }
}