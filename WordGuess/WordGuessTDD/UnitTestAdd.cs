using System;
using System.IO;
using WordGuess;
using Xunit;

namespace WordGuessTDD
{
    public class UnitTestAdd
    {
        private static readonly string _filePath = @"C:\Code\Lab 03- Word Guess Game\Lab03-Word_Guess_Game\WordGuess\WordGuess\data\TestWords.txt";

        [Fact]
        public void AddWordSuccessfully()
        {
            CreateTestFile();

            //a word that is not in file will pass
            string testWord = "lemons";
            Assert.True(Program.AddWord(testWord, _filePath));
        }

        [Fact]
        public void AddWordUnsuccefully()
        {
            CreateTestFile();

            //a word that is in the file will fail
            string testWord = "coffee"; ;
            Assert.False(Program.AddWord(testWord, _filePath));
        }

        private static void CreateTestFile()
        {
            try
            {
                using (StreamWriter streamWriter = File.CreateText(_filePath))
                {
                    streamWriter.WriteLine("COFFEE");
                    streamWriter.WriteLine("TEA");
                    streamWriter.WriteLine("MILK");
                    streamWriter.WriteLine("SUGAR");
                    streamWriter.WriteLine("HONEY");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
                Console.ReadKey();
            }
        }
    }
}