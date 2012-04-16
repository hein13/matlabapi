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
    public abstract class mxArray : IDisposable {
        /// <summary>
        /// Get the type of value.
        /// </summary>
        public mxArrayType ArrayType { get; private set; }

        internal SafeArrayPtr NativeObject { get; private set; }

        #region internal structures.

        internal mxArray(SafeArrayPtr pa) {
            this.NativeObject = pa;
        }

        internal mxArray(SafeArrayPtr pa, mxArrayType arrayType) {
            this.NativeObject = pa;
            this.ArrayType = arrayType;
        }

        #endregion

        /// <summary>
        /// Create a mxArray with a mxArray pointer.
        /// </summary>
        /// <param name="pa"></param>
        /// <returns></returns>
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
                case mxClassID.mxSTRUCT_CLASS:
                    return new mxStructArray(pa);
                default:
                    throw new NotSupportedException();
            }
        }

        #region size

        /// <summary>
        /// Get the length of first dimension. or the number of rows of value.
        /// </summary>
        public int M { 
            get {
                CheckActive();
                return matrix.mxGetM(this.NativeObject); 
            } 
        }

        /// <summary>
        /// Get the length of second dimension. or the number of columns of value.
        /// </summary>
        public int N { 
            get {
                CheckActive();
                return matrix.mxGetN(this.NativeObject); 
            } 
        }

        /// <summary>
        /// Get the size of element in array value.
        /// </summary>
        public int ElementSize { 
            get {
                CheckActive();
                return matrix.mxGetElementSize(this.NativeObject); 
            } 
        }

        /// <summary>
        /// Get the numbers of the elements in array value.
        /// </summary>
        public int Length {
            get { 
                CheckActive(); 
                return matrix.mxGetNumberOfElements(this.NativeObject); 
            }
        }

        #endregion

        #region static methods

        /// <summary>
        /// Check if a double value is NaN.
        /// </summary>
        /// <param name="value">The checking value.</param>
        /// <returns>return true if it's NaN, false if not.</returns>
        public static bool IsNaN(double value) {
            return NaN == value;
        }

        /// <summary>
        /// Check if a double value is Inf.
        /// </summary>
        /// <param name="value">The checking value.</param>
        /// <returns>return true if it's Inf, false if not.</returns>
        public static bool IsInf(double value) {
            return Inf == value;
        }

        #endregion

        #region constants

        /// <summary>
        /// NaN value.
        /// </summary>
        public readonly static double NaN = matrix.mxGetNaN();

        /// <summary>
        /// Inf value.
        /// </summary>
        public readonly static double Inf = matrix.mxGetInf();

        /// <summary>
        /// Eps value.
        /// </summary>
        public readonly static double Eps = matrix.mxGetEps();
        
        #endregion

        #region IsXXX

        /// <summary>
        /// Check if the value is empty.
        /// </summary>
        public bool IsEmpty { get { return matrix.mxIsEmpty(this.NativeObject); } }
        
        /// <summary>
        /// Check if the type of value is string.
        /// </summary>
        public bool IsChar { get { return matrix.mxIsChar(this.NativeObject); } }

        /// <summary>
        /// Check if the type of value is cell array.
        /// </summary>
        public bool IsCell { get { return matrix.mxIsCell(this.NativeObject); } }

        /// <summary>
        /// Check if the type of value is struct.
        /// </summary>
        public bool IsStruct { get { return matrix.mxIsStruct(this.NativeObject); } }

        /// <summary>
        /// Check if the type of value is a numeric.
        /// </summary>
        public bool IsNumeric { get { return matrix.mxIsNumeric(this.NativeObject); } }

        /// <summary>
        /// Check if the type of value is class.
        /// </summary>
        public bool IsObject { get { return matrix.mxIsObject(this.NativeObject); } }

        /// <summary>
        /// Check if the type of value is boolean
        /// </summary>
        public bool IsBool { get { return matrix.mxIsLogical(this.NativeObject); } }

        #endregion

        protected internal void CheckActive() {
            if (this.NativeObject.IsInvalid) {
                throw new OutOfMemoryException("The matlab instance is not active.");
            }
        }


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
    }
}
