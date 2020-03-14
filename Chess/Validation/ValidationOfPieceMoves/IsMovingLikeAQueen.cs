namespace Chess
{
    partial class Validation
    {
        public bool IsMovingLikeAQueen(int xsrc, int ysrc, int xdst, int ydst)
        {
            //queens move like a rook or bishop
            if ((IsMovingLikeARook(xsrc, ysrc, xdst, ydst)) || (IsMovingLikeABishop(xsrc, ysrc, xdst, ydst)))
            {
                return true;
            }

            return false;
        }
    }
}