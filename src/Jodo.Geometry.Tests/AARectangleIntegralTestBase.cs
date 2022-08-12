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
using Jodo.Numerics;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Geometry.Tests
{
    public abstract class AARectangleIntegralTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [SetUp]
        public void SetUp() => Assert.That(Numeric.IsIntegral<TNumeric>());

        [Test, Repeat(RandomVariations)]
        public void GetVertices_UnitSquare_CorrectResult()
        {
            //arrange
            AARectangle<TNumeric> subject = AARectangle.FromCenter(
                new Vector2<TNumeric>(Numeric.Zero<TNumeric>(), Numeric.Zero<TNumeric>()),
                new Vector2<TNumeric>(Numeric.One<TNumeric>(), Numeric.One<TNumeric>()));
            Vector2<TNumeric>[] expected = new Vector2<TNumeric>[] {
                     new Vector2<TNumeric>(Numeric.Zero<TNumeric>(), Numeric.Zero<TNumeric>()),
                     new Vector2<TNumeric>(Numeric.One<TNumeric>(), Numeric.Zero<TNumeric>()),
                     new Vector2<TNumeric>(Numeric.One<TNumeric>(), Numeric.One<TNumeric>()),
                     new Vector2<TNumeric>(Numeric.Zero<TNumeric>(), Numeric.One<TNumeric>()) };

            //act
            Vector2<TNumeric>[] results = subject.GetVertices();

            //assert
            results.Should().BeEquivalentTo(expected);
        }
    }
}
