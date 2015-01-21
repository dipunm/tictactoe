using System;
using TicTacToe.ExtensionMethods;
using TicTacToe.TicTacToe;
using TicTacToe.TicTacToe.Abstractions;
using TicTacToe.TicTacToe.Enumerations;

namespace TicTacToe.System
{
    public class ConsolePlayer : IPlayer
    {
        private readonly Token _token;

        public ConsolePlayer(Token token)
        {
            _token = token;
        }

        public BoardPosition GetMove(IReadableBoard board)
        {
            var myrenderer = new BoardRenderer();
            var myBoardSnapshot = myrenderer.DrawBoard(board);
            do
            {
                Console.Clear();
                Console.WriteLine(myBoardSnapshot);
                Console.WriteLine();
                Console.WriteLine("Where do you want to play {0}?", _token);
                var pos = Console.ReadLine().ToUpperInvariant();
                var position = BoardPosition.FromString(pos);
                if (position != null)
                    return position;
                
                Console.WriteLine("You must type a valid coordinate within the ranges A1 to C3");
                ConsoleHelper.Pause();
            } while (true);
        }

        public void ObserveBadMove(BoardPosition position)
        {
            Console.WriteLine("Move was unsuccessful, please try again.");
            ConsoleHelper.Pause();
        }

        public Token Token { get { return _token; }}
    }
}