using System;

namespace CrystalHive
{
    namespace Cards
    {
        public enum Set
        {
            COTA,
            AOA
        }

        static class SetExtensions
        {
            public const string COTAName = "Call of the Archons";
            public const string AOAName = "Age of Acension";

            public static string Name(this Set set)
            {
                switch (set)
                {
                    case Set.COTA:
                        return COTAName;
                    case Set.AOA:
                        return AOAName;
                }

                return string.Empty;
            }

            public static int Order(this Set set)
            {
                return Convert.ToInt32(set);
            }
        }
    }
}