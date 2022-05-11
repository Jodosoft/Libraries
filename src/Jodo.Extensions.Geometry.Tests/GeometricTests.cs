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
using Jodo.Extensions.Testing;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Jodo.Extensions.Geometry.Tests
{
    public static class GeometricTests
    {
        public class AARectangle : Base<AARectangle<cfloat>> { }
        public class Angle : Base<Angle<cfloat>> { }
        public class Circle : Base<Circle<cfloat>> { }
        public class Rectangle : Base<Rectangle<cfloat>> { }
        public class Unit : Base<Unit<cfloat>> { }
        public class Vector2 : Base<Vector2<cfloat>> { }
        public class Vector3 : Base<Vector3<cfloat>> { }

        public abstract class Base<T> : GlobalTestBase where T : struct, IGeometric<T>
        {
            //[Test]
            public void Serialize_RoundTrip_SameAsOriginal()
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

            //[Test]
            public void GetBytes_RoundTrip_SameAsOriginal()
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
}
