namespace CrystalHive
{
	public enum PlayerDesignator
	{
		Unset,
		Player,
		Opponent
	}

	public static class PlayerDesignatorExtensions
	{
		public static PlayerDesignator Inverse(this PlayerDesignator designator)
		{
			if (designator == PlayerDesignator.Player)
			{
				return PlayerDesignator.Opponent;
			}
			else if (designator == PlayerDesignator.Opponent)
			{
				return PlayerDesignator.Player;
			}

			return PlayerDesignator.Unset;
		}
	}
}
