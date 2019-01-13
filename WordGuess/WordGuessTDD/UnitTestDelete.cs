using WordGuess;
using Xunit;

namespace WordGuessTDD
{
    public class UnitTestDelete
    {
        private static readonly string _filePath = @"C:\Code\Lab 03- Word Guess Game\Lab03-Word_Guess_Game\WordGuess\WordGuess\data\TestWords.txt";
        [Fact]
        public void DeleteWordSuccess()
        {
            Program.CreateMyOwnWords();

            //a word that is in the file will pass
            string testWord = "packers"; ;
            Assert.True(Program.DeleteWord(testWord, _filePath));
        }

        [Fact]
        public void DeleteWordUnsuccessful()
        {
            Program.CreateMyOwnWords();

            //a word that is not in the file will fail
            string testWord = "pixi"; ;
            Assert.False(Program.DeleteWord(testWord, _filePath));
        }
    }
}