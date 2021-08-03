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

        // Insert a piece in the board
        public void InsertPiece(Piece newPiece) {
            piece[newPiece.position.line, newPiece.position.row] = newPiece;
        }

        //Move a specific piece
        public void MovePiece(Piece p, Position position) {
            bool[,] moves = p.PossibleMoves();
            if (IsAvaiable(p, position) == 0) {
                piece[p.position.line, p.position.row] = null;
                p.position = position;
                this.InsertPiece(p);
                p.numberOfMoves++;
            } else if (IsAvaiable(p, position) == 1) {
                EatPiece(p, position);
            } else {
                throw new PositionException("Position is not empty!");
            }
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
            if (moves[position.line, position.row]==true) {
                if ( ShowPosition(position) != null && ShowPosition(position).color != piece.color)
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
            if (p is Pawn) PawnsEat(p, position);
            else MovePiece(p, position);
        }

        // Shows the pieces that where eated
        public void ShowEated(List<Piece> list) {
            foreach(Piece piece in list) {
                Console.Write(piece + " ");
            }
        }

        // Method invoqued after a pawn eat a piece
        private void PawnsEat(Piece p, Position position) {
            piece[p.position.line, p.position.row] = null;
            p.position = position;
            this.InsertPiece(p);
            p.numberOfMoves++;
        }

    }
}
