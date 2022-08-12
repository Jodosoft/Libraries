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
using Jodo.Primitives;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public abstract class NumericWrapperTestBase<TNumeric, TUnderlying> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [Test, Repeat(RandomVariations)]
        public void AdditionOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = Random.NextExtreme<TUnderlying>();
            TUnderlying right = Random.Choose(left, Random.NextExtreme<TUnderlying>());

            //act
            TUnderlying underlying()
                => DynamicInvoke.AdditionOperator(left, right);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.AdditionOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right)));

            //assert
            Same.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = Random.NextExtreme<TUnderlying>();

            //act
            TUnderlying underlying()
                => DynamicInvoke.DecrementOperator(left);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.DecrementOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left)));

            //assert
            Same.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void DivisionOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = Random.NextExtreme<TUnderlying>();
            TUnderlying right = Random.Choose(left, Random.NextExtreme<TUnderlying>());

            //act
            TUnderlying underlying()
                => DynamicInvoke.DivisionOperator(left, right);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.DivisionOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right)));

            //assert
            Same.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void EqualityOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = Random.NextExtreme<TUnderlying>();
            TUnderlying right = Random.Choose(left, Random.NextExtreme<TUnderlying>());

            //act
            bool underlying()
                => DynamicInvoke.EqualityOperator(left, right);
            bool numeric()
                => DynamicInvoke.EqualityOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right));

            //assert
            Same.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void GreaterThanOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = Random.NextExtreme<TUnderlying>();
            TUnderlying right = Random.Choose(left, Random.NextExtreme<TUnderlying>());

            //act
            bool underlying()
                => DynamicInvoke.GreaterThanOperator(left, right);
            bool numeric()
                => DynamicInvoke.GreaterThanOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right));

            //assert
            Same.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void GreaterThanOrEqualOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = Random.NextExtreme<TUnderlying>();
            TUnderlying right = Random.Choose(left, Random.NextExtreme<TUnderlying>());

            //act
            bool underlying()
                => DynamicInvoke.GreaterThanOrEqualOperator(left, right);
            bool numeric()
                => DynamicInvoke.GreaterThanOrEqualOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right));

            //assert
            Same.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = Random.NextExtreme<TUnderlying>();

            //act
            TUnderlying underlying()
                => DynamicInvoke.IncrementOperator(left);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.IncrementOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left)));

            //assert
            Same.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void InequalityOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = Random.NextExtreme<TUnderlying>();
            TUnderlying right = Random.Choose(left, Random.NextExtreme<TUnderlying>());

            //act
            bool underlying()
                => DynamicInvoke.InequalityOperator(left, right);
            bool numeric()
                => DynamicInvoke.InequalityOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right));

            //assert
            Same.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void LessThanOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = Random.NextExtreme<TUnderlying>();
            TUnderlying right = Random.Choose(left, Random.NextExtreme<TUnderlying>());

            //act
            bool underlying()
                => DynamicInvoke.LessThanOperator(left, right);
            bool numeric()
                => DynamicInvoke.LessThanOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right));

            //assert
            Same.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void LessThanOrEqualOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = Random.NextExtreme<TUnderlying>();
            TUnderlying right = Random.Choose(left, Random.NextExtreme<TUnderlying>());

            //act
            bool underlying()
                => DynamicInvoke.LessThanOrEqualOperator(left, right);
            bool numeric()
                => DynamicInvoke.LessThanOrEqualOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right));

            //assert
            Same.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void MultiplicationOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = Random.NextExtreme<TUnderlying>();
            TUnderlying right = Random.Choose(left, Random.NextExtreme<TUnderlying>());

            //act
            TUnderlying underlying()
                => DynamicInvoke.MultiplicationOperator(left, right);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.MultiplicationOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right)));

            //assert
            Same.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void RemainderOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = Random.NextExtreme<TUnderlying>();
            TUnderlying right = Random.Choose(left, Random.NextExtreme<TUnderlying>());

            //act
            TUnderlying underlying()
                => DynamicInvoke.RemainderOperator(left, right);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.RemainderOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right)));

            //assert
            Same.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void SubtractionOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = Random.NextExtreme<TUnderlying>();
            TUnderlying right = Random.Choose(left, Random.NextExtreme<TUnderlying>());

            //act
            TUnderlying underlying()
                => DynamicInvoke.SubtractionOperator(left, right);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.SubtractionOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right)));

            //assert
            Same.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void UnaryMinusOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = Random.NextExtreme<TUnderlying>();

            //act
            TUnderlying underlying()
                => DynamicInvoke.UnaryMinusOperator(left);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.UnaryMinusOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left)));

            //assert
            Same.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void UnaryPlusOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = Random.NextExtreme<TUnderlying>();

            //act
            TUnderlying underlying()
                => DynamicInvoke.UnaryPlusOperator(left);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.UnaryPlusOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left)));

            //assert
            Same.Outcome(underlying, numeric);
        }
    }
}
