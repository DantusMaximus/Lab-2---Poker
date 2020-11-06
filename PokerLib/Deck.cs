using System.Collections.Generic;
namespace Poker
{
    class Deck
    {

        private List<ICard> Content { get; set; }
        private List<ICard> discardPile;

        public Deck()
        {
            discardPile = new List<ICard>();
            Content = new List<ICard>();
            for (int rank = 2; rank < 15; rank++)
            {
                for (int suite = 0; suite < 4; suite++)
                {
                    Content.Add(new Card((Rank)rank, (Suite)suite));
                }
            }
            Randomize();
        }

        private void Randomize() //Fishy Yates shuffle
        {
            System.Random random = new System.Random();
            int n = Content.Count - 1;
            int swapIndex = 0;
            while (0 < n)
            {
                swapIndex = random.Next(n + 1);
                var temp = Content[swapIndex];
                Content[swapIndex] = Content[n];
                Content[n] = temp;
                n--;
            }
        }
        public void ShuffleInCards()
        {
            Content.AddRange(discardPile);
            discardPile.Clear();
            Randomize();
        }
        public List<ICard> Draw(int cardAmmount)
        {
            List<ICard> temp = new List<ICard>();
            for (int i = 0; i < cardAmmount; i++)
            {
                int cardIndex = Content.Count - 1;
                temp.Add(Content[cardIndex]);
                Content.RemoveAt(cardIndex);
            }
            discardPile.AddRange(temp);
            return temp;
        }
    }
}