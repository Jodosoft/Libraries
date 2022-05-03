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
using Jodo.Extensions.CheckedNumerics;
using Jodo.Extensions.Primitives;
using NUnit.Framework;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Jodo.Extensions.CheckedGeometry.Tests
{
    public class GeometricTests : AssemblyTestBase
    {
        static readonly object[] AllGeometricTypes =
        {
            typeof(AARectangle<cfloat>),
            typeof(Angle<cfloat>),
            typeof(Circle<cfloat>),
            typeof(Rectangle<cfloat>),
            typeof(Unit<cfloat>),
            typeof(Vector2<cfloat>),
            typeof(Vector3<cfloat>),
        };

        [TestCaseSource(nameof(AllGeometricTypes))]
        public void Serialize_RoundTrip_SameAsOriginal(Type type) => GetType().GetMethod(nameof(Serialize_RoundTrip_SameAsOriginal1)).MakeGenericMethod(type).Invoke(this, null);
        public void Serialize_RoundTrip_SameAsOriginal1<T>() where T : struct, IGeometric<T>
        {
            //arrange
            var input = Random.NextGeometric<T>();
            var formatter = new BinaryFormatter();

            //act
            using var stream = new MemoryStream();
            formatter.Serialize(stream, input);
            stream.Position = 0;
            var result = (T)formatter.Deserialize(stream);

            //assert
            result.Should().Be(input);
        }

        [TestCaseSource(nameof(AllGeometricTypes))]
        public void GetBytes_RoundTrip_SameAsOriginal(Type type) => GetType().GetMethod(nameof(GetBytes_RoundTrip_SameAsOriginal1)).MakeGenericMethod(type).Invoke(this, null);
        public void GetBytes_RoundTrip_SameAsOriginal1<T>() where T : struct, IGeometric<T>
        {
            //arrange
            var input = Random.NextGeometric<T>();

            //act
            var result = BitConverter<T>.FromBytes(BitConverter<T>.GetBytes(input));

            //assert
            result.Should().Be(input);
        }
    }
}
