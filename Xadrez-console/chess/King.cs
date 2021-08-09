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
            //small castling
            if (numberOfMoves == 0 && CheckMate.PossibleKingMove(this, this.position)) {
                if (board.ShowPosition(position.line, position.row + 3) is Tower &&
                    board.ShowPosition(position.line, position.row + 3).numberOfMoves == 0)
                    if (board.ShowPosition(position.line, position.row + 1) == null &&
                        board.ShowPosition(position.line, position.row + 2) == null)
                        moves[position.line, position.row + 2] = true;
                // Large castling
                if (board.ShowPosition(position.line, position.row - 4) is Tower &&
                    board.ShowPosition(position.line, position.row - 4).numberOfMoves == 0)
                    if (board.ShowPosition(position.line, position.row - 1) == null &&
                        board.ShowPosition(position.line, position.row - 2) == null &&
                        board.ShowPosition(position.line, position.row - 3) == null)
                        moves[position.line, position.row - 2] = true;
            }
            return moves;
        }
    }
}
