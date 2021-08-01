using System;
using System.Collections.Generic;
using System.Text;
using board;
using board.Enums;

namespace chess {
    class Tower : Piece {

        public Tower(Position position, Color color, Board board)
            : base(position, color, board) {
        }

        public override string ToString() {
            return "T";
        }

        public override bool[,] PossibleMoves() {
            bool[,] moves = new bool[8, 8];

            // Down
            for (int i = base.position.line + 1; i < 8; i++) {
                if (board.ShowPosition(new Position(i, base.position.row)) == null)
                    moves[i, base.position.row] = true;
                else if (board.ShowPosition(new Position(i, base.position.row)).color == base.color)
                    break;
                else {
                    moves[i, base.position.row] = true;
                    break;
                }
            }
            // Up
            for (int i = base.position.line - 1; i > 0; i--) {
                if (board.ShowPosition(new Position(i, base.position.row)) == null)
                    moves[i, base.position.row] = true;
                else if (board.ShowPosition(new Position(i, base.position.row)).color == base.color)
                    break;
                else {
                    moves[i, base.position.row] = true;
                    break;
                }
            }
            // Right
            for (int i = base.position.row + 1; i < 8; i++) {
                if (board.ShowPosition(new Position(base.position.line, i)) == null)
                    moves[base.position.line, i] = true;
                else if (board.ShowPosition(new Position(base.position.line, i)).color == base.color)
                    break;
                else {
                    moves[base.position.line, i] = true;
                    break;
                }
            }

            // Left
            for (int i = base.position.row -1; i > 0; i--) {
                if (board.ShowPosition(new Position(base.position.line, i)) == null)
                    moves[base.position.line, i] = true;
                else if (board.ShowPosition(new Position(base.position.line, i)).color == base.color)
                    break;
                else {
                    moves[base.position.line, i] = true;
                    break;
                }
            }
            return moves;
        }
    }
}
