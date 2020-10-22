using Poker;
class Player : Poker.IPlayer
{
    string IPlayer.Name { get; }

        ICard[] IPlayer.Hand { get; }

        HandType IPlayer.HandType { get; }

        int IPlayer.Wins { get; }

        ICard[] IPlayer.Discard { get; set; }
}