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

        public override bool[,] PossibleMoves() {
            bool[,] moves = new bool[8, 8];
            //Improvement: Use l and r in Tower component
            int l = base.position.line;
            int r = base.position.row;

            //Down and Right
            for (int i = 1; i < 8; i++) {
                if (l + i < 8 && r + i < 8) {
                    if (board.ShowPosition(l + i, r + i) == null) {
                        if (base.board.TryMove(this, new Position(l + i, r + i)))
                            moves[l + i, r + i] = true;
                    } else {
                        if (board.ShowPosition(l + i, r + i).color != base.color) {
                            if (base.board.TryMove(this, new Position(l + i, r + i)))
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
                            if (base.board.TryMove(this, new Position(l + i, r - i))) moves[l + i, r - i] = true;
                            break;
                        } else break;
                    } else if (base.board.TryMove(this, new Position(l + i, r - i))) moves[l + i, r - i] = true;
                }
            }
            //Up and right
            for (int i = 1; i < 8; i++) {
                if (l - i >= 0 && r + i < 8) {
                    if (board.ShowPosition(l - i, r + i) == null) {
                        if (base.board.TryMove(this, new Position(l - i, r + i)))
                            moves[l - i, r + i] = true;
                    } else {
                        if (board.ShowPosition(l - i, r + i).color != base.color) {
                            if (base.board.TryMove(this, new Position(l - i, r + i)))
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
                            if (base.board.TryMove(this, new Position(l - i, r - i)))
                                moves[l - i, r - i] = true;
                            break;
                        } else break;
                    } else if (base.board.TryMove(this, new Position(l - i, r - i)))
                        moves[l - i, r - i] = true;
                }
            }
            // Down
            for (int i = base.position.line + 1; i < 8; i++) {
                if (board.ShowPosition(new Position(i, base.position.row)) == null) {
                    if (base.board.TryMove(this, new Position(i, base.position.row)))
                        moves[i, base.position.row] = true;
                } else if (board.ShowPosition(new Position(i, base.position.row)).color == base.color)
                    break;
                else {
                    if (base.board.TryMove(this, new Position(i, base.position.row)))
                        moves[i, base.position.row] = true;
                    break;
                }
            }
            // Up
            for (int i = base.position.line - 1; i >= 0; i--) {
                if (board.ShowPosition(new Position(i, base.position.row)) == null) {
                    if (base.board.TryMove(this, new Position(i, base.position.row)))
                        moves[i, base.position.row] = true;
                } else if (board.ShowPosition(new Position(i, base.position.row)).color == base.color)
                    break;
                else {
                    if (base.board.TryMove(this, new Position(i, base.position.row)))
                        moves[i, base.position.row] = true;
                    break;
                }
            }
            // Right
            for (int i = base.position.row + 1; i < 8; i++) {
                if (board.ShowPosition(new Position(base.position.line, i)) == null) {
                    if (base.board.TryMove(this, new Position(base.position.line, i)))
                        moves[base.position.line, i] = true;
                } else if (board.ShowPosition(new Position(base.position.line, i)).color == base.color)
                    break;
                else {
                    if (base.board.TryMove(this, new Position(base.position.line, i)))
                        moves[base.position.line, i] = true;
                    break;
                }
            }

            // Left
            for (int i = base.position.row - 1; i >= 0; i--) {
                if (board.ShowPosition(new Position(base.position.line, i)) == null) {
                    if (base.board.TryMove(this, new Position(base.position.line, i)))
                        moves[base.position.line, i] = true;
                } else if (board.ShowPosition(new Position(base.position.line, i)).color == base.color)
                    break;
                else {
                    if (base.board.TryMove(this, new Position(base.position.line, i)))
                        moves[base.position.line, i] = true;
                    break;
                }
            }
            return moves;
        }
    }
}
