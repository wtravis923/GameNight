using GameNight.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Models
{
    public class GameCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public GameGenre Genre { get; set; }
        [Required]
        public int PlayerCount { get; set; }

        public override string ToString() => Title;
    }
}
