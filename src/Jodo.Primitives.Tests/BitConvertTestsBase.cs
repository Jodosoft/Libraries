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
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Primitives.Tests
{
    public abstract class BitConvertTestsBase<T> : GlobalFixtureBase where T : struct, IProvider<IBitConverter<T>>, IProvider<IRandom<T>>
    {
        [Test, Repeat(RandomVariations)]
        public void GetBytes_RandomValue_ReturnsBytes()
        {
            //arrange
            T input = Random.NextRandomizable<T>();

            //act
            byte[] result = BitConvert.GetBytes(input);

            //assert
            result.Length.Should().BeGreaterThan(0);
        }

        [Test, Repeat(RandomVariations)]
        public void GetBytes_RoundTrip_SameAsOriginal()
        {
            //arrange
            T input = Random.NextRandomizable<T>();

            //act
            T result = BitConvert.FromBytes<T>(BitConvert.GetBytes(input));

            //assert
            result.Should().BeEquivalentTo(input);
        }

        [Test, Repeat(RandomVariations)]
        public void GetBytes_RoundTripMultiple_SameAsOriginal()
        {
            //arrange
            T[] input = Enumerable.Range(0, 10).Select(_ => Random.NextRandomizable<T>()).ToArray();
            T[] results = new T[input.Length];
            List<byte> buffer = new List<byte>();
            IWriter<byte> writer = buffer.AsWriteOnlyStream();
            IReader<byte> reader = buffer.AsReadOnlyStream();

            //act
            for (int i = 0; i < input.Length; i++) BitConvert.Write(writer, input[i]);
            for (int i = 0; i < input.Length; i++) results[i] = BitConvert.Read<T>(reader);

            //assert
            results.Should().BeEquivalentTo(input);
        }

        [Test]
        public void FromBytes_ZeroLength_Throws()
        {
            //arrange

            //act
            Action action = new Action(() => BitConvert.FromBytes<T>(Array.Empty<byte>()));

            //assert
            action.Should().Throw<ArgumentException>();
        }
    }
}
