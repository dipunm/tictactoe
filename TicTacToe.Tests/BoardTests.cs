using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TicTacToe.TicTacToe;
using TicTacToe.TicTacToe.Enumerations;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class BoardTests
    {
        private readonly BoardPosition[] _positions =
        {
            BoardPosition.A1,
            BoardPosition.A2,
            BoardPosition.A3,
            BoardPosition.B1,
            BoardPosition.B2,
            BoardPosition.B3,
            BoardPosition.C1,
            BoardPosition.C2,
            BoardPosition.C3
        };

        [Test]
        public void ANewBoardHasNoValuesInside()
        {
            var board = new Board();

            var values = _positions
                .Select(board.GetTokenAt)
                .ToList();

            Assert.That(values.Count(v => v == null), Is.EqualTo(9));
        }

        [Test]
        public void UnfilledBoardPositionsHasNoToken()
        {
            var board = new Board();

            board.InsertToken(Token.O, BoardPosition.A2);

            Assert.That(board.GetTokenAt(BoardPosition.A1), Is.Null);
        }

        [Test]
        public void InsertTokenShouldSaveTokenInCorrectPosition()
        {
            var board = new Board();

            board.InsertToken(Token.X, BoardPosition.A1);

            var values = _positions
                .ToDictionary(
                    p => p,
                    board.GetTokenAt
                );

            Assert.That(values.Count(v => v.Value == null), Is.EqualTo(8));
            Assert.That(values[BoardPosition.A1], Is.EqualTo(Token.X));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InsertTokenOnPreFilledPositionShouldThrowException()
        {
            var board = new Board();

            board.InsertToken(Token.X, BoardPosition.A1);
            board.InsertToken(Token.X, BoardPosition.A1);
        }

        [Test]
        public void InsertTokenOnNewPositionOnUsedBoardShouldSucceed()
        {
            var board = new Board();

            board.InsertToken(Token.X, BoardPosition.A1);
            board.InsertToken(Token.O, BoardPosition.A2);

            Assert.That(board.GetTokenAt(BoardPosition.A1), Is.EqualTo(Token.X));
            Assert.That(board.GetTokenAt(BoardPosition.A2), Is.EqualTo(Token.O));
        }

        [Test]
        public void BoardShouldKnowWhenItIsFull()
        {
            var board = new Board();
            board.InsertToken(Token.X, BoardPosition.A1);
            board.InsertToken(Token.X, BoardPosition.A2);
            board.InsertToken(Token.X, BoardPosition.A3);
            board.InsertToken(Token.X, BoardPosition.B1);
            board.InsertToken(Token.X, BoardPosition.B2);
            board.InsertToken(Token.X, BoardPosition.B3);
            board.InsertToken(Token.X, BoardPosition.C1);
            board.InsertToken(Token.X, BoardPosition.C2);
            board.InsertToken(Token.X, BoardPosition.C3);

            Assert.That(board.IsFull, Is.True);
        }

        [Test]
        public void BoardShouldNotThinkItIsFullIfPartiallyFull()
        {
            var partialBoard1 = new Board();
            partialBoard1.InsertToken(Token.X, BoardPosition.A2);
            partialBoard1.InsertToken(Token.X, BoardPosition.A3);
            partialBoard1.InsertToken(Token.X, BoardPosition.B1);
            partialBoard1.InsertToken(Token.X, BoardPosition.B2);
            partialBoard1.InsertToken(Token.X, BoardPosition.B3);
            partialBoard1.InsertToken(Token.X, BoardPosition.C1);
            partialBoard1.InsertToken(Token.X, BoardPosition.C2);
            partialBoard1.InsertToken(Token.X, BoardPosition.C3);

            Assert.That(partialBoard1.IsFull, Is.False);
        }
        
        [Test]
        public void BoardShouldNotThinkItIsFullIfEmpty()
        {
            var board = new Board();
            
            Assert.That(board.IsFull, Is.False);
        }

        [Test]
        public void GetPositonsWithTokenShouldReturnEmptyIfEmpty()
        {
            var board = new Board();

            var positions = board.GetPositonsWithToken(Token.O);

            Assert.That(positions.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetPositonsWithTokenShouldReturnEmptyIfNoTokensOfTypeProvidedExist()
        {
            var board = new Board();
            board.InsertToken(Token.X, BoardPosition.A1);
            board.InsertToken(Token.X, BoardPosition.A2);

            var positions = board.GetPositonsWithToken(Token.O);

            Assert.That(positions.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetPositonsWithTokenShouldReturn3ItemsIfTokenIn3GridCells()
        {
            var board = new Board();
            board.InsertToken(Token.O, BoardPosition.A1);
            board.InsertToken(Token.O, BoardPosition.A2);
            board.InsertToken(Token.O, BoardPosition.C3);

            var positions = board.GetPositonsWithToken(Token.O);

            Assert.That(positions.Count(), Is.EqualTo(3));
        }

        [Test]
        public void GetPositonsWithTokenShouldReturnCorrectPositionsBasedOnGridState()
        {
            var board = new Board();
            board.InsertToken(Token.O, BoardPosition.A1);
            board.InsertToken(Token.O, BoardPosition.A2);
            board.InsertToken(Token.O, BoardPosition.C3);

            var positions = board.GetPositonsWithToken(Token.O);

            var expected = new[] {BoardPosition.A1, BoardPosition.A2, BoardPosition.C3};
            CollectionAssert.AreEquivalent(expected, positions);
        }
    }
}