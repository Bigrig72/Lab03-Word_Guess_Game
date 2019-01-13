using System;
using System.IO;

namespace WordGuess
{
    public class Program
    {
        private static readonly string _filePath = @"C:\Code\Lab 03- Word Guess Game\Lab03-Word_Guess_Game\WordGuess\WordGuess\data\GameWords.txt";
        private static readonly string _gameHeaderFilePath = @"C:\Code\Lab 03- Word Guess Game\Lab03-Word_Guess_Game\WordGuess\WordGuess\data\GameHeader.txt";

        static void Main(string[] args)
        {
            CreateMyOwnWords();

            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();

            using (StreamReader streamReader = File.OpenText(_gameHeaderFilePath))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.Write(streamReader.ReadToEnd());
                Console.WriteLine("");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Hello & Welcome to the Word Guess Game");
            Console.WriteLine("Please select from the menu how you wish to start:");
            Console.WriteLine("1) Play Guessing Game");
            Console.WriteLine("2) View The Words To Guess");
            Console.WriteLine("3) Add A Word");
            Console.WriteLine("4) Delete A Word");
            Console.WriteLine("5) Exit");

            string result = Console.ReadLine();


            if (result == "1")
            {
                GuessingGame();
                return true;
            }
            else if (result == "2")
            {
                ViewWords();
                return true;
            }
            else if (result == "3")
            {
                Console.WriteLine("Enter a word to add: ");

                string addWord = Console.ReadLine();
                bool success = AddWord(addWord, _filePath);
                if (success)
                {
                    Console.WriteLine("You have successfully added a new word: {0}", addWord);
                }
                else
                {
                    Console.WriteLine("You were unsuccessful - either word existed already or an exception was thrown.");
                }

                return true;
            }
            else if (result == "4")
            {
                Console.WriteLine("Find below the words in case you want to delete");
                string[] wordsArray = File.ReadAllLines(_filePath);
                foreach (string word in wordsArray)
                {
                    Console.WriteLine(word);
                }

                Console.WriteLine("Enter a word you wish to delete: ");
                string deleteWord = Console.ReadLine().ToUpper();
                bool success = DeleteWord(deleteWord);
                if (success)
                {
                    Console.WriteLine("You have successfully deleted the word: {0}", deleteWord);
                }
                else
                {
                    Console.WriteLine("You were unsuccessful - either the word did not exist or there was an exception thrown.");
                }
                return true;
            }
            else if (result == "5")
            {
                return false;
            }

            return true;

        }

        public static void GuessingGame()
        {
            Random random = new Random();
            string[] wordsArray = File.ReadAllLines(_filePath);

            int randomWordIndex = random.Next(wordsArray.Length);
            string randomWordToGuess = wordsArray[randomWordIndex].ToUpper();

            char[] wordBeingGuessed = new char[randomWordToGuess.Length];
            for (int i = 0; i < wordBeingGuessed.Length; i++)
            {
                wordBeingGuessed[i] = '_';
            }

            Console.WriteLine("Guess a letter of your {0}-letter word: {1}", wordBeingGuessed.Length, string.Join(" ", wordBeingGuessed));

            bool stillGuessingWord = true;

            while (stillGuessingWord)
            {
                char guessedLetter = Console.ReadLine().ToUpper().Trim().ToCharArray()[0];

                if (WordContainsLetter(randomWordToGuess, guessedLetter))
                {
                    for (int i = 0; i < randomWordToGuess.Length; i++)
                    {
                        if (randomWordToGuess[i] == guessedLetter)
                        {
                            //replace underscore with guessed letter
                            wordBeingGuessed[i] = guessedLetter;
                        }
                    }

                    string wordBeingGuessedStr = new string(wordBeingGuessed);
                    if (wordBeingGuessedStr.Contains('_'))
                    {
                        Console.WriteLine("Correct! Guess another letter of your {0}-letter word: {1}", wordBeingGuessed.Length, string.Join(" ", wordBeingGuessed));
                    }
                    else
                    {
                        Console.WriteLine("You've guessed the whole word! {0}", string.Join(" ", wordBeingGuessed));
                        stillGuessingWord = false;
                    }
                }

                else
                {
                    //letter does not exist in the word the player is guessing
                    Console.WriteLine("The letter {0} does not exist in the word. Guess another letter of your {1}-letter word: {2}", guessedLetter, wordBeingGuessed.Length, string.Join(" ", wordBeingGuessed));
                }
            }
            Console.ReadKey();
        }

        public static bool WordContainsLetter(string word, char letter)
        {
            if (word.Contains(letter))
            {
                return true;
            }
            return false;
        }

        public static void ViewWords()
        {
            try
            {
                string[] wordsArray = File.ReadAllLines(_filePath);

                foreach (string word in wordsArray)
                {
                    Console.WriteLine(word);
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown" + ex.Message);
            }
        }

        public static bool AddWord(string addWord, string filePath)
        {
            try
            {
                addWord = addWord.ToUpper();
                string[] wordsArray = File.ReadAllLines(filePath);
                string wordsArrayStr = string.Join(" ", wordsArray);
                if (wordsArrayStr.Contains(addWord))
                {
                    return false; //word already exists in file.
                }

                using (StreamWriter streamWriter = File.AppendText(filePath))
                {
                    streamWriter.WriteLine(addWord);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public static void CreateMyOwnWords()
        {
            try
            {
                if (new FileInfo(_filePath).Length == 0)
                {
                    using (StreamWriter streamWriter = File.CreateText(_filePath))
                    {
                        streamWriter.WriteLine("PACKERS");
                        streamWriter.WriteLine("MOUNTAINEERS");
                        streamWriter.WriteLine("INDIANS");
                        streamWriter.WriteLine("APPALACHIAN");
                        streamWriter.WriteLine("SELINSGROVE");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Deletes a string from a text file.
        /// </summary>
        /// <param name="deleteWord">String to delete</param>
        /// <returns>
        /// True if the string successfully deleted from the file.
        /// False if the string does not exist in the file or exception is caught.
        /// </returns>
        public static bool DeleteWord(string deleteWord)
        {
            deleteWord = deleteWord.ToUpper();
            try
            {
                string[] wordsArray = File.ReadAllLines(_filePath);
                string[] newWordsArray = new string[wordsArray.Length];

                bool deletedWordSuccessful = false;
                using (StreamWriter streamWriter = File.CreateText(_filePath))
                {
                    int counter = 0;
                    for (int i = 0; i < wordsArray.Length; i++)
                    {
                        if (deleteWord == wordsArray[i])
                        {
                            deletedWordSuccessful = true;
                            continue;
                        }
                        else
                        {
                            newWordsArray[counter] = wordsArray[i];
                            counter++;
                        }
                    }

                    if (deletedWordSuccessful)
                    {
                        for (int i = 0; i < newWordsArray.Length; i++)
                        {
                            streamWriter.WriteLine(newWordsArray[i]);
                        }

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
                Console.ReadLine();
                return false;
            }
        }
    }
}