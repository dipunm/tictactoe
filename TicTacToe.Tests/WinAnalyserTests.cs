using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using TicTacToe.TicTacToe;
using TicTacToe.TicTacToe.Abstractions;
using TicTacToe.TicTacToe.Enumerations;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class WinAnalyserTests
    {
        private static BoardPosition[][] WinningPositionLists =
        {
            new BoardPosition[]
            {
                BoardPosition.A1, BoardPosition.A2, BoardPosition.A3
            },
            new BoardPosition[]
            {
                BoardPosition.B1, BoardPosition.B2, BoardPosition.B3
            },
            new BoardPosition[]
            {
                BoardPosition.C1, BoardPosition.C2, BoardPosition.C3
            },
            new BoardPosition[]
            {
                BoardPosition.A1, BoardPosition.B1, BoardPosition.C1
            },
            new BoardPosition[]
            {
                BoardPosition.A2, BoardPosition.B2, BoardPosition.C2
            },
            new BoardPosition[]
            {
                 BoardPosition.A3, BoardPosition.B3, BoardPosition.C3 
            },
            new BoardPosition[]
            {
                 BoardPosition.A1, BoardPosition.B2, BoardPosition.C3
            },
            new BoardPosition[]
            {
                 BoardPosition.A3, BoardPosition.B2, BoardPosition.C1
            },
        };

        [TestCaseSource("WinningPositionLists")]
        public void ShouldAcknowledgeWinningPatterns(IEnumerable<BoardPosition> winningPositions)
        {
            var mockBoard = new Mock<IReadableBoard>();
            mockBoard.Setup(b => b.GetPositonsWithToken(Token.O))
                .Returns(winningPositions);
            var analyser = new WinAnalyser(mockBoard.Object);

            var win = analyser.IsWinner(Token.O);

            Assert.That(win, Is.True);
        }

        [Test]
        public void ShouldAcknowledgeWinningPatternsWithNoise()
        {
            var pattern = WinningPositionLists.First().ToList(); //A column win
            pattern.Add(BoardPosition.B1);
            var mockBoard = new Mock<IReadableBoard>();
            mockBoard.Setup(b => b.GetPositonsWithToken(Token.O))
                .Returns(pattern);
            var analyser = new WinAnalyser(mockBoard.Object);

            var win = analyser.IsWinner(Token.O);

            Assert.That(win, Is.True);
        }

        [Test]
        public void ShouldAcknowledgeWinWithXToken()
        {
            var pattern = WinningPositionLists.First().ToList(); //A column win
            var mockBoard = new Mock<IReadableBoard>();
            mockBoard.Setup(b => b.GetPositonsWithToken(Token.X))
                .Returns(pattern);
            var analyser = new WinAnalyser(mockBoard.Object);

            var win = analyser.IsWinner(Token.X);

            Assert.That(win, Is.True);
        }
    }
}
