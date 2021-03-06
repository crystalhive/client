﻿using CrystalHive.Cards;

namespace CrystalHive
{
    namespace Effects
    {
        public interface IEffect
        {
            void Apply(Game game);
            void Unapply(Game game);

            void OnTurnBegin(Game game);
            void OnPlay(Game game, Card card);
            void OnTurnEnd(Game game);
        }
    }
}