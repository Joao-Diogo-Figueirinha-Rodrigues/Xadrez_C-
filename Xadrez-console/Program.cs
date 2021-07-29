using System;
using board;
using board.Enums;
using chess;

namespace Xadrez_console {
    class Program {
        static void Main(string[] args) {

            Board board = new Board();
            BoardFunctions.BuildBoard(board);
            BoardFunctions.Show(board);

        }
    }
}
