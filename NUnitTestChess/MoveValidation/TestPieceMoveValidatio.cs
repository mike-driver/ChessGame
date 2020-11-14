using Chess;
using NUnit.Framework;

namespace NUnitTestChess
{
    public partial class Tests
    {
        [Test]
        public void Is_Moving_Like_A_Rook1()
        {
            var result = val.IsMovingLikeARook(0, 0, 0, 6);
            Assert.IsTrue(result);
        }

        [Test]
        public void Is_Moving_Like_A_Rook2()
        {
            var result = val.IsMovingLikeARook(7, 7, 0, 7);
            Assert.IsTrue(result);
        }

        [Test]
        public void Is_Not_Moving_Like_A_Rook1()
        {
            var result = val.IsMovingLikeARook(7, 7, 1, 1);
            Assert.IsFalse(result);
        }

        [Test]
        public void Is_Not_Moving_Like_A_Rook2()
        {
            var result = val.IsMovingLikeARook(0, 0, 4, 3);
            Assert.IsFalse(result);
        }

        [Test]
        public void Is_Not_Moving_Like_A_Rook3()
        {
            var result = val.IsMovingLikeARook(1, 0, 2, 3);
            Assert.IsFalse(result);
        }
    }
}