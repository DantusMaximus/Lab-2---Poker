using Poker;
class Player : IPlayer
{
    private string name;
    private ICard[] hand;
    private int cardAmmount;
    private int maxCardAmmount = 5;
    private ICard[] discard;

    public Player(string name)
    {
        hand = new ICard[maxCardAmmount];
        discard = new ICard[0];
        this.name = name;
        cardAmmount = 0;
    }
    public void Give(ICard[] givenCards)
    {
        //TODO felhantering
        int i = 0;
        while(cardAmmount < maxCardAmmount)
        {
            hand[cardAmmount] = givenCards[i++];
            cardAmmount++;
        }
    }

    string IPlayer.Name { get => name; }
    ICard[] IPlayer.Hand { get => hand; }

    HandType IPlayer.HandType { get; }

    int IPlayer.Wins { get; }

    ICard[] IPlayer.Discard { get{return discard;} set{
        discard = new ICard[value.Length];
        discard = value;
        for(int i = 0; i< cardAmmount;i++){
            if(discard[i].Equals(hand[i])){

            }
        }
    }
    }
}