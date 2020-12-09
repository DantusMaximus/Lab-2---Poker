namespace Poker
{
    class Card : ICard
    {
        Rank rank;
        Suite suite;
        public Suite Suite => suite;

        public Rank Rank => rank;
        public Card(Rank rank, Suite suite)
        {
            this.rank = rank;
            this.suite = suite;
        }
        public override bool Equals(object otherObject)
        {
            var otherCard = (Card)otherObject;
            if (this.Rank != otherCard.Rank)
                return false;
            if (this.Suite != otherCard.Suite)
                return false;
            return true;
        }
 
    }
}