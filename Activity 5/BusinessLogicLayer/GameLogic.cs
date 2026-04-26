/*
 * Shawn Kripner
 * CST-250
 * 4/20/2026
 * Whack-A-Mole
 * Activity 5
  */

using System;
using System.Collections.Generic;
using System.Text;

namespace WhackAMole.BusinessLogicLayer
{
    // Handles basic game logic like scoring and levels
    public class GameLogic
    {
        // Adds 1 point to the current score
        public int AddPoint(int score)
        {
            return score + 1;
        }

        // Removes 1 point if score is above 0
        public int RemovePoint(int score)
        {
            if (score > 0)
            {
                score--;
            }

            return score;
        }

        // Determines the level based on score
        public int GetLevel(int score)
        {
            if (score >= 10)
            {
                return 3;
            }
            else if (score >= 5)
            {
                return 2;
            }

            return 1;
        }

        // Checks if the game is over based on score or time
        public bool IsGameOver(int score, double secondsElapsed)
        {
            return score >= 10 || secondsElapsed >= 30;
        }
    }
}
