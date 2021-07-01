using System;
using System.Threading;

namespace GuessingGame
{
    class Program
    {
        // add scoring feature later on
        private static int score = 0;
        private static bool isGameEnded = false;
        static void Main(string[] args)
        {
            
            do
            {                
                StarProgram();
                Console.WriteLine("Your total score is : {0}!", score);
                ExitGame();
            } while (isGameEnded == false);

        }

        private static void GameChoice(string input)
        {

            switch (input)
            {
                case "1":
                    Console.WriteLine("You have chosen 'Guess the number'!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    GuessNumber guessNumber = new GuessNumber();
                    guessNumber.Main();
                    score += guessNumber.CurrentScore;                    
                    break;
                case "2":
                    Console.WriteLine("'Larger or smaller' coming up...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    LargerOrSmaller largerOrSmaller = new LargerOrSmaller();
                    largerOrSmaller.Main();
                    score += largerOrSmaller.CurrentScore;
                    break;                
                default:
                    Console.WriteLine("Choose only numbers 1 or 2!");
                    GameChoice(Console.ReadLine());
                    break;
            }
        }

        private static void StarProgram()
        {
            Console.WriteLine("Welcome to number games.\n" +
                "Choose your game style and press enter :\n 1 - Guess the number\n 2 - Larger or smaller");
            GameChoice(Console.ReadLine());
        }

        private static void ExitGame()
        {
            Console.WriteLine("Would you like to continue?\n" +
                "y/n");
            switch (Console.ReadLine())
            {
                case "y":
                    isGameEnded = false;
                    Console.Clear();
                    break;

                case "n":
                    isGameEnded = true;
                    break;

                default:
                    ExitGame();
                    break;
            }
        }
    }
}
