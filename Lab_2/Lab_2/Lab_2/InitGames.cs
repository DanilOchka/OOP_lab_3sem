using System;
using System.Collections.Generic;
using System.Text;
using Lab_2.Accounts;
using Lab_2.Games;


namespace Lab_2
{
        public class InitGames
        {
            public BaseGame createRaitingGame(GameAccount Player1, GameAccount Player2, int points)
            {
                return new RaitingGame(Player1, Player2, points);
            }

        public BaseGame createTrainingGame(GameAccount Player1, GameAccount Player2)
        {
            return new TrainingGame(Player1, Player2);
        }
        public BaseGame createFortunaGame(GameAccount Player1, int points)
        {
            return new FortunaGame(Player1, points);
        }

    }
    
}
