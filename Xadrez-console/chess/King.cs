using System;
using System.Collections.Generic;
using System.Text;
using board;
using board.Enums;

namespace chess {
    class King : Piece {

        public King(Position position, Color color, Board board)
            : base(position, color, board) {
        }

        public override string ToString() {
            return "K";
        }

        public override bool[,] PossibleMoves() {
            bool[,] moves = new bool[8, 8];

            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    
                    if (!(i == 0 && i == j)) {
                        if (board.ValidatePosition(position.line + i, position.row + j)) {
                            if (board.ShowPosition(position.line + i, position.row + j) != null) {
                                if (board.ShowPosition(position.line + i, position.row + j).color != color) {
                                    if (CheckMate.PossibleKingMove(this, new Position(position.line + i, position.row + j)))
                                        moves[position.line + i, position.row + j] = true;
                                }
                            } else {
                                if (CheckMate.PossibleKingMove(this, new Position(position.line + i, position.row + j)))
                                    moves[position.line + i, position.row + j] = true;
                            }
                        }
                    }
                }
            }
           
            return moves;
        }
    }
}
