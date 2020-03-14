using System;

namespace Chess
{
    partial class Validation
    {
        public bool IsMovingLikeABishop(int xsrc, int ysrc, int xdst, int ydst)
        {
            //bishops move by equal n squares in both planes
            if (Math.Abs(xsrc - xdst) == Math.Abs(ysrc - ydst))
                return true;
            return false;
        }
    }
}