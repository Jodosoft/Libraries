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

namespace Jodo.Numerics.Tests
{
    public abstract class BitConverterTests<N> : Primitives.Tests.BitConverterTests<N> where N : struct, INumeric<N>
    {
#if NETSTANDARD2_1_OR_GREATER
        [Test, Repeat(RandomVariations)]
        public void GetBytes_RandomSmallValue_SameAsOriginal()
        {
            //arrange
            N input = Random.NextNumeric(Numeric<N>.MinUnit, Numeric<N>.MaxUnit);

            //act
            N result = BitConverter<N>.FromBytes(BitConverter<N>.GetBytes(input));

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void GetBytes_MaxValueRoundTrip_SameAsOriginal()
        {
            //arrange
            N input = Numeric<N>.MaxValue;

            //act
            N result = BitConverter<N>.FromBytes(BitConverter<N>.GetBytes(input));

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void GetBytes_MinValueRoundTrip_SameAsOriginal()
        {
            //arrange
            N input = Numeric<N>.MinValue;

            //act
            N result = BitConverter<N>.FromBytes(BitConverter<N>.GetBytes(input));

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void GetBytes_EpsilonRoundTrip_SameAsOriginal()
        {
            //arrange
            N input = Numeric<N>.Epsilon;

            //act
            N result = BitConverter<N>.FromBytes(BitConverter<N>.GetBytes(input));

            //assert
            result.Should().Be(input);
        }
#endif
    }
}
