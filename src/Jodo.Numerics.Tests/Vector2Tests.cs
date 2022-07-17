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
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public class Vector2Tests : AssemblyFixtureBase
    {
        public sealed class FixedPoint : General<Fix64> { }
        public sealed class FloatingPoint : General<SingleN> { }
        public sealed class UnsignedIntegral : General<ByteN> { }

        [Test]
        public void Dot_WorkedExample_CorrectResult()
        {
            //arrange
            //act
            SingleN result = Vector2<SingleN>.Dot(
                new Vector2<SingleN>(2, -4), new Vector2<SingleN>(-8, 104));

            //assert
            result.Should().Be(-432);
        }

        public abstract class General<N> : AssemblyFixtureBase where N : struct, INumeric<N>
        {
            public sealed class BitConverter : Primitives.Tests.BitConverterTests<Unit<N>> { }
            public sealed class StringParser : Primitives.Tests.StringParserTests<Unit<N>> { }

            [Test, Repeat(RandomVariations)]
            public void Ctor_RandomValues_CorrectResult()
            {
                //arrange
                N x = Random.NextNumeric<N>();
                N y = Random.NextNumeric<N>();

                //act
                Vector2<N> result = new Vector2<N>(x, y);

                //assert
                result.X.Should().Be(x);
                result.Y.Should().Be(y);
            }

            [Test, Repeat(RandomVariations)]
            public void Random_WithinBounds_CorrectResult()
            {
                //arrange
                Vector2<N> bound1 = Random.NextRandomizable<Vector2<N>>();
                Vector2<N> bound2 = Random.NextRandomizable<Vector2<N>>();

                //act
                Vector2<N> result = Random.NextRandomizable(bound1, bound2);

                //assert
                result.X.Should().BeInRange(MathN.Min(bound1.X, bound2.X), MathN.Max(bound1.X, bound2.X));
                result.Y.Should().BeInRange(MathN.Min(bound1.Y, bound2.Y), MathN.Max(bound1.Y, bound2.Y));
            }

            [Test, Repeat(RandomVariations)]
            public void Dot_RandomValues_CorrectResult()
            {
                //arrange
                Vector2<N> input1 = Random.NextVector2<N>(TestBounds.HighMagnitude | TestBounds.LowSignificance);
                Vector2<N> input2 = Random.NextVector2<N>(TestBounds.HighMagnitude | TestBounds.LowSignificance);

                //act
                //assert
                Same.Outcome(
                    () => Vector2<N>.Dot(input1, input2),
                    () => input1.X.Multiply(input2.X).Add(input1.Y.Multiply(input2.Y)));
            }

            [Test, Repeat(RandomVariations)]
            public void Multiply1_RandomValues_CorrectResult()
            {
                //arrange
                Vector2<N> input1 = Random.NextVector2<N>(TestBounds.Positive | TestBounds.HighMagnitude);
                Vector2<N> input2 = Random.NextVector2<N>();

                //act
                //assert
                Same.Outcome(
                    () => Vector2<N>.Multiply(input1, input2),
                    () => new Vector2<N>(input1.X.Multiply(input2.X), input1.Y.Multiply(input2.Y)));
            }

            [Test, Repeat(RandomVariations)]
            public void Multiply2_RandomValues_CorrectResult()
            {
                //arrange
                Vector2<N> input1 = Random.NextVector2<N>();
                N input2 = Random.NextNumeric<N>();

                //act
                //assert
                Same.Outcome(
                    () => Vector2<N>.Multiply(input1, input2),
                    () => new Vector2<N>(input1.X.Multiply(input2), input1.Y.Multiply(input2)));
            }

            [Test, Repeat(RandomVariations)]
            public void Multiply3_RandomValues_CorrectResult()
            {
                //arrange
                N input1 = Random.NextNumeric<N>();
                Vector2<N> input2 = Random.NextVector2<N>();

                //act
                //assert
                Same.Outcome(
                    () => Vector2<N>.Multiply(input1, input2),
                    () => new Vector2<N>(input1.Multiply(input2.X), input1.Multiply(input2.Y)));
            }

            [Test, Repeat(RandomVariations)]
            public void Add_RandomValues_CorrectResult()
            {
                //arrange
                Vector2<N> input1 = Random.NextVector2<N>();
                Vector2<N> input2 = Random.NextVector2<N>();

                //act
                //assert
                Same.Outcome(
                    () => Vector2<N>.Add(input1, input2),
                    () => new Vector2<N>(input1.X.Add(input2.X), input1.Y.Add(input2.Y)));
            }

            [Test, Repeat(RandomVariations)]
            public void Subtract_RandomValues_CorrectResult()
            {
                //arrange
                Vector2<N> input1 = Random.NextVector2<N>();
                Vector2<N> input2 = Random.NextVector2<N>();

                //act
                //assert
                Same.Outcome(
                    () => Vector2<N>.Subtract(input1, input2),
                    () => new Vector2<N>(input1.X.Subtract(input2.X), input1.Y.Subtract(input2.Y)));
            }

            [Test, Repeat(RandomVariations)]
            public void Divide1_RandomValues_CorrectResult()
            {
                //arrange
                Vector2<N> input1 = Random.NextVector2<N>();
                Vector2<N> input2 = Random.NextVector2<N>(TestBounds.HighMagnitude);

                //act
                //assert
                Same.Outcome(
                    () => Vector2<N>.Divide(input1, input2),
                    () => new Vector2<N>(input1.X.Divide(input2.X), input1.Y.Divide(input2.Y)));
            }

            [Test, Repeat(RandomVariations)]
            public void Divide2_RandomValues_CorrectResult()
            {
                //arrange
                Vector2<N> input1 = Random.NextVector2<N>();
                N input2 = Random.NextNumeric<N>(TestBounds.HighMagnitude);

                //act
                //assert
                Same.Outcome(
                    () => Vector2<N>.Divide(input1, input2),
                    () => new Vector2<N>(input1.X.Divide(input2), input1.Y.Divide(input2)));
            }

            [Test, Repeat(RandomVariations)]
            public void SquareRoot_RandomValues_CorrectResult()
            {
                //arrange
                Vector2<N> input = Random.NextVector2<N>(TestBounds.Positive | TestBounds.HighMagnitude);

                //act
                //assert
                Same.Outcome(
                    () => Vector2<N>.SquareRoot(input),
                    () => new Vector2<N>(MathN.Sqrt(input.X), MathN.Sqrt(input.Y)));
            }

            [Test, Repeat(RandomVariations)]
            public void Negate_RandomValues_CorrectResult()
            {
                //arrange
                Vector2<N> input = Random.NextVector2<N>();

                //act
                //assert
                Same.Outcome(
                    () => Vector2<N>.Negate(input),
                    () => new Vector2<N>(input.X.Negative(), input.Y.Negative()));
            }

            [Test, Repeat(RandomVariations)]
            public void Max_RandomValues_CorrectResult()
            {
                //arrange
                Vector2<N> input1 = Random.NextVector2<N>();
                Vector2<N> input2 = Random.NextVector2<N>();

                //act
                //assert
                Same.Outcome(
                    () => Vector2<N>.Max(input1, input2),
                    () => new Vector2<N>(MathN.Max(input1.X, input2.X), MathN.Max(input1.Y, input2.Y)));
            }

            [Test, Repeat(RandomVariations)]
            public void Min_RandomValues_CorrectResult()
            {
                //arrange
                Vector2<N> input1 = Random.NextVector2<N>();
                Vector2<N> input2 = Random.NextVector2<N>();

                //act
                //assert
                Same.Outcome(
                    () => Vector2<N>.Min(input1, input2),
                    () => new Vector2<N>(MathN.Min(input1.X, input2.X), MathN.Min(input1.Y, input2.Y)));
            }
        }
    }
}
