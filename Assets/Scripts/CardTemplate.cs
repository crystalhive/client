using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrystalHive
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
    }
}
