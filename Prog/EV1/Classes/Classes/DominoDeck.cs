﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class DominoDeck
    {
        private List<DominoPiece> _pieceList = new List<DominoPiece>();
        /* Funciones                                        1 == hecho    2 == comprobado
    + ExtractPiece(index:int) : DominoPiece             2
    + ExtractPiece(): DominoPiece                       2
    + GetPieceCount(): int                              2
    + AddPiece(piece: DominoPiece)                      2
    + ContainsPiece(piece:DominoPiece) bool             2
    + GetPieceAt(index:int): Piece?                     2
    + Shuffle()                                         2

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
            var random = Utils.GetRandomInt(0, GetPieceCount() - 1);
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

        public int IndexOf(DominoPiece? piece)
        {
            if (piece == null)
                return -1;
            for (int i = 0; i < GetPieceCount(); i++)
            {
                if (piece.IsEqualTo(GetPieceAt(i)))
                    return i;
            }
            return -1;
        }


    public bool ContainsPiece(DominoPiece? piece)
        {
        return (IndexOf(piece) >= 0);
        }

        public void AddPiece(DominoPiece piece)
        {
            if (piece == null)
                return;
            if (ContainsPiece(piece))
                _pieceList.Add(piece);
        }

        public void Shuffle()
        {
            for (int i = 0; i < 50; i++)
            {
                var random1 = Utils.GetRandomInt(0, GetPieceCount() - 1);
                var random2 = Utils.GetRandomInt(0, GetPieceCount() - 1);
                var piece = _pieceList[random2];
                _pieceList[random2] = _pieceList[random1];
                _pieceList[random1] = piece;
                    }
            }
        }

}
    

