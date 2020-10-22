using Poker;
class Player : IPlayer
{
    private string name;

    public Player(string name)
    {
        this.name = name;
    }
    string IPlayer.Name { get => name; }
    ICard[] IPlayer.Hand { get; }

        HandType IPlayer.HandType { get; }

        int IPlayer.Wins { get; }

        ICard[] IPlayer.Discard { get; set; }
}