using GameNight.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Models.GameModels
{
    public class GameEdit
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public GameGenre Genre { get; set; }
        public int PlayerCount { get; set; }
    }
}
