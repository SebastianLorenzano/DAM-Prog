using System;

namespace RetroGame
{
    public class Utils
    {
        public enum IntersectDirec
        {
            NONE,
            TOP, 
            DOWN, 
            LEFT, 
            RIGHT
        }

        public static double GetDistance(double x1, double y1, double x2, double y2)
        {   
            double dx = x2 - x1;
            double dy = y2 - y1;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static IntersectDirec GetIntersectDirection(Ball ball, Rectangle other)
        {

            if (GetDistance(ball.GetMiddleX(), ball.GetMiddleY(), other.GetMiddleX(), other.GetMiddleY()) !> 6)
            {
                if (AreIntersectingTop(ball, other))
                    return IntersectDirec.TOP;
                if (AreIntersectingDown(ball, other))
                    return IntersectDirec.DOWN;
                if (AreIntersectingLeft(ball, other))
                    return IntersectDirec.LEFT;
                if (AreIntersectingRight(ball, other))
                    return IntersectDirec.RIGHT;
            }
            return IntersectDirec.NONE;
        }

        public static bool AreIntersectingTop(Ball ball, Rectangle other) 
        {
            double ballY = ball.GetY() + ball.GetHeight();
            double otherY = other.GetY();
            return GetDistance(0, ballY, 0, otherY) < 1;
        }

        public static bool AreIntersectingDown(Ball ball, Rectangle other)
        {
            double ballY = ball.GetY();
            double otherY = other.GetY() + other.GetHeight();
            return GetDistance(0, ballY, 0, otherY) < 1;
        }

        public static bool AreIntersectingLeft(Ball ball, Rectangle other)
        {
            double ballX = ball.GetX();
            double otherX = other.GetX() + other.GetWidth();
            return GetDistance(ballX, 0, otherX, 0) < 1;
        }

        public static bool AreIntersectingRight(Ball ball, Rectangle other)
        {
            double ballX = ball.GetX() + ball.GetWidth();
            double otherX = other.GetX();
            return GetDistance(ballX, 0, otherX, 0) < 1;
        }


    }
}
