using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1
{
    public enum Status_of_Game
    {
        Win,
        Lose,
        START,
    }
    public class GameAccount
    {
        private int First_Rating = 10; //початковий рейтинг кожного гшраця
        public string UserName { get; set; } //Ім'я гравця

        public  List<Game> gameList = new List<Game>();

        //перелік статусів можливих завершень гри
        
        //змінна поточного рейтингу гравця (обраховується шляхом додавання всіх рейтингів які зароблені або втрачені в іграх)
        public int CurrentRating
        {
            get
            {
                int currentRating = First_Rating;


                foreach (var item in gameList)
                {
                    currentRating += item.GRating;

                }
                return currentRating;
            }

        }
        public int GamesCount {
            get
            {
                int currentRating = 1;


                foreach (var item in gameList)
                {
                    currentRating++;

                }
                return currentRating;
            }

            
        } //кількість зіграних партій ігор одного гравця (просто лічильникігор).

        private static List<string> AllNames = new List<string>(); //створення загального списку імен гравців

        Random rand = new Random();

        
        public GameAccount(string name)
        {
            if (AllNames.Contains(name))
            {
                throw new ArgumentException('"' + name + '"' + " Це iмя'я вже зайнято");
            }
            AllNames.Add(name);
            //Game start_point = new Game("START", UserName, "START\t", First_Rating, ((Status_of_Game)2), GamesCount);
            //gameList.Add(start_point);

            UserName = name;
            //GamesCount = 0; //початкова кількість зігарних ігор

        }

        //клас рандомної ініціаліхації гри (випадковим чином призначаються перемоги та програші)
        public void Play_game(GameAccount opponent, int game_rating)
        {
            string curr_id = GenerID();// присвоєюмо цій пратії своє унікальне ід та передаємо його самогму гравцю та опоненту
            if (game_rating <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game_rating), "Рейтинг на який грають має бути додатнiм");
            }

            int r = (rand.Next(0, 2));
            if (r == 0)
            {
                Win(opponent, game_rating, curr_id);
                opponent.Lose(this, game_rating, curr_id);

            }
            else
            {
                Lose(opponent, game_rating, curr_id);
                opponent.Win(this, game_rating, curr_id);
            }

        }

        public void Win(GameAccount opponent, int game_rating, string g_id)
        {
            if (game_rating <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game_rating), "Рейтинг на який грають має бути додатнiм");
            }
            //GamesCount++;
            Game win = new Game(g_id, UserName, opponent.UserName, game_rating, ((Status_of_Game)0), GamesCount);
            gameList.Add(win);
            //Console.WriteLine("Гру проведено успiшно. Ви отримали +" + game_rating + " балiв.");
        }

        public void Lose(GameAccount opponent, int game_rating, string g_id)
        {
            if (game_rating <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game_rating), "Рейтинг на який грають має бути додатнiм");
            }
            int minus;
            if (CurrentRating <= game_rating)
            {
                minus = 1 - CurrentRating;

            }
            else
            {
                minus = -game_rating;
            }
            //GamesCount++;
            Game lose = new Game(g_id, UserName, opponent.UserName, minus, ((Status_of_Game)1), GamesCount);
            gameList.Add(lose);
            //Console.WriteLine("Гру проведено успiшно. Ви отримали " +  minus + " балiв.");

        }

        //метод генерації випадкового шестизначног ID гри
        public string GenerID()
        {

            //Random rand = new Random();
            string id = (rand.Next(0, 10)).ToString() + (rand.Next(0, 10)).ToString() + (rand.Next(0, 10)).ToString() + (rand.Next(0, 10)).ToString() + (rand.Next(0, 10)).ToString() + (rand.Next(0, 10)).ToString();
            //перевірка чи інує вже згенероване ід гри, якщо так метод перезапускається і продовжує генрувати поки не стоврить унікальне число
            foreach (var item in gameList)
            {
                if (id == item.G_id)
                {
                    id = GenerID();
                }

            }
            return id;
        }


        public string GetStats()
        {
            Console.WriteLine("\n\nСтатистика гравця " + UserName);
            var report = new System.Text.StringBuilder();
            int allRating = First_Rating;
            report.AppendLine(" ________________________________________________________________________________________________________________________");
            report.AppendLine(" №\t |\tUsername\t |\tOpponent\t |\tID\t |   GameRating   |\tStatus\t |   CurRating   |");
            foreach (var item in gameList)
            {
                allRating += item.GRating;
                report.AppendLine($" {item.Num_of_Game}\t |\t{UserName}\t |\t{item.Opponent}\t |\t {item.G_id}\t |\t {item.GRating}\t  |\t {item.Status}\t |\t {allRating}\t |");

            }
            report.AppendLine(" ________________________________________________________________________________________________________________________|");


            return report.ToString();
        }
    }
}
