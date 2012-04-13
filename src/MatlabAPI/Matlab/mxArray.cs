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
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace MatlabAPI.Matlab {
    public class mxArray : ICloneable, IDisposable {
        public mxArrayType ArrayType { get; private set; }
        internal SafeArrayPtr NativeObject { get; private set; }

        internal  mxArray(SafeArrayPtr pa) : this(pa, mxArrayType.Array) { }

        internal mxArray(SafeArrayPtr pa, mxArrayType arrayType) : this(pa, arrayType, 2, new int[] { 1, 1 }) { }

        internal mxArray(SafeArrayPtr pa, mxArrayType arrayType, int dimCount, int[] dimensions) {
            this.NativeObject = pa;
            this.ArrayType = arrayType;
        }

        internal static mxArray Create(SafeArrayPtr pa) {
            if (pa.IsInvalid)
                throw new ArgumentException("pa");

            mxClassID clsId = matrix.mxGetClassID(pa);

            switch (clsId) {
                case mxClassID.mxDOUBLE_CLASS:
                case mxClassID.mxINT16_CLASS:
                case mxClassID.mxINT32_CLASS:
                case mxClassID.mxINT64_CLASS:
                case mxClassID.mxINT8_CLASS:
                case mxClassID.mxSINGLE_CLASS:
                case mxClassID.mxUINT16_CLASS:
                case mxClassID.mxUINT32_CLASS:
                case mxClassID.mxUINT64_CLASS:
                case mxClassID.mxUINT8_CLASS:
                    return new mxNumericArray(pa);
                case mxClassID.mxLOGICAL_CLASS:
                    return new mxLogicalArray(pa);
                case mxClassID.mxCELL_CLASS:
                    return new mxCellArray(pa);
                case mxClassID.mxCHAR_CLASS:
                    return new mxCharArray(pa);
            }

            return null;
        }

        //public mxArray(bool value) {
        //    this.NativeObject = matrix.mxCreateLogicalScalar(value);
        //}

        //public mxArray(string value) { 
        //    this.NativeObject = matrix.mxCreateString(value);
        //    CheckActive();
        //}

        //public mxArray(string[] values) {
        //    this.NativeObject = matrix.mxCreateCellMatrix(1, values.Length);
        //    CheckActive();
        //    for (int i = 0, j = values.Length; i < j; i++) {
        //        matrix.mxSetCell(this.NativeObject, i, new mxArray(values[i]).NativeObject);
        //    }
        //}

        #region size

        public int M { 
            get {
                CheckActive();
                return matrix.mxGetM(this.NativeObject); 
            } 
        }

        public int N { 
            get {
                CheckActive();
                return matrix.mxGetN(this.NativeObject); 
            } 
        }

        public int ElementSize { 
            get {
                CheckActive();
                return matrix.mxGetElementSize(this.NativeObject); 
            } 
        }

        public int Length {
            get { 
                CheckActive(); 
                return matrix.mxGetNumberOfElements(this.NativeObject); 
            }
        }

        public int[] Dimensions {
            get {
                CheckActive();
                int length = matrix.mxGetNumberOfDimensions(this.NativeObject);
                int[] dims = new int[length];
                IntPtr ptr = matrix.mxGetDimensions(this.NativeObject);
                Marshal.Copy(ptr, dims, 0, length);
                return dims;
            }
        }

        #endregion


        public string StringValue {
            get {
                CheckActive();
                if (this.IsChar) {
                    string v = matrix.mxGetChars(this.NativeObject);

                    IntPtr d = matrix.mxGetData(this.NativeObject);
                    char[] buf = new char[this.N];
                    matrix.mxGetNChars(this.NativeObject, buf, buf.Length);

                    Marshal.Copy(d, buf, 0, buf.Length);

                    return new string(buf);
                }

                return string.Empty;
            }
        }

        protected internal void CheckActive() {
            if (this.NativeObject.IsInvalid) {
                throw new OutOfMemoryException("The matlab instance is not active.");
            }
        }

        #region static methods

        public static bool IsNaN(double value) {
            return NaN == value;
        }

        public static bool IsInf(double value) {
            return Inf == value;
        }

        #endregion

        #region constants

        public readonly static double NaN = matrix.mxGetNaN();
        public readonly static double Inf = matrix.mxGetInf();
        public readonly static double Eps = matrix.mxGetEps();
        
        #endregion

        #region Is

        public bool IsEmpty { get { return matrix.mxIsEmpty(this.NativeObject); } }
        
        public bool IsChar { get { return matrix.mxIsChar(this.NativeObject); } }

        public bool IsCell { get { return matrix.mxIsCell(this.NativeObject); } }

        public bool IsComplex { get { return matrix.mxIsComplex(this.NativeObject); } }
        
        public bool IsStruct { get { return matrix.mxIsStruct(this.NativeObject); } }

        public bool IsNumeric { get { return matrix.mxIsNumeric(this.NativeObject); } }

        public bool IsObject { get { return matrix.mxIsObject(this.NativeObject); } }

        public bool IsBool { get { return matrix.mxIsLogical(this.NativeObject); } }

        public bool IsInt8 { get { return matrix.mxIsInt8(this.NativeObject); } }

        public bool IsInt16 { get { return matrix.mxIsInt16(this.NativeObject); } }

        public bool IsInt32 { get { return matrix.mxIsInt32(this.NativeObject); } }

        public bool IsInt64 { get { return matrix.mxIsInt64(this.NativeObject); } }

        public bool IsUInt8 { get { return matrix.mxIsUint8(this.NativeObject); } }

        public bool IsUInt16 { get { return matrix.mxIsUint16(this.NativeObject); } }

        public bool IsUInt32 { get { return matrix.mxIsUint32(this.NativeObject); } }

        public bool IsUInt64 { get { return matrix.mxIsUint64(this.NativeObject); } }

        public bool IsSingle { get { return matrix.mxIsSingle(this.NativeObject); } }

        public bool IsDouble { get { return matrix.mxIsDouble(this.NativeObject); } }

        #endregion

        //public virtual Array ToArray() {
        //    throw new NotImplementedException();
        //}

        #region IDisposable

        private bool _disposed;

        public void Destroy() {
            Dispose();
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (!_disposed) {
                if (disposing) {
                    this.NativeObject.Close();
                }

                _disposed = true;
            }
        }

        ~mxArray() {
            Dispose(false);
        }

        #endregion

        public virtual object Clone() {
            CheckActive();
            object obj = new mxArray(matrix.mxDuplicateArray(this.NativeObject));
            return obj;
        }
    }
}
