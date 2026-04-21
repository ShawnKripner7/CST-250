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
using WhackAMole.Models;

namespace WhackAMole.DataAccessLayer
{
    public class GameStatsDAO
    {
        public void SaveGameStats(GameStatsModel gameStats)
        {
            string filePath = "GameStats.txt";

            string gameData = "Score: " + gameStats.Score +
                              ", Level: " + gameStats.Level +
                              ", Time: " + gameStats.TimeElapsed;

            File.AppendAllText(filePath, gameData + Environment.NewLine);
        }
    }
}
