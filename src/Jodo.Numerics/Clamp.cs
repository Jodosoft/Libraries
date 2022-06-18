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

namespace Jodo.Numerics
{
    [CLSCompliant(false)]
    public static class Clamp<N> where N : struct, INumeric<N>
    {
        public static N ToNumeric(byte value)
        {
            try { checked { return Convert<N>.ToNumeric(value); } }
            catch (OverflowException) { return Numeric<N>.MaxValue; }
        }

        [CLSCompliant(false)]
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

        [CLSCompliant(false)]
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

        [CLSCompliant(false)]
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

        [CLSCompliant(false)]
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
                if (value < 0) return Numeric<N>.Epsilon.Negative();
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
                if (value < 0) return Numeric<N>.Epsilon.Negative();
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
                if (value < 0) return Numeric<N>.Epsilon.Negative();
                return Numeric<N>.Epsilon;
            }
        }
    }
}
