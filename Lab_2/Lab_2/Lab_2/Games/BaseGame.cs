using System;
using System.Collections.Generic;
using System.Text;
using Lab_2.Accounts;

namespace Lab_2.Games
{
    public abstract class BaseGame
    {
        protected Random rand = new Random();
        protected GameAccount Player1;
        protected GameAccount Player2;
        protected static List<string> idList = new List<string>();
        public string CurID { get; set; }

        private int _GR = 0;

        public int GR
        {
            get {
                return _GR; 
            }
            set {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(_GR), "Рейтинг на який грають має бути додатнiм");
                }
                else {
                    _GR = value;
                }
            }
        }

        public BaseGame(GameAccount Player1, GameAccount Player2)
        {
            this.Player1 = Player1;
            this.Player2 = Player2;
            CurID = GenerID();
            idList.Add(CurID);
        }

        public BaseGame(GameAccount Player1, GameAccount Player2, int rating)
        {
            this.Player1 = Player1;
            this.Player2 = Player2;
            CurID = GenerID();
            idList.Add(CurID);
            _GR = rating;
        }
        public BaseGame(GameAccount Player1, int rating)
        {
            this.Player1 = Player1;
            CurID = GenerID();
            idList.Add(CurID);
            _GR = rating;
        }

        public string GenerID()
        {
            string id = (rand.Next(0, 10)).ToString() + (rand.Next(0, 10)).ToString() + (rand.Next(0, 10)).ToString() + (rand.Next(0, 10)).ToString() + (rand.Next(0, 10)).ToString() + (rand.Next(0, 10)).ToString();

            //перевірка чи інує вже згенероване ід гри, якщо так метод перезапускається і продовжує генрувати поки не стоврить унікальне число
            foreach (var item in idList)
            {
                if (id == item)
                {
                    id = GenerID();
                }

            }
            return id;
        }

        public abstract string Type();

        public abstract void PlayGame();
    }

}
