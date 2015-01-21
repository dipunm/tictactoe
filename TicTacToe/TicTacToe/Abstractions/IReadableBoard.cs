using System.Collections.Generic;
using TicTacToe.TicTacToe.Enumerations;

namespace TicTacToe.TicTacToe.Abstractions
{
    public interface IReadableBoard
    {
        Token? GetTokenAt(BoardPosition position);
        IEnumerable<BoardPosition> GetPositonsWithToken(Token token);
    }
}