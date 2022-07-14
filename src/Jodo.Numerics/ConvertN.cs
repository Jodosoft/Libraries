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
using System.Runtime.CompilerServices;
using Jodo.Primitives;

namespace Jodo.Numerics
{
    public static class ConvertN
    {
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ToBoolean<N>(N value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToBoolean(value);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte<N>(N value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToByte(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte<N>(N value, Conversion mode) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToByte(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToDecimal<N>(N value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToDecimal(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToDecimal<N>(N value, Conversion mode) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToDecimal(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble<N>(N value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToDouble(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble<N>(N value, Conversion mode) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToDouble(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToSingle<N>(N value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToSingle(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToSingle<N>(N value, Conversion mode) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToSingle(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt32<N>(N value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToInt32(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt32<N>(N value, Conversion mode) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToInt32(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToInt64<N>(N value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToInt64(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToInt64<N>(N value, Conversion mode) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToInt64(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToInt16<N>(N value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToInt16(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToInt16<N>(N value, Conversion mode) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToInt16(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString<N>(N value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToString(value);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static sbyte ToSByte<N>(N value) where N : struct, INumericExtended<N> => Provider<N, IConvertExtended<N>>.Default.ToSByte(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static sbyte ToSByte<N>(N value, Conversion mode) where N : struct, INumericExtended<N> => Provider<N, IConvertExtended<N>>.Default.ToSByte(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static uint ToUInt32<N>(N value) where N : struct, INumericExtended<N> => Provider<N, IConvertExtended<N>>.Default.ToUInt32(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static uint ToUInt32<N>(N value, Conversion mode) where N : struct, INumericExtended<N> => Provider<N, IConvertExtended<N>>.Default.ToUInt32(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static ulong ToUInt64<N>(N value) where N : struct, INumericExtended<N> => Provider<N, IConvertExtended<N>>.Default.ToUInt64(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static ulong ToUInt64<N>(N value, Conversion mode) where N : struct, INumericExtended<N> => Provider<N, IConvertExtended<N>>.Default.ToUInt64(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static ushort ToUInt16<N>(N value) where N : struct, INumericExtended<N> => Provider<N, IConvertExtended<N>>.Default.ToUInt16(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static ushort ToUInt16<N>(N value, Conversion mode) where N : struct, INumericExtended<N> => Provider<N, IConvertExtended<N>>.Default.ToUInt16(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric<N>(bool value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToNumeric(value);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric<N>(byte value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric<N>(byte value, Conversion mode) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric<N>(decimal value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric<N>(decimal value, Conversion mode) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric<N>(double value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric<N>(double value, Conversion mode) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric<N>(float value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric<N>(float value, Conversion mode) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric<N>(int value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric<N>(int value, Conversion mode) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric<N>(long value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric<N>(long value, Conversion mode) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric<N>(short value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric<N>(short value, Conversion mode) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N ToNumeric<N>(string value) where N : struct, INumeric<N> => Provider<N, IConvert<N>>.Default.ToNumeric(value);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static N ToNumeric<N>(sbyte value) where N : struct, INumericExtended<N> => Provider<N, IConvertExtended<N>>.Default.ToValue(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static N ToNumeric<N>(sbyte value, Conversion mode) where N : struct, INumericExtended<N> => Provider<N, IConvertExtended<N>>.Default.ToValue(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static N ToNumeric<N>(uint value) where N : struct, INumericExtended<N> => Provider<N, IConvertExtended<N>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static N ToNumeric<N>(uint value, Conversion mode) where N : struct, INumericExtended<N> => Provider<N, IConvertExtended<N>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static N ToNumeric<N>(ulong value) where N : struct, INumericExtended<N> => Provider<N, IConvertExtended<N>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static N ToNumeric<N>(ulong value, Conversion mode) where N : struct, INumericExtended<N> => Provider<N, IConvertExtended<N>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static N ToNumeric<N>(ushort value) where N : struct, INumericExtended<N> => Provider<N, IConvertExtended<N>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static N ToNumeric<N>(ushort value, Conversion mode) where N : struct, INumericExtended<N> => Provider<N, IConvertExtended<N>>.Default.ToNumeric(value, mode);
    }
}
