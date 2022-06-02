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

namespace Jodo.Extensions.Primitives
{
    public static class Convert<T> where T : struct, IProvider<IConvert<T>>
    {
        private static readonly IConvert<T> Default = default(T).GetInstance();

        [DebuggerStepThrough]
        public static bool ToBoolean(T value) => Default.ToBoolean(value);

        [DebuggerStepThrough]
        public static byte ToByte(T value) => Default.ToByte(value);

        [DebuggerStepThrough]
        public static decimal ToDecimal(T value) => Default.ToDecimal(value);

        [DebuggerStepThrough]
        public static double ToDouble(T value) => Default.ToDouble(value);

        [DebuggerStepThrough]
        public static float ToSingle(T value) => Default.ToSingle(value);

        [DebuggerStepThrough]
        public static int ToInt32(T value) => Default.ToInt32(value);

        [DebuggerStepThrough]
        public static long ToInt64(T value) => Default.ToInt64(value);

        [DebuggerStepThrough]
        public static sbyte ToSByte(T value) => Default.ToSByte(value);

        [DebuggerStepThrough]
        public static short ToInt16(T value) => Default.ToInt16(value);

        [DebuggerStepThrough]
        public static string ToString(T value) => Default.ToString(value);

        [DebuggerStepThrough]
        public static string ToString(T value, IFormatProvider provider) => Default.ToString(value, provider);

        [DebuggerStepThrough]
        public static uint ToUInt32(T value) => Default.ToUInt32(value);

        [DebuggerStepThrough]
        public static ulong ToUInt64(T value) => Default.ToUInt64(value);

        [DebuggerStepThrough]
        public static ushort ToUInt16(T value) => Default.ToUInt16(value);

        [DebuggerStepThrough]
        public static T ToValue(bool value) => Default.ToValue(value);

        [DebuggerStepThrough]
        public static T ToValue(byte value) => Default.ToValue(value);

        [DebuggerStepThrough]
        public static T ToValue(decimal value) => Default.ToValue(value);

        [DebuggerStepThrough]
        public static T ToValue(double value) => Default.ToValue(value);

        [DebuggerStepThrough]
        public static T ToValue(float value) => Default.ToValue(value);

        [DebuggerStepThrough]
        public static T ToValue(int value) => Default.ToValue(value);

        [DebuggerStepThrough]
        public static T ToValue(long value) => Default.ToValue(value);

        [DebuggerStepThrough]
        public static T ToValue(sbyte value) => Default.ToValue(value);

        [DebuggerStepThrough]
        public static T ToValue(short value) => Default.ToValue(value);

        [DebuggerStepThrough]
        public static T ToValue(string value) => Default.ToValue(value);

        [DebuggerStepThrough]
        public static T ToValue(string value, IFormatProvider provider) => Default.ToValue(value, provider);

        [DebuggerStepThrough]
        public static T ToValue(uint value) => Default.ToValue(value);

        [DebuggerStepThrough]
        public static T ToValue(ulong value) => Default.ToValue(value);

        [DebuggerStepThrough]
        public static T ToValue(ushort value) => Default.ToValue(value);
    }
}
