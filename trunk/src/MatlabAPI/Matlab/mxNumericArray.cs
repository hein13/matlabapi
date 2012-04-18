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
using System.Text;
using System.Runtime.InteropServices;

namespace MatlabAPI.Matlab {
    public class mxNumericArray : mxArray {
        public mxNumericType NumericType { get; private set; }

        #region constructors

        #region with pointer

        internal mxNumericArray(SafeArrayPtr pa) : base(pa, mxArrayType.Numeric) {
            CheckActive();
            mxClassID clsId = matrix.mxGetClassID(this.NativeObject);

            int clsIdInt = (int)clsId;
            // isNumeric
            if (clsIdInt >= 6 && clsIdInt <= 15) {
                this.NumericType = (mxNumericType)clsIdInt;
            } else {
                throw new ArgumentException("The argument is not a numeric.");
            }
        }

        #endregion

        #region scalar value and img part

        public mxNumericArray(sbyte value) : this(BitConverter.GetBytes(value), mxNumericType.INT8) { }
        public mxNumericArray(byte value) : this(new byte[]{value}, mxNumericType.UINT8) { }
        public mxNumericArray(short value) : this(BitConverter.GetBytes(value), mxNumericType.INT16) { }
        public mxNumericArray(ushort value) : this(BitConverter.GetBytes(value), mxNumericType.UINT16) { }
        public mxNumericArray(int value) : this(BitConverter.GetBytes(value), mxNumericType.INT32) { }
        public mxNumericArray(uint value) : this(BitConverter.GetBytes(value), mxNumericType.UINT32) { }
        public mxNumericArray(long value) : this(BitConverter.GetBytes(value), mxNumericType.INT64) { }
        public mxNumericArray(ulong value) : this(BitConverter.GetBytes(value), mxNumericType.UINT64) { }
        public mxNumericArray(float value) : this(BitConverter.GetBytes(value), mxNumericType.SINGLE) { }
        public mxNumericArray(double value) : this(BitConverter.GetBytes(value), mxNumericType.DOUBLE) { }

        public mxNumericArray(sbyte realValue, sbyte imgValue) : this(BitConverter.GetBytes(realValue), BitConverter.GetBytes(imgValue), mxNumericType.INT8) { }
        public mxNumericArray(byte realValue, byte imgValue) : this(new byte[] { realValue }, new byte[] { imgValue }, mxNumericType.UINT8) { }
        public mxNumericArray(short realValue, short imgValue) : this(BitConverter.GetBytes(realValue), BitConverter.GetBytes(imgValue), mxNumericType.INT16) { }
        public mxNumericArray(ushort realValue, ushort imgValue) : this(BitConverter.GetBytes(realValue), BitConverter.GetBytes(imgValue), mxNumericType.UINT16) { }
        public mxNumericArray(int realValue, int imgValue) : this(BitConverter.GetBytes(realValue), BitConverter.GetBytes(imgValue), mxNumericType.INT32) { }
        public mxNumericArray(uint realValue, uint imgValue) : this(BitConverter.GetBytes(realValue), BitConverter.GetBytes(imgValue), mxNumericType.UINT32) { }
        public mxNumericArray(long realValue, long imgValue) : this(BitConverter.GetBytes(realValue), BitConverter.GetBytes(imgValue), mxNumericType.INT64) { }
        public mxNumericArray(ulong realValue, ulong imgValue) : this(BitConverter.GetBytes(realValue), BitConverter.GetBytes(imgValue), mxNumericType.UINT64) { }
        public mxNumericArray(float realValue, float imgValue) : this(BitConverter.GetBytes(realValue), BitConverter.GetBytes(imgValue), mxNumericType.SINGLE) { }
        public mxNumericArray(double realValue, double imgValue) : this(BitConverter.GetBytes(realValue), BitConverter.GetBytes(imgValue), mxNumericType.DOUBLE) { }

        #endregion

        #region array with one dimensions and img parts

        public mxNumericArray(sbyte[] values) 
            : this(BitConverterExtesions.GetBytes(values), BitConverterExtesions.byte_size, mxNumericType.INT8) { }
        
        public mxNumericArray(byte[] values) 
            : this(values, BitConverterExtesions.byte_size, mxNumericType.UINT8) { }

        public mxNumericArray(short[] values)
            : this(BitConverterExtesions.GetBytes(values), BitConverterExtesions.short_size, mxNumericType.INT16) { }

        public mxNumericArray(ushort[] values)
            : this(BitConverterExtesions.GetBytes(values), BitConverterExtesions.ushort_size, mxNumericType.UINT16) { }

        public mxNumericArray(int[] values)
            : this(BitConverterExtesions.GetBytes(values), BitConverterExtesions.int_size, mxNumericType.INT32) { }

        public mxNumericArray(uint[] values)
            : this(BitConverterExtesions.GetBytes(values), BitConverterExtesions.uint_size, mxNumericType.UINT32) { }

        public mxNumericArray(long[] values)
            : this(BitConverterExtesions.GetBytes(values), BitConverterExtesions.long_size, mxNumericType.INT64) { }

        public mxNumericArray(ulong[] values)
            : this(BitConverterExtesions.GetBytes(values), BitConverterExtesions.ulong_size, mxNumericType.UINT64) { }

        public mxNumericArray(float[] values)
            : this(BitConverterExtesions.GetBytes(values), BitConverterExtesions.float_size, mxNumericType.SINGLE) { }

        public mxNumericArray(double[] values)
            : this(BitConverterExtesions.GetBytes(values), BitConverterExtesions.double_size, mxNumericType.DOUBLE) { }

        public mxNumericArray(sbyte[] realValues, sbyte[] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), BitConverterExtesions.byte_size, mxNumericType.INT8) { }

        public mxNumericArray(byte[] realValues, byte[] imgValues)
            : this(realValues, imgValues, BitConverterExtesions.byte_size, mxNumericType.UINT8) { }

        public mxNumericArray(short[] realValues, short[] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), BitConverterExtesions.short_size, mxNumericType.INT16) { }

        public mxNumericArray(ushort[] realValues, ushort[] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), BitConverterExtesions.ushort_size, mxNumericType.UINT16) { }

        public mxNumericArray(int[] realValues, int[] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), BitConverterExtesions.int_size, mxNumericType.INT32) { }

        public mxNumericArray(uint[] realValues, uint[] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), BitConverterExtesions.uint_size, mxNumericType.UINT32) { }

        public mxNumericArray(long[] realValues, long[] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), BitConverterExtesions.long_size, mxNumericType.INT64) { }

        public mxNumericArray(ulong[] realValues, ulong[] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), BitConverterExtesions.ulong_size, mxNumericType.UINT64) { }

        public mxNumericArray(float[] realValues, float[] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), BitConverterExtesions.float_size, mxNumericType.SINGLE) { }

        public mxNumericArray(double[] realValues, double[] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), BitConverterExtesions.double_size, mxNumericType.DOUBLE) { }

        #endregion

        #region array with two dimensions and img parts

        public mxNumericArray(sbyte[,] values)
            : this(BitConverterExtesions.GetBytes(values), values.GetLength(0), values.GetLength(1), mxNumericType.INT8) { }

        public mxNumericArray(byte[,] values)
            : this(BitConverterExtesions.GetBytes(values), values.GetLength(0), values.GetLength(1), mxNumericType.UINT8) { }

        public mxNumericArray(short[,] values)
            : this(BitConverterExtesions.GetBytes(values), values.GetLength(0), values.GetLength(1), mxNumericType.INT16) { }

        public mxNumericArray(ushort[,] values)
            : this(BitConverterExtesions.GetBytes(values), values.GetLength(0), values.GetLength(1), mxNumericType.UINT16) { }

        public mxNumericArray(int[,] values)
            : this(BitConverterExtesions.GetBytes(values), values.GetLength(0), values.GetLength(1), mxNumericType.INT32) { }

        public mxNumericArray(uint[,] values)
            : this(BitConverterExtesions.GetBytes(values), values.GetLength(0), values.GetLength(1), mxNumericType.UINT32) { }

        public mxNumericArray(long[,] values)
            : this(BitConverterExtesions.GetBytes(values), values.GetLength(0), values.GetLength(1), mxNumericType.INT64) { }

        public mxNumericArray(ulong[,] values)
            : this(BitConverterExtesions.GetBytes(values), values.GetLength(0), values.GetLength(1), mxNumericType.UINT64) { }

        public mxNumericArray(float[,] values)
            : this(BitConverterExtesions.GetBytes(values), values.GetLength(0), values.GetLength(1), mxNumericType.SINGLE) { }

        public mxNumericArray(double[,] values)
            : this(BitConverterExtesions.GetBytes(values), values.GetLength(0), values.GetLength(1), mxNumericType.DOUBLE) { }

        public mxNumericArray(sbyte[,] realValues, sbyte[,] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), realValues.GetLength(0), realValues.GetLength(1), mxNumericType.INT8) { }

        public mxNumericArray(byte[,] realValues, byte[,] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), realValues.GetLength(0), realValues.GetLength(1), mxNumericType.UINT8) { }

        public mxNumericArray(short[,] realValues, short[,] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), realValues.GetLength(0), realValues.GetLength(1), mxNumericType.INT16) { }

        public mxNumericArray(ushort[,] realValues, ushort[,] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), realValues.GetLength(0), realValues.GetLength(1), mxNumericType.UINT16) { }

        public mxNumericArray(int[,] realValues, int[,] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), realValues.GetLength(0), realValues.GetLength(1), mxNumericType.INT32) { }

        public mxNumericArray(uint[,] realValues, uint[,] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), realValues.GetLength(0), realValues.GetLength(1), mxNumericType.UINT32) { }

        public mxNumericArray(long[,] realValues, long[,] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), realValues.GetLength(0), realValues.GetLength(1), mxNumericType.INT64) { }

        public mxNumericArray(ulong[,] realValues, ulong[,] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), realValues.GetLength(0), realValues.GetLength(1), mxNumericType.UINT64) { }

        public mxNumericArray(float[,] realValues, float[,] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), realValues.GetLength(0), realValues.GetLength(1), mxNumericType.SINGLE) { }

        public mxNumericArray(double[,] realValues, double[,] imgValues)
            : this(BitConverterExtesions.GetBytes(realValues), BitConverterExtesions.GetBytes(imgValues), realValues.GetLength(0), realValues.GetLength(1), mxNumericType.DOUBLE) { }

        #endregion

        #region protected internal

        protected internal mxNumericArray(byte[] bytes, mxNumericType numType) 
            : this(bytes, bytes.Length, numType) {}

        protected internal mxNumericArray(byte[] realBytes, byte[] imgBytes, mxNumericType numType) :
            this(realBytes, imgBytes, realBytes.Length, numType) { }

        protected internal mxNumericArray(byte[] values, int size, mxNumericType numType) {
            SafeArrayPtr pa = matrix.mxCreateNumericArray(2, new int[] { 1, values.Length / size }, numType, mxComplexity.mxREAL);
            CreateArray(pa, mxArrayType.Numeric);

            this.NumericType = numType;
            IntPtr ptr = matrix.mxGetData(this.NativeObject);
            Marshal.Copy(values, 0, ptr, values.Length);
        }

        protected internal mxNumericArray(byte[] values, int m, int n, mxNumericType numType) {
            SafeArrayPtr pa = matrix.mxCreateNumericArray(2, new int[] { m, n }, numType, mxComplexity.mxREAL);
            CreateArray(pa, mxArrayType.Numeric);

            this.NumericType = numType;
            IntPtr ptr = matrix.mxGetData(this.NativeObject);
            Marshal.Copy(values, 0, ptr, values.Length);
        }

        protected internal mxNumericArray(byte[] realBytes, byte[] imgBytes, int size, mxNumericType numType) {
            SafeArrayPtr pa = matrix.mxCreateNumericArray(2, new int[] { 1, realBytes.Length / size }, numType, mxComplexity.mxCOMPLEX);
            CreateArray(pa, mxArrayType.Numeric);

            this.NumericType = numType;
            IntPtr realPtr = matrix.mxGetData(this.NativeObject);
            IntPtr imgPtr = matrix.mxGetImagData(this.NativeObject);

            Marshal.Copy(realBytes, 0, realPtr, realBytes.Length);
            Marshal.Copy(imgBytes, 0, imgPtr, imgBytes.Length);
        }

        protected internal mxNumericArray(byte[] realBytes, byte[] imgBytes, int m, int n, mxNumericType numType) {
            SafeArrayPtr pa = matrix.mxCreateNumericArray(2, new int[] { m, n}, numType, mxComplexity.mxCOMPLEX);
            CreateArray(pa, mxArrayType.Numeric);

            this.NumericType = numType;
            IntPtr realPtr = matrix.mxGetData(this.NativeObject);
            IntPtr imgPtr = matrix.mxGetImagData(this.NativeObject);

            Marshal.Copy(realBytes, 0, realPtr, realBytes.Length);
            Marshal.Copy(imgBytes, 0, imgPtr, imgBytes.Length);
        }

        #endregion

        #endregion

        #region isXXXX

        /// <summary>
        /// Check if the type of value is complex.
        /// </summary>
        public bool IsComplex { get { return matrix.mxIsComplex(this.NativeObject); } }
        
        /// <summary>
        /// Check if the type of value is int8.
        /// </summary>
        public bool IsInt8 { get { return matrix.mxIsInt8(this.NativeObject); } }

        /// <summary>
        /// Check if the type of value is int16.
        /// </summary>
        public bool IsInt16 { get { return matrix.mxIsInt16(this.NativeObject); } }

        /// <summary>
        /// Check if the type of value is int32.
        /// </summary>
        public bool IsInt32 { get { return matrix.mxIsInt32(this.NativeObject); } }

        /// <summary>
        /// Check if the type of value is int64.
        /// </summary>
        public bool IsInt64 { get { return matrix.mxIsInt64(this.NativeObject); } }

        /// <summary>
        /// Check if the type of value is uint8.
        /// </summary>
        public bool IsUInt8 { get { return matrix.mxIsUint8(this.NativeObject); } }

        /// <summary>
        /// Check if the type of value is uint16.
        /// </summary>
        public bool IsUInt16 { get { return matrix.mxIsUint16(this.NativeObject); } }

        /// <summary>
        /// Check if the type of value is uint32.
        /// </summary>
        public bool IsUInt32 { get { return matrix.mxIsUint32(this.NativeObject); } }

        /// <summary>
        /// Check if the type of value is uint64.
        /// </summary>
        public bool IsUInt64 { get { return matrix.mxIsUint64(this.NativeObject); } }

        /// <summary>
        /// Check if the type of value is float.
        /// </summary>
        public bool IsSingle { get { return matrix.mxIsSingle(this.NativeObject); } }

        /// <summary>
        /// Check if the type of value is double.
        /// </summary>
        public bool IsDouble { get { return matrix.mxIsDouble(this.NativeObject); } }

        #endregion

        public double ScalarValue { get { return matrix.mxGetScalar(this.NativeObject); } }

        public override string ToString() {
            return ScalarValue.ToString();
        }

        public override Array ToArray() {
            IntPtr ptr = matrix.mxGetData(base.NativeObject);
            int m = this.M, n = this.N, size = this.ElementSize;
            byte[] buffer = new byte[m * n * size];
            
            Marshal.Copy(ptr, buffer, 0, buffer.Length);
            return BitConverterExtesions.ToArray(buffer, m, n, this.NumericType);
        }
    }
}
