using System;
using System.Collections.Generic;
using System.Text;

namespace _2048WinFormsApp
{
    public class GameResult
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public GameResult(string name)
        {
            Name = name;
        }
    }
}
