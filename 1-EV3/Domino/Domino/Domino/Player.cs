﻿using System.ComponentModel.DataAnnotations;

namespace Domino
{
    public abstract class Player
    {
        protected List<Piece> _playerPieces = new();
        protected string _name;
        public string Name
        {
            get { return _name; }
            set { SetName(value); }
        }
        public int PieceCount => _playerPieces.Count;

        public Player(string name)
        {
            if (name == null)
                name = "Uknown";
            Name = name;
        }

        public void SetName(string name)
        {
            if (name != null)
                _name = name;
        }
        public void AddPiece(Piece piece) 
        {
            if (piece != null)
                _playerPieces.Add(piece);
        }

        public Piece? GetPieceAt(int index)
        {
            if (index < 0 || index >= _playerPieces.Count)
                return _playerPieces[index];
            return null;
        }

        public int IndexOf(Piece piece)
        {
            if (piece == null)
                return -1;
            for (int i = 0; i < _playerPieces.Count; i++)
            {
                if (_playerPieces[i] == piece)
                    return i;
            }
            return -1;
        }

        public bool Contains(Piece piece)
        {
            return IndexOf(piece) >= 0;
        }

        public void RemovePiece(Piece piece)
        {
            int index = IndexOf(piece);
            if (index >= 0)
                _playerPieces.RemoveAt(index);
        }

        public List<Piece> GetDoubles()
        {
            return GetDoubles(_playerPieces);
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

        public List<Piece> GetDoublesSorted(List<Piece> list)
        {
            var result = GetDoubles(list);
            Utils.SortPiecesByFirstValue(ref result);
            return result;
        }

        public List<Piece> GetPlayablePieces(Juego juego)
        {
            var result = new List<Piece>();
            var gamePieces = juego.GetAvailablePieces();
            for (int i = 0; i < _playerPieces.Count; i++)
            {
                var playerPieceParts = _playerPieces[i].GetPieceParts();
                for (int j = 0; j < gamePieces.Count; j++)
                {
                    var gamePiece = gamePieces[j];
                    if (gamePiece.ContainsValue(playerPieceParts[0].value) >= 0 || gamePiece.ContainsValue(playerPieceParts[1].value) >= 0)
                    {
                        result.Add(_playerPieces[i]);
                        break;
                    }
                }
            }
            return result;
        }


        public abstract Piece? PickPieceToThrow(Juego juego);

        public virtual void UsePiece(Juego juego)
        {
            var piece = PickPieceToThrow(juego);
            RemovePiece(piece);
            juego.UsePiece(Name, piece);
        }
    }
}