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
    public sealed class mxCellArray : mxArray {
        internal mxCellArray(SafeArrayPtr pa) : base(pa, mxArrayType.Cell) {
            CheckActive();
        }

        /// <summary>
        /// Create a cell array with two dimsensions.
        /// </summary>
        /// <param name="m">The rows of cell array.</param>
        /// <param name="n">The columns of cell array.</param>
        internal mxCellArray(int m, int n)
            : base(matrix.mxCreateCellArray(2, new int[] { m, n }), mxArrayType.Cell) {
                CheckActive();
        }

        /// <summary>
        /// Create a cell array with one dimsension.
        /// </summary>
        /// <param name="count">The length of cell array.</param>
        internal mxCellArray(int count)
            : base(matrix.mxCreateCellArray(2, new int[] { 1, count }), mxArrayType.Cell) {
            CheckActive();
        }

        /// <summary>
        /// Get a item of cell.
        /// </summary>
        /// <param name="m">The index of row.</param>
        /// <param name="n">The idnex of column.</param>
        /// <returns>The item of cell.</returns>
        public mxArray GetCell(int m, int n) {
            if (m < 0 || n < 0)
                throw new ArgumentOutOfRangeException("The m and n must be larger than zero.");

            if (m >= this.M || n >= this.N)
                throw new ArgumentOutOfRangeException("The m and n must be less than the size of the cell array.");

            SafeArrayPtr ptr = matrix.mxGetCell(this.NativeObject, n * this.M + m);
            if (ptr.IsInvalid)
                throw new ArgumentException("The item of cell may be not exists.");

            return mxArray.Create(ptr);
        }

        /// <summary>
        /// Get a item of cell.
        /// </summary>
        /// <param name="index">The index of item.</param>
        /// <returns>The array value of item.</returns>
        public mxArray GetCell(int index) {
            if (index < 0)
                throw new ArgumentOutOfRangeException("index", "The index must be larger than zero.");

            if (index >= this.Length)
                throw new ArgumentOutOfRangeException("index", "The index must be less than the length of the cell array.");

            SafeArrayPtr ptr = matrix.mxGetCell(this.NativeObject, index);
            if (ptr.IsInvalid)
                throw new ArgumentException("The item of cell may be not exists.");

            return mxArray.Create(ptr);
        }

        /// <summary>
        /// Set the item value of cell.
        /// </summary>
        /// <param name="m">The index of row.</param>
        /// <param name="n">The index of column.</param>
        /// <param name="array">The item of cell.</param>
        public void SetCell(int m, int n, mxArray array) {
            if (m < 0 || n < 0)
                throw new ArgumentOutOfRangeException("The m and n must be larger than zero.");

            if (m >= this.M || n >= this.N)
                throw new ArgumentOutOfRangeException("The m and n must be less than the size of the cell array.");

            if (array == null)
                throw new ArgumentNullException("array", "The mxArray parameter must be not null.");

            if (array.NativeObject.IsInvalid)
                throw new ArgumentException("The parameter array is invalid.", "array");

            matrix.mxSetCell(this.NativeObject, n * this.M + m, array.NativeObject);
        }

        /// <summary>
        /// Set the item value of the cell.
        /// </summary>
        /// <param name="index">The index of cell items.</param>
        /// <param name="array">The item value.</param>
        public void SetCell(int index, mxArray array) {
            if (index < 0)
                throw new ArgumentOutOfRangeException("index", "The index must be larger than zero.");

            if (index >= this.Length)
                throw new ArgumentOutOfRangeException("index", "The index must be less than the length of the cell array.");

            if (array == null)
                throw new ArgumentNullException("array", "The mxArray parameter must be not null.");

            if (array.NativeObject.IsInvalid)
                throw new ArgumentException("The parameter array is invalid.", "array");

            matrix.mxSetCell(this.NativeObject, index, array.NativeObject);
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
