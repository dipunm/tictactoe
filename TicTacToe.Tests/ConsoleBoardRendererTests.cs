using NUnit.Framework;
using TicTacToe.System;
using TicTacToe.TicTacToe;
using TicTacToe.TicTacToe.Enumerations;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class ConsoleBoardRendererTests
    {
        [Test]
        public void ShouldOutputTextToConsoleWhenGivenBoardInstance()
        {
            var board = new Board();
            var consoleRenderer = new BoardRenderer();

            var output = consoleRenderer.DrawBoard(board);

            Assert.That(output, Is.Not.Null);
        }

        #region TestCaseSource: GridVariantCases
        private const int _ = 0;
        private const int X = 1;
        private const int O = 2;
        private static object[] GridVariantCases
        {
            get
            {
                return new[]
                {
                    new object[2]
                    {
                        new int [9]
                        {
                            _,_,_,
                            _,_,_,
                            _,_,_
                        }, 
@"
   A   B   C 
 1   |   |   
  ---+---+---
 2   |   |   
  ---+---+---
 3   |   |   "
                    },
                    new object[2]
                    {
                        new int [9]
                        {
                            _,_,O,
                            _,X,_,
                            _,_,X
                        }, 
@"
   A   B   C 
 1   |   | O 
  ---+---+---
 2   | X |   
  ---+---+---
 3   |   | X "
                    },
                    new object[2]
                    {
                        new int [9]
                        {
                            O,O,X,
                            X,_,X,
                            X,O,O
                        }, 
@"
   A   B   C 
 1 O | O | X 
  ---+---+---
 2 X |   | X 
  ---+---+---
 3 X | O | O "
                    },
                };
            }
        }
        #endregion

        [TestCaseSource("GridVariantCases")]
        public void ShouldDrawGridAsExpected(int[] grid, string expectedOut)
        {
            var board = GridFromNumberArray(grid);
            var consoleRenderer = new BoardRenderer();

            var output = consoleRenderer.DrawBoard(board);

            Assert.That(output, Is.EqualTo(expectedOut));
        }

        private Board GridFromNumberArray(int[] grid)
        {
            var board = new Board();
            var positions = new[]
            {
                BoardPosition.A1, BoardPosition.B1, BoardPosition.C1,
                BoardPosition.A2, BoardPosition.B2, BoardPosition.C2,
                BoardPosition.A3, BoardPosition.B3, BoardPosition.C3
            };

            for (int i = 0; i < 9; i++)
            {
                Token? token = null;
                switch (grid[i])
                {
                    case O:
                        token = Token.O;
                        break;
                    case X:
                        token = Token.X;
                        break;
                }
                if (token.HasValue)
                    board.InsertToken(token.Value, positions[i]);
            }

            return board;
        }
    }
}
