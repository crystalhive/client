using UnityEngine;
using CrystalHive.Effects;

namespace CrystalHive.Cards
{
    [CreateAssetMenu(fileName = "CardTemplate", menuName = "Resources/Card Template")]
    public class CardTemplate : ScriptableObject
    {
        #region public properties

        public int CardNumber;
        public Set Set;

        public string Name;

        [SerializeField]
        public House House;

        public int AemberBonus;

        [TextArea]
        public string FlavorText;

		#endregion public properties

		#region public properties

		public IEffect Constant { get; set; }

		public IEffect Action { get; set; }
		public IEffect Fight { get; set; }
		public IEffect Reap { get; set; }

		public IEffect Play { get; set; }
		public IEffect Destroyed { get; set; }
		public IEffect LeavesPlay { get; set; }

		#endregion public properties
	}
}
