using System;
using System.Collections.Generic;


namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторна робота №1\nГолосний Данило ТР-11\n\nПравила гри:\n1)У кожного гравця початковий рейтинг = 10;\n2) Рейтинг гравця нiколи не може бути менше < 1\n(якщо гравець програє i його рейтинг не достатнiй то у нього вiднiмається та кiлкiсть балiв щоб в кiнцi гри залишилася 1)");
            Random rand = new Random();

            GameAccount play1 = new GameAccount("Danylo01");
            GameAccount play2 = new GameAccount("Vasilo02");
            GameAccount play3 = new GameAccount("Kirilo03");
            for (int i = 0; i < 10; i++) {
                play1.Play_game(play2, rand.Next(1,11));
            }
             
            for (int i = 0; i <5; i++)
            {
                play1.Play_game(play3, rand.Next(1, 11));
            }
            for (int i = 0; i < 5; i++)
            {
                play2.Play_game(play3, rand.Next(1, 11));
            }

            Console.WriteLine(play1.GetStats());

            Console.WriteLine(play2.GetStats());

            Console.WriteLine(play3.GetStats());

        }
    } 
}