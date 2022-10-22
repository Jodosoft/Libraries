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
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
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
            IProvider<IBitBuffer<AARectangle<TNumeric>>>,
            IProvider<IVariantRandom<AARectangle<TNumeric>>>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {
        public readonly Vector2N<TNumeric> Center;
        public readonly Vector2N<TNumeric> Dimensions;

        public TNumeric Height => Dimensions.Y;
        public TNumeric Width => Dimensions.X;

        public AARectangle(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions)
        {
            Center = center;
            Dimensions = dimensions;
        }

        public AARectangle(TNumeric centerX, TNumeric centerY, TNumeric width, TNumeric height)
        {
            Center = new Vector2N<TNumeric>(centerX, centerY);
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
        public override int GetHashCode() => HashCodeShim.Combine(Center, Dimensions);
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

        IBitBuffer<AARectangle<TNumeric>> IProvider<IBitBuffer<AARectangle<TNumeric>>>.GetInstance() => Utilities.Instance;
        IVariantRandom<AARectangle<TNumeric>> IProvider<IVariantRandom<AARectangle<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IBitBuffer<AARectangle<TNumeric>>,
           IVariantRandom<AARectangle<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            AARectangle<TNumeric> IBitBuffer<AARectangle<TNumeric>>.Read(Stream stream)
            {
                return new AARectangle<TNumeric>(
                    stream.Read<Vector2N<TNumeric>>(),
                    stream.Read<Vector2N<TNumeric>>());
            }

            async Task<AARectangle<TNumeric>> IBitBuffer<AARectangle<TNumeric>>.ReadAsync(Stream stream)
            {
                return new AARectangle<TNumeric>(
                    await stream.ReadAsync<Vector2N<TNumeric>>(),
                    await stream.ReadAsync<Vector2N<TNumeric>>());
            }

            void IBitBuffer<AARectangle<TNumeric>>.Write(AARectangle<TNumeric> value, Stream stream)
            {
                stream.Write(value.Center);
                stream.Write(value.Dimensions);
            }

            async Task IBitBuffer<AARectangle<TNumeric>>.WriteAsync(AARectangle<TNumeric> value, Stream stream)
            {
                await stream.WriteAsync(value.Center);
                await stream.WriteAsync(value.Dimensions);
            }

            AARectangle<TNumeric> IVariantRandom<AARectangle<TNumeric>>.Generate(Random random, Variants variants)
            {
                return new AARectangle<TNumeric>(
                    random.NextVariant<Vector2N<TNumeric>>(variants),
                    random.NextVariant<Vector2N<TNumeric>>(variants));
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
            return new AARectangle<TNumeric>(GetCenterFromBottomLeft(bottomLeft, dimensions), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> FromBottomCenter<TNumeric>(Vector2N<TNumeric> bottomCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(GetCenterFromBottomCenter(bottomCenter, dimensions), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> FromBottomRight<TNumeric>(Vector2N<TNumeric> bottomRight, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(GetCenterFromBottomRight(bottomRight, dimensions), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> FromLeftCenter<TNumeric>(Vector2N<TNumeric> leftCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(GetCenterFromLeftCenter(leftCenter, dimensions), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> FromRightCenter<TNumeric>(Vector2N<TNumeric> rightCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(GetCenterFromRightCenter(rightCenter, dimensions), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> FromTopCenter<TNumeric>(Vector2N<TNumeric> topCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(GetCenterFromTopCenter(topCenter, dimensions), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> FromTopLeft<TNumeric>(Vector2N<TNumeric> topLeft, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(GetCenterFromTopLeft(topLeft, dimensions), dimensions);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AARectangle<TNumeric> FromTopRight<TNumeric>(Vector2N<TNumeric> topRight, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new AARectangle<TNumeric>(GetCenterFromTopRight(topRight, dimensions), dimensions);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TNumeric GetBottom<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return center.Y.Subtract(dimensions.Y.Half());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TNumeric GetLeft<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return center.X.Subtract(dimensions.X.Half());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TNumeric GetRight<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            // When subtracting, whole dimensions must be used to avoid errors caused by truncated integer division.
            return center.X.Subtract(dimensions.X.Half()).Add(dimensions.X);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TNumeric GetTop<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            // When subtracting, whole dimensions must be used to avoid errors caused by truncated integer division.
            return center.Y.Subtract(dimensions.Y.Half()).Add(dimensions.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetBottomCenter<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(center.X, GetBottom(center, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetBottomLeft<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetLeft(center, dimensions), GetBottom(center, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetBottomRight<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetRight(center, dimensions), GetBottom(center, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetLeftCenter<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetLeft(center, dimensions), center.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetRightCenter<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetRight(center, dimensions), center.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetTopCenter<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(center.X, GetTop(center, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetTopLeft<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetLeft(center, dimensions), GetTop(center, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetTopRight<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetRight(center, dimensions), GetTop(center, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TNumeric GetCenterYFromBottom<TNumeric>(Vector2N<TNumeric> bottom, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return bottom.Y.Add(dimensions.Y.Half());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TNumeric GetCenterYFromTop<TNumeric>(Vector2N<TNumeric> top, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            // When subtracting, whole dimensions must be used to avoid errors caused by truncated integer division.
            return top.Y.Subtract(dimensions.Y).Add(dimensions.Y.Half());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TNumeric GetCenterXFromLeft<TNumeric>(Vector2N<TNumeric> left, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return left.X.Add(dimensions.X.Half());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TNumeric GetCenterXFromRight<TNumeric>(Vector2N<TNumeric> right, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return right.X.Subtract(dimensions.X).Add(dimensions.X.Half());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromBottomCenter<TNumeric>(Vector2N<TNumeric> bottomCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(bottomCenter.X, GetCenterYFromBottom(bottomCenter, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromBottomLeft<TNumeric>(Vector2N<TNumeric> bottomLeft, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetCenterXFromLeft(bottomLeft, dimensions), GetCenterYFromBottom(bottomLeft, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromBottomRight<TNumeric>(Vector2N<TNumeric> bottomRight, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetCenterXFromRight(bottomRight, dimensions), GetCenterYFromBottom(bottomRight, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromLeftCenter<TNumeric>(Vector2N<TNumeric> leftCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetCenterXFromLeft(leftCenter, dimensions), leftCenter.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromRightCenter<TNumeric>(Vector2N<TNumeric> rightCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetCenterXFromRight(rightCenter, dimensions), rightCenter.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromTopCenter<TNumeric>(Vector2N<TNumeric> topCenter, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(topCenter.X, GetCenterYFromTop(topCenter, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromTopLeft<TNumeric>(Vector2N<TNumeric> topLeft, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetCenterXFromLeft(topLeft, dimensions), GetCenterYFromTop(topLeft, dimensions));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromTopRight<TNumeric>(Vector2N<TNumeric> topRight, Vector2N<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(GetCenterXFromRight(topRight, dimensions), GetCenterYFromTop(topRight, dimensions));
        }
    }
}
