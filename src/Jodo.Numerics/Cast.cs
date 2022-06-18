// Copyright (c) 2022 Joseph J. Short
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.

using System;
using System.Diagnostics;
using Jodo.Primitives;

namespace Jodo.Numerics
{
    [CLSCompliant(false)]
    public static class Cast<N> where N : struct, INumeric<N>
    {
        private static readonly ICast<N> Default = ((IProvider<ICast<N>>)default(N)).GetInstance();

        [DebuggerStepThrough]
        public static byte ToByte(N value) => Default.ToByte(value);

        [DebuggerStepThrough]
        public static decimal ToDecimal(N value) => Default.ToDecimal(value);

        [DebuggerStepThrough]
        public static double ToDouble(N value) => Default.ToDouble(value);

        [DebuggerStepThrough]
        public static float ToSingle(N value) => Default.ToSingle(value);

        [DebuggerStepThrough]
        public static int ToInt32(N value) => Default.ToInt32(value);

        [DebuggerStepThrough]
        public static long ToInt64(N value) => Default.ToInt64(value);

        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static sbyte ToSByte(N value) => Default.ToSByte(value);

        [DebuggerStepThrough]
        public static short ToInt16(N value) => Default.ToInt16(value);

        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static uint ToUInt32(N value) => Default.ToUInt32(value);

        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static ulong ToUInt64(N value) => Default.ToUInt64(value);

        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static ushort ToUInt16(N value) => Default.ToUInt16(value);

        [DebuggerStepThrough]
        public static N ToNumeric(byte value) => Default.ToNumeric(value);

        [DebuggerStepThrough]
        public static N ToNumeric(decimal value) => Default.ToNumeric(value);

        [DebuggerStepThrough]
        public static N ToNumeric(double value) => Default.ToNumeric(value);

        [DebuggerStepThrough]
        public static N ToNumeric(float value) => Default.ToNumeric(value);

        [DebuggerStepThrough]
        public static N ToNumeric(int value) => Default.ToNumeric(value);

        [DebuggerStepThrough]
        public static N ToNumeric(long value) => Default.ToNumeric(value);

        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static N ToNumeric(sbyte value) => Default.ToNumeric(value);

        [DebuggerStepThrough]
        public static N ToNumeric(short value) => Default.ToNumeric(value);

        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static N ToNumeric(uint value) => Default.ToNumeric(value);

        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static N ToNumeric(ulong value) => Default.ToNumeric(value);

        [DebuggerStepThrough]
        [CLSCompliant(false)]
        public static N ToNumeric(ushort value) => Default.ToNumeric(value);
    }
}
