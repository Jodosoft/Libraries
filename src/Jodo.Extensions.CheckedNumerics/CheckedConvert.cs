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

namespace Jodo.Extensions.CheckedNumerics
{
    [SuppressMessage("csharpsquid", "S3358")]
    [SuppressMessage("csharpsquid", "S2583")] // false positives
    public static class CheckedConvert
    {
        [CLSCompliant(false)] public static bool ToBoolean(ulong x) => x != 0;
        [CLSCompliant(false)] public static bool ToBoolean(ushort x) => x != 0;
        [CLSCompliant(false)] public static bool ToBoolean(sbyte x) => x != 0;
        [CLSCompliant(false)] public static bool ToBoolean(uint x) => x != 0;
        public static bool ToBoolean(byte x) => x != 0;
        public static bool ToBoolean(char x) => x != 0;
        public static bool ToBoolean(decimal x) => x != 0;
        public static bool ToBoolean(double x) => x != 0;
        public static bool ToBoolean(float x) => x != 0;
        public static bool ToBoolean(int x) => x != 0;
        public static bool ToBoolean(long x) => x != 0;
        public static bool ToBoolean(short x) => x != 0;

        [CLSCompliant(false)] public static byte ToByte(ulong x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return byte.MaxValue; } }
        [CLSCompliant(false)] public static byte ToByte(ushort x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return byte.MaxValue; } }
        [CLSCompliant(false)] public static byte ToByte(sbyte x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : x < 0 ? byte.MinValue : (byte)0; } }
        [CLSCompliant(false)] public static byte ToByte(uint x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return byte.MaxValue; } }
        public static byte ToByte(bool x) => x ? (byte)1 : (byte)0;
        public static byte ToByte(char x) => (byte)x;
        public static byte ToByte(decimal x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : x < 0 ? byte.MinValue : (byte)0; } }
        public static byte ToByte(double x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : x < 0 ? byte.MinValue : (byte)0; } }
        public static byte ToByte(float x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : x < 0 ? byte.MinValue : (byte)0; } }
        public static byte ToByte(int x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : x < 0 ? byte.MinValue : (byte)0; } }
        public static byte ToByte(long x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : x < 0 ? byte.MinValue : (byte)0; } }
        public static byte ToByte(short x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : x < 0 ? byte.MinValue : (byte)0; } }

        [CLSCompliant(false)] public static char ToChar(ulong x) { try { checked { return Convert.ToChar(x); } } catch (OverflowException) { return x > 0 ? char.MaxValue : char.MinValue; } }
        [CLSCompliant(false)] public static char ToChar(ushort x) { try { checked { return Convert.ToChar(x); } } catch (OverflowException) { return x > 0 ? char.MaxValue : char.MinValue; } }
        [CLSCompliant(false)] public static char ToChar(sbyte x) { try { checked { return Convert.ToChar(x); } } catch (OverflowException) { return x > 0 ? char.MaxValue : char.MinValue; } }
        [CLSCompliant(false)] public static char ToChar(uint x) { try { checked { return Convert.ToChar(x); } } catch (OverflowException) { return x > 0 ? char.MaxValue : char.MinValue; } }
        public static char ToChar(bool x) => x ? (char)1 : (char)0;
        public static char ToChar(byte x) => (char)x;
        public static char ToChar(decimal x) { try { checked { return Convert.ToChar(x); } } catch (OverflowException) { return x > 0 ? char.MaxValue : char.MinValue; } }
        public static char ToChar(double x) { try { checked { return Convert.ToChar(x); } } catch (OverflowException) { return x > 0 ? char.MaxValue : char.MinValue; } }
        public static char ToChar(float x) { try { checked { return Convert.ToChar(x); } } catch (OverflowException) { return x > 0 ? char.MaxValue : char.MinValue; } }
        public static char ToChar(int x) { try { checked { return Convert.ToChar(x); } } catch (OverflowException) { return x > 0 ? char.MaxValue : char.MinValue; } }
        public static char ToChar(long x) { try { checked { return Convert.ToChar(x); } } catch (OverflowException) { return x > 0 ? char.MaxValue : char.MinValue; } }
        public static char ToChar(short x) { try { checked { return Convert.ToChar(x); } } catch (OverflowException) { return x > 0 ? char.MaxValue : char.MinValue; } }

        [CLSCompliant(false)] public static int ToInt32(ulong x) { try { checked { return Convert.ToInt32(x); } } catch (OverflowException) { return x > 0 ? int.MaxValue : int.MinValue; } }
        [CLSCompliant(false)] public static int ToInt32(ushort x) => x;
        [CLSCompliant(false)] public static int ToInt32(sbyte x) => x;
        [CLSCompliant(false)] public static int ToInt32(uint x) { try { checked { return Convert.ToInt32(x); } } catch (OverflowException) { return x > 0 ? int.MaxValue : int.MinValue; } }
        public static int ToInt32(bool x) => x ? 1 : 0;
        public static int ToInt32(byte x) => x;
        public static int ToInt32(char x) => x;
        public static int ToInt32(decimal x) { try { checked { return Convert.ToInt32(x); } } catch (OverflowException) { return x > 0 ? int.MaxValue : x < 0 ? int.MinValue : 0; } }
        public static int ToInt32(double x) { try { checked { return Convert.ToInt32(x); } } catch (OverflowException) { return x > 0 ? int.MaxValue : x < 0 ? int.MinValue : 0; } }
        public static int ToInt32(float x) { try { checked { return Convert.ToInt32(x); } } catch (OverflowException) { return x > 0 ? int.MaxValue : x < 0 ? int.MinValue : 0; } }
        public static int ToInt32(long x) { try { checked { return Convert.ToInt32(x); } } catch (OverflowException) { return x > 0 ? int.MaxValue : int.MinValue; } }
        public static int ToInt32(short x) => x;

        [CLSCompliant(false)] public static long ToInt64(ulong x) { try { checked { return Convert.ToInt64(x); } } catch (OverflowException) { return x > 0 ? long.MaxValue : long.MinValue; } }
        [CLSCompliant(false)] public static long ToInt64(ushort x) => x;
        [CLSCompliant(false)] public static long ToInt64(sbyte x) => x;
        [CLSCompliant(false)] public static long ToInt64(uint x) => x;
        public static long ToInt64(bool x) => x ? 1L : 0L;
        public static long ToInt64(byte x) => x;
        public static long ToInt64(char x) => x;
        public static long ToInt64(decimal x) { try { checked { return Convert.ToInt64(x); } } catch (OverflowException) { return x > 0 ? long.MaxValue : x < 0 ? long.MinValue : 0; } }
        public static long ToInt64(double x) { try { checked { return Convert.ToInt64(x); } } catch (OverflowException) { return x > 0 ? long.MaxValue : x < 0 ? long.MinValue : 0; } }
        public static long ToInt64(float x) { try { checked { return Convert.ToInt64(x); } } catch (OverflowException) { return x > 0 ? long.MaxValue : x < 0 ? long.MinValue : 0; } }
        public static long ToInt64(int x) => x;
        public static long ToInt64(short x) => x;

        [CLSCompliant(false)] public static sbyte ToSByte(bool x) => x ? (sbyte)1 : (sbyte)0;
        [CLSCompliant(false)] public static sbyte ToSByte(byte x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        [CLSCompliant(false)] public static sbyte ToSByte(char x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        [CLSCompliant(false)] public static sbyte ToSByte(decimal x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : x < 0 ? sbyte.MinValue : (sbyte)0; } }
        [CLSCompliant(false)] public static sbyte ToSByte(double x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : x < 0 ? sbyte.MinValue : (sbyte)0; } }
        [CLSCompliant(false)] public static sbyte ToSByte(float x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : x < 0 ? sbyte.MinValue : (sbyte)0; } }
        [CLSCompliant(false)] public static sbyte ToSByte(int x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        [CLSCompliant(false)] public static sbyte ToSByte(long x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        [CLSCompliant(false)] public static sbyte ToSByte(short x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        [CLSCompliant(false)] public static sbyte ToSByte(uint x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        [CLSCompliant(false)] public static sbyte ToSByte(ulong x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        [CLSCompliant(false)] public static sbyte ToSByte(ushort x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : sbyte.MinValue; } }

        [CLSCompliant(false)] public static short ToInt16(uint x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return short.MaxValue; } }
        [CLSCompliant(false)] public static short ToInt16(ulong x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return short.MaxValue; } }
        [CLSCompliant(false)] public static short ToInt16(ushort x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return short.MaxValue; } }
        [CLSCompliant(false)] public static short ToInt16(sbyte x) => x;
        public static short ToInt16(bool x) => x ? (short)1 : (short)0;
        public static short ToInt16(byte x) => x;
        public static short ToInt16(char x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return short.MaxValue; } }
        public static short ToInt16(decimal x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return x > 0 ? short.MaxValue : x < 0 ? short.MinValue : (short)0; } }
        public static short ToInt16(double x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return x > 0 ? short.MaxValue : x < 0 ? short.MinValue : (short)0; } }
        public static short ToInt16(float x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return x > 0 ? short.MaxValue : x < 0 ? short.MinValue : (short)0; } }
        public static short ToInt16(int x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return x > 0 ? short.MaxValue : x < 0 ? short.MinValue : (short)0; } }
        public static short ToInt16(long x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return x > 0 ? short.MaxValue : x < 0 ? short.MinValue : (short)0; } }

        [CLSCompliant(false)] public static uint ToUInt32(bool x) => x ? 1 : (uint)0;
        [CLSCompliant(false)] public static uint ToUInt32(byte x) => x;
        [CLSCompliant(false)] public static uint ToUInt32(char x) => x;
        [CLSCompliant(false)] public static uint ToUInt32(decimal x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : x < 0 ? uint.MinValue : 0; } }
        [CLSCompliant(false)] public static uint ToUInt32(double x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : x < 0 ? uint.MinValue : 0; } }
        [CLSCompliant(false)] public static uint ToUInt32(float x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : x < 0 ? uint.MinValue : 0; } }
        [CLSCompliant(false)] public static uint ToUInt32(int x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : x < 0 ? uint.MinValue : 0; } }
        [CLSCompliant(false)] public static uint ToUInt32(long x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : x < 0 ? uint.MinValue : 0; } }
        [CLSCompliant(false)] public static uint ToUInt32(sbyte x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : x < 0 ? uint.MinValue : 0; } }
        [CLSCompliant(false)] public static uint ToUInt32(short x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : x < 0 ? uint.MinValue : 0; } }
        [CLSCompliant(false)] public static uint ToUInt32(ulong x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return uint.MaxValue; } }
        [CLSCompliant(false)] public static uint ToUInt32(ushort x) => x;

        [CLSCompliant(false)] public static ulong ToUInt64(bool x) => x ? 1 : (ulong)0;
        [CLSCompliant(false)] public static ulong ToUInt64(byte x) => x;
        [CLSCompliant(false)] public static ulong ToUInt64(char x) => x;
        [CLSCompliant(false)] public static ulong ToUInt64(decimal x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : x < 0 ? ulong.MinValue : 0; } }
        [CLSCompliant(false)] public static ulong ToUInt64(double x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : x < 0 ? ulong.MinValue : 0; } }
        [CLSCompliant(false)] public static ulong ToUInt64(float x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : x < 0 ? ulong.MinValue : 0; } }
        [CLSCompliant(false)] public static ulong ToUInt64(int x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : x < 0 ? ulong.MinValue : 0; } }
        [CLSCompliant(false)] public static ulong ToUInt64(long x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : x < 0 ? ulong.MinValue : 0; } }
        [CLSCompliant(false)] public static ulong ToUInt64(sbyte x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : x < 0 ? ulong.MinValue : 0; } }
        [CLSCompliant(false)] public static ulong ToUInt64(short x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : x < 0 ? ulong.MinValue : 0; } }
        [CLSCompliant(false)] public static ulong ToUInt64(uint x) => x;
        [CLSCompliant(false)] public static ulong ToUInt64(ushort x) => x;

        [CLSCompliant(false)] public static ushort ToUInt16(bool x) => x ? (ushort)1 : (ushort)0;
        [CLSCompliant(false)] public static ushort ToUInt16(byte x) => x;
        [CLSCompliant(false)] public static ushort ToUInt16(char x) => x;
        [CLSCompliant(false)] public static ushort ToUInt16(decimal x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : x < 0 ? ushort.MinValue : (ushort)0; } }
        [CLSCompliant(false)] public static ushort ToUInt16(double x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : x < 0 ? ushort.MinValue : (ushort)0; } }
        [CLSCompliant(false)] public static ushort ToUInt16(float x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : x < 0 ? ushort.MinValue : (ushort)0; } }
        [CLSCompliant(false)] public static ushort ToUInt16(int x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : x < 0 ? ushort.MinValue : (ushort)0; } }
        [CLSCompliant(false)] public static ushort ToUInt16(long x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : x < 0 ? ushort.MinValue : (ushort)0; } }
        [CLSCompliant(false)] public static ushort ToUInt16(sbyte x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : x < 0 ? ushort.MinValue : (ushort)0; } }
        [CLSCompliant(false)] public static ushort ToUInt16(short x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : x < 0 ? ushort.MinValue : (ushort)0; } }
        [CLSCompliant(false)] public static ushort ToUInt16(uint x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return ushort.MaxValue; } }
        [CLSCompliant(false)] public static ushort ToUInt16(ulong x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return ushort.MaxValue; } }

        [CLSCompliant(false)] public static decimal ToDecimal(ulong x) => x;
        [CLSCompliant(false)] public static decimal ToDecimal(ushort x) => x;
        [CLSCompliant(false)] public static decimal ToDecimal(sbyte x) => x;
        [CLSCompliant(false)] public static decimal ToDecimal(uint x) => x;
        public static decimal ToDecimal(bool x) => x ? 1 : 0;
        public static decimal ToDecimal(byte x) => x;
        public static decimal ToDecimal(char x) => x;
        public static decimal ToDecimal(double x) { try { checked { return Convert.ToDecimal(x); } } catch (OverflowException) { return x > 0 ? decimal.MaxValue : x < 0 ? decimal.MinValue : 0; } }
        public static decimal ToDecimal(float x) { try { checked { return Convert.ToDecimal(x); } } catch (OverflowException) { return x > 0 ? decimal.MaxValue : x < 0 ? decimal.MinValue : 0; } }
        public static decimal ToDecimal(int x) => x;
        public static decimal ToDecimal(long x) => x;
        public static decimal ToDecimal(short x) => x;

        [CLSCompliant(false)] public static double ToDouble(ulong x) => x;
        [CLSCompliant(false)] public static double ToDouble(ushort x) => x;
        [CLSCompliant(false)] public static double ToDouble(sbyte x) => x;
        [CLSCompliant(false)] public static double ToDouble(uint x) => x;
        public static double ToDouble(bool x) => x ? 1 : 0;
        public static double ToDouble(byte x) => x;
        public static double ToDouble(char x) => x;
        public static double ToDouble(decimal x) { try { checked { return Convert.ToDouble(x); } } catch (OverflowException) { return x > 0 ? double.MaxValue : x < 0 ? double.MinValue : 0; } }
        public static double ToDouble(float x) => x;
        public static double ToDouble(int x) => x;
        public static double ToDouble(long x) => x;
        public static double ToDouble(short x) => x;

        [CLSCompliant(false)] public static float ToSingle(sbyte x) => x;
        [CLSCompliant(false)] public static float ToSingle(uint x) => x;
        [CLSCompliant(false)] public static float ToSingle(ulong x) => x;
        [CLSCompliant(false)] public static float ToSingle(ushort x) => x;
        public static float ToSingle(bool x) => x ? 1 : 0;
        public static float ToSingle(byte x) => x;
        public static float ToSingle(decimal x) { try { checked { return Convert.ToSingle(x); } } catch (OverflowException) { return x > 0 ? float.MaxValue : x < 0 ? float.MinValue : 0; } }
        public static float ToSingle(double x) { try { checked { return Convert.ToSingle(x); } } catch (OverflowException) { return x > 0 ? float.MaxValue : x < 0 ? float.MinValue : 0; } }
        public static float ToSingle(int x) => x;
        public static float ToSingle(long x) => x;
        public static float ToSingle(short x) => x;
    }
}
