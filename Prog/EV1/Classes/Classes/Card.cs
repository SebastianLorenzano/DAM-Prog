using System;
using System.Diagnostics.Contracts;
using System.Runtime.Intrinsics;

namespace Classes
{

    public enum CardType
    {
         CORAZON,
         DIAMANTE,
         TREBOL,
         PICAS,
         JOKER,
    }

    public enum FigureType
    {
        NONE,
        JACK,
        QUEEN,
        kING,
        AS,
        JOKER,
    }

    public enum ColorType
    {
        RED,
        BLACK,
        NONE,
    }

    public class Card
    {
        private CardType _palo;
        private int _number;


        public Card(int n, CardType p)
        {
            if (IsValid())
            {
                _number = n;
                _palo = p;
            }  
        }

        public bool IsValid()
        {
            return _number >= 2 && _number <= 15;
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
            if (_palo == CardType.CORAZON || _palo == CardType.DIAMANTE)
                return ColorType.RED;
            if (_palo == CardType.TREBOL || _palo == CardType.PICAS)
                return ColorType.BLACK;
            return ColorType.NONE;
        }

        public bool IsFigure()
        {

            return (_number > 10);

        }

        public FigureType GetFigureType()
        {
            if (IsFigure())
            {
                if (_number == 11)
                    return FigureType.JACK;
                if (_number == 12)
                    return FigureType.QUEEN;
                if (_number == 13)
                    return FigureType.kING;
                if (_number == 14)
                    return FigureType.AS;
                if (_number == 15)
                    return FigureType.JOKER;
            }
            return FigureType.NONE;
        }
    }
    }

