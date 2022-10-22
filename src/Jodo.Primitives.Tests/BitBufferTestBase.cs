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
using System.IO;
using System.Linq;
using FluentAssertions;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Primitives.Tests
{
    /// <summary>
    /// Provides common test methods for types that implement <see cref="IProvider{IBitBuffer{T}}"/>
    /// </summary>
    /// <typeparam name="T">The type of struct.</typeparam>
    public abstract class BitBufferTestBase<T> : GlobalFixtureBase where T : struct, IProvider<IBitBuffer<T>>, IProvider<IVariantRandom<T>>
    {
        [Test, Repeat(RandomVariations)]
        public void Serialise_RandomValues_ReadsBackSameValues()
        {
            //arrange
            T[] inputs = Enumerable
                .Range(0, Random.Next(10))
                .Select(_ => Random.NextVariant<T>(Variants.NonError))
                .ToArray();

            //act
            byte[] buffer = inputs.SelectMany(x => BitBuffer.Serialize(x)).ToArray();
            using Stream stream = new MemoryStream(buffer);
            stream.Position = 0;
            T[] results = new T[inputs.Length];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = BitBuffer.Read<T>(stream);
            }

            //assert
            results.Should().BeEquivalentTo(inputs);
        }

        [Test, Repeat(RandomVariations)]
        public void SerialiseAsync_RandomValues_RoundTripsTwice()
        {
            //arrange
            T[] inputs = Enumerable
                .Range(0, Random.Next(10))
                .Select(_ => Random.NextVariant<T>(Variants.NonError))
                .ToArray();

            //act
            byte[] buffer = inputs.SelectMany(x => BitBuffer.SerializeAsync(x).Result).ToArray();
            using Stream stream = new MemoryStream(buffer);
            T[] results = new T[inputs.Length];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = BitBuffer.Read<T>(stream);
            }

            //assert
            results.Should().BeEquivalentTo(inputs);
        }

        [Test, Repeat(RandomVariations)]
        public void SerialiseMethods_RandomValue_SameResult()
        {
            //arrange
            T input = Random.NextVariant<T>(Variants.NonError);

            //act
            byte[] result1 = BitBuffer.Serialize(input);
            byte[] result2 = BitBuffer.SerializeAsync(input).Result;

            //assert
            result1.Should().BeEquivalentTo(result2);
        }
    }
}
