using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseDeObjetos
{
    public enum CharacterType
    {
        Police,
        Thief

    }

    public class Character
    {
        public string name = "";
        public CharacterType type = CharacterType.Police;
        public double x = 0.0;
        public double y = 0.0;
        public double size = 1.0;
        double velocity;
    }

    public class CharacterUtils /* Una funcion a la que le paso una lista de personajes y a Anna. 
                                 * El objetivo es que me diga si hay algun personaje llamado Anna en esa lista */
    {
        public static bool Contains(List<Character> list, string name)
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i].name == name)
                    return true;
            return false;
        }

        public static Character FindObject(List<Character> list, string name)   /* Una funcion que me devuelva el primer objeto  que tiene ese nombre en la lista */
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i].name == name)
                    return list[i];
            return null;
        }

        public static bool FindIdentical(List<Character> list) /* Una funcion a la que le paso una lista de 
                                                                * personajes y me devuelve si hay 2 posiciones 
                                                                * apuntando a un mismo objeto */
        {
            for (int i = 0; i < list.Count; i++)
                for (int j = i + 1; j < list.Count; j++)
                    if (list[i] == list[j])
                        return true;
            return false;
        }
    }
}

