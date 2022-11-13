using System;
using System.Collections.Generic;
using System.Text;
using Lab_2.Games;

namespace Lab_2.Accounts
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

        protected List<PlayerGames> gameList = new List<PlayerGames>();
        public static List<GameAccount> allPlayers = new List<GameAccount>(); //список усых гравцыв

        //перелік статусів можливих завершень гри

        //змінна поточного рейтингу гравця (обраховується шляхом додавання всіх рейтингів які зароблені або втрачені в іграх)
        private int gamecurrentRating; 
        public int GamecurrentRating
        {
            get { return gamecurrentRating; }
            set
            {

                if (value <= 0) { 
                    gamecurrentRating = 1;
                }
                else {
                    gamecurrentRating = value; 
                }
            }
        }

        
        public int GamesCount
        {
            get
            {
                int current = 1;


                foreach (var item in gameList)
                {
                    current++;

                }
                return current;
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
            gamecurrentRating = First_Rating; //початковий рейтинг кожного гравця призначається тут
            allPlayers.Add(this);
        }


        public virtual void Win(BaseGame game, string opponent)
        {
            
            GamecurrentRating = GamecurrentRating + game.GR;
            PlayerGames win = new PlayerGames(game.CurID, UserName, opponent, game.GR, GamecurrentRating, ((Status_of_Game)0), GamesCount, game.Type());
            gameList.Add(win);
        }

        public virtual void Lose(BaseGame game, string opponent)
        {
                    
                
            GamecurrentRating = GamecurrentRating - game.GR;

            //GamesCount++;
            PlayerGames lose = new PlayerGames(game.CurID, UserName, opponent, -game.GR, GamecurrentRating, ((Status_of_Game)1), GamesCount, game.Type());
            gameList.Add(lose);

        }

        //метод генерації випадкового шестизначног ID гри
        public string GenerID()
        {
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
            int allRating = 0;
            report.AppendLine(" ________________________________________________________________________________________________________________________________________");
            report.AppendLine(" №\t |\tUsername\t |\tOpponent\t |\tID\t |\tType\t |   GameRating   |\tStatus\t |   CurRating   |");
            foreach (var item in gameList)
            {
                allRating = item.GRatingUser;
                report.AppendLine($" {item.Num_of_Game}\t |\t{UserName}\t |\t{item.Opponent}\t |\t {item.G_id}\t |  {item.TypeofGame} |\t {item.GRating}\t  |\t {item.Status}\t |\t {allRating}\t |");

            }
            report.AppendLine(" ________________________________________________________________________________________________________________________________________|");


            return report.ToString();
        }
    }
}
