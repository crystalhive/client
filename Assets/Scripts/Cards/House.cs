using System;
using System.Collections.Generic;

namespace CrystalHive
{
    namespace Cards
    {
        public enum House
        {
            Unassigned,
            Any,
            Brobnar,
            Dis,
            Logos,
            Mars,
            Sanctum,
            Shadows,
            Untamed
        }

        static class HouseExtensions
        {
            public const string BrobnarName = "Brobnar";
            public const string DisName = "Dis";
            public const string LogosName = "Logos";
            public const string MarsName = "Mars";
            public const string SanctumName = "Sanctum";
            public const string ShadowsName = "Shadows";
            public const string UntamedName = "Untamed";

            public static string Name(this House house)
            {
                switch (house)
                {
                    case House.Brobnar:
                        return BrobnarName;
                    case House.Dis:
                        return DisName;
                    case House.Logos:
                        return LogosName;
                    case House.Mars:
                        return MarsName;
                    case House.Sanctum:
                        return SanctumName;
                    case House.Shadows:
                        return ShadowsName;
                    case House.Untamed:
                        return UntamedName;
                }

                return string.Empty;
            }

            public static int Order(this House house)
            {
                return Convert.ToInt32(house);
            }
        }
    }
}