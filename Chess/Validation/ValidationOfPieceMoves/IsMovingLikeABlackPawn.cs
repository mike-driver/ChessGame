using System;

namespace Chess
{
    partial class Validation
    {
        public bool IsMovingLikeABlackPawn(string dstval, int xsrc, int ysrc, int xdst, int ydst)
        {
            //on any move can move forward 1 square if destination is free
            if ((ysrc - ydst == 1) && (dstval == "  ") && (xsrc - xdst == 0))
                return true;
            //on first move can move forward 2 squares if destination is free
            if ((ysrc == 55) && (ysrc - ydst == 2) && (dstval.Equals("  ")) && (xsrc - xdst == 0))
                return true;
            //can move forward 1 square diagonally if taking a piece
            if ((((ysrc - ydst) == 1)) && (dstval != "  ") && (Math.Abs(xsrc - xdst) == 1))
                return true;
            //can move forward 1 square diagonally into empty square if executing en passant
            //if destintion square is the last rank (1 or 8) then change to another piece
            return false;
        }
    }
}