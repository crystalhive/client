using System.Collections.Generic;
using UnityEngine;
using CrystalHive.Effects;
using CrystalHive.Cards;

namespace CrystalHive
{
	public class Game : MonoBehaviour
	{

		#region static properties

		public static Game Instance { get; private set; }

		public static readonly int DefaultKeyCost = 6;

		#endregion static properties

		#region public properties

		public Player Player { get; private set; }
		public Player Opponent { get; private set; }

		public PlayerDesignator ActivePlayerDesignator { get; private set; } = PlayerDesignator.Unset;

		public Player ActivePlayer
		{
			get
			{
				switch (ActivePlayerDesignator)
				{
					case PlayerDesignator.Player:
						return Player;
					case PlayerDesignator.Opponent:
						return Opponent;
					default:
						return null;
				}
			}
		}

		#endregion public properties

		#region private properties

		private int playerKeyCost = DefaultKeyCost;
		private int opponentKeyCost = DefaultKeyCost;

		private readonly List<IEffect> constantEffects = new List<IEffect>();
		private readonly List<IEffect> turnEffects = new List<IEffect>();
		private readonly List<IEffect> untilStartOfNextTurnEffects = new List<IEffect>();

		#endregion private properties

		#region lifecyle methods

		void Awake()
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

		void Start()
		{
			Player = CreatePlayerObject(PlayerDesignator.Player);
			Opponent = CreatePlayerObject(PlayerDesignator.Opponent);

			// TODO: Move to "StartGame"
			ActivePlayerDesignator = PlayerDesignator.Player;
		}

		#endregion lifecycle methods

		#region private methods

		private Player CreatePlayerObject(PlayerDesignator designator)
		{
			GameObject go = new GameObject();
			Player player = go.AddComponent<Player>();
			player.Designator = designator;

			go.transform.SetParent(transform);
			go.transform.position = Vector3.zero;

			return player;
		}

		#endregion private methods

		#region public methods

		public void EndTurn()
		{
			if (ActivePlayerDesignator == PlayerDesignator.Player)
			{
				ActivePlayerDesignator = PlayerDesignator.Opponent;
			}
			else
			{
				ActivePlayerDesignator = PlayerDesignator.Player;
			}

		}

		public void AddConstantEffect(IEffect effect)
		{
			// effect.Apply(this);
			// constantEffects.Add(effect);
		}

		public void AddTurnEffect(IEffect effect)
		{
			// effect.Apply(this);
			// turnEffects.Add(effect);
		}

		public void AddUntilStartOfNextTurnEffect(IEffect effect)
		{

		}

        public void RemoveConstantEffect()
        {

        }

        public Player GetPlayerFromDesignator(PlayerDesignator designator)
        {
            if (designator == PlayerDesignator.Player)
            {
                return Player;
            }
            else if (designator == PlayerDesignator.Opponent)
            {
                return Opponent;
            }

			return null;
        }

        public int GetCurrentKeyCost(PlayerDesignator designator)
        {
            if (designator == PlayerDesignator.Player)
            {
                return playerKeyCost;
            }
            else if (designator == PlayerDesignator.Opponent)
            {
                return opponentKeyCost;
            }

			return -1;
        }

        public void ModifyKeyCost(int total)
        {
            playerKeyCost += total;
            opponentKeyCost += total;
        }

        public void ModifyKeyCost(PlayerDesignator designator, int total)
        {
            if (designator == PlayerDesignator.Player)
            {
                playerKeyCost += total;
            }
            else if (designator == PlayerDesignator.Opponent)
            {
                opponentKeyCost += total;
            }
        }

		#endregion public methods

		#region card related methods

		public void PlayCard(Card card)
		{
			if (card.Owner != ActivePlayerDesignator)
			{
				Debug.LogError("Non-Active Player attempted to play a card!");
				return;
			}

			if (card.Template.Play != null)
			{
				Debug.Log(string.Format("Executed '{0}' effect.", card.Template.Play.Display()));
				card.Template.Play.Apply(this, card);
			}
		}

		#endregion card related methods
	}
}