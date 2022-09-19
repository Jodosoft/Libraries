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
    public sealed class DynamicInvokeTests : GlobalFixtureBase
    {
        [Test]
        public void OperatorMethods_TypeWithoutOperatorDefinition_ThrowsInvalidOperationException()
        {
            //arrange
            //act
            Func<object>[] actions = new[] {
                new Func<object>(() => DynamicInvoke.AdditionOperator(string.Empty, string.Empty)),
                new Func<object>(() => DynamicInvoke.BitwiseComplementOperator(string.Empty)),
                new Func<object>(() => DynamicInvoke.DecrementOperator(string.Empty)),
                new Func<object>(() => DynamicInvoke.DivisionOperator(string.Empty, string.Empty)),
                new Func<object>(() => DynamicInvoke.GreaterThanOperator(string.Empty, string.Empty)),
                new Func<object>(() => DynamicInvoke.GreaterThanOrEqualOperator(string.Empty, string.Empty)),
                new Func<object>(() => DynamicInvoke.IncrementOperator(string.Empty)),
                new Func<object>(() => DynamicInvoke.LeftShiftOperator(string.Empty, Random.Next())),
                new Func<object>(() => DynamicInvoke.LessThanOperator(string.Empty, string.Empty)),
                new Func<object>(() => DynamicInvoke.LessThanOrEqualOperator(string.Empty, string.Empty)),
                new Func<object>(() => DynamicInvoke.LogicalAndOperator(string.Empty, string.Empty)),
                new Func<object>(() => DynamicInvoke.LogicalExclusiveOrOperator(string.Empty, string.Empty)),
                new Func<object>(() => DynamicInvoke.LogicalOrOperator(string.Empty, string.Empty)),
                new Func<object>(() => DynamicInvoke.MultiplicationOperator(string.Empty, string.Empty)),
                new Func<object>(() => DynamicInvoke.RemainderOperator(string.Empty, string.Empty)),
                new Func<object>(() => DynamicInvoke.RightShiftOperator(string.Empty, Random.Next())),
                new Func<object>(() => DynamicInvoke.SubtractionOperator(string.Empty, string.Empty)),
                new Func<object>(() => DynamicInvoke.UnaryMinusOperator(string.Empty)),
                new Func<object>(() => DynamicInvoke.UnaryPlusOperator(string.Empty))
            };

            //assert
            actions[0].Should().Throw<InvalidOperationException>().Which.Message.Should().Contain("not defined");
            AssertSame.Outcome(actions);
        }
    }
}
