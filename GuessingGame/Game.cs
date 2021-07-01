using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame
{
    public class Game
    {
        protected Random rnd;
        protected int max;
        protected int numberToGuess;
        protected int currentScore;
        public int CurrentScore
        {
            get { return currentScore; }
            set { value = currentScore; }
        }

    }
}
