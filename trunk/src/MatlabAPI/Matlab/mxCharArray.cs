/*
 * Copyright (c) 2012 Jeff<guangboo49@gmail.com>
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of 
 * this software and associated documentation files (the "Software"), 
 * to deal in the Software without restriction, including without limitation the 
 * rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
 * copies of the Software, and to permit persons to whom the Software is furnished 
 * to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all 
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
 * PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION 
 * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;


namespace MatlabAPI.Matlab {
    internal class mxCharArray : mxArray {
        public mxCharArray(SafeArrayPtr pa) : base(pa, mxArrayType.Char) { }

        public mxCharArray(string value) : 
            base(matrix.mxCreateString(value), mxArrayType.Char, 2, new int[]{1, value.Length}) {
            CheckActive();
        }

        public override string ToString() {
            IntPtr ptr = matrix.mxGetData(this.NativeObject);
            if(ptr == IntPtr.Zero)
                return string.Empty;

            byte[] buffer = new byte[this.Length * this.ElementSize];
            Marshal.Copy(ptr, buffer, 0, buffer.Length);
            return Encoding.Unicode.GetString(buffer);
        }

        public Array ToArray() {
            int m = this.M, n = this.N;
            char[] tmpch = new char[n];
            string[] strarray = new string[m];
            string str = this.ToString();

            for (int r = 0; r < m; r++) {
                for (int c = 0; c < n; c++) {
                    tmpch[c] = str[c * m + r];
                }

                strarray[r] = new string(tmpch);
            }

            return strarray;
        }
    }
}
