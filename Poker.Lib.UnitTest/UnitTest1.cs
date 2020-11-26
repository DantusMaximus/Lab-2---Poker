using NUnit.Framework;
namespace Poker.Lib.UnitTest
{
    /* Here we play around with testing functionality, and no proper "poker" tests
     should be written here! */
    public class Tests
    {
        int exampleSetupVar;
        [SetUp]
        public void Setup()
        {
            exampleSetupVar = 1337;
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test, Combinatorial]
        public void CombinatorialTestExample(
            [Values(1,2,3)] int x,
            [Values("A","B")]string s
            )
        {            
            Assert.True(x <4 && s[0] < 'C');
        }
        /*  IsCalled 6 Times, as follows:
            CombinatorialTestExample(1, "A")
            CombinatorialTestExample(1, "B")
            CombinatorialTestExample(2, "A")
            CombinatorialTestExample(2, "B")
            CombinatorialTestExample(3, "A")
            CombinatorialTestExample(3, "B")
        */
        [Test, Pairwise]
        public void PairwiseTestExample(
            [Values("a", "b", "c")] string a,
            [Values("+", "-")] string b,
            [Values("x", "y")] string c)
        {
            System.Console.WriteLine("{0} {0} {0}", a, b, c);
        }
        /*
            IsCalled 6 Times, as follows:
            a + y
            a - x
            b - y
            b + x
            c - x
            c + y
            approximatly tries 'every' combination to save toasters
        */

        [Test, Sequential]
        public void SequentialTestExample(
            [Values(1,2,3)] int x,
            [Values("C", "D", "E")] string s
            )
        {
            Assert.True(x <4 && s[0] >= 'C');
        }
           /* IsCalled 6 Times, as follows:
                SequentialTestExample(1, "A")
                SequentialTestExample(2, "B")
                SequentialTestExample(3, "E")
           */
        

    }
}