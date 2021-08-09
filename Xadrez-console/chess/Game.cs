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
        public bool checkMate { get; private set; }
        public bool check { get; private set; }

        public Game() {
            this.board = new Board();
            BoardFunctions.BuildBoard(board);
            turn = 1;
            color = Color.White;
            checkMate = true;
            check = true;
        }

        public void PlayTurn(Piece piece, ChessPosition pos) {
            Position position = pos.ToPosition();
            if (piece.color != this.color) {
                throw new PlayerException("You only can move " + color + " pieces!");
            }
            board.MovePiece(piece, position);
            if (color == Color.White)
                check = CheckMate.PossibleKingMove(board.FindBlackKing(), board.FindBlackKing().position);
            else check = CheckMate.PossibleKingMove(board.FindWhiteKing(), board.FindWhiteKing().position);
            if (!check) checkMate = board.VerifyCheckMate(color);
            turn++;
            if (color == Color.White) color = Color.Black;
            else color = Color.White;
        }

        public void Winner() {
            if (color == Color.White) color = Color.Black;
            else color = Color.White;
            Console.WriteLine("CheckMate");
            Console.WriteLine(color + " player wins!");
        }

        public void AvaiablePiece (Piece piece) {
            if(piece.color != color)
                throw new PlayerException("You only can move " + color + " pieces!");
            if (!board.AvaiableMove(piece))
                throw new PositionException("This Piece hasn't avaiable moves!");
        }



        public override string ToString() {
            return "Turno: " + turn + "; Jogador: " + color;
        }
    }
}
