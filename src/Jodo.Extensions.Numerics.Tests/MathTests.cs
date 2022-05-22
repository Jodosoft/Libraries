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

using FluentAssertions;
using Jodo.Extensions.Primitives;
using NUnit.Framework;
using System;

namespace Jodo.Extensions.Numerics.Tests
{
    public static class MathTests
    {
        public class XByte : Base<xbyte> { }
        public class XDecimal : Base<xdecimal> { }
        public class XDouble : Base<xdouble> { }
        public class XFloat : Base<xfloat> { }
        public class XInt : Base<xint> { }
        public class XLong : Base<xlong> { }
        public class XSByte : Base<xsbyte> { }
        public class XShort : Base<xshort> { }
        public class XUInt : Base<xuint> { }
        public class XULong : Base<xulong> { }
        public class XUShort : Base<xushort> { }

        public abstract class Base<N> : NumericTestBase<N> where N : struct, INumeric<N>
        {
            [Test]
            public void E_EquivalentToSystemMath()
            {
                Math<N>.E.Should().BeApproximately(Math.E);
            }

            [Test]
            public void E_Integral_Two()
            {
                IntegralOnly();
                Math<N>.E.ToDouble().Should().Be(2);
            }

            [Test]
            public void PI_EquivalentToSystemMath()
            {
                Math<N>.PI.Should().BeApproximately(Math.PI);
            }

            [Test]
            public void PI_Integral_Three()
            {
                IntegralOnly();
                Math<N>.PI.ToDouble().Should().Be(3);
            }

            [Test]
            public void Tau_EquivalentToTwoPi()
            {
                Math<N>.Tau.Should().BeApproximately(Math.PI * 2);
            }

            [Test]
            public void Tau_Integral_Six()
            {
                IntegralOnly();
                Math<N>.Tau.ToDouble().Should().Be(6);
            }

            [Test, Repeat(RandomVariations)]
            public void Abs_Unsigned_SameValue()
            {
                //arrange
                UnsignedOnly();
                var input = Random.NextNumeric(Numeric<N>.MinUnit, Numeric<N>.MinValue + Numeric<N>.MaxUnit);

                //act
                var result = Math<N>.Abs(input);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Abs_NegativeSigned_SameValue()
            {
                //arrange
                SignedOnly();
                var input = Random.NextNumeric(Numeric<N>.MinUnit, Numeric<N>.MinValue + Numeric<N>.MaxUnit);

                //act
                var result = Math<N>.Abs(input);

                //assert
                result.Should().Be(Numeric<N>.MinUnit * input);
            }

            [Test, Repeat(RandomVariations)]
            public void Acos_Random_EquivalentToSystemMath()
            {
                //arrange
                var input = Math<N>.Round(Random.NextNumeric<N>(-1, 1), 1);

                //act
                var result = Math<N>.Acos(input);

                //assert
                result.Should().BeApproximately(Math.Acos(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Acos_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<N>(-1, 1);

                //act
                var result = Math<N>.Acos(input);

                //assert
                result.Should().BeApproximately(Math.Acos(input.ToDouble()));
            }

            [Test]
            public void Acos_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                var input = Numeric<N>.One;

                //act
                var result = Math<N>.Acos(input);

                //assert
                result.Should().BeApproximately(Math.Acos(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Acosh_Random_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<N>(1, MaxTestableReal);

                //act
                var result = Math<N>.Acosh(input);

                //assert
                result.Should().BeApproximately(Math.Acosh(input.ToDouble()));
            }

            [Test]
            public void Acosh_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                var input = Numeric<N>.One;

                //act
                var result = Math<N>.Acosh(input);

                //assert
                result.Should().BeApproximately(Math.Acosh(input.ToDouble()));
            }

            [Test]
            public void Acosh_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                var input = Numeric<N>.MaxValue;

                //act
                var result = Math<N>.Acosh(input);

                //assert
                result.Should().BeApproximately(Math.Acosh(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Asin_Random_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<N>(-1, 1);

                //act
                var result = Math<N>.Asin(input);

                //assert
                result.Should().BeApproximately(Math.Asin(input.ToDouble()));
            }

            [Test]
            public void Asin_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                var input = Numeric<N>.MinUnit;

                //act
                var result = Math<N>.Asin(input);

                //assert
                result.Should().BeApproximately(Math.Asin(input.ToDouble()));
            }

            [Test]
            public void Asin_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                var input = Numeric<N>.One;

                //act
                var result = Math<N>.Asin(input);

                //assert
                result.Should().BeApproximately(Math.Asin(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Asinh_Random_EquivalentToSystemMath()
            {
                //arrange
                var input = NextLowPrecision();

                //act
                var result = Math<N>.Asinh(input);

                //assert
                result.Should().BeApproximately(Math.Asinh(input.ToDouble()));
            }

            [Test]
            public void Asinh_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                var input = Numeric<N>.MinValue;

                //act
                var result = Math<N>.Asinh(input);

                //assert
                result.Should().BeApproximately(Math.Asinh(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Asinh_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                var input = Numeric<N>.MaxValue;

                //act
                var result = Math<N>.Asinh(input);

                //assert
                result.Should().BeApproximately(Math.Asinh(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Atan_Random_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<N>();

                //act
                var result = Math<N>.Atan(input);

                //assert
                result.Should().BeApproximately(Math.Atan(input.ToDouble()));
            }

            [Test]
            public void Atan_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                var input = Numeric<N>.MinValue;

                //act
                var result = Math<N>.Atan(input);

                //assert
                result.Should().BeApproximately(Math.Atan(input.ToDouble()));
            }

            [Test]
            public void Atan_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                var input = Numeric<N>.MaxValue;

                //act
                var result = Math<N>.Atan(input);

                //assert
                result.Should().BeApproximately(Math.Atan(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Atan2_Random_EquivalentToSystemMath()
            {
                //arrange
                var input1 = Random.NextNumeric<N>();
                var input2 = Random.NextNumeric<N>();

                //act
                var result = Math<N>.Atan2(input1, input2);

                //assert
                result.Should().BeApproximately(Math.Atan2(input1.ToDouble(), input2.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Atan2_RandomBoundaries_EquivalentToSystemMath()
            {
                //arrange
                var input1 = Random.NextBoolean() ? Numeric<N>.MinValue : Numeric<N>.MaxValue;
                var input2 = Random.NextBoolean() ? Numeric<N>.MinValue : Numeric<N>.MaxValue;

                //act
                var result = Math<N>.Atan2(input1, input2);

                //assert
                result.Should().BeApproximately(Math.Atan2(input1.ToDouble(), input2.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Atanh_Random_EquivalentToSystemMath()
            {
                //arrange
                N input;
                do { input = Random.NextNumeric<N>(-1, 1); }
                while (!double.IsFinite(Math.Atanh(input.ToDouble())));

                //act
                var result = Math<N>.Atanh(input);

                //assert
                result.Should().BeApproximately(Math.Atanh(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Cbrt_RandomIntegral_EquivalentToSystemMath()
            {
                //arrange
                IntegralOnly();
                var input = Random.NextNumeric<N>();

                //act
                var result = Math<N>.Cbrt(input);

                //assert
                result.Should().BeApproximately(Math.Cbrt(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Cbrt_RandomReal_EquivalentToSystemMath()
            {
                //arrange
                IntegralOnly();
                var input = Random.NextNumeric<N>();

                //act
                var result = Math<N>.Cbrt(input);

                //assert
                result.Should().BeApproximately(Math.Cbrt(input.ToDouble()));
            }

            [Test]
            public void Cbrt_Zero_Zero()
            {
                //arrange
                var input = Numeric<N>.Zero;

                //act
                var result = Math<N>.Cbrt(input);

                //assert
                result.Should().Be(Numeric<N>.Zero);
            }

            [Test]
            public void Cbrt_IntegralLowerBound_EquivalentToSystemMath()
            {
                //arrange
                IntegralOnly();
                var input = Numeric<N>.MaxValue;

                //act
                var result = Math<N>.Cbrt(input);

                //assert
                result.Should().BeApproximately(Math.Cbrt(input.ToDouble()));
            }

            [Test]
            public void Cbrt_IntegralUpperBound_EquivalentToSystemMath()
            {
                //arrange
                IntegralOnly();
                var input = Numeric<N>.MaxValue;

                //act
                var result = Math<N>.Cbrt(input);

                //assert
                result.Should().BeApproximately(Math.Cbrt(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Ceiling_RandomIntegral_SameValue()
            {
                //arrange
                IntegralOnly();
                var input = NextLowPrecision();

                //act
                var result = Math<N>.Ceiling(input);

                //assert
                result.Should().Be(input);
            }

            [Test]
            public void Ceiling_IntegralLowerBound_SameValue()
            {
                //arrange
                IntegralOnly();
                var input = Numeric<N>.MinValue;

                //act
                var result = Math<N>.Ceiling(input);

                //assert
                result.Should().Be(input);
            }

            [Test]
            public void Ceiling_IntegralUpperBound_SameValue()
            {
                //arrange
                IntegralOnly();
                var input = Numeric<N>.MaxValue;

                //act
                var result = Math<N>.Ceiling(input);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Ceiling_RandomReal_EquivalentToSystemMath()
            {
                //arrange
                RealOnly();
                var input = NextLowPrecision();

                //act
                var result = Math<N>.Ceiling(input);

                //assert
                result.Should().BeApproximately(Math.Ceiling(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Cos_RandomSigned_EquivalentToSystemMath()
            {
                //arrange
                SignedOnly();
                var input = NextLowPrecision();

                //act
                var result = Math<N>.Cos(input);

                //assert
                result.Should().BeApproximately(Math.Cos(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Cos_RandomUnsigned_EquivalentToSystemMath()
            {
                //arrange
                UnsignedOnly();
                N input;
                do { input = NextLowPrecision(); } while (Math.Cos(input.ToDouble()) < 0);

                //act
                var result = Math<N>.Cos(input);

                //assert
                result.Should().BeApproximately(Math.Cos(input.ToDouble()));
            }

            [Test]
            public void Cos_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                var input = Numeric<N>.MinValue;

                //act
                var result = Math<N>.Cos(input);

                //assert
                result.Should().BeApproximately(Math.Cos(input.ToDouble()));
            }

            [Test]
            public void Cos_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                var input = Numeric<N>.MaxValue;

                //act
                var result = Math<N>.Cos(input);

                //assert
                result.Should().BeApproximately(Math.Cos(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Cosh_Random_EquivalentToSystemMath()
            {
                //arrange
                N input;
                do { input = Random.NextNumeric<N>(-1, 1); }
                while (!double.IsFinite(Math.Cosh(input.ToDouble())));

                //act
                var result = Math<N>.Cosh(input);

                //assert
                result.Should().BeApproximately(Math.Cosh(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Exp_Random_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<N>(-1, 4);

                //act
                var result = Math<N>.Exp(input);

                //assert
                result.Should().BeApproximately(Math.Exp(input.ToDouble()));
            }

            [Test]
            public void Exp_Zero_One()
            {
                //arrange
                var input = Numeric<N>.Zero;

                //act
                var result = Math<N>.Exp(input);

                //assert
                result.Should().Be(Numeric<N>.One);
            }

            [Test]
            public void Exp_One_E()
            {
                //arrange
                var input = Numeric<N>.One;

                //act
                var result = Math<N>.Exp(input);

                //assert
                result.Should().Be(Math<N>.E);
            }

            [Test, Repeat(RandomVariations)]
            public void Floor_RandomIntegral_SameValue()
            {
                //arrange
                IntegralOnly();
                var input = NextLowPrecision();

                //act
                var result = Math<N>.Floor(input);

                //assert
                result.Should().Be(input);
            }

            [Test]
            public void Floor_IntegralLowerBound_SameValue()
            {
                //arrange
                IntegralOnly();
                var input = Numeric<N>.MinValue;

                //act
                var result = Math<N>.Floor(input);

                //assert
                result.Should().Be(input);
            }

            [Test]
            public void Floor_IntegralUpperBound_SameValue()
            {
                //arrange
                IntegralOnly();
                var input = Numeric<N>.MaxValue;

                //act
                var result = Math<N>.Floor(input);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Floor_RandomReal_EquivalentToSystemMath()
            {
                //arrange
                RealOnly();
                var input = NextLowPrecision();

                //act
                var result = Math<N>.Floor(input);

                //assert
                result.Should().BeApproximately(Math.Floor(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void IEEERemainder_Signed_EquivalentToSystemMath()
            {
                //arrange
                SignedOnly();
                var input1 = Math<N>.Round(Random.NextNumeric<N>(0, 10), 1);
                var input2 = Math<N>.Round(Random.NextNumeric<N>(1, 10), 1);

                //act
                var result = Math<N>.IEEERemainder(input1, input2);

                //assert
                result.Should().BeApproximately(Math.IEEERemainder(input1.ToDouble(), input2.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void IEEERemainder_Unsigned_EquivalentToSystemMath()
            {
                //arrange
                UnsignedOnly();
                N input1;
                N input2;
                do
                {
                    input1 = Math<N>.Round(Random.NextNumeric<N>(0, 10), 1);
                    input2 = Math<N>.Round(Random.NextNumeric<N>(1, 10), 1);
                } while (Math.IEEERemainder(input1.ToDouble(), input2.ToDouble()) < 0);


                //act
                var result = Math<N>.IEEERemainder(input1, input2);

                //assert
                result.Should().BeApproximately(Math.IEEERemainder(input1.ToDouble(), input2.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Log_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<N>(100, 127);

                //act
                var result = Math<N>.Log(input);

                //assert
                result.Should().BeApproximately(Math.Log(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void LogN_EquivalentToSystemMath()
            {
                //arrange
                var input1 = Random.NextNumeric<N>(100, 127);
                var input2 = Random.NextNumeric<N>(2, 10);

                //act
                var result = Math<N>.Log(input1, input2);

                //assert
                result.Should().BeApproximately(Math.Log(input1.ToDouble(), input2.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Log10_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<N>(1, 127);

                //act
                var result = Math<N>.Log10(input);

                //assert
                result.Should().BeApproximately(Math.Log10(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Max_LargestValue()
            {
                //arrange
                var input1 = Random.NextNumeric<N>();
                var input2 = Random.NextNumeric<N>();

                //act
                var result = Math<N>.Max(input1, input2);

                //assert
                result.Should().Be(input1 > input2 ? input1 : input2);
            }

            [Test, Repeat(RandomVariations)]
            public void Min_SmallestValue()
            {
                //arrange
                var input1 = Random.NextNumeric<N>();
                var input2 = Random.NextNumeric<N>();

                //act
                var result = Math<N>.Min(input1, input2);

                //assert
                result.Should().Be(input1 < input2 ? input1 : input2);
            }

            [Test, Repeat(RandomVariations)]
            public void Pow_Random_EquivalentToSystemMath()
            {
                //arrange
                var input1 = Random.NextNumeric<N>(.9, 3);
                var input2 = Random.NextNumeric<N>(.9, 3);

                //act
                var result = Math<N>.Pow(input1, input2);

                //assert
                result.Should().BeApproximately(Math.Pow(input1.ToDouble(), input2.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Pow_Zero_One()
            {
                //arrange
                var input = Random.NextNumeric<N>();

                //act
                var result = Math<N>.Pow(input, Numeric<N>.Zero);

                //assert
                result.Should().Be(Numeric<N>.One);
            }

            [Test, Repeat(RandomVariations)]
            public void Pow_One_SameValue()
            {
                //arrange
                var input = Random.NextNumeric<N>();

                //act
                var result = Math<N>.Pow(input, Numeric<N>.One);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Round1_Integral_SameValue()
            {
                //arrange
                IntegralOnly();
                var input = Random.NextNumeric<N>();

                //act
                var result = Math<N>.Round(input);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Round1_Real_EquivalentToSystemMath()
            {
                //arrange
                RealOnly();
                var input = Math.Round(Random.NextDouble(), 5);
                var numeric = Convert<N>.ToNumeric(input);

                //act
                var result = Math<N>.Round(numeric);

                //assert
                result.Should().Be(Convert<N>.ToNumeric(Math.Round(input)));
            }

            [Test, Repeat(RandomVariations)]
            public void Round2_Integral_SameValue()
            {
                //arrange
                IntegralOnly();
                var input = Random.NextNumeric<N>();

                //act
                var result = Math<N>.Round(input, Random.NextByte());

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Round2_Real_EquivalentToSystemMath()
            {
                //arrange
                RealOnly();
                var input = Math.Round(Random.NextDouble(), 5);
                var numeric = Convert<N>.ToNumeric(input);
                var digits = Random.NextByte(1, 3);

                //act
                var result = Math<N>.Round(numeric, digits);

                //assert
                result.Should().Be(Convert<N>.ToNumeric(Math.Round(input, digits)));
            }

            [Test, Repeat(RandomVariations)]
            public void Round3_Integral_SameValue()
            {
                //arrange
                IntegralOnly();
                var input = Random.NextNumeric<N>();

                //act
                var result = Math<N>.Round(input, Random.NextEnum<MidpointRounding>());

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Round3_Real_EquivalentToSystemMath()
            {
                //arrange
                RealOnly();
                var input = Math.Round(Random.NextDouble(), 5);
                var numeric = Convert<N>.ToNumeric(input);
                var mode = Random.NextEnum<MidpointRounding>();

                //act
                var result = Math<N>.Round(numeric, mode);

                //assert
                result.Should().Be(Convert<N>.ToNumeric(Math.Round(input, mode)));
            }

            [Test, Repeat(RandomVariations)]
            public void Round4_Integral_SameValue()
            {
                //arrange
                IntegralOnly();
                var input = Random.NextNumeric<N>();

                //act
                var result = Math<N>.Round(input, Random.NextByte(), Random.NextEnum<MidpointRounding>());

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Round4_Real_EquivalentToSystemMath()
            {
                //arrange
                RealOnly();
                var input = Math.Round(Random.NextDouble(), 5);
                var numeric = Convert<N>.ToNumeric(input);
                var digits = Random.NextByte(1, 3);
                var mode = Random.NextEnum<MidpointRounding>();

                //act
                var result = Math<N>.Round(numeric, digits, mode);

                //assert
                result.Should().Be(Convert<N>.ToNumeric(Math.Round(input, digits, mode)));
            }

            [Test, Repeat(RandomVariations)]
            public void Sin_RandomSigned_EquivalentToSystemMath()
            {
                //arrange
                SignedOnly();
                var input = NextLowPrecision();

                //act
                var result = Math<N>.Sin(input);

                //assert
                result.Should().BeApproximately(Math.Sin(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Sin_RandomUnsigned_EquivalentToSystemMath()
            {
                //arrange
                UnsignedOnly();
                N input;
                do { input = NextLowPrecision(); } while (Math.Sin(input.ToDouble()) < 0);

                //act
                var result = Math<N>.Sin(input);

                //assert
                result.Should().BeApproximately(Math.Sin(input.ToDouble()));
            }

            [Test]
            public void Sin_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                var input = Numeric<N>.MinValue;

                //act
                var result = Math<N>.Sin(input);

                //assert
                result.Should().BeApproximately(Math.Sin(input.ToDouble()));
            }

            [Test]
            public void Sin_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                var input = Numeric<N>.MaxValue;

                //act
                var result = Math<N>.Sin(input);

                //assert
                result.Should().BeApproximately(Math.Sin(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Sinh_Random_EquivalentToSystemMath()
            {
                //arrange
                N input;
                do { input = Random.NextNumeric<N>(-1, 1); }
                while (!double.IsFinite(Math.Sinh(input.ToDouble())));

                //act
                var result = Math<N>.Sinh(input);

                //assert
                result.Should().BeApproximately(Math.Sinh(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Sqrt_RandomIntegral_EquivalentToSystemMath()
            {
                //arrange
                IntegralOnly();
                var input = Random.NextNumeric<N>(Numeric<N>.Zero, Numeric<N>.MaxValue);

                //act
                var result = Math<N>.Sqrt(input);

                //assert
                result.Should().BeApproximately(Math.Sqrt(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Sqrt_RandomReal_EquivalentToSystemMath()
            {
                //arrange
                RealOnly();
                var input = NextLowPrecisionNonNegative();

                //act
                var result = Math<N>.Sqrt(input);

                //assert
                result.Should().BeApproximately(Math.Sqrt(input.ToDouble()));
            }

            [Test]
            public void Sqrt_Zero_Zero()
            {
                //arrange
                var input = Numeric<N>.Zero;

                //act
                var result = Math<N>.Sqrt(input);

                //assert
                result.Should().Be(Numeric<N>.Zero);
            }

            [Test, Repeat(RandomVariations)]
            public void Tan_RandomSigned_EquivalentToSystemMath()
            {
                //arrange
                SignedOnly();
                var input = Math<N>.Round(Random.NextNumeric<N>(-10, 10), 1);

                //act
                var result = Math<N>.Tan(input);

                //assert
                result.Should().BeApproximately(Math.Tan(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Tan_RandomUnsigned_EquivalentToSystemMath()
            {
                //arrange
                UnsignedOnly();
                N input;
                do { input = Random.NextNumeric<N>(); } while (Math.Tan(input.ToDouble()) < 0);

                //act
                var result = Math<N>.Tan(input);

                //assert
                result.Should().BeApproximately(Math.Tan(input.ToDouble()));
            }

            [Test]
            public void Tan_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                var input = Numeric<N>.MinValue;

                //act
                var result = Math<N>.Tan(input);

                //assert
                result.Should().BeApproximately(Math.Tan(input.ToDouble()));
            }

            [Test]
            public void Tan_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                var input = Numeric<N>.MaxValue;

                //act
                var result = Math<N>.Tan(input);

                //assert
                result.Should().BeApproximately(Math.Tan(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Tanh_Random_EquivalentToSystemMath()
            {
                //arrange
                N input;
                do { input = Random.NextNumeric<N>(-1, 1); }
                while (!double.IsFinite(Math.Tanh(input.ToDouble())));

                //act
                var result = Math<N>.Tanh(input);

                //assert
                result.Should().BeApproximately(Math.Tanh(input.ToDouble()));
            }

            [Test, Repeat(RandomVariations)]
            public void Truncate_RandomIntegral_SameValue()
            {
                //arrange
                IntegralOnly();
                var input = Random.NextNumeric<N>();

                //act
                var result = Math<N>.Truncate(input);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Truncate_RandomReal_EquivalentToSystemMath()
            {
                //arrange
                RealOnly();
                var input = Random.NextNumeric<N>();

                //act
                var result = Math<N>.Truncate(input);

                //assert
                result.ToDouble().Should().Be(Math.Truncate(input.ToDouble()));
            }
        }
    }
}
