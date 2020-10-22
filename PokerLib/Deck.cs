using System.Collections.Generic;
namespace Poker
{
    class Deck
    {
        private List<ICard> Content { get; set; }
        public Deck()
        {
            for (int rank = 2; rank < 15; rank++)
            {
                for (int suite = 0; suite < 4; suite++)
                {
                    Content.Add(new Card((Rank)rank, (Suite)suite));
                }
            }
            Shuffle();
        }
        private void Shuffle() //Fishy Yates shuffle
        {
            System.Random random = new System.Random();
            int n = 0;
            int swapIndex = 0;
            while (n < Content.Count)
            {
                swapIndex = random.Next(n, Content.Count-1);
                var temp = Content[swapIndex];
                Content[swapIndex] = Content[n];
                Content[n] = temp;
            }
        }
         public ICard Draw()
        {
            var temp = Content[Content.Count-1];
            Content.RemoveAt(Content.Count-1);
            return temp;
        }
        private bool Exists(ICard card)
        {
            if (Content.Contains(card))
                return true;
            return false;
        }
    }



}