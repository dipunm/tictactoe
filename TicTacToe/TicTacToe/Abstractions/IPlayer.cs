using TicTacToe.TicTacToe.Enumerations;

namespace TicTacToe.TicTacToe.Abstractions
{
    public interface IPlayer
    {
        BoardPosition GetMove(IReadableBoard board);
        void ObserveBadMove(BoardPosition position);
        Token Token { get; }
    }
}