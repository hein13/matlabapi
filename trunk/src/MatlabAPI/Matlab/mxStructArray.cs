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

namespace MatlabAPI.Matlab {
    public sealed class mxStructArray : mxArray {
        #region constructors

        internal mxStructArray(SafeArrayPtr pa) : base(pa, mxArrayType.Struct) { }

        /// <summary>
        /// Create a struct array by field names.
        /// </summary>
        /// <param name="fieldNames">The field names.</param>
        public mxStructArray(string[] fieldNames) {
            if (fieldNames == null || fieldNames.Length == 0)
                throw new ArgumentNullException("fieldNames", "The fieldNames must be not null or emtpy.");

            SafeArrayPtr pa = matrix.mxCreateStructMatrix(1, 1, fieldNames.Length, fieldNames);
            CreateArray(pa, mxArrayType.Struct);
        }

        /// <summary>
        /// Create a struct array with one dimsension by field names.
        /// </summary>
        /// <param name="count">The length of array.</param>
        /// <param name="fieldNames">The field names.</param>
        public mxStructArray(int count, string[] fieldNames) {
            if (count < 1)
                throw new ArgumentOutOfRangeException("count", "The count must be larger and equal than zero.");
            
            if (fieldNames == null || fieldNames.Length == 0)
                throw new ArgumentNullException("fieldNames", "The fieldNames must be not null or emtpy.");
            
            SafeArrayPtr pa = matrix.mxCreateStructArray(2, new int[]{1,count}, fieldNames.Length, fieldNames);
            CreateArray(pa, mxArrayType.Struct);
        }

        /// <summary>
        /// Create a struct array with two dimsension by field names.
        /// </summary>
        /// <param name="m">The number of rows.</param>
        /// <param name="n">The number of columns.</param>
        /// <param name="fieldNames">The field names.</param>
        public mxStructArray(int m, int n, string[] fieldNames) {
            if (m < 1 || n < 1)
                throw new ArgumentOutOfRangeException("The m and n must be larger than zero.");

            if (fieldNames == null || fieldNames.Length == 0)
                throw new ArgumentNullException("fieldNames", "The fieldNames must be not null or emtpy.");

            SafeArrayPtr pa = matrix.mxCreateStructArray(2, new int[]{m, n}, fieldNames.Length, fieldNames);
            CreateArray(pa, mxArrayType.Struct);
        }

        #endregion

        #region FieldCount property

        /// <summary>
        /// Get the number of the fields in structs.
        /// </summary>
        public int FieldCount {
            get { return matrix.mxGetNumberOfFields(this.NativeObject); }
        }

        #endregion

        #region GetFieldNames

        /// <summary>
        /// Get all field names.
        /// </summary>
        /// <returns>The array of field names.</returns>
        public string[] GetFieldNames() {
            int fieldCount = this.FieldCount;
            string[] fieldNames = new string[fieldCount];

            for (int i = 0; i < fieldCount; i++) {
                fieldNames[i] = matrix.mxGetFieldNameByNumber(this.NativeObject, i);
            }

            return fieldNames;
        }

        #endregion

        #region GetField

        /// <summary>
        /// Get a field by field No.
        /// </summary>
        /// <param name="index">The index of the struct array.</param>
        /// <param name="fieldNum">The No. of the field.</param>
        /// <returns>The field array object.</returns>
        public mxArray GetField(int index, int fieldNum) {
            if (index < 0 || index >= this.Length)
                throw new ArgumentOutOfRangeException("The index must be range from 0 to the length of the array.");

            int fieldCount = this.FieldCount;
            if (fieldNum < 0 || fieldNum >= fieldCount)
                throw new ArgumentOutOfRangeException("The fieldnum must be range from 0 to the number of the field.");

            SafeArrayPtr ptr = matrix.mxGetFieldByNumber(this.NativeObject, index, fieldNum);
            if (ptr.IsInvalid)
                throw new ArgumentException("The fieldName is not exists in struct.");

            return mxArray.Create(ptr);
        }

        /// <summary>
        /// Get a field by field name.
        /// </summary>
        /// <param name="index">The index of the struct array.</param>
        /// <param name="fieldName">The name of field.</param>
        /// <returns>The field array object.</returns>
        public mxArray GetField(int index, string fieldName) {
            if (index < 0 || index >= this.Length)
                throw new ArgumentOutOfRangeException("index", "The index must be range from 0 to the length of the array.");

            if (string.IsNullOrEmpty(fieldName))
                throw new ArgumentNullException("fieldName", "The fieldName must be not null.");

            SafeArrayPtr ptr = matrix.mxGetField(this.NativeObject, index, fieldName);
            if (ptr.IsInvalid)
                throw new ArgumentException("The fieldName is not exists in struct.");

            return mxArray.Create(ptr);
        }

        /// <summary>
        /// Get the value of the field at [m, n] with the index of field.
        /// </summary>
        /// <param name="m">The index of rows.</param>
        /// <param name="n">The index of columns.</param>
        /// <param name="fieldNum">The no. of the field.</param>
        /// <returns>The field array object.</returns>
        public mxArray GetField(int m, int n, int fieldNum) {
            if (m < 0 || m >= this.M || n < 0 || n >= this.N)
                throw new ArgumentOutOfRangeException("The m and n must be larger and equal than zero, and less than the rows and columns.");

            int fieldCount = this.FieldCount;
            if (fieldNum < 0 || fieldNum >= fieldCount)
                throw new ArgumentOutOfRangeException("The fieldnum must be range from 0 to the number of the field.");

            SafeArrayPtr ptr = matrix.mxGetFieldByNumber(this.NativeObject, n * this.M + m, fieldNum);
            if (ptr.IsInvalid)
                throw new ArgumentException("The fieldName is not exists in struct.");

            return mxArray.Create(ptr);
        }

        /// <summary>
        /// Get the value of the field at [m, n] with the field name.
        /// </summary>
        /// <param name="m">The index of rows.</param>
        /// <param name="n">The index of columns.</param>
        /// <param name="fieldName">The field name.</param>
        /// <returns>The field array object.</returns>
        public mxArray GetField(int m, int n, string fieldName) {
            if (m < 0 || m >= this.M || n < 0 || n >= this.N)
                throw new ArgumentOutOfRangeException("The m and n must be larger and equal than zero, and less than the rows and columns.");

            if (string.IsNullOrEmpty(fieldName))
                throw new ArgumentNullException("fieldName", "The fieldName must be not null.");

            SafeArrayPtr ptr = matrix.mxGetField(this.NativeObject, n * this.M + m, fieldName);
            if (ptr.IsInvalid)
                throw new ArgumentException("The fieldName is not exists in struct.");

            return mxArray.Create(ptr);
        }

        #endregion

        #region SetField

        /// <summary>
        /// Set the field value by field No..
        /// </summary>
        /// <param name="index">The index of the struct array.</param>
        /// <param name="fieldNum">The No. of the field.</param>
        /// <param name="array">The field value.</param>
        public void SetField(int index, int fieldNum, mxArray array) {
            if (index < 0 || index >= this.Length)
                throw new ArgumentOutOfRangeException("index", "The index must be range from 0 to the length of the array.");

            if (array == null)
                throw new ArgumentNullException("array", "The mxArray parameter must be not null.");

            if (array.NativeObject.IsInvalid)
                throw new ArgumentException("The parameter array is invalid.", "array");

            int fieldCount = this.FieldCount;
            if (fieldNum < 0 || fieldNum >= fieldCount)
                throw new ArgumentOutOfRangeException("fieldNum", "The fieldnum must be range from 0 to the number of the field.");

            matrix.mxSetFieldByNumber(this.NativeObject, index, fieldNum, array.NativeObject);
        }

        /// <summary>
        /// Set the field value by field name.
        /// </summary>
        /// <param name="index">The index of the struct array.</param>
        /// <param name="fieldName">The name of field.</param>
        /// <param name="array">The field value.</param>
        public void SetField(int index, string fieldName, mxArray array) {
            if (index < 0 || index >= this.Length)
                throw new ArgumentOutOfRangeException("index", "The index must be range from 0 to the length of the array.");
            
            if (string.IsNullOrEmpty(fieldName))
                throw new ArgumentNullException("fieldName", "The fieldName must be not null.");

            if (array == null)
                throw new ArgumentNullException("array", "The mxArray parameter must be not null.");

            if (array.NativeObject.IsInvalid)
                throw new ArgumentException("The parameter array is invalid.", "array");
            
            matrix.mxSetField(this.NativeObject, index, fieldName, array.NativeObject);
        }

        /// <summary>
        /// Set the field value at [m, n] by field No..
        /// </summary>
        /// <param name="m">The index of the rows.</param>
        /// <param name="n">The index of the columns.</param>
        /// <param name="fieldNum">The No. of the field.</param>
        /// <param name="array">The field value.</param>
        public void SetField(int m, int n, int fieldNum, mxArray array) {
            if (m < 0 || m >= this.M || n < 0 || n >= this.N)
                throw new ArgumentOutOfRangeException("The m and n must be larger and equal than zero, and less than the rows and columns.");

            if (array == null)
                throw new ArgumentNullException("array", "The mxArray parameter must be not null.");

            if (array.NativeObject.IsInvalid)
                throw new ArgumentException("The parameter array is invalid.", "array");

            int fieldCount = this.FieldCount;
            if (fieldNum < 0 || fieldNum >= fieldCount)
                throw new ArgumentOutOfRangeException("fieldNum", "The fieldnum must be range from 0 to the number of the field.");

            matrix.mxSetFieldByNumber(this.NativeObject, n * this.M + m, fieldNum, array.NativeObject);
        }

        /// <summary>
        /// Set the field value at [m, n] by field name.
        /// </summary>
        /// <param name="m">The index of the rows.</param>
        /// <param name="n">The index of the columns.</param>
        /// <param name="fieldName">The field name.</param>
        /// <param name="array">The field value.</param>
        public void SetField(int m, int n, string fieldName, mxArray array) {
            if (m < 0 || m >= this.M || n < 0 || n >= this.N)
                throw new ArgumentOutOfRangeException("The m and n must be larger and equal than zero, and less than the rows and columns.");

            if (array == null)
                throw new ArgumentNullException("array", "The mxArray parameter must be not null.");

            if (array.NativeObject.IsInvalid)
                throw new ArgumentException("The parameter array is invalid.", "array");

            if (string.IsNullOrEmpty(fieldName))
                throw new ArgumentNullException("fieldName", "The fieldName must be not null.");

            matrix.mxSetField(this.NativeObject, n * this.M + m, fieldName, array.NativeObject);
        }

        #endregion

        public override Array ToArray() {
            int r = this.M, c = this.N, fieldCount = this.FieldCount;
            mxCellArray[,] array = new mxCellArray[r, c];
            
            for (int i = 0; i < r; i++) {
                for (int j = 0; j < c; j++) {
                    mxCellArray cell = new mxCellArray(fieldCount);
                    for (int x = 0; x < fieldCount; x++) {
                        cell.SetCell(0, this.GetField(i, j, x));
                    }
                    array[i, j] = cell;
                }
            }

            return array;
        }
    }
}
