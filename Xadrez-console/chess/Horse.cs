using System;
using System.Collections.Generic;
using System.Text;
using board;
using board.Enums;


namespace chess {
    class Horse : Piece {

        public Horse(Position position, Color color, Board board)
            : base(position, color, board) {
        }

        public override string ToString() {
            return "H";
        }

        public override bool[,] PossibleMoves() {

            bool[,] moves = new bool[8, 8];
            int l = base.position.line;
            int r = base.position.row;

            for (int i = -2; i <=2; i++) {
                for (int j = -2; j <= 2; j++) {
                    if(i!=j && i != -j && i != 0 && j != 0 && board.ValidatePosition(l + i,r + j)) {
                        if (board.ShowPosition(l + i, r + j) != null) {
                            if (board.ShowPosition(l + i, r + j).color != base.color) {
                                moves[l + i, r + j] = true;
                            }
                        } else moves[l + i, r + j] = true;
                    }
                }
            }
            return moves;
        }
    }
}
