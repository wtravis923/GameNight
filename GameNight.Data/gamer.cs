using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Data
{
    public class Gamer
    {
        [Key]
        public int GamerId { get; set; }
        public string GamerTag { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Location { get; set; }
    }
}
