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
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Primitives.Tests
{
    public sealed class FuncExtensionsTests : GlobalFixtureBase
    {
        [Test]
        public void Try1_ReferenceTypeNoException_ReturnsSameReference()
        {
            //arrange
            object expected = new object();
            Func<object> function = new Func<object>(() => expected);

            //act
            bool result = FuncExtensions.Try(function, out object outResult);

            //assert
            result.Should().BeTrue();
            outResult.Should().BeSameAs(expected);
        }

        [Test]
        public void Try1_ValueTypeNoException_ReturnsSameValue()
        {
            //arrange
            int expected = Random.Next();
            Func<int> function = new Func<int>(() => expected);

            //act
            bool result = FuncExtensions.Try(function, out int outResult);

            //assert
            result.Should().BeTrue();
            outResult.Should().Be(expected);
        }

        [Test]
        public void Try1_ReferenceTypeWithException_ReturnsNull()
        {
            //arrange
            Func<object> function = new Func<object>(() => throw new InvalidOperationException());

            //act
            bool result = FuncExtensions.Try(function, out object outResult);

            //assert
            result.Should().BeFalse();
            outResult.Should().BeNull();
        }

        [Test]
        public void Try1_ValueTypeWithException_ReturnsDefault()
        {
            //arrange
            Func<int> function = new Func<int>(() => throw new InvalidOperationException());

            //act
            bool result = FuncExtensions.Try(function, out int outResult);

            //assert
            result.Should().BeFalse();
            outResult.Should().Be(0);
        }
    }
}
