using Chess;

using NUnit.Framework;

namespace NUnitTestChess
{
    public partial class Tests
    {
        readonly BoardInternal internal_board = new BoardInternal();
        readonly ChessGame Game1 = new ChessGame();
        readonly Validation val = new Validation();

        [SetUp]
        public void Setup()
        {
        }
    }
}