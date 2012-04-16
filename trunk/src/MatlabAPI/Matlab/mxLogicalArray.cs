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

namespace MatlabAPI.Matlab {
    public class mxLogicalArray : mxArray {
        internal mxLogicalArray(SafeArrayPtr pa) : base(pa, mxArrayType.Logical) { }

        /// <summary>
        /// Create a logical array of one item, the value is false.
        /// </summary>
        public mxLogicalArray() : this(false) { }

        /// <summary>
        /// Create a logical array of one dimsension with false value.
        /// </summary>
        /// <param name="count">The length of logical array.</param>
        public mxLogicalArray(int count) : this(false, count) { }

        /// <summary>
        /// Create a logical array of one dimsension with value.
        /// </summary>
        /// <param name="value">The value of logical array.</param>
        public mxLogicalArray(bool value)
            : base(matrix.mxCreateLogicalScalar(value), mxArrayType.Logical) {
                CheckActive();
        }

        /// <summary>
        /// Create a logical array of two dimsensions with false value.
        /// </summary>
        /// <param name="m">The rows of logical array.</param>
        /// <param name="n">The columns of logical array.</param>
        public mxLogicalArray(int m, int n)
            : base(matrix.mxCreateLogicalArray(2, new int[] { m, n }), mxArrayType.Logical) {
                CheckActive();
        }

        /// <summary>
        /// Create a logical array of one dimension with given value.
        /// </summary>
        /// <param name="value">The given value.</param>
        /// <param name="count">The length of logical array.</param>
        public mxLogicalArray(bool value, int count)
            : base(matrix.mxCreateLogicalArray(2,new int[]{1, count}), mxArrayType.Logical) {
            CheckActive();

            if (count < 1)
                throw new ArgumentOutOfRangeException("count", "The count must be larger than zero.");

            byte[] buf = new byte[count * BitConverterExtesions.bool_size];
            byte v = value ? (byte)1 : (byte)0;
            for (int i = 0; i < count; i++) {
                buf[i] = v;
            }

            IntPtr ptr = matrix.mxGetData(this.NativeObject);
            Marshal.Copy(buf, 0, ptr, count);
        }

        /// <summary>
        /// Create a logical array of two dimensions with given value.
        /// </summary>
        /// <param name="value">The given value.</param>
        /// <param name="rows">The rows of logical array.</param>
        /// <param name="cols">The columns of logical array.</param>
        public mxLogicalArray(bool value, int rows, int cols)
            : base(matrix.mxCreateLogicalArray(2, new int[] { rows, cols }), mxArrayType.Logical) {
            CheckActive();

            if (rows < 1 || cols < 1)
                throw new ArgumentOutOfRangeException("rows", "The rows and cols must be larger than zero.");

            byte[] buf = new byte[rows * cols * BitConverterExtesions.bool_size];
            byte v = value ? (byte)1 : (byte)0;
            for (int i = 0; i < buf.Length; i++) {
                buf[i] = v;
            }

            IntPtr ptr = matrix.mxGetData(this.NativeObject);
            Marshal.Copy(buf, 0, ptr, buf.Length);
        }

        /// <summary>
        /// Create a logical array of one dimsension with bool array.
        /// </summary>
        /// <param name="values">The bool array.</param>
        public mxLogicalArray(bool[] values)
            : base(matrix.mxCreateLogicalArray(2, new int[] { 1, values.Length }), mxArrayType.Logical) {
                CheckActive();
                byte[] buf = BitConverterExtesions.GetBytes(values);
                IntPtr ptr = matrix.mxGetData(this.NativeObject);
                Marshal.Copy(buf, 0, ptr, buf.Length);
        }

        /// <summary>
        /// Create a logical array of two dimsensions with bool array.
        /// </summary>
        /// <param name="values">The given bool array.</param>
        public mxLogicalArray(bool[,] values)
            : base(matrix.mxCreateLogicalArray(2, new int[] { values.GetLength(0), values.GetLength(1) }), mxArrayType.Logical) {
            CheckActive();
            byte[] buf = BitConverterExtesions.GetBytes(values);
            IntPtr ptr = matrix.mxGetData(this.NativeObject);
            Marshal.Copy(buf, 0, ptr, buf.Length);
        }

        public bool[,] ToArray() {
            IntPtr ptr = matrix.mxGetLogicals(this.NativeObject);
            int row = this.M, col = this.N;
            int size = this.ElementSize;

            byte[] buffer = new byte[row * col * size];
            Marshal.Copy(ptr, buffer, 0, buffer.Length);
            return BitConverterExtesions.ToArray(buffer, row, col);
        }
    }
}
