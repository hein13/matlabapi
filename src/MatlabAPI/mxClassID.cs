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
    /// <summary>
    /// Enumerated value identifying class of array
    /// see more: http://www.mathworks.cn/help/techdoc/apiref/mxclassid.html
    /// </summary>
    public enum mxClassID {
        /// <summary>
        /// Undetermined class. You cannot specify this category for an mxArray; 
        /// however, if mxGetClassID cannot identify the class, it returns this value.
        /// </summary>
        mxUNKNOWN_CLASS,

        /// <summary>
        /// Identifies a cell mxArray.
        /// </summary>
        mxCELL_CLASS,

        /// <summary>
        /// Identifies a structure mxArray.
        /// </summary>
        mxSTRUCT_CLASS,

        /// <summary>
        /// Identifies a logical mxArray, an mxArray of mxLogical data.
        /// </summary>
        mxLOGICAL_CLASS,

        /// <summary>
        /// Identifies a string mxArray, an mxArray whose data is represented as mxChar.
        /// </summary>
        mxCHAR_CLASS,

        /// <summary>
        /// Reserved.
        /// </summary>
        mxVOID_CLASS,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        mxDOUBLE_CLASS,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        mxSINGLE_CLASS,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        mxINT8_CLASS,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        mxUINT8_CLASS,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        mxINT16_CLASS,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        mxUINT16_CLASS,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        mxINT32_CLASS,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        mxUINT32_CLASS,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        mxINT64_CLASS,

        /// <summary>
        /// Identifies a numeric mxArray whose data is stored as the 
        /// type specified in the MATLAB Primitive Types table.
        /// </summary>
        mxUINT64_CLASS,

        /// <summary>
        /// Identifies a function handle mxArray.
        /// </summary>
        mxFUNCTION_CLASS,
        mxOPAQUE_CLASS,
        mxOBJECT_CLASS,
    };
}
