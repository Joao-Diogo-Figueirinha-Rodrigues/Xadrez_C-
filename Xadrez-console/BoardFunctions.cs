using System;
using System.Collections.Generic;
using System.Text;
using board;
using chess;
using board.Enums;

namespace board {
    class BoardFunctions {

        public static void Show(Board board) {
            Piece piece;
            Console.WriteLine("  _________________");
            for (int i = 0; i < board.lines; i++) {
                Console.Write(8 - i + "| ");
                for (int j = 0; j < board.rows; j++) {
                    piece = board.ShowPosition(i, j);
                    if (piece == null) Console.Write("- ");
                    else {
                        PrintPiece(piece); // Possible improvement (aula 164)
                    }
                    if (j == board.rows - 1) Console.Write("|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("  -----------------");
            Console.WriteLine("   A B C D E F G H ");
            Console.WriteLine();
            Console.Write("Black: ");
            board.ShowEated(board.BlackEated);
            Console.WriteLine();
            Console.Write("White: ");
            board.ShowEated(board.WhiteEated);
            Console.WriteLine();

        }
        // Overload of Show
        public static void Show(Board board, Piece p) {
            bool[,] moves = p.PossibleMoves();
            Piece piece;
            ConsoleColor original = Console.BackgroundColor;
            ConsoleColor changed = ConsoleColor.DarkGray;

            Console.WriteLine("  _________________");
            for (int i = 0; i < board.lines; i++) {
                Console.Write(8 - i + "| ");
                for (int j = 0; j < board.rows; j++) {
                    // Change Color
                    if (moves[i, j]) Console.BackgroundColor = changed;
                    

                    piece = board.ShowPosition(i, j);
                    if (piece == null) Console.Write("- ");
                    else {
                        if (new Position(i, j).line == p.position.line &&
                            new Position(i, j).row == p.position.row) {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            PrintPiece(piece);
                            Console.BackgroundColor = original;
                        } else PrintPiece(piece); // Possible improvement (aula 164)
                    }
                    Console.BackgroundColor = original;
                    if (j == board.rows - 1) Console.Write("|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("  -----------------");
            Console.WriteLine("   A B C D E F G H ");
            Console.WriteLine();
            Console.Write("Black: ");
            board.ShowEated(board.BlackEated);
            Console.WriteLine();
            Console.Write("White: ");
            board.ShowEated(board.WhiteEated);
            Console.WriteLine();

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
                    Piece blackHorseman = new Horse(new Position(0, i), Color.Black, board);
                    board.InsertPiece(blackHorseman);

                    Piece WhiteHorseman = new Horse(new Position(7, i), Color.White, board);
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

        static void PrintPiece(Piece piece) {
            if (piece.color == Color.Black) {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece + " ");
                Console.ForegroundColor = aux;
            } else {
                Console.Write(piece + " ");
            }
        }

    }
}
