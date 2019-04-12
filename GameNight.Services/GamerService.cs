using GameNight.Data;
using GameNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNight.Services
{
    public class GamerService
    {
        private readonly Guid _gamerId;

        public GamerService(Guid gamerId)
        {
            _gamerId = gamerId;
        }

        public bool CreateGamer(GamerCreate model)
        {
            var entity =
                new Gamer()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailAddress = model.EmailAddress,
                    Location = model.Location
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Gamers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GamerListItem> GetGamers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Gamers
                    .Select(
                        e =>
                        new GamerListItem
                        {
                            GamerId = e.GamerId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            EmailAddress = e.EmailAddress,
                            Location = e.Location
                        }
                        );
                return query.ToArray();
            }
        }

    }

}
