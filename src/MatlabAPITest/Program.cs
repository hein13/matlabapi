using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MatlabAPI;
using MatlabAPI.Matlab;

namespace MatlabAPITest {
    class Program {
        static void Main(string[] args) {
            System.IO.MemoryMappedFiles.MemoryMappedFile mmf = System.IO.MemoryMappedFiles.MemoryMappedFile.CreateOrOpen("", 1024 * 1024 * 1024 * 2,
                 System.IO.MemoryMappedFiles.MemoryMappedFileAccess.Read,
                  System.IO.MemoryMappedFiles.MemoryMappedFileOptions.DelayAllocatePages,
                 new System.IO.MemoryMappedFiles.MemoryMappedFileSecurity(), System.IO.HandleInheritability.None);

            
            //string filename = @"E:\Program Files\MATLAB\R2009b\toolbox\gildata\cache.mat";
            //using (MatFile matFile = MatFile.Open(filename, "r")) {
            //    string[] variableNames = matFile.GetVariableNames();
            //    foreach (string vn in variableNames) {
            //        mxArray ma = matFile.GetVariable(vn);
            //    }

            //    //bool succ = matFile.PutVariable("d", new mxCharArray("hello world!"));
            //    //variableNames = matFile.GetVariableNames();
            //    //succ = matFile.DeleteVariable("a");
            //    //variableNames = matFile.GetVariableNames();
            //}
            using (MatEngine engine = new MatEngine(true)) {
                engine.Start();
                //mxLogicalArray bl = new mxLogicalArray(10, 10);

                //engine.PutVariable("a", bl);

                mxArray array = engine.GetVariable("a");

                Array a = array.ToArray();

                engine.Close();
            }
        }
    }
}