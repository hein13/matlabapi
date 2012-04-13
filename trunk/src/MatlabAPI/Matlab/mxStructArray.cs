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
        internal mxStructArray(SafeArrayPtr pa) : base(pa, mxArrayType.Struct) { }

        public int FieldCount {
            get { return matrix.mxGetNumberOfFields(this.NativeObject); }
        }

        public mxArray GetField(int index, int fieldNum) {
            if (index < 0 || index >= this.Length)
                throw new ArgumentOutOfRangeException("The index must be range from 0 to the length of the array.");

            int fieldCount = this.FieldCount;
            if (fieldNum < 0 || fieldNum >= fieldCount)
                throw new ArgumentOutOfRangeException("The fieldnum must be range from 0 to the number of the field.");

            return mxArray.Create(matrix.mxGetFieldByNumber(this.NativeObject, index, fieldNum));
        }

        public mxArray GetField(int index, string fieldName) {
            if (index < 0 || index >= this.Length)
                throw new ArgumentOutOfRangeException("The index must be range from 0 to the length of the array.");

            SafeArrayPtr ptr = matrix.mxGetField(this.NativeObject, index, fieldName);
            if (ptr.IsInvalid)
                throw new ArgumentException("The fieldName is not exists in struct.");

            return mxArray.Create(ptr);
        }

        public string[] GetFieldNames() {
            int fieldCount = this.FieldCount;
            string[] fieldNames = new string[fieldCount];

            for (int i = 0; i < fieldCount; i++) {
                fieldNames[i] = matrix.mxGetFieldNameByNumber(this.NativeObject, i);
            }

            return fieldNames;
        }
    }
}
