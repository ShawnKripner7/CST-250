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

namespace WhackAMole.Models
{
    public class GameStatsModel
    {
        public int Score { get; set; }
        public int Level { get; set; }
        public TimeSpan TimeElapsed { get; set; }
    }
}
