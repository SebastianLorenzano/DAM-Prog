using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class DominoDeck
    {
        private List<DominoPiece> dominoPieces = new List<DominoPiece>();

        /* Funciones 
            + ExtractPiece(index:int) : DominoPiece
            + ExtractPiece(): DominoPiece
            + GetPieceCount(): int
            + AddPiece(piece: DominoPiece)
            + GetPieceAt(index:int): Piece? 
            + Shuffle()
        */
        public DominoPiece? ExtractPiece(int index)
        {
            if (index < 0 || index >= dominoPieces.Count)
                return null;
            var piece = dominoPieces[index];
            dominoPieces.RemoveAt(index);
            return piece;
        }

        public DominoPiece ExtractPiece()
        {
            int random = Utils.GetRandom(0, dominoPieces.Count() - 1);
            return ExtractPiece(random);
           
        }

        public int? GetPieceCount()
        {
            return dominoPieces.Count;
        }

        public DominoPiece? GetPieceAt(int index)
        {
            if (index < 0 || index >= GetPieceCount())
                return null;
            return dominoPieces[index];
        }

        public void AddPiece(DominoPiece piece)
        {

            dominoPieces.Add(piece);
        }

        public bool ContainsPiece(DominoPiece piece)
        {
            if (piece == null)
                return false;
            for (int i = 0; i < dominoPieces.Count; i++)
                if (dominoPieces[i] == piece)
                    return true;
            return false;
        }

        public void Shuffle();
}
}
