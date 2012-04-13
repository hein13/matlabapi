using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using MatlabAPI.Matlab;

namespace MatlabAPI {
    public class MatEngine : IDisposable {
        public int Id { get { return this.Process.Id; } }
        public Process Process { get; private set; }
        private SafeEnginePtr _engine;
        private bool _disposed;

        public MatEngine() : this(true) { }

        public MatEngine(bool visible) {
            int ret;
            Process[] pros = Process.GetProcessesByName("MATLAB");
            
            _engine = engine.engOpenSingleUse(string.Empty, IntPtr.Zero, out ret);

            Process[] pros2 = Process.GetProcessesByName("MATLAB");
            bool has = false;

            for (int i = 0, j = pros2.Length; i < j; i++) {
                has = false;
                for (int x = 0, y = pros.Length; x < y; x++) {
                    if (pros2[i].Id == pros[x].Id) {
                        has = true;
                        break;
                    }
                }

                if (!has) {
                    this.Process = pros2[i];
                    break;
                }
            }

            if (_engine.IsInvalid) {
                throw new ApplicationException("The matlab opend failed.");
            }

            if (!visible) {
                engine.engSetVisible(_engine, visible);
            }
        }

        public bool IsValid { get { return _engine.IsInvalid; } }

        public void Start() {
            int r = engine.engEvalString(this._engine, "start;");
        }

        public bool Visible {
            get {
                bool v;
                engine.engGetVisible(_engine, out v);
                return v;
            }
            set { engine.engSetVisible(_engine, value); }
        }

        public bool PutVariable(string variableName, mxArray variable) {
            return engine.engPutVariable(this._engine, variableName, variable.NativeObject) == 0;
        }

        public bool Execute(string cmd) {
            return engine.engEvalString(this._engine, cmd) == 0;
        }

        public mxArray GetVariable(string variableName) {
            return mxArray.Create(engine.engGetVariable(this._engine, variableName));
        }


        public void Close() { Dispose(); }

        internal void ValidateResult(int result) {
            if (result != 0) {

            }
        }

        #region IDispose

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (!_disposed) {
                if (disposing) {
                    _engine.Close();
                }

                _disposed = true;
            }
        }

        ~MatEngine() {
            Dispose(false);
        }

        #endregion
    }
}
