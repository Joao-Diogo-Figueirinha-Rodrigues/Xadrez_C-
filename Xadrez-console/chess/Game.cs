using System;
using System.Collections.Generic;
using System.Text;
using board;
using board.Enums;

namespace chess {
    class Game {
        public Board board { get; private set; }
        private int turn;
        private Color color;

        public Game() {
            this.board = new Board();
            BoardFunctions.BuildBoard(board);
            turn = 1;
            color = Color.White;
        }

        public void PlayTurn(Piece piece, Position position) {
            if(piece.color != this.color) {
                throw new PlayerException("You only can move " + color + " pieces!");
            }
            board.MovePiece(piece, position);
            turn++;
            if (color == Color.White) color = Color.Black;
            else color = Color.White;
        }

        public override string ToString() {
            return "Turno: " + turn + "; Jogador: " + color;
        }
    }
}
