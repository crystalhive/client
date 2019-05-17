using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrystalHive
{
    public class Card
    {
        #region public properties

        public CardTemplate Template { get; private set; }
        public House MaverickHouse { get; private set; }

        public House House
        {
            get
            {
                if (MaverickHouse != House.Unassigned)
                {
                    return MaverickHouse;
                }
                    
                return Template.House;
            }
        }

        public bool IsMaverick
        {
            get
            {
                return MaverickHouse != House.Unassigned;
            }
        }

        #endregion public properties

        public Card(CardTemplate template)
        {
            Template = template;
            MaverickHouse = House.Unassigned;
        }

        public Card(CardTemplate template, House maverickHouse)
        {
            Template = template;
            MaverickHouse = maverickHouse;
        }
    }
}
