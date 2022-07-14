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
using System.Diagnostics.CodeAnalysis;

namespace Jodo.Numerics
{
    [SuppressMessage("csharpsquid", "S3358")]
    [SuppressMessage("csharpsquid", "S2583")] // false positives
    public static class NumericConvert
    {
        [CLSCompliant(false)]
        public static sbyte ToSByte(ushort value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToSByte(value),
            Conversion.Clamp => value > sbyte.MaxValue ? sbyte.MaxValue : Convert.ToSByte(value),
            Conversion.Cast => (sbyte)value,
            Conversion.CastClamp => value > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static sbyte ToSByte(uint value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToSByte(value),
            Conversion.Clamp => value > sbyte.MaxValue ? sbyte.MaxValue : Convert.ToSByte(value),
            Conversion.Cast => (sbyte)value,
            Conversion.CastClamp => value > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static sbyte ToSByte(ulong value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToSByte(value),
            Conversion.Clamp => value > (ulong)sbyte.MaxValue ? sbyte.MaxValue : Convert.ToSByte(value),
            Conversion.Cast => (sbyte)value,
            Conversion.CastClamp => value > (ulong)sbyte.MaxValue ? sbyte.MaxValue : (sbyte)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static sbyte ToSByte(byte value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToSByte(value),
            Conversion.Clamp => value > sbyte.MaxValue ? sbyte.MaxValue : Convert.ToSByte(value),
            Conversion.Cast => (sbyte)value,
            Conversion.CastClamp => value > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static sbyte ToSByte(short value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToSByte(value),
            Conversion.Clamp => value < sbyte.MinValue ? sbyte.MinValue : value > sbyte.MaxValue ? sbyte.MaxValue : Convert.ToSByte(value),
            Conversion.Cast => (sbyte)value,
            Conversion.CastClamp => value < sbyte.MinValue ? sbyte.MinValue : value > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static sbyte ToSByte(int value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToSByte(value),
            Conversion.Clamp => value < sbyte.MinValue ? sbyte.MinValue : value > sbyte.MaxValue ? sbyte.MaxValue : Convert.ToSByte(value),
            Conversion.Cast => (sbyte)value,
            Conversion.CastClamp => value < sbyte.MinValue ? sbyte.MinValue : value > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static sbyte ToSByte(long value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToSByte(value),
            Conversion.Clamp => value < sbyte.MinValue ? sbyte.MinValue : value > sbyte.MaxValue ? sbyte.MaxValue : Convert.ToSByte(value),
            Conversion.Cast => (sbyte)value,
            Conversion.CastClamp => value < sbyte.MinValue ? sbyte.MinValue : value > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static sbyte ToSByte(float value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToSByte(value),
            Conversion.Clamp => value < sbyte.MinValue ? sbyte.MinValue : value > sbyte.MaxValue ? sbyte.MaxValue : float.IsNaN(value) ? (sbyte)0 : Convert.ToSByte(value),
            Conversion.Cast => (sbyte)value,
            Conversion.CastClamp => value < sbyte.MinValue ? sbyte.MinValue : value > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static sbyte ToSByte(double value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToSByte(value),
            Conversion.Clamp => value < sbyte.MinValue ? sbyte.MinValue : value > sbyte.MaxValue ? sbyte.MaxValue : double.IsNaN(value) ? (sbyte)0 : Convert.ToSByte(value),
            Conversion.Cast => (sbyte)value,
            Conversion.CastClamp => value < sbyte.MinValue ? sbyte.MinValue : value > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static sbyte ToSByte(decimal value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToSByte(value),
            Conversion.Clamp => value < sbyte.MinValue ? sbyte.MinValue : value > sbyte.MaxValue ? sbyte.MaxValue : Convert.ToSByte(value),
            Conversion.Cast => (sbyte)value,
            Conversion.CastClamp => value < sbyte.MinValue ? sbyte.MinValue : value > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ushort ToUInt16(sbyte value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt16(value),
            Conversion.Clamp => value < 0 ? (ushort)0 : Convert.ToUInt16(value),
            Conversion.Cast => (ushort)value,
            Conversion.CastClamp => value < 0 ? (ushort)0 : (ushort)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ushort ToUInt16(uint value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt16(value),
            Conversion.Clamp => value > ushort.MaxValue ? ushort.MaxValue : Convert.ToUInt16(value),
            Conversion.Cast => (ushort)value,
            Conversion.CastClamp => value > ushort.MaxValue ? ushort.MaxValue : (ushort)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ushort ToUInt16(ulong value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt16(value),
            Conversion.Clamp => value > ushort.MaxValue ? ushort.MaxValue : Convert.ToUInt16(value),
            Conversion.Cast => (ushort)value,
            Conversion.CastClamp => value > ushort.MaxValue ? ushort.MaxValue : (ushort)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ushort ToUInt16(byte value, Conversion _) => value;

        [CLSCompliant(false)]
        public static ushort ToUInt16(short value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt16(value),
            Conversion.Clamp => value < 0 ? (ushort)0 : Convert.ToUInt16(value),
            Conversion.Cast => (ushort)value,
            Conversion.CastClamp => value < 0 ? (ushort)0 : (ushort)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ushort ToUInt16(int value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt16(value),
            Conversion.Clamp => value < 0 ? (ushort)0 : value > ushort.MaxValue ? ushort.MaxValue : Convert.ToUInt16(value),
            Conversion.Cast => (ushort)value,
            Conversion.CastClamp => value < 0 ? (ushort)0 : value > ushort.MaxValue ? ushort.MaxValue : (ushort)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ushort ToUInt16(long value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt16(value),
            Conversion.Clamp => value < 0 ? (ushort)0 : value > ushort.MaxValue ? ushort.MaxValue : Convert.ToUInt16(value),
            Conversion.Cast => (ushort)value,
            Conversion.CastClamp => value < 0 ? (ushort)0 : value > ushort.MaxValue ? ushort.MaxValue : (ushort)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ushort ToUInt16(float value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt16(value),
            Conversion.Clamp => value < 0 ? (ushort)0 : value > ushort.MaxValue ? ushort.MaxValue : float.IsNaN(value) ? (ushort)0 : Convert.ToUInt16(value),
            Conversion.Cast => (ushort)value,
            Conversion.CastClamp => value < 0 ? (ushort)0 : value > ushort.MaxValue ? ushort.MaxValue : (ushort)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ushort ToUInt16(double value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt16(value),
            Conversion.Clamp => value < 0 ? (ushort)0 : value > ushort.MaxValue ? ushort.MaxValue : double.IsNaN(value) ? (ushort)0 : Convert.ToUInt16(value),
            Conversion.Cast => (ushort)value,
            Conversion.CastClamp => value < 0 ? (ushort)0 : value > ushort.MaxValue ? ushort.MaxValue : (ushort)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ushort ToUInt16(decimal value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt16(value),
            Conversion.Clamp => value < 0 ? (ushort)0 : value > ushort.MaxValue ? ushort.MaxValue : Convert.ToUInt16(value),
            Conversion.Cast => (ushort)value,
            Conversion.CastClamp => value < 0 ? (ushort)0 : value > ushort.MaxValue ? ushort.MaxValue : (ushort)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static uint ToUInt32(sbyte value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt32(value),
            Conversion.Clamp => value < 0 ? 0 : Convert.ToUInt32(value),
            Conversion.Cast => (uint)value,
            Conversion.CastClamp => value < 0 ? 0 : (uint)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static uint ToUInt32(ushort value, Conversion _) => value;

        [CLSCompliant(false)]
        public static uint ToUInt32(ulong value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt32(value),
            Conversion.Clamp => value > uint.MaxValue ? uint.MaxValue : Convert.ToUInt32(value),
            Conversion.Cast => (uint)value,
            Conversion.CastClamp => value > uint.MaxValue ? uint.MaxValue : (uint)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static uint ToUInt32(byte value, Conversion _) => value;

        [CLSCompliant(false)]
        public static uint ToUInt32(short value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt32(value),
            Conversion.Clamp => value < 0 ? 0 : Convert.ToUInt32(value),
            Conversion.Cast => (uint)value,
            Conversion.CastClamp => value < 0 ? 0 : (uint)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static uint ToUInt32(int value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt32(value),
            Conversion.Clamp => value < 0 ? 0 : Convert.ToUInt32(value),
            Conversion.Cast => (uint)value,
            Conversion.CastClamp => value < 0 ? 0 : (uint)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static uint ToUInt32(long value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt32(value),
            Conversion.Clamp => value < 0 ? 0 : value > uint.MaxValue ? uint.MaxValue : Convert.ToUInt32(value),
            Conversion.Cast => (uint)value,
            Conversion.CastClamp => value < 0 ? 0 : value > uint.MaxValue ? uint.MaxValue : (uint)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static uint ToUInt32(float value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt32(value),
            Conversion.Clamp => value < 0 ? 0 : value > uint.MaxValue ? uint.MaxValue : float.IsNaN(value) ? 0 : Convert.ToUInt32(value),
            Conversion.Cast => (uint)value,
            Conversion.CastClamp => value < 0 ? 0 : value > uint.MaxValue ? uint.MaxValue : (uint)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static uint ToUInt32(double value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt32(value),
            Conversion.Clamp => value < 0 ? 0 : value > uint.MaxValue ? uint.MaxValue : double.IsNaN(value) ? 0 : Convert.ToUInt32(value),
            Conversion.Cast => (uint)value,
            Conversion.CastClamp => value < 0 ? 0 : value > uint.MaxValue ? uint.MaxValue : (uint)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static uint ToUInt32(decimal value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt32(value),
            Conversion.Clamp => value < 0 ? 0 : value > uint.MaxValue ? uint.MaxValue : Convert.ToUInt32(value),
            Conversion.Cast => (uint)value,
            Conversion.CastClamp => value < 0 ? 0 : value > uint.MaxValue ? uint.MaxValue : (uint)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ulong ToUInt64(sbyte value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt64(value),
            Conversion.Clamp => value < 0 ? 0 : Convert.ToUInt64(value),
            Conversion.Cast => (ulong)value,
            Conversion.CastClamp => value < 0 ? 0 : (ulong)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ulong ToUInt64(ushort value, Conversion _) => value;

        [CLSCompliant(false)]
        public static ulong ToUInt64(uint value, Conversion _) => value;

        [CLSCompliant(false)]
        public static ulong ToUInt64(byte value, Conversion _) => value;

        [CLSCompliant(false)]
        public static ulong ToUInt64(short value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt64(value),
            Conversion.Clamp => value < 0 ? 0 : Convert.ToUInt64(value),
            Conversion.Cast => (ulong)value,
            Conversion.CastClamp => value < 0 ? 0 : (ulong)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ulong ToUInt64(int value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt64(value),
            Conversion.Clamp => value < 0 ? 0 : Convert.ToUInt64(value),
            Conversion.Cast => (ulong)value,
            Conversion.CastClamp => value < 0 ? 0 : (ulong)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ulong ToUInt64(long value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt64(value),
            Conversion.Clamp => value < 0 ? 0 : Convert.ToUInt64(value),
            Conversion.Cast => (ulong)value,
            Conversion.CastClamp => value < 0 ? 0 : (ulong)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ulong ToUInt64(float value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt64(value),
            Conversion.Clamp => value < ulong.MinValue ? ulong.MinValue : value > ulong.MaxValue ? ulong.MaxValue : float.IsNaN(value) ? 0 : Convert.ToUInt64(value),
            Conversion.Cast => (ulong)value,
            Conversion.CastClamp => value < ulong.MinValue ? ulong.MinValue : value > ulong.MaxValue ? ulong.MaxValue : (ulong)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ulong ToUInt64(double value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt64(value),
            Conversion.Clamp => value < ulong.MinValue ? ulong.MinValue : value > ulong.MaxValue ? ulong.MaxValue : double.IsNaN(value) ? 0 : Convert.ToUInt64(value),
            Conversion.Cast => (ulong)value,
            Conversion.CastClamp => value < ulong.MinValue ? ulong.MinValue : value > ulong.MaxValue ? ulong.MaxValue : (ulong)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ulong ToUInt64(decimal value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToUInt64(value),
            Conversion.Clamp => value < ulong.MinValue ? ulong.MinValue : value > ulong.MaxValue ? ulong.MaxValue : Convert.ToUInt64(value),
            Conversion.Cast => (ulong)value,
            Conversion.CastClamp => value < ulong.MinValue ? ulong.MinValue : value > ulong.MaxValue ? ulong.MaxValue : (ulong)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static byte ToByte(sbyte value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToByte(value),
            Conversion.Clamp => value < byte.MinValue ? byte.MinValue : Convert.ToByte(value),
            Conversion.Cast => (byte)value,
            Conversion.CastClamp => value < byte.MinValue ? byte.MinValue : (byte)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static byte ToByte(ushort value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToByte(value),
            Conversion.Clamp => value > byte.MaxValue ? byte.MaxValue : Convert.ToByte(value),
            Conversion.Cast => (byte)value,
            Conversion.CastClamp => value > byte.MaxValue ? byte.MaxValue : (byte)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static byte ToByte(uint value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToByte(value),
            Conversion.Clamp => value > byte.MaxValue ? byte.MaxValue : Convert.ToByte(value),
            Conversion.Cast => (byte)value,
            Conversion.CastClamp => value > byte.MaxValue ? byte.MaxValue : (byte)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static byte ToByte(ulong value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToByte(value),
            Conversion.Clamp => value > byte.MaxValue ? byte.MaxValue : Convert.ToByte(value),
            Conversion.Cast => (byte)value,
            Conversion.CastClamp => value > byte.MaxValue ? byte.MaxValue : (byte)value,
            _ => throw new InvalidOperationException(),
        };

        public static byte ToByte(short value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToByte(value),
            Conversion.Clamp => value < byte.MinValue ? byte.MinValue : value > byte.MaxValue ? byte.MaxValue : Convert.ToByte(value),
            Conversion.Cast => (byte)value,
            Conversion.CastClamp => value < byte.MinValue ? byte.MinValue : value > byte.MaxValue ? byte.MaxValue : (byte)value,
            _ => throw new InvalidOperationException(),
        };

        public static byte ToByte(int value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToByte(value),
            Conversion.Clamp => value < byte.MinValue ? byte.MinValue : value > byte.MaxValue ? byte.MaxValue : Convert.ToByte(value),
            Conversion.Cast => (byte)value,
            Conversion.CastClamp => value < byte.MinValue ? byte.MinValue : value > byte.MaxValue ? byte.MaxValue : (byte)value,
            _ => throw new InvalidOperationException(),
        };

        public static byte ToByte(long value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToByte(value),
            Conversion.Clamp => value < byte.MinValue ? byte.MinValue : value > byte.MaxValue ? byte.MaxValue : Convert.ToByte(value),
            Conversion.Cast => (byte)value,
            Conversion.CastClamp => value < byte.MinValue ? byte.MinValue : value > byte.MaxValue ? byte.MaxValue : (byte)value,
            _ => throw new InvalidOperationException(),
        };

        public static byte ToByte(float value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToByte(value),
            Conversion.Clamp => value < byte.MinValue ? byte.MinValue : value > byte.MaxValue ? byte.MaxValue : float.IsNaN(value) ? (byte)0 : Convert.ToByte(value),
            Conversion.Cast => (byte)value,
            Conversion.CastClamp => value < byte.MinValue ? byte.MinValue : value > byte.MaxValue ? byte.MaxValue : (byte)value,
            _ => throw new InvalidOperationException(),
        };

        public static byte ToByte(double value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToByte(value),
            Conversion.Clamp => value < byte.MinValue ? byte.MinValue : value > byte.MaxValue ? byte.MaxValue : double.IsNaN(value) ? (byte)0 : Convert.ToByte(value),
            Conversion.Cast => (byte)value,
            Conversion.CastClamp => value < byte.MinValue ? byte.MinValue : value > byte.MaxValue ? byte.MaxValue : (byte)value,
            _ => throw new InvalidOperationException(),
        };

        public static byte ToByte(decimal value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToByte(value),
            Conversion.Clamp => value < byte.MinValue ? byte.MinValue : value > byte.MaxValue ? byte.MaxValue : Convert.ToByte(value),
            Conversion.Cast => (byte)value,
            Conversion.CastClamp => value < byte.MinValue ? byte.MinValue : value > byte.MaxValue ? byte.MaxValue : (byte)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static short ToInt16(sbyte value, Conversion _) => value;

        [CLSCompliant(false)]
        public static short ToInt16(ushort value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt16(value),
            Conversion.Clamp => value > short.MaxValue ? short.MaxValue : Convert.ToInt16(value),
            Conversion.Cast => (short)value,
            Conversion.CastClamp => value > short.MaxValue ? short.MaxValue : (short)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static short ToInt16(uint value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt16(value),
            Conversion.Clamp => value > short.MaxValue ? short.MaxValue : Convert.ToInt16(value),
            Conversion.Cast => (short)value,
            Conversion.CastClamp => value > short.MaxValue ? short.MaxValue : (short)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static short ToInt16(ulong value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt16(value),
            Conversion.Clamp => value > (ulong)short.MaxValue ? short.MaxValue : Convert.ToInt16(value),
            Conversion.Cast => (short)value,
            Conversion.CastClamp => value > (ulong)short.MaxValue ? short.MaxValue : (short)value,
            _ => throw new InvalidOperationException(),
        };

        public static short ToInt16(byte value, Conversion _) => value;

        public static short ToInt16(int value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt16(value),
            Conversion.Clamp => value < short.MinValue ? short.MinValue : value > short.MaxValue ? short.MaxValue : Convert.ToInt16(value),
            Conversion.Cast => (short)value,
            Conversion.CastClamp => value < short.MinValue ? short.MinValue : value > short.MaxValue ? short.MaxValue : (short)value,
            _ => throw new InvalidOperationException(),
        };

        public static short ToInt16(long value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt16(value),
            Conversion.Clamp => value < short.MinValue ? short.MinValue : value > short.MaxValue ? short.MaxValue : Convert.ToInt16(value),
            Conversion.Cast => (short)value,
            Conversion.CastClamp => value < short.MinValue ? short.MinValue : value > short.MaxValue ? short.MaxValue : (short)value,
            _ => throw new InvalidOperationException(),
        };

        public static short ToInt16(float value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt16(value),
            Conversion.Clamp => value < short.MinValue ? short.MinValue : value > short.MaxValue ? short.MaxValue : float.IsNaN(value) ? (short)0 : Convert.ToInt16(value),
            Conversion.Cast => (short)value,
            Conversion.CastClamp => value < short.MinValue ? short.MinValue : value > short.MaxValue ? short.MaxValue : (short)value,
            _ => throw new InvalidOperationException(),
        };

        public static short ToInt16(double value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt16(value),
            Conversion.Clamp => value < short.MinValue ? short.MinValue : value > short.MaxValue ? short.MaxValue : double.IsNaN(value) ? (short)0 : Convert.ToInt16(value),
            Conversion.Cast => (short)value,
            Conversion.CastClamp => value < short.MinValue ? short.MinValue : value > short.MaxValue ? short.MaxValue : (short)value,
            _ => throw new InvalidOperationException(),
        };

        public static short ToInt16(decimal value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt16(value),
            Conversion.Clamp => value < short.MinValue ? short.MinValue : value > short.MaxValue ? short.MaxValue : Convert.ToInt16(value),
            Conversion.Cast => (short)value,
            Conversion.CastClamp => value < short.MinValue ? short.MinValue : value > short.MaxValue ? short.MaxValue : (short)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static int ToInt32(sbyte value, Conversion _) => value;

        [CLSCompliant(false)]
        public static int ToInt32(ushort value, Conversion _) => value;

        [CLSCompliant(false)]
        public static int ToInt32(uint value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt32(value),
            Conversion.Clamp => value > int.MaxValue ? int.MaxValue : Convert.ToInt32(value),
            Conversion.Cast => (int)value,
            Conversion.CastClamp => value > int.MaxValue ? int.MaxValue : (int)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static int ToInt32(ulong value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt32(value),
            Conversion.Clamp => value > int.MaxValue ? int.MaxValue : Convert.ToInt32(value),
            Conversion.Cast => (int)value,
            Conversion.CastClamp => value > int.MaxValue ? int.MaxValue : (int)value,
            _ => throw new InvalidOperationException(),
        };

        public static int ToInt32(byte value, Conversion _) => value;

        public static int ToInt32(short value, Conversion _) => value;

        public static int ToInt32(long value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt32(value),
            Conversion.Clamp => value < int.MinValue ? int.MinValue : value > int.MaxValue ? int.MaxValue : Convert.ToInt32(value),
            Conversion.Cast => (int)value,
            Conversion.CastClamp => value < int.MinValue ? int.MinValue : value > int.MaxValue ? int.MaxValue : (int)value,
            _ => throw new InvalidOperationException(),
        };

        public static int ToInt32(float value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt32(value),
            Conversion.Clamp => value < int.MinValue ? int.MinValue : value > int.MaxValue ? int.MaxValue : float.IsNaN(value) ? 0 : Convert.ToInt32(value),
            Conversion.Cast => (int)value,
            Conversion.CastClamp => value < int.MinValue ? int.MinValue : value > int.MaxValue ? int.MaxValue : (int)value,
            _ => throw new InvalidOperationException(),
        };

        public static int ToInt32(double value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt32(value),
            Conversion.Clamp => value < int.MinValue ? int.MinValue : value > int.MaxValue ? int.MaxValue : double.IsNaN(value) ? 0 : Convert.ToInt32(value),
            Conversion.Cast => (int)value,
            Conversion.CastClamp => value < int.MinValue ? int.MinValue : value > int.MaxValue ? int.MaxValue : (int)value,
            _ => throw new InvalidOperationException(),
        };

        public static int ToInt32(decimal value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt32(value),
            Conversion.Clamp => value < int.MinValue ? int.MinValue : value > int.MaxValue ? int.MaxValue : Convert.ToInt32(value),
            Conversion.Cast => (int)value,
            Conversion.CastClamp => value < int.MinValue ? int.MinValue : value > int.MaxValue ? int.MaxValue : (int)value,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static long ToInt64(sbyte value, Conversion _) => value;

        [CLSCompliant(false)]
        public static long ToInt64(ushort value, Conversion _) => value;

        [CLSCompliant(false)]
        public static long ToInt64(uint value, Conversion _) => value;

        [CLSCompliant(false)]
        public static long ToInt64(ulong value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt64(value),
            Conversion.Clamp => value > long.MaxValue ? long.MaxValue : Convert.ToInt64(value),
            Conversion.Cast => (long)value,
            Conversion.CastClamp => value > long.MaxValue ? long.MaxValue : (long)value,
            _ => throw new InvalidOperationException(),
        };

        public static long ToInt64(byte value, Conversion _) => value;

        public static long ToInt64(short value, Conversion _) => value;

        public static long ToInt64(int value, Conversion _) => value;

        public static long ToInt64(float value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt64(value),
            Conversion.Clamp => value < long.MinValue ? long.MinValue : value > long.MaxValue ? long.MaxValue : float.IsNaN(value) ? 0 : Convert.ToInt64(value),
            Conversion.Cast => (long)value,
            Conversion.CastClamp => value < long.MinValue ? long.MinValue : value > long.MaxValue ? long.MaxValue : (long)value,
            _ => throw new InvalidOperationException(),
        };

        public static long ToInt64(double value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt64(value),
            Conversion.Clamp => value < long.MinValue ? long.MinValue : value > long.MaxValue ? long.MaxValue : double.IsNaN(value) ? 0 : Convert.ToInt64(value),
            Conversion.Cast => (long)value,
            Conversion.CastClamp => value < long.MinValue ? long.MinValue : value > long.MaxValue ? long.MaxValue : (long)value,
            _ => throw new InvalidOperationException(),
        };

        public static long ToInt64(decimal value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToInt64(value),
            Conversion.Clamp => value < long.MinValue ? long.MinValue : value > long.MaxValue ? long.MaxValue : Convert.ToInt64(value),
            Conversion.Cast => (long)value,
            Conversion.CastClamp => value < long.MinValue ? long.MinValue : value > long.MaxValue ? long.MaxValue : (long)value,
            _ => throw new InvalidOperationException(),
        };



        [CLSCompliant(false)]
        public static float ToSingle(sbyte value, Conversion _) => value;

        [CLSCompliant(false)]
        public static float ToSingle(ushort value, Conversion _) => value;

        [CLSCompliant(false)]
        public static float ToSingle(uint value, Conversion _) => value;

        [CLSCompliant(false)]
        public static float ToSingle(ulong value, Conversion _) => value;

        public static float ToSingle(byte value, Conversion _) => value;

        public static float ToSingle(short value, Conversion _) => value;

        public static float ToSingle(int value, Conversion _) => value;

        public static float ToSingle(long value, Conversion _) => value;

        public static float ToSingle(double value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToSingle(value),
            Conversion.Clamp => value < float.MinValue ? float.MinValue : value > float.MaxValue ? float.MaxValue : double.IsNaN(value) ? 0 : Convert.ToSingle(value),
            Conversion.Cast => (float)value,
            Conversion.CastClamp => value < float.MinValue ? float.MinValue : value > float.MaxValue ? float.MaxValue : (float)value,
            _ => throw new InvalidOperationException(),
        };

        public static float ToSingle(decimal value, Conversion mode)
        {
            switch (mode)
            {
                case Conversion.Default: return Convert.ToSingle(value);

                case Conversion.Clamp: { try { checked { return Convert.ToSingle(value); } } catch (OverflowException) { return value > 0 ? float.MaxValue : value < 0 ? float.MinValue : 0; } }

                case Conversion.Cast: return (float)value;

                case Conversion.CastClamp: { try { checked { return (float)value; } } catch (OverflowException) { return value > 0 ? float.MaxValue : value < 0 ? float.MinValue : 0; } }

                default: throw new InvalidOperationException();
            }
        }

        [CLSCompliant(false)]
        public static double ToDouble(sbyte value, Conversion _) => value;

        [CLSCompliant(false)]
        public static double ToDouble(ushort value, Conversion _) => value;

        [CLSCompliant(false)]
        public static double ToDouble(uint value, Conversion _) => value;

        [CLSCompliant(false)]
        public static double ToDouble(ulong value, Conversion _) => value;

        public static double ToDouble(byte value, Conversion _) => value;

        public static double ToDouble(short value, Conversion _) => value;

        public static double ToDouble(int value, Conversion _) => value;

        public static double ToDouble(long value, Conversion _) => value;

        public static double ToDouble(float value, Conversion mode) => mode switch
        {
            Conversion.Default => Convert.ToDouble(value),
            Conversion.Clamp => value < double.MinValue ? double.MinValue : value > double.MaxValue ? double.MaxValue : double.IsNaN(value) ? 0 : Convert.ToDouble(value),
            Conversion.Cast => (double)value,
            Conversion.CastClamp => value < double.MinValue ? double.MinValue : value > double.MaxValue ? double.MaxValue : (double)value,
            _ => throw new InvalidOperationException(),
        };

        public static double ToDouble(decimal value, Conversion mode)
        {
            switch (mode)
            {
                case Conversion.Default: return Convert.ToDouble(value);

                case Conversion.Clamp: { try { checked { return Convert.ToDouble(value); } } catch (OverflowException) { return value > 0 ? double.MaxValue : value < 0 ? double.MinValue : 0; } }

                case Conversion.Cast: return (double)value;

                case Conversion.CastClamp: { try { checked { return (double)value; } } catch (OverflowException) { return value > 0 ? double.MaxValue : value < 0 ? double.MinValue : 0; } }

                default: throw new InvalidOperationException();
            }
        }

        [CLSCompliant(false)]
        public static decimal ToDecimal(sbyte value, Conversion _) => value;

        [CLSCompliant(false)]
        public static decimal ToDecimal(ushort value, Conversion _) => value;

        [CLSCompliant(false)]
        public static decimal ToDecimal(uint value, Conversion _) => value;

        [CLSCompliant(false)]
        public static decimal ToDecimal(ulong value, Conversion _) => value;

        public static decimal ToDecimal(byte value, Conversion _) => value;

        public static decimal ToDecimal(short value, Conversion _) => value;

        public static decimal ToDecimal(int value, Conversion _) => value;

        public static decimal ToDecimal(long value, Conversion _) => value;

        public static decimal ToDecimal(float value, Conversion mode)
        {
            switch (mode)
            {
                case Conversion.Default: return Convert.ToDecimal(value);

                case Conversion.Clamp: { try { checked { return Convert.ToDecimal(value); } } catch (OverflowException) { return value > 0 ? decimal.MaxValue : value < 0 ? decimal.MinValue : 0; } }

                case Conversion.Cast: return (decimal)value;

                case Conversion.CastClamp: { try { checked { return (decimal)value; } } catch (OverflowException) { return value > 0 ? decimal.MaxValue : value < 0 ? decimal.MinValue : 0; } }

                default: throw new InvalidOperationException();
            }
        }

        public static decimal ToDecimal(double value, Conversion mode)
        {
            switch (mode)
            {
                case Conversion.Default: return Convert.ToDecimal(value);

                case Conversion.Clamp: { try { checked { return Convert.ToDecimal(value); } } catch (OverflowException) { return value > 0 ? decimal.MaxValue : value < 0 ? decimal.MinValue : 0; } }

                case Conversion.Cast: return (decimal)value;

                case Conversion.CastClamp: { try { checked { return (decimal)value; } } catch (OverflowException) { return value > 0 ? decimal.MaxValue : value < 0 ? decimal.MinValue : 0; } }

                default: throw new InvalidOperationException();
            }
        }

        public static N ToNumeric<N>(byte value) where N : struct, INumeric<N>
        {
            try { checked { return ConvertN.ToNumeric<N>(value); } }
            catch (OverflowException) { return Numeric<N>.MaxValue; }
        }

        public static N ToNumeric<N>(short value) where N : struct, INumeric<N>
        {
            try { checked { return ConvertN.ToNumeric<N>(value); } }
            catch (OverflowException) { return value < 0 ? Numeric<N>.MinValue : Numeric<N>.MaxValue; }
        }

        public static N ToNumeric<N>(int value) where N : struct, INumeric<N>
        {
            try { checked { return ConvertN.ToNumeric<N>(value); } }
            catch (OverflowException) { return value < 0 ? Numeric<N>.MinValue : Numeric<N>.MaxValue; }
        }

        public static N ToNumeric<N>(long value) where N : struct, INumeric<N>
        {
            try { checked { return ConvertN.ToNumeric<N>(value); } }
            catch (OverflowException) { return value < 0 ? Numeric<N>.MinValue : Numeric<N>.MaxValue; }
        }

        public static N ToNumeric<N>(float value) where N : struct, INumeric<N>
        {
            if (float.IsPositiveInfinity(value)) return Numeric<N>.MaxValue;
            if (float.IsNegativeInfinity(value)) return Numeric<N>.MinValue;
            if (float.IsNaN(value)) return Numeric<N>.Zero;

            try { checked { return ConvertN.ToNumeric<N>(value); } }
            catch (OverflowException)
            {
                if (value < 0 && Numeric<N>.IsUnsigned) return Numeric<N>.MinValue;
                if (value < -1) return Numeric<N>.MinValue;
                if (value > 1) return Numeric<N>.MaxValue;
                if (value < 0) return Numeric<N>.Epsilon.Negative();
                return Numeric<N>.Epsilon;
            }
        }

        public static N ToNumeric<N>(double value) where N : struct, INumeric<N>
        {
            if (double.IsPositiveInfinity(value)) return Numeric<N>.MaxValue;
            if (double.IsNegativeInfinity(value)) return Numeric<N>.MinValue;
            if (double.IsNaN(value)) return Numeric<N>.Zero;

            try { checked { return ConvertN.ToNumeric<N>(value); } }
            catch (OverflowException)
            {
                if (value < 0 && Numeric<N>.IsUnsigned) return Numeric<N>.MinValue;
                if (value < -1) return Numeric<N>.MinValue;
                if (value > 1) return Numeric<N>.MaxValue;
                if (value < 0) return Numeric<N>.Epsilon.Negative();
                return Numeric<N>.Epsilon;
            }
        }

        public static N ToNumeric<N>(decimal value) where N : struct, INumeric<N>
        {
            try { checked { return ConvertN.ToNumeric<N>(value); } }
            catch (OverflowException)
            {
                if (value < 0 && Numeric<N>.IsUnsigned) return Numeric<N>.MinValue;
                if (value < -1) return Numeric<N>.MinValue;
                if (value > 1) return Numeric<N>.MaxValue;
                if (value < 0) return Numeric<N>.Epsilon.Negative();
                return Numeric<N>.Epsilon;
            }
        }

        [CLSCompliant(false)]
        public static N ToNumeric<N>(sbyte value) where N : struct, INumericNonCLS<N>
        {
            try { checked { return ConvertN.ToNumeric<N>(value); } }
            catch (OverflowException) { return value < 0 ? Numeric<N>.MinValue : Numeric<N>.MaxValue; }
        }

        [CLSCompliant(false)]
        public static N ToNumeric<N>(ushort value) where N : struct, INumericNonCLS<N>
        {
            try { checked { return ConvertN.ToNumeric<N>(value); } }
            catch (OverflowException) { return Numeric<N>.MaxValue; }
        }

        [CLSCompliant(false)]
        public static N ToNumeric<N>(uint value) where N : struct, INumericNonCLS<N>
        {
            try { checked { return ConvertN.ToNumeric<N>(value); } }
            catch (OverflowException) { return Numeric<N>.MaxValue; }
        }

        [CLSCompliant(false)]
        public static N ToNumeric<N>(ulong value) where N : struct, INumericNonCLS<N>
        {
            try { checked { return ConvertN.ToNumeric<N>(value); } }
            catch (OverflowException) { return Numeric<N>.MaxValue; }
        }
    }
}
