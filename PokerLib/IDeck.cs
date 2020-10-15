namespace Poker.Lib{
public delegate void OnMix(IDeck deck);

    public interface IDeck{
        ICard[] Deck{get;}
        event OnMix Mix;
    }
}