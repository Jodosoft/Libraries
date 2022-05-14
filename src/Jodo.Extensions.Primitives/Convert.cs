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
    public static class Convert<T> where T : IConvertible<T>, new()
    {
        private static readonly IConvert<T> DefaultInstance = new T().Convert;

        [DebuggerStepThrough] public static bool ToBoolean(T value) => DefaultInstance.ToBoolean(value);
        [DebuggerStepThrough] public static byte ToByte(T value) => DefaultInstance.ToByte(value);
        [DebuggerStepThrough] public static char ToChar(T value) => DefaultInstance.ToChar(value);
        [DebuggerStepThrough] public static decimal ToDecimal(T value) => DefaultInstance.ToDecimal(value);
        [DebuggerStepThrough] public static double ToDouble(T value) => DefaultInstance.ToDouble(value);
        [DebuggerStepThrough] public static float ToSingle(T value) => DefaultInstance.ToSingle(value);
        [DebuggerStepThrough] public static int ToInt32(T value) => DefaultInstance.ToInt32(value);
        [DebuggerStepThrough] public static long ToInt64(T value) => DefaultInstance.ToInt64(value);
        [DebuggerStepThrough] public static sbyte ToSByte(T value) => DefaultInstance.ToSByte(value);
        [DebuggerStepThrough] public static short ToInt16(T value) => DefaultInstance.ToInt16(value);
        [DebuggerStepThrough] public static string ToString(T value) => DefaultInstance.ToString(value);
        [DebuggerStepThrough] public static string ToString(T value, IFormatProvider provider) => DefaultInstance.ToString(value, provider);
        [DebuggerStepThrough] public static uint ToUInt32(T value) => DefaultInstance.ToUInt32(value);
        [DebuggerStepThrough] public static ulong ToUInt64(T value) => DefaultInstance.ToUInt64(value);
        [DebuggerStepThrough] public static ushort ToUInt16(T value) => DefaultInstance.ToUInt16(value);

        [DebuggerStepThrough] public static T ToValue(bool value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static T ToValue(byte value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static T ToValue(char value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static T ToValue(decimal value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static T ToValue(double value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static T ToValue(float value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static T ToValue(int value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static T ToValue(long value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static T ToValue(sbyte value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static T ToValue(short value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static T ToValue(string value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static T ToValue(string value, IFormatProvider provider) => DefaultInstance.ToValue(value, provider);
        [DebuggerStepThrough] public static T ToValue(uint value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static T ToValue(ulong value) => DefaultInstance.ToValue(value);
        [DebuggerStepThrough] public static T ToValue(ushort value) => DefaultInstance.ToValue(value);
    }
}
