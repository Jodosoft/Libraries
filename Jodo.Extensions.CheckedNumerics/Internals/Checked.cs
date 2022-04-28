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

namespace Jodo.Extensions.CheckedNumerics.Internals
{
    internal static class Checked
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

        public static float DegreesToRadians(float degrees) => degrees * RadiansPerDegreeF;
        public static float DegreesToTurns(float degrees) => degrees * TurnsPerDegreeF;
        public static float RadiansToDegrees(float radians) => radians * DegreesPerRadianF;
        public static float RadiansToTurns(float radians) => radians * TurnsPerRadianF;
        public static float TurnsToDegrees(float turns) => turns * DegreesPerTurnF;
        public static float TurnsToRadians(float turns) => turns * RadiansPerTurnF;

        public static double DegreesToRadians(double degrees) => degrees * RadiansPerDegree;
        public static double DegreesToTurns(double degrees) => degrees * TurnsPerDegree;
        public static double RadiansToDegrees(double radians) => radians * DegreesPerRadian;
        public static double RadiansToTurns(double radians) => radians * TurnsPerRadian;
        public static double TurnsToDegrees(double turns) => turns * DegreesPerTurn;
        public static double TurnsToRadians(double turns) => turns * RadiansPerTurn;


        public static int Add(int x, int y)
        {
            try { checked { return x + y; } }
            catch { return y > 0 ? int.MaxValue : int.MinValue; }
        }

        public static long Add(long x, long y)
        {
            try { checked { return x + y; } }
            catch { return y > 0 ? long.MaxValue : long.MinValue; }
        }

        public static uint Add(uint x, uint y)
        {
            try { checked { return x + y; } }
            catch { return uint.MaxValue; }
        }

        public static ulong Add(ulong x, ulong y)
        {
            try { checked { return x + y; } }
            catch { return ulong.MaxValue; }
        }

        public static int Subtract(int x, int y)
        {
            try { checked { return x - y; } }
            catch { return y < 0 ? int.MaxValue : int.MinValue; }
        }

        public static long Subtract(long x, long y)
        {
            try { checked { return x - y; } }
            catch { return y < 0 ? long.MaxValue : long.MinValue; }
        }

        public static uint Subtract(uint x, uint y)
        {
            try { checked { return x - y; } }
            catch { return uint.MinValue; }
        }

        public static ulong Subtract(ulong x, ulong y)
        {
            try { checked { return x - y; } }
            catch { return ulong.MinValue; }
        }

        public static short Multiply(short x, short y)
        {
            try
            {
                checked
                {
                    var result = x * y;
                    return
                        result > short.MaxValue ? short.MaxValue :
                        result < short.MinValue ? short.MinValue :
                        (short)result;
                }
            }
            catch { return (x > 0 && y > 0) || (x < 0 && y < 0) ? short.MaxValue : short.MinValue; }
        }

        public static int Multiply(int x, int y)
        {
            try { checked { return x * y; } }
            catch { return (x > 0 && y > 0) || (x < 0 && y < 0) ? int.MaxValue : int.MinValue; }
        }

        public static long Multiply(long x, long y)
        {
            try { checked { return x * y; } }
            catch { return (x > 0 && y > 0) || (x < 0 && y < 0) ? long.MaxValue : long.MinValue; }
        }

        public static uint Multiply(uint x, uint y)
        {
            try { checked { return x * y; } }
            catch { return uint.MaxValue; }
        }

        public static ulong Multiply(ulong x, ulong y)
        {
            try { checked { return x * y; } }
            catch { return ulong.MaxValue; }
        }

        public static int Divide(int x, int y)
        {
            if (y == 0)
            {
                return x == 0 ? 0 : x < 0 ? int.MinValue : int.MaxValue;
            }
            return x / y;
        }

        public static uint Divide(uint x, uint y)
        {
            if (y == 0) return x == 0 ? 0 : uint.MaxValue;
            return x / y;
        }


        public static int Pow(int x, int power)
        {
            if (power < 0) return 0;
            if (power == 0) return 1;
            try
            {
                checked
                {
                    var acc = x;
                    for (int i = 1; i < power; i++)
                    {
                        acc *= x;
                    }
                    return acc;
                }
            }
            catch { return x < 0 && power % 2 == 1 ? int.MinValue : int.MaxValue; }
        }


        public static uint Pow(uint x, uint power)
        {
            if (power == 0) return 1;
            try
            {
                checked
                {
                    var acc = x;
                    for (int i = 1; i < power; i++)
                    {
                        acc *= x;
                    }
                    return acc;
                }
            }
            catch { return uint.MaxValue; }
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

        public static float Add(float x, float y)
        {
            float result = x + y;
            if (result == float.PositiveInfinity) return float.MaxValue;
            if (result == float.NegativeInfinity) return float.MinValue;
            if (result == float.NaN) return 0;
            return result;
        }

        public static float Subtract(float x, float y)
        {
            float result = x - y;
            if (result == float.PositiveInfinity) return float.MaxValue;
            if (result == float.NegativeInfinity) return float.MinValue;
            if (result == float.NaN) return 0;
            return result;
        }

        public static float Multiply(float x, float y)
        {
            float result = x * y;
            if (result == float.PositiveInfinity) return float.MaxValue;
            if (result == float.NegativeInfinity) return float.MinValue;
            if (result == float.NaN) return 0;
            return result;
        }

        public static float Divide(float x, float y)
        {
            float result = x / y;
            if (result == float.PositiveInfinity) return float.MaxValue;
            if (result == float.NegativeInfinity) return float.MinValue;
            if (result == float.NaN) return 0;
            return result;
        }

        public static double Add(double x, double y)
        {
            double result = x + y;
            if (result == double.PositiveInfinity) return double.MaxValue;
            if (result == double.NegativeInfinity) return double.MinValue;
            if (result == double.NaN) return 0;
            return result;
        }

        public static double Subtract(double x, double y)
        {
            double result = x - y;
            if (result == double.PositiveInfinity) return double.MaxValue;
            if (result == double.NegativeInfinity) return double.MinValue;
            if (result == double.NaN) return 0;
            return result;
        }

        public static double Multiply(double x, double y)
        {
            double result = x * y;
            if (result == double.PositiveInfinity) return double.MaxValue;
            if (result == double.NegativeInfinity) return double.MinValue;
            if (result == double.NaN) return 0;
            return result;
        }

        public static double Divide(double x, double y)
        {
            double result = x / y;
            if (result == double.PositiveInfinity) return double.MaxValue;
            if (result == double.NegativeInfinity) return double.MinValue;
            if (result == double.NaN) return 0;
            return result;
        }
    }
}
