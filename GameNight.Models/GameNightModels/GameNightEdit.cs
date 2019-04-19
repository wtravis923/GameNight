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
        [Required]
        public int GameId { get; set; }
    }
}
