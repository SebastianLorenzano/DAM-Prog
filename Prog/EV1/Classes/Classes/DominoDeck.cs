using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class DominoDeck
    {
        private List<DominoPiece> dominoPieces;
    
        /* que compare fichas para ver si son compatibles */

        public DominoPiece ExtractPiece(int index)
        {   
            DominoPiece piece = dominoPieces[index];
            dominoPieces.RemoveAt(index);
            return piece;
        }

        public DominoPiece ExtractPiece()
        {
            int value1 = 0, value2 = dominoPieces.Count - 1;
            int random = Utils.GetRandom(value1, value2);
            return ExtractPiece(random);
           
        }

        public int? GetPieceCount(int value)
        {
            return dominoPieces.Count;
        }

        public DominoPiece? GetPieceAt(int index)
        {
            if (index < 0 || index >= dominoPieces.Count)
                return null;
            return dominoPieces[index];
        }

        public void AddPiece(DominoPiece piece)
        {

            dominoPieces.Add(piece);
        }

        public void Shuffle();
}
}
