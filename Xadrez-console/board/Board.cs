using System;
using System.Collections.Generic;
using System.Text;
using chess;
using board.Enums;

namespace board {
    class Board {
        public int lines { get; private set; }
        public int rows { get; private set; }
        private Piece[,] piece;
        public List<Piece> WhiteEated { get; set; }
        public List<Piece> BlackEated { get; set; }

        public Board() {
            lines = 8;
            rows = 8;
            piece = new Piece[lines, rows];
            WhiteEated = new List<Piece>();
            BlackEated = new List<Piece>();
        }

        // Return a Piece in a specific position
        public Piece ShowPosition(int line, int row) {
            VerifyPosition(new Position(line, row));
            return piece[line, row];
        }
        // Overload of the previous method
        public Piece ShowPosition(Position position) {
            VerifyPosition(position);
            return piece[position.line, position.row];
        }
        // Overload of the previous method
        public Piece ShowPosition(ChessPosition pos) {
            Position position = pos.ToPosition();
            VerifyPosition(position);
            return piece[position.line, position.row];
        }

        // Insert a piece in the board
        public void InsertPiece(Piece newPiece) {
            piece[newPiece.position.line, newPiece.position.row] = newPiece;
        }

        //Move a specific piece
        public void MovePiece(Piece p, Position position) {
            if (IsAvaiable(p, position) == 0) {
                if (p is King && (p.position.row == position.row + 2 || p.position.row == position.row - 2)) Castling(p, position);
                else if (p is Pawn && VerifyEnPassant(p, position)) EnPassant(p, position);
                else {
                    piece[p.position.line, p.position.row] = null;
                    p.position = position;
                    this.InsertPiece(p);
                    p.numberOfMoves++;
                    if (p is Pawn && (p.position.line == 0 || p.position.line == 7)) Promotion(p);
                }
            } else if (IsAvaiable(p, position) == 1) {
                EatPiece(p, position);
                if (p is Pawn && (p.position.line == 0 || p.position.line == 7)) Promotion(p);
            } else {
                throw new PositionException("Position is not avaiable!");
            }
        }
        // Special move castling
        private void Castling(Piece piece, Position position) {
            if (position.row == piece.position.row + 2) {
                MoveSpecial(ShowPosition(piece.position.line, piece.position.row + 3), new Position(position.line, piece.position.row + 1));
                MoveSpecial(piece, position);
            } else {
                MoveSpecial(ShowPosition(piece.position.line, piece.position.row - 4), new Position(position.line, piece.position.row - 1));
                MoveSpecial(piece, position);
            }

        }
        //Special move promotion
        private void Promotion(Piece p) {
            piece[p.position.line, p.position.row] = null;
            Piece q = new Queen(p.position, p.color, this);
            p.position = null;
            InsertPiece(q);
        }

        //Special move en passant
        private void EnPassant(Piece piece, Position position) {
            if (piece.color == Color.White) {
                EatPiece(piece, new Position(position.line + 1, position.row));
                MoveSpecial(piece, position);
            } else {
                EatPiece(piece, new Position(position.line - 1, position.row));
                MoveSpecial(piece, position);
            }
        }

        // Verify if it's possible to make an en passent
        private bool VerifyEnPassant(Piece piece, Position position) {
            if (position.row != piece.position.row &&
            ShowPosition(position) == null)
                return true;
            else return false;
        }

        // Verify if a position is avaiable
        private void VerifyPosition(Position position) {
            if (position.line < 0 || position.row < 0 || position.line > 7 || position.row > 7)
                throw new PositionException("Position is out of limits");
            else return;
        }

        // Validates a position
        public bool ValidatePosition(Position position) {
            if (position.line < 0 || position.row < 0 || position.line > 7 || position.row > 7)
                return false;
            else return true;
        }

        // Overload of ValidatePosition
        public bool ValidatePosition(int line, int row) {
            if (line < 0 || row < 0 || line > 7 || row > 7)
                return false;
            else return true;
        }

        // Verify if a position is avaiable
        private int IsAvaiable(Piece piece, Position position) {
            bool[,] moves = piece.PossibleMoves();
            if (moves[position.line, position.row] == true) {
                if (ShowPosition(position) != null && ShowPosition(position).color != piece.color)
                    return 1;
                else return 0;
            } else {
                return -1;
            }

        }

        // Method invoqued when a piece is eated
        public void EatPiece(Piece p, Position position) {
            Piece aux = ShowPosition(position);
            aux.position = null;
            if (aux.color == Color.White) {
                WhiteEated.Add(aux);
            } else BlackEated.Add(aux);
            this.piece[position.line, position.row] = null;
            if (p is Pawn) MoveSpecial(p, position);
            else MovePiece(p, position);
        }

        // Shows the pieces that where eated
        public void ShowEated(List<Piece> list) {
            foreach (Piece piece in list) {
                Console.Write(piece + " ");
            }
        }

        // Method invoqued after a pawn eat a piece or a special move
        private void MoveSpecial(Piece p, Position position) {
            piece[p.position.line, p.position.row] = null;
            p.position = position;
            this.InsertPiece(p);
            p.numberOfMoves++;
        }

        public Piece FindBlackKing() {
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (ShowPosition(i, j) is King && ShowPosition(i, j).color == Color.Black)
                        return ShowPosition(i, j);
                }
            }
            return null;
        }

        public Piece FindWhiteKing() {
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (ShowPosition(i, j) is King && ShowPosition(i, j).color == Color.White)
                        return ShowPosition(i, j);
                }
            }
            return null;
        }
        //Implementaion: Use ShowPosition
        // Tries a move with the possibility of check
        public bool TryMove(Piece piece, Position position) {
            Piece aux = null;
            if (this.piece[position.line, position.row] != null)
                aux = this.piece[position.line, position.row];
            this.piece[position.line, position.row] = piece;
            this.piece[piece.position.line, piece.position.row] = null;
            bool verify;
            if (piece.color == Color.Black)
                verify = CheckMate.PossibleKingMove(FindBlackKing(), FindBlackKing().position);
            else verify = CheckMate.PossibleKingMove(FindWhiteKing(), FindWhiteKing().position);
            this.piece[position.line, position.row] = aux;
            this.piece[piece.position.line, piece.position.row] = piece;
            return verify;
        }

        // Verify if a Piece as Possible moves
        public bool AvaiableMove(Piece piece) {
            bool[,] moves = piece.PossibleMoves();
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (moves[i, j]) return true;
                }
            }
            return false;
        }

        // Verify if is CheckMate
        public bool VerifyCheckMate(Color color) {
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (ShowPosition(i, j) != null && ShowPosition(i, j).color != color)
                        if (AvaiableMove(ShowPosition(i, j))) return true;
                }
            }
            return false;
        }
    }
}
