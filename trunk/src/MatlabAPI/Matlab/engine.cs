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
    internal static class engine {
        [DllImport("libeng.dll", EntryPoint = "engOpenSingleUse", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static SafeEnginePtr engOpenSingleUse(string startcmd, IntPtr reserved, out int retstatus);

        [DllImport("libeng.dll", EntryPoint = "engGetArray", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static SafeArrayPtr engGetArray(SafeEnginePtr engine, string name);

        [DllImport("libeng.dll", EntryPoint = "engPutArray", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static int engPutArray(SafeEnginePtr engine, SafeArrayPtr mp);

        [DllImport("libeng.dll", EntryPoint = "engEvalString", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static int engEvalString(SafeEnginePtr engine, string cmdstring);

        [DllImport("libeng.dll", EntryPoint = "engOutputBuffer", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static int engOutputBuffer(SafeEnginePtr engine, char[] buffer, int buflen);

        [DllImport("libeng.dll", EntryPoint = "engClose", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static int engClose(IntPtr engine);

        [DllImport("libeng.dll", EntryPoint = "engGetVariable", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static SafeArrayPtr engGetVariable(SafeEnginePtr engine, string variableName);

        [DllImport("libeng.dll", EntryPoint = "engPutVariable", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static int engPutVariable(SafeEnginePtr engine, string variableName, SafeArrayPtr ap);

        [DllImport("libeng.dll", EntryPoint = "engSetVisible", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static int engSetVisible(SafeEnginePtr engine, [MarshalAs(UnmanagedType.U1)]bool newVal);

        [DllImport("libeng.dll", EntryPoint = "engGetVisible", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        public extern static int engGetVisible(SafeEnginePtr engine, [MarshalAs(UnmanagedType.U1)]out bool val);

    }
}
