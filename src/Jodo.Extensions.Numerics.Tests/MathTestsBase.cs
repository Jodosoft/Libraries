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
using Jodo.Extensions.Testing;
using NUnit.Framework;
using System;

namespace Jodo.Extensions.Numerics.Tests
{
    public abstract class MathTestsBase<T> : GlobalTestBase where T : struct, INumeric<T>
    {
        private T NextInput()
        {
            T result = Random.NextNumeric<T>(0, 20);

            if (Constants<T>.IsSigned && Random.NextBoolean())
            {
                result = -result;
            }

            if (Constants<T>.IsReal)
            {
                result /= 10;
            }
            return result;
        }

        [Test]
        public void Abs_UnsignedValue_ReturnsSameValue()
        {
            //arrange
            if (Constants<T>.IsSigned) return;
            var input = Random.NextNumeric(Constants<T>.MinUnit, Constants<T>.MinValue + Constants<T>.MaxUnit);

            //act
            var result = Math<T>.Abs(input);

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Abs_NegativeSignedValue_ReturnsSameValue()
        {
            //arrange
            if (!Constants<T>.IsSigned) return;
            var input = Random.NextNumeric(Constants<T>.MinUnit, Constants<T>.MinValue + Constants<T>.MaxUnit);

            //act
            var result = Math<T>.Abs(input);

            //assert
            result.Should().Be(Constants<T>.MinUnit * input);
        }

        [Test]
        public void Acos_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<T>(0, 1);
            var expected = Math.Acos(input.ToDouble());

            //act
            var result = Math<T>.Acos(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Acosh_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<T>(1, 127);
            var expected = Math.Acosh(input.ToDouble());

            //act
            var result = Math<T>.Acosh(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Asin_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<T>(0, 1);
            var expected = Math.Asin(input.ToDouble());

            //act
            var result = Math<T>.Asin(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Asinh_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<T>(0, 3);
            var expected = Math.Asinh(input.ToDouble());

            //act
            var result = Math<T>.Asinh(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Atan_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<T>(0, 1);
            var expected = Math.Atan(input.ToDouble());

            //act
            var result = Math<T>.Atan(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Atan2_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input1 = Random.NextNumeric<T>(1, 4);
            var input2 = Random.NextNumeric<T>(1, 4);
            var expected = Math.Atan2(input1.ToDouble(), input2.ToDouble());

            //act
            var result = Math<T>.Atan2(input1, input2);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Atanh_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            T input;
            do { input = Random.NextNumeric<T>(0, 1); } while (input.Equals(Constants<T>.One));
            var expected = Math.Atanh(input.ToDouble());

            //act
            var result = Math<T>.Atanh(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Cbrt_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<T>(1, 127);
            var expected = Math.Cbrt(input.ToDouble());

            //act
            var result = Math<T>.Cbrt(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Ceiling_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = NextInput();
            var expected = Math.Ceiling(input.ToDouble());

            //act
            var result = Math<T>.Ceiling(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Cos_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<T>(0, 127);
            var expected = Math.Cos(input.ToDouble());

            //act
            var result = Math<T>.Cos(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Cosh_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<T>(0, 3);
            var expected = Math.Cosh(input.ToDouble());

            //act
            var result = Math<T>.Cosh(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void E_Get_EquivalentToSystemMath()
        {
            //arrange
            var expected = Math.E;

            //act
            var result = Math<T>.E;

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Exp_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<T>(1, 3);
            var expected = Math.Exp(input.ToDouble());

            //act
            var result = Math<T>.Exp(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Floor_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = NextInput();
            var expected = Math.Floor(input.ToDouble());

            //act
            var result = Math<T>.Floor(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void IEEERemainder_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            T input1;
            T input2;
            double expected;
            do
            {
                input1 = Random.NextNumeric<T>(100, 127);
                input2 = Random.NextNumeric<T>(1, 5);
                expected = Math.IEEERemainder(input1.ToDouble(), input2.ToDouble());
            } while (!Constants<T>.IsSigned && expected < 0);

            //act
            var result = Math<T>.IEEERemainder(input1, input2);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Log_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<T>(100, 127);
            var expected = Math.Log(input.ToDouble());

            //act
            var result = Math<T>.Log(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void LogN_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input1 = Random.NextNumeric<T>(100, 127);
            var input2 = Random.NextNumeric<T>(2, 10);
            var expected = Math.Log(input1.ToDouble(), input2.ToDouble());

            //act
            var result = Math<T>.Log(input1, input2);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Log10_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<T>(1, 127);
            var expected = Math.Log10(input.ToDouble());

            //act
            var result = Math<T>.Log10(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Max_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input1 = NextInput();
            var input2 = NextInput();
            var expected = Math.Max(input1.ToDouble(), input2.ToDouble());

            //act
            var result = Math<T>.Max(input1, input2);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Min_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input1 = NextInput();
            var input2 = NextInput();
            var expected = Math.Min(input1.ToDouble(), input2.ToDouble());

            //act
            var result = Math<T>.Min(input1, input2);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void PI_Get_EquivalentToSystemMath()
        {
            //arrange
            var expected = Math.PI;

            //act
            var result = Math<T>.PI;

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Pow_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input1 = Random.NextNumeric<T>(1, 3);
            var input2 = Random.NextNumeric<T>(1, 3);
            var expected = Math.Pow(input1.ToDouble(), input2.ToDouble());

            //act
            var result = Math<T>.Pow(input1, input2);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Round1_IntegralValue_ReturnsSameValue()
        {
            //arrange
            if (Constants<T>.IsReal) return;
            var input = Random.NextNumeric<T>();

            //act
            var result = Math<T>.Round(input);

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Round1_RealValue_EquivalentToSystemMath()
        {
            //arrange
            if (!Constants<T>.IsReal) return;
            var input = Random.NextNumeric<T>();
            var expected = Math.Round(input.ToDouble());

            //act
            var result = Math<T>.Round(input);

            //assert
            result.ToDouble().Should().BeApproximately(expected, 0.000001);
        }

        [Test]
        public void Round2_IntegralValue_ReturnsSameValue()
        {
            //arrange
            if (Constants<T>.IsReal) return;
            var input = Random.NextNumeric<T>();

            //act
            var result = Math<T>.Round(input, Random.NextByte());

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Round2_RealValue_EquivalentToSystemMath()
        {
            //arrange
            if (!Constants<T>.IsReal) return;
            var input = Random.NextNumeric<T>();
            var digits = Random.NextByte(1, 5);
            var expected = Math.Round(input.ToDouble(), digits);

            //act
            var result = Math<T>.Round(input, digits);

            //assert
            result.ToDouble().Should().BeApproximately(expected, 1 / Math.Pow(10, digits));
        }

        [Test]
        public void Round3_IntegralValue_ReturnsSameValue()
        {
            //arrange
            if (Constants<T>.IsReal) return;
            var input = Random.NextNumeric<T>();

            //act
            var result = Math<T>.Round(input, Random.NextEnum<MidpointRounding>());

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Round3_RealValue_EquivalentToSystemMath()
        {
            //arrange
            if (!Constants<T>.IsReal) return;
            var input = Random.NextNumeric<T>();
            var mode = Random.NextEnum<MidpointRounding>();
            var expected = Math.Round(input.ToDouble(), mode);

            //act
            var result = Math<T>.Round(input, mode);

            //assert
            result.ToDouble().Should().BeApproximately(expected, 0.000001);
        }

        [Test]
        public void Round4_IntegralValue_ReturnsSameValue()
        {
            //arrange
            if (Constants<T>.IsReal) return;
            var input = Random.NextNumeric<T>();

            //act
            var result = Math<T>.Round(input, Random.NextByte(), Random.NextEnum<MidpointRounding>());

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Round4_RealValue_EquivalentToSystemMath()
        {
            //arrange
            if (!Constants<T>.IsReal) return;
            var input = Random.NextNumeric<T>();
            var digits = Random.NextByte(1, 5);
            var mode = Random.NextEnum<MidpointRounding>();
            var expected = Math.Round(input.ToDouble(), digits, mode);

            //act
            var result = Math<T>.Round(input, digits, mode);

            //assert
            result.ToDouble().Should().BeApproximately(expected, 1 / Math.Pow(10, digits));
        }

        [Test]
        public void Sin_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<T>(0, 127);
            var expected = Math.Sin(input.ToDouble());

            //act
            var result = Math<T>.Sin(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Sinh_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<T>(0, 3);
            var expected = Math.Sinh(input.ToDouble());

            //act
            var result = Math<T>.Sinh(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Sqrt_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<T>(1, 127);
            var expected = Math.Sqrt(input.ToDouble());

            //act
            var result = Math<T>.Sqrt(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Tan_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            T input;
            double expected;
            do
            {
                input = Random.NextNumeric<T>(0, 127);
                expected = Math.Tan(input.ToDouble());
            } while (!Constants<T>.IsSigned && expected < 0);

            //act
            var result = Math<T>.Tan(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Tanh_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            var input = Random.NextNumeric<T>(0, 10);
            var expected = Math.Tanh(input.ToDouble());

            //act
            var result = Math<T>.Tanh(input);

            //assert
            result.Should().BeNumericEquivalentTo(expected);
        }

        [Test]
        public void Truncate_IntegralValue_ReturnsSameValue()
        {
            //arrange
            if (Constants<T>.IsReal) return;
            var input = Random.NextNumeric<T>();

            //act
            var result = Math<T>.Truncate(input);

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Truncate_RealValue_EquivalentToSystemMath()
        {
            //arrange
            if (!Constants<T>.IsReal) return;
            var input = Random.NextNumeric<T>();
            var expected = Math.Truncate(input.ToDouble());

            //act
            var result = Math<T>.Truncate(input);

            //assert
            result.ToDouble().Should().Be(expected);
        }
    }
}
