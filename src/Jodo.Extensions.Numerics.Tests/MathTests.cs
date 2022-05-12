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
    public static class MathTests
    {
        public class GShort : Base<gshort> { }
        public class GInt : Base<gint> { }

        public abstract class Base<T> : GlobalTestBase where T : struct, INumeric<T>
        {
            private T NextInput()
            {
                T result = Random.NextNumeric<T>(0, 20);

                if (Math<T>.IsSigned && Random.NextBoolean())
                {
                    result = -result;
                }

                if (Math<T>.IsReal)
                {
                    result /= 10;
                }
                return result;
            }

            [Test]
            public void Zero_Get_ReturnsZero()
            {
                //arrange

                //act
                var result = Math<T>.Zero;

                //assert
                result.Should().BeNumericEquivalentTo(0);
            }

            [Test]
            public void Epsilon_Get_GreaterThanZero()
            {
                //arrange

                //act
                var result = Math<T>.Epsilon;

                //assert
                result.Should().BeGreaterThan(Math<T>.Convert(0));
            }

            [Test]
            public void Abs_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = NextInput();
                var expected = Math.Abs(Math<T>.ToDouble(input, 0));

                //act
                var result = Math<T>.Abs(input);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void Acos_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<T>(0, 1);
                var expected = Math.Acos(Math<T>.ToDouble(input, 0));

                //act
                var result = Math<T>.Acos(input);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void Acosh_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<T>(1, 255);
                var expected = Math.Acosh(Math<T>.ToDouble(input, 0));

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
                var expected = Math.Asin(Math<T>.ToDouble(input, 0));

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
                var expected = Math.Asinh(Math<T>.ToDouble(input, 0));

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
                var expected = Math.Atan(Math<T>.ToDouble(input, 0));

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
                var expected = Math.Atan2(Math<T>.ToDouble(input1, 0), Math<T>.ToDouble(input2, 0));

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
                do { input = Random.NextNumeric<T>(0, 1); } while (input.Equals(Math<T>.One));
                var expected = Math.Atanh(Math<T>.ToDouble(input, 0));

                //act
                var result = Math<T>.Atanh(input);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void Cbrt_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<T>(1, 255);
                var expected = Math.Cbrt(Math<T>.ToDouble(input, 0));

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
                var expected = Math.Ceiling(Math<T>.ToDouble(input, 0));

                //act
                var result = Math<T>.Ceiling(input);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void Cos_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<T>(0, 255);
                var expected = Math.Cos(Math<T>.ToDouble(input, 0));

                //act
                var result = Math<T>.Cos(input);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void Cosh_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<T>(0, 10);
                var expected = Math.Cosh(Math<T>.ToDouble(input, 0));

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
                var expected = Math.Exp(Math<T>.ToDouble(input, 0));

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
                var expected = Math.Floor(Math<T>.ToDouble(input, 0));

                //act
                var result = Math<T>.Floor(input);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void IEEERemainder_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input1 = NextInput();
                var input2 = NextInput();
                var expected = Math.IEEERemainder(Math<T>.ToDouble(input1, 0), Math<T>.ToDouble(input2, 0));

                //act
                var result = Math<T>.IEEERemainder(input1, input2);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void Log_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<T>(1, 255);
                var expected = Math.Log(Math<T>.ToDouble(input, 0));

                //act
                var result = Math<T>.Log(input);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void LogN_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input1 = Random.NextNumeric<T>(1, 255);
                var input2 = Random.NextNumeric<T>(1, 10);
                var expected = Math.Log(Math<T>.ToDouble(input1, 0), Math<T>.ToDouble(input2, 0));

                //act
                var result = Math<T>.Log(input1, input2);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void Log10_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<T>(1, 255);
                var expected = Math.Log10(Math<T>.ToDouble(input, 0));

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
                var expected = Math.Max(Math<T>.ToDouble(input1, 0), Math<T>.ToDouble(input2, 0));

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
                var expected = Math.Min(Math<T>.ToDouble(input1, 0), Math<T>.ToDouble(input2, 0));

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
                var expected = Math.Pow(Math<T>.ToDouble(input1, 0), Math<T>.ToDouble(input2, 0));

                //act
                var result = Math<T>.Pow(input1, input2);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void Round1_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = NextInput();
                var expected = Math.Round(Math<T>.ToDouble(input, 0));

                //act
                var result = Math<T>.Round(input);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void Round2_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = NextInput();
                var digits = Random.NextByte(3, 5);
                var expected = Math.Round(Math<T>.ToDouble(input, 0), digits);

                //act
                var result = Math<T>.Round(input, digits);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void Round3_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = NextInput();
                var midpointRounding = Random.NextEnum<MidpointRounding>();
                var expected = Math.Round(Math<T>.ToDouble(input, 0), midpointRounding);

                //act
                var result = Math<T>.Round(input, midpointRounding);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void Round4_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = NextInput();
                var digits = Random.NextByte(3, 5);
                var midpointRounding = Random.NextEnum<MidpointRounding>();
                var expected = Math.Round(Math<T>.ToDouble(input, 0), digits, midpointRounding);

                //act
                var result = Math<T>.Round(input, digits, midpointRounding);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void Sin_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<T>(0, 255);
                var expected = Math.Sin(Math<T>.ToDouble(input, 0));

                //act
                var result = Math<T>.Sin(input);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void Sinh_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<T>(0, 10);
                var expected = Math.Sinh(Math<T>.ToDouble(input, 0));

                //act
                var result = Math<T>.Sinh(input);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void Sqrt_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<T>(1, 255);
                var expected = Math.Sqrt(Math<T>.ToDouble(input, 0));

                //act
                var result = Math<T>.Sqrt(input);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void Tan_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = Random.NextNumeric<T>(0, 255);
                var expected = Math.Tan(Math<T>.ToDouble(input, 0));

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
                var expected = Math.Tanh(Math<T>.ToDouble(input, 0));

                //act
                var result = Math<T>.Tanh(input);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }

            [Test]
            public void Truncate_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                var input = NextInput();
                var expected = Math.Truncate(Math<T>.ToDouble(input, 0));
                //act
                var result = Math<T>.Truncate(input);

                //assert
                result.Should().BeNumericEquivalentTo(expected);
            }
        }
    }
}
