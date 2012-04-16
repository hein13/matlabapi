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
    public sealed class mxStructArray : mxArray {
        internal mxStructArray(SafeArrayPtr pa) : base(pa, mxArrayType.Struct) {
            CheckActive();
        }

        public mxStructArray(string[] fieldNames) {
            if (fieldNames == null || fieldNames.Length == 0)
                throw new ArgumentNullException("fieldNames", "The fieldNames must be not null or emtpy.");

            SafeArrayPtr pa = matrix.mxCreateStructMatrix(1, 1, fieldNames.Length, fieldNames);
            CreateArray(pa, mxArrayType.Struct);
        }

        public mxStructArray(int count, string[] fieldNames) {
            if (count < 1)
                throw new ArgumentOutOfRangeException("count", "The count must be larger and equal than zero.");
            
            if (fieldNames == null || fieldNames.Length == 0)
                throw new ArgumentNullException("fieldNames", "The fieldNames must be not null or emtpy.");
            
            SafeArrayPtr pa = matrix.mxCreateStructArray(2, new int[]{1,count}, fieldNames.Length, fieldNames);
            CreateArray(pa, mxArrayType.Struct);
        }

        public mxStructArray(int m, int n, string[] fieldNames) {
            if (m < 1 || n < 1)
                throw new ArgumentOutOfRangeException("The m and n must be larger than zero.");

            if (fieldNames == null || fieldNames.Length == 0)
                throw new ArgumentNullException("fieldNames", "The fieldNames must be not null or emtpy.");

            SafeArrayPtr pa = matrix.mxCreateStructArray(2, new int[]{m, n}, fieldNames.Length, fieldNames);
            CreateArray(pa, mxArrayType.Struct);
        }

        /// <summary>
        /// Get the number of the fields in structs.
        /// </summary>
        public int FieldCount {
            get { return matrix.mxGetNumberOfFields(this.NativeObject); }
        }

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

        #endregion

        #region SetField

        /// <summary>
        /// Set the field value by field No.
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

        #endregion

    }
}
