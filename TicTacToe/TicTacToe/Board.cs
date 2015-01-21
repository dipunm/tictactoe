using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.TicTacToe.Abstractions;
using TicTacToe.TicTacToe.Enumerations;

namespace TicTacToe.TicTacToe
{
    public class Board : IReadableBoard
    {
        private readonly Dictionary<BoardPosition, Token?> _cells;

        public Board()
        {
            _cells = new Dictionary<BoardPosition, Token?>()
            {
                {BoardPosition.A1, null},
                {BoardPosition.A2, null},
                {BoardPosition.A3, null},
                {BoardPosition.B1, null},
                {BoardPosition.B2, null},
                {BoardPosition.B3, null},
                {BoardPosition.C1, null},
                {BoardPosition.C2, null},
                {BoardPosition.C3, null}
            };
        }

        public bool IsFull
        {
            get { return _cells.All(d => d.Value != null); }
        }

        public Token? GetTokenAt(BoardPosition position)
        {
            return _cells[position];
        }

        public void InsertToken(Token token, BoardPosition position)
        {
            if(_cells[position] == null)
                _cells[position] = token;
            else
                throw new InvalidOperationException("Cannot place token in specified position. Position already taken.");
        }

        public IEnumerable<BoardPosition> GetPositonsWithToken(Token token)
        {
            return _cells.Where(c => c.Value == token).Select(c => c.Key);
        }
    }
}