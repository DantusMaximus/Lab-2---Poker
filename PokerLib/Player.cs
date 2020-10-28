using Poker;
using System.Collections.Generic;
class Player : IPlayer
{
    private string name;
    public Hand hand;
    private ICard[] discard;
    private int wins;

    public Player(string name)
        : this(name,0){

    }
    public Player(string name, int wins){        
        this.wins = wins;
        discard = new ICard[0];
        this.name = name;
        hand = new Hand(this);
        this.wins = wins;
    }
    public void Give(List<ICard> givenCards)
    {
        while (!hand.IsFull())
        {
            int lastIndex = givenCards.Count - 1;
            hand.Add(givenCards[lastIndex]);
            givenCards.RemoveAt(lastIndex);
        }
    }
    public void RemoveCards()
    {
        foreach (var disc in discard)
        {
            if (hand.Contains(disc))
            {
                hand.Remove(disc);
            }
        }
    }
    public void JustWon(){
        wins++;
    }

    string IPlayer.Name { get => name; }
    ICard[] IPlayer.Hand { get => hand.Cards.ToArray(); }

    HandType IPlayer.HandType { get => hand.HandType; }

    int IPlayer.Wins { get => wins; }

    ICard[] IPlayer.Discard { get => discard; set { discard = value; } }
}