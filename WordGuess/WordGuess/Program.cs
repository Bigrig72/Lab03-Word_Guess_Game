using System;
using System.IO;

namespace WordGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateMyOwnWords();

            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }

            //string[] linesArray = File.ReadAllLines(filePath);

            //foreach (string name in linesArray)
            //{
            //    Console.WriteLine(name);
            //}


        }

        private static bool MainMenu()
        {
            Console.Clear();

            Console.WriteLine("Hello and welcome to the Word Guess Game");
            Console.WriteLine("Please select from the menu how you wish to start");
            Console.WriteLine("1) Choose To Create words");
            Console.WriteLine("2) Choose To View The Words I Have Chosen");
            Console.WriteLine("3) Choose To Add A Word");
            Console.WriteLine("4) Choose To Delete A Word From The List");
            Console.WriteLine("5) Choose To Exit App");

            string result = Console.ReadLine();


            if (result == "1")
            {
                //GuessingGame();
                return true;
            }
            else if (result == "2")
            {
                ViewWords();
                return true;
            }
            else if (result == "3")
            {
                AddWord();
                return true;
            }
            else if (result == "4")
            {
                DeleteWord();
                return true;
            }
            else if (result == "5")
            {
                return false;
            }

            return true;

        }


        public static void AddWord()
        {
            string filePath = @"C:\Code\Lab 03- Word Guess Game\Lab03-Word_Guess_Game\WordGuess\WordGuess\TextFile1.txt";

            try
            {
                
                using (StreamWriter streamWriter = File.AppendText(filePath))

                {
                    try
                    {
                        Console.WriteLine("Enter a word to add");

                        string addWord = Console.ReadLine();

                        streamWriter.WriteLine(addWord);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception thrown" + ex.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.ReadLine();
            }
        }

        public static void ViewWords()
        {
            string filePath = @"C:\Code\Lab 03- Word Guess Game\Lab03-Word_Guess_Game\WordGuess\WordGuess\TextFile1.txt";


            try
            {

                string[] wordsArray = File.ReadAllLines(filePath);



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




        static void CreateMyOwnWords()
        {
            string filePath = @"C:\Code\Lab 03- Word Guess Game\Lab03-Word_Guess_Game\WordGuess\WordGuess\TextFile1.txt";

            try
            {
                if (new FileInfo(filePath).Length == 0)
                {
                    using (StreamWriter streamWriter = File.AppendText(filePath))
                    {
                        streamWriter.WriteLine("Packers");
                        streamWriter.WriteLine("Mountaineers");
                        streamWriter.WriteLine("Indians");
                        streamWriter.WriteLine("AppState");
                        streamWriter.WriteLine("Selinsgrove");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
                Console.ReadKey();
            }
        }

        static void DeleteWord()
        {
            string filePath = @"C:\Code\Lab 03- Word Guess Game\Lab03-Word_Guess_Game\WordGuess\WordGuess\TextFile1.txt";

            try
            {
                Console.WriteLine("Find below the words in case you want to delete");
                string[] wordsArray = File.ReadAllLines(filePath);
                string[] newWordsArray = new string[wordsArray.Length -1];


                foreach (string word in wordsArray)
                {
                    Console.WriteLine(word);
                }

                Console.ReadLine();
               
                Console.WriteLine("enter a word you wish to delete");
                string delete = Console.ReadLine();

                using (StreamWriter streamWriter = new StreamWriter(filePath))
                  {

                int counter = 0;

                for (int i = 0; i < wordsArray.Length; i++)
                {
                    if (delete == wordsArray[i])
                    {
                            continue;
                       
                    }
                    else
                     {
                         newWordsArray[i] = wordsArray[i];
                         counter++;

                     }
                  
                  
                }
                
                 for (int i = 0; i < newWordsArray.Length; i++)
                    {

                        streamWriter.Write(newWordsArray[i]);
                    }

                    }                
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
                Console.ReadLine();
            }
        }
    }
}