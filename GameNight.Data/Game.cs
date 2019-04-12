using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Data
{
    public enum GameGenre { Strategy, Card, Dice, RolePlaying };

    public class Game
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public GameGenre Genre { get; set; }
        public int PlayerCount { get; set; }

    }
}
