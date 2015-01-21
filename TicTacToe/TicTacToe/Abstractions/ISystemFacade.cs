using TicTacToe.TicTacToe.Enumerations;

namespace TicTacToe.TicTacToe.Abstractions
{
    public interface ISystemFacade
    {
        void ObserveEndGame(Game game);
        void ObserveBoard(IReadableBoard board);
        IPlayer GetPlayer(Token token);
    }
}