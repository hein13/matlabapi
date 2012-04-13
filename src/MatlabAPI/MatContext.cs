using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatlabAPI {
    public class MatContext {
        public MatRequest Request { get; private set; }
        public MatResponse Response { get; private set; }
        public MatEngine Engine { get; private set; }


    }
}
