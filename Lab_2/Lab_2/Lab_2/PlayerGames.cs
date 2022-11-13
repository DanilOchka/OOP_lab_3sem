using System;
using System.Collections.Generic;
using System.Text;
using Lab_2.Accounts;


namespace Lab_2
{
    public class PlayerGames
    {
        public string TypeofGame { get; }
        public string User { get; }
        public string Opponent { get; }
        public string G_id { get; }
        public int GRating { get; }
        public int GRatingUser { get; }
        public int Num_of_Game { get; }

        public Status_of_Game Status;

        public PlayerGames(string id, string name, string opponent, int game_raiting, int game_r_user, Status_of_Game s, int gameCount, string type)
        {
            Num_of_Game = gameCount; //кількість ігор
            User = name;
            Opponent = opponent;
            G_id = id; //ід гри
            GRating = game_raiting;
            Status = s;
            GRatingUser = game_r_user;
            TypeofGame = type;

        }
    }
}
