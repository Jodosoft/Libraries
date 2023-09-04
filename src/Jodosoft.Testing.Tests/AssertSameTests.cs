// Copyright (c) 2023 Joe Lawry-Short
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
using FluentAssertions;
using NUnit.Framework;

namespace Jodosoft.Testing.Tests
{
    public class AssertSameTests : GlobalFixtureBase
    {
        [Test]
        public void Outcome1_SameResults_DoesNotThrow()
        {
            //arrange
            int result = Random.Next();

            //act
            Action action = new Action(() => AssertSame.Outcome(() => result, () => result, () => result));

            //assert
            action.Should().NotThrow();
        }

        [Test]
        public void Outcome2_SameResults_DoesNotThrow()
        {
            //arrange
            int result = Random.Next();

            //act
            Action action = new Action(() => AssertSame.Outcome(new List<Func<int>>() { () => result, () => result, () => result }));

            //assert
            action.Should().NotThrow();
        }

        [Test]
        public void Outcome1_DifferentResults_ThrowsAssertionException()
        {
            //arrange
            int result1 = Random.Next();
            int result2 = result1 - 1;

            //act
            Action action = new Action(() => AssertSame.Outcome(() => result1, () => result1, () => result2, () => result1));

            //assert
            action.Should().Throw<AssertionException>()
                .Which.Message.Should().Contain(result1.ToString()).And.Contain(result2.ToString());
        }

        [Test]
        public void Outcome2_DifferentResults_ThrowsAssertionException()
        {
            //arrange
            int result1 = Random.Next();
            int result2 = result1 - 1;

            //act
            Action action = new Action(() => AssertSame.Outcome(new List<Func<int>>() { () => result1, () => result1, () => result2 }));

            //assert
            action.Should().Throw<AssertionException>()
                .Which.Message.Should().Contain(result1.ToString())
                .And.Contain(result2.ToString());
        }

        [Test]
        public void Outcome1_SameException_DoesNotThrow()
        {
            //arrange

            //act
            Action action = new Action(() => AssertSame.Outcome<object>(
                () => throw new DivideByZeroException(),
                () => throw new DivideByZeroException(),
                () => throw new DivideByZeroException()));

            //assert
            action.Should().NotThrow();
        }

        [Test]
        public void Outcome2_SameException_DoesNotThrow()
        {
            //arrange

            //act
            Action action = new Action(() => AssertSame.Outcome(new List<Func<object>>() {
                () => throw new DivideByZeroException(),
                () => throw new DivideByZeroException(),
                () => throw new DivideByZeroException(),
                () => throw new DivideByZeroException(),
                () => throw new DivideByZeroException() }));

            //assert
            action.Should().NotThrow();
        }
    }
}
