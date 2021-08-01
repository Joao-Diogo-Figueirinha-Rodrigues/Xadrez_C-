using System;
using System.Collections.Generic;
using System.Text;
using board;
using board.Enums;

namespace chess {
    class Bishop : Piece {

        public Bishop(Position position, Color color, Board board)
            : base(position, color, board) {
        }

        public override string ToString() {
            return "B";
        }

        public override bool[,] PossibleMoves() {

            bool[,] moves = new bool[8, 8];
            int l = base.position.line;
            int r = base.position.row;

            //Down and Right
            for (int i = 1; i < 8; i++) {
                if (l + i < 8 && r + i < 8) {
                    if (board.ShowPosition(l + i, r + i) == null) {
                        moves[l + i, r + i] = true;
                    } else {
                        if (board.ShowPosition(l + i, r + i).color != base.color) {
                            moves[l + i, r + i] = true;
                            break;
                        } else break;
                    }
                }
            }
            //Down and Left
            for (int i = 1; i < 8; i++) {
                if (l + i < 8 && r - i >= 0) {
                    if (board.ShowPosition(l + i, r - i) != null) {
                        if (board.ShowPosition(l + i, r - i).color != base.color) {
                            moves[l + i, r - i] = true;
                            break;
                        } else break;
                    } else moves[l + i, r - i] = true;
                }
            }
            //Up and right
            for (int i = 1; i < 8; i++) {
                if (l - i >= 0 && r + i < 8) {
                    if (board.ShowPosition(l - i, r + i) == null) {
                        moves[l - i, r + i] = true;
                    } else {
                        if (board.ShowPosition(l - i, r + i).color != base.color) {
                            moves[l - i, r + i] = true;
                            break;
                        } else break;
                    }
                }
            }
            //Up and Left
            for (int i = 1; i < 8; i++) {
                if (l - i >= 0 && r - i >= 0) {
                    if (board.ShowPosition(l - i, r - i) != null) {
                        if (board.ShowPosition(l - i, r - i).color != base.color) {
                            moves[l - i, r - i] = true;
                            break;
                        } else break;
                    } else moves[l - i, r - i] = true;
                }
            }

            return moves;
        }
    }
}
