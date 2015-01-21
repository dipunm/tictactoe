using TicTacToe.TicTacToe.Abstractions;
using TicTacToe.TicTacToe.Enumerations;

namespace TicTacToe.TicTacToe
{
    public class TicTacToeEngine
    {
        public void PlayGame(ISystemFacade system)
        {
            var game = new Game();
            var oPlayer = system.GetPlayer(Token.O);
            var xPlayer = system.GetPlayer(Token.X);

            do
            {
                system.ObserveBoard(game.Board);
                var player = game.CurrentPlayerToken == Token.O ? oPlayer : xPlayer;
                PlayRound(game, player);
            }
            while (game.Result == null);
                     
            system.ObserveEndGame(game);    
        }

        private void PlayRound(Game game, IPlayer player)
        {
            bool roundCompleted;
            do
            {
                BoardPosition position = player.GetMove(game.Board);

                roundCompleted = game.Play(position);
                if (!roundCompleted)
                {
                    player.ObserveBadMove(position);
                }
            } while (!roundCompleted && game.CurrentPlayerToken == player.Token);
        }
    }
}