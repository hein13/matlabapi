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
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;

namespace MatlabAPI.Matlab {
    [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
    internal sealed class SafeEnginePtr : SafeHandleZeroOrMinusOneIsInvalid {
        public SafeEnginePtr() : base(true) { base.SetHandle(IntPtr.Zero); }

        public SafeEnginePtr(IntPtr pa) : base(true) { base.SetHandle(pa); }

        public SafeEnginePtr(IntPtr pa, bool ownsHandle) : base(ownsHandle) { base.SetHandle(pa); }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        protected override bool ReleaseHandle() {
            bool flag = false;
            try {
                if (IntPtr.Zero != this.handle) {
                    engine.engClose(this.handle);
                    this.handle = IntPtr.Zero;
                }

                flag = true;
            } catch { }

            return flag;
        }


        public override bool IsInvalid {
            get {
                return base.IsClosed || IntPtr.Zero == this.handle;
            }
        }
    }
}
