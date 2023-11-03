using System;

namespace Classes
{
    public class ChessUtils
    {
        public static bool IsOnTheTable(int x, int y)
        {
            return x >= 1 && x <= 8 && y >= 1 && y <= 8;
        
        }

        public static ChessFigure? GetFigureAt(int x, int y /*, List<ChessFigure> figures */)
        {
            return null;
        }

        List<ChessFigure> figures;



        // GetFigureAt
        public static bool CanTowerMoveTo(ChessFigure figure, int TargetX, int TargetY /*, List<ChessFigure> figures */)
        {
            List<ChessFigure> list;
        
            int x = figure.GetX();
            int y = figure.GetY();
            ChessFigure? f;
            if (figure.GetX() != TargetX)

                if (figure.GetX()  > TargetX)
                {

                }

            return false;
        }

        public static bool CanKnightMoveTo(ChessFigure figure, int TargetX, int TargetY /*, List<ChessFigure> figures */)
        {

            if (!IsOnTheTable(TargetX, TargetY))
                return false;
            List<ChessFigure> list;

            int x = figure.GetX();
            int y = figure.GetY();

            return true;
        }





    }
}
