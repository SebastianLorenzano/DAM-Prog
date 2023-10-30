using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class DominoDeck1
    {
        private List<DominoPiece> _pieceList = new List<DominoPiece>();
        /* Funciones 
    + ExtractPiece(index:int) : DominoPiece             1
    + ExtractPiece(): DominoPiece                       1
    + GetPieceCount(): int                              1
    + AddPiece(piece: DominoPiece)                      
    + ContainsPiece(piece:DominoPiece) bool
    + GetPieceAt(index:int): Piece?                     1
    + Shuffle()

        */
        public DominoPiece? ExtractPiece(int index)
        {
            if (index < 0 || index >= _pieceList.Count)
                return null;
            var piece = _pieceList[index];
            _pieceList.RemoveAt(index);
            return piece;
        }

        public DominoPiece? ExtractPiece()
        {
            var random = Utils.GetRandomInt(1, GetPieceCount());
            return ExtractPiece(random);
        }
        

        public int GetPieceCount()
            { return _pieceList.Count; }


        public DominoPiece? GetPieceAt(int index)
        {
            if (index < 0 || index >= _pieceList.Count)
                return null;
            return _pieceList[index];
        }


    }
}
