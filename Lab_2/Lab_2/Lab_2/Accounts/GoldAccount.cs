using System;
using System.Collections.Generic;
using System.Text;
using Lab_2.Games;

namespace Lab_2.Accounts
{
    
    //Золотий Акаунт знімає в два рази менше балів за програш
    public class GoldAccount : GameAccount
    {
        public GoldAccount(string name) : base(name) {
            UserName = name + '*';
        }


        
        //модифікований метод ПРОГРАШУ (знімається в два рази менше балів рейтингу)
        public override void Lose(BaseGame game, string opponent)
        {
           

            GamecurrentRating = GamecurrentRating - (int)(game.GR/2);
            PlayerGames lose = new PlayerGames(game.CurID, UserName, opponent, -game.GR, GamecurrentRating, ((Status_of_Game)1), GamesCount, game.Type());
            gameList.Add(lose);


        }        
    }

}
