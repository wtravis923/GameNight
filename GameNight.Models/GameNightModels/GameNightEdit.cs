using GameNight.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Models
{
    public class GameNightEdit
    {
        public int GameTimeId { get; set; }
        public Guid OwnerId { get; set; }
        [Display(Name = "When")]
        public DateTimeOffset DateTime { get; set; }
        [Display(Name = "Where")]
        public string Location { get; set; }
        [Display(Name = "Noobs Welcome?")]
        public Noobs NoobsAllowed { get; set; }
        public string Description { get; set; }
        [Display(Name = "Tutorial")]
        public string TutorialVideo { get; set; }
        
        public virtual Game Game { get; set; }
        [Display(Name = "Game")]
        public int GameId { get; set; }
        public string Title { get; set; }
        public GameGenre Genre { get; set; }
        public int PlayerCount { get; set; }

        public virtual Gamer Gamer { get; set; }
        [Display(Name = "Host")]
        public int GamerId { get; set; }
        public string GamerTag { get; set; }
    }
}
