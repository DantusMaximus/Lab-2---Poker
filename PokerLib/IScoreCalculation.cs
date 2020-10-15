namespace Poker.Lib
{
    public delegate IPlayer OnCheckForWinner(IPlayer[] Players);
    public delegate void OnSetHandType(IPlayer Player);
    public interface IScoreCalculation{
        event OnCheckForWinner CheckForWinner;
        event OnSetHandType SetHandTypes;
    }
}