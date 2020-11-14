using Chess;

using NUnit.Framework;

namespace NUnitTestChess
{
    public partial class Tests
    {
        readonly BoardInternal internal_board = new BoardInternal();
        readonly Validation val = new Validation();

        [SetUp]
        public void Setup()
        {
        }
    }
}