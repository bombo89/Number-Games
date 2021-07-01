using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GuessingGame
{
    
    class LargerOrSmaller : Game
    {
        
        private static int currentNumber;
        private static bool isLost = false;    


        public void Main()
        {
            rnd = new Random();

            Console.WriteLine("Hello. This is a larger of smaller guessing game.");
            Console.WriteLine("To play, first select difficulty.\n" +
                "Type a number and press enter:\n" +
                " 1 - easy\n 2 - medium\n 3 - hard");

            DifficultySettings(Console.ReadLine());

            SetRandomNumber();            
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("----------------Current number is {0}----------------", currentNumber);

            GamePlay();
            
        }

        private void SetRandomNumber()
        {
            currentNumber = rnd.Next(max);
        }

        private void DifficultySettings(string input)
        {
            Console.Clear();

            switch (input)
            {
                case "1":
                    Console.WriteLine("You've chosen easy difficulty.");
                    max = 10;
                    break;
                case "2":
                    Console.WriteLine("You've chosen medium difficulty.");
                    max = 50;
                    break;
                case "3":
                    Console.WriteLine("You've chosen hard difficulty");
                    max = 100;
                    break;
                default:
                    Console.WriteLine("Choose only numbers 1 - 3!");
                    DifficultySettings(Console.ReadLine());
                    break;
            }
        }

        private void GamePlay()
        {
            while(isLost == false)
            {
                Choice();
            }
            isLost = false;
        }

        private void Choice()       
        {            
            Console.Clear();
            Console.WriteLine("\n\n\n          *****Score : {0}***** \n\n\n", currentScore);
            Console.WriteLine("----------------Current number is {0}----------------", currentNumber);
            Console.WriteLine("Press ▲ if the next number is larger or ▼ if it's smaller");

            int num = (int)Console.ReadKey(true).Key;

            switch (num)
            {
                case 38:                    
                    Console.WriteLine("Larger you say?");
                    Larger();
                    break;
                case 40:                    
                    Console.WriteLine("Smaller you say?");
                    Smaller();
                    break;
                default:                    
                    Console.WriteLine("Press ▲ for larger or ▼ for smaller");
                    Choice();
                    break;
            }
        }

        private void Larger()
        {
            numberToGuess = rnd.Next(max);
            Console.WriteLine(numberToGuess);
            if(currentNumber == numberToGuess)
            {
                Larger();
            }
            else if(currentNumber < numberToGuess)
            {
                Console.WriteLine("You are correct.");
                currentNumber = numberToGuess;
                currentScore++;
                Thread.Sleep(2000);
                Choice();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wrong biaaaaaatch!!! It was {0}", numberToGuess);
                Console.WriteLine("Final score = {0}", currentScore);
                isLost = true;
            }
        }
        private void Smaller()
        {
            numberToGuess = rnd.Next(max);
            Console.WriteLine(numberToGuess);
            if (currentNumber == numberToGuess)
            {
                Smaller();
            }
            else if (currentNumber > numberToGuess)
            {
                Console.WriteLine("You are correct.");
                currentNumber = numberToGuess;
                currentScore++;
                Thread.Sleep(2000);
                Choice();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wrong biaaaaaatch!!! It was {0}", numberToGuess);
                Console.WriteLine("Final score = {0}", currentScore);
                isLost = true;
            }
        }

    }
}
