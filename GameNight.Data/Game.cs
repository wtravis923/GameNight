using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Data
{
    public enum GameGenre { Card, Dice, Party, RolePlaying, Strategy };

    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public GameGenre Genre { get; set; }
        [Required]
        public int PlayerCount { get; set; }

    }
}
