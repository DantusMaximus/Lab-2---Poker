using System.Collections.Generic;
using Poker;
class CheatDeck : Deck
{

    public CheatDeck()
    {
        Content = new List<ICard>();
        
        Content.Add(new Card((Rank)3, (Suite)2));
        Content.Add(new Card((Rank)2, (Suite)2));
        Content.Add(new Card((Rank)14, (Suite)2));
        Content.Add(new Card((Rank)4, (Suite)2));
        Content.Add(new Card((Rank)5, (Suite)2));
     
        Content.Add(new Card((Rank)3, (Suite)2));
        Content.Add(new Card((Rank)2, (Suite)2));
        Content.Add(new Card((Rank)6, (Suite)2));
        Content.Add(new Card((Rank)4, (Suite)2));
        Content.Add(new Card((Rank)5, (Suite)2));

        playerTwoPair(Rank.Two, Rank.Six);
        Content.Add(new Card((Rank)12, Suite.Clubs));

        Content.Add(new Card((Rank)3, Suite.Clubs));
        Content.Reverse();
    }
    private void playerRoyalStraightFlush(int suite)
    {
        Content.Add(new Card((Rank)10, (Suite)suite));
        Content.Add(new Card((Rank)11, (Suite)suite));
        Content.Add(new Card((Rank)12, (Suite)suite));
        Content.Add(new Card((Rank)13, (Suite)suite));
        Content.Add(new Card((Rank)14, (Suite)suite));
    }
    private void playerStraightFlush(int suite)
    {
        Content.Add(new Card((Rank)5, (Suite)suite));
        Content.Add(new Card((Rank)6, (Suite)suite));
        Content.Add(new Card((Rank)7, (Suite)suite));
        Content.Add(new Card((Rank)8, (Suite)suite));
        Content.Add(new Card((Rank)9, (Suite)suite));
    }
    private void playerStraight()
    {
        Content.Add(new Card((Rank)10, (Suite)0));
        Content.Add(new Card((Rank)11, (Suite)0));
        Content.Add(new Card((Rank)12, (Suite)0));
        Content.Add(new Card((Rank)13, (Suite)0));
        Content.Add(new Card((Rank)14, (Suite)2));
    }
    private void playerFlush(int suite)
    {
        Content.Add(new Card((Rank)9, (Suite)suite));
        Content.Add(new Card((Rank)11, (Suite)suite));
        Content.Add(new Card((Rank)12, (Suite)suite));
        Content.Add(new Card((Rank)13, (Suite)suite));
        Content.Add(new Card((Rank)14, (Suite)suite));
    }
    private void playerFourOfAKind(Rank rank)
    {
        Content.Add(new Card(rank, (Suite)0));
        Content.Add(new Card(rank, (Suite)1));
        Content.Add(new Card(rank, (Suite)2));
        Content.Add(new Card(rank, (Suite)3));
    }
    private void playerThreeOfAKind(Rank rank)
    {
        Content.Add(new Card(rank, (Suite)0));
        Content.Add(new Card(rank, (Suite)1));
        Content.Add(new Card(rank, (Suite)2));
    }
    private void playerTwoPair(Rank rank1, Rank rank2){
        playerPair(rank1);
        playerPair(rank2);
    }
    private void playerPair(Rank rank)
    {
        Content.Add(new Card(rank, (Suite)0));
        Content.Add(new Card(rank, (Suite)1));
    }


}