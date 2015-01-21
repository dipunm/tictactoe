using System;
using TicTacToe.TicTacToe;
using TicTacToe.TicTacToe.Abstractions;
using TicTacToe.TicTacToe.Enumerations;

namespace TicTacToe.System
{
    public class BoardRenderer
    {
        public string DrawBoard(IReadableBoard board)
        {
            return String.Format(
                @"
   A   B   C 
 1 {0} | {1} | {2} 
  ---+---+---
 2 {3} | {4} | {5} 
  ---+---+---
 3 {6} | {7} | {8} ",
                RenderToken(board.GetTokenAt(BoardPosition.A1)),
                RenderToken(board.GetTokenAt(BoardPosition.B1)),
                RenderToken(board.GetTokenAt(BoardPosition.C1)),
                RenderToken(board.GetTokenAt(BoardPosition.A2)),
                RenderToken(board.GetTokenAt(BoardPosition.B2)),
                RenderToken(board.GetTokenAt(BoardPosition.C2)),
                RenderToken(board.GetTokenAt(BoardPosition.A3)),
                RenderToken(board.GetTokenAt(BoardPosition.B3)),
                RenderToken(board.GetTokenAt(BoardPosition.C3))
                );
        }

        private string RenderToken(Token? token)
        {
            switch (token)
            {
                case Token.O:
                    return "O";
                case Token.X:
                    return "X";
                default:
                    return " ";
            }
        }
    }
}