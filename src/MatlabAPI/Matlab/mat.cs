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
using System.Security;
using System.Runtime.InteropServices;

namespace MatlabAPI.Matlab {
    [SuppressUnmanagedCodeSecurity()]
    internal static class mat {
        /* 
         * Open a MAT-file "filename" using mode "mode".  Return
         * a pointer to a MATFile for use with other MAT API functions.
         *
         * Current valid entries for "mode" are
         * "r"    == read only.
         * "w"    == write only (deletes any existing file with name <filename>).
         * "w4"   == as "w", but create a MATLAB 4.0 MAT-file.
         * "w7.3" == as "w", but create a MATLAB 7.3 MAT-file.
         * "u"    == update.  Read and write allowed, existing file is not deleted.
         * 
         * Return NULL if an error occurs.
         */
        [DllImport("libmat.dll", EntryPoint = "matOpen", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static SafeMATFilePtr matOpen(string filename, string mode);

        /*
         * Close a MAT-file opened with matOpen.
         * Return zero for success, EOF on error.
         */
        [DllImport("libmat.dll", EntryPoint = "matClose", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static int matClose(IntPtr pMF);

        /*
         * Write array value with the specified name to the MAT-file, deleting any 
         * previously existing variable with that name in the MAT-file.
         *
         * Return zero for success, nonzero for error.
         */
        [DllImport("libmat.dll", EntryPoint = "matPutVariable", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static int matPutVariable(SafeMATFilePtr pMF, string name, SafeArrayPtr pA);

        /*
         * Write array value with the specified name to the MAT-file pMF, deleting any 
         * previously existing variable in the MAT-file with the same name.
         *
         * The variable will be written such that when the MATLAB LOAD command 
         * loads the variable, it will automatically place it in the 
         * global workspace and establish a link to it in the local
         * workspace (as if the command "global <varname>" had been
         * issued after the variable was loaded.)
         *
         * Return zero for success, nonzero for error.
         */
        [DllImport("libmat.dll", EntryPoint = "matPutVariableAsGlobal", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static int matPutVariableAsGlobal(SafeMATFilePtr pMF, string name, SafeArrayPtr pA);

        /*
         * Read the array value for the specified variable name from a MAT-file.
         *
         * Return NULL if an error occurs.
         */
        [DllImport("libmat.dll", EntryPoint = "matGetVariable", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static SafeArrayPtr matGetVariable(SafeMATFilePtr pMF, string name);

        /* 
         * Read the next array value from the current file location of the MAT-file
         * pMF.  This function should only be used in conjunction with 
         * matOpen and matClose.  Passing pMF to any other API functions
         * will cause matGetNextVariable() to work incorrectly.
         *
         * Return NULL if an error occurs.
         */
        [DllImport("libmat.dll", EntryPoint = "matGetNextVariable", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static SafeArrayPtr matGetNextVariable(SafeMATFilePtr pMF, string[] nameptr);

        /*
         * Read the array header of the next array value in a MAT-file.  
         * This function should only be used in conjunction with 
         * matOpen and matClose.  Passing pMF to any other API functions
         * will cause matGetNextVariableInfo to work incorrectly.
         * 
         * See the description of matGetVariableInfo() for the definition
         * and valid uses of an array header.
         *
         * Return NULL if an error occurs.
         */ 
        [DllImport("libmat.dll", EntryPoint = "matGetNextVariableInfo", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static SafeArrayPtr matGetNextVariableInfo(SafeMATFilePtr pMF, string[] nameptr);

        /*
         * Read the array header for the variable with the specified name from 
         * the MAT-file.
         * 
         * An array header contains all the same information as an
         * array, except that the pr, pi, ir, and jc data structures are 
         * not allocated for non-recursive data types.  That is,
         * Cells, structures, and objects contain pointers to other
         * array headers, but numeric, string, and sparse arrays do not 
         * contain valid data in their pr, pi, ir, or jc fields.
         *
         * The purpose of an array header is to gain fast access to 
         * information about an array without reading all the array's
         * actual data.  Thus, functions such as mxGetM, mxGetN, and mxGetClassID
         * can be used with array headers, but mxGetPr, mxGetPi, mxGetIr, mxGetJc,
         * mxSetPr, mxSetPi, mxSetIr, and mxSetJc cannot.
         *
         * An array header should NEVER be returned to MATLAB (for example via the
         * MEX API), or any other non-matrix access API function that expects a
         * full mxArray (examples include engPutVariable(), matPutVariable(), and 
         * mexPutVariable()).
         *
         * Return NULL if an error occurs.
         */
        [DllImport("libmat.dll", EntryPoint = "matGetVariableInfo", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static SafeArrayPtr matGetVariableInfo(SafeMATFilePtr pMF, string name);

        /*
         * Remove a variable with with the specified name from the MAT-file pMF.
         *
         * Return zero on success, non-zero on error.
         */
        [DllImport("libmat.dll", EntryPoint = "matDeleteVariable", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static int matDeleteVariable(SafeMATFilePtr pMF, string name);

        /* 
         * Get a list of the names of the arrays in a MAT-file.
         * The array of strings returned by this function contains "num"
         * entries.  It is allocated with one call to mxCalloc, and so 
         * can (must) be freed with one call to mxFree.
         *
         * If there are no arrays in the MAT-file, return value 
         * is NULL and num is set to zero.  If an error occurs,
         * return value is NULL and num is set to a negative number.
         */
        [DllImport("libmat.dll", EntryPoint = "matDeleteVariable", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static string[] matGetDir(SafeMATFilePtr pMF, int[] num);
    }
}
