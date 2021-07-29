using System;
using System.Collections.Generic;
using System.Text;
using board;
using board.Enums;


namespace chess {
    class Queen : Piece {

        public Queen(Position position, Color color, Board board)
            : base(position, color, board) {
        }

        public override string ToString() {
            return "Q";
        }
    }
}
