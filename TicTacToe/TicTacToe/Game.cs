using TicTacToe.TicTacToe.Abstractions;
using TicTacToe.TicTacToe.Enumerations;

namespace TicTacToe.TicTacToe
{
    public class Game
    {
        private Token _token;
        private readonly Board _board;
        private readonly WinAnalyser _winAnalyser;

        public Game()
        {
            _board = new Board();
            _token = Token.O;
            Result = null;
            _winAnalyser = new WinAnalyser(_board);
        }

        public Token CurrentPlayerToken
        {
            get { return _token; }
        }

        public IReadableBoard Board
        {
            get { return _board; }
        }

        public GameResult? Result { get; private set; }

        public bool Play(BoardPosition position)
        {
            if (Board.GetTokenAt(position) == null)
            {
                _board.InsertToken(CurrentPlayerToken, position);
                CheckForAndUpdateResult(_token);
                _token = _token == Token.O ? Token.X : Token.O;
                return true;
            }
            return false;
        }

        private void CheckForAndUpdateResult(Token lastPlayedToken)
        {
            if (_winAnalyser.IsWinner(lastPlayedToken))
            {
                Result = lastPlayedToken == Token.O ? GameResult.O_Win : GameResult.X_Win;
            }
            else if (_board.IsFull)
            {
                Result = GameResult.Draw;
            }
        }
    }
}