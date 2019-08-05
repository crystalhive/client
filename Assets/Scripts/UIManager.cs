using TMPro;
using UnityEngine;

namespace CrystalHive
{
	public class UIManager : MonoBehaviour
	{
		#region constants

		public const string PlayerName = "PLAYER";
		public const string PlayerActiveName = "[PLAYER]";
		public const string OpponentName = "OPPONENT";
		public const string OpponentActiveName = "[OPPONENT]";

		#endregion constants

		#region static properties

		public static UIManager Instance { get; private set; }

		#endregion static properties

		#region public properties

		public TextMeshProUGUI playerLabel;
		public TextMeshProUGUI playerAemberTotal;
		public TextMeshProUGUI playerForgeCost;

		public TextMeshProUGUI opponentLabel;
		public TextMeshProUGUI opponentAemberTotal;
		public TextMeshProUGUI opponentForgeCost;

		#endregion public properties

		#region private properties

		private PlayerDesignator activePlayer;

		#endregion private properties

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

			activePlayer = PlayerDesignator.Unset;
		}

		private void Update()
		{
			PlayerDesignator newActivePlayer = Game.Instance.ActivePlayerDesignator;

			if (newActivePlayer != activePlayer)
			{
				activePlayer = newActivePlayer;

				if (activePlayer == PlayerDesignator.Player)
				{
					playerLabel.SetText(PlayerActiveName);
					opponentLabel.SetText(OpponentName);
				}
				else
				{
					playerLabel.SetText(PlayerName);
					opponentLabel.SetText(OpponentActiveName);
				}
			}

			playerAemberTotal.SetText(Game.Instance.GetPlayerFromDesignator(PlayerDesignator.Player).Aember.ToString());
			playerForgeCost.SetText(Game.Instance.GetCurrentKeyCost(PlayerDesignator.Player).ToString());

			opponentAemberTotal.SetText(Game.Instance.GetPlayerFromDesignator(PlayerDesignator.Opponent).Aember.ToString());
			opponentForgeCost.SetText(Game.Instance.GetCurrentKeyCost(PlayerDesignator.Opponent).ToString());
		}

		#endregion lifecycle methods
	}
}
