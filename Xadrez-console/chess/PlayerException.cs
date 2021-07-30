using System;
using System.Collections.Generic;
using System.Text;

namespace chess {
    class PlayerException : ApplicationException {
        public PlayerException(String message) : base(message) {
        }
    }
}
