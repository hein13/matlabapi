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
using System.Linq;
using System.Text;

namespace MatlabAPI.Matlab {
    internal class mxCellArray : mxArray {
        public mxCellArray(SafeArrayPtr pa) : base(pa, mxArrayType.Cell) { }

        public mxArray GetCell(int m, int n) {
            if (m < 0 || n < 0)
                throw new ArgumentOutOfRangeException("The m and n must be larger than zero.");

            if (m >= this.M || n >= this.N)
                throw new ArgumentOutOfRangeException("The m and n must be less than the size of the cell array.");

            SafeArrayPtr pt = matrix.mxGetCell(this.NativeObject, n * this.M + m);
            
            return mxArray.Create(pt);
        }

        public mxArray[,] ToArray() {
            int m = this.M, n = this.N;
            mxArray[,] array = new mxArray[m, n];

            for (int r = 0; r < m; r++) {
                for (int c = 0; c < n; c++) {
                    array[r, c] = mxArray.Create(matrix.mxGetCell(this.NativeObject, c * m + r));
                }
            }

            return array;
        }
    }
}
