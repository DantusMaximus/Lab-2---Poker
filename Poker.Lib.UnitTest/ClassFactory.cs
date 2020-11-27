using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Reflection;  
using System.Reflection.Emit;  
using System.Text;  
using System.Threading.Tasks;  
namespace Poker.Lib.UnitTest
{
    class MyClassBuilder  { 
        AssemblyName assemblyName;
        public MyClassBuilder  (string className,string testName,HandType prefered, string cardsString){
              assemblyName = new AssemblyName(className);
        }
    /*
        private TypeBuilder CreateClass(){
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(this.asemblyName, AssemblyBuilderAccess.Run);
        }
       

        
        /* såhär ska klassen som är byggd se ut:
            class Pair{
                String[] cardString;
                static int[][] PositionCombos = ScoreLogicTest.allValidPositionCombos;


                [Test, Combinatorial]
                public void Assert_DetermineHandType_CorrectlyOutputsPair(
                [ValueSource("PositionCombos")] int[] positionsPermutation,
                [Values(
                        "♣2♦3♥4♥A♣A",
                        "♣K♦2♥4♥K♣5"
                    )] string cardsString
                )
                {
                    AssertCorrectHandType(HandType.Pair, cardsString, positionsPermutation);
                }
            }
        */
    }
}