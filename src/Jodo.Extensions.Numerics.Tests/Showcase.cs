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
using Jodo.Extensions.Testing;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace Jodo.Extensions.Numerics.Tests
{
    public sealed class Showcase : GlobalFixtureBase
    {
        public StringBuilder ConsoleOuput;

        [SetUp]
        public void SetUp()
        {
            ConsoleOuput = new StringBuilder();
            Console.SetOut(new StringWriter(ConsoleOuput));
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }

        [Test]
        public void FixedPointArithmetic_LargeValues_NoLossOfPrecision()
        {
            var floatingPoint = 1000000 + MathF.PI;
            var fixedPoint = 1000000 + Math<fix64>.PI;

            Console.WriteLine(floatingPoint); // outputs: 1000003.1
            Console.WriteLine(fixedPoint); // outputs: 1000003.141592

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("1000003.1", "1000003.141592");
        }

        [Test]
        public void Github_CodeSample()
        {
            var f1 = 2 * Math<fix64>.PI;
            var f2 = f1 / 1000;

            var i1 = (xint)1234;
            var i2 = i1 >> 0b11;

            Console.WriteLine(f1); // outputs: 6.283184
            Console.WriteLine(f2); // outputs: 0.006283
            Console.WriteLine(i1); // outputs: 1234
            Console.WriteLine($"{i2:X}"); // outputs: 9A

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("6.283184", "0.006283", "1234", "9A");
        }

        [Test]
        public void CastConvertAndClamp()
        {
            var castResult = Cast<xbyte>.ToNumeric(1023);
            var convertResult = Convert<xbyte>.ToNumeric(199.956M);
            var clampResult = Clamp<xbyte>.ToNumeric(-100);

            Console.WriteLine(castResult); // outputs: 255
            Console.WriteLine(convertResult); // outputs: 200
            Console.WriteLine(clampResult); // outputs: 0

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("255", "200", "0");
        }
    }
}
