using GameNight.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Models
{
    public class GameDetail
    {
        public int GameId { get; set; }
        public Guid OwnerId { get; set; }
        public string Title { get; set; }
        public GameGenre Genre { get; set; }
        public int PlayerCount { get; set; }
    }
}
