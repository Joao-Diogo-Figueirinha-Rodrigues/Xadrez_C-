using System;
using System.Collections.Generic;
using System.Text;
using board;
using board.Enums;

namespace chess {
    class Pawn : Piece {

        public Pawn(Position position, Color color, Board board)
            : base(position, color, board) {
        }

        public override string ToString() {
            return "P";
        }

        public override bool[,] PossibleMoves() {
            bool[,] moves = new bool[8, 8];
            int ml = base.position.line;
            int mr = base.position.row;

            if (base.color == Color.White) {
                //left Eat
                if (ml - 1 >= 0 && mr - 1 >= 0) {
                    if (board.ShowPosition(ml - 1, mr - 1) != null &&
                        board.ShowPosition(ml - 1, mr - 1).color == Color.Black) {
                        if (base.board.TryMove(this, new Position(ml - 1, mr - 1)))
                            moves[ml - 1, mr - 1] = true;
                    }
                }
                // Rigth Eat
                if (ml - 1 >= 0 && mr + 1 < 8) {
                    if (board.ShowPosition(ml - 1, mr + 1) != null &&
                        board.ShowPosition(ml - 1, mr + 1).color == Color.Black) {
                        if (base.board.TryMove(this, new Position(ml - 1, mr + 1))) 
                            moves[ml - 1, mr + 1] = true;
                    }
                }
            } else {
                //left Eat
                if (ml + 1 <8 && mr - 1 >= 0) {
                    if (board.ShowPosition(ml + 1, mr - 1) != null &&
                        board.ShowPosition(ml + 1, mr - 1).color == Color.White) {
                        if (base.board.TryMove(this, new Position(ml + 1, mr - 1)))
                            moves[ml + 1, mr - 1] = true;
                    }
                }
                // Rigth Eat
                if (ml + 1 <8 && mr + 1 < 8) {
                    if (board.ShowPosition(ml + 1, mr + 1) != null &&
                        board.ShowPosition(ml + 1, mr + 1).color == Color.White) {
                        if (base.board.TryMove(this, new Position(ml + 1, mr + 1)))
                            moves[ml + 1, mr + 1] = true;
                    }
                }
            }
            // Improvement: Put first other moves and after First move
            // First Move
            if (base.numberOfMoves == 0) {
                if (base.color == Color.White) {

                    if (board.ShowPosition(ml - 1, mr) != null) return moves;
                    if (base.board.TryMove(this, new Position(ml - 1, mr))) moves[ml - 1, mr] = true;
                    if (board.ShowPosition(ml - 2, mr) != null) return moves;
                    if (base.board.TryMove(this, new Position(ml - 2, mr))) moves[ml - 2, mr] = true;
                } else {
                    if (board.ShowPosition(ml + 1, mr) != null) return moves;
                    if (base.board.TryMove(this, new Position(ml + 1, mr))) moves[ml + 1, mr] = true;
                    if (board.ShowPosition(ml + 2, mr) != null) return moves;
                    if (base.board.TryMove(this, new Position(ml +2, mr))) moves[ml + 2, mr] = true;
                }
                // Other Moves
            } else {
                if (base.color == Color.White) {
                    if (board.ShowPosition(ml - 1, mr) != null) return moves;
                    if (base.board.TryMove(this, new Position(ml - 1, mr))) moves[ml - 1, mr] = true;
                } else {
                    if (board.ShowPosition(ml + 1, mr) != null) return moves;
                    if (base.board.TryMove(this, new Position(ml + 1, mr))) moves[ml + 1, mr] = true;
                }
            }
            return moves;
        }
    }
}
