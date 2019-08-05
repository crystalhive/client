using CrystalHive.Cards;

namespace CrystalHive
{
    namespace Effects
    {
        public interface IEffect
        {
			void Apply(Game game, Card card);
			string Display();
        }
    }
}