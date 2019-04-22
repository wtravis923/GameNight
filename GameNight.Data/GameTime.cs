using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Data
{
    public enum Noobs { Yes, No }
    public class GameTime
    {
        [Key]
        public int GameTimeId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public DateTimeOffset DateTime { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public Noobs NoobsAllowed { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string TutorialVideo { get; set; }

        [Required]
        [Display(Name = "Game")]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        //public string Title { get; set; }
        //public GameGenre Genre { get; set; }
        //public int PlayerCount { get; set; }
    }
}
