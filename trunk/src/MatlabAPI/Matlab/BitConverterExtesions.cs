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

namespace MatlabAPI.Matlab {
    internal static class BitConverterExtesions {
        #region constances

        public const int bool_size      = sizeof(bool);
        public const int byte_size      = sizeof(byte);
        public const int short_size     = sizeof(short);
        public const int ushort_size    = sizeof(ushort);
        public const int int_size       = sizeof(int);
        public const int uint_size      = sizeof(uint);
        public const int long_size      = sizeof(long);
        public const int ulong_size     = sizeof(ulong);
        public const int float_size     = sizeof(float);
        public const int double_size    = sizeof(double);

        #endregion

        #region getbytes

        #region one dimensions

        public static byte[] GetBytes(bool[] values) {
            byte[] buf = new byte[values.Length * bool_size];
            Buffer.BlockCopy(values, 0, buf, 0, buf.Length);
            return buf;
        }

        public static byte[] GetBytes(sbyte[] values) {
            byte[] buf = new byte[values.Length * byte_size];
            Buffer.BlockCopy(values, 0, buf, 0, buf.Length);
            return buf;
        }

        public static byte[] GetBytes(short[] values) {
            byte[] buf = new byte[values.Length * short_size];
            Buffer.BlockCopy(values, 0, buf, 0, buf.Length);
            return buf;
        }

        public static byte[] GetBytes(ushort[] values) {
            byte[] buf = new byte[values.Length * ushort_size];
            Buffer.BlockCopy(values, 0, buf, 0, buf.Length);
            return buf;
        }


        public static byte[] GetBytes(int[] values) {
            byte[] buf = new byte[values.Length * int_size];
            Buffer.BlockCopy(values, 0, buf, 0, buf.Length);
            return buf;
        }

        public static byte[] GetBytes(uint[] values) {
            byte[] buf = new byte[values.Length * uint_size];
            Buffer.BlockCopy(values, 0, buf, 0, buf.Length);
            return buf;
        }

        public static byte[] GetBytes(long[] values) {
            byte[] buf = new byte[values.Length * long_size];
            Buffer.BlockCopy(values, 0, buf, 0, buf.Length);
            return buf;
        }

        public static byte[] GetBytes(ulong[] values) {
            byte[] buf = new byte[values.Length * ulong_size];
            Buffer.BlockCopy(values, 0, buf, 0, buf.Length);
            return buf;
        }

        public static byte[] GetBytes(float[] values) {
            byte[] buf = new byte[values.Length * float_size];
            Buffer.BlockCopy(values, 0, buf, 0, buf.Length);
            return buf;
        }

        public static byte[] GetBytes(double[] values) {
            byte[] buf = new byte[values.Length * double_size];
            Buffer.BlockCopy(values, 0, buf, 0, buf.Length);
            return buf;
        }

        #endregion

        #region two dimensions

        public static byte[] GetBytes(bool[,] values) {
            int rows = values.GetLength(0);
            int cols = values.GetLength(1);
            byte[] buf = new byte[rows * cols * bool_size];

            for (int r = 0;r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    buf[c * rows + r] = values[r,c] ? (byte)1 : (byte)0;
                }
            }

            return buf;
        }

        public static byte[] GetBytes(byte[,] values) {
            int rows = values.GetLength(0);
            int cols = values.GetLength(1);
            byte[] buf = new byte[rows * cols * byte_size];

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    buf[c * rows + r] = values[r, c];
                }
            }

            return buf;
        }

        public static byte[] GetBytes(sbyte[,] values) {
            int rows = values.GetLength(0);
            int cols = values.GetLength(1);
            byte[] buf = new byte[rows * cols * byte_size];

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    buf[c * rows + r] = (byte)values[r, c];
                }
            }

            return buf;
        }

        public static byte[] GetBytes(short[,] values){
            int rows = values.GetLength(0);
            int cols = values.GetLength(1);
            byte[] buf = new byte[rows * cols * short_size];
            byte[] tmp;
            int offset;

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    offset = (c * rows + r) * short_size;
                    tmp = BitConverter.GetBytes(values[r,c]);
                    Buffer.BlockCopy(tmp, 0, buf, offset, short_size);
                }
            }

            return buf;
        }

        
        public static byte[] GetBytes(ushort[,] values) {
            int rows = values.GetLength(0);
            int cols = values.GetLength(1);
            byte[] buf = new byte[rows * cols * ushort_size];
            byte[] tmp;
            int offset;

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    offset = (c * rows + r) * ushort_size;
                    tmp = BitConverter.GetBytes(values[r, c]);
                    Buffer.BlockCopy(tmp, 0, buf, offset, ushort_size);
                }
            }

            return buf;
        }


        public static byte[] GetBytes(int[,] values) {
            int rows = values.GetLength(0);
            int cols = values.GetLength(1);
            byte[] buf = new byte[rows * cols * int_size];
            byte[] tmp;
            int offset;

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    offset = (c * rows + r) * int_size;
                    tmp = BitConverter.GetBytes(values[r, c]);
                    Buffer.BlockCopy(tmp, 0, buf, offset, int_size);
                }
            }

            return buf;
        }

        public static byte[] GetBytes(uint[,] values) {
            int rows = values.GetLength(0);
            int cols = values.GetLength(1);
            byte[] buf = new byte[rows * cols * uint_size];
            byte[] tmp;
            int offset;

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    offset = (c * rows + r) * uint_size;
                    tmp = BitConverter.GetBytes(values[r, c]);
                    Buffer.BlockCopy(tmp, 0, buf, offset, uint_size);
                }
            }

            return buf;
        }

        public static byte[] GetBytes(long[,] values) {
            int rows = values.GetLength(0);
            int cols = values.GetLength(1);
            byte[] buf = new byte[rows * cols * long_size];
            byte[] tmp;
            int offset;

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    offset = (c * rows + r) * long_size;
                    tmp = BitConverter.GetBytes(values[r, c]);
                    Buffer.BlockCopy(tmp, 0, buf, offset, long_size);
                }
            }

            return buf;
        }

        
        public static byte[] GetBytes(ulong[,] values) {
            int rows = values.GetLength(0);
            int cols = values.GetLength(1);
            byte[] buf = new byte[rows * cols * ulong_size];
            byte[] tmp;
            int offset;

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    offset = (c * rows + r) * ulong_size;
                    tmp = BitConverter.GetBytes(values[r, c]);
                    Buffer.BlockCopy(tmp, 0, buf, offset, ulong_size);
                }
            }

            return buf;
        }

        public static byte[] GetBytes(float[,] values) {
            int rows = values.GetLength(0);
            int cols = values.GetLength(1);
            byte[] buf = new byte[rows * cols * float_size];
            byte[] tmp;
            int offset;

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    offset = (c * rows + r) * float_size;
                    tmp = BitConverter.GetBytes(values[r, c]);
                    Buffer.BlockCopy(tmp, 0, buf, offset, float_size);
                }
            }

            return buf;
        }


        public static byte[] GetBytes(double[,] values) {
            int rows = values.GetLength(0);
            int cols = values.GetLength(1);
            byte[] buf = new byte[rows * cols * double_size];
            byte[] tmp;
            int offset;

            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < cols; c++) {
                    offset = (c * rows + r) * double_size;
                    tmp = BitConverter.GetBytes(values[r, c]);
                    Buffer.BlockCopy(tmp, 0, buf, offset, double_size);
                }
            }

            return buf;
        }

        #endregion

        #endregion

        public static bool[,] ToArray(byte[] buffer, int m, int n) {
            if (m < 1 || n < 1)
                throw new ArgumentOutOfRangeException("The dimension must be larger than 1.");

            if (buffer.Length != m * n)
                throw new ArgumentException("The buffer length is not match with m*n.");

            bool[,] values = new bool[m, n];
            byte zero = (byte)0;

            for (int r = 0; r < m; r++) {
                for (int c = 0; c < n; c++) {
                    values[r, c] = buffer[c * m + r] == zero ? false : true;
                }
            }

            return values;
        }

        public static Array ToArray(byte[] buffer, int m, int n, mxNumericType numType) {
            if (m < 1 || n < 1)
                throw new ArgumentOutOfRangeException("The dimension must be larger than 1.");

            switch (numType) {
                case mxNumericType.UINT8:{
                        if (buffer.Length != m * n * byte_size)
                            throw new ArgumentException("The buffer length is not match with m*n.");
                        
                        byte[,] values = new byte[m, n];

                        for (int r = 0; r < m; r++) {
                            for (int c = 0; c < n; c++) {
                                values[r, c] = buffer[c * m + r];
                            }
                        }

                        return values;
                    }
                case mxNumericType.INT8: {
                        if (buffer.Length != m * n * byte_size)
                            throw new ArgumentException("The buffer length is not match with m*n.");
                        
                        sbyte[,] values = new sbyte[m, n];

                        for (int r = 0; r < m; r++) {
                            for (int c = 0; c < n; c++) {
                                values[r, c] = (sbyte)buffer[c * m + r];
                            }
                        }

                        return values;
                    }
                case mxNumericType.INT16: {
                        if (buffer.Length != m * n * short_size)
                            throw new ArgumentException("The buffer length is not match with m*n.");

                        short[,] values = new short[m, n];
                        int offset;
                        for (int r = 0; r < m; r++) {
                            for (int c = 0; c < n; c++) {
                                offset = (c * m + r) * short_size;
                                Buffer.BlockCopy(buffer, offset, values, (r * n + c) * short_size, short_size);
                            }
                        }

                        return values;
                    }
                case mxNumericType.UINT16: {
                        if (buffer.Length != m * n * ushort_size)
                            throw new ArgumentException("The buffer length is not match with m*n.");

                        ushort[,] values = new ushort[m, n];
                        int offset;
                        for (int r = 0; r < m; r++) {
                            for (int c = 0; c < n; c++) {
                                offset = (c * m + r) * ushort_size;
                                Buffer.BlockCopy(buffer, offset, values, (r * n + c) * ushort_size, ushort_size);
                            }
                        }

                        return values;
                    }
                case mxNumericType.INT32: {
                        if (buffer.Length != m * n * int_size)
                            throw new ArgumentException("The buffer length is not match with m*n.");

                        int[,] values = new int[m, n];
                        int offset;
                        for (int r = 0; r < m; r++) {
                            for (int c = 0; c < n; c++) {
                                offset = (c * m + r) * int_size;
                                Buffer.BlockCopy(buffer, offset, values, (r * n + c) * int_size, int_size);
                            }
                        }

                        return values;
                    }
                case mxNumericType.UINT32:{
                        if (buffer.Length != m * n * uint_size)
                            throw new ArgumentException("The buffer length is not match with m*n.");

                        uint[,] values = new uint[m, n];
                        int offset;
                        for (int r = 0; r < m; r++) {
                            for (int c = 0; c < n; c++) {
                                offset = (c * m + r) * uint_size;
                                Buffer.BlockCopy(buffer, offset, values, (r * n + c) * uint_size, uint_size);
                            }
                        }

                        return values;
                    }
                case mxNumericType.INT64: {
                        if (buffer.Length != m * n * long_size)
                            throw new ArgumentException("The buffer length is not match with m*n.");

                        long[,] values = new long[m, n];
                        int offset;
                        for (int r = 0; r < m; r++) {
                            for (int c = 0; c < n; c++) {
                                offset = (c * m + r) * long_size;
                                Buffer.BlockCopy(buffer, offset, values, (r * n + c) * long_size, long_size);
                            }
                        }

                        return values;
                    }
                case mxNumericType.UINT64: {
                        if (buffer.Length != m * n * ulong_size)
                            throw new ArgumentException("The buffer length is not match with m*n.");

                        ulong[,] values = new ulong[m, n];
                        int offset;
                        for (int r = 0; r < m; r++) {
                            for (int c = 0; c < n; c++) {
                                offset = (c * m + r) * ulong_size;
                                Buffer.BlockCopy(buffer, offset, values, (r * n + c) * ulong_size, ulong_size);
                            }
                        }

                        return values;
                    }
                case mxNumericType.SINGLE: {
                        if (buffer.Length != m * n * float_size)
                            throw new ArgumentException("The buffer length is not match with m*n.");

                        float[,] values = new float[m, n];
                        int offset;
                        for (int r = 0; r < m; r++) {
                            for (int c = 0; c < n; c++) {
                                offset = (c * m + r) * float_size;
                                Buffer.BlockCopy(buffer, offset, values, (r * n + c) * float_size, float_size);
                            }
                        }

                        return values;
                    }
                case mxNumericType.DOUBLE: {
                        if (buffer.Length != m * n * double_size)
                            throw new ArgumentException("The buffer length is not match with m*n.");

                        double[,] values = new double[m, n];
                        int offset;
                        for (int r = 0; r < m; r++) {
                            for (int c = 0; c < n; c++) {
                                offset = (c * m + r) * double_size;
                                Buffer.BlockCopy(buffer, offset, values, (r * n + c) * double_size, double_size);
                            }
                        }

                        return values;
                    }
                default:
                    throw new ArgumentException();
            }
        }
    }
}
