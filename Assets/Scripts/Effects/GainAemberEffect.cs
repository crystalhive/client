
using CrystalHive.Cards;

namespace CrystalHive.Effects
{
	public class GainAemberEffect : IEffect
	{
		public int Amount { get; private set; }

		/// <summary>
		/// Create a new GainAemberEffect that will cause the owner of the card
		/// to gain X (amount) number of amber.
		/// </summary>
		/// <param name="amount">The amount of aember you want the controller to gain.</param>
		public GainAemberEffect(int amount)
		{
			Amount = amount;
		}

		public void Apply(Game game, Card card)
		{
			Player player = game.GetPlayerFromDesignator(card.Controller);
			player.AddAember(Amount);
		}

		public string Display()
		{
			return string.Format("Gain {0} :aember:", Amount);
		}
	}
}
