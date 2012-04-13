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
using System.Security;
using System.Runtime.InteropServices;

namespace MatlabAPI.Matlab {
    [SuppressUnmanagedCodeSecurity()]
    internal static class matrix {
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr mxMalloc(int n);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr mxCalloc(int n, int size);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxFree(IntPtr ptr);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr mxRealloc(IntPtr ptr, int size);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr mxGetData(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxSetData(SafeArrayPtr pa, IntPtr newdata);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsNumeric(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsCell(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsLogical(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsChar(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsStruct(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsOpaque(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsFunctionHandle(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsObject(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsComplex(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsSparse(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsDouble(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsSingle(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsInt8(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsUint8(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsInt16(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsUint16(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsInt32(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsUint32(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsInt64(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsUint64(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsEmpty(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsClass(SafeArrayPtr pa, string name);



        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int mxGetNumberOfDimensions(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr mxGetDimensions(SafeArrayPtr pa);

        /// <summary>
        /// Get number of elements in array
        /// </summary>
        /// <param name="pa"></param>
        /// <returns></returns>
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int mxGetNumberOfElements(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr mxGetPr(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxSetPr(SafeArrayPtr pa, IntPtr pr);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr mxGetPi(SafeArrayPtr pa);

        /*
         * Set new imaginary data for array
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxSetPi(SafeArrayPtr pa, IntPtr pr);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr mxGetImagData(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxSetImagData(SafeArrayPtr pa, IntPtr newdata);



        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static string mxGetChars(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int mxGetUserBits(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxSetUserBits(SafeArrayPtr pa, int value);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static double mxGetScalar(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsFromGlobalWS(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxSetFromGlobalWS(SafeArrayPtr pa, [MarshalAs(UnmanagedType.U1)]bool global);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int mxGetM(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxSetM(SafeArrayPtr pa, int m);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int mxGetN(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int[] mxGetIr(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxGetIr(SafeArrayPtr pa, int[] newir);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int[] mxGetJc(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxSetJc(SafeArrayPtr pa, int[] newir);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int mxGetNzmax(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxSetNzmax(SafeArrayPtr pa, int nzmax);

        /// <summary>
        /// Number of bytes required to store each data element
        /// </summary>
        /// <param name="pa"></param>
        /// <returns>
        /// Number of bytes required to store one element of the specified mxArray, 
        /// if successful. Returns 0 on failure. The primary reason for failure is 
        /// that pm points to an mxArray having an unrecognized class. 
        /// 
        /// If pm points to a cell mxArray or a structure mxArray, mxGetElementSize 
        /// returns the size of a pointer (not the size of all the elements in each cell or structure field).
        /// </returns>
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int mxGetElementSize(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int mxCalcSingleSubscript(SafeArrayPtr pa, int nsubs, int[] subs);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int mxGetNumberOfFields(SafeArrayPtr pa);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxGetCell(SafeArrayPtr pa, int i);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxSetCell(SafeArrayPtr pa, int i, SafeArrayPtr value);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static string mxGetFieldNameByNumber(SafeArrayPtr pa, int n);

        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int mxGetFieldNumber(SafeArrayPtr pa, string name);

        /*
         * Return a pointer to the contents of the named field for 
         * the ith element (zero based).
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxGetFieldByNumber(SafeArrayPtr pa, int i, int fieldnum);

        /*
         * Set pa[i][fieldnum] = value 
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxSetFieldByNumber(SafeArrayPtr pa, int i, int fieldnum, SafeArrayPtr value);

        /*
         * Return a pointer to the contents of the named field for the ith 
         * element (zero based).  Returns NULL on no such field or if the
         * field itself is NULL
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxGetField(SafeArrayPtr pa, int i, string fieldname);

        /*
         * Sets the contents of the named field for the ith element (zero based).  
         * The input 'value' is stored in the input array 'pa' - no copy is made.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxSetField(SafeArrayPtr pa, int i, string fieldname, SafeArrayPtr value);

        /*
         * mxGetProperty returns the value of a property for a given object and index.
         * The property must be public.
         *
         * If the given property name doesn't exist, isn't public, or the object isn't
         * the right type, then mxGetProperty returns NULL.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr mxGetProperty(SafeArrayPtr pa, int i, string propname);

        /*
         * mxSetProperty sets the value of a property for a given object and index.
         * The property must be public.
         *
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxSetProperty(SafeArrayPtr pa, int i, string propname, SafeArrayPtr value);

        /* 
         * Return the name of an array's class.  
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static string mxGetClassName(SafeArrayPtr pa);



        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxCreateNumericMatrix(int m, int n, mxNumericType classId, mxComplexity complexFlag);

        /* 
         * Set column dimension
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxSetN(SafeArrayPtr pa, int n);

        /*
         * Set dimension array and number of dimensions.  Returns 0 on success and 1
         * if there was not enough memory available to reallocate the dimensions array.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int mxSetDimensions(SafeArrayPtr pa, int size, int ndims);

        /*
         * mxArray destructor
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxDestroyArray(IntPtr pa);

        /*
         * Create a numeric array and initialize all its data elements to 0.
         *
         * Similar to mxCreateNumericMatrix, in a standalone application, 
         * out-of-memory will mean a NULL pointer is returned.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxCreateNumericArray(int ndim, int[] dims, mxNumericType classId, mxComplexity complexFlag);

        /*
         * Create an N-Dimensional array to hold string data;
         * initialize all elements to 0.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxCreateCharArray(int ndim, int[] dims);

        /*
         * Create a two-dimensional array to hold double-precision
         * floating-point data; initialize each data element to 0.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxCreateDoubleMatrix(int m, int n, mxComplexity flag);

        /*
         * Get a properly typed pointer to the elements of a logical array.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr mxGetLogicals(SafeArrayPtr pa);

        /*
         * Create a logical array and initialize its data elements to false.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxCreateLogicalArray(int ndim, int[] dims);

        /*
         * Create a logical scalar mxArray having the specified value.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxCreateLogicalScalar([MarshalAs(UnmanagedType.U1)]bool value);

        /*
         * Returns true if we have a valid logical scalar mxArray.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsLogicalScalar(SafeArrayPtr pa);

        /*
         * Returns true if the logical scalar value is true.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsLogicalScalarTrue(SafeArrayPtr pa);

        /*
         * Create a double-precision scalar mxArray initialized to the
         * value specified
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxCreateDoubleScalar(double value);


        /*
         * Create a 2-Dimensional sparse array.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxCreateSparse(int m, int n, int nzmax, mxComplexity flag);

        /*
         * Create a 2-D sparse logical array
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxCreateSparseLogicalMatrix(int m, int n, int nzmax);

        /*
         * Copies characters from a MATLAB array to a char array
         * This function will attempt to perform null termination if it is possible.
         * nChars is the number of bytes in the output buffer
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxGetNChars(SafeArrayPtr pa, char[] buf, int nChars);

        /*
         * Converts a string array to a C-style string. The C-style string is in the
         * local codepage encoding. If the conversion for the entire Unicode string
         * cannot fit into the supplied character buffer, then the conversion includes
         * the last whole codepoint that will fit into the buffer. The string is thus
         * truncated at the greatest possible whole codepoint and does not split code-
         * points.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int mxGetString(SafeArrayPtr pa, char[] buf, int buflen);

        /*
         * Create a NULL terminated C string from an mxArray of type mxCHAR_CLASS
         * Supports multibyte character sets.  The resulting string must be freed
         * with mxFree.  Returns NULL on out of memory or non-character arrays.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static string mxArrayToString(SafeArrayPtr pa);

        /*
         * Create a 1-by-n string array initialized to str. The supplied string is
         * presumed to be in the local codepage encoding. The character data format
         * in the mxArray will be UTF-16.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxCreateStringFromNChars(string str, int n);

        /*
         * Create a 1-by-n string array initialized to null terminated string
         * where n is the length of the string.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxCreateString(string str);

        /*
         * Create a string array initialized to the strings in str.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxCreateCharMatrixFromStrings(int m, string[] str);

        /*
         * Create a 2-Dimensional cell array, with each cell initialized
         * to NULL.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxCreateCellMatrix(int m, int n);

        /*
         * Create an N-Dimensional cell array, with each cell initialized
         * to NULL.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxCreateCellArray(int ndim, int[] dims);

        /*
         * Create a 2-Dimensional structure array having the specified fields;
         * initialize all values to NULL.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxCreateStructMatrix(int m, int n, int nfields, string[] fieldnames);

        /*
         * Create an N-Dimensional structure array having the specified fields;
         * initialize all values to NULL.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxCreateStructArray(int ndim, int[] dims, int nfields, string[] fieldnames);

        /*
         * Make a deep copy of an array, return a pointer to the copy.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static SafeArrayPtr mxDuplicateArray(SafeArrayPtr inpa);

        /*
         * Set classname of an unvalidated object array.  It is illegal to
         * call this function on a previously validated object array.
         * Return 0 for success, 1 for failure.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int mxSetClassName(SafeArrayPtr pa, string classname);

        /* 
         * Add a field to a structure array. Returns field number on success or -1
         * if inputs are invalid or an out of memory condition occurs.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static int mxAddField(SafeArrayPtr pa, string fieldname);

        /*
         * Remove a field from a structure array.  Does nothing if no such field exists.
         * Does not destroy the field itself.
        */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void mxRemoveField(SafeArrayPtr pa, int field);

        /*
         * Function for obtaining MATLAB's concept of EPS
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static double mxGetEps();

        /*
         * Function for obtaining MATLAB's concept of INF (Used in MEX-File callback).
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static double mxGetInf();

        /*
         * Function for obtaining MATLAB's concept of NaN (Used in MEX-File callback).
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static double mxGetNaN();

        /*
         * test for finiteness in a machine-independent manner
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsFinite(double x);

        /*
         * test for infinity in a machine-independent manner
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsInf(double x);

        /*
         * test for NaN in a machine-independent manner
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public extern static bool mxIsNaN(double x);

       
        /*
         * Return the class (catergory) of data that the array holds.
         */
        [DllImport("libmx.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static mxClassID mxGetClassID(SafeArrayPtr pa);

    }
}
