using System;


namespace EVALUACION
{
    public class Notes
    {
        private List<Note> _notesList = new List<Note>();
        public Notes()
        {
            for (int i = 0; i < (int)AssignatureType.COUNT - 1; i++)
            {
                Note note = new Note((AssignatureType)i);
                _notesList.Add(note);
            }
        }

        public Notes(Notes notes)
        {
            for (int i = 0; i < notes.GetNotesCount(); i++)
            {
                _notesList.Add(GetNoteAt(i));   //Preguntar en la proxima clase de programación                                   
            }                                   // como hacer para sacar la linea verde
        }

        public bool IsValid(int index)
        {
            return index >= 0 && index < _notesList.Count;
        }

        public Notes Clone()
        {

            return new Notes(this);
        }
        public int GetNotesCount()
        {
            return _notesList.Count;
        }

        public Note? GetNoteAt(int index)
        {
            if (IsValid(index))
                return _notesList[index];
            return null;
        }

        public Note? GetNoteWithAssignature(AssignatureType assignature)
        {
            for (int i = 0; i < _notesList.Count; i++)
            {
                if (_notesList[i].GetAssignature() == assignature)
                    return _notesList[i];
            }
            return null;
        }

        public double GetMarkWithAssignature(AssignatureType assignature)
        {
            for (int i = 0; i < _notesList.Count; i++)
            {
                if (_notesList[i].GetAssignature() == assignature)
                    return _notesList[i].GetMark();
            }

            return -1;
        }

        public void SetMarkForAssignature(AssignatureType assignature, double mark)
        {
            for (int i = 0; i < _notesList.Count; i++)
            {
                if (_notesList[i].GetAssignature() == assignature)
                     _notesList[i].SetMark(mark);
            }
        }

        public double GetOverallMark()
        {
            int count = 0;
            double result = 0;
            for (int i = 0; i < _notesList.Count; i++)
            {
                result += _notesList[i].GetMark();
                count++;
            }
            return result / count;
        }

        public Note GetNoteWithHigherMark() //la agrege yo
        {
            var note = _notesList[0];
            for (int i = 1; i < _notesList.Count;i++)
            {
                if (_notesList[i].GetMark() > note.GetMark())
                    note = _notesList[i];
            }
            return note;
        }

        public Note GetNoteWithLowerMark() //la agrege yo
        {
            var note = _notesList[0];
            for (int i = 1; i < _notesList.Count; i++)
            {
                if (_notesList[i].GetMark() < note.GetMark())
                    note = _notesList[i];
            }
            return note;
        }

        public AssignatureType GetAssignatureWithHigherMark()
        {
            return GetNoteWithHigherMark().GetAssignature();
        }

        public AssignatureType GetAssignatureWithLowerMark()
        {
            return GetNoteWithLowerMark().GetAssignature();
        }

        public double GetHigherMark()
        {
            return GetNoteWithHigherMark().GetMark();
        }

        public double GetLowerMark()
        {
            return GetNoteWithLowerMark().GetMark();
        }
    }
}

