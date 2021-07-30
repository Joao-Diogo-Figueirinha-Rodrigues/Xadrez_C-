using System;
using System.Collections.Generic;
using System.Text;
using board;


namespace chess {
    class ChessPosition {

        public char row { get; set; }
        public int line { get; set; }

        public ChessPosition(char row, int line) {
            this.row = row;
            this.line = line;
        }
        public Position ToPosition() {
            return new Position(8 - line, row - 'A');
        }
    }
}
