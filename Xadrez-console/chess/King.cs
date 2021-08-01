using System;
using System.Collections.Generic;
using System.Text;
using board;
using board.Enums;

namespace chess {
    class King : Piece{

        public King(Position position, Color color, Board board)
            : base(position, color, board) {
        }

        public override string ToString() {
            return "K";
        }
        public override bool[,] PossibleMoves() {
            bool[,] moves = new bool[8, 8];
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    moves[i, j] = true;
                }
            }
            return moves;
        }
    }
}
