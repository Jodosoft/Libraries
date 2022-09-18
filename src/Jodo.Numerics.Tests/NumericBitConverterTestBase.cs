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
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Jodo.Primitives;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public abstract class NumericBitConverterTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [Test, Repeat(RandomVariations)]
        public void RoundTrip_RandomVariant_SameAsOriginal()
        {
            //arrange
            TNumeric input = Random.NextVariant<TNumeric>(Variants.All);

            //act
            TNumeric result = BitConverterN.ToNumeric<TNumeric>(BitConverterN.GetBytes(input), 0);

            //assert
            AssertSame.Result(() => input, () => result);
        }

        [Test, Repeat(RandomVariations)]
        public void RoundTrip_ContiguousByteArray_SameAsOriginals()
        {
            //arrange
            const int Count = 10;
            List<byte> buffer = new List<byte>();
            TNumeric[] inputs = Enumerable.Range(0, Count).Select(_ => Random.NextVariant<TNumeric>()).ToArray();
            TNumeric[] results = new TNumeric[Count];

            //act
            for (int i = 0; i < Count; i++)
            {
                buffer.AddRange(BitConverterN.GetBytes(inputs[i]));
            }
            byte[] contiguousBytes = buffer.ToArray();
            for (int i = 0; i < Count; i++)
            {
                results[i] = BitConverterN.ToNumeric<TNumeric>(contiguousBytes, i * BitConverterN.ConvertedSize<TNumeric>());
            }

            //assert
            for (int i = 0; i < Count; i++)
            {
                AssertSame.Result(() => inputs[i], () => results[i]);
            }
        }

        [Test, Repeat(RandomVariations)]
        public void GetBytes_RandomVariant_ReturnsCorrectNumberOfBytes()
        {
            //arrange
            TNumeric input = Random.NextVariant<TNumeric>(Variants.NonError);
            int expected = BitConverterN.ConvertedSize<TNumeric>();

            //act
            byte[] result = BitConverterN.GetBytes(input);

            //assert
            result.Should().HaveCount(expected);
        }

        [Test]
        public void FromBytes_NullValue_Throws()
        {
            //arrange
            //act
            Action action = new Action(() => BitConverterN.ToNumeric<TNumeric>(null, 0));

            //assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void FromBytes_ZeroLengthValue_Throws()
        {
            //arrange
            //act
            Action action = new Action(() => BitConverterN.ToNumeric<TNumeric>(Array.Empty<byte>(), 0));

            //assert
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void FromBytes_IndexOverrun_Throws()
        {
            //arrange
            //act
            Action action = new Action(() => BitConverterN.ToNumeric<TNumeric>(Random.NextBytes(100), 100));

            //assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
