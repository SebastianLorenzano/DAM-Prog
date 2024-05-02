namespace Domino
{
    public class DominoDeck
    {
        private List<Piece> _pieces = new();
        public int Count => _pieces.Count;
        public Piece? First => Count > 0 ? _pieces[0] : null;
        public Piece? Last => Count > 0 ? _pieces[Count - 1] : null;
        public Piece? this[int index]
        {
            get => _pieces[index];
            set => _pieces[index] = value;
        }
        
        public DominoDeck()
        {

        }

        public DominoDeck(List<Piece> pieces)
        {
            _pieces = pieces.ToList();
        }

        public void Add(Piece piece)
        {
            if (piece == null)
                return;
            _pieces.Add(piece);
        }

        public void Remove(Piece piece)
        {
            int index = IndexOf(piece);
            if (index >= 0)
                _pieces.RemoveAt(index);
        }


        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _pieces.Count)
                return;
            _pieces.RemoveAt(index);
        }

        public Piece? GetPieceAt(int index)
        {
            if (index >= 0 && index < _pieces.Count)
                return _pieces[index];
            return null;
        }

        public Piece? TakePieceAt(int index)
        {
            if (index >= 0 && index < _pieces.Count)
            {
                Piece result = _pieces[index];
                _pieces.RemoveAt(index);
                return result;
            }
            return null;
        }

        public bool Contains(Piece piece)
        {
            return IndexOf(piece) >= 0;
        }

        public int IndexOf(Piece piece)
        {
            if (piece == null)
                return -1;
            for (int i = 0; i < _pieces.Count; i++)
            {
                if (_pieces[i] == piece)
                    return i;
            }
            return -1;
        }

        public List<Piece> GetDoubles()
        {
            return GetDoubles(_pieces);
        }

        public static List<Piece> GetDoubles(List<Piece> list)
        {
            var result = new List<Piece>();
            var p = list;
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].IsDouble)
                    result.Add(p[i]);
            }
            return result;
        }

        public static List<Piece> GetPiecesSortedByHighestValue(List<Piece> pieces)
        {
            if (pieces == null)
                return new List<Piece>();
            var result = new List<Piece>(pieces);
            for (int i = 0;i < pieces.Count;i++)
            {
                for (int j = i + 1; j < pieces.Count; j++)
                {
                    var r = result;
                    int valueI = r[i].GetValue1() + r[i].GetValue2();
                    int valueJ = r[j].GetValue1() + r[j].GetValue2();
                    if (valueI < valueJ)
                    {
                        var aux = r[i];
                        r[i] = r[j];
                        r[j] = aux;
                    }
                }
            }
            return result;
        }

        public DominoDeck Fill()
        {
            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j <= 6; j++)
                {
                    var piece = Piece.Create(i, j);
                    if (piece != null)
                        _pieces.Add(piece);
                }
            }
            return this;
        }

        public DominoDeck Clone()
        {
            return new DominoDeck(_pieces);
        }

        public List<Piece> ToList()
        {
            return new List<Piece>(_pieces);
          
        }

    }
}
