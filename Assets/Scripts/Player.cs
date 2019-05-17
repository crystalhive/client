using System.Collections.Generic;
using UnityEngine;

namespace CrystalHive
{
    public class Player : MonoBehaviour
    {
        public enum Key
        {
            Red,
            Blue,
            Yellow
        }

        #region static properties

        private static readonly Key[] KeyForgeOrder = { Key.Red, Key.Blue, Key.Yellow };

        #endregion static properties

        #region properties

        private HashSet<Key> forgedKeys = new HashSet<Key>();

        public bool RedKeyForged
        {
            get
            {
                return forgedKeys.Contains(Key.Red);
            }
        }

        public bool BlueKeyForged
        {
            get
            {
                return forgedKeys.Contains(Key.Blue);
            }
        }

        public bool YellowKeyForged
        {
            get
            {
                return forgedKeys.Contains(Key.Yellow);
            }
        }

        public int Aember { get; private set; } = 0;

        #endregion properties

        #region lifecycle methods

        void Start()
        {
        }

        #endregion lifecycle methods

        #region public methods

        public void Reset()
        {
            forgedKeys = new HashSet<Key>();
            Aember = 0;
        }

        public bool ForgeKey()
        {
            int keyCost = Game.Instance.GetCurrentKeyCost(this);
            if (Aember >= keyCost)
            {
                RemoveAember(keyCost);
                int forgedKeyCount = forgedKeys.Count;
                Key color = KeyForgeOrder[forgedKeyCount];
                forgedKeys.Add(color);

                return true;
            }

            return false;
        }

        public void AddAember(int count)
        {
            Aember += 1;
        }

        public void RemoveAember(int count)
        {
            AddAember(-count);
        }

        #endregion public methods
    }
}