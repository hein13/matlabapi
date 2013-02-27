using System;
using System.Collections.Generic;
using System.Text;
using MatlabAPI;
using MatlabAPI.Matlab;

namespace MatlabAPITest {
    class Program {
        static void Main(string[] args) {

            using (MatEngine engine = new MatEngine(true)) {
                mxLogicalArray bl = new mxLogicalArray(10, 10);
                engine.PutVariable("a", bl);

                mxArray array = engine.GetVariable("a");

                Array a = array.ToArray();

                engine.Close();
            }
        }
    }
}