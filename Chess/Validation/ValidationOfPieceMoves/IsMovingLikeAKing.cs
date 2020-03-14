using System;

namespace Chess
{
    partial class Validation
    {
        public bool IsMovingLikeAKing(int xsrc, int ysrc, int xdst, int ydst)
        {
            //kings move one square in any direction, so r and f can both change by 1 or one of them can change by 1
            //must allow for castling - 0 or 00 ... TO DO
            if ((Math.Abs(xsrc - xdst) <= 1) && (Math.Abs(ysrc - ydst) <= 1))
                return true;
            return false;
        }
    }
}