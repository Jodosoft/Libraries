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
using System.Linq;
using System.Runtime.Serialization;
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Geometry
{
    public static class Rectangle
    {
        public static Rectangle<TNumeric> FromCenter<TNumeric>(Vector2<TNumeric> center, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => new Rectangle<TNumeric>(center, dimensions, angle);

        public static Rectangle<TNumeric> FromBottomLeft<TNumeric>(Vector2<TNumeric> bottomLeft, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => new Rectangle<TNumeric>(GetTopRight(bottomLeft, dimensions, default), dimensions, angle);

        public static Rectangle<TNumeric> FromBottomCenter<TNumeric>(Vector2<TNumeric> bottomLeft, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => new Rectangle<TNumeric>(GetTopCenter(bottomLeft, dimensions, default), dimensions, angle);

        public static Rectangle<TNumeric> FromBottomRight<TNumeric>(Vector2<TNumeric> bottomLeft, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => new Rectangle<TNumeric>(GetTopLeft(bottomLeft, dimensions, default), dimensions, angle);

        public static Rectangle<TNumeric> FromLeftCenter<TNumeric>(Vector2<TNumeric> bottomLeft, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => new Rectangle<TNumeric>(GetRightCenter(bottomLeft, dimensions, default), dimensions, angle);

        public static Rectangle<TNumeric> FromRightCenter<TNumeric>(Vector2<TNumeric> bottomLeft, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => new Rectangle<TNumeric>(GetLeftCenter(bottomLeft, dimensions, default), dimensions, angle);

        public static Rectangle<TNumeric> FromTopLeft<TNumeric>(Vector2<TNumeric> bottomLeft, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => new Rectangle<TNumeric>(GetBottomRight(bottomLeft, dimensions, default), dimensions, angle);

        public static Rectangle<TNumeric> FromTopCenter<TNumeric>(Vector2<TNumeric> bottomLeft, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => new Rectangle<TNumeric>(GetBottomCenter(bottomLeft, dimensions, default), dimensions, angle);

        public static Rectangle<TNumeric> FromTopRight<TNumeric>(Vector2<TNumeric> bottomLeft, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => new Rectangle<TNumeric>(GetBottomLeft(bottomLeft, dimensions, default), dimensions, angle);

        public static Rectangle<TNumeric> Parse<TNumeric>(string s, NumberStyles? style, IFormatProvider? provider) where TNumeric : struct, INumeric<TNumeric>
        {
            string[] parts = StringUtilities.ParseVectorParts(s.Trim());
            if (parts.Length == 5)
                return new Rectangle<TNumeric>(
                    new Vector2<TNumeric>(
                        Numeric.Parse<TNumeric>(parts[0].Replace("X:", string.Empty).Trim(), style, provider),
                        Numeric.Parse<TNumeric>(parts[1].Replace("Y:", string.Empty).Trim(), style, provider)),
                    new Vector2<TNumeric>(
                        Numeric.Parse<TNumeric>(parts[2].Replace("W:", string.Empty).Trim(), style, provider),
                        Numeric.Parse<TNumeric>(parts[3].Replace("H:", string.Empty).Trim(), style, provider)),
                    new Angle<TNumeric>(Angle.Parse<TNumeric>(parts[4].Replace("A:", string.Empty).Trim(), style, provider)));
            else throw new FormatException();
        }

        internal static Vector2<TNumeric> GetBottomCenter<TNumeric>(Vector2<TNumeric> center, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => new Vector2<TNumeric>(center.X, center.Y.Add(dimensions.Y.Divide(Numeric.Two<TNumeric>()))).RotateAround(center, angle);

        internal static Vector2<TNumeric> GetBottomLeft<TNumeric>(Vector2<TNumeric> center, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => (center - (dimensions / Numeric.Two<TNumeric>())).RotateAround(center, angle);

        internal static Vector2<TNumeric> GetBottomRight<TNumeric>(Vector2<TNumeric> center, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => new Vector2<TNumeric>(center.X.Add(dimensions.X.Halved()), center.Y.Subtract(dimensions.Y.Halved())).RotateAround(center, angle);

        internal static Vector2<TNumeric> GetLeftCenter<TNumeric>(Vector2<TNumeric> center, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => new Vector2<TNumeric>(center.X.Subtract(dimensions.X.Halved()), center.Y).RotateAround(center, angle);

        internal static Vector2<TNumeric> GetRightCenter<TNumeric>(Vector2<TNumeric> center, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => new Vector2<TNumeric>(center.X.Add(dimensions.X.Halved()), center.Y).RotateAround(center, angle);

        internal static Vector2<TNumeric> GetTopCenter<TNumeric>(Vector2<TNumeric> center, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => new Vector2<TNumeric>(center.X, center.Y.Add(dimensions.Y.Halved())).RotateAround(center, angle);

        internal static Vector2<TNumeric> GetTopLeft<TNumeric>(Vector2<TNumeric> center, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => new Vector2<TNumeric>(center.X.Subtract(dimensions.X.Halved()), center.Y.Add(dimensions.Y.Halved())).RotateAround(center, angle);

        internal static Vector2<TNumeric> GetTopRight<TNumeric>(Vector2<TNumeric> center, Vector2<TNumeric> dimensions, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
            => (center + (dimensions / Numeric.Two<TNumeric>())).RotateAround(center, angle);
    }

    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Rectangle<TNumeric> :
            IEquatable<Rectangle<TNumeric>>,
            IFormattable,
            IProvider<IBitConvert<Rectangle<TNumeric>>>,
                        IProvider<IVariantRandom<Rectangle<TNumeric>>>,
            ITwoDimensional<Rectangle<TNumeric>, TNumeric>,
            IRotatable<Rectangle<TNumeric>, Angle<TNumeric>, Vector2<TNumeric>>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {
        public readonly Vector2<TNumeric> Origin;
        public readonly Vector2<TNumeric> Dimensions;
        public readonly Angle<TNumeric> Angle;

        public TNumeric Height => Dimensions.Y;
        public TNumeric Width => Dimensions.X;

        public Vector2<TNumeric> GetBottomCenter() => Rectangle.GetBottomCenter(Origin, Dimensions, Angle);
        public Vector2<TNumeric> GetBottomLeft() => Rectangle.GetBottomLeft(Origin, Dimensions, Angle);
        public Vector2<TNumeric> GetBottomRight() => Rectangle.GetBottomRight(Origin, Dimensions, Angle);
        public Vector2<TNumeric> GetLeftCenter() => Rectangle.GetLeftCenter(Origin, Dimensions, Angle);
        public Vector2<TNumeric> GetRightCenter() => Rectangle.GetRightCenter(Origin, Dimensions, Angle);
        public Vector2<TNumeric> GetTopCenter() => Rectangle.GetTopCenter(Origin, Dimensions, Angle);
        public Vector2<TNumeric> GetTopLeft() => Rectangle.GetTopLeft(Origin, Dimensions, Angle);
        public Vector2<TNumeric> GetTopRight() => Rectangle.GetTopRight(Origin, Dimensions, Angle);

        public Rectangle(Vector2<TNumeric> origin, Vector2<TNumeric> dimensions, Angle<TNumeric> angle)
        {
            Origin = origin;
            Dimensions = dimensions;
            Angle = angle;
        }

        private Rectangle(SerializationInfo info, StreamingContext context)
        {
            Origin = (Vector2<TNumeric>)info.GetValue(nameof(Origin), typeof(Vector2<TNumeric>));
            Dimensions = (Vector2<TNumeric>)info.GetValue(nameof(Dimensions), typeof(Vector2<TNumeric>));
            Angle = (Angle<TNumeric>)info.GetValue(nameof(Angle), typeof(Angle<TNumeric>));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Origin), Origin, typeof(Vector2<TNumeric>));
            info.AddValue(nameof(Dimensions), Dimensions, typeof(Vector2<TNumeric>));
            info.AddValue(nameof(Angle), Angle, typeof(Angle<TNumeric>));
        }

        public bool Contains(Rectangle<TNumeric> other)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Vector2<TNumeric> point)
        {
            throw new NotImplementedException();
        }

        public bool IntersectsWith(Rectangle<TNumeric> other)
        {
            throw new NotImplementedException();
        }

        public TNumeric GetArea() => MathN.Abs(Width.Multiply(Height));

        public Vector2<TNumeric>[] GetVertices()
        {
            return new[]
            {
                GetBottomLeft(),
                GetBottomRight(),
                GetTopRight(),
                GetTopLeft()
            };
        }

        public Rectangle<TNumeric> Grow(TNumeric delta) => Grow(new Vector2<TNumeric>(delta, delta));
        public Rectangle<TNumeric> Grow(TNumeric deltaX, TNumeric deltaY) => Grow(new Vector2<TNumeric>(deltaX, deltaY));
        public Rectangle<TNumeric> Grow(Vector2<TNumeric> delta) => new Rectangle<TNumeric>(GetBottomLeft() - delta, Dimensions + delta + delta, Angle);

        public Rectangle<TNumeric> Scale(TNumeric scale) => new Rectangle<TNumeric>(Origin, Dimensions * scale, Angle);

        public Rectangle<TNumeric> Rotate(Angle<TNumeric> angle) => new Rectangle<TNumeric>(GetBottomLeft(), Dimensions, Angle + angle);
        public Rectangle<TNumeric> RotateAround(Vector2<TNumeric> pivot, Angle<TNumeric> angle) => new Rectangle<TNumeric>(Origin.RotateAround(pivot, angle), Dimensions, Angle + angle);
        public Rectangle<TNumeric> Shrink(TNumeric delta) => Shrink(new Vector2<TNumeric>(delta, delta));
        public Rectangle<TNumeric> Shrink(TNumeric deltaX, TNumeric deltaY) => Shrink(new Vector2<TNumeric>(deltaX, deltaY));
        public Rectangle<TNumeric> Shrink(Vector2<TNumeric> delta) => new Rectangle<TNumeric>(GetBottomLeft(), Dimensions - delta, Angle);
        public Rectangle<TNumeric> Translate(TNumeric deltaX, TNumeric deltaY) => Translate(new Vector2<TNumeric>(deltaX, deltaY));
        public Rectangle<TNumeric> Translate(Vector2<TNumeric> delta) => new Rectangle<TNumeric>(GetBottomLeft() + delta, Dimensions, Angle);
        public Rectangle<TNumeric> UnitTranslate(TNumeric deltaX, TNumeric deltaY) => Translate(new Vector2<TNumeric>(deltaX, deltaY));
        public Rectangle<TNumeric> UnitTranslate(Vector2<TNumeric> delta) => new Rectangle<TNumeric>(
            GetBottomLeft() + new Vector2<TNumeric>(delta.X.Multiply(Width), delta.Y.Multiply(Height)), Dimensions, Angle);

        public bool Equals(Rectangle<TNumeric> other) => Origin.Equals(other.Origin) && Dimensions.Equals(other.Dimensions) && Angle.Equals(other.Angle);
        public override bool Equals(object? obj)
        {
            return obj is Rectangle<TNumeric> rectangle && Equals(rectangle);
        }

        public override int GetHashCode() => HashCode.Combine(Origin, Dimensions, Angle);
        public override string ToString() => $"<X:{Origin.X}, Y:{Origin.Y}, W:{Dimensions.X}, H:{Dimensions.Y}, A:{Angle}>";
        public string ToString(string? format, IFormatProvider? formatProvider) => $"<X:{Origin.X.ToString(format, formatProvider)}, Y:{Origin.Y.ToString(format, formatProvider)}, W:{Dimensions.X.ToString(format, formatProvider)}, H:{Dimensions.Y.ToString(format, formatProvider)}, A:{Angle.ToString(format, formatProvider)}>";

        public AARectangle<TNumeric> GetBounds()
        {
            TNumeric[]? xs = new[] { GetTopLeft().X, GetTopRight().X, GetBottomLeft().X, GetBottomRight().X };
            TNumeric[]? ys = new[] { GetTopLeft().Y, GetTopRight().Y, GetBottomLeft().Y, GetBottomRight().Y };

            TNumeric minX = xs.Min();
            TNumeric maxX = xs.Max();
            TNumeric minY = ys.Min();
            TNumeric maxY = ys.Max();

            Vector2<TNumeric> dimensions = new Vector2<TNumeric>(maxX.Subtract(minX), maxY.Subtract(minY));
            return AARectangle.FromBottomLeft(new Vector2<TNumeric>(minX, minY), dimensions);
        }

        public static bool operator ==(Rectangle<TNumeric> left, Rectangle<TNumeric> right) => left.Equals(right);
        public static bool operator !=(Rectangle<TNumeric> left, Rectangle<TNumeric> right) => !(left == right);
        public static implicit operator Rectangle<TNumeric>(AARectangle<TNumeric> value) => new Rectangle<TNumeric>(value.Origin, value.Dimensions, default);

        Vector2<TNumeric>[] ITwoDimensional<Rectangle<TNumeric>, TNumeric>.GetVertices(int circumferenceDivisor) => GetVertices();
        Vector2<TNumeric> ITwoDimensional<Rectangle<TNumeric>, TNumeric>.GetCenter() => Origin;

        IBitConvert<Rectangle<TNumeric>> IProvider<IBitConvert<Rectangle<TNumeric>>>.GetInstance() => Utilities.Instance;
        IVariantRandom<Rectangle<TNumeric>> IProvider<IVariantRandom<Rectangle<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IBitConvert<Rectangle<TNumeric>>,
           IVariantRandom<Rectangle<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            Rectangle<TNumeric> IVariantRandom<Rectangle<TNumeric>>.Next(Random random, Scenarios scenarios)
            {
                return new Rectangle<TNumeric>(
                    random.NextVariant<Vector2<TNumeric>>(scenarios),
                    random.NextVariant<Vector2<TNumeric>>(scenarios),
                    random.NextVariant<Angle<TNumeric>>(scenarios));
            }

            Rectangle<TNumeric> IBitConvert<Rectangle<TNumeric>>.Read(IReader<byte> stream)
            {
                return new Rectangle<TNumeric>(
                    BitConvert.Read<Vector2<TNumeric>>(stream),
                    BitConvert.Read<Vector2<TNumeric>>(stream),
                    BitConvert.Read<Angle<TNumeric>>(stream));
            }

            void IBitConvert<Rectangle<TNumeric>>.Write(Rectangle<TNumeric> value, IWriter<byte> stream)
            {
                BitConvert.Write(stream, value.Origin);
                BitConvert.Write(stream, value.Dimensions);
                BitConvert.Write(stream, value.Angle);
            }
        }
    }
}
