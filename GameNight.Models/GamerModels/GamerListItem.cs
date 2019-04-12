using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Models
{
    public class GamerListItem
    {
        public int GamerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
