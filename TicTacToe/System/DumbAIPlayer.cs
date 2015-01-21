using System.Collections.Generic;
using System.Linq;
using TicTacToe.TicTacToe;
using TicTacToe.TicTacToe.Abstractions;
using TicTacToe.TicTacToe.Enumerations;

namespace TicTacToe.System
{
    public class DumbAIPlayer : IPlayer
    {
        private readonly Token _token;
        private readonly List<BoardPosition> _play;

        public DumbAIPlayer(Token token)
        {
            _token = token;
            _play = new List<BoardPosition>()
            {
                BoardPosition.A1,
                BoardPosition.A2,
                BoardPosition.A3,
                BoardPosition.B1,
                BoardPosition.B2,
                BoardPosition.B3,
                BoardPosition.C1,
                BoardPosition.C2,
                BoardPosition.C3,
            };
        }

        public BoardPosition GetMove(IReadableBoard board)
        {
            var move = _play.FirstOrDefault();
            _play.Remove(move);
            return move;
        }

        public void ObserveBadMove(BoardPosition position)
        {
            _play.Remove(position);
        }

        public Token Token { get { return _token; } }
    }
}