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
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Geometry
{
    /// <summary>
    /// Represents an axis-aligned (non-rotated) rectangle defined by its center and dimensions.
    /// </summary>
    /// <typeparam name="TNumeric">The type of number used to specify the center and dimensions of the rectangle.</typeparam>
    /// <seealso cref="AARectangle"/>
    /// <seealso cref="Rectangle{TNumeric}"/>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct AARectangle<TNumeric> :
            IEquatable<AARectangle<TNumeric>>,
            IFormattable,
            IProvider<IVariantRandom<AARectangle<TNumeric>>>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {
        public readonly Vector2N<TNumeric> Center;
        public readonly Vector2N<TNumeric> Dimensions;

        public TNumeric Height => Dimensions.Y;
        public TNumeric Width => Dimensions.X;

        public AARectangle(Vector2N<TNumeric> origin, Vector2N<TNumeric> dimensions)
        {
            Center = origin;
            Dimensions = dimensions;
        }

        public AARectangle(TNumeric originX, TNumeric originY, TNumeric width, TNumeric height)
        {
            Center = new Vector2N<TNumeric>(originX, originY);
            Dimensions = new Vector2N<TNumeric>(width, height);
        }

        private AARectangle(SerializationInfo info, StreamingContext context) : this(
            (Vector2N<TNumeric>)info.GetValue(nameof(Center), typeof(Vector2N<TNumeric>)),
            (Vector2N<TNumeric>)info.GetValue(nameof(Dimensions), typeof(Vector2N<TNumeric>)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Center), Center, typeof(Vector2N<TNumeric>));
            info.AddValue(nameof(Dimensions), Dimensions, typeof(Vector2N<TNumeric>));
        }

        public TNumeric GetArea() => MathN.Abs(Dimensions.X.Multiply(Dimensions.Y));

        public AARectangle<TNumeric> Translate(Vector2N<TNumeric> delta) => new AARectangle<TNumeric>(Center + delta, Dimensions);

        public bool Contains(Vector2N<TNumeric> point) =>
            point.X.IsGreaterThanOrEqualTo(this.GetLeft()) &&
            point.X.IsLessThanOrEqualTo(this.GetRight()) &&
            point.Y.IsGreaterThanOrEqualTo(this.GetBottom()) &&
            point.Y.IsLessThanOrEqualTo(this.GetTop());

        public bool Contains(AARectangle<TNumeric> other) =>
           this.GetLeft().IsLessThanOrEqualTo(other.GetLeft()) &&
           this.GetRight().IsGreaterThanOrEqualTo(other.GetRight()) &&
           this.GetBottom().IsLessThanOrEqualTo(other.GetBottom()) &&
           this.GetTop().IsGreaterThanOrEqualTo(other.GetTop());

        public bool IntersectsWith(AARectangle<TNumeric> other) =>
           this.GetLeft().IsLessThan(other.GetRight()) &&
           this.GetRight().IsGreaterThan(other.GetLeft()) &&
           this.GetBottom().IsLessThan(other.GetTop()) &&
           this.GetTop().IsGreaterThan(other.GetBottom());

        public AARectangle<TOther> Convert<TOther>(Func<TNumeric, TOther> convert) where TOther : struct, INumeric<TOther> => new AARectangle<TOther>(convert(Center.X), convert(Center.Y), convert(Dimensions.X), convert(Dimensions.Y));
        public bool Equals(AARectangle<TNumeric> other) => Center.Equals(other.Center) && Dimensions.Equals(other.Dimensions);
        public override bool Equals(object? obj) => obj is AARectangle<TNumeric> fix && Equals(fix);
        public override int GetHashCode() => HashCode.Combine(Center, Dimensions);
        public override string ToString() => $"<X:{Center.X}, Y:{Center.Y}, W:{Dimensions.X}, H:{Dimensions.Y}>";
        public string ToString(string? format, IFormatProvider? formatProvider) => $"<X:{Center.X.ToString(format, formatProvider)}, Y:{Center.Y.ToString(format, formatProvider)}, W:{Dimensions.X.ToString(format, formatProvider)}, H:{Dimensions.Y.ToString(format, formatProvider)}>";

        public static bool operator ==(AARectangle<TNumeric> left, AARectangle<TNumeric> right) => left.Equals(right);
        public static bool operator !=(AARectangle<TNumeric> left, AARectangle<TNumeric> right) => !(left == right);

#if HAS_VALUE_TUPLES
        public static implicit operator AARectangle<TNumeric>((Vector2N<TNumeric>, Vector2N<TNumeric>) value) => new AARectangle<TNumeric>(value.Item1, value.Item2);
        public static implicit operator (Vector2N<TNumeric>, Vector2N<TNumeric>)(AARectangle<TNumeric> value) => (value.Center, value.Dimensions);
        public static implicit operator AARectangle<TNumeric>((TNumeric, TNumeric, TNumeric, TNumeric) value) => new AARectangle<TNumeric>((value.Item1, value.Item2), (value.Item3, value.Item4));
        public static implicit operator (TNumeric, TNumeric, TNumeric, TNumeric)(AARectangle<TNumeric> value) => (value.Center.X, value.Center.Y, value.Dimensions.X, value.Dimensions.Y);
#endif

        IVariantRandom<AARectangle<TNumeric>> IProvider<IVariantRandom<AARectangle<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IVariantRandom<AARectangle<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            AARectangle<TNumeric> IVariantRandom<AARectangle<TNumeric>>.Next(Random random, Scenarios scenarios)
            {
                return new AARectangle<TNumeric>(
                    random.NextVariant<Vector2N<TNumeric>>(scenarios),
                    random.NextVariant<Vector2N<TNumeric>>(scenarios));
            }
        }
    }

    /// <summary>
    /// Provides methods for creating instances of <see cref="AARectangle{TNumeric}"/>.
    /// </summary>
    public static class AARectangle
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> Between<TNumeric>(Vector2N<TNumeric> point1, Vector2N<TNumeric> point2) where TNumeric : struct, INumeric<TNumeric>
        {
            Vector2N<TNumeric> dimensions = point2.Subtract(point1);
            return new AARectangle<TNumeric>(point1.Add(dimensions.Half()), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> FromCenter<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(center, dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> FromBottomLeft<TNumeric>(Vector2N<TNumeric> bottomLeft, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(bottomLeft.Add(dimensions.Half()), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> FromBottomCenter<TNumeric>(Vector2N<TNumeric> bottomCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(bottomCenter.AddY(dimensions.Y.Half()), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> FromBottomRight<TNumeric>(Vector2N<TNumeric> bottomRight, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(
                new Vector2N<TNumeric>(bottomRight.X.Subtract(dimensions.X.Half()), bottomRight.Y.Add(dimensions.Y.Half())),
                dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> FromLeftCenter<TNumeric>(Vector2N<TNumeric> leftCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(leftCenter.AddX(dimensions.X.Half()), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> FromRightCenter<TNumeric>(Vector2N<TNumeric> rightCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(rightCenter.SubtractX(dimensions.X.Half()), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> FromTopCenter<TNumeric>(Vector2N<TNumeric> topCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(topCenter.SubtractY(dimensions.Y.Half()), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> FromTopLeft<TNumeric>(Vector2N<TNumeric> topLeft, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(
                new Vector2N<TNumeric>(topLeft.X.Add(dimensions.X.Half()), topLeft.Y.Subtract(dimensions.Y.Half())),
                dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> FromTopRight<TNumeric>(Vector2N<TNumeric> topRight, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(topRight.Subtract(dimensions.Half()), dimensions);
        }

        public static AARectangle<TNumeric> Parse<TNumeric>(string s, NumberStyles? style, IFormatProvider? provider) where TNumeric : struct, INumeric<TNumeric>
        {
            string[] parts = StringUtilities.ParseVectorParts(s.Trim());
            if (parts.Length == 4)
                return new AARectangle<TNumeric>(
                    Numeric.Parse<TNumeric>(parts[0].Replace("X:", string.Empty).Trim(), style, provider),
                    Numeric.Parse<TNumeric>(parts[1].Replace("Y:", string.Empty).Trim(), style, provider),
                    Numeric.Parse<TNumeric>(parts[2].Replace("W:", string.Empty).Trim(), style, provider),
                    Numeric.Parse<TNumeric>(parts[3].Replace("H:", string.Empty).Trim(), style, provider));
            else throw new FormatException();
        }
    }
}
