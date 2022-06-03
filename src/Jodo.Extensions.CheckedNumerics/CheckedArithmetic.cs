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
using System.Numerics;

namespace Jodo.Extensions.CheckedNumerics
{
    [SuppressMessage("csharpsquid", "S3358")]
    public static class CheckedArithmetic
    {
        public static byte Add(byte x, byte y) { try { checked { return (byte)(x + y); } } catch (OverflowException) { return byte.MaxValue; } }
        public static int Add(int x, int y) { try { checked { return x + y; } } catch (OverflowException) { return y > 0 ? int.MaxValue : int.MinValue; } }
        public static decimal Add(decimal x, decimal y) { try { checked { return x + y; } } catch (OverflowException) { return y > 0 ? decimal.MaxValue : decimal.MinValue; } }
        public static long Add(long x, long y) { try { checked { return x + y; } } catch (OverflowException) { return y > 0 ? long.MaxValue : long.MinValue; } }
        public static sbyte Add(sbyte x, sbyte y) { try { checked { return (sbyte)(x + y); } } catch (OverflowException) { return y > 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        public static short Add(short x, short y) { try { checked { return (short)(x + y); } } catch (OverflowException) { return y > 0 ? short.MaxValue : short.MinValue; } }
        public static uint Add(uint x, uint y) { try { checked { return x + y; } } catch (OverflowException) { return uint.MaxValue; } }
        public static ulong Add(ulong x, ulong y) { try { checked { return x + y; } } catch (OverflowException) { return ulong.MaxValue; } }
        public static ushort Add(ushort x, ushort y) { try { checked { return (ushort)(x + y); } } catch (OverflowException) { return ushort.MaxValue; } }

        public static float Add(float x, float y)
        {
            float result = x + y;
            if (float.IsNaN(result)) return 0f;
            if (float.IsPositiveInfinity(result)) return float.MaxValue;
            if (float.IsNegativeInfinity(result)) return float.MinValue;
            return result;
        }

        public static double Add(double x, double y)
        {
            double result = x + y;
            if (double.IsNaN(result)) return 0f;
            if (double.IsPositiveInfinity(result)) return double.MaxValue;
            if (double.IsNegativeInfinity(result)) return double.MinValue;
            return result;
        }

        public static byte Divide(byte x, byte y) { try { return (byte)(x / y); } catch (DivideByZeroException) { return byte.MaxValue; } }
        public static int Divide(int x, int y) { try { return x / y; } catch (DivideByZeroException) { return int.MaxValue; } }
        public static decimal Divide(decimal x, decimal y) { try { return x / y; } catch (DivideByZeroException) { return decimal.MaxValue; } }
        public static long Divide(long x, long y) { try { return x / y; } catch (DivideByZeroException) { return long.MaxValue; } }
        public static sbyte Divide(sbyte x, sbyte y) { try { return (sbyte)(x / y); } catch (DivideByZeroException) { return sbyte.MaxValue; } }
        public static short Divide(short x, short y) { try { return (short)(x / y); } catch (DivideByZeroException) { return short.MaxValue; } }
        public static uint Divide(uint x, uint y) { try { return x / y; } catch (DivideByZeroException) { return uint.MaxValue; } }
        public static ulong Divide(ulong x, ulong y) { try { return x / y; } catch (DivideByZeroException) { return ulong.MaxValue; } }
        public static ushort Divide(ushort x, ushort y) { try { return (ushort)(x / y); } catch (DivideByZeroException) { return ushort.MaxValue; } }

        public static float Divide(float x, float y)
        {
            float result = x / y;
            if (double.IsNaN(result)) return 0f;
            if (float.IsPositiveInfinity(result)) return float.MaxValue;
            if (float.IsNegativeInfinity(result)) return float.MaxValue;
            return result;
        }

        public static double Divide(double x, double y)
        {
            double result = x / y;
            if (double.IsNaN(result)) return 0d;
            if (double.IsPositiveInfinity(result)) return double.MaxValue;
            if (double.IsNegativeInfinity(result)) return double.MaxValue;
            return result;
        }

        public static byte Multiply(byte x, byte y) { try { checked { return (byte)(x * y); } } catch (OverflowException) { return byte.MaxValue; } }
        public static int Multiply(int x, int y) { try { checked { return x * y; } } catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? int.MaxValue : int.MinValue; } }
        public static decimal Multiply(decimal x, decimal y) { try { checked { return x * y; } } catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? decimal.MaxValue : decimal.MinValue; } }
        public static long Multiply(long x, long y) { try { checked { return x * y; } } catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? long.MaxValue : long.MinValue; } }
        public static sbyte Multiply(sbyte x, sbyte y) { try { checked { return (sbyte)(x * y); } } catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? sbyte.MaxValue : sbyte.MinValue; } }
        public static short Multiply(short x, short y) { try { checked { return (short)(x * y); } } catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? short.MaxValue : short.MinValue; } }
        public static uint Multiply(uint x, uint y) { try { checked { return x * y; } } catch (OverflowException) { return uint.MaxValue; } }
        public static ulong Multiply(ulong x, ulong y) { try { checked { return x * y; } } catch (OverflowException) { return ulong.MaxValue; } }
        public static ushort Multiply(ushort x, ushort y) { try { checked { return (ushort)(x * y); } } catch (OverflowException) { return ushort.MaxValue; } }

        public static float Multiply(float x, float y)
        {
            float result = x * y;
            if (double.IsNaN(result)) return 0f;
            if (float.IsPositiveInfinity(result)) return float.MaxValue;
            if (float.IsNegativeInfinity(result)) return float.MinValue;
            return result;
        }

        public static double Multiply(double x, double y)
        {
            double result = x * y;
            if (double.IsNaN(result)) return 0d;
            if (double.IsPositiveInfinity(result)) return double.MaxValue;
            if (double.IsNegativeInfinity(result)) return double.MinValue;
            return result;
        }

        public static byte Remainder(byte x, byte y) { try { return (byte)(x % y); } catch (DivideByZeroException) { return 0; } }
        public static int Remainder(int x, int y) { try { return x % y; } catch (DivideByZeroException) { return 0; } }
        public static decimal Remainder(decimal x, decimal y) { try { return x % y; } catch (DivideByZeroException) { return 0; } }
        public static long Remainder(long x, long y) { try { return x % y; } catch (DivideByZeroException) { return 0; } }
        public static sbyte Remainder(sbyte x, sbyte y) { try { return (sbyte)(x % y); } catch (DivideByZeroException) { return 0; } }
        public static short Remainder(short x, short y) { try { return (short)(x % y); } catch (DivideByZeroException) { return 0; } }
        public static uint Remainder(uint x, uint y) { try { return x % y; } catch (DivideByZeroException) { return 0; } }
        public static ulong Remainder(ulong x, ulong y) { try { return x % y; } catch (DivideByZeroException) { return 0; } }
        public static ushort Remainder(ushort x, ushort y) { try { return (ushort)(x % y); } catch (DivideByZeroException) { return 0; } }

        public static float Remainder(float x, float y)
        {
            float result = x % y;
            if (double.IsNaN(result)) return 0f;
            if (float.IsPositiveInfinity(result)) return float.MaxValue;
            if (float.IsNegativeInfinity(result)) return float.MaxValue;
            return result;
        }

        public static double Remainder(double x, double y)
        {
            double result = x % y;
            if (double.IsNaN(result)) return 0d;
            if (double.IsPositiveInfinity(result)) return double.MaxValue;
            if (double.IsNegativeInfinity(result)) return double.MaxValue;
            return result;
        }

        public static byte Subtract(byte x, byte y) { try { checked { return (byte)(x - y); } } catch (OverflowException) { return byte.MinValue; } }
        public static int Subtract(int x, int y) { try { checked { return x - y; } } catch (OverflowException) { return y < 0 ? int.MaxValue : int.MinValue; } }
        public static decimal Subtract(decimal x, decimal y) { try { checked { return x - y; } } catch (OverflowException) { return y < 0 ? decimal.MaxValue : decimal.MinValue; } }
        public static long Subtract(long x, long y) { try { checked { return x - y; } } catch (OverflowException) { return y < 0 ? long.MaxValue : long.MinValue; } }
        public static sbyte Subtract(sbyte x, sbyte y) { try { checked { return (sbyte)(x - y); } } catch (OverflowException) { return y < 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        public static short Subtract(short x, short y) { try { checked { return (short)(x - y); } } catch (OverflowException) { return y < 0 ? short.MaxValue : short.MinValue; } }
        public static uint Subtract(uint x, uint y) { try { checked { return x - y; } } catch (OverflowException) { return uint.MinValue; } }
        public static ulong Subtract(ulong x, ulong y) { try { checked { return x - y; } } catch (OverflowException) { return ulong.MinValue; } }
        public static ushort Subtract(ushort x, ushort y) { try { checked { return (ushort)(x - y); } } catch (OverflowException) { return ushort.MinValue; } }

        public static float Subtract(float x, float y)
        {
            float result = x - y;
            if (float.IsNaN(result)) return 0f;
            if (float.IsPositiveInfinity(result)) return float.MaxValue;
            if (float.IsNegativeInfinity(result)) return float.MinValue;
            return result;
        }

        public static double Subtract(double x, double y)
        {
            double result = x - y;
            if (double.IsNaN(result)) return 0f;
            if (double.IsPositiveInfinity(result)) return double.MaxValue;
            if (double.IsNegativeInfinity(result)) return double.MinValue;
            return result;
        }

        public static byte Pow(byte x, byte y)
        {
            if (y == 0) return 1;
            if (y == 1) return x;
            var result = x;
            for (byte i = 1; i < y; i++)
            {
                try { checked { result *= x; } }
                catch (OverflowException) { return byte.MaxValue; }
            }
            return result;
        }

        public static ushort Pow(ushort x, ushort y)
        {
            if (y == 0) return 1;
            if (y == 1) return x;
            var result = x;
            for (ushort i = 1; i < y; i++)
            {
                try { checked { result *= x; } }
                catch (OverflowException) { return ushort.MaxValue; }
            }
            return result;
        }

        public static uint Pow(uint x, uint y)
        {
            if (y == 0) return 1;
            if (y == 1) return x;
            var result = x;
            for (uint i = 1; i < y; i++)
            {
                try { checked { result *= x; } }
                catch (OverflowException) { return uint.MaxValue; }
            }
            return result;
        }

        public static ulong Pow(ulong x, ulong y)
        {
            if (y == 0) return 1;
            if (y == 1) return x;
            var result = x;
            for (ulong i = 1; i < y; i++)
            {
                try { checked { result *= x; } }
                catch (OverflowException) { return ulong.MaxValue; }
            }
            return result;
        }

        public static sbyte Pow(sbyte x, sbyte y)
        {
            if (y < 0) return 0;
            if (y == 0) return 1;
            if (y == 1) return x;
            var result = x;
            for (sbyte i = 1; i < y; i++)
            {
                try { checked { result *= x; } }
                catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? sbyte.MaxValue : sbyte.MinValue; }
            }
            return result;
        }

        public static short Pow(short x, short y)
        {
            if (y < 0) return 0;
            if (y == 0) return 1;
            if (y == 1) return x;
            var result = x;
            for (short i = 1; i < y; i++)
            {
                try { checked { result *= x; } }
                catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? short.MaxValue : short.MinValue; }
            }
            return result;
        }

        public static int Pow(int x, int y)
        {
            if (y < 0) return 0;
            if (y == 0) return 1;
            if (y == 1) return x;
            var result = x;
            for (int i = 1; i < y; i++)
            {
                try { checked { result *= x; } }
                catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? int.MaxValue : int.MinValue; }
            }
            return result;
        }

        public static decimal Pow(decimal x, decimal y)
        {
            if (y < 0) return 0;
            if (y == 0) return 1;
            if (y == 1) return x;
            var result = x;
            for (int i = 1; i < y; i++)
            {
                try { checked { result *= x; } }
                catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? decimal.MaxValue : decimal.MinValue; }
            }
            return result;
        }

        public static long Pow(long x, long y)
        {
            if (y < 0) return 0;
            if (y == 0) return 1;
            if (y == 1) return x;
            var result = x;
            for (long i = 1; i < y; i++)
            {
                try { checked { result *= x; } }
                catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? long.MaxValue : long.MinValue; }
            }
            return result;
        }

        public static float Pow(float x, float y)
        {
            var result = MathF.Pow(x, y);
            if (float.IsNaN(result)) return 0f;
            if (float.IsPositiveInfinity(result)) return float.MaxValue;
            if (float.IsNegativeInfinity(result)) return float.MinValue;
            return result;
        }

        public static double Pow(double x, double y)
        {
            var result = Math.Pow(x, y);
            if (double.IsNaN(result)) return 0d;
            if (double.IsPositiveInfinity(result)) return double.MaxValue;
            if (double.IsNegativeInfinity(result)) return double.MinValue;
            return result;
        }

        public static long ScaledMultiply(long scaledLeft, long scaledRight, long scalingFactor)
        {
            var result = new BigInteger(scaledLeft) * new BigInteger(scaledRight) / scalingFactor;
            if (result < long.MinValue) return long.MinValue;
            if (result > long.MaxValue) return long.MaxValue;
            return (long)result;

        }

        public static ulong ScaledMultiply(ulong scaledLeft, ulong scaledRight, ulong scalingFactor)
        {
            var result = new BigInteger(scaledLeft) * new BigInteger(scaledRight) / scalingFactor;
            if (result < ulong.MinValue) return ulong.MinValue;
            if (result > ulong.MaxValue) return ulong.MaxValue;
            return (ulong)result;
        }

        public static long ScaledDivide(long scaledLeft, long scaledRight, long scalingFactor)
        {
            if (scaledRight == 0) return long.MaxValue;
            var result = new BigInteger(scaledLeft) * scalingFactor / new BigInteger(scaledRight);
            if (result < long.MinValue) return long.MinValue;
            if (result > long.MaxValue) return long.MaxValue;
            return (long)result;
        }

        public static ulong ScaledDivide(ulong scaledLeft, ulong scaledRight, ulong scalingFactor)
        {
            if (scaledRight == 0) return ulong.MaxValue;
            var result = new BigInteger(scaledLeft) * scalingFactor / new BigInteger(scaledRight);
            if (result < ulong.MinValue) return ulong.MinValue;
            if (result > ulong.MaxValue) return ulong.MaxValue;
            return (ulong)result;
        }
    }
}
