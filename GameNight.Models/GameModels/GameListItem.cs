using GameNight.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Models
{
    public class GameListItem
    {
        public int GameId { get; set; }

        public string Title { get; set; }
        public GameGenre Genre { get; set; }
        [Display(Name = "Max Players")]
        public int PlayerCount { get; set; }

        [Display(Name = "Host")]
        public string GamerTag { get; set; }

        public override string ToString() => Title; 
    }
}
