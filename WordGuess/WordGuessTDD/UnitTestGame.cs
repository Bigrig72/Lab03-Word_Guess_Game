using WordGuess;
using Xunit;

namespace WordGuessTDD
{
    public class UnitTestGame
    {
        [Fact]
        public void WordContainsLetter()
        {
            //a word that contains the letter will pass
            string testWord = "packers";
            char testLetter = 'p';
            Assert.True(Program.WordContainsLetter(testWord, testLetter));
        }

        [Fact]
        public void WordDoesNotContainLetter()
        {
            //a word that does not contain the letter will pass
            string testWord = "packers";
            char testLetter = 'x';
            Assert.False(Program.WordContainsLetter(testWord, testLetter));
        }
    }
}