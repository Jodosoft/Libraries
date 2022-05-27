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

namespace Jodo.Extensions.Numerics
{
    public static class Cast<N> where N : struct, INumeric<N>
    {
        private static readonly ICast<N> DefaultInstance = new N().Cast;

        [DebuggerStepThrough] public static byte ToByte(N value) => DefaultInstance.ToByte(value);
        [DebuggerStepThrough] public static decimal ToDecimal(N value) => DefaultInstance.ToDecimal(value);
        [DebuggerStepThrough] public static double ToDouble(N value) => DefaultInstance.ToDouble(value);
        [DebuggerStepThrough] public static float ToSingle(N value) => DefaultInstance.ToSingle(value);
        [DebuggerStepThrough] public static int ToInt32(N value) => DefaultInstance.ToInt32(value);
        [DebuggerStepThrough] public static long ToInt64(N value) => DefaultInstance.ToInt64(value);
        [DebuggerStepThrough] public static sbyte ToSByte(N value) => DefaultInstance.ToSByte(value);
        [DebuggerStepThrough] public static short ToInt16(N value) => DefaultInstance.ToInt16(value);
        [DebuggerStepThrough] public static uint ToUInt32(N value) => DefaultInstance.ToUInt32(value);
        [DebuggerStepThrough] public static ulong ToUInt64(N value) => DefaultInstance.ToUInt64(value);
        [DebuggerStepThrough] public static ushort ToUInt16(N value) => DefaultInstance.ToUInt16(value);

        [DebuggerStepThrough] public static N ToValue(byte value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static N ToValue(decimal value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static N ToValue(double value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static N ToValue(float value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static N ToValue(int value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static N ToValue(long value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static N ToValue(sbyte value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static N ToValue(short value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static N ToValue(uint value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static N ToValue(ulong value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static N ToValue(ushort value) => DefaultInstance.ToValue(value);
    }
}
