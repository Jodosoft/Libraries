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

namespace Jodo.Extensions.CheckedNumerics
{
    public static class CheckedMath
    {
        private const float DegreesPerRadianF = 180 / MathF.PI;
        private const float DegreesPerTurnF = 360;
        private const float TurnsPerDegreeF = 1 / DegreesPerTurnF;
        private const float TurnsPerRadianF = 1 / RadiansPerTurnF;
        private const float RadiansPerDegreeF = MathF.PI / 180;
        private const float RadiansPerTurnF = 2 * MathF.PI;

        private const double DegreesPerRadian = 180 / Math.PI;
        private const double DegreesPerTurn = 360;
        private const double TurnsPerDegree = 1 / DegreesPerTurn;
        private const double TurnsPerRadian = 1 / RadiansPerTurn;
        private const double RadiansPerDegree = Math.PI / 180;
        private const double RadiansPerTurn = 2 * Math.PI;

        internal static float DegreesToRadians(float degrees) => degrees * RadiansPerDegreeF;
        internal static float DegreesToTurns(float degrees) => degrees * TurnsPerDegreeF;
        internal static float RadiansToDegrees(float radians) => radians * DegreesPerRadianF;
        internal static float RadiansToTurns(float radians) => radians * TurnsPerRadianF;
        internal static float TurnsToDegrees(float turns) => turns * DegreesPerTurnF;
        internal static float TurnsToRadians(float turns) => turns * RadiansPerTurnF;
        internal static double DegreesToRadians(double degrees) => degrees * RadiansPerDegree;
        internal static double DegreesToTurns(double degrees) => degrees * TurnsPerDegree;
        internal static double RadiansToDegrees(double radians) => radians * DegreesPerRadian;
        internal static double RadiansToTurns(double radians) => radians * TurnsPerRadian;
        internal static double TurnsToDegrees(double turns) => turns * DegreesPerTurn;
        internal static double TurnsToRadians(double turns) => turns * RadiansPerTurn;

        public static byte Add(byte x, byte y) { try { checked { return (byte)(x + y); } } catch (OverflowException) { return byte.MaxValue; } }
        public static byte Subtract(byte x, byte y) { try { checked { return (byte)(x - y); } } catch (OverflowException) { return byte.MinValue; } }
        public static byte Multiply(byte x, byte y) { try { checked { return (byte)(x * y); } } catch (OverflowException) { return byte.MaxValue; } }
        public static byte Divide(byte x, byte y) { try { return (byte)(x / y); } catch (DivideByZeroException) { return byte.MaxValue; } }
        public static byte Remainder(byte x, byte y) { try { return (byte)(x % y); } catch (DivideByZeroException) { return byte.MaxValue; } }

        public static ushort Add(ushort x, ushort y) { try { checked { return (ushort)(x + y); } } catch (OverflowException) { return ushort.MaxValue; } }
        public static ushort Subtract(ushort x, ushort y) { try { checked { return (ushort)(x - y); } } catch (OverflowException) { return ushort.MinValue; } }
        public static ushort Multiply(ushort x, ushort y) { try { checked { return (ushort)(x * y); } } catch (OverflowException) { return ushort.MaxValue; } }
        public static ushort Divide(ushort x, ushort y) { try { return (ushort)(x / y); } catch (DivideByZeroException) { return ushort.MaxValue; } }
        public static ushort Remainder(ushort x, ushort y) { try { return (ushort)(x % y); } catch (DivideByZeroException) { return ushort.MaxValue; } }

        public static uint Add(uint x, uint y) { try { checked { return x + y; } } catch (OverflowException) { return uint.MaxValue; } }
        public static uint Subtract(uint x, uint y) { try { checked { return x - y; } } catch (OverflowException) { return uint.MinValue; } }
        public static uint Multiply(uint x, uint y) { try { checked { return x * y; } } catch (OverflowException) { return uint.MaxValue; } }
        public static uint Divide(uint x, uint y) { try { return x / y; } catch (DivideByZeroException) { return uint.MaxValue; } }
        public static uint Remainder(uint x, uint y) { try { return x % y; } catch (DivideByZeroException) { return uint.MaxValue; } }

        public static ulong Add(ulong x, ulong y) { try { checked { return x + y; } } catch (OverflowException) { return ulong.MaxValue; } }
        public static ulong Subtract(ulong x, ulong y) { try { checked { return x - y; } } catch (OverflowException) { return ulong.MinValue; } }
        public static ulong Multiply(ulong x, ulong y) { try { checked { return x * y; } } catch (OverflowException) { return ulong.MaxValue; } }
        public static ulong Divide(ulong x, ulong y) { try { return x / y; } catch (DivideByZeroException) { return ulong.MaxValue; } }
        public static ulong Remainder(ulong x, ulong y) { try { return x % y; } catch (DivideByZeroException) { return ulong.MaxValue; } }

        public static short Add(short x, short y) { try { checked { return (short)(x + y); } } catch (OverflowException) { return y > 0 ? short.MaxValue : short.MinValue; } }
        public static short Subtract(short x, short y) { try { checked { return (short)(x - y); ; } } catch (OverflowException) { return y < 0 ? short.MaxValue : short.MinValue; } }
        public static short Multiply(short x, short y) { try { checked { return (short)(x * y); ; } } catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? short.MaxValue : short.MinValue; } }
        public static short Divide(short x, short y) { try { return (short)(x / y); ; } catch (DivideByZeroException) { return short.MaxValue; } }
        public static short Remainder(short x, short y) { try { return (short)(x % y); ; } catch (DivideByZeroException) { return short.MaxValue; } }

        public static int Add(int x, int y) { try { checked { return x + y; } } catch (OverflowException) { return y > 0 ? int.MaxValue : int.MinValue; } }
        public static int Subtract(int x, int y) { try { checked { return x - y; } } catch (OverflowException) { return y < 0 ? int.MaxValue : int.MinValue; } }
        public static int Multiply(int x, int y) { try { checked { return x * y; } } catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? int.MaxValue : int.MinValue; } }
        public static int Divide(int x, int y) { try { return x / y; } catch (DivideByZeroException) { return int.MaxValue; } }
        public static int Remainder(int x, int y) { try { return x % y; } catch (DivideByZeroException) { return int.MaxValue; } }

        public static long Add(long x, long y) { try { checked { return x + y; } } catch (OverflowException) { return y > 0 ? long.MaxValue : long.MinValue; } }
        public static long Subtract(long x, long y) { try { checked { return x - y; } } catch (OverflowException) { return y < 0 ? long.MaxValue : long.MinValue; } }
        public static long Multiply(long x, long y) { try { checked { return x * y; } } catch (OverflowException) { return (x > 0 && y > 0) || (x < 0 && y < 0) ? long.MaxValue : long.MinValue; } }
        public static long Divide(long x, long y) { try { return x / y; } catch (DivideByZeroException) { return long.MaxValue; } }
        public static long Remainder(long x, long y) { try { return x % y; } catch (DivideByZeroException) { return long.MaxValue; } }

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
            if (float.IsNaN(result)) return float.MaxValue;
            if (float.IsPositiveInfinity(result)) return float.MaxValue;
            if (float.IsNegativeInfinity(result)) return float.MinValue;
            return result;
        }

        public static double Pow(double x, double y)
        {
            var result = Math.Pow(x, y);
            if (double.IsNaN(result)) return double.MaxValue;
            if (double.IsPositiveInfinity(result)) return double.MaxValue;
            if (double.IsNegativeInfinity(result)) return double.MinValue;
            return result;
        }

        public static long ToInt64(double x)
        {
            try { checked { return Convert.ToInt64(x); } }
            catch { return x > 0 ? long.MaxValue : long.MinValue; }
        }

        public static long ToInt64(decimal x)
        {
            try { checked { return Convert.ToInt64(x); } }
            catch { return x > 0 ? long.MaxValue : long.MinValue; }
        }

        public static long ToInt64(float x)
        {
            try { checked { return Convert.ToInt64(x); } }
            catch { return x > 0 ? long.MaxValue : long.MinValue; }
        }

        public static long ToInt64(ulong x)
        {
            try { checked { return Convert.ToInt64(x); } }
            catch { return x > 0 ? long.MaxValue : long.MinValue; }
        }

        public static ulong ToUInt64(double x)
        {
            try { checked { return Convert.ToUInt64(x); } }
            catch { return x > 0 ? ulong.MaxValue : ulong.MinValue; }
        }

        public static ulong ToUInt64(decimal x)
        {
            try { checked { return Convert.ToUInt64(x); } }
            catch { return x > 0 ? ulong.MaxValue : ulong.MinValue; }
        }

        public static ulong ToUInt64(float x)
        {
            try { checked { return Convert.ToUInt64(x); } }
            catch { return x > 0 ? ulong.MaxValue : ulong.MinValue; }
        }

        public static ulong ToUInt64(long x)
        {
            try { checked { return Convert.ToUInt64(x); } }
            catch { return x > 0 ? ulong.MaxValue : ulong.MinValue; }
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
            if (float.IsNaN(result)) return float.MaxValue;
            if (float.IsPositiveInfinity(result)) return float.MaxValue;
            if (float.IsNegativeInfinity(result)) return float.MinValue;
            return result;
        }

        public static float Divide(in float x, in float y)
        {
            float result = x / y;
            if (float.IsNaN(result)) return float.MaxValue;
            if (float.IsPositiveInfinity(result)) return float.MaxValue;
            if (float.IsNegativeInfinity(result)) return float.MaxValue;
            return result;
        }

        public static float Remainder(in float x, in float y)
        {
            float result = x % y;
            if (float.IsNaN(result)) return float.MaxValue;
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
            if (double.IsNaN(result)) return double.MaxValue;
            if (double.IsPositiveInfinity(result)) return double.MaxValue;
            if (double.IsNegativeInfinity(result)) return double.MinValue;
            return result;
        }

        public static double Divide(in double x, in double y)
        {
            double result = x / y;
            if (double.IsNaN(result)) return double.MaxValue;
            if (double.IsPositiveInfinity(result)) return double.MaxValue;
            if (double.IsNegativeInfinity(result)) return double.MaxValue;
            return result;
        }

        public static double Remainder(in double x, in double y)
        {
            double result = x % y;
            if (double.IsNaN(result)) return double.MaxValue;
            if (double.IsPositiveInfinity(result)) return double.MaxValue;
            if (double.IsNegativeInfinity(result)) return double.MaxValue;
            return result;
        }
    }
}
