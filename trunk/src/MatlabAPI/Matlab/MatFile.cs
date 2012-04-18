using System;
using System.IO;
using System.Runtime.InteropServices;

namespace MatlabAPI.Matlab {
    public class MatFile : IDisposable {
        internal SafeMATFilePtr NativeObject { get; private set; }
        
        internal MatFile(SafeMATFilePtr pa) {
            this.NativeObject = pa;
            CheckActive();
        }

        /// <summary>
        /// Open a mat file with readonly mode.
        /// </summary>
        /// <param name="fileName">The mat file full name.</param>
        /// <returns>return matfile object.</returns>
        public static MatFile Open(string fileName) {
            return Open(fileName, "r");
        }

        /// <summary>
        /// Open a mat file with certain mode.
        /// </summary>
        /// <param name="fileName">The mat file full name.</param>
        /// <param name="mode">the open mode which supported 'r', 'w', 'u'.</param>
        /// <returns>return matfile object.</returns>
        public static MatFile Open(string fileName, string mode) {
            // check mode
            //if (!File.Exists(fileName))
            //    throw new FileNotFoundException("The mat file is not found!", fileName);

            SafeMATFilePtr pa = mat.matOpen(fileName, mode);
            if (pa.IsInvalid)
                throw new ArgumentException("The mat file is invalid.");

            return new MatFile(pa);
        }

        /// <summary>
        /// Put a value into mat file with variable name.
        /// </summary>
        /// <param name="name">The variable name.</param>
        /// <param name="array">The value which would put into mat file.</param>
        /// <returns>return true on success, false on error.</returns>
        public bool PutVariable(string name, mxArray array) {
            return 0 == mat.matPutVariable(this.NativeObject, name, array.NativeObject) ;
        }

        /// <summary>
        /// Put a global value into mat file with variable name.
        /// </summary>
        /// <param name="name">The global variable name.</param>
        /// <param name="array">The global value which would put into mat file.</param>
        /// <returns>return true on success, false on error.</returns>
        public bool PutVariableAsGlobal(string name, mxArray array) {
            return 0 == mat.matPutVariableAsGlobal(this.NativeObject, name, array.NativeObject);
        }

        /// <summary>
        /// Get a variable value via name in mat file.
        /// </summary>
        /// <param name="name">The variable name.</param>
        /// <returns>return variable value.</returns>
        public mxArray GetVariable(string name) {
            SafeArrayPtr pa = mat.matGetVariable(this.NativeObject, name);
            if (pa.IsInvalid)
                return null;

            return mxArray.Create(pa);
        }

        /// <summary>
        /// Get all variable names in mat file.
        /// </summary>
        /// <returns>return the variable name array.</returns>
        public string[] GetVariableNames() {
            int num = -1;
            IntPtr ptr = mat.matGetDir(this.NativeObject, ref num);
            if (ptr == IntPtr.Zero) {
                if (num == 0) {
                    return new string[0];
                } else if (num < 0) {
                    throw new ArgumentException();
                }
            }

            string[] names = new string[num];
            for (int i = 0; i < num; i++) {
                var strptr = (IntPtr)Marshal.PtrToStructure(ptr, typeof(IntPtr));
                names[i] = Marshal.PtrToStringAnsi(strptr);
                ptr = new IntPtr(ptr.ToInt64() + IntPtr.Size);
            }

            // don't forget free the unmanaged memory
            matrix.mxFree(ptr);
            return names;
        }


        /// <summary>
        /// Delete a variable in mat file.
        /// </summary>
        /// <param name="name">The variable name.</param>
        /// <returns>return true on success, false on error.</returns>
        public bool DeleteVariable(string name) {
            return 0 == mat.matDeleteVariable(this.NativeObject, name);
        }

        internal void CheckActive() {
            if (this.NativeObject.IsInvalid) {
                throw new OutOfMemoryException("The mat file instance is not active.");
            }
        }

        /// <summary>
        /// Close the mat file. release unmanage resources.
        /// </summary>
        public void Close() {
            Dispose();
        }

        #region IDisposable

        private bool _disposed;

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

        ~MatFile() {
            Dispose(false);
        }

        #endregion
    }
}
