using System;
using System.Collections.Generic;
using System.Text;
using chess;

namespace board {
    class Board {
        public int lines { get; private set; }
        public int rows { get; private set; }
        private Piece[,] piece;

        public Board() {
            lines = 8;
            rows = 8;
            piece = new Piece[lines, rows];
        }

        // Return a Piece in a specific position
        public Piece ShowPosition(int line, int row) {
            return piece[line, row];
        }
        // Overload of the previous method
        public Piece ShowPosition(Position position) {
            return piece[position.line, position.row];
        }

        // Insert a piece in the board
        public void InsertPiece(Piece newPiece) {
            piece[newPiece.position.line, newPiece.position.row] = newPiece;
        }

        //Move a specific piece
        public void MovePiece(Piece p, Position position) {
            piece[p.position.line, p.position.row] = null;
            p.position = position;
            this.InsertPiece(p);
            p.numberOfMoves++;
        }

        // Verify if a position is avaiable
        private void VerifyPosition(Position position) {
            if(position.line < 0 || position.row < 0 || position.line > 7 || position.row > 7)
                throw new PositionException("Position is out of limits");
            else return;
        }

        
    }
}
