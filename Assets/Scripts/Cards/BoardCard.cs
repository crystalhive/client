namespace CrystalHive.Cards
{
    public class BoardCard
    {
        #region public properties

        public Player Owner { get; private set; }
        public Player Controller { get; private set; }

        public Card Card { get; private set; }

        #endregion public properties

        public BoardCard(Player owner, Card card)
        {
            Owner = owner;
            Controller = owner;
            Card = card;
        }

        #region public methods

        public void RestoreControl()
        {
            ChangeController(Owner);
        }

        public void ChangeController(Player newController)
        {
            Controller = newController;
        }

        #endregion public methods
    }
}