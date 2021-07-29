using System;
using System.Collections.Generic;
using System.Text;
using board;
using chess;
using board.Enums;

namespace Xadrez_console {
    class BoardFunctions {

        public static void Show(Board board) {
            Piece piece;
            for (int i = 0; i < board.lines; i++) {
                for (int j = 0; j < board.rows; j++) {
                    piece = board.ShowPosition(i, j);
                    if (piece == null) Console.Write("- ");
                    else Console.Write(piece.ToString() + " ");
                }
                Console.WriteLine();
            }
        }

        public static void BuildBoard(Board board) {

            for (int i = 0; i < 8; i++) {
                Piece blackPawn = new Pawn(new Position(1, i), Color.Black, board);
                board.InsertPiece(blackPawn);

                Piece whitePawn = new Pawn(new Position(6, i), Color.White, board);
                board.InsertPiece(whitePawn);

                if (i == 0 || i == 7) {
                    Piece blackTower = new Tower(new Position(0, i), Color.Black, board);
                    board.InsertPiece(blackTower);

                    Piece WhiteTower = new Tower(new Position(7, i), Color.White, board);
                    board.InsertPiece(WhiteTower);

                } else if (i == 1 || i == 6) {
                    Piece blackHorseman = new Horseman(new Position(0, i), Color.Black, board);
                    board.InsertPiece(blackHorseman);

                    Piece WhiteHorseman = new Horseman(new Position(7, i), Color.White, board);
                    board.InsertPiece(WhiteHorseman);

                } else if (i == 2 || i == 5) {
                    Piece blackBishop = new Bishop(new Position(0, i), Color.Black, board);
                    board.InsertPiece(blackBishop);

                    Piece WhiteBishop = new Bishop(new Position(7, i), Color.White, board);
                    board.InsertPiece(WhiteBishop);

                } else if (i == 3) {
                    Piece blackQueen = new Queen(new Position(0, i), Color.Black, board);
                    board.InsertPiece(blackQueen);

                    Piece WhiteQueen = new Queen(new Position(7, i), Color.White, board);
                    board.InsertPiece(WhiteQueen);

                } else {
                    Piece blackKing = new King(new Position(0, i), Color.Black, board);
                    board.InsertPiece(blackKing);

                    Piece WhiteKing = new King(new Position(7, i), Color.White, board);
                    board.InsertPiece(WhiteKing);
                }
            }
        }
    }
}
