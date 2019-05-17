using System.Collections;
using System.Collections.Generic;

namespace CrystalHive
{
    namespace Utils
    {
        public static class TokenHelper
        {
            #region static properties

            public static readonly int[] DamageTokenValues = { 5, 3, 1 };
            public static readonly int[] PowerTokenValues = { 5, 3, 1 };
            public static readonly int[] ArmorTokenValues = { 1 };

            #endregion static properties

            #region public static methods

            public static List<int> DamageTokensForDamage(int damage)
            {
                return TokensForValue(DamageTokenValues, damage);
            }

            public static List<int> PowerTokensForPower(int power)
            {
                return TokensForValue(PowerTokenValues, power);
            }

            public static List<int> ArmorTokensForArmor(int armor)
            {
                return TokensForValue(ArmorTokenValues, armor);
            }

            #endregion public static methods

            #region private static methods

            private static List<int> TokensForValue(int[] tokenValues, int value)
            {
                List<int> tokens = new List<int>();
                int valueLeft = value;

                foreach (int tokenValue in tokenValues)
                {
                    int tokenCount = valueLeft / tokenValue;
                    valueLeft %= tokenValue;

                    for (int i = 0; i < tokenCount; ++i)
                    {
                        tokens.Add(tokenValue);
                    }

                    if (valueLeft == 0)
                    {
                        break;
                    }
                }

                return tokens;
            }

            #endregion private static methods
        }
    }
}