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
using Jodo.Extensions.Testing;
using NUnit.Framework;

namespace Jodo.Extensions.Numerics.Tests
{
    public static class MathTests
    {
        [Timeout(1000)]
        public abstract class General<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [Test]
            public void E_EquivalentToSystemMath()
            {
                Math<N>.E.Should().BeApproximately(Cast<N>.ToNumeric(Math.E));
            }

            [Test]
            public void PI_EquivalentToSystemMath()
            {
                Math<N>.PI.Should().BeApproximately(Cast<N>.ToNumeric(Math.PI));
            }

            [Test]
            public void Tau_TwoPi()
            {
                Math<N>.Tau.Should().BeApproximately(Cast<N>.ToNumeric(Math.PI * 2));
            }

            [Test]
            public void Abs_Zero_SameValue()
            {
                //arrange
                N input = Numeric<N>.Zero;

                //act
                N result = Math<N>.Abs(input);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Abs_Positive_SameValue()
            {
                //arrange
                N input = Random.NextNumeric(Numeric<N>.Zero, Numeric<N>.MaxValue);

                //act
                N result = Math<N>.Abs(input);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Acos_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -1 : 0, 1), 2);
                if (!Numeric<N>.IsReal) randomValue = Math.Round(randomValue);
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Acos(randomValue));

                //act
                N result = Math<N>.Acos(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Acos_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                int lowerBound = Numeric<N>.IsSigned ? -1 : 0;
                N input = Cast<N>.ToNumeric(lowerBound);
                N expected = Cast<N>.ToNumeric(Math.Acos(lowerBound));

                //act
                N result = Math<N>.Acos(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Acos_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                int upperBound = 1;
                N input = Cast<N>.ToNumeric(upperBound);
                N expected = Cast<N>.ToNumeric(Math.Acos(upperBound));

                //act
                N result = Math<N>.Acos(input);

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
                    if (!Numeric<N>.IsReal) randomValue = Math.Round(randomValue);
                }
                while (!double.IsFinite(Math.Acosh(randomValue)));
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Acosh(randomValue));

                //act
                N result = Math<N>.Acosh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Acosh_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                int lowerBound = 1;
                N input = Cast<N>.ToNumeric(lowerBound);
                N expected = Cast<N>.ToNumeric(Math.Acosh(lowerBound));

                //act
                N result = Math<N>.Acosh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Acosh_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = Utilities.ClosestTestableDouble(Numeric<N>.MaxValue);
                N input = Cast<N>.ToNumeric(upperBound);
                N expected = Cast<N>.ToNumeric(Math.Acosh(upperBound));

                //act
                N result = Math<N>.Acosh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Asin_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -1 : 0, 1), 2);
                if (!Numeric<N>.IsReal) randomValue = Math.Round(randomValue);
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Asin(randomValue));

                //act
                N result = Math<N>.Asin(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Asin_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                int lowerBound = Numeric<N>.IsSigned ? -1 : 0;
                N input = Cast<N>.ToNumeric(lowerBound);
                N expected = Cast<N>.ToNumeric(Math.Asin(lowerBound));

                //act
                N result = Math<N>.Asin(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Asin_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                int upperBound = 1;
                N input = Cast<N>.ToNumeric(upperBound);
                N expected = Cast<N>.ToNumeric(Math.Asin(upperBound));

                //act
                N result = Math<N>.Asin(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Asinh_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(), 2);
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Asinh(randomValue));

                //act
                N result = Math<N>.Asinh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Asinh_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double lowerBound = Utilities.ClosestTestableDouble(Numeric<N>.MinValue);
                N input = Cast<N>.ToNumeric(lowerBound);
                N expected = Cast<N>.ToNumeric(Math.Asinh(lowerBound));

                //act
                N result = Math<N>.Asinh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Asinh_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = Utilities.ClosestTestableDouble(Numeric<N>.MaxValue);
                N input = Cast<N>.ToNumeric(upperBound);
                N expected = Cast<N>.ToNumeric(Math.Asinh(upperBound));

                //act
                N result = Math<N>.Asinh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Atan_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Utilities.ClosestTestableDouble(Random.NextNumeric<N>());
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Atan(randomValue));

                //act
                N result = Math<N>.Atan(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Atan_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double lowerBound = Utilities.ClosestTestableDouble(Numeric<N>.MinValue);
                N input = Cast<N>.ToNumeric(lowerBound);
                N expected = Cast<N>.ToNumeric(Math.Atan(lowerBound));

                //act
                N result = Math<N>.Atan(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Atan_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = Utilities.ClosestTestableDouble(Numeric<N>.MaxValue);
                N input = Cast<N>.ToNumeric(upperBound);
                N expected = Cast<N>.ToNumeric(Math.Atan(upperBound));

                //act
                N result = Math<N>.Atan(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Atan2_RandomValues_EquivalentToSystemMath()
            {
                //arrange
                double randomValue1 = Utilities.ClosestTestableDouble(Random.NextNumeric<N>());
                double randomValue2 = Utilities.ClosestTestableDouble(Random.NextNumeric<N>());
                N input1 = Cast<N>.ToNumeric(randomValue1);
                N input2 = Cast<N>.ToNumeric(randomValue2);
                N expected = Cast<N>.ToNumeric(Math.Atan2(randomValue1, randomValue2));

                //act
                N result = Math<N>.Atan2(input1, input2);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Atan2_RandomBoundaries_EquivalentToSystemMath()
            {
                //arrange
                double randomBoundary1 = Utilities.ClosestTestableDouble(Random.NextBoolean() ? Numeric<N>.MinValue : Numeric<N>.MaxValue);
                double randomBoundary2 = Utilities.ClosestTestableDouble(Random.NextBoolean() ? Numeric<N>.MinValue : Numeric<N>.MaxValue);
                N input1 = Cast<N>.ToNumeric(randomBoundary1);
                N input2 = Cast<N>.ToNumeric(randomBoundary2);
                N expected = Cast<N>.ToNumeric(Math.Atan2(randomBoundary1, randomBoundary2));

                //act
                N result = Math<N>.Atan2(input1, input2);

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
                    if (!Numeric<N>.IsReal) randomValue = Math.Round(randomValue);
                }
                while (!double.IsFinite(Math.Atanh(randomValue)));
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Atanh(randomValue));

                //act
                N result = Math<N>.Atanh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Cbrt_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Utilities.ClosestTestableDouble(Random.NextNumeric<N>());
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Cbrt(randomValue));

                //act
                N result = Math<N>.Cbrt(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Cbrt_Zero_EquivalentToSystemMath()
            {
                //arrange
                N input = Cast<N>.ToNumeric(0);
                N expected = Cast<N>.ToNumeric(Math.Cbrt(0d));

                //act
                N result = Math<N>.Cbrt(input);

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Cbrt_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double lowerBound = Utilities.ClosestTestableDouble(Numeric<N>.MinValue);
                N input = Cast<N>.ToNumeric(lowerBound);
                N expected = Cast<N>.ToNumeric(Math.Cbrt(lowerBound));

                //act
                N result = Math<N>.Cbrt(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Cbrt_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = Utilities.ClosestTestableDouble(Numeric<N>.MaxValue);
                N input = Cast<N>.ToNumeric(upperBound);
                N expected = Cast<N>.ToNumeric(Math.Cbrt(upperBound));

                //act
                N result = Math<N>.Cbrt(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Ceiling_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -10 : 0, 10), 1);
                if (!Numeric<N>.IsReal) randomValue = Math.Round(randomValue);
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Ceiling(randomValue));

                //act
                N result = Math<N>.Ceiling(input);

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Ceiling_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double lowerBound = Utilities.ClosestTestableDouble(Numeric<N>.MinValue + Numeric<N>.One);
                if (!Numeric<N>.IsReal) lowerBound = Math.Round(lowerBound);
                N input = Cast<N>.ToNumeric(lowerBound);
                N expected = Cast<N>.ToNumeric(Math.Ceiling(lowerBound));

                //act
                N result = Math<N>.Ceiling(input);

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Ceiling_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = Utilities.ClosestTestableDouble(Numeric<N>.MaxValue - Numeric<N>.One);
                if (!Numeric<N>.IsReal) upperBound = Math.Floor(upperBound);
                N input = Cast<N>.ToNumeric(upperBound);
                N expected = Cast<N>.ToNumeric(Math.Ceiling(upperBound));

                //act
                N result = Math<N>.Ceiling(input);

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Ceiling_Zero_EquivalentToSystemMath()
            {
                //arrange
                N input = Cast<N>.ToNumeric(0);
                N expected = Cast<N>.ToNumeric(Math.Ceiling(0d));

                //act
                N result = Math<N>.Ceiling(input);

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
                N result = Math<N>.Clamp(input, bound1, bound2);

                //assert
                if (bound1 > bound2) (bound1, bound2) = (bound2, bound1);
                (result >= bound1 && result <= bound2).Should().BeTrue();
            }

            [Test, Repeat(RandomVariations)]
            public void Clamp_RandomValuesWithinBounds_ReturnsSameValue()
            {
                //arrange
                N bound1 = Random.NextNumeric<N>();
                N bound2 = Random.NextNumeric<N>();
                N input = Random.NextNumeric(bound1, bound2);

                //act
                N result = Math<N>.Clamp(input, bound1, bound2);

                //assert
                result.Should().Be(input);
            }

            [Test, Repeat(RandomVariations)]
            public void Cos_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Utilities.ClosestTestableDouble(Random.NextNumeric<N>());
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Cos(randomValue));

                //act
                N result = Math<N>.Cos(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Cos_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double lowerBound = Utilities.ClosestTestableDouble(Numeric<N>.MinValue);
                N input = Cast<N>.ToNumeric(lowerBound);
                N expected = Cast<N>.ToNumeric(Math.Cos(lowerBound));

                //act
                N result = Math<N>.Cos(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Cos_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = Utilities.ClosestTestableDouble(Numeric<N>.MaxValue);
                N input = Cast<N>.ToNumeric(upperBound);
                N expected = Cast<N>.ToNumeric(Math.Cos(upperBound));

                //act
                N result = Math<N>.Cos(input);

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
                    if (!Numeric<N>.IsReal) randomValue = Math.Round(randomValue);
                }
                while (!double.IsFinite(Math.Cosh(randomValue)));
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Cosh(randomValue));

                //act
                N result = Math<N>.Cosh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void DegreesToRadians_SmallValue_CorrectResult()
            {
                //arrange
                int smallValue = 90;
                N input = Cast<N>.ToNumeric(smallValue);
                N expected = Cast<N>.ToNumeric(1.5708);

                //act
                N result = Math<N>.DegreesToRadians(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Exp_Random_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -1 : 0, 4), 2);
                if (!Numeric<N>.IsReal) randomValue = Math.Round(randomValue);
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Exp(randomValue));

                //act
                N result = Math<N>.Exp(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Exp_Zero_EquivalentToSystemMath()
            {
                //arrange
                N input = Cast<N>.ToNumeric(0);
                N expected = Cast<N>.ToNumeric(Math.Exp(0d));

                //act
                N result = Math<N>.Exp(input);

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Exp_One_EquivalentToSystemMath()
            {
                //arrange
                N input = Cast<N>.ToNumeric(1);
                N expected = Cast<N>.ToNumeric(Math.Exp(1d));

                //act
                N result = Math<N>.Exp(input);

                //assert
                result.Should().Be(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Floor_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -10 : 0, 10), 1);
                if (!Numeric<N>.IsReal) randomValue = Math.Round(randomValue);
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Floor(randomValue));

                //act
                N result = Math<N>.Floor(input);

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Floor_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double lowerBound = Utilities.ClosestTestableDouble(Numeric<N>.MinValue + Numeric<N>.One);
                if (!Numeric<N>.IsReal) lowerBound = Math.Round(lowerBound);
                N input = Cast<N>.ToNumeric(lowerBound);
                N expected = Cast<N>.ToNumeric(Math.Floor(lowerBound));

                //act
                N result = Math<N>.Floor(input);

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Floor_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = Utilities.ClosestTestableDouble(Numeric<N>.MaxValue - Numeric<N>.One);
                if (!Numeric<N>.IsReal) upperBound = Math.Round(upperBound);
                N input = Cast<N>.ToNumeric(upperBound);
                N expected = Cast<N>.ToNumeric(Math.Floor(upperBound));

                //act
                N result = Math<N>.Floor(input);

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void Floor_Zero_EquivalentToSystemMath()
            {
                //arrange
                N input = Cast<N>.ToNumeric(0);
                N expected = Cast<N>.ToNumeric(Math.Floor(0d));

                //act
                N result = Math<N>.Floor(input);

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
                } while (!Numeric<N>.IsSigned && Math.IEEERemainder(randomValue1, randomValue2) < 0);
                N input1 = Cast<N>.ToNumeric(randomValue1);
                N input2 = Cast<N>.ToNumeric(randomValue2);
                N expected = Cast<N>.ToNumeric(Math.IEEERemainder(randomValue1, randomValue2));

                //act
                N result = Math<N>.IEEERemainder(input1, input2);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Log_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue;
                do { randomValue = Utilities.ClosestTestableDouble(Random.NextNumeric(Numeric<N>.One, Numeric<N>.MaxValue)); }
                while (!double.IsFinite(Math.Log(randomValue)));
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Log(randomValue));

                //act
                N result = Math<N>.Log(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Log_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Cast<N>.ToDouble(Numeric<N>.Epsilon);
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Log(randomValue));

                //act
                N result = Math<N>.Log(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Log_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Utilities.ClosestTestableDouble(Numeric<N>.MaxValue);
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Log(randomValue));

                //act
                N result = Math<N>.Log(input);

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
                    randomValue1 = Utilities.ClosestTestableDouble(Random.NextNumeric(Numeric<N>.Zero, Numeric<N>.MaxValue));
                    randomValue2 = Utilities.ClosestTestableDouble(Random.NextNumeric(Numeric<N>.One, Numeric<N>.MaxValue));
                } while (randomValue1 <= 0 || randomValue2 <= 1);
                N input1 = Cast<N>.ToNumeric(randomValue1);
                N input2 = Cast<N>.ToNumeric(randomValue2);
                N expected = Cast<N>.ToNumeric(Math.Log(randomValue1, randomValue2));

                //act
                N result = Math<N>.Log(input1, input2);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Log10_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Utilities.ClosestTestableDouble(Random.NextNumeric(Numeric<N>.One, Numeric<N>.MaxValue));
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Log10(randomValue));

                //act
                N result = Math<N>.Log10(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Log10_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Cast<N>.ToDouble(Numeric<N>.Epsilon);
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Log10(randomValue));

                //act
                N result = Math<N>.Log10(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Log10_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Utilities.ClosestTestableDouble(Numeric<N>.MaxValue);
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Log10(randomValue));

                //act
                N result = Math<N>.Log10(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Max_RandomValues_LargestValue()
            {
                //arrange
                N input1 = Random.NextNumeric<N>();
                N input2 = Random.NextNumeric<N>();
                N expected = input1 > input2 ? input1 : input2;

                //act
                N result = Math<N>.Max(input1, input2);

                //assert
                result.Should().Be(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Min_RandomValues_SmallestValue()
            {
                //arrange
                N input1 = Random.NextNumeric<N>();
                N input2 = Random.NextNumeric<N>();
                N expected = input1 < input2 ? input1 : input2;

                //act
                N result = Math<N>.Min(input1, input2);

                //assert
                result.Should().Be(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Pow_RandomValues_EquivalentToSystemMath()
            {
                //arrange
                double randomValue1 = Random.NextDouble(1, 11);
                double randomValue2 = Random.NextDouble(1, 11);
                if (!Numeric<N>.IsReal)
                {
                    randomValue1 = Math.Truncate(randomValue1);
                    randomValue2 = Math.Truncate(randomValue2);
                }
                N input1 = Cast<N>.ToNumeric(randomValue1);
                N input2 = Cast<N>.ToNumeric(randomValue2);
                N expected = Cast<N>.ToNumeric(Math.Pow(randomValue1, randomValue2));

                //act
                N result = Math<N>.Pow(input1, input2);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Pow_RandomValueByZero_One()
            {
                //arrange
                N input = Random.NextNumeric<N>();

                //act
                N result = Math<N>.Pow(input, Numeric<N>.Zero);

                //assert
                result.Should().Be(Numeric<N>.One);
            }

            [Test, Repeat(RandomVariations)]
            public void Pow_RandomValueByOne_SameValue()
            {
                //arrange
                N input = Random.NextNumeric<N>();

                //act
                N result = Math<N>.Pow(input, Numeric<N>.One);

                //assert
                result.Should().Be(input);
            }

            [Test]
            public void RadiansToDegrees_SmallValue_CorrectResult()
            {
                //arrange
                int smallValue = 2;
                N input = Cast<N>.ToNumeric(smallValue);
                N expected = Cast<N>.ToNumeric(114.592);

                //act
                N result = Math<N>.RadiansToDegrees(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Sign_RandomPositiveValue_ReturnsOne()
            {
                //arrange
                N input;
                do { input = Random.NextNumeric<N>(); }
                while (input <= Numeric<N>.Zero);

                //act
                int result = Math<N>.Sign(input);

                //assert
                result.Should().Be(1);
            }

            [Test]
            public void Sign_Zero_ReturnsZero()
            {
                //arrange
                N input = Numeric<N>.Zero;

                //act
                int result = Math<N>.Sign(input);

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
                    if (!Numeric<N>.IsReal) randomValue = Math.Truncate(randomValue);
                }
                while (!Numeric<N>.IsSigned && Math.Sin(randomValue) < 0);
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Sin(randomValue));

                //act
                N result = Math<N>.Sin(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Sin_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                double lowerBound = Utilities.ClosestTestableDouble(Numeric<N>.MinValue);
                N input = Cast<N>.ToNumeric(lowerBound);
                N expected = Cast<N>.ToNumeric(Math.Sin(lowerBound));

                //act
                N result = Math<N>.Sin(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Sin_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = Utilities.ClosestTestableDouble(Numeric<N>.MaxValue);
                N input = Cast<N>.ToNumeric(upperBound);
                N expected = Cast<N>.ToNumeric(Math.Sin(upperBound));

                //act
                N result = Math<N>.Sin(input);

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
                    if (!Numeric<N>.IsReal) randomValue = Math.Round(randomValue);
                }
                while (!double.IsFinite(Math.Sinh(randomValue)));
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Sinh(randomValue));

                //act
                N result = Math<N>.Sinh(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Sqrt_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Utilities.ClosestTestableDouble(Random.NextNumeric(Numeric<N>.Zero, Numeric<N>.MaxValue));
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Sqrt(randomValue));

                //act
                N result = Math<N>.Sqrt(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Sqrt_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                int lowerBound = 0;
                N input = Cast<N>.ToNumeric(lowerBound);
                N expected = Cast<N>.ToNumeric(Math.Sqrt(lowerBound));

                //act
                N result = Math<N>.Sqrt(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Sqrt_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                double upperBound = Utilities.ClosestTestableDouble(Numeric<N>.MaxValue);
                N input = Cast<N>.ToNumeric(upperBound);
                N expected = Cast<N>.ToNumeric(Math.Sqrt(upperBound));

                //act
                N result = Math<N>.Sqrt(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Tan_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -10 : 0, 10), 2);
                if (!Numeric<N>.IsReal) randomValue = Math.Round(randomValue);
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Tan(randomValue));

                //act
                N result = Math<N>.Tan(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Tan_LowerBound_EquivalentToSystemMath()
            {
                //arrange
                int lowerBound = Numeric<N>.IsSigned ? -10 : 0;
                N input = Cast<N>.ToNumeric(lowerBound);
                N expected = Cast<N>.ToNumeric(Math.Tan(lowerBound));

                //act
                N result = Math<N>.Tan(input);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test]
            public void Tan_UpperBound_EquivalentToSystemMath()
            {
                //arrange
                int upperBound = 10;
                N input = Cast<N>.ToNumeric(upperBound);
                N expected = Cast<N>.ToNumeric(Math.Tan(upperBound));

                //act
                N result = Math<N>.Tan(input);

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
                while (!double.IsFinite(Math.Tanh(input)));
                N sut = Cast<N>.ToNumeric(input);
                N expected = Cast<N>.ToNumeric(Math.Tanh(input));

                //act
                N result = Math<N>.Tanh(sut);

                //assert
                result.Should().BeApproximately(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Truncate_RandomValue_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Math.Round(Random.NextDouble(Numeric<N>.IsSigned ? -10 : 0, 10), 1);
                if (!Numeric<N>.IsReal) randomValue = Math.Round(randomValue);
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Truncate(randomValue));

                //act
                N result = Math<N>.Truncate(input);

                //assert
                result.Should().Be(expected);
            }
        }

        public abstract class Integral<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(!Numeric<N>.IsReal);

            [Test, Repeat(RandomVariations)]
            public void Round1_RandomIntegral_SameValue()
            {
                //arrange
                N input = Random.NextNumeric<N>();

                //act
                N result = Math<N>.Round(input);

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
                N result = Math<N>.Round(input, digits);

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
                N result = Math<N>.Round(input, mode);

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
                N result = Math<N>.Round(input, digits, mode);

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
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Round(randomValue));

                //act
                N result = Math<N>.Round(input);

                //assert
                result.Should().Be(expected);
            }
        }

        public abstract class Unsigned<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(!Numeric<N>.IsSigned);

            [Test, Repeat(RandomVariations)]
            public void Abs_Unsigned_SameValue()
            {
                //arrange
                N input = Random.NextNumeric<N>();

                //act
                N result = Math<N>.Abs(input);

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
                N input = Random.NextNumeric(Numeric<N>.MinValue + Numeric<N>.MaxUnit, Numeric<N>.MinUnit);
                N expected = Numeric<N>.MinUnit * input;

                //act
                N result = Math<N>.Abs(input);

                //assert
                result.Should().Be(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Sign_RandomNegativeValue_ReturnsNegativeOne()
            {
                //arrange
                N input;
                do { input = Random.NextNumeric<N>(); }
                while (input >= Numeric<N>.Zero);

                //act
                int result = Math<N>.Sign(input);

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
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Round(randomValue));

                //act
                N result = Math<N>.Round(input);

                //assert
                result.Should().Be(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Round2_RandomFloatingPoint_EquivalentToSystemMath()
            {
                //arrange
                double randomValue = Random.NextDouble(Numeric<N>.IsSigned ? -10 : 0, 10);
                int digits = Random.NextInt32(0, 2);
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Round(randomValue, digits));

                //act
                N result = Math<N>.Round(input, digits);

                //assert
                result.Should().Be(expected);
            }

            [Test, Repeat(RandomVariations)]
            public void Round3_RandomFloatingPoint_SameValue()
            {
                //arrange
                double randomValue = Random.NextDouble(Numeric<N>.IsSigned ? -10 : 0, 10);
                MidpointRounding mode = Random.NextEnum<MidpointRounding>();
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Round(randomValue, mode));

                //act
                N result = Math<N>.Round(input, mode);

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
                N input = Cast<N>.ToNumeric(randomValue);
                N expected = Cast<N>.ToNumeric(Math.Round(randomValue, digits, mode));

                //act
                N result = Math<N>.Round(input, digits, mode);

                //assert
                result.Should().Be(expected);
            }
        }
    }
}
