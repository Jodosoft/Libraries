﻿// Copyright (c) 2022 Joseph J. Short
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
using NUnit.Framework;
using System;

namespace Jodo.Extensions.Numerics.Tests
{
    public abstract class MathTestsBase<N> : NumericTestBase<N> where N : struct, INumeric<N>
    {
        public const double MaxTestableReal = 1_000_000d;

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
        public void Epsilon_LessThanOrEqualToOne()
        {
            Math<N>.Epsilon.Should().BeLessThanOrEqualTo(Math<N>.One);
        }

        [Test]
        public void Epsilon_Integral_IsOne()
        {
            IntegralOnly();
            Math<N>.Epsilon.ToDouble().Should().Be(1);
        }

        [Test]
        public void Epsilon_Real_GreaterThanZero()
        {
            RealOnly();
            Math<N>.Epsilon.ToDouble().Should().BeGreaterThan(0);
        }

        [Test]
        public void Epsilon_Real_LessThanOne()
        {
            RealOnly();
            Math<N>.Epsilon.ToDouble().Should().BeLessThan(1);
        }

        [Test]
        public void Epsilon_Real_ApproximatelyZero()
        {
            RealOnly();
            Math<N>.Epsilon.ToDouble().Should().BeApproximately(0, 0.0001);
        }

        [Test]
        public void MaxUnit_LessThanMaxValue()
        {
            Math<N>.MaxUnit.Should().BeLessThan(Math<N>.MaxValue);
        }

        [Test]
        public void MaxUnit_IsOne()
        {
            Math<N>.MaxUnit.ToDouble().Should().Be(1);
        }

        [Test]
        public void MinUnit_LessThanMaxUnit()
        {
            Math<N>.MinUnit.Should().BeLessThan(Math<N>.MaxUnit);
        }

        [Test]
        public void MinUnit_Unsigned_IsZero()
        {
            UnsignedOnly();
            Math<N>.MinUnit.Should().Be(Math<N>.Zero);
        }

        [Test]
        public void MinUnit_Signed_IsMinusOne()
        {
            SignedOnly();
            Math<N>.MinUnit.ToDouble().Should().Be(-1);
        }

        [Test]
        public void MinValue_Unsigned_IsZero()
        {
            UnsignedOnly();
            Math<N>.MinValue.Should().Be(Math<N>.Zero);
        }

        [Test]
        public void MinValue_Signed_IsNegative()
        {
            SignedOnly();
            Math<N>.MinValue.ToDouble().Should().BeLessThanOrEqualTo(sbyte.MinValue);
        }

        [Test]
        public void MaxValue_IsPositive()
        {
            Math<N>.MaxValue.ToDouble().Should().BeGreaterThanOrEqualTo(sbyte.MaxValue);
        }

        [Test]
        public void One_IsOne()
        {
            Math<N>.One.ToDouble().Should().Be(1);
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

        [Test]
        public void Zero_LessThanEpsilon()
        {
            Math<N>.Zero.Should().BeLessThan(Math<N>.Epsilon);
        }

        [Test]
        public void Zero_IsZero()
        {
            Math<N>.Zero.ToDouble().Should().Be(0);
        }

        [Test]
        public void Abs_Unsigned_SameValue()
        {
            //arrange
            UnsignedOnly();
            var input = Random.NextNumeric(Math<N>.MinUnit, Math<N>.MinValue + Math<N>.MaxUnit);

            //act
            var result = Math<N>.Abs(input);

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Abs_NegativeSigned_SameValue()
        {
            //arrange
            SignedOnly();
            var input = Random.NextNumeric(Math<N>.MinUnit, Math<N>.MinValue + Math<N>.MaxUnit);

            //act
            var result = Math<N>.Abs(input);

            //assert
            result.Should().Be(Math<N>.MinUnit * input);
        }

        [Test]
        public void Acos_Random_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<N>(-1, 1);

            //act
            var result = Math<N>.Acos(input);

            //assert
            result.Should().BeApproximately(Math.Acos(input.ToDouble()));
        }

        [Test]
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
            var input = Math<N>.One;

            //act
            var result = Math<N>.Acos(input);

            //assert
            result.Should().BeApproximately(Math.Acos(input.ToDouble()));
        }

        [Test]
        public void Acosh_Random_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<N>(Math<N>.One, Math<N>.MaxValue);

            //act
            var result = Math<N>.Acosh(input);

            //assert
            result.Should().BeApproximately(Math.Acosh(input.ToDouble()));
        }

        [Test]
        public void Acosh_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            var input = Math<N>.One;

            //act
            var result = Math<N>.Acosh(input);

            //assert
            result.Should().BeApproximately(Math.Acosh(input.ToDouble()));
        }

        [Test]
        public void Acosh_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            var input = Math<N>.MaxValue;

            //act
            var result = Math<N>.Acosh(input);

            //assert
            result.Should().BeApproximately(Math.Acosh(input.ToDouble()));
        }

        [Test]
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
            var input = Math<N>.MinUnit;

            //act
            var result = Math<N>.Asin(input);

            //assert
            result.Should().BeApproximately(Math.Asin(input.ToDouble()));
        }

        [Test]
        public void Asin_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            var input = Math<N>.One;

            //act
            var result = Math<N>.Asin(input);

            //assert
            result.Should().BeApproximately(Math.Asin(input.ToDouble()));
        }

        [Test]
        public void Asinh_Random_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<N>();

            //act
            var result = Math<N>.Asinh(input);

            //assert
            result.Should().BeApproximately(Math.Asinh(input.ToDouble()));
        }

        [Test]
        public void Asinh_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            var input = Math<N>.MinValue;

            //act
            var result = Math<N>.Asinh(input);

            //assert
            result.Should().BeApproximately(Math.Asinh(input.ToDouble()));
        }

        [Test]
        public void Asinh_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            var input = Math<N>.MaxValue;

            //act
            var result = Math<N>.Asinh(input);

            //assert
            result.Should().BeApproximately(Math.Asinh(input.ToDouble()));
        }

        [Test]
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
            var input = Math<N>.MinValue;

            //act
            var result = Math<N>.Atan(input);

            //assert
            result.Should().BeApproximately(Math.Atan(input.ToDouble()));
        }

        [Test]
        public void Atan_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            var input = Math<N>.MaxValue;

            //act
            var result = Math<N>.Atan(input);

            //assert
            result.Should().BeApproximately(Math.Atan(input.ToDouble()));
        }

        [Test]
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

        [Test]
        public void Atan2_RandomBoundaries_EquivalentToSystemMath()
        {
            //arrange
            var input1 = Random.NextBoolean() ? Math<N>.MinValue : Math<N>.MaxValue;
            var input2 = Random.NextBoolean() ? Math<N>.MinValue : Math<N>.MaxValue;

            //act
            var result = Math<N>.Atan2(input1, input2);

            //assert
            result.Should().BeApproximately(Math.Atan2(input1.ToDouble(), input2.ToDouble()));
        }

        [Test]
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

        [Test]
        public void Cbrt_IntegralRandom_EquivalentToSystemMath()
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
        public void Cbrt_RealRandom_EquivalentToSystemMath()
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
            var input = Math<N>.Zero;

            //act
            var result = Math<N>.Cbrt(input);

            //assert
            result.Should().Be(Math<N>.Zero);
        }

        [Test]
        public void Cbrt_IntegralLowerBound_EquivalentToSystemMath()
        {
            //arrange
            IntegralOnly();
            var input = Math<N>.MaxValue;

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
            var input = Math<N>.MaxValue;

            //act
            var result = Math<N>.Cbrt(input);

            //assert
            result.Should().BeApproximately(Math.Cbrt(input.ToDouble()));
        }

        [Test]
        public void Ceiling_IntegralRandom_SameValue()
        {
            //arrange
            IntegralOnly();
            var input = Random.NextNumeric<N>(-MaxTestableReal, MaxTestableReal);

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
            var input = Math<N>.MinValue;

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
            var input = Math<N>.MaxValue;

            //act
            var result = Math<N>.Ceiling(input);

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Ceiling_RealRandom_EquivalentToSystemMath()
        {
            //arrange
            RealOnly();
            var input = Random.NextNumeric<N>(-MaxTestableReal, MaxTestableReal);

            //act
            var result = Math<N>.Ceiling(input);

            //assert
            result.Should().BeApproximately(Math.Ceiling(input.ToDouble()));
        }

        [Test]
        public void Cos_Random_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<N>();

            //act
            var result = Math<N>.Cos(input);

            //assert
            result.Should().BeApproximately(Math.Cos(input.ToDouble()));
        }

        [Test]
        public void Cos_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            var input = Math<N>.MinValue;

            //act
            var result = Math<N>.Cos(input);

            //assert
            result.Should().BeApproximately(Math.Cos(input.ToDouble()));
        }

        [Test]
        public void Cos_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            var input = Math<N>.MaxValue;

            //act
            var result = Math<N>.Cos(input);

            //assert
            result.Should().BeApproximately(Math.Cos(input.ToDouble()));
        }

        [Test]
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

        [Test]
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
            var input = Math<N>.Zero;

            //act
            var result = Math<N>.Exp(input);

            //assert
            result.Should().Be(Math<N>.One);
        }

        [Test]
        public void Exp_One_E()
        {
            //arrange
            var input = Math<N>.One;

            //act
            var result = Math<N>.Exp(input);

            //assert
            result.Should().Be(Math<N>.E);
        }

        [Test]
        public void Floor_IntegralRandom_SameValue()
        {
            //arrange
            IntegralOnly();
            var input = Random.NextNumeric<N>(-MaxTestableReal, MaxTestableReal);

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
            var input = Math<N>.MinValue;

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
            var input = Math<N>.MaxValue;

            //act
            var result = Math<N>.Floor(input);

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Floor_RealRandom_EquivalentToSystemMath()
        {
            //arrange
            RealOnly();
            var input = Random.NextNumeric<N>(-MaxTestableReal, MaxTestableReal);

            //act
            var result = Math<N>.Floor(input);

            //assert
            result.Should().BeApproximately(Math.Floor(input.ToDouble()));
        }

        [Test, Ignore("")]
        public void IEEERemainder_EquivalentToSystemMath()
        {
            //arrange
            var input1 = Random.NextNumeric<N>(1, 10);
            var input2 = Random.NextNumeric<N>(1, 5);

            //act
            var result = Math<N>.IEEERemainder(input1, input2);

            //assert
            result.Should().BeApproximately(Math.IEEERemainder(input1.ToDouble(), input2.ToDouble()));
        }

        [Test]
        public void Log_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<N>(100, 127);
            var expected = Math.Log(input.ToDouble());

            //act
            var result = Math<N>.Log(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void LogN_EquivalentToSystemMath()
        {
            //arrange
            var input1 = Random.NextNumeric<N>(100, 127);
            var input2 = Random.NextNumeric<N>(2, 10);
            var expected = Math.Log(input1.ToDouble(), input2.ToDouble());

            //act
            var result = Math<N>.Log(input1, input2);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Log10_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<N>(1, 127);
            var expected = Math.Log10(input.ToDouble());

            //act
            var result = Math<N>.Log10(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public void Pow_Zero_One()
        {
            //arrange
            var input = Random.NextNumeric<N>();

            //act
            var result = Math<N>.Pow(input, Math<N>.Zero);

            //assert
            result.Should().Be(Math<N>.One);
        }

        [Test]
        public void Pow_One_SameValue()
        {
            //arrange
            var input = Random.NextNumeric<N>();

            //act
            var result = Math<N>.Pow(input, Math<N>.One);

            //assert
            result.Should().Be(input);
        }

        [Test]
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

        [Test]
        public void Round1_Real_EquivalentToSystemMath()
        {
            //arrange
            RealOnly();
            var input = Random.NextNumeric<N>();

            //act
            var result = Math<N>.Round(input);

            //assert
            result.Should().BeApproximately(Math.Round(input.ToDouble()));
        }

        [Test]
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

        [Test]
        public void Round2_Real_EquivalentToSystemMath()
        {
            //arrange
            RealOnly();
            var input = Random.NextNumeric<N>();
            var digits = Random.NextByte(1, 3);
            var expected = Math.Round(input.ToDouble(), digits);

            //act
            var result = Math<N>.Round(input, digits);

            //assert
            result.ToDouble().Should().BeApproximately(expected, 1 / Math.Pow(10, digits));
        }

        [Test]
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

        [Test]
        public void Round3_Real_EquivalentToSystemMath()
        {
            //arrange
            RealOnly();
            var input = Random.NextNumeric<N>();
            var mode = Random.NextEnum<MidpointRounding>();
            var expected = Math.Round(input.ToDouble(), mode);

            //act
            var result = Math<N>.Round(input, mode);

            //assert
            result.ToDouble().Should().BeApproximately(expected, 0.000001);
        }

        [Test]
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

        [Test]
        public void Round4_Real_EquivalentToSystemMath()
        {
            //arrange
            RealOnly();
            var input = Random.NextNumeric<N>();
            var digits = Random.NextByte(1, 3);
            var mode = Random.NextEnum<MidpointRounding>();
            var expected = Math.Round(input.ToDouble(), digits, mode);

            //act
            var result = Math<N>.Round(input, digits, mode);

            //assert
            result.ToDouble().Should().BeApproximately(expected, 1 / Math.Pow(10, digits));
        }

        [Test]
        public void Sin_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<N>(0, 127);
            var expected = Math.Sin(input.ToDouble());

            //act
            var result = Math<N>.Sin(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Sinh_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<N>(0, 3);
            var expected = Math.Sinh(input.ToDouble());

            //act
            var result = Math<N>.Sinh(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Sqrt_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<N>(1, 127);
            var expected = Math.Sqrt(input.ToDouble());

            //act
            var result = Math<N>.Sqrt(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Tan_EquivalentToSystemMath()
        {
            //arrange
            N input;
            double expected;
            do
            {
                input = Random.NextNumeric<N>(0, 127);
                expected = Math.Tan(input.ToDouble());
            } while (!Math<N>.IsSigned && expected < 0);

            //act
            var result = Math<N>.Tan(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Tanh_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<N>(0, 10);
            var expected = Math.Tanh(input.ToDouble());

            //act
            var result = Math<N>.Tanh(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Truncate_Integral_SameValue()
        {
            //arrange
            IntegralOnly();
            var input = Random.NextNumeric<N>();

            //act
            var result = Math<N>.Truncate(input);

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Truncate_Real_EquivalentToSystemMath()
        {
            //arrange
            RealOnly();
            var input = Random.NextNumeric<N>();
            var expected = Math.Truncate(input.ToDouble());

            //act
            var result = Math<N>.Truncate(input);

            //assert
            result.ToDouble().Should().Be(expected);
        }
    }
}
