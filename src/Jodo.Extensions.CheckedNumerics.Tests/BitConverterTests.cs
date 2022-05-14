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
using Jodo.Extensions.Numerics;
using Jodo.Extensions.Primitives;
using Jodo.Extensions.Testing;
using NUnit.Framework;
using System;

namespace Jodo.Extensions.CheckedNumerics.Tests
{
    public static class BitConverterTests
    {
        public class CDouble : Base<cdouble> { }
        public class CFix64 : Base<cfix64> { }
        public class CFloat : Base<cfloat> { }
        public class CInt : Base<cint> { }
        public class CLong : Base<clong> { }
        public class CSByte : Base<csbyte> { }
        public class CShort : Base<cshort> { }
        public class CUFix64 : Base<cufix64> { }
        public class CUInt : Base<cuint> { }

        public abstract class Base<T> : GlobalTestBase where T : struct, INumeric<T>
        {
            [Test]
            public void GetBytes_RoundTrip_SameAsOriginal()
            {
                //arrange
                var input = Random.NextNumeric<T>();

                //act
                var result = BitConverter<T>.FromBytes(BitConverter<T>.GetBytes(input));

                //assert
                result.Should().Be(input);
            }

            [Test]
            public void GetBytes_Zero_AllZero()
            {
                //arrange
                var input = Math<T>.Zero;

                //act
                var result = BitConverter<T>.GetBytes(input);

                //assert
                result.ToArray().Should().AllBeEquivalentTo(0);
            }

            [Test]
            public void GetBytes_NonZero_NotAllZero()
            {
                //arrange
                T input;
                while ((input = Random.NextNumeric<T>()).Equals(Math<T>.Zero)) { }

                //act
                var result = BitConverter<T>.GetBytes(input);

                //assert
                result.ToArray().Should().Contain(x => x != 0);
            }
        }
    }
}
