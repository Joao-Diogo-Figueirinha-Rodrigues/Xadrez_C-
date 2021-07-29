using System;
using System.Collections.Generic;
using System.Text;
using board;
using board.Enums;

namespace chess {
    class Bishop : Piece{

        public Bishop (Position position, Color color, Board board) 
            : base(position, color, board) {
        }

        public override string ToString() {
            return "B";
        }

    }
}
