using System;


namespace EVALUACION
{
    public enum AssignatureType
    {
                        // Siempre se puede agregar nuevos enums, y se van a 
                        //  notas automaticamente, pero COUNT debe quedar SIEMPRE
                        // ultima para que funcione el formato
        MATEMATICA,
        CIENCIA,
        HISTORIA,
        LENGUA,
        COUNT
    }

    public class Note
    {
        private AssignatureType _assignature;
        private double _mark;

        public Note(AssignatureType assignature)
        {
            _assignature = assignature;
        }

        public AssignatureType GetAssignature()
        {
            return _assignature;
        }

        public double GetMark()
        {
            return _mark;
        }

        public void SetMark(double mark)
        {
            if (IsValid(mark))
                _mark = mark;
        }

        public bool IsValid(double mark)
        {
            return mark >= 0 && mark <= 10;
        }
    }



    

    

}
