using System;

namespace Chess
{
    partial class Validation
    {
        public bool IsMovingLikeAKnight(int xsrc, int ysrc, int xdst, int ydst)
        {
            //knights move 2x1 OR 1x2
            if (((Math.Abs(xsrc - xdst) == 2) && (Math.Abs(ysrc - ydst) == 1)) || ((Math.Abs(xsrc - xdst) == 1) && (Math.Abs(ysrc - ydst) == 2)))
                return true;
            return false;
        }
    }
}