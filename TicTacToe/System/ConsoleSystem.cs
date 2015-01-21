using System;
using TicTacToe.ExtensionMethods;
using TicTacToe.TicTacToe;
using TicTacToe.TicTacToe.Abstractions;
using TicTacToe.TicTacToe.Enumerations;

namespace TicTacToe.System
{
    public class ConsoleSystem : ISystemFacade
    {
        private readonly BoardRenderer _renderer;

        public ConsoleSystem()
        {
            _renderer = new BoardRenderer();
        }
        public void ObserveEndGame(Game game)
        {
            var boardSnapshot = _renderer.DrawBoard(game.Board);

            Console.Clear();
            Console.WriteLine(boardSnapshot);
            Console.WriteLine();
            switch (game.Result)
            {
                case GameResult.X_Win:
                    Console.WriteLine("X wins the game!");
                    break;
                case GameResult.O_Win:
                    Console.WriteLine("O wins the game!");
                    break;
                case GameResult.Draw:
                default:
                    Console.WriteLine("Draw game!");
                    break;
            }
            ConsoleHelper.Pause();
        }

        public void ObserveBoard(IReadableBoard board)
        {
            var boardSnapshot = _renderer.DrawBoard(board);
            
            Console.Clear();
            Console.WriteLine("Board State:");
            Console.WriteLine("---------------------------");
            Console.WriteLine(boardSnapshot);
            Console.WriteLine();
            ConsoleHelper.Pause();
        }

        public IPlayer GetPlayer(Token token)
        {
            Console.Clear();
            Console.WriteLine("Choose a player type for token `{0}`", token == Token.O ? "O" : "X");
            Console.WriteLine("Press K for keyboard controlled player, or A for an AI player");
            bool? AI = null;
            while (AI == null)
            {
                char key = Console.ReadKey().KeyChar;
                if(key == 'K' || key == 'k')
                    AI = false;
                else if (key == 'A' || key == 'a')
                    AI = true;
            }
            if(AI.Value)
                Console.WriteLine("AI Chosen.");
            else
                Console.WriteLine("Keyboard chosen.");
            ConsoleHelper.Pause();

            if (AI.Value)
                return new DumbAIPlayer(token);
            return new ConsolePlayer(token);
        }

        public void Reset()
        {
            Console.Clear();
        }
    }
}