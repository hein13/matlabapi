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

namespace MatlabAPI {
    public enum mxNumericType {
        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        DOUBLE = 6,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        SINGLE = 7,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        INT8 = 8,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        UINT8 = 9,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        INT16 = 10,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        UINT16 = 11,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        INT32 = 12,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        UINT32 = 13,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        INT64 = 14,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        UINT64 = 15,
    }
}
