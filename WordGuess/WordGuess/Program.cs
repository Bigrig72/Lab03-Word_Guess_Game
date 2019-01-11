using System;
using System.IO;

namespace WordGuess
{
    class Program
    {
       
        static void Main(string[] args)

        {
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
            Console.WriteLine("1) Choose To Play The Guess Word Game");        
            Console.WriteLine("2) Choose To View The Words I Have Chosen");
            Console.WriteLine("3) Choose To Add A Word");
            Console.WriteLine("4) Choose To Delete A Word From The List");
            Console.WriteLine("5) Choose To Exit App");

            string result = Console.ReadLine();

           
            if (result == 1)
            {
                GuessingGame();
                return true;
            }
            else if (result == 2)
            {
                ViewWords();
                return true;
            }
            else if (result == 3)
            {
                AddWord();
                return true;
            }
            else if (result == 4)
            {
                DeleteWord();
                return true;
            }
            else if (result == 5)
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
                using (StreamWriter streamWriter = new StreamWriter(filePath)) 

                {
                    try
                    {
                        Console.WriteLine("Enter a word to add");
                        String addWord = Console.ReadLine();
                    
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
    }
}
