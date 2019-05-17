using System.Collections.Generic;
using UnityEngine;
using CrystalHive.Effects;

namespace CrystalHive
{
    public class Game : MonoBehaviour
    {
        public enum PlayerDesignator
        {
            Unset,
            Player,
            Opponent
        }

        #region static properties

        public static Game Instance { get; private set; }

        public static readonly int DefaultKeyCost = 6;

        #endregion static properties

        #region public properties

        public Player Player { get; private set; }
        public Player Opponent { get; private set; }

        private PlayerDesignator _activePlayer = PlayerDesignator.Unset;
        public Player ActivePlayer
        {
            get
            {
                switch (_activePlayer)
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

        private readonly List<IEffect> constantEffects;
        private readonly List<IEffect> turnEffects;

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
                DontDestroyOnLoad(this);
            }
        }

        void Start()
        {
            Player = CreatePlayerObject();
            Opponent = CreatePlayerObject();
        }

        #endregion lifecycle methods

        #region private methods

        Player CreatePlayerObject()
        {
            GameObject go = new GameObject();
            Player player = go.AddComponent<Player>();
            go.transform.SetParent(transform);
            go.transform.position = Vector3.zero;

            return player;
        }

        #endregion private methods

        #region public methods

        public void EndTurn()
        {
            PlayerDesignator activePlayer = _activePlayer;

        }

        public void AddConstantEffect(IEffect effect)
        {
            effect.Apply(this);
            constantEffects.Add(effect);
        }

        public void AddTurnEffect(IEffect effect)
        {
            effect.Apply(this);
            turnEffects.Add(effect);
        }

        public void RemoveConstantEffect()
        {

        }

        public Player GetPlayerFromDesignator(PlayerDesignator designator)
        {
            if (designator == PlayerDesignator.Opponent)
            {
                return Opponent;
            }
            else
            {
                return Player;
            }
        }

        public int GetCurrentKeyCost(Player player)
        {
            if (player == Player)
            {
                return playerKeyCost;
            }
            else
            {
                return opponentKeyCost;
            }
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
            else
            {
                opponentKeyCost += total;
            }
        }

        #endregion public methods
    }
}