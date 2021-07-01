using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame
{
    class GuessNumber : Game
    {
        private const int min = 1;       
        private static int guessCounter;        
        private static bool isGuessed = false;        
        private static int guessedNumber;            


        // main method to start the guessnumber game from program.cs
        public void Main()
        {
            rnd = new Random();

            Console.WriteLine("Hello. This is a number guessing game.");
            Console.WriteLine("To play, first select difficulty.\n" +
                "Type a number and press enter:\n" +
                " 1 - easy\n 2 - medium\n 3 - hard\n 4 - free mode");

            DifficultySetting(Console.ReadLine());
            SetRandomNumber();
            GamePlay();
            EndGame();
        }        



        // sets min, max and guesscounter fields according to chosen difficulty
        // also handles input exceptions
        private void DifficultySetting(string input)
        {           

            switch (input)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("You've chosen easy difficulty.");
                    max = 10;
                    guessCounter = 3;
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("You've chosen medium difficulty.");
                    max = 50;
                    guessCounter = 5;
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("You've chosen hard difficulty.");
                    max = 100;
                    guessCounter = 7;
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("You've chosen free mode.");
                    FreeModeMax();
                    guessCounter = max;
                    break;
                default:
                    Console.WriteLine("Choose only numbers from 1 - 3!");
                    DifficultySetting(Console.ReadLine());
                    break;
            }
        }


        // method to set a freemode difficulty with number of guesses equal to max value
        private void FreeModeMax()
        {
            int num;

            Console.WriteLine("Choose the max number size for your game: ");
            if (int.TryParse(Console.ReadLine(), out num) && num > min)
            {
                max = num;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Choose only natural numbers!");
                FreeModeMax();
            }
        }

        // sets a number player needs to guess
        private void SetRandomNumber()
        {
            numberToGuess = rnd.Next(min, max + 1);

            Console.WriteLine("------------------------------");
            Console.WriteLine("Guess a number from {0} to {1}", min, max);
        }

        // informs the player if he guessed the number correctly
        // loops until guessCounter is 0, once it reaches 0 it breaks the loop
        // if player guessed number, it sets the isGuessed bool to true and breaks the loop
        private void GamePlay()
        {
            while (isGuessed == false && guessCounter > 0)
            {
                guessedNumber = -1;
                Console.WriteLine("You have {0} tries left", guessCounter);

                while (guessedNumber <= 0)
                {
                    guessedNumber = GuessingTheNumber();
                    if (numberToGuess == guessedNumber)
                    {
                        isGuessed = true;
                        break;
                    }
                    else if (guessedNumber > numberToGuess && guessedNumber <= max && guessedNumber >= min)
                    {
                        Console.WriteLine("The number is smaller.\n");
                    }
                    else if (guessedNumber < numberToGuess && guessedNumber <= max && guessedNumber >= min)
                    {
                        Console.WriteLine("The number is larger.\n");
                    }
                }
            }
        }

        // method to see if player input is inside min and max values
        // also checks if player entered int or some other value
        private int GuessingTheNumber()
        {
            int num;

            if (int.TryParse(Console.ReadLine(), out num) && num >= min && num <= max)
            {
                guessCounter--;
                return num;
            }
            else
            {
                Console.WriteLine("Enter only numbers from {0} to {1}", min, max);
                return -1;
            }
        }

        // checks winning conditions and informs the player of victory or loss
        private void EndGame()
        {
            Console.WriteLine("------------------------------");
            if (isGuessed == true)
            {
                Console.WriteLine("Congratulations. The number was {0}", numberToGuess);
                currentScore++;
            }
            else
                Console.WriteLine("You fail! The number was {0}", numberToGuess);
        }

    }
}
