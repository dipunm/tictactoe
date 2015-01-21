using System.Linq;
using NUnit.Framework;
using TicTacToe.TicTacToe;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class BoardPositionTests
    {
        private static readonly object[] PositionCoordinatesRaw =
        {
            new object[] {BoardPosition.A1, 0, 0, "A1"},
            new object[] {BoardPosition.A2, 0, 1, "A2"},
            new object[] {BoardPosition.A3, 0, 2, "A3"},
            new object[] {BoardPosition.B1, 1, 0, "B1"},
            new object[] {BoardPosition.B2, 1, 1, "B2"},
            new object[] {BoardPosition.B3, 1, 2, "B3"},
            new object[] {BoardPosition.C1, 2, 0, "C1"},
            new object[] {BoardPosition.C2, 2, 1, "C2"},
            new object[] {BoardPosition.C3, 2, 2, "C3"}
        };

        private static object[][] PositionCoordinates
        {
            get
            {
                return PositionCoordinatesRaw
                    .Select(data => new[]
                    {
                        ((object[])data)[0],
                        ((object[])data)[1],
                        ((object[])data)[2]
                    }).ToArray();
            }
        }

        private static object[][] PositionAsStringCoordinates
        {
            get
            {
                return PositionCoordinatesRaw
                    .Select(data => new[]
                    {
                        ((object[])data)[3],
                        ((object[])data)[1],
                        ((object[])data)[2]
                    }).ToArray();
            }
        }

        [TestCaseSource("PositionCoordinates")]
        public void PositionUsingFactoryShouldHaveCorrectCoordinates(
            BoardPosition position, int expectedColumn, int expectedRow)
        {
            Assert.That(position.Row, Is.EqualTo(expectedRow));
            Assert.That(position.Column, Is.EqualTo(expectedColumn));
        }

        [TestCaseSource("PositionAsStringCoordinates")]
        public void FromStringShouldCreateAppropriateBoardPositionInstance(
            string input, int expectedColumn, int expectedRow)
        {
            var position = BoardPosition.FromString(input);

            Assert.That(position, Is.Not.Null);
            Assert.That(position.Row, Is.EqualTo(expectedRow));
            Assert.That(position.Column, Is.EqualTo(expectedColumn));
        }
    }
}