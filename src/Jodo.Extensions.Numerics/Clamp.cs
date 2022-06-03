using Jodo.Extensions.Primitives;
using System;

namespace Jodo.Extensions.Numerics
{
    public static class Clamp<N> where N : struct, INumeric<N>
    {
        public static N ToValue(byte value)
        {
            try { checked { return Convert<N>.ToValue(value); } }
            catch (OverflowException) { return value < 0 ? Numeric<N>.MinValue : Numeric<N>.MaxValue; }
        }

        public static N ToValue(sbyte value)
        {
            try { checked { return Convert<N>.ToValue(value); } }
            catch (OverflowException) { return value < 0 ? Numeric<N>.MinValue : Numeric<N>.MaxValue; }
        }

        public static N ToValue(short value)
        {
            try { checked { return Convert<N>.ToValue(value); } }
            catch (OverflowException) { return value < 0 ? Numeric<N>.MinValue : Numeric<N>.MaxValue; }
        }

        public static N ToValue(ushort value)
        {
            try { checked { return Convert<N>.ToValue(value); } }
            catch (OverflowException) { return value < 0 ? Numeric<N>.MinValue : Numeric<N>.MaxValue; }
        }

        public static N ToValue(int value)
        {
            try { checked { return Convert<N>.ToValue(value); } }
            catch (OverflowException) { return value < 0 ? Numeric<N>.MinValue : Numeric<N>.MaxValue; }
        }

        public static N ToValue(uint value)
        {
            try { checked { return Convert<N>.ToValue(value); } }
            catch (OverflowException) { return value < 0 ? Numeric<N>.MinValue : Numeric<N>.MaxValue; }
        }

        public static N ToValue(long value)
        {
            try { checked { return Convert<N>.ToValue(value); } }
            catch (OverflowException) { return value < 0 ? Numeric<N>.MinValue : Numeric<N>.MaxValue; }
        }

        public static N ToValue(ulong value)
        {
            try { checked { return Convert<N>.ToValue(value); } }
            catch (OverflowException) { return value < 0 ? Numeric<N>.MinValue : Numeric<N>.MaxValue; }
        }

        public static N ToValue(float value)
        {
            if (float.IsPositiveInfinity(value)) return Numeric<N>.MaxValue;
            if (float.IsNegativeInfinity(value)) return Numeric<N>.MinValue;
            if (float.IsNaN(value)) return Numeric<N>.Zero;

            try { checked { return Convert<N>.ToValue(value); } }
            catch (OverflowException)
            {
                if (value < 0 && !Numeric<N>.IsSigned) return Numeric<N>.MinValue;
                if (value < -1) return Numeric<N>.MinValue;
                if (value > 1) return Numeric<N>.MaxValue;
                if (value < 0) return -Numeric<N>.Epsilon;
                return Numeric<N>.Epsilon;
            }
        }

        public static N ToValue(double value)
        {
            if (double.IsPositiveInfinity(value)) return Numeric<N>.MaxValue;
            if (double.IsNegativeInfinity(value)) return Numeric<N>.MinValue;
            if (double.IsNaN(value)) return Numeric<N>.Zero;

            try { checked { return Convert<N>.ToValue(value); } }
            catch (OverflowException)
            {
                if (value < 0 && !Numeric<N>.IsSigned) return Numeric<N>.MinValue;
                if (value < -1) return Numeric<N>.MinValue;
                if (value > 1) return Numeric<N>.MaxValue;
                if (value < 0) return -Numeric<N>.Epsilon;
                return Numeric<N>.Epsilon;
            }
        }

        public static N ToValue(decimal value)
        {
            try { checked { return Convert<N>.ToValue(value); } }
            catch (OverflowException)
            {
                if (value < 0 && !Numeric<N>.IsSigned) return Numeric<N>.MinValue;
                if (value < -1) return Numeric<N>.MinValue;
                if (value > 1) return Numeric<N>.MaxValue;
                if (value < 0) return -Numeric<N>.Epsilon;
                return Numeric<N>.Epsilon;
            }
        }
    }
}
