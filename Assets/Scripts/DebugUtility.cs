using UnityEngine;
using CrystalHive.Effects;
using CrystalHive.Cards;

namespace CrystalHive
{
	public class DebugUtility : MonoBehaviour
	{
		#region static properties

		public static DebugUtility Instance { get; private set; }

		#endregion static properties

		#region public properties

		public CardTemplate Gain1AemberTemplate;
		public CardTemplate Gain2AemberTemplate;
		public CardTemplate Gain3AemberTemplate;

		#endregion public properties

		#region lifecycle methods

		private void Awake()
		{
			if (Instance != null && Instance != this)
			{
				Destroy(this, 0.1f);
			}
			else
			{
				Instance = this;
			}
		}

		private void Start()
		{
			Gain1AemberTemplate.Play = new GainAemberEffect(1);
			Gain2AemberTemplate.Play = new GainAemberEffect(2);
			Gain3AemberTemplate.Play = new GainAemberEffect(3);
		}

		#endregion lifecycle methods

		#region public methods

		public void AddPlayerAember(int amount)
		{
			CardTemplate tmpl;
			if (amount == 1)
			{
				tmpl = Gain1AemberTemplate;

			}
			else if (amount == 2)
			{
				tmpl = Gain2AemberTemplate;
			}
			else
			{
				tmpl = Gain3AemberTemplate;
			}

			AddAember(PlayerDesignator.Player, tmpl);
		}

		public void AddOpponentAember(int amount)
		{
			CardTemplate tmpl;
			if (amount == 1)
			{
				tmpl = Gain1AemberTemplate;

			}
			else if (amount == 2)
			{
				tmpl = Gain2AemberTemplate;
			}
			else
			{
				tmpl = Gain3AemberTemplate;
			}

			AddAember(PlayerDesignator.Opponent, tmpl);
		}

		#endregion public methods

		#region private methods

		private void AddAember(PlayerDesignator owner, CardTemplate template)
		{
			Card card = new Card(template);
			card.Owner = card.Controller = owner;

			Game.Instance.PlayCard(card);
			Game.Instance.EndTurn();
		}

		#endregion private methods
	}
}