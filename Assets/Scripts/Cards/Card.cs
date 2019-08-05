using CrystalHive.Effects;

namespace CrystalHive.Cards
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

		public PlayerDesignator Owner { get; set; }

		public PlayerDesignator Controller { get; set; }

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