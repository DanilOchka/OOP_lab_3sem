using System;
using System.Collections.Generic;
using System.Text;
using Lab_2.Accounts;

namespace Lab_2.Games
{
       //в цій грі на бали грає лише один гшравець. його опонентом буе рандомний супротивник зі списку. Якщо твій рейтин більше або меншу в тебе додаються або віднімаються бали
    public class FortunaGame : BaseGame
    {
        public FortunaGame(GameAccount Player1,  int rating) : base(Player1, rating)
        {
            int n = rand.Next(0, GameAccount.allPlayers.Count);
            Player2 = GameAccount.allPlayers[n];
            if (Player2.UserName == Player1.UserName) {
                n++;
                Player2 = GameAccount.allPlayers[n];
            }

        }
        public override void PlayGame()
        {
            int r = (rand.Next(0, 2));
            if (Player1.GamecurrentRating > Player2.GamecurrentRating)
            {
                Player1.Win(this, Player2.UserName);

            }
            else if (Player1.GamecurrentRating == Player2.GamecurrentRating)
            {
                if (r == 0)
                {
                    Player1.Win(this, Player2.UserName);

                }
                else
                {
                    Player1.Lose(this, Player2.UserName);
                }
            }
            else {
                Player1.Lose(this, Player2.UserName);
            }
        }


        public override string Type()
        {
            return "FortunaGame ";
        }

    }
}
