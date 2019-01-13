using WordGuess;
using Xunit;

namespace WordGuessTDD
{
    public class UnitTestDelete
    {
        [Fact]
        public void DeleteWordSuccess()
        {
            Program.CreateMyOwnWords();

            //a word that is in the file will pass
            string testWord = "packers"; ;
            Assert.True(Program.DeleteWord(testWord));
        }

        [Fact]
        public void DeleteWordUnsuccessful()
        {
            Program.CreateMyOwnWords();

            //a word that is not in the file will fail
            string testWord = "pixi"; ;
            Assert.False(Program.DeleteWord(testWord));
        }
    }
}