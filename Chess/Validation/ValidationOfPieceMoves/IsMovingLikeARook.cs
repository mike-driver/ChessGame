namespace Chess
{
    partial class Validation
    {
        public bool IsMovingLikeARook(int xsrc, int ysrc, int xdst, int ydst)
        {
            //rooks (castles) move along a rank or along a file in any direction, not diagonally
            if ((xsrc == xdst) || (ysrc == ydst))
            {
                return true;
            }

            return false;
        }
    }
}