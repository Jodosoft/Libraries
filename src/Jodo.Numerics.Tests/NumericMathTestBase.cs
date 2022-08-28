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
    public abstract class NumericMathTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [Test]
        public void E_EquivalentToSystemMath()
        {
            MathN.E<TNumeric>().Should().BeApproximately(ConvertN.ToNumeric<TNumeric>(Math.E, Conversion.Cast));
        }

        [Test]
        public void PI_EquivalentToSystemMath()
        {
            MathN.PI<TNumeric>().Should().BeApproximately(ConvertN.ToNumeric<TNumeric>(Math.PI, Conversion.Cast));
        }

        [Test]
        public void Tau_TwoPi()
        {
            MathN.Tau<TNumeric>().Should().BeApproximately(ConvertN.ToNumeric<TNumeric>(Math.PI * 2, Conversion.Cast));
        }

        [Test]
        public void Abs_Zero_SameValue()
        {
            //arrange
            TNumeric input = Numeric.Zero<TNumeric>();

            //act
            TNumeric result = MathN.Abs(input);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void Abs_Positive_SameValue()
        {
            //arrange
            TNumeric input = Random.NextNumeric(Numeric.Zero<TNumeric>(), Numeric.MaxValue<TNumeric>(), Generation.Extended);

            //act
            TNumeric result = MathN.Abs(input);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void Acos_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = Math.Round(Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -1 : 0, 1), 2);
            if (Numeric.IsIntegral<TNumeric>()) randomValue = Math.Round(randomValue);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Acos(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Acos(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Acos_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            int lowerBound = Numeric.IsSigned<TNumeric>() ? -1 : 0;
            TNumeric input = ConvertN.ToNumeric<TNumeric>(lowerBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Acos(lowerBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Acos(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Acos_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            int upperBound = 1;
            TNumeric input = ConvertN.ToNumeric<TNumeric>(upperBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Acos(upperBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Acos(input);

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
                if (Numeric.IsIntegral<TNumeric>()) randomValue = Math.Round(randomValue);
            }
            while (!DoubleCompat.IsFinite(MathCompat.Acosh(randomValue)));
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(MathCompat.Acosh(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Acosh(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Acosh_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            int lowerBound = 1;
            TNumeric input = ConvertN.ToNumeric<TNumeric>(lowerBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(MathCompat.Acosh(lowerBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Acosh(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Acosh_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            double upperBound = TestUtilities.ReduceSignificance(Numeric.MaxValue<TNumeric>());
            TNumeric input = ConvertN.ToNumeric<TNumeric>(upperBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(MathCompat.Acosh(upperBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Acosh(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Asin_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = Math.Round(Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -1 : 0, 1), 2);
            if (Numeric.IsIntegral<TNumeric>()) randomValue = Math.Round(randomValue);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Asin(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Asin(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Asin_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            int lowerBound = Numeric.IsSigned<TNumeric>() ? -1 : 0;
            TNumeric input = ConvertN.ToNumeric<TNumeric>(lowerBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Asin(lowerBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Asin(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Asin_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            int upperBound = 1;
            TNumeric input = ConvertN.ToNumeric<TNumeric>(upperBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Asin(upperBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Asin(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Asinh_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = Math.Round(Random.NextDouble(), 2);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(MathCompat.Asinh(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Asinh(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Asinh_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            double lowerBound = TestUtilities.ReduceSignificance(Numeric.MinValue<TNumeric>());
            TNumeric input = ConvertN.ToNumeric<TNumeric>(lowerBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(MathCompat.Asinh(lowerBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Asinh(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Asinh_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            double upperBound = TestUtilities.ReduceSignificance(Numeric.MaxValue<TNumeric>());
            TNumeric input = ConvertN.ToNumeric<TNumeric>(upperBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(MathCompat.Asinh(upperBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Asinh(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Atan_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = TestUtilities.ReduceSignificance(Random.NextNumeric<TNumeric>(Generation.Extended));
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Atan(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Atan(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Atan_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            double lowerBound = TestUtilities.ReduceSignificance(Numeric.MinValue<TNumeric>());
            TNumeric input = ConvertN.ToNumeric<TNumeric>(lowerBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Atan(lowerBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Atan(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Atan_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            double upperBound = TestUtilities.ReduceSignificance(Numeric.MaxValue<TNumeric>());
            TNumeric input = ConvertN.ToNumeric<TNumeric>(upperBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Atan(upperBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Atan(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Atan2_RandomValues_EquivalentToSystemMath()
        {
            //arrange
            double randomValue1 = TestUtilities.ReduceSignificance(Random.NextNumeric<TNumeric>(Generation.Extended));
            double randomValue2 = TestUtilities.ReduceSignificance(Random.NextNumeric<TNumeric>(Generation.Extended));
            TNumeric input1 = ConvertN.ToNumeric<TNumeric>(randomValue1, Conversion.Cast);
            TNumeric input2 = ConvertN.ToNumeric<TNumeric>(randomValue2, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Atan2(randomValue1, randomValue2), Conversion.Cast);

            //act
            TNumeric result = MathN.Atan2(input1, input2);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Atan2_RandomBoundaries_EquivalentToSystemMath()
        {
            //arrange
            double randomBoundary1 = TestUtilities.ReduceSignificance(Random.NextBoolean() ? Numeric.MinValue<TNumeric>() : Numeric.MaxValue<TNumeric>());
            double randomBoundary2 = TestUtilities.ReduceSignificance(Random.NextBoolean() ? Numeric.MinValue<TNumeric>() : Numeric.MaxValue<TNumeric>());
            TNumeric input1 = ConvertN.ToNumeric<TNumeric>(randomBoundary1, Conversion.Cast);
            TNumeric input2 = ConvertN.ToNumeric<TNumeric>(randomBoundary2, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Atan2(randomBoundary1, randomBoundary2), Conversion.Cast);

            //act
            TNumeric result = MathN.Atan2(input1, input2);

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
                randomValue = Math.Round(Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -1 : 0, 1), 2);
                if (Numeric.IsIntegral<TNumeric>()) randomValue = Math.Round(randomValue);
            }
            while (!DoubleCompat.IsFinite(MathCompat.Atanh(randomValue)));
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(MathCompat.Atanh(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Atanh(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Cbrt_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = TestUtilities.ReduceSignificance(Random.NextNumeric<TNumeric>(Generation.Extended));
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(MathCompat.Cbrt(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Cbrt(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Cbrt_Zero_EquivalentToSystemMath()
        {
            //arrange
            TNumeric input = ConvertN.ToNumeric<TNumeric>(0, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(MathCompat.Cbrt(0d), Conversion.Cast);

            //act
            TNumeric result = MathN.Cbrt(input);

            //assert
            result.Should().Be(expected);
        }

        [Test]
        public void Cbrt_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            double lowerBound = TestUtilities.ReduceSignificance(Numeric.MinValue<TNumeric>());
            TNumeric input = ConvertN.ToNumeric<TNumeric>(lowerBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(MathCompat.Cbrt(lowerBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Cbrt(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Cbrt_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            double upperBound = TestUtilities.ReduceSignificance(Numeric.MaxValue<TNumeric>());
            TNumeric input = ConvertN.ToNumeric<TNumeric>(upperBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(MathCompat.Cbrt(upperBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Cbrt(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Ceiling_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = Math.Round(Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -10 : 0, 10), 1);
            if (Numeric.IsIntegral<TNumeric>()) randomValue = Math.Round(randomValue);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Ceiling(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Ceiling(input);

            //assert
            result.Should().Be(expected);
        }

        [Test]
        public void Ceiling_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            double lowerBound = TestUtilities.ReduceSignificance(Numeric.MinValue<TNumeric>().Add(Numeric.One<TNumeric>()));
            if (Numeric.IsIntegral<TNumeric>()) lowerBound = Math.Round(lowerBound);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(lowerBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Ceiling(lowerBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Ceiling(input);

            //assert
            result.Should().Be(expected);
        }

        [Test]
        public void Ceiling_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            double upperBound = TestUtilities.ReduceSignificance(Numeric.MaxValue<TNumeric>().Subtract(Numeric.One<TNumeric>()));
            if (Numeric.IsIntegral<TNumeric>()) upperBound = Math.Floor(upperBound);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(upperBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Ceiling(upperBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Ceiling(input);

            //assert
            result.Should().Be(expected);
        }

        [Test]
        public void Ceiling_Zero_EquivalentToSystemMath()
        {
            //arrange
            TNumeric input = ConvertN.ToNumeric<TNumeric>(0, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Ceiling(0d), Conversion.Cast);

            //act
            TNumeric result = MathN.Ceiling(input);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Clamp_RandomValues_ReturnsValueWithinBounds()
        {
            //arrange
            TNumeric input = Random.NextNumeric<TNumeric>(Generation.Extended);
            TNumeric bound1 = Random.NextNumeric<TNumeric>(Generation.Extended);
            TNumeric bound2 = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            TNumeric result = MathN.Clamp(input, bound1, bound2);

            //assert
            if (bound1.IsGreaterThan(bound2)) (bound1, bound2) = (bound2, bound1);
            (result.IsGreaterThanOrEqualTo(bound1) && result.IsLessThanOrEqualTo(bound2)).Should().BeTrue();
        }

        [Test, Repeat(RandomVariations)]
        public void Clamp_RandomValuesWithinBounds_ReturnsSameValue()
        {
            //arrange
            TNumeric bound1 = Random.NextNumeric<TNumeric>(Generation.Extended);
            TNumeric bound2 = Random.NextNumeric<TNumeric>(Generation.Extended);
            TNumeric input = Random.NextNumeric(bound1, bound2, Generation.Extended);

            //act
            TNumeric result = MathN.Clamp(input, bound1, bound2);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void Cos_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = TestUtilities.ReduceSignificance(Random.NextNumeric<TNumeric>(Generation.Extended));
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Cos(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Cos(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Cos_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            double lowerBound = TestUtilities.ReduceSignificance(Numeric.MinValue<TNumeric>());
            TNumeric input = ConvertN.ToNumeric<TNumeric>(lowerBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Cos(lowerBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Cos(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Cos_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            double upperBound = TestUtilities.ReduceSignificance(Numeric.MaxValue<TNumeric>());
            TNumeric input = ConvertN.ToNumeric<TNumeric>(upperBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Cos(upperBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Cos(input);

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
                randomValue = Math.Round(Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -1 : 0, 1), 2);
                if (Numeric.IsIntegral<TNumeric>()) randomValue = Math.Round(randomValue);
            }
            while (!DoubleCompat.IsFinite(Math.Cosh(randomValue)));
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Cosh(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Cosh(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void DegreesToRadians_SmallValue_CorrectResult()
        {
            //arrange
            int smallValue = 90;
            TNumeric input = ConvertN.ToNumeric<TNumeric>(smallValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(1.5708, Conversion.Cast);

            //act
            TNumeric result = MathN.DegreesToRadians(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Exp_Random_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = Math.Round(Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -1 : 0, 4), 2);
            if (Numeric.IsIntegral<TNumeric>()) randomValue = Math.Round(randomValue);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Exp(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Exp(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Exp_Zero_EquivalentToSystemMath()
        {
            //arrange
            TNumeric input = ConvertN.ToNumeric<TNumeric>(0, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Exp(0d), Conversion.Cast);

            //act
            TNumeric result = MathN.Exp(input);

            //assert
            result.Should().Be(expected);
        }

        [Test]
        public void Exp_One_EquivalentToSystemMath()
        {
            //arrange
            TNumeric input = ConvertN.ToNumeric<TNumeric>(1, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Exp(1d), Conversion.Cast);

            //act
            TNumeric result = MathN.Exp(input);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Floor_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = Math.Round(Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -10 : 0, 10), 1);
            if (Numeric.IsIntegral<TNumeric>()) randomValue = Math.Round(randomValue);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Floor(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Floor(input);

            //assert
            result.Should().Be(expected);
        }

        [Test]
        public void Floor_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            double lowerBound = TestUtilities.ReduceSignificance(Numeric.MinValue<TNumeric>().Add(Numeric.One<TNumeric>()));
            if (Numeric.IsIntegral<TNumeric>()) lowerBound = Math.Round(lowerBound);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(lowerBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Floor(lowerBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Floor(input);

            //assert
            result.Should().Be(expected);
        }

        [Test]
        public void Floor_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            double upperBound = TestUtilities.ReduceSignificance(Numeric.MaxValue<TNumeric>().Subtract(Numeric.One<TNumeric>()));
            if (Numeric.IsIntegral<TNumeric>()) upperBound = Math.Round(upperBound);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(upperBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Floor(upperBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Floor(input);

            //assert
            result.Should().Be(expected);
        }

        [Test]
        public void Floor_Zero_EquivalentToSystemMath()
        {
            //arrange
            TNumeric input = ConvertN.ToNumeric<TNumeric>(0, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Floor(0d), Conversion.Cast);

            //act
            TNumeric result = MathN.Floor(input);

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
            } while (Numeric.IsUnsigned<TNumeric>() && Math.IEEERemainder(randomValue1, randomValue2) < 0);
            TNumeric input1 = ConvertN.ToNumeric<TNumeric>(randomValue1, Conversion.Cast);
            TNumeric input2 = ConvertN.ToNumeric<TNumeric>(randomValue2, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.IEEERemainder(randomValue1, randomValue2), Conversion.Cast);

            //act
            TNumeric result = MathN.IEEERemainder(input1, input2);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Log_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            double randomValue;
            do { randomValue = TestUtilities.ReduceSignificance(Random.NextNumeric(Numeric.One<TNumeric>(), Numeric.MaxValue<TNumeric>(), Generation.Extended)); }
            while (!DoubleCompat.IsFinite(Math.Log(randomValue)));
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Log(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Log(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Log_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = ConvertN.ToDouble(Numeric.Epsilon<TNumeric>(), Conversion.Cast);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Log(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Log(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Log_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = TestUtilities.ReduceSignificance(Numeric.MaxValue<TNumeric>());
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Log(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Log(input);

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
                randomValue1 = TestUtilities.ReduceSignificance(Random.NextNumeric(Numeric.Zero<TNumeric>(), Numeric.MaxValue<TNumeric>(), Generation.Extended));
                randomValue2 = TestUtilities.ReduceSignificance(Random.NextNumeric(Numeric.One<TNumeric>(), Numeric.MaxValue<TNumeric>(), Generation.Extended));
            } while (randomValue1 <= 0 || randomValue2 <= 1);
            TNumeric input1 = ConvertN.ToNumeric<TNumeric>(randomValue1, Conversion.Cast);
            TNumeric input2 = ConvertN.ToNumeric<TNumeric>(randomValue2, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Log(randomValue1, randomValue2), Conversion.Cast);

            //act
            TNumeric result = MathN.Log(input1, input2);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Log10_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = TestUtilities.ReduceSignificance(Random.NextNumeric(Numeric.One<TNumeric>(), Numeric.MaxValue<TNumeric>(), Generation.Extended));
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Log10(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Log10(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Log10_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = ConvertN.ToDouble(Numeric.Epsilon<TNumeric>(), Conversion.Cast);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Log10(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Log10(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Log10_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = TestUtilities.ReduceSignificance(Numeric.MaxValue<TNumeric>());
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Log10(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Log10(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Max_RandomValues_LargestValue()
        {
            //arrange
            TNumeric input1 = Random.NextNumeric<TNumeric>(Generation.Extended);
            TNumeric input2 = Random.NextNumeric<TNumeric>(Generation.Extended);
            TNumeric expected = input1.IsGreaterThan(input2) ? input1 : input2;

            //act
            TNumeric result = MathN.Max(input1, input2);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Min_RandomValues_SmallestValue()
        {
            //arrange
            TNumeric input1 = Random.NextNumeric<TNumeric>(Generation.Extended);
            TNumeric input2 = Random.NextNumeric<TNumeric>(Generation.Extended);
            TNumeric expected = input1.IsLessThan(input2) ? input1 : input2;

            //act
            TNumeric result = MathN.Min(input1, input2);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Pow_RandomValues_EquivalentToSystemMath()
        {
            //arrange
            double randomValue1 = Random.NextDouble(1, 11);
            double randomValue2 = Random.NextDouble(1, 11);
            if (Numeric.IsIntegral<TNumeric>())
            {
                randomValue1 = Math.Truncate(randomValue1);
                randomValue2 = Math.Truncate(randomValue2);
            }
            TNumeric input1 = ConvertN.ToNumeric<TNumeric>(randomValue1, Conversion.Cast);
            TNumeric input2 = ConvertN.ToNumeric<TNumeric>(randomValue2, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Pow(randomValue1, randomValue2), Conversion.Cast);

            //act
            TNumeric result = MathN.Pow(input1, input2);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Pow_RandomValueByZero_One()
        {
            //arrange
            TNumeric input = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            TNumeric result = MathN.Pow(input, Numeric.Zero<TNumeric>());

            //assert
            result.Should().Be(Numeric.One<TNumeric>());
        }

        [Test, Repeat(RandomVariations)]
        public void Pow_RandomValueByOne_SameValue()
        {
            //arrange
            TNumeric input = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            TNumeric result = MathN.Pow(input, Numeric.One<TNumeric>());

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void RadiansToDegrees_SmallValue_CorrectResult()
        {
            //arrange
            int smallValue = 2;
            TNumeric input = ConvertN.ToNumeric<TNumeric>(smallValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(114.592, Conversion.Cast);

            //act
            TNumeric result = MathN.RadiansToDegrees(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Sign_RandomPositiveValue_ReturnsOne()
        {
            //arrange
            TNumeric input = Random.NextNumeric(Numeric.Epsilon<TNumeric>(), Numeric.MaxValue<TNumeric>());

            //act
            int result = MathN.Sign(input);

            //assert
            result.Should().Be(1);
        }

        [Test]
        public void Sign_Zero_ReturnsZero()
        {
            //arrange
            TNumeric input = Numeric.Zero<TNumeric>();

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
                randomValue = Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -10 : 0, 10);
                if (Numeric.IsIntegral<TNumeric>()) randomValue = Math.Truncate(randomValue);
            }
            while (Numeric.IsUnsigned<TNumeric>() && Math.Sin(randomValue) < 0);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Sin(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Sin(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Sin_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            double lowerBound = TestUtilities.ReduceSignificance(Numeric.MinValue<TNumeric>());
            TNumeric input = ConvertN.ToNumeric<TNumeric>(lowerBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Sin(lowerBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Sin(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Sin_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            double upperBound = TestUtilities.ReduceSignificance(Numeric.MaxValue<TNumeric>());
            TNumeric input = ConvertN.ToNumeric<TNumeric>(upperBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Sin(upperBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Sin(input);

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
                randomValue = Math.Round(Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -1 : 0, 1), 2);
                if (Numeric.IsIntegral<TNumeric>()) randomValue = Math.Round(randomValue);
            }
            while (!DoubleCompat.IsFinite(Math.Sinh(randomValue)));
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Sinh(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Sinh(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Sqrt_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = TestUtilities.ReduceSignificance(Random.NextNumeric(Numeric.Zero<TNumeric>(), Numeric.MaxValue<TNumeric>(), Generation.Extended));
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Sqrt(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Sqrt(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Sqrt_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            int lowerBound = 0;
            TNumeric input = ConvertN.ToNumeric<TNumeric>(lowerBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Sqrt(lowerBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Sqrt(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Sqrt_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            double upperBound = TestUtilities.ReduceSignificance(Numeric.MaxValue<TNumeric>());
            TNumeric input = ConvertN.ToNumeric<TNumeric>(upperBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Sqrt(upperBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Sqrt(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Tan_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = Math.Round(Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -10 : 0, 10), 2);
            if (Numeric.IsIntegral<TNumeric>()) randomValue = Math.Round(randomValue);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Tan(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Tan(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Tan_LowerBound_EquivalentToSystemMath()
        {
            //arrange
            int lowerBound = Numeric.IsSigned<TNumeric>() ? -10 : 0;
            TNumeric input = ConvertN.ToNumeric<TNumeric>(lowerBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Tan(lowerBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Tan(input);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test]
        public void Tan_UpperBound_EquivalentToSystemMath()
        {
            //arrange
            int upperBound = 10;
            TNumeric input = ConvertN.ToNumeric<TNumeric>(upperBound, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Tan(upperBound), Conversion.Cast);

            //act
            TNumeric result = MathN.Tan(input);

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
                input = Math.Round(Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -1 : 0, 1), 2);
            }
            while (!DoubleCompat.IsFinite(Math.Tanh(input)));
            TNumeric sut = ConvertN.ToNumeric<TNumeric>(input, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Tanh(input), Conversion.Cast);

            //act
            TNumeric result = MathN.Tanh(sut);

            //assert
            result.Should().BeApproximately(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Truncate_RandomValue_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = Math.Round(Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -10 : 0, 10), 1);
            if (Numeric.IsIntegral<TNumeric>()) randomValue = Math.Round(randomValue);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Truncate(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Truncate(input);

            //assert
            result.Should().Be(expected);
        }
    }
}
