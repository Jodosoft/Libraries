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

using System.Diagnostics;
using System.Runtime.CompilerServices;
using Jodo.Primitives;

namespace Jodo.Numerics
{
    public static class Convert<N> where N : struct, IProvider<IConvert<N>>
    {
        private static readonly IConvert<N> Default = default(N).GetInstance();

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBoolean(N value) => Default.ToBoolean(value);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte(N value) => Default.ToByte(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte(N value, Conversion mode) => Default.ToByte(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToDecimal(N value) => Default.ToDecimal(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToDecimal(N value, Conversion mode) => Default.ToDecimal(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(N value) => Default.ToDouble(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(N value, Conversion mode) => Default.ToDouble(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToSingle(N value) => Default.ToSingle(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToSingle(N value, Conversion mode) => Default.ToSingle(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt32(N value) => Default.ToInt32(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt32(N value, Conversion mode) => Default.ToInt32(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToInt64(N value) => Default.ToInt64(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToInt64(N value, Conversion mode) => Default.ToInt64(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToInt16(N value) => Default.ToInt16(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToInt16(N value, Conversion mode) => Default.ToInt16(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(N value) => Default.ToString(value);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric(bool value) => Default.ToValue(value);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric(byte value) => Default.ToValue(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric(byte value, Conversion mode) => Default.ToValue(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric(decimal value) => Default.ToValue(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric(decimal value, Conversion mode) => Default.ToValue(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric(double value) => Default.ToValue(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric(double value, Conversion mode) => Default.ToValue(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric(float value) => Default.ToValue(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric(float value, Conversion mode) => Default.ToValue(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric(int value) => Default.ToValue(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric(int value, Conversion mode) => Default.ToValue(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric(long value) => Default.ToValue(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric(long value, Conversion mode) => Default.ToValue(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric(short value) => Default.ToValue(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric(short value, Conversion mode) => Default.ToValue(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric(string value) => Default.ToValue(value);
    }
}
