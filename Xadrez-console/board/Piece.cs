using board.Enums;


namespace board {
    abstract class Piece {

        public Position position { get; set; }
        protected Color color;
        public int numberOfMoves { get; set; }
        public Board board { get; protected set; }

        public Piece(Position position, Color color, Board board) {
            this.position = position;
            this.color = color;
            this.board = board;
            numberOfMoves = 0;
        }

        //
    }
}
