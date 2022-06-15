using System;

namespace Jodo.Extensions.Numerics
{
    public static class Clamp<N> where N : struct, INumeric<N>
    {
        public static N ToNumeric(byte value)
        {
            try { checked { return Convert<N>.ToNumeric(value); } }
            catch (OverflowException) { return Numeric<N>.MaxValue; }
        }

        public static N ToNumeric(sbyte value)
        {
            try { checked { return Convert<N>.ToNumeric(value); } }
            catch (OverflowException) { return value < 0 ? Numeric<N>.MinValue : Numeric<N>.MaxValue; }
        }

        public static N ToNumeric(short value)
        {
            try { checked { return Convert<N>.ToNumeric(value); } }
            catch (OverflowException) { return value < 0 ? Numeric<N>.MinValue : Numeric<N>.MaxValue; }
        }

        public static N ToNumeric(ushort value)
        {
            try { checked { return Convert<N>.ToNumeric(value); } }
            catch (OverflowException) { return Numeric<N>.MaxValue; }
        }

        public static N ToNumeric(int value)
        {
            try { checked { return Convert<N>.ToNumeric(value); } }
            catch (OverflowException) { return value < 0 ? Numeric<N>.MinValue : Numeric<N>.MaxValue; }
        }

        public static N ToNumeric(uint value)
        {
            try { checked { return Convert<N>.ToNumeric(value); } }
            catch (OverflowException) { return Numeric<N>.MaxValue; }
        }

        public static N ToNumeric(long value)
        {
            try { checked { return Convert<N>.ToNumeric(value); } }
            catch (OverflowException) { return value < 0 ? Numeric<N>.MinValue : Numeric<N>.MaxValue; }
        }

        public static N ToNumeric(ulong value)
        {
            try { checked { return Convert<N>.ToNumeric(value); } }
            catch (OverflowException) { return Numeric<N>.MaxValue; }
        }

        public static N ToNumeric(float value)
        {
            if (float.IsPositiveInfinity(value)) return Numeric<N>.MaxValue;
            if (float.IsNegativeInfinity(value)) return Numeric<N>.MinValue;
            if (float.IsNaN(value)) return Numeric<N>.Zero;

            try { checked { return Convert<N>.ToNumeric(value); } }
            catch (OverflowException)
            {
                if (value < 0 && !Numeric<N>.IsSigned) return Numeric<N>.MinValue;
                if (value < -1) return Numeric<N>.MinValue;
                if (value > 1) return Numeric<N>.MaxValue;
                if (value < 0) return -Numeric<N>.Epsilon;
                return Numeric<N>.Epsilon;
            }
        }

        public static N ToNumeric(double value)
        {
            if (double.IsPositiveInfinity(value)) return Numeric<N>.MaxValue;
            if (double.IsNegativeInfinity(value)) return Numeric<N>.MinValue;
            if (double.IsNaN(value)) return Numeric<N>.Zero;

            try { checked { return Convert<N>.ToNumeric(value); } }
            catch (OverflowException)
            {
                if (value < 0 && !Numeric<N>.IsSigned) return Numeric<N>.MinValue;
                if (value < -1) return Numeric<N>.MinValue;
                if (value > 1) return Numeric<N>.MaxValue;
                if (value < 0) return -Numeric<N>.Epsilon;
                return Numeric<N>.Epsilon;
            }
        }

        public static N ToNumeric(decimal value)
        {
            try { checked { return Convert<N>.ToNumeric(value); } }
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
