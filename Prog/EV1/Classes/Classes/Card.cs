using System;
using System.Diagnostics.Contracts;
using System.Runtime.Intrinsics;

namespace Classes
{

    public enum CardType
    {
         Corazon,
         Diamante,
         Trebol,
         Picas,
         Joker,
    }

    public enum FigureType
    {
        None,
        Jack,
        Queen,
        King,
        As,
        Joker,
    }

    public enum ColorType
    {
        Red,
        Black,
        None,
    }

    public class Card
    {
        private CardType _palo;
        private int _number;


        public Card(int n, CardType p)
        {
            if (n >= 1 || n <= 14)
            {
                _number = n;
                _palo = p;
            }
                
        }


        public bool IsValid()
        {
            if (_number >= 2 && _number <= 15)
                return true;
            return false;
            
        }

        public CardType GetCardType()
        {
            return _palo;
        }

        public int GetNumber()
        {
            return _number;
        }

        public ColorType GetColorType()
        {
            if (_palo == CardType.Corazon || _palo == CardType.Diamante)
                return ColorType.Red;
            if (_palo == CardType.Trebol || _palo == CardType.Picas)
                return ColorType.Black;
            return ColorType.None;
        }

        public bool IsFigure()
        {
            if (_number > 10)
                return true;
            return false;
        }

        public FigureType GetFigureType()
        {
            if (IsFigure())
            {
                if (_number == 11)
                    return FigureType.Jack;
                if (_number == 12)
                    return FigureType.Queen;
                if (_number == 13)
                    return FigureType.King;
                if (_number == 14)
                    return FigureType.As;
                if (_number == 15)
                    return FigureType.Joker;
            }
            return FigureType.None;
        }
    }

    }

