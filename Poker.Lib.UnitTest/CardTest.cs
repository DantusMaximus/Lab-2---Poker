using NUnit.Framework;
namespace Poker.Lib.UnitTest
{
public class CardTest{
[SetUp]
        public void Setup()
        {
        }
[Test]
public void Assert_Constructor_CreatesCards(){
    var rank = Rank.Seven;
    var suite = Suite.Hearts;
    Card card = new Card(rank, suite);
    Assert.True(card.Suite == suite);
    Assert.True(card.Rank == rank);
}
[Test]
public void Assert_Equals_ReturnsTrueOnEqual(){
    Card card1 = new Card(Rank.Ace, Suite.Spades);
    Card card2 = new Card(Rank.Ace, Suite.Spades);
    Assert.True(card1.Equals(card2));
}
[Test]
public void Assert_Equals_ThrowsNullExceptionOnNull(){
    Card card = new Card(Rank.Ace, Suite.Spades);
    Assert.Throws(     typeof(System.NullReferenceException), delegate{card.Equals(null);}    );
}

}
}