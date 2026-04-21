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
    public class GameLogic
    {
        public int AddPoint(int score)
        {
            return score + 1;
        }

        public int RemovePoint(int score)
        {
            if (score > 0)
            {
                score--;
            }

            return score;
        }

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

        public bool IsGameOver(int score, double secondsElapsed)
        {
            return score >= 10 || secondsElapsed >= 30;
        }
    }
}
