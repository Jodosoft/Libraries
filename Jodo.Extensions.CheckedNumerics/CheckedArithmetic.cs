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
using System.Numerics;

namespace Jodo.Extensions.CheckedNumerics
{
    public static class CheckedArithmetic
    {
        public static byte Add(byte x, byte y) { try { checked { return (byte)(x + y); } } catch (OverflowException) { return byte.MaxValue; } }
        public static byte Subtract(byte x, byte y) { try { checked { return (byte)(x - y); } } catch (OverflowException) { return byte.MinValue; } }
        public static byte Multiply(byte x, byte y) { try { checked { return (byte)(x * y); } } catch (OverflowException) { return byte.MaxValue; } }
        public static byte Divide(byte x, byte y) { try { return (byte)(x / y); } catch (DivideByZeroException) { return byte.MaxValue; } }
        public static byte Remainder(byte x, byte y) { try { return (byte)(x % y); } catch (DivideByZeroException) { return 0; } }

        public static ushort Add(ushort x, ushort y) { try { checked { return (ushort)(x + y); } } catch (OverflowException) { return ushort.MaxValue; } }
        public static ushort Subtract(ushort x, ushort y) { try { checked { return (ushort)(x - y); } } catch (OverflowException) { return ushort.MinValue; } }
        public static ushort Multiply(ushort x, ushort y) { try { checked { return (ushort)(x * y); } } catch (OverflowException) { return ushort.MaxValue; } }
        public static ushort Divide(ushort x, ushort y) { try { return (ushort)(x / y); } catch (DivideByZeroException) { return ushort.MaxValue; } }
        public static ushort Remainder(ushort x, ushort y) { try { return (ushort)(x % y); } catch (DivideByZeroException) { return 0; } }

        public static uint Add(uint x, uint y) { try { checked { return x + y; } } catch (OverflowException) { return uint.MaxValue; } }
        public static uint Subtract(uint x, uint y) { try { checked { return x - y; } } catch (OverflowException) { return uint.MinValue; } }
        public static uint Multiply(uint x, uint y) { try { checked { return x * y; } } catch (OverflowException) { return uint.MaxValue; } }
        public static uint Divide(uint x, uint y) { try { return x / y; } catch (DivideByZeroException) { return uint.MaxValue; } }
        public static uint Remainder(uint x, uint y) { try { return x % y; } catch (DivideByZeroException) { return 0; } }

        public static ulong Add(ulong x, ulong y) { try { checked { return x + y; } } catch (OverflowException) { return ulong.MaxValue; } }
        public static ulong Subtract(ulong x, ulong y) { try { checked { return x - y; } } catch (OverflowException) { return ulong.MinValue; } }
        public static ulong Multiply(ulong x, ulong y) { try { checked { return x * y; } } catch (OverflowException) { return ulong.MaxValue; } }
        public static ulong Divide(ulong x, ulong y) { try { return x / y; } catch (DivideByZeroException) { return ulong.MaxValue; } }
        public static ulong Remainder(ulong x, ulong y) { try { return x % y; } catch (DivideByZeroException) { return 0; } }

        public static sbyte Add(sbyte x, sbyte y) { try { checked { return (sbyte)(x + y); } } catch (OverflowException) { return y > 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        public static sbyte Subtract(sbyte x, sbyte y) { try { checked { return (sbyte)(x - y); } } catch (OverflowException) { return y < 0 ? sbyte.MaxValue : sbyte.MinValue; } }
        public static sbyte Multiply(sbyte x, sbyte y) { try { checked { return (sbyte)(x * y); } } catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? sbyte.MaxValue : sbyte.MinValue; } }
        public static sbyte Divide(sbyte x, sbyte y) { try { return (sbyte)(x / y); } catch (DivideByZeroException) { return sbyte.MaxValue; } }
        public static sbyte Remainder(sbyte x, sbyte y) { try { return (sbyte)(x % y); } catch (DivideByZeroException) { return 0; } }

        public static short Add(short x, short y) { try { checked { return (short)(x + y); } } catch (OverflowException) { return y > 0 ? short.MaxValue : short.MinValue; } }
        public static short Subtract(short x, short y) { try { checked { return (short)(x - y); ; } } catch (OverflowException) { return y < 0 ? short.MaxValue : short.MinValue; } }
        public static short Multiply(short x, short y) { try { checked { return (short)(x * y); ; } } catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? short.MaxValue : short.MinValue; } }
        public static short Divide(short x, short y) { try { return (short)(x / y); ; } catch (DivideByZeroException) { return short.MaxValue; } }
        public static short Remainder(short x, short y) { try { return (short)(x % y); ; } catch (DivideByZeroException) { return 0; } }

        public static int Add(int x, int y) { try { checked { return x + y; } } catch (OverflowException) { return y > 0 ? int.MaxValue : int.MinValue; } }
        public static int Subtract(int x, int y) { try { checked { return x - y; } } catch (OverflowException) { return y < 0 ? int.MaxValue : int.MinValue; } }
        public static int Multiply(int x, int y) { try { checked { return x * y; } } catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? int.MaxValue : int.MinValue; } }
        public static int Divide(int x, int y) { try { return x / y; } catch (DivideByZeroException) { return int.MaxValue; } }
        public static int Remainder(int x, int y) { try { return x % y; } catch (DivideByZeroException) { return 0; } }

        public static long Add(long x, long y) { try { checked { return x + y; } } catch (OverflowException) { return y > 0 ? long.MaxValue : long.MinValue; } }
        public static long Subtract(long x, long y) { try { checked { return x - y; } } catch (OverflowException) { return y < 0 ? long.MaxValue : long.MinValue; } }
        public static long Multiply(long x, long y) { try { checked { return x * y; } } catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? long.MaxValue : long.MinValue; } }
        public static long Divide(long x, long y) { try { return x / y; } catch (DivideByZeroException) { return long.MaxValue; } }
        public static long Remainder(long x, long y) { try { return x % y; } catch (DivideByZeroException) { return 0; } }

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

        public static float Add(in float x, in float y)
        {
            float result = x + y;
            if (float.IsNaN(result)) return 0f;
            if (float.IsPositiveInfinity(result)) return float.MaxValue;
            if (float.IsNegativeInfinity(result)) return float.MinValue;
            return result;
        }

        public static float Subtract(in float x, in float y)
        {
            float result = x - y;
            if (float.IsNaN(result)) return 0f;
            if (float.IsPositiveInfinity(result)) return float.MaxValue;
            if (float.IsNegativeInfinity(result)) return float.MinValue;
            return result;
        }

        public static float Multiply(in float x, in float y)
        {
            float result = x * y;
            if (double.IsNaN(result)) return 0f;
            if (float.IsPositiveInfinity(result)) return float.MaxValue;
            if (float.IsNegativeInfinity(result)) return float.MinValue;
            return result;
        }

        public static float Divide(in float x, in float y)
        {
            float result = x / y;
            if (double.IsNaN(result)) return 0f;
            if (float.IsPositiveInfinity(result)) return float.MaxValue;
            if (float.IsNegativeInfinity(result)) return float.MaxValue;
            return result;
        }

        public static float Remainder(in float x, in float y)
        {
            float result = x % y;
            if (double.IsNaN(result)) return 0f;
            if (float.IsPositiveInfinity(result)) return float.MaxValue;
            if (float.IsNegativeInfinity(result)) return float.MaxValue;
            return result;
        }

        public static double Add(in double x, in double y)
        {
            double result = x + y;
            if (double.IsNaN(result)) return 0f;
            if (double.IsPositiveInfinity(result)) return double.MaxValue;
            if (double.IsNegativeInfinity(result)) return double.MinValue;
            return result;
        }

        public static double Subtract(in double x, in double y)
        {
            double result = x - y;
            if (double.IsNaN(result)) return 0f;
            if (double.IsPositiveInfinity(result)) return double.MaxValue;
            if (double.IsNegativeInfinity(result)) return double.MinValue;
            return result;
        }

        public static double Multiply(in double x, in double y)
        {
            double result = x * y;
            if (double.IsNaN(result)) return 0d;
            if (double.IsPositiveInfinity(result)) return double.MaxValue;
            if (double.IsNegativeInfinity(result)) return double.MinValue;
            return result;
        }

        public static double Divide(in double x, in double y)
        {
            double result = x / y;
            if (double.IsNaN(result)) return 0d;
            if (double.IsPositiveInfinity(result)) return double.MaxValue;
            if (double.IsNegativeInfinity(result)) return double.MaxValue;
            return result;
        }

        public static double Remainder(in double x, in double y)
        {
            double result = x % y;
            if (double.IsNaN(result)) return 0d;
            if (double.IsPositiveInfinity(result)) return double.MaxValue;
            if (double.IsNegativeInfinity(result)) return double.MaxValue;
            return result;
        }

        public static long ScaledMultiply(in long left, in long right, in long scalingFactor)
        {
            try
            {
                try
                {
                    checked
                    {
                        return left * right / scalingFactor;
                    }
                }
                catch (OverflowException)
                {
                    return (long)(new BigInteger(left) * new BigInteger(right) / scalingFactor);
                }
            }
            catch (DivideByZeroException)
            {
                return long.MaxValue;
            }
        }

        public static long ScaledDivide(in long left, in long right, in long scalingFactor)
        {
            try
            {
                try
                {
                    checked
                    {
                        return left * scalingFactor / right;
                    }
                }
                catch (OverflowException)
                {
                    return (long)(new BigInteger(left) * scalingFactor / new BigInteger(right));
                }
            }
            catch (DivideByZeroException)
            {
                return long.MaxValue;
            }
        }

        public static long ScaledRemainder(in long left, in long right, in long scalingFactor)
        {
            try
            {
                try
                {
                    checked
                    {
                        return left * scalingFactor % right;
                    }
                }
                catch (OverflowException)
                {
                    return (long)(new BigInteger(left) * scalingFactor % new BigInteger(right));
                }
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
        }

        public static ulong ScaledMultiply(in ulong left, in ulong right, in ulong scalingFactor)
        {
            try
            {
                try
                {
                    checked
                    {
                        return left * right / scalingFactor;
                    }
                }
                catch (OverflowException)
                {
                    return (ulong)(new BigInteger(left) * new BigInteger(right) / scalingFactor);
                }
            }
            catch (DivideByZeroException)
            {
                return ulong.MaxValue;
            }
        }

        public static ulong ScaledDivide(in ulong left, in ulong right, in ulong scalingFactor)
        {
            try
            {
                try
                {
                    checked
                    {
                        return left * scalingFactor / right;
                    }
                }
                catch (OverflowException)
                {
                    return (ulong)(new BigInteger(left) * scalingFactor / new BigInteger(right));
                }
            }
            catch (DivideByZeroException)
            {
                return ulong.MaxValue;
            }
        }

        public static ulong ScaledRemainder(in ulong left, in ulong right, in ulong scalingFactor)
        {
            try
            {
                try
                {
                    checked
                    {
                        return left * scalingFactor % right;
                    }
                }
                catch (OverflowException)
                {
                    return (ulong)(new BigInteger(left) * scalingFactor % new BigInteger(right));
                }
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
        }
    }
}
