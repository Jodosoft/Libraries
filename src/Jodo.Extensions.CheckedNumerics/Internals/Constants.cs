using System;

namespace Jodo.Extensions.CheckedNumerics
{
    internal static class Constants
    {
        public const float DegreesPerRadianF = 180 / MathF.PI;
        public const float DegreesPerTurnF = 360;
        public const float TurnsPerDegreeF = 1 / DegreesPerTurnF;
        public const float TurnsPerRadianF = 1 / RadiansPerTurnF;
        public const float RadiansPerDegreeF = MathF.PI / 180;
        public const float RadiansPerTurnF = 2 * MathF.PI;

        public const double DegreesPerRadian = 180 / Math.PI;
        public const double DegreesPerTurn = 360;
        public const double TurnsPerDegree = 1 / DegreesPerTurn;
        public const double TurnsPerRadian = 1 / RadiansPerTurn;
        public const double RadiansPerDegree = Math.PI / 180;
        public const double RadiansPerTurn = 2 * Math.PI;
    }
}
