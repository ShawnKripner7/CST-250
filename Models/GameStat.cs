/*
 * Shawn Kripner
 * CST-250
 * 4/23/2026
 * Minesweeper Project
 * Milestone 5
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperClassLibrary.Models
{
    // stores information about a completed game
    public class GameStat
    {
        public int Id { get; set; }

        // name of the player
        public string Name { get; set; }

        // final score from the game
        public int Score { get; set; }

        // how long the game took
        public TimeSpan GameTime { get; set; }

        // date the game was played
        public DateTime DatePlayed { get; set; }

        public GameStat(int id, string name, int score, TimeSpan gameTime)
        {
            Id = id;
            Name = name;
            Score = score;
            GameTime = gameTime;
            DatePlayed = DateTime.Now;
        }
    }
}