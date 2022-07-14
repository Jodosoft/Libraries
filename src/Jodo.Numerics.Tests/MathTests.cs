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
using FluentAssertions;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public static class MathTests
    {
        [Timeout(1000)]
        public abstract class General<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [Test]
            public void E_EquivalentToSystemMath()
            {
                MathN.E<N>().Should().BeApproximately(ConvertN.ToNumeric<N>(Math.E, Conversion.Cast));
            }

            [Test]
            public void PI_EquivalentToSystemMath()
            {
                MathN.PI<N>().Should().BeApproximately(ConvertN.ToNumeric<N>(Math.PI, Conversion.Cast));
            }

            [Test]
            public void Tau_TwoPi()
            {
                MathN.Tau<N>().Should().BeApproximately(ConvertN.ToNumeric<N>(Math.PI * 2, Conversion.Cast));
            }

            [Test]
            public void Abs_Zero_SameValue()
            {
                //arrange
                N input = Numeric<N>.Zero;

                //act
                N result = MathN.Abs(input);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Abs_Positive_SameValue()
            {
                //arrange
                N input = Random.NextNumeric(Numeric<N>.Zero, Numeric<N>.MaxValue);

                //act
                N result = MathN.Abs(input);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Acos_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -1 : 0, 1), 2);
                if (Numeric<N>.IsIntegral) randomValue = Math.Round(randomValue);
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Acos(randomValue), Conversion.Cast);

                //act
                N result = MathN.Acos(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Acos_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                int lowerBound = Numeric<N>.IsSigned ? -1 : 0;
                N input = ConvertN.ToNumeric<N>(lowerBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Acos(lowerBound), Conversion.Cast);

                //act
                N result = MathN.Acos(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Acos_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                int upperBound = 1;
                N input = ConvertN.ToNumeric<N>(upperBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Acos(upperBound), Conversion.Cast);

                //act
                N result = MathN.Acos(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Acosh_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue;
                do
                {
                    randomValue = Math.Round(Random.NextDouble(1, 10), 2);
                    if (Numeric<N>.IsIntegral) randomValue = Math.Round(randomValue);
                }
                while (!DoubleCompat.IsFinite(MathCompat.Acosh(randomValue)));
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(MathCompat.Acosh(randomValue), Conversion.Cast);

                //act
                N result = MathN.Acosh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Acosh_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                int lowerBound = 1;
                N input = ConvertN.ToNumeric<N>(lowerBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(MathCompat.Acosh(lowerBound), Conversion.Cast);

                //act
                N result = MathN.Acosh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Acosh_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = TestUtilities.ReduceSignificance(Numeric<N>.MaxValue);
                N input = ConvertN.ToNumeric<N>(upperBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(MathCompat.Acosh(upperBound), Conversion.Cast);

                //act
                N result = MathN.Acosh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Asin_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -1 : 0, 1), 2);
                if (Numeric<N>.IsIntegral) randomValue = Math.Round(randomValue);
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Asin(randomValue), Conversion.Cast);

                //act
                N result = MathN.Asin(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Asin_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                int lowerBound = Numeric<N>.IsSigned ? -1 : 0;
                N input = ConvertN.ToNumeric<N>(lowerBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Asin(lowerBound), Conversion.Cast);

                //act
                N result = MathN.Asin(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Asin_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                int upperBound = 1;
                N input = ConvertN.ToNumeric<N>(upperBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Asin(upperBound), Conversion.Cast);

                //act
                N result = MathN.Asin(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Asinh_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(), 2);
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(MathCompat.Asinh(randomValue), Conversion.Cast);

                //act
                N result = MathN.Asinh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Asinh_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double lowerBound = TestUtilities.ReduceSignificance(Numeric<N>.MinValue);
                N input = ConvertN.ToNumeric<N>(lowerBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(MathCompat.Asinh(lowerBound), Conversion.Cast);

                //act
                N result = MathN.Asinh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Asinh_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = TestUtilities.ReduceSignificance(Numeric<N>.MaxValue);
                N input = ConvertN.ToNumeric<N>(upperBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(MathCompat.Asinh(upperBound), Conversion.Cast);

                //act
                N result = MathN.Asinh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Atan_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = TestUtilities.ReduceSignificance(Random.NextNumeric<N>());
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Atan(randomValue), Conversion.Cast);

                //act
                N result = MathN.Atan(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Atan_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double lowerBound = TestUtilities.ReduceSignificance(Numeric<N>.MinValue);
                N input = ConvertN.ToNumeric<N>(lowerBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Atan(lowerBound), Conversion.Cast);

                //act
                N result = MathN.Atan(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Atan_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = TestUtilities.ReduceSignificance(Numeric<N>.MaxValue);
                N input = ConvertN.ToNumeric<N>(upperBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Atan(upperBound), Conversion.Cast);

                //act
                N result = MathN.Atan(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Atan2_RandomValues_EquivalentToSystemMath()
            {
                //arrange
                double randomValue1 = TestUtilities.ReduceSignificance(Random.NextNumeric<N>());
                double randomValue2 = TestUtilities.ReduceSignificance(Random.NextNumeric<N>());
                N input1 = ConvertN.ToNumeric<N>(randomValue1, Conversion.Cast);
                N input2 = ConvertN.ToNumeric<N>(randomValue2, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Atan2(randomValue1, randomValue2), Conversion.Cast);

                //act
                N result = MathN.Atan2(input1, input2);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Atan2_RandomBoundaries_EquivalentToSystemMath()
            {
                //arrange
                double randomBoundary1 = TestUtilities.ReduceSignificance(Random.NextBoolean() ? Numeric<N>.MinValue : Numeric<N>.MaxValue);
                double randomBoundary2 = TestUtilities.ReduceSignificance(Random.NextBoolean() ? Numeric<N>.MinValue : Numeric<N>.MaxValue);
                N input1 = ConvertN.ToNumeric<N>(randomBoundary1, Conversion.Cast);
                N input2 = ConvertN.ToNumeric<N>(randomBoundary2, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Atan2(randomBoundary1, randomBoundary2), Conversion.Cast);

                //act
                N result = MathN.Atan2(input1, input2);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Atanh_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue;
                do
                {
                    randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -1 : 0, 1), 2);
                    if (Numeric<N>.IsIntegral) randomValue = Math.Round(randomValue);
                }
                while (!DoubleCompat.IsFinite(MathCompat.Atanh(randomValue)));
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(MathCompat.Atanh(randomValue), Conversion.Cast);

                //act
                N result = MathN.Atanh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Cbrt_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = TestUtilities.ReduceSignificance(Random.NextNumeric<N>());
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(MathCompat.Cbrt(randomValue), Conversion.Cast);

                //act
                N result = MathN.Cbrt(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Cbrt_Zero_EquivalentToSystemMath()
            {
                //arrange
                N input = ConvertN.ToNumeric<N>(0, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(MathCompat.Cbrt(0d), Conversion.Cast);

                //act
                N result = MathN.Cbrt(input);

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Cbrt_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double lowerBound = TestUtilities.ReduceSignificance(Numeric<N>.MinValue);
                N input = ConvertN.ToNumeric<N>(lowerBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(MathCompat.Cbrt(lowerBound), Conversion.Cast);

                //act
                N result = MathN.Cbrt(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Cbrt_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = TestUtilities.ReduceSignificance(Numeric<N>.MaxValue);
                N input = ConvertN.ToNumeric<N>(upperBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(MathCompat.Cbrt(upperBound), Conversion.Cast);

                //act
                N result = MathN.Cbrt(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Ceiling_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -10 : 0, 10), 1);
                if (Numeric<N>.IsIntegral) randomValue = Math.Round(randomValue);
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Ceiling(randomValue), Conversion.Cast);

                //act
                N result = MathN.Ceiling(input);

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Ceiling_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double lowerBound = TestUtilities.ReduceSignificance(Numeric<N>.MinValue.Add(Numeric<N>.One));
                if (Numeric<N>.IsIntegral) lowerBound = Math.Round(lowerBound);
                N input = ConvertN.ToNumeric<N>(lowerBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Ceiling(lowerBound), Conversion.Cast);

                //act
                N result = MathN.Ceiling(input);

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Ceiling_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = TestUtilities.ReduceSignificance(Numeric<N>.MaxValue.Subtract(Numeric<N>.One));
                if (Numeric<N>.IsIntegral) upperBound = Math.Floor(upperBound);
                N input = ConvertN.ToNumeric<N>(upperBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Ceiling(upperBound), Conversion.Cast);

                //act
                N result = MathN.Ceiling(input);

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Ceiling_Zero_EquivalentToSystemMath()
            {
                //arrange
                N input = ConvertN.ToNumeric<N>(0, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Ceiling(0d), Conversion.Cast);

                //act
                N result = MathN.Ceiling(input);

                //assert
                result.Should().Be(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Clamp_RandomValues_ReturnsValueWithinBounds()
            {
                //arrange
                N input = Random.NextNumeric<N>();
                N bound1 = Random.NextNumeric<N>();
                N bound2 = Random.NextNumeric<N>();

                //act
                N result = MathN.Clamp(input, bound1, bound2);

                //assert
                if (bound1.IsGreaterThan(bound2)) (bound1, bound2) = (bound2, bound1);
                (result.IsGreaterThanOrEqualTo(bound1) && result.IsLessThanOrEqualTo(bound2)).Should().BeTrue();
            }

            [Test, Repeat(RandomVariations)]
            public void Clamp_RandomValuesWithinBounds_ReturnsSameValue()
            {
                //arrange
                N bound1 = Random.NextNumeric<N>();
                N bound2 = Random.NextNumeric<N>();
                N input = Random.NextNumeric(bound1, bound2);

                //act
                N result = MathN.Clamp(input, bound1, bound2);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Cos_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = TestUtilities.ReduceSignificance(Random.NextNumeric<N>());
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Cos(randomValue), Conversion.Cast);

                //act
                N result = MathN.Cos(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Cos_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double lowerBound = TestUtilities.ReduceSignificance(Numeric<N>.MinValue);
                N input = ConvertN.ToNumeric<N>(lowerBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Cos(lowerBound), Conversion.Cast);

                //act
                N result = MathN.Cos(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Cos_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = TestUtilities.ReduceSignificance(Numeric<N>.MaxValue);
                N input = ConvertN.ToNumeric<N>(upperBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Cos(upperBound), Conversion.Cast);

                //act
                N result = MathN.Cos(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Cosh_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue;
                do
                {
                    randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -1 : 0, 1), 2);
                    if (Numeric<N>.IsIntegral) randomValue = Math.Round(randomValue);
                }
                while (!DoubleCompat.IsFinite(Math.Cosh(randomValue)));
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Cosh(randomValue), Conversion.Cast);

                //act
                N result = MathN.Cosh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void DegreesToRadians_SmallValue_CorrectResult()
            {
                //arrange
                int smallValue = 90;
                N input = ConvertN.ToNumeric<N>(smallValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(1.5708, Conversion.Cast);

                //act
                N result = MathN.DegreesToRadians(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Exp_Random_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -1 : 0, 4), 2);
                if (Numeric<N>.IsIntegral) randomValue = Math.Round(randomValue);
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Exp(randomValue), Conversion.Cast);

                //act
                N result = MathN.Exp(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Exp_Zero_EquivalentToSystemMath()
            {
                //arrange
                N input = ConvertN.ToNumeric<N>(0, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Exp(0d), Conversion.Cast);

                //act
                N result = MathN.Exp(input);

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Exp_One_EquivalentToSystemMath()
            {
                //arrange
                N input = ConvertN.ToNumeric<N>(1, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Exp(1d), Conversion.Cast);

                //act
                N result = MathN.Exp(input);

                //assert
                result.Should().Be(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Floor_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -10 : 0, 10), 1);
                if (Numeric<N>.IsIntegral) randomValue = Math.Round(randomValue);
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Floor(randomValue), Conversion.Cast);

                //act
                N result = MathN.Floor(input);

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Floor_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double lowerBound = TestUtilities.ReduceSignificance(Numeric<N>.MinValue.Add(Numeric<N>.One));
                if (Numeric<N>.IsIntegral) lowerBound = Math.Round(lowerBound);
                N input = ConvertN.ToNumeric<N>(lowerBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Floor(lowerBound), Conversion.Cast);

                //act
                N result = MathN.Floor(input);

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Floor_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = TestUtilities.ReduceSignificance(Numeric<N>.MaxValue.Subtract(Numeric<N>.One));
                if (Numeric<N>.IsIntegral) upperBound = Math.Round(upperBound);
                N input = ConvertN.ToNumeric<N>(upperBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Floor(upperBound), Conversion.Cast);

                //act
                N result = MathN.Floor(input);

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Floor_Zero_EquivalentToSystemMath()
            {
                //arrange
                N input = ConvertN.ToNumeric<N>(0, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Floor(0d), Conversion.Cast);

                //act
                N result = MathN.Floor(input);

                //assert
                result.Should().Be(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void IEEERemainder_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue1;
                double randomValue2;
                do
                {
                    randomValue1 = Math.Round(Random.NextDouble(0, 10));
                    randomValue2 = Math.Round(Random.NextDouble(1, 10));
                } while (Numeric<N>.IsUnsigned && Math.IEEERemainder(randomValue1, randomValue2) < 0);
                N input1 = ConvertN.ToNumeric<N>(randomValue1, Conversion.Cast);
                N input2 = ConvertN.ToNumeric<N>(randomValue2, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.IEEERemainder(randomValue1, randomValue2), Conversion.Cast);

                //act
                N result = MathN.IEEERemainder(input1, input2);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Log_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue;
                do { randomValue = TestUtilities.ReduceSignificance(Random.NextNumeric(Numeric<N>.One, Numeric<N>.MaxValue)); }
                while (!DoubleCompat.IsFinite(Math.Log(randomValue)));
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Log(randomValue), Conversion.Cast);

                //act
                N result = MathN.Log(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Log_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = ConvertN.ToDouble(Numeric<N>.Epsilon, Conversion.Cast);
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Log(randomValue), Conversion.Cast);

                //act
                N result = MathN.Log(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Log_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = TestUtilities.ReduceSignificance(Numeric<N>.MaxValue);
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Log(randomValue), Conversion.Cast);

                //act
                N result = MathN.Log(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void LogN_RandomValues_EquivalentToSystemMath()
            {
                //arrange
                double randomValue1;
                double randomValue2;
                do
                {
                    randomValue1 = TestUtilities.ReduceSignificance(Random.NextNumeric(Numeric<N>.Zero, Numeric<N>.MaxValue));
                    randomValue2 = TestUtilities.ReduceSignificance(Random.NextNumeric(Numeric<N>.One, Numeric<N>.MaxValue));
                } while (randomValue1 <= 0 || randomValue2 <= 1);
                N input1 = ConvertN.ToNumeric<N>(randomValue1, Conversion.Cast);
                N input2 = ConvertN.ToNumeric<N>(randomValue2, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Log(randomValue1, randomValue2), Conversion.Cast);

                //act
                N result = MathN.Log(input1, input2);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Log10_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = TestUtilities.ReduceSignificance(Random.NextNumeric(Numeric<N>.One, Numeric<N>.MaxValue));
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Log10(randomValue), Conversion.Cast);

                //act
                N result = MathN.Log10(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Log10_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = ConvertN.ToDouble(Numeric<N>.Epsilon, Conversion.Cast);
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Log10(randomValue), Conversion.Cast);

                //act
                N result = MathN.Log10(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Log10_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = TestUtilities.ReduceSignificance(Numeric<N>.MaxValue);
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Log10(randomValue), Conversion.Cast);

                //act
                N result = MathN.Log10(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Max_RandomValues_LargestValue()
            {
                //arrange
                N input1 = Random.NextNumeric<N>();
                N input2 = Random.NextNumeric<N>();
                N expected = input1.IsGreaterThan(input2) ? input1 : input2;

                //act
                N result = MathN.Max(input1, input2);

                //assert
                result.Should().Be(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Min_RandomValues_SmallestValue()
            {
                //arrange
                N input1 = Random.NextNumeric<N>();
                N input2 = Random.NextNumeric<N>();
                N expected = input1.IsLessThan(input2) ? input1 : input2;

                //act
                N result = MathN.Min(input1, input2);

                //assert
                result.Should().Be(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Pow_RandomValues_EquivalentToSystemMath()
            {
                //arrange
                double randomValue1 = Random.NextDouble(1, 11);
                double randomValue2 = Random.NextDouble(1, 11);
                if (Numeric<N>.IsIntegral)
                {
                    randomValue1 = Math.Truncate(randomValue1);
                    randomValue2 = Math.Truncate(randomValue2);
                }
                N input1 = ConvertN.ToNumeric<N>(randomValue1, Conversion.Cast);
                N input2 = ConvertN.ToNumeric<N>(randomValue2, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Pow(randomValue1, randomValue2), Conversion.Cast);

                //act
                N result = MathN.Pow(input1, input2);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Pow_RandomValueByZero_One()
            {
                //arrange
                N input = Random.NextNumeric<N>();

                //act
                N result = MathN.Pow(input, Numeric<N>.Zero);

                //assert
                result.Should().Be(Numeric<N>.One);
            }

            [Test, Repeat(RandomVariations)]
            public void Pow_RandomValueByOne_SameValue()
            {
                //arrange
                N input = Random.NextNumeric<N>();

                //act
                N result = MathN.Pow(input, Numeric<N>.One);

                //assert
                result.Should().Be(input);
            }

            [Test]
            public void RadiansToDegrees_SmallValue_CorrectResult()
            {
                //arrange
                int smallValue = 2;
                N input = ConvertN.ToNumeric<N>(smallValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(114.592, Conversion.Cast);

                //act
                N result = MathN.RadiansToDegrees(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Sign_RandomPositiveValue_ReturnsOne()
            {
                //arrange
                N input;
                do { input = Random.NextNumeric<N>(); }
                while (input.IsLessThanOrEqualTo(Numeric<N>.Zero));

                //act
                int result = MathN.Sign(input);

                //assert
                result.Should().Be(1);
            }

            [Test]
            public void Sign_Zero_ReturnsZero()
            {
                //arrange
                N input = Numeric<N>.Zero;

                //act
                int result = MathN.Sign(input);

                //assert
                result.Should().Be(0);
            }

            [Test, Repeat(RandomVariations)]
            public void Sin_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue;
                do
                {
                    randomValue = Random.NextDouble(Numeric<N>.IsSigned ? -10 : 0, 10);
                    if (Numeric<N>.IsIntegral) randomValue = Math.Truncate(randomValue);
                }
                while (Numeric<N>.IsUnsigned && Math.Sin(randomValue) < 0);
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Sin(randomValue), Conversion.Cast);

                //act
                N result = MathN.Sin(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Sin_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double lowerBound = TestUtilities.ReduceSignificance(Numeric<N>.MinValue);
                N input = ConvertN.ToNumeric<N>(lowerBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Sin(lowerBound), Conversion.Cast);

                //act
                N result = MathN.Sin(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Sin_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = TestUtilities.ReduceSignificance(Numeric<N>.MaxValue);
                N input = ConvertN.ToNumeric<N>(upperBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Sin(upperBound), Conversion.Cast);

                //act
                N result = MathN.Sin(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Sinh_Random_EquivalentToSystemMath()
            {
                //arrange
                double randomValue;
                do
                {
                    randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -1 : 0, 1), 2);
                    if (Numeric<N>.IsIntegral) randomValue = Math.Round(randomValue);
                }
                while (!DoubleCompat.IsFinite(Math.Sinh(randomValue)));
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Sinh(randomValue), Conversion.Cast);

                //act
                N result = MathN.Sinh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Sqrt_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = TestUtilities.ReduceSignificance(Random.NextNumeric(Numeric<N>.Zero, Numeric<N>.MaxValue));
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Sqrt(randomValue), Conversion.Cast);

                //act
                N result = MathN.Sqrt(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Sqrt_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                int lowerBound = 0;
                N input = ConvertN.ToNumeric<N>(lowerBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Sqrt(lowerBound), Conversion.Cast);

                //act
                N result = MathN.Sqrt(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Sqrt_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = TestUtilities.ReduceSignificance(Numeric<N>.MaxValue);
                N input = ConvertN.ToNumeric<N>(upperBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Sqrt(upperBound), Conversion.Cast);

                //act
                N result = MathN.Sqrt(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Tan_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -10 : 0, 10), 2);
                if (Numeric<N>.IsIntegral) randomValue = Math.Round(randomValue);
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Tan(randomValue), Conversion.Cast);

                //act
                N result = MathN.Tan(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Tan_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                int lowerBound = Numeric<N>.IsSigned ? -10 : 0;
                N input = ConvertN.ToNumeric<N>(lowerBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Tan(lowerBound), Conversion.Cast);

                //act
                N result = MathN.Tan(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Tan_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                int upperBound = 10;
                N input = ConvertN.ToNumeric<N>(upperBound, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Tan(upperBound), Conversion.Cast);

                //act
                N result = MathN.Tan(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Tanh_Random_EquivalentToSystemMath()
            {
                //arrange
                double input;
                do
                {
                    input = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -1 : 0, 1), 2);
                }
                while (!DoubleCompat.IsFinite(Math.Tanh(input)));
                N sut = ConvertN.ToNumeric<N>(input, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Tanh(input), Conversion.Cast);

                //act
                N result = MathN.Tanh(sut);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Truncate_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -10 : 0, 10), 1);
                if (Numeric<N>.IsIntegral) randomValue = Math.Round(randomValue);
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Truncate(randomValue), Conversion.Cast);

                //act
                N result = MathN.Truncate(input);

                //assert
                result.Should().Be(expected);
            }
        }

        public abstract class Integral<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric<N>.IsIntegral);

            [Test, Repeat(RandomVariations)]
            public void Round1_RandomIntegral_SameValue()
            {
                //arrange
                N input = Random.NextNumeric<N>();

                //act
                N result = MathN.Round(input);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Round2_RandomIntegral_SameValue()
            {
                //arrange
                N input = Random.NextNumeric<N>();
                int digits = Random.NextInt32(0, 10);

                //act
                N result = MathN.Round(input, digits);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Round3_RandomIntegral_SameValue()
            {
                //arrange
                N input = Random.NextNumeric<N>();
                MidpointRounding mode = Random.NextEnum<MidpointRounding>();

                //act
                N result = MathN.Round(input, mode);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Round4_RandomIntegral_SameValue()
            {
                //arrange
                N input = Random.NextNumeric<N>();
                int digits = Random.NextInt32(0, 10);
                MidpointRounding mode = Random.NextEnum<MidpointRounding>();

                //act
                N result = MathN.Round(input, digits, mode);

                //assert
                result.Should().Be(input);
            }
        }

        public abstract class Real<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric<N>.IsReal);

            [Test, Repeat(RandomVariations)]
            public void Round1_RandomReal_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -10 : 0, 10), 1);
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Round(randomValue), Conversion.Cast);

                //act
                N result = MathN.Round(input);

                //assert
                result.Should().Be(expected);
            }
        }

        public abstract class Unsigned<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric<N>.IsUnsigned);

            [Test, Repeat(RandomVariations)]
            public void Abs_Unsigned_SameValue()
            {
                //arrange
                N input = Random.NextNumeric<N>();

                //act
                N result = MathN.Abs(input);

                //assert
                result.Should().Be(input);
            }
        }

        public abstract class Signed<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric<N>.IsSigned);

            [Test, Repeat(RandomVariations)]
            public void Abs_Negative_PositiveEquivalent()
            {
                //arrange
                N input = Random.NextNumeric(Numeric<N>.MinValue.Add(Numeric<N>.MaxUnit), Numeric<N>.MinUnit);
                N expected = Numeric<N>.MinUnit.Multiply(input);

                //act
                N result = MathN.Abs(input);

                //assert
                result.Should().Be(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Sign_RandomNegativeValue_ReturnsNegativeOne()
            {
                //arrange
                N input;
                do { input = Random.NextNumeric<N>(); }
                while (input.IsGreaterThanOrEqualTo(Numeric<N>.Zero));

                //act
                int result = MathN.Sign(input);

                //assert
                result.Should().Be(-1);
            }
        }

        public abstract class FloatingPoint<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric<N>.HasFloatingPoint);

            [Test, Repeat(RandomVariations)]
            public void Round1_RandomFloatingPoint_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Random.NextDouble(Numeric<N>.IsSigned ? -10 : 0, 10);
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Round(randomValue), Conversion.Cast);

                //act
                N result = MathN.Round(input);

                //assert
                result.Should().Be(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Round2_RandomFloatingPoint_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Random.NextDouble(Numeric<N>.IsSigned ? -10 : 0, 10);
                int digits = Random.NextInt32(0, 2);
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Round(randomValue, digits), Conversion.Cast);

                //act
                N result = MathN.Round(input, digits);

                //assert
                result.Should().Be(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Round3_RandomFloatingPoint_SameValue()
            {
                //arrange
                double randomValue = Random.NextDouble(Numeric<N>.IsSigned ? -10 : 0, 10);
                MidpointRounding mode = Random.NextEnum<MidpointRounding>();
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Round(randomValue, mode), Conversion.Cast);

                //act
                N result = MathN.Round(input, mode);

                //assert
                result.Should().Be(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Round4_RandomFloatingPoint_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Random.NextDouble(Numeric<N>.IsSigned ? -10 : 0, 10);
                int digits = Random.NextInt32(0, 2);
                MidpointRounding mode = Random.NextEnum<MidpointRounding>();
                N input = ConvertN.ToNumeric<N>(randomValue, Conversion.Cast);
                N expected = ConvertN.ToNumeric<N>(Math.Round(randomValue, digits, mode), Conversion.Cast);

                //act
                N result = MathN.Round(input, digits, mode);

                //assert
                result.Should().Be(expected);
            }
        }
    }
}
