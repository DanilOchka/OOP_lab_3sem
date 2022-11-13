using System;
using System.Collections.Generic;
using System.Text;
using Lab_2.Accounts;

namespace Lab_2.Games
{
    class RaitingGame : BaseGame
    {
        public RaitingGame(GameAccount Player1, GameAccount Player2, int rating) : base(Player1, Player2, rating) { 
        
        }

        public override string Type() {
            return "RaitingGame ";
        }

        public override void PlayGame()
        {
            int r = (rand.Next(0, 2));
            if (r == 0)
            {
                Player1.Win(this, Player2.UserName);
                Player2.Lose(this, Player1.UserName);

            }
            else
            {
                Player1.Lose(this, Player2.UserName);
                Player2.Win(this, Player1.UserName);
            }
        }

    }
}
