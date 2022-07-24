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
        public static bool ToBoolean<TNumeric>(TNumeric value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToBoolean(value);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte<TNumeric>(TNumeric value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToByte(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ToByte<TNumeric>(TNumeric value, Conversion mode) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToByte(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToDecimal<TNumeric>(TNumeric value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToDecimal(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal ToDecimal<TNumeric>(TNumeric value, Conversion mode) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToDecimal(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble<TNumeric>(TNumeric value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToDouble(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble<TNumeric>(TNumeric value, Conversion mode) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToDouble(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToSingle<TNumeric>(TNumeric value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToSingle(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToSingle<TNumeric>(TNumeric value, Conversion mode) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToSingle(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt32<TNumeric>(TNumeric value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToInt32(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt32<TNumeric>(TNumeric value, Conversion mode) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToInt32(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToInt64<TNumeric>(TNumeric value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToInt64(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToInt64<TNumeric>(TNumeric value, Conversion mode) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToInt64(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToInt16<TNumeric>(TNumeric value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToInt16(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ToInt16<TNumeric>(TNumeric value, Conversion mode) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToInt16(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString<TNumeric>(TNumeric value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToString(value);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static sbyte ToSByte<TNumeric>(TNumeric value) where TNumeric : struct, INumericExtended<TNumeric> => Provider<TNumeric, IConvertExtended<TNumeric>>.Default.ToSByte(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static sbyte ToSByte<TNumeric>(TNumeric value, Conversion mode) where TNumeric : struct, INumericExtended<TNumeric> => Provider<TNumeric, IConvertExtended<TNumeric>>.Default.ToSByte(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static uint ToUInt32<TNumeric>(TNumeric value) where TNumeric : struct, INumericExtended<TNumeric> => Provider<TNumeric, IConvertExtended<TNumeric>>.Default.ToUInt32(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static uint ToUInt32<TNumeric>(TNumeric value, Conversion mode) where TNumeric : struct, INumericExtended<TNumeric> => Provider<TNumeric, IConvertExtended<TNumeric>>.Default.ToUInt32(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static ulong ToUInt64<TNumeric>(TNumeric value) where TNumeric : struct, INumericExtended<TNumeric> => Provider<TNumeric, IConvertExtended<TNumeric>>.Default.ToUInt64(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static ulong ToUInt64<TNumeric>(TNumeric value, Conversion mode) where TNumeric : struct, INumericExtended<TNumeric> => Provider<TNumeric, IConvertExtended<TNumeric>>.Default.ToUInt64(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static ushort ToUInt16<TNumeric>(TNumeric value) where TNumeric : struct, INumericExtended<TNumeric> => Provider<TNumeric, IConvertExtended<TNumeric>>.Default.ToUInt16(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static ushort ToUInt16<TNumeric>(TNumeric value, Conversion mode) where TNumeric : struct, INumericExtended<TNumeric> => Provider<TNumeric, IConvertExtended<TNumeric>>.Default.ToUInt16(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(bool value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToNumeric(value);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(byte value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(byte value, Conversion mode) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(decimal value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(decimal value, Conversion mode) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(double value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(double value, Conversion mode) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(float value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(float value, Conversion mode) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(int value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(int value, Conversion mode) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(long value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(long value, Conversion mode) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(short value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(short value, Conversion mode) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(string value) where TNumeric : struct, INumeric<TNumeric> => Provider<TNumeric, IConvert<TNumeric>>.Default.ToNumeric(value);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static TNumeric ToNumeric<TNumeric>(sbyte value) where TNumeric : struct, INumericExtended<TNumeric> => Provider<TNumeric, IConvertExtended<TNumeric>>.Default.ToValue(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static TNumeric ToNumeric<TNumeric>(sbyte value, Conversion mode) where TNumeric : struct, INumericExtended<TNumeric> => Provider<TNumeric, IConvertExtended<TNumeric>>.Default.ToValue(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static TNumeric ToNumeric<TNumeric>(uint value) where TNumeric : struct, INumericExtended<TNumeric> => Provider<TNumeric, IConvertExtended<TNumeric>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static TNumeric ToNumeric<TNumeric>(uint value, Conversion mode) where TNumeric : struct, INumericExtended<TNumeric> => Provider<TNumeric, IConvertExtended<TNumeric>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static TNumeric ToNumeric<TNumeric>(ulong value) where TNumeric : struct, INumericExtended<TNumeric> => Provider<TNumeric, IConvertExtended<TNumeric>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static TNumeric ToNumeric<TNumeric>(ulong value, Conversion mode) where TNumeric : struct, INumericExtended<TNumeric> => Provider<TNumeric, IConvertExtended<TNumeric>>.Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static TNumeric ToNumeric<TNumeric>(ushort value) where TNumeric : struct, INumericExtended<TNumeric> => Provider<TNumeric, IConvertExtended<TNumeric>>.Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [CLSCompliant(false)]
        public static TNumeric ToNumeric<TNumeric>(ushort value, Conversion mode) where TNumeric : struct, INumericExtended<TNumeric> => Provider<TNumeric, IConvertExtended<TNumeric>>.Default.ToNumeric(value, mode);
    }
}
