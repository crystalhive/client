namespace CrystalHive
{
    namespace Cards
    {
        public enum CardType
        {
            Action,
            Creature,
            Artifact,
            Upgrade
        }

        static class CardTypeExtensions
        {
            public const string ActionName = "Action";
            public const string CreatureName = "Creature";
            public const string ArtifactName = "Artifact";
            public const string UpgradeName = "Upgrade";

            public static string Name(this CardType cardType)
            {
                switch (cardType)
                {
                    case CardType.Action:
                        return ActionName;
                    case CardType.Creature:
                        return CreatureName;
                    case CardType.Artifact:
                        return ArtifactName;
                    case CardType.Upgrade:
                        return UpgradeName;
                }

                return string.Empty;
            }
        }
    }
}