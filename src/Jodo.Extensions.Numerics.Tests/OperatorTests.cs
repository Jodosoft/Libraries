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
using System.Linq.Expressions;

namespace Jodo.Extensions.Numerics.Tests
{
    public static class OperatorTests
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
            public N NextSmall()
            {
                var result = Random.NextNumeric<N>(0, 10);

                if (Numeric<N>.IsReal) result = Math<N>.Round(result / Convert<N>.ToNumeric(2), 1);
                if (Numeric<N>.IsSigned) result -= Convert<N>.ToNumeric(5);
                return result;
            }

            public N NextSmallPositive()
            {
                var result = Random.NextNumeric<N>(0, 10);
                if (Numeric<N>.IsReal) result = Math<N>.Round(result / Convert<N>.ToNumeric(2), 1);
                return result + Numeric<N>.One;
            }

            [Test, Repeat(RandomVariations)]
            public void Add_RandomValues_CorrectResult()
            {
                //arrange
                var left = NextSmall();
                var right = NextSmall();

                //act
                var result = left + right;

                //assert
                result.Should().BeApproximately(Convert<N>.ToDouble(left) + Convert<N>.ToDouble(right));
            }

            [Test, Repeat(RandomVariations)]
            public void AddSubtract_Random_CorrectResult()
            {
                //arrange
                var left = NextSmall();
                var right = NextSmall();

                //act
                var result = (left + right - right);

                //assert
                result.Should().BeApproximately(Convert<N>.ToDouble(left));
            }

            [Test, Repeat(RandomVariations)]
            public void Multiply_RandomValues_CorrectResult()
            {
                //arrange
                var left = NextSmall();
                var right = NextSmall();

                //act
                var result = left * right;

                //assert
                result.Should().BeApproximately(Convert<N>.ToDouble(left) * Convert<N>.ToDouble(right));
            }

            [Test, Repeat(RandomVariations)]
            public void Positive_RandomValue_ReturnsSameValue()
            {
                //arrange
                var input = NextLowPrecision();

                //act
                var result = +input;

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Negative_RandomSignedValue_ReturnsSameAsAbs()
            {
                //arrange
                SignedOnly();
                var input = Random.NextSByte(-127, -1);
                var inputN = Convert<N>.ToNumeric(input);

                //act
                var result = -inputN;

                //assert
                result.Should().Be(Convert<N>.ToNumeric(input * -1));
            }

            [Test, Repeat(RandomVariations)]
            public void Negative_Zero_ReturnsZero()
            {
                //arrange
                var input = Numeric<N>.Zero;

                //act
                var result = -input;

                //assert
                result.Should().Be(Numeric<N>.Zero);
            }

            [Test, Repeat(RandomVariations)]
            public void Multiply_RandomValueByZero_ReturnsZero()
            {
                //arrange
                var input = NextLowPrecision();

                //act
                var result = input * Numeric<N>.Zero;

                //assert
                result.Should().Be(Numeric<N>.Zero);
            }

            [Test, Repeat(RandomVariations)]
            public void Multiply_RandomValueByOne_ReturnSameValue()
            {
                //arrange
                var input = NextLowPrecision();

                //act
                var result = input * Numeric<N>.One;

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Divide_RandomValueByOne_ReturnsSameValue()
            {
                //arrange
                var input = NextLowPrecision();

                //act
                var result = input / Numeric<N>.One;

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Divide_RandomValueByItself_ReturnsOne()
            {
                //arrange
                var input = NextLowPrecision();

                //act
                var result = input / Numeric<N>.One;

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Divide_RandomValues_CorrectResult()
            {
                //arrange
                var left = NextSmall();
                var right = NextSmallPositive();

                //act
                var result = left / right;

                //assert
                result.Should().BeApproximately(Convert<N>.ToDouble(left) / Convert<N>.ToDouble(right));
            }

            [Test, Repeat(RandomVariations)]
            public void GreaterThan_RandomValues_SameAsSystem()
            {
                //arrange
                var left = Random.NextByte(0, 127);
                var right = Random.NextByte(0, 127);
                var leftN = Convert<N>.ToNumeric(left);
                var rightN = Convert<N>.ToNumeric(right);

                //act
                var result = leftN > rightN;

                //assert
                result.Should().Be(left > right);
            }

            [Test, Repeat(RandomVariations)]
            public void GreaterThanOrEqualTo_RandomValues_SameAsSystem()
            {
                //arrange
                var left = Random.NextByte(0, 127);
                var right = Random.NextByte(0, 127);
                var leftN = Convert<N>.ToNumeric(left);
                var rightN = Convert<N>.ToNumeric(right);

                //act
                var result = leftN >= rightN;

                //assert
                result.Should().Be(left >= right);
            }

            [Test, Repeat(RandomVariations)]
            public void LessThan_RandomValues_SameAsSystem()
            {
                //arrange
                var left = Random.NextByte(0, 127);
                var right = Random.NextByte(0, 127);
                var leftN = Convert<N>.ToNumeric(left);
                var rightN = Convert<N>.ToNumeric(right);

                //act
                var result = leftN < rightN;

                //assert
                result.Should().Be(left < right);
            }

            [Test, Repeat(RandomVariations)]
            public void LessThanOrEqualTo_RandomValues_SameAsSystem()
            {
                //arrange
                var left = Random.NextByte(0, 127);
                var right = Random.NextByte(0, 127);
                var leftN = Convert<N>.ToNumeric(left);
                var rightN = Convert<N>.ToNumeric(right);

                //act
                var result = leftN <= rightN;

                //assert
                result.Should().Be(left <= right);
            }

            [Test, Repeat(RandomVariations)]
            public void Remainder_RandomValueByOne_ReturnsZero()
            {
                //arrange
                var input = Math<N>.Truncate(NextLowPrecision());

                //act
                var result = input % Numeric<N>.One;

                //assert
                result.Should().Be(Numeric<N>.Zero);
            }

            [Test, Repeat(RandomVariations)]
            public void Remainder_RandomValueByItself_ReturnsZero()
            {
                //arrange
                var input = Math<N>.Truncate(NextLowPrecision());

                //act
                var result = input % Numeric<N>.One;

                //assert
                result.Should().Be(Numeric<N>.Zero);
            }

            [Test, Repeat(RandomVariations)]
            public void Remainder_RandomValues_CorrectResult()
            {
                //arrange
                var left = Math<N>.Truncate(NextSmall());
                var right = Math<N>.Truncate(NextSmallPositive());

                //act
                var result = left % right;

                //assert
                result.Should().BeApproximately(Convert<N>.ToDouble(left) % Convert<N>.ToDouble(right));
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalAnd_RandomIntegralValues_CorrectResult()
            {
                //arrange
                IntegralOnly();
                var left = NextSmall();
                var right = NextSmall();

                //act
                var result = left & right;

                //assert
                result.Should().BeApproximately(Convert<N>.ToInt32(left) & Convert<N>.ToInt32(right));
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalOr_RandomIntegralValues_CorrectResult()
            {
                //arrange
                IntegralOnly();
                var left = NextSmall();
                var right = NextSmall();

                //act
                var result = left | right;

                //assert
                result.Should().BeApproximately(Convert<N>.ToInt32(left) | Convert<N>.ToInt32(right));
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalExclusiveOr_RandomIntegralValues_CorrectResult()
            {
                //arrange
                IntegralOnly();
                var left = NextSmall();
                var right = NextSmall();

                //act
                var result = left ^ right;

                //assert
                result.Should().BeApproximately(Convert<N>.ToInt32(left) ^ Convert<N>.ToInt32(right));
            }

            [Test, Repeat(RandomVariations)]
            public void BitwiseComplement_IntegralRoundTrip_SameValue()
            {
                //arrange
                IntegralOnly();
                var left = NextLowPrecision();

                //act
                var result = ~~left;

                //assert
                result.Should().Be(left);
            }

            [Test, Repeat(RandomVariations)]
            public void BitwiseComplement_RandomIntegral_DifferentValue()
            {
                //arrange
                IntegralOnly();
                var left = NextLowPrecision();

                //act
                var result = ~left;

                //assert
                result.Should().NotBe(left);
            }

            [Test, Repeat(RandomVariations)]
            public void BitwiseComplement_RandomReal_DoesntThrow()
            {
                //arrange
                RealOnly();
                var left = NextLowPrecision();

                //act
                var action = new Action(() => { left = ~left; });

                //assert
                action.Should().NotThrow();
            }

            [Test, Repeat(RandomVariations)]
            public void LeftShift_RandomIntegralValues_CorrectResult()
            {
                //arrange
                IntegralOnly();
                var left = NextSmall();
                var right = Random.NextInt32(0, 2);

                //act
                var result = left << right;

                //assert
                result.Should().BeApproximately(Convert<N>.ToInt32(left) << right);
            }

            [Test, Repeat(RandomVariations)]
            public void SByteConversion_SignedRoundTrip_CorrectResult()
            {
                //arrange
                SignedOnly();
                var input = Random.NextSByte();

                //act
                var result = Cast<sbyte>(Cast<N>(input));

                //assert
                result.Should().Be(input);
            }

            public static object Cast<T>(object data)
            {
                var parameter = Expression.Parameter(typeof(object), "data");
                var body = Expression.Block(Expression.Convert(Expression.Convert(parameter, data.GetType()), typeof(T)));
                return Expression.Lambda(body, parameter).Compile().DynamicInvoke(data);
            }
        }
    }
}
