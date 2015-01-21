using System.Linq;
using TicTacToe.TicTacToe.Abstractions;
using TicTacToe.TicTacToe.Enumerations;

namespace TicTacToe.TicTacToe
{
    public class WinAnalyser
    {
        private readonly IReadableBoard _board;

        public WinAnalyser(IReadableBoard board)
        {
            _board = board;
        }

        public bool IsWinner(Token token)
        {
            var positions = _board.GetPositonsWithToken(token);
            //look for straight matches
            var straightsFound = positions
                .SelectMany(p => new[] { p.Column, p.Row + 3 })
                .Aggregate(
                    new int[6], (seed, value) =>
                    {
                        seed[value] += 1;
                        return seed;
                    }).Any(count => count == 3);
            
            var backSlash = new[]
            {
                BoardPosition.A1, BoardPosition.B2, BoardPosition.C3
            };
            var forwardSlash = new[]
            {
                BoardPosition.A3, BoardPosition.B2, BoardPosition.C1
            };
            var diagonalsFound =
                positions.Intersect(backSlash).Count() == 3
                || positions.Intersect(forwardSlash).Count() == 3;
            
            var tokenWon = straightsFound || diagonalsFound;
            return tokenWon;
        }
    }
}