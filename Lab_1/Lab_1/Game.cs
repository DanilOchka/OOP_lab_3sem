using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1
{
    public class Game
    {
        public string User { get; }
        public string Opponent { get; }
        public string G_id { get; }
        public int GRating { get; }
        public int Num_of_Game { get; }

        public string Status;

        public Game(string id, string name, string opponent, int game_raiting, string s, int gameCount)
        {
            Num_of_Game = gameCount; //кількість ігор
            User = name;
            Opponent = opponent;
            G_id = id; //ід гри
            GRating = game_raiting;
            Status = s;

        }
    }
}
