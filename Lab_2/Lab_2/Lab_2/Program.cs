using System;
using Lab_2.Accounts;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторна робота №1\nГолосний Данило ТР-11\n\nПравила гри:\n1)У кожного гравця початковий рейтинг = 10;\n2) Рейтинг гравця нiколи не може бути менше < 1\n(якщо гравець програє i його рейтинг не достатнiй то у нього вiднiмається та кiлкiсть балiв щоб в кiнцi гри залишилася 1)\n\nВ грi iснує три типiв акаунтiв:\nGameAccount - звичайни йакаунт;\nGoldAccount* - за програш знiмається вiдвiчi менше балiв;\nPlatinumAccount** - за програш знiмається вiдвiчi менше балiв + за три перемоги пiдряд дарується додатковi 5 балiв\n\nВ грi iснує три типи iгор:\nRaitingGame - гра на рейтинг проти обраного гравця(випадковий переможець);\nTrainingGame - тренувальна гра без рейтингу (випадковий переможець)\nFortunaGame - гра на удачу ивбирається випадковий супротивник, якщо в тебе рейтинг блiьше ти виграєш, якщо менше програєш (рейтинг береться лише в тебе)\n");
            Random rand = new Random();

            GameAccount play1 = new GameAccount("Danylo01");
            GameAccount play2 = new GameAccount("Vasilo02");
            GameAccount play3 = new GameAccount("Kirilo03");
            GoldAccount play4 = new GoldAccount("Danylo02");
            PlatinumAccount play5 = new PlatinumAccount("Danylo03");

            InitGames fight = new InitGames();

            /*
            fight.createRaitingGame(play1, play4, rand.Next(1, 11)).PlayGame();
            fight.createRaitingGame(play4, play5, rand.Next(1, 11)).PlayGame();

            fight.createTrainingGame(play1, play4).PlayGame();
            fight.createTrainingGame(play4, play5).PlayGame();
            */

            for (int i = 0; i < 5; i++)
            {
                fight.createRaitingGame(play1, play5, rand.Next(1, 11)).PlayGame();
            }

            for (int i = 0; i < 5; i++)
            {
                fight.createRaitingGame(play2, play4, rand.Next(1, 11)).PlayGame();
            }

            for (int i = 0; i < 5; i++)
            {
                fight.createFortunaGame(play3, rand.Next(1, 11)).PlayGame();
            }

            for (int i = 0; i < 5; i++)
            {
                fight.createTrainingGame(play5, play3).PlayGame();
            }

            Console.WriteLine(play1.GetStats());

            Console.WriteLine(play2.GetStats());

            Console.WriteLine(play3.GetStats());

            Console.WriteLine(play4.GetStats());

            Console.WriteLine(play5.GetStats());
        }
    }
}
