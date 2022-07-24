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
    public abstract class StringParserTests<T> : GlobalFixtureBase where T : struct, IProvider<IStringParser<T>>, IProvider<IRandom<T>>
    {
        [Test]
        public void Parse1_RandomValueRoundTrip_SameAsInput()
        {
            //arrange
            T input = Random.NextRandomizable<T>();

            //act
            T result = StringParser.Parse<T>(input.ToString());

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Parse1_EmptyString_Throws()
        {
            //arrange

            //act
            Action action = new Action(() => StringParser.Parse<T>(string.Empty));

            //assert
            action.Should().Throw<FormatException>();
        }
    }
}
