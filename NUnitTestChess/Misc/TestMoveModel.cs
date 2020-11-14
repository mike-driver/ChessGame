using Chess.Model;

using NUnit.Framework;

namespace NUnitTestChess
{
    public partial class Tests
    {
        [Test]
        public void Get_XY_Coords_And_SrcDst_Pieces_From_Move_Input()
        {
            string move = "d2d4";
            MoveModel mm = val.GetMoveCoordsAndPiece(Game1, move);
            Assert.IsTrue(mm.xsrc == 100 && mm.ysrc == 50 && mm.xdst == 100 && mm.ydst == 52 && mm.srcval == " P" && mm.dstval == "  ");
        }
    }
}