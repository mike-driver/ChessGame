using Chess;

using NUnit.Framework;

namespace NUnitTestChess
{
    public partial class Tests
    {
        [Test]
        public void PieceOnSquare_Of_Newly_Initialised_Board_Gets_Correct_Piece_WhiteRook()
        {
            var init_board = internal_board.InitialiseGame();
            var result = val.PieceOnSquare(init_board, "a1");
            Assert.AreEqual(result, Chess.Common.P.WR);
        }

        [Test]
        public void PieceOnSquare_Of_Newly_Initialised_Board_Gets_Correct_Piece_BlackRook()
        {
            var init_board = internal_board.InitialiseGame();
            var result = val.PieceOnSquare(init_board, "h8");
            Assert.AreEqual(result, Chess.Common.P.BR);
        }

        [Test]
        public void PieceOnSquare_Of_Newly_Initialised_Board_Gets_Correct_Piece_WhitePawn()
        {
            var init_board = internal_board.InitialiseGame();
            var result = val.PieceOnSquare(init_board, "d2");
            Assert.AreEqual(result, Chess.Common.P.WP);
        }

        [Test]
        public void PieceOnSquare_Of_Newly_Initialised_Board_Gets_BlankSquare_d4()
        {
            var init_board = internal_board.InitialiseGame();
            var result = val.PieceOnSquare(init_board, "d4");
            Assert.AreEqual(result, Chess.Common.P.__);
        }

        [Test]
        public void PieceOnSquare_Of_Newly_Initialised_Board_Gets_BlankSquare_h6()
        {
            var init_board = internal_board.InitialiseGame();
            var result = val.PieceOnSquare(init_board, "h6");
            Assert.AreEqual(result, Chess.Common.P.__);
        }
    }
}