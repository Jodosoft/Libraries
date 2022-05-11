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
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("SonarCloud", "csharpsquid:S3358")]
    public static class CheckedConvert
    {
        public static byte ToByte(decimal x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : x < 0 ? byte.MinValue : (byte)0; } }
        public static byte ToByte(double x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : x < 0 ? byte.MinValue : (byte)0; } }
        public static byte ToByte(float x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : x < 0 ? byte.MinValue : (byte)0; } }
        public static byte ToByte(int x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : byte.MinValue; } }
        public static byte ToByte(long x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : byte.MinValue; } }
        public static byte ToByte(sbyte x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : byte.MinValue; } }
        public static byte ToByte(short x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : byte.MinValue; } }
        public static byte ToByte(uint x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : byte.MinValue; } }
        public static byte ToByte(ulong x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : byte.MinValue; } }
        public static byte ToByte(ushort x) { try { checked { return Convert.ToByte(x); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : byte.MinValue; } }
        public static decimal ToDecimal(byte x) { try { checked { return Convert.ToDecimal(x); } } catch (OverflowException) { return x > 0 ? decimal.MaxValue : decimal.MinValue; } }
        public static decimal ToDecimal(double x) { try { checked { return Convert.ToDecimal(x); } } catch (OverflowException) { return x > 0 ? decimal.MaxValue : x < 0 ? decimal.MinValue : 0; } }
        public static decimal ToDecimal(float x) { try { checked { return Convert.ToDecimal(x); } } catch (OverflowException) { return x > 0 ? decimal.MaxValue : x < 0 ? decimal.MinValue : 0; } }
        public static decimal ToDecimal(int x) { try { checked { return Convert.ToDecimal(x); } } catch (OverflowException) { return x > 0 ? decimal.MaxValue : decimal.MinValue; } }
        public static decimal ToDecimal(long x) { try { checked { return Convert.ToDecimal(x); } } catch (OverflowException) { return x > 0 ? decimal.MaxValue : decimal.MinValue; } }
        public static decimal ToDecimal(sbyte x) { try { checked { return Convert.ToDecimal(x); } } catch (OverflowException) { return x > 0 ? decimal.MaxValue : decimal.MinValue; } }
        public static decimal ToDecimal(short x) { try { checked { return Convert.ToDecimal(x); } } catch (OverflowException) { return x > 0 ? decimal.MaxValue : decimal.MinValue; } }
        public static decimal ToDecimal(uint x) { try { checked { return Convert.ToDecimal(x); } } catch (OverflowException) { return x > 0 ? decimal.MaxValue : decimal.MinValue; } }
        public static decimal ToDecimal(ulong x) { try { checked { return Convert.ToDecimal(x); } } catch (OverflowException) { return x > 0 ? decimal.MaxValue : x < 0 ? decimal.MinValue : 0; } }
        public static decimal ToDecimal(ushort x) { try { checked { return Convert.ToDecimal(x); } } catch (OverflowException) { return x > 0 ? decimal.MaxValue : decimal.MinValue; } }
        public static double ToDouble(byte x) { try { checked { return Convert.ToDouble(x); } } catch (OverflowException) { return x > 0 ? double.MaxValue : double.MinValue; } }
        public static double ToDouble(decimal x) { try { checked { return Convert.ToDouble(x); } } catch (OverflowException) { return x > 0 ? double.MaxValue : x < 0 ? double.MinValue : 0; } }
        public static double ToDouble(float x) { try { checked { return Convert.ToDouble(x); } } catch (OverflowException) { return x > 0 ? double.MaxValue : x < 0 ? double.MinValue : 0; } }
        public static double ToDouble(int x) { try { checked { return Convert.ToDouble(x); } } catch (OverflowException) { return x > 0 ? double.MaxValue : double.MinValue; } }
        public static double ToDouble(long x) { try { checked { return Convert.ToDouble(x); } } catch (OverflowException) { return x > 0 ? double.MaxValue : double.MinValue; } }
        public static double ToDouble(sbyte x) { try { checked { return Convert.ToDouble(x); } } catch (OverflowException) { return x > 0 ? double.MaxValue : double.MinValue; } }
        public static double ToDouble(short x) { try { checked { return Convert.ToDouble(x); } } catch (OverflowException) { return x > 0 ? double.MaxValue : double.MinValue; } }
        public static double ToDouble(uint x) { try { checked { return Convert.ToDouble(x); } } catch (OverflowException) { return x > 0 ? double.MaxValue : double.MinValue; } }
        public static double ToDouble(ulong x) { try { checked { return Convert.ToDouble(x); } } catch (OverflowException) { return x > 0 ? double.MaxValue : x < 0 ? double.MinValue : 0; } }
        public static double ToDouble(ushort x) { try { checked { return Convert.ToDouble(x); } } catch (OverflowException) { return x > 0 ? double.MaxValue : double.MinValue; } }
        public static float ToSingle(byte x) { try { checked { return Convert.ToSingle(x); } } catch (OverflowException) { return x > 0 ? float.MaxValue : float.MinValue; } }
        public static float ToSingle(decimal x) { try { checked { return Convert.ToSingle(x); } } catch (OverflowException) { return x > 0 ? float.MaxValue : x < 0 ? float.MinValue : 0; } }
        public static float ToSingle(double x) { try { checked { return Convert.ToSingle(x); } } catch (OverflowException) { return x > 0 ? float.MaxValue : x < 0 ? float.MinValue : 0; } }
        public static float ToSingle(int x) { try { checked { return Convert.ToSingle(x); } } catch (OverflowException) { return x > 0 ? float.MaxValue : float.MinValue; } }
        public static float ToSingle(long x) { try { checked { return Convert.ToSingle(x); } } catch (OverflowException) { return x > 0 ? float.MaxValue : float.MinValue; } }
        public static float ToSingle(sbyte x) { try { checked { return Convert.ToSingle(x); } } catch (OverflowException) { return x > 0 ? float.MaxValue : float.MinValue; } }
        public static float ToSingle(short x) { try { checked { return Convert.ToSingle(x); } } catch (OverflowException) { return x > 0 ? float.MaxValue : float.MinValue; } }
        public static float ToSingle(uint x) { try { checked { return Convert.ToSingle(x); } } catch (OverflowException) { return x > 0 ? float.MaxValue : float.MinValue; } }
        public static float ToSingle(ulong x) { try { checked { return Convert.ToSingle(x); } } catch (OverflowException) { return x > 0 ? float.MaxValue : x < 0 ? float.MinValue : 0; } }
        public static float ToSingle(ushort x) { try { checked { return Convert.ToSingle(x); } } catch (OverflowException) { return x > 0 ? float.MaxValue : float.MinValue; } }
        public static int ToInt32(byte x) { try { checked { return Convert.ToInt32(x); } } catch (OverflowException) { return x > 0 ? int.MaxValue : int.MinValue; } }
        public static int ToInt32(decimal x) { try { checked { return Convert.ToInt32(x); } } catch (OverflowException) { return x > 0 ? int.MaxValue : x < 0 ? int.MinValue : 0; } }
        public static int ToInt32(double x) { try { checked { return Convert.ToInt32(x); } } catch (OverflowException) { return x > 0 ? int.MaxValue : x < 0 ? int.MinValue : 0; } }
        public static int ToInt32(float x) { try { checked { return Convert.ToInt32(x); } } catch (OverflowException) { return x > 0 ? int.MaxValue : x < 0 ? int.MinValue : 0; } }
        public static int ToInt32(long x) { try { checked { return Convert.ToInt32(x); } } catch (OverflowException) { return x > 0 ? int.MaxValue : int.MinValue; } }
        public static int ToInt32(sbyte x) { try { checked { return Convert.ToInt32(x); } } catch (OverflowException) { return x > 0 ? int.MaxValue : int.MinValue; } }
        public static int ToInt32(short x) { try { checked { return Convert.ToInt32(x); } } catch (OverflowException) { return x > 0 ? int.MaxValue : int.MinValue; } }
        public static int ToInt32(uint x) { try { checked { return Convert.ToInt32(x); } } catch (OverflowException) { return x > 0 ? int.MaxValue : int.MinValue; } }
        public static int ToInt32(ulong x) { try { checked { return Convert.ToInt32(x); } } catch (OverflowException) { return x > 0 ? int.MaxValue : int.MinValue; } }
        public static int ToInt32(ushort x) { try { checked { return Convert.ToInt32(x); } } catch (OverflowException) { return x > 0 ? int.MaxValue : int.MinValue; } }
        public static long ToInt64(byte x) { try { checked { return Convert.ToInt64(x); } } catch (OverflowException) { return x > 0 ? long.MaxValue : long.MinValue; } }
        public static long ToInt64(decimal x) { try { checked { return Convert.ToInt64(x); } } catch (OverflowException) { return x > 0 ? long.MaxValue : x < 0 ? long.MinValue : 0; } }
        public static long ToInt64(double x) { try { checked { return Convert.ToInt64(x); } } catch (OverflowException) { return x > 0 ? long.MaxValue : x < 0 ? long.MinValue : 0; } }
        public static long ToInt64(float x) { try { checked { return Convert.ToInt64(x); } } catch (OverflowException) { return x > 0 ? long.MaxValue : x < 0 ? long.MinValue : 0; } }
        public static long ToInt64(int x) { try { checked { return Convert.ToInt64(x); } } catch (OverflowException) { return x > 0 ? long.MaxValue : long.MinValue; } }
        public static long ToInt64(sbyte x) { try { checked { return Convert.ToInt64(x); } } catch (OverflowException) { return x > 0 ? long.MaxValue : long.MinValue; } }
        public static long ToInt64(short x) { try { checked { return Convert.ToInt64(x); } } catch (OverflowException) { return x > 0 ? long.MaxValue : long.MinValue; } }
        public static long ToInt64(uint x) { try { checked { return Convert.ToInt64(x); } } catch (OverflowException) { return x > 0 ? long.MaxValue : long.MinValue; } }
        public static long ToInt64(ulong x) { try { checked { return Convert.ToInt64(x); } } catch (OverflowException) { return x > 0 ? long.MaxValue : long.MinValue; } }
        public static long ToInt64(ushort x) { try { checked { return Convert.ToInt64(x); } } catch (OverflowException) { return x > 0 ? long.MaxValue : long.MinValue; } }
        public static sbyte ToSByte(byte x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        public static sbyte ToSByte(decimal x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : x < 0 ? sbyte.MinValue : (sbyte)0; } }
        public static sbyte ToSByte(double x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : x < 0 ? sbyte.MinValue : (sbyte)0; } }
        public static sbyte ToSByte(float x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : x < 0 ? sbyte.MinValue : (sbyte)0; } }
        public static sbyte ToSByte(int x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        public static sbyte ToSByte(long x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        public static sbyte ToSByte(short x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        public static sbyte ToSByte(uint x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        public static sbyte ToSByte(ulong x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        public static sbyte ToSByte(ushort x) { try { checked { return Convert.ToSByte(x); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        public static short ToInt16(byte x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return x > 0 ? short.MaxValue : short.MinValue; } }
        public static short ToInt16(decimal x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return x > 0 ? short.MaxValue : x < 0 ? short.MinValue : (short)0; } }
        public static short ToInt16(double x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return x > 0 ? short.MaxValue : x < 0 ? short.MinValue : (short)0; } }
        public static short ToInt16(float x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return x > 0 ? short.MaxValue : x < 0 ? short.MinValue : (short)0; } }
        public static short ToInt16(int x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return x > 0 ? short.MaxValue : short.MinValue; } }
        public static short ToInt16(long x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return x > 0 ? short.MaxValue : short.MinValue; } }
        public static short ToInt16(sbyte x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return x > 0 ? short.MaxValue : short.MinValue; } }
        public static short ToInt16(uint x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return x > 0 ? short.MaxValue : short.MinValue; } }
        public static short ToInt16(ulong x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return x > 0 ? short.MaxValue : short.MinValue; } }
        public static short ToInt16(ushort x) { try { checked { return Convert.ToInt16(x); } } catch (OverflowException) { return x > 0 ? short.MaxValue : short.MinValue; } }
        public static uint ToUInt32(byte x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : uint.MinValue; } }
        public static uint ToUInt32(decimal x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : x < 0 ? uint.MinValue : 0; } }
        public static uint ToUInt32(double x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : x < 0 ? uint.MinValue : 0; } }
        public static uint ToUInt32(float x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : x < 0 ? uint.MinValue : 0; } }
        public static uint ToUInt32(int x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : uint.MinValue; } }
        public static uint ToUInt32(long x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : uint.MinValue; } }
        public static uint ToUInt32(sbyte x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : uint.MinValue; } }
        public static uint ToUInt32(short x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : uint.MinValue; } }
        public static uint ToUInt32(ulong x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : uint.MinValue; } }
        public static uint ToUInt32(ushort x) { try { checked { return Convert.ToUInt32(x); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : uint.MinValue; } }
        public static ulong ToUInt64(byte x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : ulong.MinValue; } }
        public static ulong ToUInt64(decimal x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : x < 0 ? ulong.MinValue : 0; } }
        public static ulong ToUInt64(double x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : x < 0 ? ulong.MinValue : 0; } }
        public static ulong ToUInt64(float x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : x < 0 ? ulong.MinValue : 0; } }
        public static ulong ToUInt64(int x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : ulong.MinValue; } }
        public static ulong ToUInt64(long x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : ulong.MinValue; } }
        public static ulong ToUInt64(sbyte x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : ulong.MinValue; } }
        public static ulong ToUInt64(short x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : ulong.MinValue; } }
        public static ulong ToUInt64(uint x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : ulong.MinValue; } }
        public static ulong ToUInt64(ushort x) { try { checked { return Convert.ToUInt64(x); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : ulong.MinValue; } }
        public static ushort ToUInt16(byte x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : ushort.MinValue; } }
        public static ushort ToUInt16(decimal x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : x < 0 ? ushort.MinValue : (ushort)0; } }
        public static ushort ToUInt16(double x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : x < 0 ? ushort.MinValue : (ushort)0; } }
        public static ushort ToUInt16(float x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : x < 0 ? ushort.MinValue : (ushort)0; } }
        public static ushort ToUInt16(int x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : ushort.MinValue; } }
        public static ushort ToUInt16(long x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : ushort.MinValue; } }
        public static ushort ToUInt16(sbyte x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : ushort.MinValue; } }
        public static ushort ToUInt16(short x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : ushort.MinValue; } }
        public static ushort ToUInt16(uint x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : ushort.MinValue; } }
        public static ushort ToUInt16(ulong x) { try { checked { return Convert.ToUInt16(x); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : ushort.MinValue; } }
    }
}
