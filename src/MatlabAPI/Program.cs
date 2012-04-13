using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using MatlabAPI.Matlab;

namespace MatlabAPI {
    class Program {
        static void Main(){

            using (MatEngine engine = new MatEngine(true)) {
                engine.Start();

                engine.PutVariable("a", new mxCharArray("Hello world!"));

                mxArray array = engine.GetVariable("a");
                mxCharArray v = (mxCharArray)array;
                Array a = v.ToArray();

                engine.Close();
            }

            //Console.Read();
        }


    }
}
