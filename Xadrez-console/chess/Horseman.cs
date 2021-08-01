using System;
using System.Collections.Generic;
using System.Text;
using board;
using board.Enums;


namespace chess {
    class Horseman : Piece {

        public Horseman(Position position, Color color, Board board)
            : base(position, color, board) {
        }

        public override string ToString() {
            return "H";
        }

        public override bool[,] PossibleMoves() {

            bool[,] moves = new bool[8, 8];
            int l = base.position.line;
            int r = base.position.row;

            // Up and left
            if (l - 2 >= 0 && r - 1 >= 0) moves[l - 2, r - 1] = true;
            if (l - 1 >= 0 && r - 2 >= 0) moves[l - 1, r - 2] = true;
            // Up and right
            if (l - 2 >= 0 && r + 1 < 8) moves[l - 2, r + 1] = true;
            if (l - 1 >= 0 && r + 2 < 8) moves[l - 1, r + 2] = true;
            //Down and left
            if (l + 2 < 8 && r - 1 >= 0) moves[l + 2, r - 1] = true;
            if (l + 1 < 8 && r - 2 >= 0) moves[l + 1, r - 2] = true;
            // Down and right
            if (l + 2 < 8 && r + 1 < 8) moves[l + 2, r + 1] = true;
            if (l + 1 < 8 && r + 2 < 8) moves[l + 1, r + 2] = true;

            return moves;
        }
    }
}
