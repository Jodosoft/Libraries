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
using NUnit.Framework;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Jodo.Extensions.CheckedNumerics.Tests
{
    public class SerializationTests : AssemblyTestBase
    {
        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Serialize_RoundTrip_SameAsOriginal<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextNumeric<T>();
            var formatter = new BinaryFormatter();

            //act
            using var stream = new MemoryStream();
            formatter.Serialize(stream, input);
            stream.Position = 0;
            var result = (T)formatter.Deserialize(stream);

            //assert
            result.Should().Be(input);
        }
    }
}
