using GameNight.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Models
{
    public class GameNightCreate
    {
        public int GameTimeId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public DateTimeOffset DateTime { get; set; }
        public string Location { get; set; }
        public Noobs NoobsAllowed { get; set; }
        public string Description { get; set; }
        public string TutorialVideo { get; set; }
        [Required]
        [Display(Name = "Game")]
        public int GameId { get; set; }
    }
}
