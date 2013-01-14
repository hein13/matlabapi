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
using System.Runtime.InteropServices;
using System.Text;
using MatlabAPI.Matlab;

namespace MatlabAPI {
    public sealed class mxCharArray : mxArray {
        #region Constructors

        internal mxCharArray(SafeArrayPtr pa) : base(pa, mxArrayType.Char) { }

        /// <summary>
        /// Create a char array by a string.
        /// </summary>
        /// <param name="value">The string value.</param>
        public mxCharArray(string value){
            if (value == null)
                value = string.Empty;

            SafeArrayPtr pa = matrix.mxCreateString(value);
            CreateArray(pa, mxArrayType.Char);
        }

        #endregion

        public override string ToString() {
            IntPtr ptr = matrix.mxGetData(this.NativeObject);
            if(ptr == IntPtr.Zero)
                return string.Empty;

            byte[] buffer = new byte[this.Length * this.ElementSize];
            Marshal.Copy(ptr, buffer, 0, buffer.Length);
            return Encoding.Unicode.GetString(buffer);
        }

        public override Array ToArray() {
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
