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
using System.Globalization;
using System.Linq;
using System.Reflection;
using Jodosoft.Primitives;
using Jodosoft.Testing;
using NUnit.Framework;

namespace Jodosoft.Numerics.Tests
{
    public abstract class NumericWrapperTestBase<TNumeric, TUnderlying> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [Test, Repeat(RandomVariations)]
        public void AdditionOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            TUnderlying right = Random.Choose(left, DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>()));

            //act
            TUnderlying underlying()
                => DynamicInvoke.AdditionOperator(left, right);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.AdditionOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right)));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());

            //act
            TUnderlying underlying()
                => DynamicInvoke.DecrementOperator(left);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.DecrementOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left)));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void DivisionOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            TUnderlying right = Random.Choose(left, DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>()));

            //act
            TUnderlying underlying()
                => DynamicInvoke.DivisionOperator(left, right);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.DivisionOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right)));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void EqualityOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            TUnderlying right = Random.Choose(left, DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>()));

            //act
            bool underlying()
                => DynamicInvoke.EqualityOperator(left, right);
            bool numeric()
                => DynamicInvoke.EqualityOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void GreaterThanOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            TUnderlying right = Random.Choose(left, DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>()));

            //act
            bool underlying()
                => DynamicInvoke.GreaterThanOperator(left, right);
            bool numeric()
                => DynamicInvoke.GreaterThanOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void GreaterThanOrEqualOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            TUnderlying right = Random.Choose(left, DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>()));

            //act
            bool underlying()
                => DynamicInvoke.GreaterThanOrEqualOperator(left, right);
            bool numeric()
                => DynamicInvoke.GreaterThanOrEqualOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());

            //act
            TUnderlying underlying()
                => DynamicInvoke.IncrementOperator(left);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.IncrementOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left)));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void InequalityOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            TUnderlying right = Random.Choose(left, DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>()));

            //act
            bool underlying()
                => DynamicInvoke.InequalityOperator(left, right);
            bool numeric()
                => DynamicInvoke.InequalityOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void LessThanOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            TUnderlying right = Random.Choose(left, DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>()));

            //act
            bool underlying()
                => DynamicInvoke.LessThanOperator(left, right);
            bool numeric()
                => DynamicInvoke.LessThanOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void LessThanOrEqualOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            TUnderlying right = Random.Choose(left, DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>()));

            //act
            bool underlying()
                => DynamicInvoke.LessThanOrEqualOperator(left, right);
            bool numeric()
                => DynamicInvoke.LessThanOrEqualOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void MultiplicationOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            TUnderlying right = Random.Choose(left, DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>()));

            //act
            TUnderlying underlying()
                => DynamicInvoke.MultiplicationOperator(left, right);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.MultiplicationOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right)));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void RemainderOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            TUnderlying right = Random.Choose(left, DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>()));

            //act
            TUnderlying underlying()
                => DynamicInvoke.RemainderOperator(left, right);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.RemainderOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right)));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void SubtractionOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            TUnderlying right = Random.Choose(left, DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>()));

            //act
            TUnderlying underlying()
                => DynamicInvoke.SubtractionOperator(left, right);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.SubtractionOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right)));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void UnaryMinusOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());

            //act
            TUnderlying underlying()
                => DynamicInvoke.UnaryMinusOperator(left);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.UnaryMinusOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left)));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void UnaryPlusOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());

            //act
            TUnderlying underlying()
                => DynamicInvoke.UnaryPlusOperator(left);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.UnaryPlusOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left)));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void ParseMethods1_RandomValues_SameOutcomeAsUnderlying()
        {
            //arrange
            string input = Random.Choose(
                Random.NextVariant<DoubleN>().ToString(),
                Random.Next(-100, 100).ToString(),
                Guid.NewGuid().ToString());
            MethodInfo underlyingParseMethod = typeof(TNumeric)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Single(x => x.Name == "Parse" && x.GetParameters().Length == 1);
            //act
            Func<TNumeric>[] actions = new Func<TNumeric>[]
            {
                () => Numeric.Parse<TNumeric>(input),
                () =>
                {
                    try { return (TNumeric)underlyingParseMethod.Invoke(null, new object[] { input }); }
                    catch (TargetInvocationException ex) { throw ex.InnerException; }
                }
            };

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void ParseMethods2_RandomValues_SameOutcomeAsUnderlying()
        {
            //arrange
            string input = Random.Choose(
                Random.NextVariant<DoubleN>().ToString(),
                Random.Next(-100, 100).ToString(),
                Guid.NewGuid().ToString());
            IFormatProvider formatProvider = Random.Choose(
                null,
                CultureInfo.InvariantCulture,
                CultureInfo.CurrentCulture,
                CultureInfo.GetCultureInfo("en-GB"),
                CultureInfo.GetCultureInfo("en-US"),
                CultureInfo.GetCultureInfo("da-DK"),
                CultureInfo.GetCultureInfo("ja-JP"));
            MethodInfo underlyingParseMethod = typeof(TNumeric)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Single(x => x.Name == "Parse" && x.GetParameters().Length == 2 &&
                        x.GetParameters()[1].ParameterType == typeof(IFormatProvider));
            //act
            Func<TNumeric>[] actions = new Func<TNumeric>[]
            {
                () => Numeric.Parse<TNumeric>(input, formatProvider),
                () =>
                {
                    try { return (TNumeric)underlyingParseMethod.Invoke(null, new object[] { input, formatProvider }); }
                    catch (TargetInvocationException ex) { throw ex.InnerException; }
                }
            };

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void ParseMethods3_RandomValues_SameOutcomeAsUnderlying()
        {
            //arrange
            string input = Random.Choose(
                Random.NextVariant<DoubleN>().ToString(),
                Random.Next(-100, 100).ToString(),
                Guid.NewGuid().ToString());
            NumberStyles numberStyles = Random.NextEnum<NumberStyles>();
            MethodInfo underlyingParseMethod = typeof(TNumeric)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Single(x => x.Name == "Parse" && x.GetParameters().Length == 2 &&
                        x.GetParameters()[1].ParameterType == typeof(NumberStyles));

            //act
            Func<TNumeric>[] actions = new Func<TNumeric>[]
            {
                () => Numeric.Parse<TNumeric>(input, numberStyles),
                () =>
                {
                    try { return (TNumeric)underlyingParseMethod.Invoke(null, new object[] { input, numberStyles }); }
                    catch (TargetInvocationException ex) { throw ex.InnerException; }
                }
            };

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void ParseMethods4_RandomValues_SameOutcomeAsUnderlying()
        {
            //arrange
            string input = Random.Choose(
                Random.NextVariant<DoubleN>().ToString(),
                Random.Next(-100, 100).ToString(),
                Guid.NewGuid().ToString());
            NumberStyles numberStyles = Random.NextEnum<NumberStyles>();
            IFormatProvider formatProvider = Random.Choose(
                null,
                CultureInfo.InvariantCulture,
                CultureInfo.CurrentCulture,
                CultureInfo.GetCultureInfo("en-GB"),
                CultureInfo.GetCultureInfo("en-US"),
                CultureInfo.GetCultureInfo("da-DK"),
                CultureInfo.GetCultureInfo("ja-JP"));
            MethodInfo underlyingParseMethod = typeof(TNumeric)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Single(x => x.Name == "Parse" && x.GetParameters().Length == 3);

            //act
            Func<TNumeric>[] actions = new Func<TNumeric>[]
            {
                () => Numeric.Parse<TNumeric>(input, numberStyles, formatProvider),
                () =>
                {
                    try { return (TNumeric)underlyingParseMethod.Invoke(null, new object[] { input, numberStyles, formatProvider }); }
                    catch (TargetInvocationException ex) { throw ex.InnerException; }
                }
            };

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void GetTypeCode_RandomValues_SamedAsUnderlying()
        {
            //arrange
            TNumeric subject = Random.NextVariant<TNumeric>();

            //act
            //assert
            AssertSame.Value(
                Type.GetTypeCode(typeof(TUnderlying)),
                ((IConvertible)subject).GetTypeCode());
        }

        [Test, Repeat(RandomVariations)]
        public void ToChar_RandomValues_SamedAsUnderlying()
        {
            //arrange
            TUnderlying input = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            TNumeric subject = DynamicInvoke.ConversionOperator<TNumeric>(input);

            //act
            char underlying()
                => ((IConvertible)input).ToChar(CultureInfo.CurrentCulture);
            char numeric()
                => ((IConvertible)subject).ToChar(CultureInfo.CurrentCulture);

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void ToDateTime_RandomValues_SamedAsUnderlying()
        {
            //arrange
            TUnderlying input = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            TNumeric subject = DynamicInvoke.ConversionOperator<TNumeric>(input);

            //act
            DateTime underlying()
                => ((IConvertible)input).ToDateTime(CultureInfo.CurrentCulture);
            DateTime numeric()
                => ((IConvertible)subject).ToDateTime(CultureInfo.CurrentCulture);

            //assert
            AssertSame.Outcome(underlying, numeric);
        }
    }
}
