using System;


namespace board {
    class Position {

        public int line { get; set; }
        public int row { get; set; }

        public Position (int line, int row) {
            this.line = line;
            this.row = row;
        }

        public override string ToString() {
            return "Position: (" +line+ "," +row+ ")";
        }
    }
}
