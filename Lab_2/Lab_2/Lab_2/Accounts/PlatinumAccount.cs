using System;
using System.Collections.Generic;
using System.Text;
using Lab_2.Games;

namespace Lab_2.Accounts
{
    class PlatinumAccount : GoldAccount
    {
        private int Mult = 1;
        public PlatinumAccount(string name) : base(name)
        {
            UserName = name + "**";
        }

        public override void Win(BaseGame game, string opponent)
        {
            Mult++;
            if (Mult == 3)
            {
                GamecurrentRating = GamecurrentRating + game.GR + 5;
                Mult = 0;
            }
            else {
                GamecurrentRating = GamecurrentRating + game.GR;
            }

            PlayerGames win = new PlayerGames(game.CurID, UserName, opponent, game.GR, GamecurrentRating, ((Status_of_Game)0), GamesCount, game.Type());
            gameList.Add(win);
            
        }

        public override void Lose(BaseGame game, string opponent)
        {
            Mult = 0;

            GamecurrentRating = GamecurrentRating - (int)(game.GR / 2);
            PlayerGames lose = new PlayerGames(game.CurID, UserName, opponent, -game.GR, GamecurrentRating, ((Status_of_Game)1), GamesCount, game.Type());
            gameList.Add(lose);


        }
    }
}
