namespace TicTacToe.TicTacToe
{
    public class BoardPosition
    {
        private readonly int _column;
        private readonly int _row;

        private BoardPosition(int column, int row)
        {
            _column = column;
            _row = row;
        }

        public int Row { get { return _row; } }
        public int Column { get { return _column; } }

        public override bool Equals(object obj)
        {
            var pos = obj as BoardPosition;
            if (pos == null)
                return false;

            return pos.Row == Row && pos.Column == Column;
        }

        public override int GetHashCode()
        {
            return (Row * 3) + Column;
        }

        #region factory methods
        public static BoardPosition A1
        {
            get
            {
                return new BoardPosition(0, 0);
            }
        }

        public static BoardPosition A2
        {
            get
            {
                return new BoardPosition(0, 1);
            }
        }
        public static BoardPosition A3
        {
            get
            {
                return new BoardPosition(0, 2);
            }
        }
        public static BoardPosition B1
        {
            get
            {
                return new BoardPosition(1, 0);
            }
        }
        public static BoardPosition B2
        {
            get
            {
                return new BoardPosition(1, 1);
            }
        }
        public static BoardPosition B3
        {
            get
            {
                return new BoardPosition(1, 2);
            }
        }
        public static BoardPosition C1
        {
            get
            {
                return new BoardPosition(2, 0);
            }
        }
        public static BoardPosition C2
        {
            get
            {
                return new BoardPosition(2, 1);
            }
        }
        public static BoardPosition C3
        {
            get
            {
                return new BoardPosition(2, 2);
            }
        }

        #endregion

        public static BoardPosition FromString(string input)
        {
            switch (input)
            {
                case "A1":
                    return A1;
                case "A2":
                    return A2;
                case "A3":
                    return A3;
                case "B1":
                    return B1;
                case "B2":
                    return B2;
                case "B3":
                    return B3;
                case "C1":
                    return C1;
                case "C2":
                    return C2;
                case "C3":
                    return C3;
                default:
                    return null;
            }
        }
    }
}