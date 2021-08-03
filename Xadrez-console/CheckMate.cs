using System;
using System.Collections.Generic;
using System.Text;
using board;
using board.Enums;

namespace chess {
    class CheckMate {
        public static bool PossibleKingMove(Piece piece, Position position) {
            // Tower and queen
            //Down
            for (int i = position.line; i < 8; i++) {
                if (piece.board.ShowPosition(i, position.row) != null) {
                    if (piece.board.ShowPosition(i, position.row).color != piece.color) {
                        if (piece.board.ShowPosition(i, position.row) is Tower ||
                            piece.board.ShowPosition(i, position.row) is Queen) return false;
                        else break;
                    } else if (piece.board.ShowPosition(i, position.row) is King) {
                        continue;
                    } else break;
                }
            }
            //Up
            for (int i = position.line; i >= 0; i--) {
                if (piece.board.ShowPosition(i, position.row) != null) {
                    if (piece.board.ShowPosition(i, position.row).color != piece.color) {
                        if (piece.board.ShowPosition(i, position.row) is Tower ||
                            piece.board.ShowPosition(i, position.row) is Queen) return false;
                        else break;
                    } else if (piece.board.ShowPosition(i, position.row) is King) {
                        continue;
                    } else break;
                }
            }
            // Right
            for (int i = position.row; i < 8; i++) {
                if (piece.board.ShowPosition(position.line, i) != null) {
                    if (piece.board.ShowPosition(position.line, i).color != piece.color) {
                        if (piece.board.ShowPosition(position.line, i) is Tower ||
                            piece.board.ShowPosition(position.line, i) is Queen) return false;
                        else break;
                    } else if (piece.board.ShowPosition(position.line, i) is King) {
                        continue;
                    } else break;
                }
            }
            // Left
            for (int i = position.row; i >= 0; i--) {
                if (piece.board.ShowPosition(position.line, i) != null) {
                    if (piece.board.ShowPosition(position.line, i).color != piece.color) {
                        if (piece.board.ShowPosition(position.line, i) is Tower ||
                            piece.board.ShowPosition(position.line, i) is Queen) return false;
                        else break;
                    } else if (piece.board.ShowPosition(position.line, i) is King) {
                        continue;
                    } else break;
                }
            }
            // Bishop, Pawn and Queen
            for (int l = -1; l <= 1; l++) {
                for (int r = -1; r <= 1; r++) {
                    if (l == 0 || r == 0) {
                        continue;
                    } else {
                        for (int i = position.line + l, j = position.row + r; i >= 0 && j >= 0; i--, j--) {
                            if (piece.board.ValidatePosition(i, j)) {
                                if (piece.board.ShowPosition(i, j) != null) {
                                    if (piece.board.ShowPosition(i, j).color != piece.color) {
                                        if (i == position.line + l && piece.board.ShowPosition(i, j) is Pawn)
                                            return false;
                                        if (piece.board.ShowPosition(i, j) is Bishop ||
                                           piece.board.ShowPosition(i, j) is Queen) {
                                            return false;
                                        } else break;
                                    } else if (piece.board.ShowPosition(i, j) is King) {
                                        continue;
                                    } else break;
                                }
                            }
                        }
                    }
                }
            }
            // Horse
            for (int i = -2; i <= 2; i++) {
                for (int j = -2; j <= 2; j++) {
                    if (i != j && i != -j && i != 0 && j != 0 && piece.board.ValidatePosition(position.line + i, position.row + j)) {
                        if (piece.board.ShowPosition(position.line + i, position.row + j) != null) {
                            if (piece.board.ShowPosition(position.line + i, position.row + j).color != piece.color && piece.board.ShowPosition(position.line + i, position.row + j) is Horse) {
                                return false;
                            }
                        } 
                    }
                }
            }

            return true;
        }
    }
}
