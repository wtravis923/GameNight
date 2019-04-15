using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Models
{
    public class GameNightListItem
    {
        public int GameTimeId { get; set; }
        public Guid OwnerId { get; set; }
        [Display(Name="When")]
        public DateTimeOffset DateTime { get; set; }
        public string Location { get; set; }
        public bool NoobsAllowed { get; set; }
        public string Description { get; set; }
        public string TutorialVideo { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
