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
    [SuppressMessage("csharpsquid", "S3358")]
    public static class CheckedTruncate
    {
        public static byte ToByte(decimal x) { try { checked { return Convert.ToByte(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : x < 0 ? byte.MinValue : (byte)0; } }
        public static byte ToByte(double x) { try { checked { return Convert.ToByte(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : x < 0 ? byte.MinValue : (byte)0; } }
        public static byte ToByte(float x) { try { checked { return Convert.ToByte(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? byte.MaxValue : x < 0 ? byte.MinValue : (byte)0; } }

        public static char ToChar(decimal x) { try { checked { return Convert.ToChar(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? char.MaxValue : x < 0 ? char.MinValue : (char)0; } }
        public static char ToChar(double x) { try { checked { return Convert.ToChar(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? char.MaxValue : x < 0 ? char.MinValue : (char)0; } }
        public static char ToChar(float x) { try { checked { return Convert.ToChar(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? char.MaxValue : x < 0 ? char.MinValue : (char)0; } }

        public static int ToInt32(decimal x) { try { checked { return Convert.ToInt32(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? int.MaxValue : x < 0 ? int.MinValue : 0; } }
        public static int ToInt32(double x) { try { checked { return Convert.ToInt32(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? int.MaxValue : x < 0 ? int.MinValue : 0; } }
        public static int ToInt32(float x) { try { checked { return Convert.ToInt32(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? int.MaxValue : x < 0 ? int.MinValue : 0; } }

        public static long ToInt64(decimal x) { try { checked { return Convert.ToInt64(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? long.MaxValue : x < 0 ? long.MinValue : 0; } }
        public static long ToInt64(double x) { try { checked { return Convert.ToInt64(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? long.MaxValue : x < 0 ? long.MinValue : 0; } }
        public static long ToInt64(float x) { try { checked { return Convert.ToInt64(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? long.MaxValue : x < 0 ? long.MinValue : 0; } }

        public static sbyte ToSByte(decimal x) { try { checked { return Convert.ToSByte(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : x < 0 ? sbyte.MinValue : (sbyte)0; } }
        public static sbyte ToSByte(double x) { try { checked { return Convert.ToSByte(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : x < 0 ? sbyte.MinValue : (sbyte)0; } }
        public static sbyte ToSByte(float x) { try { checked { return Convert.ToSByte(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? sbyte.MaxValue : x < 0 ? sbyte.MinValue : (sbyte)0; } }

        public static short ToInt16(decimal x) { try { checked { return Convert.ToInt16(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? short.MaxValue : x < 0 ? short.MinValue : (short)0; } }
        public static short ToInt16(double x) { try { checked { return Convert.ToInt16(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? short.MaxValue : x < 0 ? short.MinValue : (short)0; } }
        public static short ToInt16(float x) { try { checked { return Convert.ToInt16(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? short.MaxValue : x < 0 ? short.MinValue : (short)0; } }

        public static uint ToUInt32(decimal x) { try { checked { return Convert.ToUInt32(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : x < 0 ? uint.MinValue : 0; } }
        public static uint ToUInt32(double x) { try { checked { return Convert.ToUInt32(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : x < 0 ? uint.MinValue : 0; } }
        public static uint ToUInt32(float x) { try { checked { return Convert.ToUInt32(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? uint.MaxValue : x < 0 ? uint.MinValue : 0; } }

        public static ulong ToUInt64(decimal x) { try { checked { return Convert.ToUInt64(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : x < 0 ? ulong.MinValue : 0; } }
        public static ulong ToUInt64(double x) { try { checked { return Convert.ToUInt64(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : x < 0 ? ulong.MinValue : 0; } }
        public static ulong ToUInt64(float x) { try { checked { return Convert.ToUInt64(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? ulong.MaxValue : x < 0 ? ulong.MinValue : 0; } }

        public static ushort ToUInt16(decimal x) { try { checked { return Convert.ToUInt16(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : x < 0 ? ushort.MinValue : (ushort)0; } }
        public static ushort ToUInt16(double x) { try { checked { return Convert.ToUInt16(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : x < 0 ? ushort.MinValue : (ushort)0; } }
        public static ushort ToUInt16(float x) { try { checked { return Convert.ToUInt16(Math.Truncate(x)); } } catch (OverflowException) { return x > 0 ? ushort.MaxValue : x < 0 ? ushort.MinValue : (ushort)0; } }


    }
}
