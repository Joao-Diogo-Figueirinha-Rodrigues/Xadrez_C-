using System;
using System.Collections.Generic;
using System.Text;

namespace board {
    class PositionException : ApplicationException {
        public PositionException (String message) : base(message) {
        }
    }
}
